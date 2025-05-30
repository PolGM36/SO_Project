﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net;
using Cliente;


namespace Cliente
{
    public partial class Form_login : Form
    {
        //Definición de Socket y delegate void para la edición de labels con cross-threading protection
        Socket server;
        private bool showPassword_l, showPassword_r = false;
        delegate void DelegadoParaEscribir1(string mensaje);
        delegate void DelegadoParaEscribir2(string mensaje);
        public Form_login()
        {
            InitializeComponent();
            //Para que la contraseña no se vea a priori
            register_passw_txt.PasswordChar = '*';
            loggin_password_txt.PasswordChar = '*';
        }

        public void SetServer(Socket server) //Función para definir el socket
        {
            this.server = server;
        }

        private void Register_btn_Click(object sender, EventArgs e)  //Bontón register: Función para registrar un usuario
        {
            
            if (Register_txt.Text.Length != 0 && register_passw_txt.Text.Length != 0 && server != null)
            {
                if (server.Connected)
                {
                    string mensaje = "2/" + Register_txt.Text + "/" + register_passw_txt.Text; //Peticion de registro
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    byte[] msg2 = new byte[80];
                    try
                    {
                        server.Receive(msg2); //Respuesta del servidor
                        string[] trozos = Encoding.ASCII.GetString(msg2).Split('/');
                        int codigo = Convert.ToInt32(trozos[0]);
                        mensaje = trozos[1].Split('\0')[0];

                        if (mensaje == "Si") //Registro Correcto
                        {
                            RegisterLbl.ForeColor = Color.Black;
                            DelegadoParaEscribir2 delegado2 = new DelegadoParaEscribir2(Cambiar2);
                            RegisterLbl.Invoke(delegado2, new object[] { "Registro Completado" });
                            Register_txt.Text = "";
                            register_passw_txt.Text = "";
                        }
                        else //Usuario ya existente
                        {
                            RegisterLbl.ForeColor = Color.OrangeRed;
                            DelegadoParaEscribir2 delegado2 = new DelegadoParaEscribir2(Cambiar2);
                            RegisterLbl.Invoke(delegado2, new object[] { "Error al registrar" });
                        }
                    }
                    catch (Exception ex) //Mensaje de error
                    {
                        MessageBox.Show("Error al cerrar la conexión: " + ex.Message);
                    }
                }
            }            
        }

        private void Loggin_btn_Click(object sender, EventArgs e) //Bontón login: Función para entrar al juego con un usuario registrado
        {
            if (Loggin_txt.Text.Length != 0 && loggin_password_txt.Text.Length != 0 && server != null)
            {
                if (server.Connected)
                {
                    try
                    {

                        string mensaje = "1/" + Loggin_txt.Text + "/" + loggin_password_txt.Text; //Petición de login
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);

                        byte[] msg2 = new byte[80];
                        server.Receive(msg2); //Respuesa Servidor
                        string[] trozos = Encoding.ASCII.GetString(msg2).Split('/');
                        int codigo = Convert.ToInt32(trozos[0]);
                        mensaje = trozos[1].Split('\0')[0];

                        if (mensaje != "0" && mensaje != "-1") //Usuario existente y no conectado
                        {
                            Form_query form_query = new Form_query();
                            form_query.SetUser(mensaje);
                            form_query.SetServer(this.server);
                            form_query.Show();

                            mensaje = "7/";
                            msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                            server.Send(msg);

                            this.Close(); // Cierra el form_login
                        }
                        else if(mensaje == "-1") //Usuario ya conectado
                        {
                            DelegadoParaEscribir1 delegado1 = new DelegadoParaEscribir1(Cambiar1);
                            LoginLbl.Invoke(delegado1, new object[] { "Usuario ya conectado" });
                        }
                    }
                    catch (Exception ex) //Usuario no existente o contraseña mal introducida
                    {
                        DelegadoParaEscribir1 delegado1 = new DelegadoParaEscribir1(Cambiar1);
                        LoginLbl.Invoke(delegado1, new object[] { "Usuario o contraseña mal introducidos" });
                    }
                }
            }
        }

        private void checkBox_r_CheckedChanged(object sender, EventArgs e) //Para ver la contraseña en el registro
        {
            showPassword_r = !showPassword_r;
            if (showPassword_r)
            {
                register_passw_txt.PasswordChar = '\0';
            }
            else
            {
                register_passw_txt.PasswordChar = '*';
            }
        }

        private void checkBox_l_CheckedChanged(object sender, EventArgs e) //Para ver la contraseña en el login
        {
            showPassword_l = !showPassword_l;
            if (showPassword_l)
            {
                loggin_password_txt.PasswordChar = '\0';
            }
            else
            {
                loggin_password_txt.PasswordChar = '*';
            }
        }

        public void Cambiar1(string mensaje) //Función para escribir en el label de login (Cross-Threading Protection)
        {
            LoginLbl.Text = mensaje;
        }

        public void Cambiar2(string mensaje) //Función para escribir en el label de register (Cross-Threading Protection)
        {
            RegisterLbl.Text = mensaje;
        }

        private void Form_login_Load(object sender, EventArgs e)
        {

        }

        private void back_btn_Click(object sender, EventArgs e) //Botón back: Desconecta el usuario y devuelve a la pantalla inicial
        {
 
            string mensaje = "0/"; //Petición de Desconexión
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            try
            {
                server.Send(msg);
                server.Shutdown(SocketShutdown.Both);
                server.Close();     
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cerrar la conexión: " + ex.Message);
            }
            Form_connect form_connect = new Form_connect();
            
            form_connect.Show();
            this.Close();
        }

    }

}

