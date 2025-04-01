using System;
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

        Socket server;
        private bool showPassword_l, showPassword_r = false;
        public Form_login()
        {
            InitializeComponent();
            register_passw_txt.PasswordChar = '*';
            loggin_password_txt.PasswordChar = '*';
        }

        public void SetServer(Socket server)
        {
            this.server = server;
        }

        private void Register_btn_Click(object sender, EventArgs e)
        {
            
            if (Register_txt.Text.Length != 0 && register_passw_txt.Text.Length != 0 && server != null)
            {
                if (server.Connected)
                {
                    try
                    {
                        string mensaje = "2/" + Register_txt.Text + "/" + register_passw_txt.Text;
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);

                        byte[] msg2 = new byte[80];
                        server.Receive(msg2);
                        mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                        if (mensaje == "Si")
                        {
                            MessageBox.Show("Registro Completado");
                            Register_txt.Text = "";
                            register_passw_txt.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Error al registrar");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cerrar la conexión: " + ex.Message);
                    }
                }
            }            
        }

        private void Loggin_btn_Click(object sender, EventArgs e)
        {
            if (Loggin_txt.Text.Length != 0 && loggin_password_txt.Text.Length != 0 && server != null)
            {
                if (server.Connected)
                {
                    try
                    {
                        string mensaje = "1/" + Loggin_txt.Text + "/" + loggin_password_txt.Text;
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);

                        byte[] msg2 = new byte[80];
                        server.Receive(msg2);
                        mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

                        if (mensaje != "0")
                        {
                            MessageBox.Show("Bienvenido de vuelta jugador " + mensaje);

                            Form_query form_query = new Form_query();
                            form_query.SetUser(mensaje);
                            form_query.SetServer(this.server);
                            form_query.Show();
                            this.Close(); // Cierra el form_login
                        }
                        else
                        {
                            MessageBox.Show("Username desconocido");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cerrar la conexión: " + ex.Message);
                    }
                }
            }
        }

        private void checkBox_r_CheckedChanged(object sender, EventArgs e)
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

        private void checkBox_l_CheckedChanged(object sender, EventArgs e)
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

        private void Form_login_Load(object sender, EventArgs e)
        {

        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            if(server != null)
            {
                if (server.Connected)
                {
                    try
                    {
                        string mensaje = "0/";
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);

                        server.Send(msg);
                        server.Shutdown(SocketShutdown.Both);
                        server.Close();

                        Form_connect form_connect = new Form_connect();
                        form_connect.SetServer(this.server);
                        form_connect.Show();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cerrar la conexión: " + ex.Message);
                    }
                }
            }
        }

    }

}

