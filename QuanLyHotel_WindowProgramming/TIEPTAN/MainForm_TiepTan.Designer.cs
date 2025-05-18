namespace QuanLyHotel_WindowProgramming
{
    partial class MainForm_TiepTan
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
            this.buttonManagementCustomer = new System.Windows.Forms.Button();
            this.btnFoodManagement = new System.Windows.Forms.Button();
            this.buttonDkyCustomer = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonAddRoom = new System.Windows.Forms.Button();
            this.btnManagementRoom = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnStaffCheck = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonManagementCustomer
            // 
            this.buttonManagementCustomer.Location = new System.Drawing.Point(28, 151);
            this.buttonManagementCustomer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonManagementCustomer.Name = "buttonManagementCustomer";
            this.buttonManagementCustomer.Size = new System.Drawing.Size(235, 107);
            this.buttonManagementCustomer.TabIndex = 5;
            this.buttonManagementCustomer.Text = "Quản lý khách hàng";
            this.buttonManagementCustomer.UseVisualStyleBackColor = true;
            this.buttonManagementCustomer.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnFoodManagement
            // 
            this.btnFoodManagement.BackColor = System.Drawing.Color.PowderBlue;
            this.btnFoodManagement.Location = new System.Drawing.Point(4, 28);
            this.btnFoodManagement.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFoodManagement.Name = "btnFoodManagement";
            this.btnFoodManagement.Size = new System.Drawing.Size(139, 203);
            this.btnFoodManagement.TabIndex = 2;
            this.btnFoodManagement.Text = "Quản lý thực phẩm";
            this.btnFoodManagement.UseVisualStyleBackColor = false;
            this.btnFoodManagement.Click += new System.EventHandler(this.btnFoodManagement_Click);
            // 
            // buttonDkyCustomer
            // 
            this.buttonDkyCustomer.BackColor = System.Drawing.Color.PeachPuff;
            this.buttonDkyCustomer.Location = new System.Drawing.Point(28, 25);
            this.buttonDkyCustomer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonDkyCustomer.Name = "buttonDkyCustomer";
            this.buttonDkyCustomer.Size = new System.Drawing.Size(235, 121);
            this.buttonDkyCustomer.TabIndex = 1;
            this.buttonDkyCustomer.Text = "Đăng Ký Khách hàng";
            this.buttonDkyCustomer.UseVisualStyleBackColor = false;
            this.buttonDkyCustomer.Click += new System.EventHandler(this.buttonDkyCustomer_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.IndianRed;
            this.buttonExit.Location = new System.Drawing.Point(9, 10);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(124, 70);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonAddRoom
            // 
            this.buttonAddRoom.BackColor = System.Drawing.Color.Aquamarine;
            this.buttonAddRoom.Location = new System.Drawing.Point(16, 25);
            this.buttonAddRoom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonAddRoom.Name = "buttonAddRoom";
            this.buttonAddRoom.Size = new System.Drawing.Size(158, 232);
            this.buttonAddRoom.TabIndex = 0;
            this.buttonAddRoom.Text = "Thêm phòng";
            this.buttonAddRoom.UseVisualStyleBackColor = false;
            this.buttonAddRoom.Click += new System.EventHandler(this.buttonAddRoom_Click);
            // 
            // btnManagementRoom
            // 
            this.btnManagementRoom.BackColor = System.Drawing.Color.Aqua;
            this.btnManagementRoom.Location = new System.Drawing.Point(196, 25);
            this.btnManagementRoom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnManagementRoom.Name = "btnManagementRoom";
            this.btnManagementRoom.Size = new System.Drawing.Size(136, 232);
            this.btnManagementRoom.TabIndex = 4;
            this.btnManagementRoom.Text = "Quản lý phòng";
            this.btnManagementRoom.UseVisualStyleBackColor = false;
            this.btnManagementRoom.Click += new System.EventHandler(this.btnManagementRoom_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnManagementRoom);
            this.groupBox1.Controls.Add(this.buttonAddRoom);
            this.groupBox1.Location = new System.Drawing.Point(186, 20);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(360, 275);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Phòng";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonDkyCustomer);
            this.groupBox2.Controls.Add(this.buttonManagementCustomer);
            this.groupBox2.Location = new System.Drawing.Point(612, 20);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(296, 275);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Khách";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.PapayaWhip;
            this.button1.Location = new System.Drawing.Point(168, 28);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 203);
            this.button1.TabIndex = 8;
            this.button1.Text = "Danh sách thực phẩm";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnFoodManagement);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Location = new System.Drawing.Point(186, 313);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(360, 247);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thực phẩm";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnStaffCheck);
            this.groupBox4.Location = new System.Drawing.Point(612, 313);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Size = new System.Drawing.Size(296, 232);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Lao công";
            // 
            // btnStaffCheck
            // 
            this.btnStaffCheck.Location = new System.Drawing.Point(20, 37);
            this.btnStaffCheck.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnStaffCheck.Name = "btnStaffCheck";
            this.btnStaffCheck.Size = new System.Drawing.Size(130, 92);
            this.btnStaffCheck.TabIndex = 0;
            this.btnStaffCheck.Text = "Kiểm tra thực phẩm ";
            this.btnStaffCheck.UseVisualStyleBackColor = true;
            this.btnStaffCheck.Click += new System.EventHandler(this.btnStaffCheck_Click);
            // 
            // MainForm_TiepTan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 593);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonExit);
            this.Name = "MainForm_TiepTan";
            this.Text = "Tiếp tân";
            this.Load += new System.EventHandler(this.MainForm_TiepTan_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion  
        private System.Windows.Forms.Button btnFoodManagement;
        private System.Windows.Forms.Button buttonDkyCustomer;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonManagementCustomer;
        private System.Windows.Forms.Button buttonAddRoom;
        private System.Windows.Forms.Button btnManagementRoom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnStaffCheck;
    }
}