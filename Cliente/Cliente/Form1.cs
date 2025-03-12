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


namespace Cliente
{
    public partial class Form1 : Form
    {

        Socket server;
        public Form1()
        {
            InitializeComponent();
        }

        public void SetServer(Socket server)
        {
            this.server = server;
        }

        private void Register_btn_Click(object sender, EventArgs e)
        {

            string mensaje = "2/" + Register_txt.Text + "/" + register_passw_txt.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
            if(mensaje == "Si")
            {
                MessageBox.Show("Registro Completado");
            }
            else
            {
                MessageBox.Show("Error al registrar");
            }
            
        }

        private void Loggin_btn_Click(object sender, EventArgs e)
        { 

            string mensaje = "1/" + Loggin_txt.Text + "/" + loggin_password_txt.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
            
            if(mensaje!="0")
            {
                MessageBox.Show("Bienvenido de vuelta jugador " + mensaje);
            }
            else
            {
                MessageBox.Show("Username desconocido");
            }
            

        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            string mensaje = "0/";

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            server.Shutdown(SocketShutdown.Both);
            server.Close();

            this.Close();

            Form2 form2 = new Form2();
            form2.Show();
        }

        private void Query_btn_Click(object sender, EventArgs e)
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
    }

}

