using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Cliente
{
    public partial class Form_query : Form
    {
        Socket server;
        Thread atender;
        string user;
        public Form_query()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;

            ThreadStart ts = delegate { AtenderServidor(); };
            atender = new Thread(ts);
            atender.Start();
        }

        public void SetServer(Socket server)
        {
            this.server = server;
        }

        public void SetUser(string username)
        {
            this.user = username;
            username_lbl.Text = "@" + user;
        }

        private List<string> usuariosConectados = new List<string>();

        public List<string> ObtenerUsuariosConectados()
        {
            return new List<string>(usuariosConectados); // Retorna una copia de la lista
        }
        private void Query_btn_Click(object sender, EventArgs e)
        {

            if (Query_txt.Text.Length != 0 && server != null)
            {
                if (server.Connected)
                {
                    try
                    {
                        if (radioButton1.Checked)
                        {
                            string mensaje = "3/" + Query_txt.Text + "\0";
                            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                            server.Send(msg);

                        }
                        else if (radioButton2.Checked)
                        {
                            string mensaje = "4/" + Query_txt.Text + "\0";
                            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                            server.Send(msg);
                        }
                        else
                        {
                            string mensaje = "5/" + Query_txt.Text + "\0";
                            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                            server.Send(msg);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cerrar la conexión: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("No se ha detectado ID de la partida en el campo de texto. Por favor introduzca la ID deseada.");
            }
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            if (server != null && server.Connected)
            {
                string mensaje = "8/" + this.user + "\0";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                atender.Abort();

                Form_connect form_connect = new Form_connect();
                form_connect.SetServer(this.server);
                form_connect.Show();

                mensaje = "0/\0";
                msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                try
                {
                    server.Send(msg);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cerrar la conexión: " + ex.Message);
                }

                this.Close();
            }
        }

        private void Service_btn_Click(object sender, EventArgs e)
        {
            string mensaje = "6/\0";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void AtenderServidor()
        {
            while (true)
            {
                if (server != null && server.Connected)
                {
                    int numUsuarios;
                    byte[] msg2 = new byte[1024]; // Aumentamos el tamaño del buffer
                    server.Receive(msg2);
                    string[] trozos = Encoding.ASCII.GetString(msg2).Split('/');
                    int codigo = Convert.ToInt32(trozos[0]);
                    string mensaje = trozos[1].Split('\0')[0];
                    switch (codigo)
                    {
                        case 1: //consultar usuario
                            break;
                        case 2://insertar usuario
                            break;
                        case 3://consultar tiempo
                            if (mensaje != "0")
                            {
                                MessageBox.Show("La partida se jugo: " + mensaje);
                            }
                            else
                            {
                                MessageBox.Show("La partida no se ha encontrado");
                            }
                            break;
                        case 4://consultar duracion
                            if (mensaje != "0")
                            {
                                MessageBox.Show("La partida duró: " + mensaje + " minutos");
                            }
                            else
                            {
                                MessageBox.Show("La partida no se ha encontrado");
                            }
                            break;
                        case 5://consultar ganador
                            if (mensaje != "0")
                            {
                                MessageBox.Show("El ganador fue el jugador: " + mensaje);
                            }
                            else
                            {
                                MessageBox.Show("La partida no se ha encontrado");
                            }
                            break;
                        case 6://contador
                            ServiceLbl.Text = mensaje;
                            break;
                        case 7: // Consultar lista conectados
                            usuariosConectados.Clear();

                            numUsuarios = int.Parse(trozos[1]);
                            Online_lbl.Text = $"Conectados ({numUsuarios}):\n";

                            for (int i = 2; i <= numUsuarios + 1; i++)
                            {
                                string nombre = trozos[i];
                                usuariosConectados.Add(nombre);
                                Online_lbl.Text += nombre + "\n";
                            }
                            break;
                        case 9:
                            if (mensaje != "0")
                            {
                                Form_Invitacion invitacion = new Form_Invitacion(mensaje);
                                var resultado = invitacion.ShowDialog();

                                if (resultado == DialogResult.OK && invitacion.Aceptado)
                                {
                                    // Aquí puedes enviar al servidor que aceptó la invitación
                                    string respuesta = "10/" + user + "/acepta/" + mensaje + "\0";
                                    byte[] msgAceptar = Encoding.ASCII.GetBytes(respuesta);
                                    server.Send(msgAceptar);
                                }
                                else
                                {
                                    // Aquí puedes enviar al servidor que rechazó
                                    string respuesta = "10/" + user + "/rechaza/" + mensaje + "\0";
                                    byte[] msgRechazar = Encoding.ASCII.GetBytes(respuesta);
                                    server.Send(msgRechazar);
                                }
                            }
                            break;
                        case 10:
                            if (mensaje != "0")
                            { 
                                MessageBox.Show(mensaje);
                            }
                            break;
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (server.Connected)
            {
                MessageBox.Show("Usuarios conectados: " + string.Join(", ", usuariosConectados));

                this.Hide();

                Form_loby form_loby = new Form_loby();
                form_loby.SetServer(this.server);
                form_loby.SetUser(this.user); 
                form_loby.SetUsuariosConectados(usuariosConectados);
                form_loby.Show();
            }
        }
    }
}