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
            if(server != null)
            {
                if (server.Connected)
                {
                    Form_login form_login = new Form_login();
                    form_login.SetServer(server); // Asegura que el socket se pasa
                    form_login.Show();
                    this.Close();
                }
            }
        }
    }
}
