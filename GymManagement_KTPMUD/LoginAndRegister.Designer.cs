namespace GymManagement_KTPMUD
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.gradientPanel1 = new CustomControl.GradientPanel();
            this.panelMenu = new CustomControl.GradientPanel();
            this.roundAnglePanel1 = new CustomControl.RoundAnglePanel();
            this.panel_login = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox_eyeLogin = new System.Windows.Forms.PictureBox();
            this.textbox_password_login = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textbox_username_login = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button_register = new System.Windows.Forms.Button();
            this.button_login = new System.Windows.Forms.Button();
            this.panel_register = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.textbox_email_register = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox_eyeRegister = new System.Windows.Forms.PictureBox();
            this.textbox_password_register = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textbox_username_register = new System.Windows.Forms.TextBox();
            this.button_SignUpAfter = new System.Windows.Forms.Button();
            this.picturebox3_login = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelMenu.SuspendLayout();
            this.roundAnglePanel1.SuspendLayout();
            this.panel_login.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_eyeLogin)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel_register.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_eyeRegister)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox3_login)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.gradientBottom = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.gradientPanel1.gradientTop = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gradientPanel1.Location = new System.Drawing.Point(0, -2);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(1001, 34);
            this.gradientPanel1.TabIndex = 2;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(87)))));
            this.panelMenu.Controls.Add(this.label1);
            this.panelMenu.Controls.Add(this.roundAnglePanel1);
            this.panelMenu.Controls.Add(this.picturebox3_login);
            this.panelMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(87)))));
            this.panelMenu.gradientBottom = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.panelMenu.gradientTop = System.Drawing.Color.DimGray;
            this.panelMenu.Location = new System.Drawing.Point(0, 27);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(1001, 626);
            this.panelMenu.TabIndex = 9;
            this.panelMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMenu_Paint_1);
            // 
            // roundAnglePanel1
            // 
            this.roundAnglePanel1.BackColor = System.Drawing.Color.White;
            this.roundAnglePanel1.BorderColor = System.Drawing.Color.DarkBlue;
            this.roundAnglePanel1.Controls.Add(this.pictureBox1);
            this.roundAnglePanel1.Controls.Add(this.panel_login);
            this.roundAnglePanel1.Controls.Add(this.button_register);
            this.roundAnglePanel1.Controls.Add(this.button_login);
            this.roundAnglePanel1.Controls.Add(this.panel_register);
            this.roundAnglePanel1.FillColor = System.Drawing.Color.White;
            this.roundAnglePanel1.ForeColor = System.Drawing.Color.White;
            this.roundAnglePanel1.Location = new System.Drawing.Point(508, 51);
            this.roundAnglePanel1.Name = "roundAnglePanel1";
            this.roundAnglePanel1.Radius = 20;
            this.roundAnglePanel1.Size = new System.Drawing.Size(434, 544);
            this.roundAnglePanel1.TabIndex = 0;
            this.roundAnglePanel1.Thickness = 2F;
            // 
            // panel_login
            // 
            this.panel_login.BackColor = System.Drawing.Color.White;
            this.panel_login.Controls.Add(this.button2);
            this.panel_login.Controls.Add(this.panel2);
            this.panel_login.Controls.Add(this.panel1);
            this.panel_login.Controls.Add(this.button1);
            this.panel_login.Font = new System.Drawing.Font("Microsoft Tai Le", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel_login.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel_login.Location = new System.Drawing.Point(32, 231);
            this.panel_login.Name = "panel_login";
            this.panel_login.Size = new System.Drawing.Size(372, 329);
            this.panel_login.TabIndex = 4;
            this.panel_login.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMenu_Paint);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.Location = new System.Drawing.Point(14, 239);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(346, 41);
            this.button2.TabIndex = 17;
            this.button2.Text = "Forgot password ?";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.pictureBox_eyeLogin);
            this.panel2.Controls.Add(this.textbox_password_login);
            this.panel2.Location = new System.Drawing.Point(16, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(344, 49);
            this.panel2.TabIndex = 16;
            // 
            // pictureBox_eyeLogin
            // 
            this.pictureBox_eyeLogin.Location = new System.Drawing.Point(295, 12);
            this.pictureBox_eyeLogin.Name = "pictureBox_eyeLogin";
            this.pictureBox_eyeLogin.Size = new System.Drawing.Size(41, 34);
            this.pictureBox_eyeLogin.TabIndex = 15;
            this.pictureBox_eyeLogin.TabStop = false;
            this.pictureBox_eyeLogin.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // textbox_password_login
            // 
            this.textbox_password_login.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textbox_password_login.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox_password_login.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_password_login.ForeColor = System.Drawing.Color.Black;
            this.textbox_password_login.Location = new System.Drawing.Point(10, 12);
            this.textbox_password_login.Name = "textbox_password_login";
            this.textbox_password_login.Size = new System.Drawing.Size(279, 24);
            this.textbox_password_login.TabIndex = 14;
            this.textbox_password_login.TextChanged += new System.EventHandler(this.textbox_password_login_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.textbox_username_login);
            this.panel1.Location = new System.Drawing.Point(16, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(344, 49);
            this.panel1.TabIndex = 15;
            // 
            // textbox_username_login
            // 
            this.textbox_username_login.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textbox_username_login.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox_username_login.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_username_login.ForeColor = System.Drawing.Color.Black;
            this.textbox_username_login.Location = new System.Drawing.Point(10, 14);
            this.textbox_username_login.Margin = new System.Windows.Forms.Padding(0, 500, 0, 0);
            this.textbox_username_login.Name = "textbox_username_login";
            this.textbox_username_login.Size = new System.Drawing.Size(326, 24);
            this.textbox_username_login.TabIndex = 13;
            this.textbox_username_login.TextChanged += new System.EventHandler(this.textbox_username_login_TextChanged_1);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(87)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(14, 174);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(346, 36);
            this.button1.TabIndex = 12;
            this.button1.Text = "LOGIN";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button_register
            // 
            this.button_register.BackColor = System.Drawing.Color.White;
            this.button_register.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_register.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_register.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button_register.Location = new System.Drawing.Point(224, 175);
            this.button_register.Name = "button_register";
            this.button_register.Size = new System.Drawing.Size(168, 39);
            this.button_register.TabIndex = 7;
            this.button_register.Text = "Register";
            this.button_register.UseVisualStyleBackColor = false;
            this.button_register.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_login
            // 
            this.button_login.BackColor = System.Drawing.Color.White;
            this.button_login.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_login.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_login.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button_login.Location = new System.Drawing.Point(48, 175);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(171, 39);
            this.button_login.TabIndex = 6;
            this.button_login.Text = "Login";
            this.button_login.UseVisualStyleBackColor = false;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // panel_register
            // 
            this.panel_register.BackColor = System.Drawing.Color.White;
            this.panel_register.Controls.Add(this.panel5);
            this.panel_register.Controls.Add(this.panel4);
            this.panel_register.Controls.Add(this.panel3);
            this.panel_register.Controls.Add(this.button_SignUpAfter);
            this.panel_register.Location = new System.Drawing.Point(32, 231);
            this.panel_register.Name = "panel_register";
            this.panel_register.Size = new System.Drawing.Size(372, 292);
            this.panel_register.TabIndex = 3;
            this.panel_register.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_register_Paint);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel5.Controls.Add(this.textbox_email_register);
            this.panel5.Location = new System.Drawing.Point(15, 174);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(343, 49);
            this.panel5.TabIndex = 19;
            // 
            // textbox_email_register
            // 
            this.textbox_email_register.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textbox_email_register.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox_email_register.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_email_register.ForeColor = System.Drawing.Color.Black;
            this.textbox_email_register.Location = new System.Drawing.Point(11, 16);
            this.textbox_email_register.Name = "textbox_email_register";
            this.textbox_email_register.Size = new System.Drawing.Size(321, 24);
            this.textbox_email_register.TabIndex = 16;
            this.textbox_email_register.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel4.Controls.Add(this.pictureBox_eyeRegister);
            this.panel4.Controls.Add(this.textbox_password_register);
            this.panel4.Location = new System.Drawing.Point(16, 100);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(344, 49);
            this.panel4.TabIndex = 18;
            // 
            // pictureBox_eyeRegister
            // 
            this.pictureBox_eyeRegister.Location = new System.Drawing.Point(295, 12);
            this.pictureBox_eyeRegister.Name = "pictureBox_eyeRegister";
            this.pictureBox_eyeRegister.Size = new System.Drawing.Size(41, 34);
            this.pictureBox_eyeRegister.TabIndex = 16;
            this.pictureBox_eyeRegister.TabStop = false;
            this.pictureBox_eyeRegister.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // textbox_password_register
            // 
            this.textbox_password_register.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textbox_password_register.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox_password_register.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_password_register.ForeColor = System.Drawing.Color.Black;
            this.textbox_password_register.Location = new System.Drawing.Point(10, 12);
            this.textbox_password_register.Name = "textbox_password_register";
            this.textbox_password_register.Size = new System.Drawing.Size(282, 24);
            this.textbox_password_register.TabIndex = 15;
            this.textbox_password_register.TextChanged += new System.EventHandler(this.textbox_password_register_TextChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.textbox_username_register);
            this.panel3.Location = new System.Drawing.Point(16, 25);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(344, 49);
            this.panel3.TabIndex = 17;
            // 
            // textbox_username_register
            // 
            this.textbox_username_register.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textbox_username_register.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox_username_register.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_username_register.ForeColor = System.Drawing.Color.Black;
            this.textbox_username_register.Location = new System.Drawing.Point(10, 13);
            this.textbox_username_register.Name = "textbox_username_register";
            this.textbox_username_register.Size = new System.Drawing.Size(321, 24);
            this.textbox_username_register.TabIndex = 14;
            this.textbox_username_register.TextChanged += new System.EventHandler(this.textbox_username_register_TextChanged_1);
            // 
            // button_SignUpAfter
            // 
            this.button_SignUpAfter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(87)))));
            this.button_SignUpAfter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_SignUpAfter.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_SignUpAfter.Location = new System.Drawing.Point(16, 251);
            this.button_SignUpAfter.Name = "button_SignUpAfter";
            this.button_SignUpAfter.Size = new System.Drawing.Size(343, 36);
            this.button_SignUpAfter.TabIndex = 12;
            this.button_SignUpAfter.Text = "SIGN UP";
            this.button_SignUpAfter.UseVisualStyleBackColor = false;
            this.button_SignUpAfter.Click += new System.EventHandler(this.button_SignUpAfter_Click);
            // 
            // picturebox3_login
            // 
            this.picturebox3_login.BackColor = System.Drawing.Color.Transparent;
            this.picturebox3_login.Image = ((System.Drawing.Image)(resources.GetObject("picturebox3_login.Image")));
            this.picturebox3_login.Location = new System.Drawing.Point(56, 51);
            this.picturebox3_login.Name = "picturebox3_login";
            this.picturebox3_login.Size = new System.Drawing.Size(398, 352);
            this.picturebox3_login.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picturebox3_login.TabIndex = 0;
            this.picturebox3_login.TabStop = false;
            this.picturebox3_login.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Emoji", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(121, 382);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 53);
            this.label1.TabIndex = 1;
            this.label1.Text = "LOJ FITNESS";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(113, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(213, 152);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.gradientPanel1);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.roundAnglePanel1.ResumeLayout(false);
            this.panel_login.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_eyeLogin)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel_register.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_eyeRegister)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox3_login)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel_login;
        private System.Windows.Forms.Panel panel_register;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button button_register;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.Button button_SignUpAfter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox picturebox3_login;
        private CustomControl.GradientPanel panelMenu;
        private CustomControl.RoundAnglePanel roundAnglePanel1;
        private System.Windows.Forms.TextBox textbox_username_login;
        private System.Windows.Forms.TextBox textbox_password_login;
        private CustomControl.GradientPanel gradientPanel1;
        private System.Windows.Forms.TextBox textbox_email_register;
        private System.Windows.Forms.TextBox textbox_password_register;
        private System.Windows.Forms.TextBox textbox_username_register;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox_eyeLogin;
        private System.Windows.Forms.PictureBox pictureBox_eyeRegister;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

