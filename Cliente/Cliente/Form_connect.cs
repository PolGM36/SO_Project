using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente
{
    public partial class Form_connect : Form
    {
        public Form_connect()
        {
            InitializeComponent();
            int width = this.Width;
            int height = this.Height;

            start_btn.Location = new Point((width - start_btn.Width) / 2, (height - start_btn.Height) / 2);
            label1.Location = new Point((width - label1.Width) / 2, (height - label1.Height * 4) / 2);
        }
        Socket server;

        public void SetServer(Socket server)
        {
            this.server = server;
        }
        private void conectar_servidor()
        {
            IPAddress direc = IPAddress.Parse("10.4.119.5");
            IPEndPoint ipep = new IPEndPoint(direc, 50004);

            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);
                Form_login form_login = new Form_login();
                form_login.SetServer(this.server);
                form_login.Show();
                this.Hide(); // Cierra el form_connect
            }
            catch (SocketException ex)
            {

                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }
        }
        private void start_btn_Click(object sender, EventArgs e)
        {
            conectar_servidor();
        }
    }
}
