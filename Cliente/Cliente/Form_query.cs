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
        //Definición de Forms, server (socket), thread y otras variables para la aplicación
        Form_loby form_loby;
        Form_partida form_Partida;
        Socket server;
        Thread atender;
        string user;
        private List<string> usuariosConectados = new List<string>();
        List<string> puntos = new List<string>();
        Partidas partidas = new Partidas();
        //Definición de delegate voids (Cross-Threading Protection)
        delegate void DelegadoParaEscribir6(string mensaje);
        delegate void DelegadoParaEscribir3(string mensaje);
        delegate void DelegadoParaEscribir7(string[] trozos);
        delegate void DelegadoParaEscribir10(string nombreUsuario);
        delegate void DelegadoParaEscribir12(string[] trozos);
        
        public class Partidas //Clase de partidas
        {
            public int numpartidas = 0;
            public Partida[] partida = new Partida[20];
        }
        public class Partida //Clase de partida
        {
            public int id;
            public Form_partida form;
        }
        public Form_partida GetPartida(int id, Partidas partidas) //Función para obtener el form de una partida con su id
        {
            bool found = false;
            int i = 0;
            Form_partida partida = null;
            while (found == false)
            {
                if (partidas.partida[i].id == id)
                {
                    partida = partidas.partida[i].form;
                    found = true;
                }
                i++;
            }
            return partida;
        }

        public void SetPartida(Form_partida partida, Partidas partidas, int id) //Función para definir y crear un form de una partida con su id
        {
            partidas.partida[partidas.numpartidas] = new Partida();
            partidas.partida[partidas.numpartidas].form = partida;
            partidas.partida[partidas.numpartidas].id = id;
            partidas.numpartidas++;
        }
        public Form_query()
        {
            InitializeComponent();

            ThreadStart ts = delegate { AtenderServidor(); }; //Definición del thread del cliente
            atender = new Thread(ts);
            atender.Start(); //Inicialización del thread del cliente
        }

        public void SetServer(Socket server) //Función para definir el socket
        {
            this.server = server;
        }

        public void SetUser(string username) //Función para definir el usuario
        {
            this.user = username;
            username_lbl.Text = "@" + user;
        }

        public List<string> ObtenerUsuariosConectados()
        {
            return new List<string>(usuariosConectados); // Retorna una copia de la lista
        }
        private void Query_btn_Click(object sender, EventArgs e) //Radiobutton de querys: selección y petición al servidor de un query de una partida
        {

            if (Query_txt.Text.Length != 0 && server != null)
            {
                if (server.Connected)
                {
                    try
                    {
                        if (radioButton1.Checked)
                        {
                            string mensaje = "3/" + Query_txt.Text; //Petición de fecha y hora
                            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                            server.Send(msg);

                        }
                        else if (radioButton2.Checked)
                        {
                            string mensaje = "4/" + Query_txt.Text; //Petición de duración
                            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                            server.Send(msg);
                        }
                        else
                        {
                            string mensaje = "5/" + Query_txt.Text; //Petición de ganador
                            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                            server.Send(msg);
                        }
                    }
                    catch (Exception ex) //Control de error
                    {
                        MessageBox.Show("Error al cerrar la conexión: " + ex.Message);
                    }
                }
            }
            else //Si no existe el id de la partida en la base de datos
            {
                MessageBox.Show("No se ha detectado ID de la partida en el campo de texto. Por favor introduzca la ID deseada.");
            }
        }

        private void back_btn_Click(object sender, EventArgs e) //Botón back: para volver al login (desconectar usuario)
        {
            if (server != null && server.Connected)
            {
                string mensaje = "8/" + this.user; //Petición de desconexión del usuario
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

        private void Service_btn_Click(object sender, EventArgs e) //Botoón de petición de servicios del servidor
        {
            string mensaje = "6/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void AtenderServidor() //Thread del Cliente
        {
            while (true)
            {
                if (server != null && server.Connected)
                {
                    byte[] msg2 = new byte[1024]; // Aumentamos el tamaño del buffer
                    server.Receive(msg2); //Respuesta Servidor
                    string rawMsg = Encoding.ASCII.GetString(msg2).Trim('\0');
                    string[] trozos = rawMsg.Split('/');
                    int codigo = 0;
                    string mensaje = null;
                    try
                    {
                        codigo = Convert.ToInt32(trozos[0]);
                        mensaje = trozos[1].Split('\0')[0];
                    }
                    catch //Control de error cuando un usuario se desconecta forzosamente
                    {
                        MessageBox.Show("Desconexión Forzada");
                    }
                    
                    

                    if (mensaje != null) //Bucle para atender a las respuestas del servidor
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
                                    DelegadoParaEscribir3 delegado3 = new DelegadoParaEscribir3(Cambiar3);
                                    QueryLbl.Invoke(delegado3, new object[] { "La partida se jugó: " + mensaje });
                                }
                                else
                                {
                                    DelegadoParaEscribir3 delegado3 = new DelegadoParaEscribir3(Cambiar3);
                                    QueryLbl.Invoke(delegado3, new object[] { "La partida no se ha encontrado" });
                                }
                                break;
                            case 4://consultar duracion
                                if (mensaje != "0")
                                {
                                    DelegadoParaEscribir3 delegado3 = new DelegadoParaEscribir3(Cambiar3);
                                    QueryLbl.Invoke(delegado3, new object[] { "La partida duró: " + mensaje + " minutos"});
                                }
                                else
                                {
                                    DelegadoParaEscribir3 delegado3 = new DelegadoParaEscribir3(Cambiar3);
                                    QueryLbl.Invoke(delegado3, new object[] { "La partida no se ha encontrado" });
                                }
                                break;
                            case 5://consultar ganador
                                if (mensaje != "0")
                                {
                                    DelegadoParaEscribir3 delegado3 = new DelegadoParaEscribir3(Cambiar3);
                                    QueryLbl.Invoke(delegado3, new object[] { "El ganador fue el jugador: " + mensaje });
                                }
                                else
                                {
                                    DelegadoParaEscribir3 delegado3 = new DelegadoParaEscribir3(Cambiar3);
                                    QueryLbl.Invoke(delegado3, new object[] { "La partida no se ha encontrado" });
                                }
                                break;
                            case 6://Contador de servicios
                                DelegadoParaEscribir6 delegado6 = new DelegadoParaEscribir6(Cambiar6);
                                ServiceLbl.Invoke(delegado6, new object[] { mensaje });
                                break;
                            case 7: // Consultar lista conectados                            
                                DelegadoParaEscribir7 delegado7 = new DelegadoParaEscribir7(Cambiar7);
                                ServiceLbl.Invoke(delegado7, new object[] { trozos });
                                break;
                            case 9: //Enviar respuesta a invitacion
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
                            case 10: //Recibe respuesta a invitacion
                                string nombreUsuario = trozos[1];
                                string res = trozos[2]; // "1" o "0"
                                string idPartida = trozos[3];

                                if (res == "1") //Aceptada
                                {
                                    DelegadoParaEscribir10 delegado10 = new DelegadoParaEscribir10(Actualizar_Aceptados);
                                    ServiceLbl.Invoke(delegado10, new object[] { nombreUsuario });
                                }
                                else if (res == "0") //Rechazada
                                {
                                    DelegadoParaEscribir10 delegado10 = new DelegadoParaEscribir10(Actualizar_Rechazados);
                                    ServiceLbl.Invoke(delegado10, new object[] { nombreUsuario });
                                }
                                break;
                            case 11: //Empieza la partida
                                int id = Convert.ToInt32(trozos[1]);
                                this.Invoke((MethodInvoker)delegate {
                                    form_Partida = new Form_partida();
                                    SetPartida(form_Partida, partidas, id);
                                    form_Partida.SetId(trozos[1]);
                                    form_Partida.SetUser(this.user);
                                    form_Partida.SetCreador(trozos[2]);
                                    form_Partida.SetServer(this.server);
                                    form_Partida.Show(); // Usa Show() pero desde el hilo UI
                                });
                                break;

                            case 12: //Envia Mensaje por el chat
                                id = Convert.ToInt32(trozos[1]);
                                Form_partida form = GetPartida(id, partidas);
                                if (form != null && !form.IsDisposed)
                                {
                                    form.Invoke((MethodInvoker)delegate {
                                        form.AddChat(trozos);
                                    });
                                }
                                break;
                            case 13: //Juego 1: El Forastero, disparo
                                id = Convert.ToInt32(trozos[1]);
                                puntos.Clear();
                                for (int i = 3; i < trozos.Length; i++)
                                {
                                    puntos.Add(trozos[i]);
                                }

                                form = GetPartida(id, partidas);
                                if (form != null && !form.IsDisposed)
                                {
                                    form.Invoke((MethodInvoker)delegate {
                                        form.AddWinner(trozos[2]);
                                        form.SetPuntos(puntos);
                                    });
                                }
                                break;
                            case 14: //Siguiente Juego
                                id = Convert.ToInt32(trozos[1]);
                                int juego = Convert.ToInt32(trozos[2]);
                                form = GetPartida(id, partidas);
                                if (juego == 3) //Fin de la partida (pantalla final)
                                {
                                    if (form != null && !form.IsDisposed)
                                    {
                                        form.Invoke((MethodInvoker)delegate {
                                            form.AddWinner(trozos[3]);
                                            form.SetJuego(juego);
                                        });
                                    }
                                }
                                else if(juego == 4) //Fin de la partida (cierre)
                                {
                                    if(form != null && !form.IsDisposed)
                                    {
                                        form.Invoke((MethodInvoker)delegate {
                                            form.Close();
                                        });
                                    }
                                }
                                else
                                {
                                    if (form != null && !form.IsDisposed)
                                    {
                                        form.Invoke((MethodInvoker)delegate {
                                            form.SetJuego(juego);
                                        });
                                    }
                                }
                                break;
                            case 15: //Juego 2: Carrera de las Galaxias, el primero en llegar
                                id = Convert.ToInt32(trozos[1]);
                                puntos.Clear();
                                for (int i = 3; i < trozos.Length; i++)
                                {
                                    puntos.Add(trozos[i]);
                                }

                                form = GetPartida(id, partidas);
                                if (form != null && !form.IsDisposed)
                                {
                                    form.Invoke((MethodInvoker)delegate {
                                        form.AddWinner(trozos[2]);
                                        form.SetPuntos(puntos);
                                    });
                                }
                                break;
                            case 16: //Juego 3: Ataque Submarino, el más preciso
                                id = Convert.ToInt32(trozos[1]);
                                puntos.Clear();
                                for (int i = 3; i < trozos.Length; i++)
                                {
                                    puntos.Add(trozos[i]);
                                }

                                form = GetPartida(id, partidas);
                                if (form != null && !form.IsDisposed)
                                {
                                    form.Invoke((MethodInvoker)delegate {
                                        form.AddWinner(trozos[2]);
                                        form.SetPuntos(puntos);
                                    });
                                }
                                break;
                            case 17: //Cierre forzado de la partida
                                id = Convert.ToInt32(trozos[1]);
                                form = GetPartida(id, partidas);
                                if (form != null && !form.IsDisposed)
                                {
                                    form.Invoke((MethodInvoker)delegate {
                                        form.SetMusica();
                                        form.Close();
                                    });
                                }
                                break;
                        }

                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e) //Botón para abrir el lobby para invitar
        {
            if (server.Connected)
            {
                this.form_loby = new Form_loby();
                form_loby.SetUser(this.user);
                form_loby.SetServer(this.server);
                form_loby.SetUsuariosConectados(this.usuariosConectados);
               
                form_loby.ShowDialog();
            }
        }

        public void SetUsuariosConectados(List<string> usuarios) //Definición de usuarios conectados en el form lobby
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

        //Funciones para escribir en labels (Cross-Threading Protection)
        public void Cambiar6(string mensaje)
        {
            ServiceLbl.Text = mensaje;
        }
        public void Cambiar3(string mensaje)
        {
            QueryLbl.Text = mensaje;
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

        //Funciones para actualizar los usuarios que han aceptado y rechazado una invitación
        public void Actualizar_Aceptados (string nombreUsuario)
        {
            form_loby.JugadoresAceptados(nombreUsuario);
        }

        public void Actualizar_Rechazados(string nombreUsuario)
        {
            form_loby.JugadoresRechazados(nombreUsuario);
        }
    }
}