namespace Cliente
{
    partial class Form1
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Register_txt = new System.Windows.Forms.TextBox();
            this.Register_btn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Loggin_txt = new System.Windows.Forms.TextBox();
            this.Loggin_btn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.register_passw_txt = new System.Windows.Forms.TextBox();
            this.back_btn = new System.Windows.Forms.Button();
            this.loggin_password_txt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.Query_btn = new System.Windows.Forms.Button();
            this.Query_txt = new System.Windows.Forms.TextBox();
            this.Match_ID_text = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "Register";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(50, 431);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 52);
            this.label2.TabIndex = 1;
            this.label2.Text = "Loggin";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(413, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "Input your username to register:";
            // 
            // Register_txt
            // 
            this.Register_txt.Location = new System.Drawing.Point(472, 135);
            this.Register_txt.Name = "Register_txt";
            this.Register_txt.Size = new System.Drawing.Size(336, 38);
            this.Register_txt.TabIndex = 3;
            // 
            // Register_btn
            // 
            this.Register_btn.BackColor = System.Drawing.Color.LightGray;
            this.Register_btn.Location = new System.Drawing.Point(239, 304);
            this.Register_btn.Name = "Register_btn";
            this.Register_btn.Size = new System.Drawing.Size(323, 71);
            this.Register_btn.TabIndex = 4;
            this.Register_btn.Text = "Register!";
            this.Register_btn.UseVisualStyleBackColor = false;
            this.Register_btn.Click += new System.EventHandler(this.Register_btn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 507);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(181, 32);
            this.label4.TabIndex = 5;
            this.label4.Text = "USERNAME:";
            // 
            // Loggin_txt
            // 
            this.Loggin_txt.Location = new System.Drawing.Point(239, 501);
            this.Loggin_txt.Name = "Loggin_txt";
            this.Loggin_txt.Size = new System.Drawing.Size(336, 38);
            this.Loggin_txt.TabIndex = 6;
            // 
            // Loggin_btn
            // 
            this.Loggin_btn.BackColor = System.Drawing.Color.LightGray;
            this.Loggin_btn.Location = new System.Drawing.Point(239, 671);
            this.Loggin_btn.Name = "Loggin_btn";
            this.Loggin_btn.Size = new System.Drawing.Size(323, 71);
            this.Loggin_btn.TabIndex = 7;
            this.Loggin_btn.Text = "Loggin!";
            this.Loggin_btn.UseVisualStyleBackColor = false;
            this.Loggin_btn.Click += new System.EventHandler(this.Loggin_btn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(408, 32);
            this.label5.TabIndex = 8;
            this.label5.Text = "Input your password to register:";
            // 
            // register_passw_txt
            // 
            this.register_passw_txt.Location = new System.Drawing.Point(472, 204);
            this.register_passw_txt.Name = "register_passw_txt";
            this.register_passw_txt.Size = new System.Drawing.Size(336, 38);
            this.register_passw_txt.TabIndex = 9;
            // 
            // back_btn
            // 
            this.back_btn.BackColor = System.Drawing.Color.IndianRed;
            this.back_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.back_btn.Location = new System.Drawing.Point(724, 744);
            this.back_btn.Name = "back_btn";
            this.back_btn.Size = new System.Drawing.Size(323, 71);
            this.back_btn.TabIndex = 10;
            this.back_btn.Text = "BACK";
            this.back_btn.UseVisualStyleBackColor = false;
            this.back_btn.Click += new System.EventHandler(this.back_btn_Click);
            // 
            // loggin_password_txt
            // 
            this.loggin_password_txt.Location = new System.Drawing.Point(239, 571);
            this.loggin_password_txt.Name = "loggin_password_txt";
            this.loggin_password_txt.Size = new System.Drawing.Size(336, 38);
            this.loggin_password_txt.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 577);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(186, 32);
            this.label6.TabIndex = 12;
            this.label6.Text = "PASSWORD:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(893, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(154, 52);
            this.label7.TabIndex = 13;
            this.label7.Text = "Querys";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(902, 270);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(276, 36);
            this.radioButton1.TabIndex = 14;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Time of the match";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(902, 344);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(321, 36);
            this.radioButton2.TabIndex = 15;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Duration of the match";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(902, 417);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(303, 36);
            this.radioButton3.TabIndex = 16;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Winner of the match";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // Query_btn
            // 
            this.Query_btn.BackColor = System.Drawing.Color.LightGray;
            this.Query_btn.Location = new System.Drawing.Point(902, 525);
            this.Query_btn.Name = "Query_btn";
            this.Query_btn.Size = new System.Drawing.Size(323, 71);
            this.Query_btn.TabIndex = 17;
            this.Query_btn.Text = "Query!";
            this.Query_btn.UseVisualStyleBackColor = false;
            this.Query_btn.Click += new System.EventHandler(this.Query_btn_Click);
            // 
            // Query_txt
            // 
            this.Query_txt.Location = new System.Drawing.Point(1240, 342);
            this.Query_txt.Name = "Query_txt";
            this.Query_txt.Size = new System.Drawing.Size(336, 38);
            this.Query_txt.TabIndex = 18;
            // 
            // Match_ID_text
            // 
            this.Match_ID_text.AutoSize = true;
            this.Match_ID_text.Location = new System.Drawing.Point(1234, 298);
            this.Match_ID_text.Name = "Match_ID_text";
            this.Match_ID_text.Size = new System.Drawing.Size(133, 32);
            this.Match_ID_text.TabIndex = 19;
            this.Match_ID_text.Text = "Match ID:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2576, 1290);
            this.Controls.Add(this.Match_ID_text);
            this.Controls.Add(this.Query_txt);
            this.Controls.Add(this.Query_btn);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.loggin_password_txt);
            this.Controls.Add(this.back_btn);
            this.Controls.Add(this.register_passw_txt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Loggin_btn);
            this.Controls.Add(this.Loggin_txt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Register_btn);
            this.Controls.Add(this.Register_txt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Register_txt;
        private System.Windows.Forms.Button Register_btn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Loggin_txt;
        private System.Windows.Forms.Button Loggin_btn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox register_passw_txt;
        private System.Windows.Forms.Button back_btn;
        private System.Windows.Forms.TextBox loggin_password_txt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Button Query_btn;
        private System.Windows.Forms.TextBox Query_txt;
        private System.Windows.Forms.Label Match_ID_text;
    }
}

