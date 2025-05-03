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
            this.pictureBox_oeste = new System.Windows.Forms.PictureBox();
            this.cont_oeste_lbl = new System.Windows.Forms.Label();
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
            this.Chat.Location = new System.Drawing.Point(1016, 67);
            this.Chat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Chat.Name = "Chat";
            this.Chat.Size = new System.Drawing.Size(839, 531);
            this.Chat.TabIndex = 31;
            // 
            // ChatTextBox
            // 
            this.ChatTextBox.Location = new System.Drawing.Point(1016, 620);
            this.ChatTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChatTextBox.Name = "ChatTextBox";
            this.ChatTextBox.Size = new System.Drawing.Size(396, 38);
            this.ChatTextBox.TabIndex = 32;
            // 
            // Enviar_btn
            // 
            this.Enviar_btn.Location = new System.Drawing.Point(1032, 694);
            this.Enviar_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            // pictureBox_oeste
            // 
            this.pictureBox_oeste.ErrorImage = null;
            this.pictureBox_oeste.Image = global::Cliente.Properties.Resources.Shoot;
            this.pictureBox_oeste.InitialImage = null;
            this.pictureBox_oeste.Location = new System.Drawing.Point(246, 220);
            this.pictureBox_oeste.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox_oeste.Name = "pictureBox_oeste";
            this.pictureBox_oeste.Size = new System.Drawing.Size(586, 399);
            this.pictureBox_oeste.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_oeste.TabIndex = 34;
            this.pictureBox_oeste.TabStop = false;
            this.pictureBox_oeste.Visible = false;
            this.pictureBox_oeste.Click += new System.EventHandler(this.pictureBox_oeste_Click);
            // 
            // cont_oeste_lbl
            // 
            this.cont_oeste_lbl.AutoSize = true;
            this.cont_oeste_lbl.BackColor = System.Drawing.Color.Transparent;
            this.cont_oeste_lbl.Font = new System.Drawing.Font("Playbill", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cont_oeste_lbl.Location = new System.Drawing.Point(344, 694);
            this.cont_oeste_lbl.Name = "cont_oeste_lbl";
            this.cont_oeste_lbl.Size = new System.Drawing.Size(357, 121);
            this.cont_oeste_lbl.TabIndex = 35;
            this.cont_oeste_lbl.Text = "cont_oeste";
            this.cont_oeste_lbl.Visible = false;
            // 
            // Form_partida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1951, 926);
            this.Controls.Add(this.cont_oeste_lbl);
            this.Controls.Add(this.pictureBox_oeste);
            this.Controls.Add(this.Enviar_btn);
            this.Controls.Add(this.ChatTextBox);
            this.Controls.Add(this.Chat);
            this.Controls.Add(this.username_lbl);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form_partida";
            this.Text = "Form_partida";
            this.Load += new System.EventHandler(this.Form_partida_Load);
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
    }
}