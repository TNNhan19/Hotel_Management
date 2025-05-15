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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm_TiepTan));
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonManagementCustomer = new System.Windows.Forms.Button();
            this.btnManagementRoom = new System.Windows.Forms.Button();
            this.buttonDetailsCustomer = new System.Windows.Forms.Button();
            this.btnFoodManagement = new System.Windows.Forms.Button();
            this.buttonDkyCustomer = new System.Windows.Forms.Button();
            this.buttonAddRoom = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.buttonManagementCustomer);
            this.panel1.Controls.Add(this.btnManagementRoom);
            this.panel1.Controls.Add(this.buttonDetailsCustomer);
            this.panel1.Controls.Add(this.btnFoodManagement);
            this.panel1.Controls.Add(this.buttonDkyCustomer);
            this.panel1.Controls.Add(this.buttonAddRoom);
            this.panel1.Location = new System.Drawing.Point(193, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(861, 496);
            this.panel1.TabIndex = 0;
            // 
            // buttonManagementCustomer
            // 
            this.buttonManagementCustomer.Location = new System.Drawing.Point(572, 352);
            this.buttonManagementCustomer.Name = "buttonManagementCustomer";
            this.buttonManagementCustomer.Size = new System.Drawing.Size(260, 132);
            this.buttonManagementCustomer.TabIndex = 5;
            this.buttonManagementCustomer.Text = "Management Customer";
            this.buttonManagementCustomer.UseVisualStyleBackColor = true;
            this.buttonManagementCustomer.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnManagementRoom
            // 
            this.btnManagementRoom.BackColor = System.Drawing.Color.Aqua;
            this.btnManagementRoom.Location = new System.Drawing.Point(291, 72);
            this.btnManagementRoom.Name = "btnManagementRoom";
            this.btnManagementRoom.Size = new System.Drawing.Size(262, 257);
            this.btnManagementRoom.TabIndex = 4;
            this.btnManagementRoom.Text = "Management Room";
            this.btnManagementRoom.UseVisualStyleBackColor = false;
            this.btnManagementRoom.Click += new System.EventHandler(this.btnManagementRoom_Click);
            // 
            // buttonDetailsCustomer
            // 
            this.buttonDetailsCustomer.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonDetailsCustomer.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.buttonDetailsCustomer.Location = new System.Drawing.Point(291, 352);
            this.buttonDetailsCustomer.Name = "buttonDetailsCustomer";
            this.buttonDetailsCustomer.Size = new System.Drawing.Size(269, 132);
            this.buttonDetailsCustomer.TabIndex = 3;
            this.buttonDetailsCustomer.Text = "Chi tiết Khách hàng";
            this.buttonDetailsCustomer.UseVisualStyleBackColor = false;
            this.buttonDetailsCustomer.Click += new System.EventHandler(this.buttonDetailsCustomer_Click);
            // 
            // btnFoodManagement
            // 
            this.btnFoodManagement.BackColor = System.Drawing.Color.PowderBlue;
            this.btnFoodManagement.Location = new System.Drawing.Point(0, 352);
            this.btnFoodManagement.Name = "btnFoodManagement";
            this.btnFoodManagement.Size = new System.Drawing.Size(274, 132);
            this.btnFoodManagement.TabIndex = 2;
            this.btnFoodManagement.Text = "Food Management";
            this.btnFoodManagement.UseVisualStyleBackColor = false;
            this.btnFoodManagement.Click += new System.EventHandler(this.btnFoodManagement_Click);
            // 
            // buttonDkyCustomer
            // 
            this.buttonDkyCustomer.BackColor = System.Drawing.Color.PeachPuff;
            this.buttonDkyCustomer.Location = new System.Drawing.Point(572, 72);
            this.buttonDkyCustomer.Name = "buttonDkyCustomer";
            this.buttonDkyCustomer.Size = new System.Drawing.Size(260, 257);
            this.buttonDkyCustomer.TabIndex = 1;
            this.buttonDkyCustomer.Text = "Đăng Ký Khách hàng";
            this.buttonDkyCustomer.UseVisualStyleBackColor = false;
            this.buttonDkyCustomer.Click += new System.EventHandler(this.buttonDkyCustomer_Click);
            // 
            // buttonAddRoom
            // 
            this.buttonAddRoom.BackColor = System.Drawing.Color.Aquamarine;
            this.buttonAddRoom.Location = new System.Drawing.Point(12, 72);
            this.buttonAddRoom.Name = "buttonAddRoom";
            this.buttonAddRoom.Size = new System.Drawing.Size(262, 257);
            this.buttonAddRoom.TabIndex = 0;
            this.buttonAddRoom.Text = "Add Room";
            this.buttonAddRoom.UseVisualStyleBackColor = false;
            this.buttonAddRoom.Click += new System.EventHandler(this.buttonAddRoom_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.IndianRed;
            this.buttonExit.Location = new System.Drawing.Point(12, 12);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(166, 86);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // MainForm_TiepTan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1075, 546);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm_TiepTan";
            this.Text = "Tiếp tân";
            this.Load += new System.EventHandler(this.MainForm_TiepTan_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion  

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonDetailsCustomer;
        private System.Windows.Forms.Button btnFoodManagement;
        private System.Windows.Forms.Button buttonDkyCustomer;
        private System.Windows.Forms.Button buttonAddRoom;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button btnManagementRoom;
        private System.Windows.Forms.Button buttonManagementCustomer;
    }
}