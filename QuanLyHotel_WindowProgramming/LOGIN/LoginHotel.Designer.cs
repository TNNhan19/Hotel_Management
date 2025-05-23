﻿namespace QuanLyHotel_WindowProgramming
{
    partial class LoginHotel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginHotel));
            this.lbHotelName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbDangNhap = new System.Windows.Forms.Label();
            this.lbMatKhau = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.txtDangNhap = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.RadioButtonLaoCong = new System.Windows.Forms.RadioButton();
            this.RadioButtonTiepTan = new System.Windows.Forms.RadioButton();
            this.RadioButtonQuanLy = new System.Windows.Forms.RadioButton();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnForgetPass = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbHotelName
            // 
            this.lbHotelName.AutoSize = true;
            this.lbHotelName.Font = new System.Drawing.Font("Showcard Gothic", 25.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHotelName.Location = new System.Drawing.Point(457, 57);
            this.lbHotelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbHotelName.Name = "lbHotelName";
            this.lbHotelName.Size = new System.Drawing.Size(536, 54);
            this.lbHotelName.TabIndex = 0;
            this.lbHotelName.Text = "WELCOME TO HN HOTEL";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-4, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(363, 501);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lbDangNhap
            // 
            this.lbDangNhap.AutoSize = true;
            this.lbDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDangNhap.Location = new System.Drawing.Point(442, 168);
            this.lbDangNhap.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDangNhap.Name = "lbDangNhap";
            this.lbDangNhap.Size = new System.Drawing.Size(195, 29);
            this.lbDangNhap.TabIndex = 2;
            this.lbDangNhap.Text = "Tên đăng nhập:";
            // 
            // lbMatKhau
            // 
            this.lbMatKhau.AutoSize = true;
            this.lbMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMatKhau.Location = new System.Drawing.Point(442, 234);
            this.lbMatKhau.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMatKhau.Name = "lbMatKhau";
            this.lbMatKhau.Size = new System.Drawing.Size(124, 29);
            this.lbMatKhau.TabIndex = 3;
            this.lbMatKhau.Text = "Mật khẩu:";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(660, 238);
            this.txtMatKhau.Margin = new System.Windows.Forms.Padding(4);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(181, 22);
            this.txtMatKhau.TabIndex = 4;
            // 
            // txtDangNhap
            // 
            this.txtDangNhap.Location = new System.Drawing.Point(660, 175);
            this.txtDangNhap.Margin = new System.Windows.Forms.Padding(4);
            this.txtDangNhap.Name = "txtDangNhap";
            this.txtDangNhap.Size = new System.Drawing.Size(181, 22);
            this.txtDangNhap.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.RadioButtonLaoCong);
            this.panel1.Controls.Add(this.RadioButtonTiepTan);
            this.panel1.Controls.Add(this.RadioButtonQuanLy);
            this.panel1.Location = new System.Drawing.Point(559, 298);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(367, 35);
            this.panel1.TabIndex = 6;
            // 
            // RadioButtonLaoCong
            // 
            this.RadioButtonLaoCong.AutoSize = true;
            this.RadioButtonLaoCong.Location = new System.Drawing.Point(256, 4);
            this.RadioButtonLaoCong.Margin = new System.Windows.Forms.Padding(4);
            this.RadioButtonLaoCong.Name = "RadioButtonLaoCong";
            this.RadioButtonLaoCong.Size = new System.Drawing.Size(86, 20);
            this.RadioButtonLaoCong.TabIndex = 2;
            this.RadioButtonLaoCong.TabStop = true;
            this.RadioButtonLaoCong.Text = "Lao Công";
            this.RadioButtonLaoCong.UseVisualStyleBackColor = true;
            // 
            // RadioButtonTiepTan
            // 
            this.RadioButtonTiepTan.AutoSize = true;
            this.RadioButtonTiepTan.Location = new System.Drawing.Point(125, 4);
            this.RadioButtonTiepTan.Margin = new System.Windows.Forms.Padding(4);
            this.RadioButtonTiepTan.Name = "RadioButtonTiepTan";
            this.RadioButtonTiepTan.Size = new System.Drawing.Size(83, 20);
            this.RadioButtonTiepTan.TabIndex = 1;
            this.RadioButtonTiepTan.TabStop = true;
            this.RadioButtonTiepTan.Text = "Tiếp Tân";
            this.RadioButtonTiepTan.UseVisualStyleBackColor = true;
            // 
            // RadioButtonQuanLy
            // 
            this.RadioButtonQuanLy.AutoSize = true;
            this.RadioButtonQuanLy.Location = new System.Drawing.Point(4, 4);
            this.RadioButtonQuanLy.Margin = new System.Windows.Forms.Padding(4);
            this.RadioButtonQuanLy.Name = "RadioButtonQuanLy";
            this.RadioButtonQuanLy.Size = new System.Drawing.Size(77, 20);
            this.RadioButtonQuanLy.TabIndex = 0;
            this.RadioButtonQuanLy.TabStop = true;
            this.RadioButtonQuanLy.Text = "Quản Lý";
            this.RadioButtonQuanLy.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Aquamarine;
            this.btnLogin.Location = new System.Drawing.Point(537, 352);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(145, 74);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.OrangeRed;
            this.btnCancel.Location = new System.Drawing.Point(540, 449);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(142, 92);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.Yellow;
            this.btnRegister.Location = new System.Drawing.Point(802, 352);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(4);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(146, 74);
            this.btnRegister.TabIndex = 9;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnForgetPass
            // 
            this.btnForgetPass.BackColor = System.Drawing.Color.Violet;
            this.btnForgetPass.Location = new System.Drawing.Point(802, 449);
            this.btnForgetPass.Margin = new System.Windows.Forms.Padding(4);
            this.btnForgetPass.Name = "btnForgetPass";
            this.btnForgetPass.Size = new System.Drawing.Size(146, 92);
            this.btnForgetPass.TabIndex = 10;
            this.btnForgetPass.Text = "Forget password";
            this.btnForgetPass.UseVisualStyleBackColor = false;
            // 
            // LoginHotel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.btnForgetPass);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtDangNhap);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.lbMatKhau);
            this.Controls.Add(this.lbDangNhap);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbHotelName);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LoginHotel";
            this.Text = "LoginHotel";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbHotelName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbDangNhap;
        private System.Windows.Forms.Label lbMatKhau;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.TextBox txtDangNhap;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton RadioButtonLaoCong;
        private System.Windows.Forms.RadioButton RadioButtonTiepTan;
        private System.Windows.Forms.RadioButton RadioButtonQuanLy;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnForgetPass;
    }
}