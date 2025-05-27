namespace Cliente
{
    partial class Form_Invitacion
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
            this.Mensaje_lbl = new System.Windows.Forms.Label();
            this.Aceptar_btn = new System.Windows.Forms.Button();
            this.Rechazar_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Mensaje_lbl
            // 
            this.Mensaje_lbl.AutoSize = true;
            this.Mensaje_lbl.Font = new System.Drawing.Font("Ravie", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mensaje_lbl.Location = new System.Drawing.Point(262, 189);
            this.Mensaje_lbl.Name = "Mensaje_lbl";
            this.Mensaje_lbl.Size = new System.Drawing.Size(169, 54);
            this.Mensaje_lbl.TabIndex = 0;
            this.Mensaje_lbl.Text = "label1";
            // 
            // Aceptar_btn
            // 
            this.Aceptar_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Aceptar_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Aceptar_btn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Aceptar_btn.Location = new System.Drawing.Point(323, 347);
            this.Aceptar_btn.Name = "Aceptar_btn";
            this.Aceptar_btn.Size = new System.Drawing.Size(330, 165);
            this.Aceptar_btn.TabIndex = 1;
            this.Aceptar_btn.Text = "Aceptar";
            this.Aceptar_btn.UseVisualStyleBackColor = false;
            this.Aceptar_btn.Click += new System.EventHandler(this.Aceptar_btn_Click);
            // 
            // Rechazar_btn
            // 
            this.Rechazar_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Rechazar_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rechazar_btn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Rechazar_btn.Location = new System.Drawing.Point(779, 347);
            this.Rechazar_btn.Name = "Rechazar_btn";
            this.Rechazar_btn.Size = new System.Drawing.Size(330, 165);
            this.Rechazar_btn.TabIndex = 2;
            this.Rechazar_btn.Text = "Rechazar";
            this.Rechazar_btn.UseVisualStyleBackColor = false;
            this.Rechazar_btn.Click += new System.EventHandler(this.Rechazar_btn_Click);
            // 
            // Form_Invitacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1442, 708);
            this.Controls.Add(this.Rechazar_btn);
            this.Controls.Add(this.Aceptar_btn);
            this.Controls.Add(this.Mensaje_lbl);
            this.Name = "Form_Invitacion";
            this.Text = "Form_Invitacion";
            this.Load += new System.EventHandler(this.Form_Invitacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Mensaje_lbl;
        private System.Windows.Forms.Button Aceptar_btn;
        private System.Windows.Forms.Button Rechazar_btn;
    }
}