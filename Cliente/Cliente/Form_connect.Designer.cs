﻿namespace Cliente
{
    partial class Form_connect
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
            this.label1 = new System.Windows.Forms.Label();
            this.start_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Ravie", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(130, 61);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(455, 96);
            this.label1.TabIndex = 0;
            this.label1.Text = "UPartyC";
            // 
            // start_btn
            // 
            this.start_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.start_btn.Cursor = System.Windows.Forms.Cursors.Default;
            this.start_btn.Font = new System.Drawing.Font("Ravie", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start_btn.Location = new System.Drawing.Point(158, 128);
            this.start_btn.Margin = new System.Windows.Forms.Padding(2);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(157, 77);
            this.start_btn.TabIndex = 1;
            this.start_btn.Text = "PLAY";
            this.start_btn.UseVisualStyleBackColor = false;
            this.start_btn.Click += new System.EventHandler(this.start_btn_Click);
            // 
            // Form_connect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Cliente.Properties.Resources.imagen_fondo;
            this.ClientSize = new System.Drawing.Size(1898, 1024);
            this.Controls.Add(this.start_btn);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form_connect";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button start_btn;
    }
}