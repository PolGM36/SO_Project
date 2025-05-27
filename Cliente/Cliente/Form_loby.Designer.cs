namespace Cliente
{
    partial class Form_loby
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.username_lbl = new System.Windows.Forms.Label();
            this.back_btn = new System.Windows.Forms.Button();
            this.Invitar_btn = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.IniciarPartida_btn = new System.Windows.Forms.Button();
            this.jugadoresGrid = new System.Windows.Forms.DataGridView();
            this.Jugadores = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jugadores2Grid = new System.Windows.Forms.DataGridView();
            this.Jugadores2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.jugadoresGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jugadores2Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // username_lbl
            // 
            this.username_lbl.AutoSize = true;
            this.username_lbl.BackColor = System.Drawing.Color.Transparent;
            this.username_lbl.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username_lbl.ForeColor = System.Drawing.Color.White;
            this.username_lbl.Location = new System.Drawing.Point(20, 14);
            this.username_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.username_lbl.Name = "username_lbl";
            this.username_lbl.Size = new System.Drawing.Size(199, 52);
            this.username_lbl.TabIndex = 29;
            this.username_lbl.Text = "Username";
            // 
            // back_btn
            // 
            this.back_btn.BackColor = System.Drawing.Color.SpringGreen;
            this.back_btn.Location = new System.Drawing.Point(678, 846);
            this.back_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.back_btn.Name = "back_btn";
            this.back_btn.Size = new System.Drawing.Size(324, 71);
            this.back_btn.TabIndex = 30;
            this.back_btn.Text = "BACK";
            this.back_btn.UseVisualStyleBackColor = false;
            this.back_btn.Click += new System.EventHandler(this.back_btn_Click);
            // 
            // Invitar_btn
            // 
            this.Invitar_btn.BackColor = System.Drawing.Color.SpringGreen;
            this.Invitar_btn.Font = new System.Drawing.Font("Ravie", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Invitar_btn.Location = new System.Drawing.Point(205, 349);
            this.Invitar_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Invitar_btn.Name = "Invitar_btn";
            this.Invitar_btn.Size = new System.Drawing.Size(442, 126);
            this.Invitar_btn.TabIndex = 31;
            this.Invitar_btn.Text = "Invitar";
            this.Invitar_btn.UseVisualStyleBackColor = false;
            this.Invitar_btn.Click += new System.EventHandler(this.Invitar_btn_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BackColor = System.Drawing.SystemColors.Control;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(678, 349);
            this.checkedListBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.ScrollAlwaysVisible = true;
            this.checkedListBox1.Size = new System.Drawing.Size(415, 459);
            this.checkedListBox1.TabIndex = 32;
            // 
            // IniciarPartida_btn
            // 
            this.IniciarPartida_btn.BackColor = System.Drawing.Color.SpringGreen;
            this.IniciarPartida_btn.Font = new System.Drawing.Font("Ravie", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IniciarPartida_btn.Location = new System.Drawing.Point(29, 531);
            this.IniciarPartida_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.IniciarPartida_btn.Name = "IniciarPartida_btn";
            this.IniciarPartida_btn.Size = new System.Drawing.Size(618, 126);
            this.IniciarPartida_btn.TabIndex = 33;
            this.IniciarPartida_btn.Text = "Iniciar Partida";
            this.IniciarPartida_btn.UseVisualStyleBackColor = false;
            this.IniciarPartida_btn.Click += new System.EventHandler(this.IniciarPartida_btn_Click);
            // 
            // jugadoresGrid
            // 
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.SpringGreen;
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.jugadoresGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle19;
            this.jugadoresGrid.BackgroundColor = System.Drawing.Color.SpringGreen;
            this.jugadoresGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.SpringGreen;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Ravie", 8F);
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.jugadoresGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.jugadoresGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jugadoresGrid.ColumnHeadersVisible = false;
            this.jugadoresGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Jugadores});
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.SpringGreen;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Ravie", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.jugadoresGrid.DefaultCellStyle = dataGridViewCellStyle21;
            this.jugadoresGrid.GridColor = System.Drawing.Color.SpringGreen;
            this.jugadoresGrid.Location = new System.Drawing.Point(1102, 349);
            this.jugadoresGrid.Margin = new System.Windows.Forms.Padding(5);
            this.jugadoresGrid.Name = "jugadoresGrid";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Ravie", 11F);
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.jugadoresGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.jugadoresGrid.RowHeadersVisible = false;
            this.jugadoresGrid.RowHeadersWidth = 62;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.SpringGreen;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Ravie", 8F);
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.jugadoresGrid.RowsDefaultCellStyle = dataGridViewCellStyle23;
            this.jugadoresGrid.RowTemplate.Height = 28;
            this.jugadoresGrid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.jugadoresGrid.Size = new System.Drawing.Size(372, 459);
            this.jugadoresGrid.TabIndex = 34;
            // 
            // Jugadores
            // 
            this.Jugadores.HeaderText = "Jugadores";
            this.Jugadores.MinimumWidth = 8;
            this.Jugadores.Name = "Jugadores";
            this.Jugadores.Width = 258;
            // 
            // jugadores2Grid
            // 
            this.jugadores2Grid.BackgroundColor = System.Drawing.Color.LightCoral;
            this.jugadores2Grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.jugadores2Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jugadores2Grid.ColumnHeadersVisible = false;
            this.jugadores2Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Jugadores2});
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.LightCoral;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Ravie", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.jugadores2Grid.DefaultCellStyle = dataGridViewCellStyle24;
            this.jugadores2Grid.GridColor = System.Drawing.Color.LightCoral;
            this.jugadores2Grid.Location = new System.Drawing.Point(1482, 349);
            this.jugadores2Grid.Name = "jugadores2Grid";
            this.jugadores2Grid.RowHeadersVisible = false;
            this.jugadores2Grid.RowHeadersWidth = 102;
            this.jugadores2Grid.RowTemplate.Height = 40;
            this.jugadores2Grid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.jugadores2Grid.Size = new System.Drawing.Size(373, 459);
            this.jugadores2Grid.TabIndex = 35;
            // 
            // Jugadores2
            // 
            this.Jugadores2.HeaderText = "Jugadores";
            this.Jugadores2.MinimumWidth = 12;
            this.Jugadores2.Name = "Jugadores2";
            this.Jugadores2.Width = 250;
            // 
            // Form_loby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::Cliente.Properties.Resources.loby;
            this.ClientSize = new System.Drawing.Size(2404, 1259);
            this.Controls.Add(this.jugadores2Grid);
            this.Controls.Add(this.jugadoresGrid);
            this.Controls.Add(this.IniciarPartida_btn);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.Invitar_btn);
            this.Controls.Add(this.back_btn);
            this.Controls.Add(this.username_lbl);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "Form_loby";
            this.Text = "Lobby";
            this.Load += new System.EventHandler(this.Form_loby_Load);
            ((System.ComponentModel.ISupportInitialize)(this.jugadoresGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jugadores2Grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label username_lbl;
        private System.Windows.Forms.Button back_btn;
        private System.Windows.Forms.Button Invitar_btn;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button IniciarPartida_btn;
        private System.Windows.Forms.DataGridView jugadoresGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jugadores;
        private System.Windows.Forms.DataGridView jugadores2Grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jugadores2;
    }
}