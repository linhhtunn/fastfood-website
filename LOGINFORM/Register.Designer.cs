namespace LOGINFORM
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            this.label1 = new System.Windows.Forms.Label();
            this.paneldn = new System.Windows.Forms.Panel();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.username = new System.Windows.Forms.TextBox();
            this.panelemail = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.email = new System.Windows.Forms.TextBox();
            this.panelmk = new System.Windows.Forms.Panel();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.mk = new System.Windows.Forms.TextBox();
            this.panelsdt = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.sdt = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.paneldn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.panelemail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelmk.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.panelsdt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(411, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 58);
            this.label1.TabIndex = 0;
            this.label1.Text = "Register";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // paneldn
            // 
            this.paneldn.Controls.Add(this.pictureBox7);
            this.paneldn.Controls.Add(this.username);
            this.paneldn.Location = new System.Drawing.Point(164, 85);
            this.paneldn.Margin = new System.Windows.Forms.Padding(4);
            this.paneldn.Name = "paneldn";
            this.paneldn.Size = new System.Drawing.Size(696, 71);
            this.paneldn.TabIndex = 8;
            this.paneldn.Paint += new System.Windows.Forms.PaintEventHandler(this.panel8_Paint);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(20, 16);
            this.pictureBox7.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(73, 39);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 4;
            this.pictureBox7.TabStop = false;
            // 
            // username
            // 
            this.username.BackColor = System.Drawing.Color.White;
            this.username.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.ForeColor = System.Drawing.Color.Gray;
            this.username.Location = new System.Drawing.Point(119, 16);
            this.username.Margin = new System.Windows.Forms.Padding(4);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(528, 38);
            this.username.TabIndex = 2;
            this.username.Text = "Tên Đăng Ký";
            this.username.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            this.username.Enter += new System.EventHandler(this.username_Enter);
            this.username.Leave += new System.EventHandler(this.username_Leave);
            // 
            // panelemail
            // 
            this.panelemail.Controls.Add(this.pictureBox1);
            this.panelemail.Controls.Add(this.email);
            this.panelemail.Location = new System.Drawing.Point(164, 164);
            this.panelemail.Margin = new System.Windows.Forms.Padding(4);
            this.panelemail.Name = "panelemail";
            this.panelemail.Size = new System.Drawing.Size(696, 71);
            this.panelemail.TabIndex = 9;
            this.panelemail.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(20, 16);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(73, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // email
            // 
            this.email.BackColor = System.Drawing.Color.White;
            this.email.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email.ForeColor = System.Drawing.Color.Gray;
            this.email.Location = new System.Drawing.Point(119, 16);
            this.email.Margin = new System.Windows.Forms.Padding(4);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(528, 38);
            this.email.TabIndex = 2;
            this.email.Text = "Email";
            this.email.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.email.Enter += new System.EventHandler(this.email_Enter);
            this.email.Leave += new System.EventHandler(this.email_Leave);
            // 
            // panelmk
            // 
            this.panelmk.Controls.Add(this.pictureBox8);
            this.panelmk.Controls.Add(this.mk);
            this.panelmk.Location = new System.Drawing.Point(164, 242);
            this.panelmk.Margin = new System.Windows.Forms.Padding(4);
            this.panelmk.Name = "panelmk";
            this.panelmk.Size = new System.Drawing.Size(696, 71);
            this.panelmk.TabIndex = 10;
            this.panelmk.Paint += new System.Windows.Forms.PaintEventHandler(this.panel11_Paint);
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(20, 16);
            this.pictureBox8.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(73, 39);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 5;
            this.pictureBox8.TabStop = false;
            // 
            // mk
            // 
            this.mk.BackColor = System.Drawing.Color.White;
            this.mk.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mk.ForeColor = System.Drawing.Color.Gray;
            this.mk.Location = new System.Drawing.Point(119, 16);
            this.mk.Margin = new System.Windows.Forms.Padding(4);
            this.mk.Name = "mk";
            this.mk.Size = new System.Drawing.Size(528, 38);
            this.mk.TabIndex = 3;
            this.mk.Text = "Mật Khẩu";
            this.mk.TextChanged += new System.EventHandler(this.mk_TextChanged);
            this.mk.Enter += new System.EventHandler(this.mk_Enter);
            this.mk.Leave += new System.EventHandler(this.mk_Leave);
            // 
            // panelsdt
            // 
            this.panelsdt.Controls.Add(this.pictureBox2);
            this.panelsdt.Controls.Add(this.sdt);
            this.panelsdt.Location = new System.Drawing.Point(164, 321);
            this.panelsdt.Margin = new System.Windows.Forms.Padding(4);
            this.panelsdt.Name = "panelsdt";
            this.panelsdt.Size = new System.Drawing.Size(696, 71);
            this.panelsdt.TabIndex = 11;
            this.panelsdt.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(20, 16);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(73, 39);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // sdt
            // 
            this.sdt.BackColor = System.Drawing.Color.White;
            this.sdt.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sdt.ForeColor = System.Drawing.Color.Gray;
            this.sdt.Location = new System.Drawing.Point(119, 16);
            this.sdt.Margin = new System.Windows.Forms.Padding(4);
            this.sdt.Name = "sdt";
            this.sdt.Size = new System.Drawing.Size(528, 38);
            this.sdt.TabIndex = 3;
            this.sdt.Text = "Số Điện Thoại";
            this.sdt.Enter += new System.EventHandler(this.sdt_Enter);
            this.sdt.Leave += new System.EventHandler(this.sdt_Leave);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(9)))), ((int)(((byte)(43)))));
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.Control;
            this.button3.Location = new System.Drawing.Point(411, 426);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(279, 67);
            this.button3.TabIndex = 12;
            this.button3.Text = "Đăng Ký";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panelsdt);
            this.Controls.Add(this.panelmk);
            this.Controls.Add(this.panelemail);
            this.Controls.Add(this.paneldn);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Register";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Register_Load);
            this.Click += new System.EventHandler(this.Register_Click);
            this.paneldn.ResumeLayout(false);
            this.paneldn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.panelemail.ResumeLayout(false);
            this.panelemail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelmk.ResumeLayout(false);
            this.panelmk.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.panelsdt.ResumeLayout(false);
            this.panelsdt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel paneldn;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Panel panelemail;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.Panel panelmk;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.TextBox mk;
        private System.Windows.Forms.Panel panelsdt;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox sdt;
        private System.Windows.Forms.Button button3;
    }
}