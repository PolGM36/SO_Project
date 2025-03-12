namespace Cliente
{
    partial class Form_query
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
            this.Match_ID_text = new System.Windows.Forms.Label();
            this.Query_txt = new System.Windows.Forms.TextBox();
            this.Query_btn = new System.Windows.Forms.Button();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.back_btn = new System.Windows.Forms.Button();
            this.username_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Match_ID_text
            // 
            this.Match_ID_text.AutoSize = true;
            this.Match_ID_text.Location = new System.Drawing.Point(399, 180);
            this.Match_ID_text.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Match_ID_text.Name = "Match_ID_text";
            this.Match_ID_text.Size = new System.Drawing.Size(78, 20);
            this.Match_ID_text.TabIndex = 26;
            this.Match_ID_text.Text = "Match ID:";
            // 
            // Query_txt
            // 
            this.Query_txt.Location = new System.Drawing.Point(403, 209);
            this.Query_txt.Margin = new System.Windows.Forms.Padding(2);
            this.Query_txt.Name = "Query_txt";
            this.Query_txt.Size = new System.Drawing.Size(191, 26);
            this.Query_txt.TabIndex = 25;
            // 
            // Query_btn
            // 
            this.Query_btn.BackColor = System.Drawing.Color.LightGray;
            this.Query_btn.Location = new System.Drawing.Point(212, 327);
            this.Query_btn.Margin = new System.Windows.Forms.Padding(2);
            this.Query_btn.Name = "Query_btn";
            this.Query_btn.Size = new System.Drawing.Size(182, 46);
            this.Query_btn.TabIndex = 24;
            this.Query_btn.Text = "Query!";
            this.Query_btn.UseVisualStyleBackColor = false;
            this.Query_btn.Click += new System.EventHandler(this.Query_btn_Click);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(212, 257);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(177, 24);
            this.radioButton3.TabIndex = 23;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Winner of the match";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(212, 210);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(188, 24);
            this.radioButton2.TabIndex = 22;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Duration of the match";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(212, 162);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(161, 24);
            this.radioButton1.TabIndex = 21;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Time of the match";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(207, 77);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 31);
            this.label7.TabIndex = 20;
            this.label7.Text = "Querys";
            // 
            // back_btn
            // 
            this.back_btn.BackColor = System.Drawing.Color.LightGray;
            this.back_btn.Location = new System.Drawing.Point(431, 327);
            this.back_btn.Margin = new System.Windows.Forms.Padding(2);
            this.back_btn.Name = "back_btn";
            this.back_btn.Size = new System.Drawing.Size(182, 46);
            this.back_btn.TabIndex = 27;
            this.back_btn.Text = "BACK";
            this.back_btn.UseVisualStyleBackColor = false;
            this.back_btn.Click += new System.EventHandler(this.back_btn_Click);
            // 
            // username_lbl
            // 
            this.username_lbl.AutoSize = true;
            this.username_lbl.Font = new System.Drawing.Font("Microsoft New Tai Lue", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username_lbl.Location = new System.Drawing.Point(11, 9);
            this.username_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.username_lbl.Name = "username_lbl";
            this.username_lbl.Size = new System.Drawing.Size(81, 21);
            this.username_lbl.TabIndex = 28;
            this.username_lbl.Text = "Username";
            // 
            // Form_query
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.username_lbl);
            this.Controls.Add(this.back_btn);
            this.Controls.Add(this.Match_ID_text);
            this.Controls.Add(this.Query_txt);
            this.Controls.Add(this.Query_btn);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label7);
            this.Name = "Form_query";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Match_ID_text;
        private System.Windows.Forms.TextBox Query_txt;
        private System.Windows.Forms.Button Query_btn;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button back_btn;
        private System.Windows.Forms.Label username_lbl;
    }
}