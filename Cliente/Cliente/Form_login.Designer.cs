namespace Cliente
{
    partial class Form_login
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
            this.checkBox_r = new System.Windows.Forms.CheckBox();
            this.checkBox_l = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Register";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 278);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Loggin";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 89);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(234, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Input your username to register:";
            // 
            // Register_txt
            // 
            this.Register_txt.Location = new System.Drawing.Point(266, 87);
            this.Register_txt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Register_txt.Name = "Register_txt";
            this.Register_txt.Size = new System.Drawing.Size(191, 26);
            this.Register_txt.TabIndex = 3;
            // 
            // Register_btn
            // 
            this.Register_btn.BackColor = System.Drawing.Color.LightGray;
            this.Register_btn.Location = new System.Drawing.Point(134, 196);
            this.Register_btn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Register_btn.Name = "Register_btn";
            this.Register_btn.Size = new System.Drawing.Size(182, 46);
            this.Register_btn.TabIndex = 4;
            this.Register_btn.Text = "Register!";
            this.Register_btn.UseVisualStyleBackColor = false;
            this.Register_btn.Click += new System.EventHandler(this.Register_btn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 327);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "USERNAME:";
            // 
            // Loggin_txt
            // 
            this.Loggin_txt.Location = new System.Drawing.Point(134, 323);
            this.Loggin_txt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Loggin_txt.Name = "Loggin_txt";
            this.Loggin_txt.Size = new System.Drawing.Size(191, 26);
            this.Loggin_txt.TabIndex = 6;
            // 
            // Loggin_btn
            // 
            this.Loggin_btn.BackColor = System.Drawing.Color.LightGray;
            this.Loggin_btn.Location = new System.Drawing.Point(134, 433);
            this.Loggin_btn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Loggin_btn.Name = "Loggin_btn";
            this.Loggin_btn.Size = new System.Drawing.Size(182, 46);
            this.Loggin_btn.TabIndex = 7;
            this.Loggin_btn.Text = "Loggin!";
            this.Loggin_btn.UseVisualStyleBackColor = false;
            this.Loggin_btn.Click += new System.EventHandler(this.Loggin_btn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 135);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(231, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Input your password to register:";
            // 
            // register_passw_txt
            // 
            this.register_passw_txt.Location = new System.Drawing.Point(266, 132);
            this.register_passw_txt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.register_passw_txt.Name = "register_passw_txt";
            this.register_passw_txt.Size = new System.Drawing.Size(191, 26);
            this.register_passw_txt.TabIndex = 9;
            // 
            // back_btn
            // 
            this.back_btn.BackColor = System.Drawing.Color.IndianRed;
            this.back_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.back_btn.Location = new System.Drawing.Point(134, 549);
            this.back_btn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.back_btn.Name = "back_btn";
            this.back_btn.Size = new System.Drawing.Size(182, 46);
            this.back_btn.TabIndex = 10;
            this.back_btn.Text = "BACK";
            this.back_btn.UseVisualStyleBackColor = false;
            this.back_btn.Click += new System.EventHandler(this.back_btn_Click);
            // 
            // loggin_password_txt
            // 
            this.loggin_password_txt.Location = new System.Drawing.Point(134, 368);
            this.loggin_password_txt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.loggin_password_txt.Name = "loggin_password_txt";
            this.loggin_password_txt.Size = new System.Drawing.Size(191, 26);
            this.loggin_password_txt.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 372);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "PASSWORD:";
            // 
            // checkBox_r
            // 
            this.checkBox_r.AutoSize = true;
            this.checkBox_r.Location = new System.Drawing.Point(462, 135);
            this.checkBox_r.Name = "checkBox_r";
            this.checkBox_r.Size = new System.Drawing.Size(148, 24);
            this.checkBox_r.TabIndex = 15;
            this.checkBox_r.Text = "Show Password";
            this.checkBox_r.UseVisualStyleBackColor = true;
            this.checkBox_r.CheckedChanged += new System.EventHandler(this.checkBox_r_CheckedChanged);
            // 
            // checkBox_l
            // 
            this.checkBox_l.AutoSize = true;
            this.checkBox_l.Location = new System.Drawing.Point(330, 372);
            this.checkBox_l.Name = "checkBox_l";
            this.checkBox_l.Size = new System.Drawing.Size(148, 24);
            this.checkBox_l.TabIndex = 16;
            this.checkBox_l.Text = "Show Password";
            this.checkBox_l.UseVisualStyleBackColor = true;
            this.checkBox_l.CheckedChanged += new System.EventHandler(this.checkBox_l_CheckedChanged);
            // 
            // Form_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1442, 832);
            this.Controls.Add(this.checkBox_l);
            this.Controls.Add(this.checkBox_r);
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
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form_login";
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
        private System.Windows.Forms.CheckBox checkBox_r;
        private System.Windows.Forms.CheckBox checkBox_l;
    }
}

