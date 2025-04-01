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
    public partial class Form_loby: Form
    {
        Socket server;
        string user;
        public Form_loby()
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
        private void Form_loby_Load(object sender, EventArgs e)
        {

        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            if (server.Connected)
            {
                Form_query form_query = new Form_query();
                form_query.SetServer(server); // Asegura que el socket se pasa
                form_query.Show();
                this.Close();
            }
        }


    }
}
