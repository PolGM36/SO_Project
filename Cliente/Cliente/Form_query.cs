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
        private List<string> usuariosConectados = new List<string>();

        delegate void DelegadoParaEscribir6(string mensaje);
        delegate void DelegadoParaEscribir7(string[] trozos);

        public Form_query()
        {
            InitializeComponent();

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

                Form_connect form_connect = new Form_connect();
                form_connect.SetServer(this.server);
                form_connect.Show();

                mensaje = "0/";
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
            string mensaje = "6/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void AtenderServidor()
        {
            while (true)
            {
                if (server != null && server.Connected)
                {
                    byte[] msg2 = new byte[1024]; // Aumentamos el tamaño del buffer
                    server.Receive(msg2);
                    string rawMsg = Encoding.ASCII.GetString(msg2).Trim('\0');
                    string[] trozos = rawMsg.Split('/');
                    int codigo = Convert.ToInt32(trozos[0]);
                    string mensaje = trozos[1].Split('\0')[0];

                    if (mensaje != null)
                    {
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
                                   //ServiceLbl.Text = mensaje;
                                DelegadoParaEscribir6 delegado6 = new DelegadoParaEscribir6(Cambiar6);
                                ServiceLbl.Invoke(delegado6, new object[] { mensaje });
                                break;
                            case 7: // Consultar lista conectados                            
                                DelegadoParaEscribir7 delegado7 = new DelegadoParaEscribir7(Cambiar7);
                                ServiceLbl.Invoke(delegado7, new object[] { trozos });
                                break;
                            case 9:
                                if (mensaje != null)
                                {
                                    Form_Invitacion invitacion = new Form_Invitacion(trozos[2]);
                                    var resultado = invitacion.ShowDialog();

                                    if (resultado == DialogResult.OK && invitacion.Aceptado)
                                    {
                                        string respuesta = "10/" + trozos[1] + "/" + user + "/1/" + trozos[3];
                                        byte[] msgAceptar = Encoding.ASCII.GetBytes(respuesta);
                                        server.Send(msgAceptar);
                                    }
                                    else
                                    {
                                        string respuesta = "10/" + trozos[1] + "/" + user + "/0/" + trozos[3];
                                        byte[] msgRechazar = Encoding.ASCII.GetBytes(respuesta);
                                        server.Send(msgRechazar);
                                    }
                                }
                                break;
                            case 10:
                                string nombreUsuario = trozos[1];
                                string res = trozos[2]; // "1" o "0"
                                string idPartida = trozos[3];

                                if (res == "1")
                                {
                                    MessageBox.Show($"{nombreUsuario} ha aceptado tu invitación.");
                                }
                                else if (res == "0")
                                {
                                    MessageBox.Show($"{nombreUsuario} ha rechazado tu invitación.");
                                }
                                break;
                            case 11:
                                Form_partida form_Partida = new Form_partida();
                                form_Partida.SetUser(this.user);
                                form_Partida.SetServer(this.server);
                                form_Partida.ShowDialog();
                                
                                break;
                        }

                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (server.Connected)
            {
                MessageBox.Show("Usuarios conectados: " + string.Join(", ", usuariosConectados));

                Form_loby form_loby = new Form_loby();
                form_loby.SetUser(this.user);
                form_loby.SetServer(this.server);
                form_loby.SetUsuariosConectados(this.usuariosConectados);
               
                form_loby.ShowDialog();
            }
        }

        public void SetUsuariosConectados(List<string> usuarios)
        {
            int numUsuarios = usuariosConectados.Count;

            Online_lbl.Text = $"Conectados ({numUsuarios}):\n";

            for (int i = 2; i <= numUsuarios + 1; i++)
            {
                string nombre = usuariosConectados[i];
                usuariosConectados.Add(nombre);
                Online_lbl.Text += nombre + "\n";
            }
            MessageBox.Show("Usuarios conectados: " + string.Join(", ", usuariosConectados));
        }

        public void Cambiar6(string mensaje)
        {
            ServiceLbl.Text = mensaje;
        }

        public void Cambiar7(string[] trozos)
        {
            usuariosConectados.Clear();

            int numUsuarios = int.Parse(trozos[1]);
            Online_lbl.Text = $"Conectados ({numUsuarios}):\n";

            for (int i = 2; i <= numUsuarios + 1; i++)
            {
                string nombre = trozos[i];
                usuariosConectados.Add(nombre);
                Online_lbl.Text += nombre + "\n";
            }
        }
    }
}