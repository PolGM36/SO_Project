using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Cliente
{
    public partial class Form_loby : Form
    {
        //Definición de socket
        Socket server;
        string user;
        private List<string> usuariosConectados = new List<string>();
      
        public Form_loby()
        {
            InitializeComponent();
        }

        public void SetServer(Socket server) //Definición de socket
        {
            this.server = server;
        }

        public void SetUser(string username) //Definición de usuario
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

        private void back_btn_Click(object sender, EventArgs e) //Botón para cerrar el form_lobby
        {
            if (server.Connected)
            {
                this.Close();
            }
        }
        private void EnviarInvitacion(string mensaje) //Función para enviar una invitación a otros usuarios
        {
            if (server != null && server.Connected)
            {
                // Crear el mensaje para enviar al servidor, con los usuarios separados por "/"
                string mensajeInvitacion = "9/" + mensaje; //Petición de invitación
                byte[] msg = Encoding.ASCII.GetBytes(mensajeInvitacion);

                try
                {
                    server.Send(msg); // Enviar el mensaje al servidor
                }
                catch (Exception ex) //Control de error
                {
                    MessageBox.Show("Error al enviar la invitación: " + ex.Message);
                }
            }
        }

        private void Invitar_btn_Click(object sender, EventArgs e) //Botón para invitar
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

            }
            else
            {
                MessageBox.Show("Debe seleccionar al menos un usuario para invitar.");
            }
        }

        private void IniciarPartida_btn_Click(object sender, EventArgs e) //Botón para iniciar una partida
        {
            string mensaje = "11/0"; //Petición de inicio de partida
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            jugadoresGrid.Rows.Clear();
            jugadores2Grid.Rows.Clear();   
            this.Close();
        }

        //Actualización de los grids con la lista de usuarios que han aceptado o rechazado una invitación
        public void JugadoresAceptados(string jugador)
        {
            jugadoresGrid.Rows.Add(jugador);
        }

        public void JugadoresRechazados(string jugador)
        {
            jugadores2Grid.Rows.Add(jugador);
        }
    }
}
