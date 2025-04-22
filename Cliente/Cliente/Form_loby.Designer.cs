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
            this.username_lbl = new System.Windows.Forms.Label();
            this.back_btn = new System.Windows.Forms.Button();
            this.Invitar_btn = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
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
            this.back_btn.Location = new System.Drawing.Point(2818, 1398);
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
            this.Invitar_btn.Location = new System.Drawing.Point(257, 431);
            this.Invitar_btn.Name = "Invitar_btn";
            this.Invitar_btn.Size = new System.Drawing.Size(546, 126);
            this.Invitar_btn.TabIndex = 31;
            this.Invitar_btn.Text = "Invitar";
            this.Invitar_btn.UseVisualStyleBackColor = false;
            this.Invitar_btn.Click += new System.EventHandler(this.Invitar_btn_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BackColor = System.Drawing.SystemColors.Control;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(863, 349);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.ScrollAlwaysVisible = true;
            this.checkedListBox1.Size = new System.Drawing.Size(414, 529);
            this.checkedListBox1.TabIndex = 32;
            // 
            // Form_loby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Cliente.Properties.Resources.loby;
            this.ClientSize = new System.Drawing.Size(3374, 1587);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.Invitar_btn);
            this.Controls.Add(this.back_btn);
            this.Controls.Add(this.username_lbl);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form_loby";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form_loby_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label username_lbl;
        private System.Windows.Forms.Button back_btn;
        private System.Windows.Forms.Button Invitar_btn;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}