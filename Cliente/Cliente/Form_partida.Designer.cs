namespace Cliente
{
    partial class Form_partida
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.username_lbl = new System.Windows.Forms.Label();
            this.Chat = new System.Windows.Forms.ListBox();
            this.ChatTextBox = new System.Windows.Forms.TextBox();
            this.Enviar_btn = new System.Windows.Forms.Button();
            this.timer_oeste = new System.Windows.Forms.Timer(this.components);
            this.cont_oeste_lbl = new System.Windows.Forms.Label();
            this.PartidaLbl = new System.Windows.Forms.Label();
            this.InstruccionesLbl = new System.Windows.Forms.Label();
            this.timer_respuesta = new System.Windows.Forms.Timer(this.components);
            this.puntosGrid = new System.Windows.Forms.DataGridView();
            this.Siguiente_btn = new System.Windows.Forms.Button();
            this.timer_futuro = new System.Windows.Forms.Timer(this.components);
            this.Fly_btn = new System.Windows.Forms.Button();
            this.timer_submarino = new System.Windows.Forms.Timer(this.components);
            this.panelSubmarino = new System.Windows.Forms.Panel();
            this.timer_torpedo = new System.Windows.Forms.Timer(this.components);
            this.pictureBox_torpedo = new System.Windows.Forms.PictureBox();
            this.pictureBox_nave = new System.Windows.Forms.PictureBox();
            this.pictureBox_meta = new System.Windows.Forms.PictureBox();
            this.pictureBox_oeste = new System.Windows.Forms.PictureBox();
            this.Cerrar_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.puntosGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_torpedo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_nave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_meta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_oeste)).BeginInit();
            this.SuspendLayout();
            // 
            // username_lbl
            // 
            this.username_lbl.AutoSize = true;
            this.username_lbl.BackColor = System.Drawing.Color.Transparent;
            this.username_lbl.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username_lbl.ForeColor = System.Drawing.Color.Black;
            this.username_lbl.Location = new System.Drawing.Point(32, 31);
            this.username_lbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.username_lbl.Name = "username_lbl";
            this.username_lbl.Size = new System.Drawing.Size(199, 52);
            this.username_lbl.TabIndex = 30;
            this.username_lbl.Text = "Username";
            // 
            // Chat
            // 
            this.Chat.FormattingEnabled = true;
            this.Chat.ItemHeight = 31;
            this.Chat.Location = new System.Drawing.Point(1017, 67);
            this.Chat.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Chat.Name = "Chat";
            this.Chat.Size = new System.Drawing.Size(840, 531);
            this.Chat.TabIndex = 31;
            // 
            // ChatTextBox
            // 
            this.ChatTextBox.Location = new System.Drawing.Point(1017, 620);
            this.ChatTextBox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.ChatTextBox.Name = "ChatTextBox";
            this.ChatTextBox.Size = new System.Drawing.Size(395, 38);
            this.ChatTextBox.TabIndex = 32;
            // 
            // Enviar_btn
            // 
            this.Enviar_btn.Location = new System.Drawing.Point(1031, 694);
            this.Enviar_btn.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Enviar_btn.Name = "Enviar_btn";
            this.Enviar_btn.Size = new System.Drawing.Size(229, 62);
            this.Enviar_btn.TabIndex = 33;
            this.Enviar_btn.Text = "Enviar";
            this.Enviar_btn.UseVisualStyleBackColor = true;
            this.Enviar_btn.Click += new System.EventHandler(this.Enviar_btn_Click);
            // 
            // timer_oeste
            // 
            this.timer_oeste.Tick += new System.EventHandler(this.timer_oeste_Tick);
            // 
            // cont_oeste_lbl
            // 
            this.cont_oeste_lbl.AutoSize = true;
            this.cont_oeste_lbl.BackColor = System.Drawing.Color.Transparent;
            this.cont_oeste_lbl.Font = new System.Drawing.Font("Playbill", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cont_oeste_lbl.Location = new System.Drawing.Point(281, 724);
            this.cont_oeste_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cont_oeste_lbl.Name = "cont_oeste_lbl";
            this.cont_oeste_lbl.Size = new System.Drawing.Size(357, 121);
            this.cont_oeste_lbl.TabIndex = 35;
            this.cont_oeste_lbl.Text = "cont_oeste";
            this.cont_oeste_lbl.Visible = false;
            // 
            // PartidaLbl
            // 
            this.PartidaLbl.AutoSize = true;
            this.PartidaLbl.Location = new System.Drawing.Point(1553, 710);
            this.PartidaLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PartidaLbl.Name = "PartidaLbl";
            this.PartidaLbl.Size = new System.Drawing.Size(164, 32);
            this.PartidaLbl.TabIndex = 36;
            this.PartidaLbl.Text = "NumPartida";
            // 
            // InstruccionesLbl
            // 
            this.InstruccionesLbl.AutoSize = true;
            this.InstruccionesLbl.BackColor = System.Drawing.Color.Transparent;
            this.InstruccionesLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstruccionesLbl.Location = new System.Drawing.Point(36, 112);
            this.InstruccionesLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.InstruccionesLbl.Name = "InstruccionesLbl";
            this.InstruccionesLbl.Size = new System.Drawing.Size(257, 32);
            this.InstruccionesLbl.TabIndex = 37;
            this.InstruccionesLbl.Text = "DescripcionJuego";
            // 
            // timer_respuesta
            // 
            this.timer_respuesta.Tick += new System.EventHandler(this.timer_respuesta_Tick);
            // 
            // puntosGrid
            // 
            this.puntosGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.puntosGrid.Location = new System.Drawing.Point(364, 133);
            this.puntosGrid.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.puntosGrid.Name = "puntosGrid";
            this.puntosGrid.RowHeadersWidth = 102;
            this.puntosGrid.RowTemplate.Height = 40;
            this.puntosGrid.Size = new System.Drawing.Size(370, 463);
            this.puntosGrid.TabIndex = 38;
            // 
            // Siguiente_btn
            // 
            this.Siguiente_btn.Location = new System.Drawing.Point(31, 739);
            this.Siguiente_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Siguiente_btn.Name = "Siguiente_btn";
            this.Siguiente_btn.Size = new System.Drawing.Size(252, 67);
            this.Siguiente_btn.TabIndex = 39;
            this.Siguiente_btn.Text = "Continuar";
            this.Siguiente_btn.UseVisualStyleBackColor = true;
            this.Siguiente_btn.Click += new System.EventHandler(this.Siguiente_btn_Click);
            // 
            // timer_futuro
            // 
            this.timer_futuro.Tick += new System.EventHandler(this.timer_futuro_Tick);
            // 
            // Fly_btn
            // 
            this.Fly_btn.BackColor = System.Drawing.Color.MediumPurple;
            this.Fly_btn.Font = new System.Drawing.Font("Agency FB", 21.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fly_btn.Location = new System.Drawing.Point(386, 604);
            this.Fly_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Fly_btn.Name = "Fly_btn";
            this.Fly_btn.Size = new System.Drawing.Size(242, 96);
            this.Fly_btn.TabIndex = 41;
            this.Fly_btn.Text = "GO!";
            this.Fly_btn.UseVisualStyleBackColor = false;
            this.Fly_btn.Click += new System.EventHandler(this.Fly_btn_Click);
            // 
            // timer_submarino
            // 
            this.timer_submarino.Tick += new System.EventHandler(this.timer_submarino_Tick);
            // 
            // panelSubmarino
            // 
            this.panelSubmarino.Location = new System.Drawing.Point(302, 473);
            this.panelSubmarino.Margin = new System.Windows.Forms.Padding(5);
            this.panelSubmarino.Name = "panelSubmarino";
            this.panelSubmarino.Size = new System.Drawing.Size(491, 65);
            this.panelSubmarino.TabIndex = 43;
            this.panelSubmarino.Visible = false;
            this.panelSubmarino.Paint += new System.Windows.Forms.PaintEventHandler(this.barra_Paint);
            // 
            // timer_torpedo
            // 
            this.timer_torpedo.Interval = 5;
            this.timer_torpedo.Tick += new System.EventHandler(this.timer_torpedo_Tick);
            // 
            // pictureBox_torpedo
            // 
            this.pictureBox_torpedo.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_torpedo.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox_torpedo.Image = global::Cliente.Properties.Resources.torpedo;
            this.pictureBox_torpedo.Location = new System.Drawing.Point(434, 536);
            this.pictureBox_torpedo.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox_torpedo.Name = "pictureBox_torpedo";
            this.pictureBox_torpedo.Size = new System.Drawing.Size(123, 95);
            this.pictureBox_torpedo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_torpedo.TabIndex = 44;
            this.pictureBox_torpedo.TabStop = false;
            this.pictureBox_torpedo.Visible = false;
            // 
            // pictureBox_nave
            // 
            this.pictureBox_nave.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_nave.Image = global::Cliente.Properties.Resources.xwing;
            this.pictureBox_nave.Location = new System.Drawing.Point(53, 358);
            this.pictureBox_nave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox_nave.Name = "pictureBox_nave";
            this.pictureBox_nave.Size = new System.Drawing.Size(190, 140);
            this.pictureBox_nave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_nave.TabIndex = 40;
            this.pictureBox_nave.TabStop = false;
            // 
            // pictureBox_meta
            // 
            this.pictureBox_meta.Image = global::Cliente.Properties.Resources.meta;
            this.pictureBox_meta.Location = new System.Drawing.Point(896, 321);
            this.pictureBox_meta.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox_meta.Name = "pictureBox_meta";
            this.pictureBox_meta.Size = new System.Drawing.Size(92, 177);
            this.pictureBox_meta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_meta.TabIndex = 42;
            this.pictureBox_meta.TabStop = false;
            // 
            // pictureBox_oeste
            // 
            this.pictureBox_oeste.ErrorImage = null;
            this.pictureBox_oeste.Image = global::Cliente.Properties.Resources.Shoot;
            this.pictureBox_oeste.InitialImage = null;
            this.pictureBox_oeste.Location = new System.Drawing.Point(251, 250);
            this.pictureBox_oeste.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.pictureBox_oeste.Name = "pictureBox_oeste";
            this.pictureBox_oeste.Size = new System.Drawing.Size(252, 175);
            this.pictureBox_oeste.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_oeste.TabIndex = 34;
            this.pictureBox_oeste.TabStop = false;
            this.pictureBox_oeste.Visible = false;
            this.pictureBox_oeste.Click += new System.EventHandler(this.pictureBox_oeste_Click);
            // 
            // Cerrar_btn
            // 
            this.Cerrar_btn.BackColor = System.Drawing.Color.IndianRed;
            this.Cerrar_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Cerrar_btn.Location = new System.Drawing.Point(1295, 694);
            this.Cerrar_btn.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Cerrar_btn.Name = "Cerrar_btn";
            this.Cerrar_btn.Size = new System.Drawing.Size(229, 62);
            this.Cerrar_btn.TabIndex = 45;
            this.Cerrar_btn.Text = "Cerrar";
            this.Cerrar_btn.UseVisualStyleBackColor = false;
            this.Cerrar_btn.Visible = false;
            this.Cerrar_btn.Click += new System.EventHandler(this.Cerrar_btn_Click);
            // 
            // Form_partida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1950, 925);
            this.Controls.Add(this.Cerrar_btn);
            this.Controls.Add(this.pictureBox_torpedo);
            this.Controls.Add(this.panelSubmarino);
            this.Controls.Add(this.pictureBox_nave);
            this.Controls.Add(this.pictureBox_meta);
            this.Controls.Add(this.Fly_btn);
            this.Controls.Add(this.Siguiente_btn);
            this.Controls.Add(this.puntosGrid);
            this.Controls.Add(this.InstruccionesLbl);
            this.Controls.Add(this.PartidaLbl);
            this.Controls.Add(this.cont_oeste_lbl);
            this.Controls.Add(this.pictureBox_oeste);
            this.Controls.Add(this.Enviar_btn);
            this.Controls.Add(this.ChatTextBox);
            this.Controls.Add(this.Chat);
            this.Controls.Add(this.username_lbl);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "Form_partida";
            this.Text = "Partida";
            this.Load += new System.EventHandler(this.Form_partida_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.torpedo_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.puntosGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_torpedo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_nave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_meta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_oeste)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label username_lbl;
        private System.Windows.Forms.ListBox Chat;
        private System.Windows.Forms.TextBox ChatTextBox;
        private System.Windows.Forms.Button Enviar_btn;
        private System.Windows.Forms.PictureBox pictureBox_oeste;
        private System.Windows.Forms.Timer timer_oeste;
        private System.Windows.Forms.Label cont_oeste_lbl;
        private System.Windows.Forms.Label PartidaLbl;
        private System.Windows.Forms.Label InstruccionesLbl;
        private System.Windows.Forms.Timer timer_respuesta;
        private System.Windows.Forms.DataGridView puntosGrid;
        private System.Windows.Forms.Button Siguiente_btn;
        private System.Windows.Forms.PictureBox pictureBox_nave;
        private System.Windows.Forms.Timer timer_futuro;
        private System.Windows.Forms.Button Fly_btn;
        private System.Windows.Forms.PictureBox pictureBox_meta;
        private System.Windows.Forms.Timer timer_submarino;
        private System.Windows.Forms.Panel panelSubmarino;
        private System.Windows.Forms.PictureBox pictureBox_torpedo;
        private System.Windows.Forms.Timer timer_torpedo;
        private System.Windows.Forms.Button Cerrar_btn;
    }
}