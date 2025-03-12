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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        Socket server;
        private void conectar_servidor()
        {
            IPAddress direc = IPAddress.Parse("192.168.56.101");
            IPEndPoint ipep = new IPEndPoint(direc, 9080);

            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);
                Form1 form1 = new Form1();
                form1.SetServer(server);
                form1.Show();
                this.Hide(); // Cierra el Form2
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
