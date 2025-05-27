using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Cliente
{
    public partial class Form_partida : Form
    {
        //Definición de socket y múltiples variables para la interfaz del juego y su correcto funcionamiento
        Socket server;
        string partida;
        string user;
        string creador;
        int priority = 0;
        int contador_oeste = 20;
        int countdown = 0;
        int cont_respuesta = 0;
        int cont_nave = 0;
        Stopwatch shoot = new Stopwatch(); //Stopwatch: Variable de cronometro para medir tiempo de disparo y de partida
        Stopwatch tiempo = new Stopwatch();
        int cont_juego = 0;
        int direccion = 5;
        SoundPlayer player;
        bool EspacioEnabled = false;
        string ganador;
        string fechaHora; 

        public Form_partida()
        {
            InitializeComponent();
            //Definición del GridView de Puntos de los jugadores
            puntosGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            puntosGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            puntosGrid.AllowUserToAddRows = false;
            puntosGrid.AllowUserToResizeColumns = false;
            puntosGrid.AllowUserToResizeRows = false;
            puntosGrid.RowHeadersVisible = false;

            puntosGrid.AutoSize = true;
            //Y otros aspectos de formato
            puntosGrid.BorderStyle = BorderStyle.None;
            puntosGrid.GridColor = Color.LightGray;
            puntosGrid.BackgroundColor = Color.SpringGreen;
            puntosGrid.DefaultCellStyle.BackColor = Color.SpringGreen;
            puntosGrid.Font = new Font("Playbill", 20);
            puntosGrid.Columns.Add("Jugador", "Jugador");
            puntosGrid.Columns.Add("Puntos", "Puntos");
        }

        public void SetId(string partida) //Función para marcar el id de la partida
        {
            this.partida = partida;
            PartidaLbl.Text = "Partida: " + partida;
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

        public void SetCreador(string nombre) //Función para definir el creador de la partida, este gestiona cuando se pasa de juego o si se cierra esta
        {
            this.creador = nombre;
            if (creador == user)
            {
                username_lbl.ForeColor = Color.Red;
                this.priority = 1;
            }
        }
        public void AddWinner(string nombre) //Función para añadir el ganador de cada juego así como de la partida en general
        {
            ganador = nombre;
            Fly_btn.Enabled = false;
            cont_oeste_lbl.Font = new Font("Ravie", 16);
            cont_oeste_lbl.Text = "Ganador: " + nombre + "!";
            if (creador == user)
            {
                Siguiente_btn.Visible = true;
            }
        }

        public void SetPuntos(List<string> puntos) //Función para poner puntos en el grid de puntos tras cada juego
        {
            puntosGrid.Rows.Clear();
            this.puntosGrid.Visible = true;
            foreach (string punto in puntos)
            {
                string[] trozos = punto.Split(':');
                if (trozos.Length == 2)
                {
                    string u = trozos[0];
                    string p = trozos[1];
                    puntosGrid.Rows.Add(u, p);
                }
            }
        }

        public void SetJuego(int juego) //Función para establecer la interfaz en cada juego (cuando se pasa)
        {
            contador_oeste = 20;
            if (juego == 1) //Juego 2: Carrera de las Galaxias
            {
                this.ActiveControl = null;
                cont_oeste_lbl.ForeColor = Color.White;
                cont_oeste_lbl.Font = new Font("Agency FB", 36);
                cont_oeste_lbl.Text = "20";
                this.BackgroundImage = Properties.Resources.Futuro;
                puntosGrid.Visible = false;
                InstruccionesLbl.Text = "CARRERA DE LAS GALAXIAS:\nCuando termine la cuenta atrás aparecerá tu nave,\napreta constantemente el botón GO! para avanzar,\nquien llegue antes a la meta será el más rápido de la galaxia";
                timer_futuro.Start();
                player = new SoundPlayer("Coral.wav");
                player.Play();
            }
            if (juego == 2) //Juego 3: Ataque Submarino
            {
                this.ActiveControl = null;
                player = new SoundPlayer("Coral.wav");
                Fly_btn.Visible = false;
                pictureBox_meta.Visible = false;
                pictureBox_nave.Visible = false;
                this.BackgroundImage = Properties.Resources.sonar;
                cont_oeste_lbl.Font = new Font("OCR A Extended", 36);
                cont_oeste_lbl.Text = "20";
                puntosGrid.Visible = false;
                InstruccionesLbl.ForeColor = Color.White;
                InstruccionesLbl.Text = "ATAQUE SUBMARINO:\nCuando termine la cuenta atrás aparecerá un torpedo\nel que atine con más precisión el centro de disparo,\npara hundir al enemigo, con la barra de espacio\nserá el más rápido de los mares";
                if(creador != user)
                {
                    username_lbl.ForeColor = Color.White;
                }
                timer_submarino.Start();
                player.Play();
            }
            if(juego == 3) //Pantalla final de partida con el ganador de esta
            {
                this.ActiveControl = null;
                player.Stop();
                player = new SoundPlayer("Winner.wav");
                player.Play();
                timer_submarino.Stop();
                timer_torpedo.Stop();
                InstruccionesLbl.Text = "";
                cont_oeste_lbl.ForeColor = Color.Black;
                panelSubmarino.Visible = false;
                pictureBox_torpedo.Visible = false;
                this.BackgroundImage = null;
                this.BackColor = Color.SpringGreen;
                if(creador != user)
                {
                    username_lbl.ForeColor= Color.Black;
                }
            }
        }

        public void AddChat(string[] trozos) //Función para añadir los mensajes al chat
        {
            Chat.Items.Add($"{trozos[2]}: {trozos[3]}");
        }

        public void SetMusica() //Función para añadir música
        {
            player.Stop();
        }
        private void Form_partida_Load(object sender, EventArgs e)
        {
            //Definición del formato del form al cargar este y otras variables para el correcto funcionamiento de el juego
            fechaHora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            tiempo.Start();
            this.KeyPreview = true;
            this.ActiveControl = null;
            pictureBox_nave.Visible = false;

            pictureBox_torpedo.Visible = false;
            panelSubmarino.Visible = false;

            Image rotated = (Image)Properties.Resources.torpedo.Clone();
            rotated.RotateFlip(RotateFlipType.Rotate270FlipNone);
            pictureBox_torpedo.Image = rotated;
            
            //Definición del formato del Juego 1: El Forastero
            pictureBox_meta.Visible = false;
            this.puntosGrid.Visible = false;
            Siguiente_btn.Visible = false;
            Fly_btn.Visible = false;
            this.BackgroundImage = Properties.Resources.Oeste;
            cont_oeste_lbl.Text = contador_oeste.ToString();
            cont_oeste_lbl.Visible = true;
            InstruccionesLbl.Text = "EL FORASTERO:\nCuando termine la cuenta atrás aparecerá\nuna imagen donde clickar,\nquien dispare primero será el más rápido del oeste";
            timer_oeste.Interval = 1000;
            timer_oeste.Start();
            timer_respuesta.Interval = 1000;
            timer_futuro.Interval = 1000;
            timer_submarino.Interval = 1000;
            player = new SoundPlayer("Coral.wav");
            player.Play();
            if(creador == user)
            {
                Cerrar_btn.Visible = true;
            }
        }

        private void torpedo_KeyDown(object sender, KeyEventArgs e) //Evento de Click del espacio para el juego 3
        {
            if (EspacioEnabled)
            {
                if (e.KeyCode == Keys.Space && timer_torpedo.Enabled)
                {
                    player.Stop();
                    int posTX = pictureBox_torpedo.Left + pictureBox_torpedo.Width / 2;

                    // Posición relativa dentro del panel
                    int relX = posTX - panelSubmarino.Left;

                    int width = panelSubmarino.Width;

                    // Tramos relativos
                    int rojoW = (int)(width * 0.05);        // 5%
                    int amarilloW = (int)(width * 0.25);    // 25% (12.5% cada lado)
                    int blancoW = width - rojoW - amarilloW;

                    int center = width / 2;
                    int puntos;

                    // Zona izquierda
                    int inicioBlanco = 0;
                    int inicioAmarilloIzq = blancoW / 2;
                    int inicioRojo = inicioAmarilloIzq + amarilloW / 2;
                    int inicioAmarilloDer = inicioRojo + rojoW;
                    int finAmarilloDer = inicioAmarilloDer + amarilloW / 2;

                    // Cálculo de puntos
                    if ((relX > inicioAmarilloIzq && relX <= inicioRojo) ||
                        (relX >= inicioAmarilloDer && relX < finAmarilloDer))
                    {
                        puntos = 2; // amarillo
                    }
                    else if (relX > inicioRojo && relX < inicioAmarilloDer && relX != center)
                    {
                        puntos = 1; // rojo (no centro)
                    }
                    else if (relX == center)
                    {
                        puntos = 0; // centro exacto
                    }
                    else
                    {
                        puntos = 3; // blanco
                    }

                    string mensaje = "16/" + this.partida + "/" + puntos + "/" + this.user;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    pictureBox_torpedo.Visible = true;
                    timer_submarino.Stop();
                    timer_torpedo.Stop();
                    panelSubmarino.Visible = true;
                    EspacioEnabled = false;
                }
            }
        }

        private void Enviar_btn_Click(object sender, EventArgs e) //Botón de enviar mensaje por el chat
        {
            if (ChatTextBox.Text != null && ChatTextBox.Text.Length > 0) //Mientras no este vacio
            {
                string mensaje = "12/" + this.partida + "/" + username_lbl.Text + "/" + ChatTextBox.Text; //Petición al servidor de chat
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                ChatTextBox.Text = "";
                server.Send(msg);
            }
        }

        private void timer_oeste_Tick(object sender, EventArgs e) //Timer Juego 1
        {
            countdown++;
            
            if (contador_oeste > 1)
            {
                contador_oeste--;
                cont_oeste_lbl.Text = contador_oeste.ToString();
            }
            else if (countdown <= 25)
            {
                if (countdown == 20)
                {
                    player.Stop();
                    player = new SoundPlayer("Duelo.wav");
                    player.Play();
                }
                InstruccionesLbl.Text = "";
                cont_oeste_lbl.Text = "Preparados...";
            }
            else if (countdown > 25 && countdown <= 29)
            {
                cont_oeste_lbl.Text = "Listos...";
            }
            else
            {
                player.Stop();
                Random rnd = new Random();

                // Define los límites del área donde puede aparecer el PictureBox
                int minX = 0;
                int maxX = 250;
                int minY = 0;
                int maxY = 250;

                // Calcula coordenadas aleatorias dentro de ese rango
                int randomX = rnd.Next(minX, maxX);
                int randomY = rnd.Next(minY, maxY);

                cont_oeste_lbl.Text = "";
                timer_oeste.Stop();
                pictureBox_oeste.Location = new Point(randomX, randomY);
                pictureBox_oeste.Visible = true;
                shoot.Start();
                this.pictureBox_oeste.Image = Properties.Resources.Shoot;
                timer_respuesta.Start();
            }

        }

        private void pictureBox_oeste_Click(object sender, EventArgs e) //Evento de Click del PictureBox del juego 1 (disparo)
        {
            player = new SoundPlayer("shot.wav");
            player.Play();
            pictureBox_oeste.Visible = false;
            shoot.Stop();
            timer_respuesta.Stop();
            cont_respuesta = 0;
            double t = shoot.Elapsed.TotalMilliseconds;
            string mensaje = "13/" + this.partida + "/" + t + "/" + this.user; //Petición de juego 1 al servidor
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void timer_respuesta_Tick(object sender, EventArgs e) //Timer de respuesta por si no contesta algun jugador
        {
            cont_respuesta++;
            if (cont_respuesta > 7)
            {
                pictureBox_oeste.Visible = false;
                shoot.Stop();
                double t = shoot.Elapsed.TotalMilliseconds;
                string mensaje = "13/" + this.partida + "/" + t + "/" + this.user;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                cont_respuesta = 0;
                timer_respuesta.Stop();
            }
        }

        private void Siguiente_btn_Click(object sender, EventArgs e) //Botón de paso al siguiente juego
        {
            cont_juego++;
            Siguiente_btn.Visible = false;
            if (cont_juego == 4) //Fin de la partida
            {
                tiempo.Stop();
                double tiempo_partida = tiempo.Elapsed.TotalMinutes;
                string mensaje = "14/" + this.partida + "/" + cont_juego + "/" + fechaHora + "/" + ganador + "/" + tiempo_partida; //Petición al servidor para pasar de juego y registrar partida
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else
            {
                string mensaje = "14/" + this.partida + "/" + cont_juego; //Petición al servidor para pasar de juego
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
        }

        private void timer_futuro_Tick(object sender, EventArgs e) //Timer juego 2
        { 
            contador_oeste--;
            if (contador_oeste == 0)
            {
                player.Stop();
                player = new SoundPlayer("Space.wav");
                player.Play();
                cont_oeste_lbl.Text = "";
                InstruccionesLbl.Text = "";
                pictureBox_nave.Visible = true;
                pictureBox_meta.Visible = true;
                Fly_btn.Enabled = true;
                Fly_btn.Visible = true;
                timer_futuro.Stop();
            }
            else
            {
                cont_oeste_lbl.Text = contador_oeste.ToString();
            }

        }

        private void Fly_btn_Click(object sender, EventArgs e) //Botón GO! con el que avanza la nave
        {
            Point posicionActual = pictureBox_nave.Location;

            int nuevoX = posicionActual.X + 10;
            int nuevoY = posicionActual.Y;

            pictureBox_nave.Location = new Point(nuevoX, nuevoY);
            cont_nave++;
            if (cont_nave == 27) //Al llegar a la meta 
            {
                player.Stop();
                Fly_btn.Enabled = false;
                string mensaje = "15/" + this.partida + "/" + this.user; //Petición de juego 2, el primero en llegar a la meta
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
        }

        private void timer_submarino_Tick(object sender, EventArgs e) //Timer juego 3
        {
            contador_oeste--;
            if (contador_oeste == 0)
            {
                EspacioEnabled = true;
                player = new SoundPlayer("sonar.wav");
                player.Play();
                cont_oeste_lbl.Text = "";
                InstruccionesLbl.Text = "";
                timer_submarino.Stop();

                pictureBox_torpedo.Visible = true;
                panelSubmarino.Visible = true;
                timer_torpedo.Start();
            }
            else
            {
                cont_oeste_lbl.Text = contador_oeste.ToString();
            }
        }

        private void barra_Paint(object sender, PaintEventArgs e) //Definición de la barra para el juego 3
        {
            Graphics g = e.Graphics;
            int width = panelSubmarino.Width;
            int height = panelSubmarino.Height;

            // Tramos
            int center = width / 2;
            int rojoW = (int)(width * 0.05);        // 5%
            int amarilloW = (int)(width * 0.25);    // 25% (12.5% cada lado)
            int blancoW = width - rojoW - amarilloW; // Resto

            // Blanco (izquierda)
            g.FillRectangle(Brushes.DarkBlue, 0, 0, blancoW/2, height);

            // Amarillo (izquierda)
            g.FillRectangle(Brushes.Yellow, blancoW/2, 0, amarilloW/2, height);

            // Rojo (centro)
            g.FillRectangle(Brushes.Red, blancoW/2 + amarilloW/2, 0, rojoW, height);

            // Amarillo (derecha)
            g.FillRectangle(Brushes.Yellow, blancoW / 2 + amarilloW / 2 + rojoW, 0, amarilloW/2, height);

            // Blanco (derecha)
            g.FillRectangle(Brushes.DarkBlue, blancoW / 2 + amarilloW / 2 + rojoW + amarilloW/2, 0, blancoW/2, height);
        }

        private void timer_torpedo_Tick(object sender, EventArgs e) //Timer torpedo para el movimiento de este en el juego 3
        {
            
            Point pos = pictureBox_torpedo.Location;
            pos.X += direccion;

            int minX = panelSubmarino.Location.X;
            int maxX = panelSubmarino.Location.X + panelSubmarino.Width - pictureBox_torpedo.Width;

            
            if (pos.X <= minX || pos.X >= maxX)
            {
                direccion *= -1; // Reverse direction
            }
            

            pictureBox_torpedo.Location = new Point(pos.X, pos.Y);


        }

        private void Cerrar_btn_Click(object sender, EventArgs e) //Botón para cerrar el juego forzosamente
        {
            player.Stop();
            string mensaje = "17/" + this.partida;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }
    }
}
