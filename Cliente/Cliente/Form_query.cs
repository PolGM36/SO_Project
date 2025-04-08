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
    public partial class Form_query: Form
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

                        }
                        else if (radioButton2.Checked)
                        {
                            string mensaje = "4/" + Query_txt.Text;
                            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                            server.Send(msg);
                        }
                        else
                        {
                            string mensaje = "5/" + Query_txt.Text;
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
                string mensaje = "8/" + this.user;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                atender.Abort();

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
        }

        private void OnlineList_btn_Click(object sender, EventArgs e)
        {
        }

        private void AtenderServidor()
        {
            while (true)
            {
                if(server != null && server.Connected)
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
                        case 7://consultar lista conectados
                               // Procesar la lista de conectados
                            numUsuarios = int.Parse(trozos[1]); // Primer elemento es el número de usuarios
                            
                            // Mostrar en Label con saltos de línea
                            Online_lbl.Text = $"Conectados ({numUsuarios}):\n";

                            for (int i = 2; i <= numUsuarios + 1; i++)
                            {
                                Online_lbl.Text += trozos[i] + "\n";
                            }
                            break;
                        case 8://consultar lista conectados
                               // Procesar la lista de conectados
                            numUsuarios = int.Parse(trozos[1]); // Primer elemento es el número de usuarios

                            // Mostrar en Label con saltos de línea
                            Online_lbl.Text = $"Conectados ({numUsuarios}):\n";
                            if(numUsuarios > 0)
                            {
                                for (int i = 2; i <= numUsuarios + 1; i++)
                                {
                                    Online_lbl.Text += trozos[i] + "\n";
                                }
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
                Form_loby form_loby = new Form_loby();
                form_loby.SetUser(user);
                form_loby.SetServer(this.server);
                form_loby.Show();
                this.Close(); // Cierra el form_login
            }
        }

        private void Form_query_Load(object sender, EventArgs e)
        {
        }
    }
}
