using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Cliente
{
    public partial class Form_loby : Form
    {
        Socket server;
        string user;
        private List<string> usuariosConectados = new List<string>();
      
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


        // Método que recibe la lista de usuarios conectados desde Form_query
        public void SetUsuariosConectados(List<string> usuarios)
        {
            this.usuariosConectados = usuarios;
            string usuario_principal = this.user.ToString();

            // Ahora actualizamos el CheckedListBox
            checkedListBox1.Items.Clear();
            foreach (string usuario in usuarios)
            {
                if(usuario.ToString() != usuario_principal)
                {
                    checkedListBox1.Items.Add(usuario);
                }
            }
        }
  
        private void Form_loby_Load(object sender, EventArgs e)
        {
      
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            if (server.Connected)
            {
                //Form_query form_query = new Form_query();
                //form_query.SetUser(this.user);
                //form_query.SetServer(this.server);
                //form_query.SetUsuariosConectados(this.usuariosConectados);
                //form_query.Show();

                this.Close();
            }
        }
        private void EnviarInvitacion(string mensaje)
        {
            if (server != null && server.Connected)
            {
                // Crear el mensaje para enviar al servidor, con los usuarios separados por "/"
                string mensajeInvitacion = "9/" + mensaje;
                byte[] msg = Encoding.ASCII.GetBytes(mensajeInvitacion);

                try
                {
                    server.Send(msg); // Enviar el mensaje al servidor
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al enviar la invitación: " + ex.Message);
                }
            }
        }

        private void Invitar_btn_Click(object sender, EventArgs e)
        {
            // Crear una lista para almacenar los usuarios seleccionados
            List<string> usuariosSeleccionados = new List<string>();

            // Recorremos los elementos seleccionados en el CheckedListBox
            foreach (var item in checkedListBox1.CheckedItems)
            {
                if(item.ToString() != "0" && item.ToString() != null)
                {
                    usuariosSeleccionados.Add(item.ToString());
                }
                
            }

            // Comprobar si se seleccionaron usuarios
            if (usuariosSeleccionados.Count > 0)
            {
                // Obtener el número de usuarios seleccionados
                int numUsuarios = usuariosSeleccionados.Count;

                // Crear el mensaje de invitación con el formato requerido
                // Incluimos el nombre del usuario que invita (this.user)
                string mensajeInvitacion = numUsuarios.ToString() + "/" + this.user + "/" + string.Join("/", usuariosSeleccionados);

                // Enviar la invitación al servidor
                EnviarInvitacion(mensajeInvitacion);

                MessageBox.Show("Invitación enviada a los usuarios seleccionados.");
            }
            else
            {
                MessageBox.Show("Debe seleccionar al menos un usuario para invitar.");
            }
        }

        private void IniciarPartida_btn_Click(object sender, EventArgs e)
        {
            string mensaje = "11/0";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }
    }
}
