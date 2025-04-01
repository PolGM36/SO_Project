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

namespace Cliente
{
    public partial class Form_query: Form
    {
        Socket server;
        string user;
        public Form_query()
        {
            InitializeComponent();
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
                            string mensaje = "3/" + Query_txt.Text;
                            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                            server.Send(msg);

                            byte[] msg2 = new byte[80];
                            server.Receive(msg2);
                            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                            if (mensaje != "0")
                            {
                                MessageBox.Show("La partida se jugo: " + mensaje);
                            }
                            else
                            {
                                MessageBox.Show("La partida no se ha encontrado");
                            }
                        }
                        else if (radioButton2.Checked)
                        {
                            string mensaje = "4/" + Query_txt.Text;
                            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                            server.Send(msg);

                            byte[] msg2 = new byte[80];
                            server.Receive(msg2);
                            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

                            if (mensaje != "0")
                            {
                                MessageBox.Show("La partida duró: " + mensaje + " minutos");
                            }
                            else
                            {
                                MessageBox.Show("La partida no se ha encontrado");
                            }
                        }
                        else
                        {
                            string mensaje = "5/" + Query_txt.Text;
                            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                            server.Send(msg);

                            byte[] msg2 = new byte[80];
                            server.Receive(msg2);
                            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];


                            if (mensaje != "0")
                            {
                                MessageBox.Show("El ganador fue el jugador: " + mensaje);
                            }
                            else
                            {
                                MessageBox.Show("La partida no se ha encontrado");
                            }
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
                string mensaje = "8/" + this.user;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                this.Hide(); // Oculta en vez de cerrar
                Form_login form_login = new Form_login();
                form_login.SetServer(server); // Mantiene la misma conexión
                form_login.Show();
            }
        }

        private void Service_btn_Click(object sender, EventArgs e)
        {
            string mensaje = "6/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
            ServiceLbl.Text = mensaje;
        }

        private void OnlineList_btn_Click(object sender, EventArgs e)
        {
            string mensaje = "7/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            byte[] msg2 = new byte[1024]; // Aumentamos el tamaño del buffer
            server.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

            // Procesar la lista de conectados
            string[] partes = mensaje.Split('/');
            int numUsuarios = int.Parse(partes[0]); // Primer elemento es el número de usuarios

            // Mostrar en Label con saltos de línea
            Online_lbl.Text = $"Conectados ({numUsuarios}):\n";

            for (int i = 1; i <= numUsuarios; i++)
            {
                Online_lbl.Text += partes[i] + "\n";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (server.Connected)
            {
                Form_loby form_loby = new Form_loby();
                form_loby.SetUser(user);
                form_loby.SetServer(this.server);
                form_loby.Show();
                this.Close(); // Cierra el form_login
            }
        }
    }
}
