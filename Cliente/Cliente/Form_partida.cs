using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente
{
    public partial class Form_partida : Form
    {
        Socket server;
        Thread atender;
        string user;
        private static readonly Random rnd = new Random();
        int contador_oeste = 20;
        int countdown = 0;
        delegate void DelegadoParaEscribir12(string[] trozos);
        public Form_partida()
        {
            InitializeComponent();

            ThreadStart ts = delegate { AtenderPartida(); };
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

        private void AtenderPartida()
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
                            case 12:
                                this.Invoke(new DelegadoParaEscribir12(AddChat), new object[] { trozos });

                                break;

                        }
                    }
                }
            }
        }
        public void AddChat(string[] trozos) 
        {
            Chat.Items.Add($"{trozos[1]}: {trozos[2]}");
        }

        private void Form_partida_Load(object sender, EventArgs e)
        {
            int numero = rnd.Next(1, 2);
            if(numero == 1)
            {
                this.BackgroundImage = Properties.Resources.Oeste;
                cont_oeste_lbl.Text = contador_oeste.ToString();
                cont_oeste_lbl.Visible = true;
               
                
                timer_oeste.Interval = 1000;  
                timer_oeste.Start();
            }
            else if(numero == 2)
            {
                this.BackgroundImage = Properties.Resources.Futuro;
            }
            else if(numero == 3)
            {
                this.BackgroundImage = Properties.Resources.Submarino;
            }
        }

        private void Enviar_btn_Click(object sender, EventArgs e)
        {
            string mensaje = "12/0/" + username_lbl.Text + "/" + ChatTextBox.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            ChatTextBox.Text = "";
            server.Send(msg);
        }

        private void timer_oeste_Tick(object sender, EventArgs e)
        {
            countdown++;

            if (contador_oeste > 1)
            {
                contador_oeste--;
                cont_oeste_lbl.Text = contador_oeste.ToString();
            }
            else if(countdown <= 25)
            {
                cont_oeste_lbl.Text = "Preparados...";
            }
            else if (countdown > 25 && countdown <= 29)
            {
                cont_oeste_lbl.Text = "Listos...";
            }
            else
            {
                cont_oeste_lbl.Text = "";
                timer_oeste.Stop();
                pictureBox_oeste.Visible = true;
                this.pictureBox_oeste.Image = Properties.Resources.Shoot;
            }

        }

        private void pictureBox_oeste_Click(object sender, EventArgs e)
        {
            string mensaje = "13/0/" + username_lbl.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }
    }
}
