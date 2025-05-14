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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonDetailsCustomer = new System.Windows.Forms.Button();
            this.buttonCheckOut = new System.Windows.Forms.Button();
            this.buttonDkyCustomer = new System.Windows.Forms.Button();
            this.buttonAddRoom = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonDetailsCustomer);
            this.panel1.Controls.Add(this.buttonCheckOut);
            this.panel1.Controls.Add(this.buttonDkyCustomer);
            this.panel1.Controls.Add(this.buttonAddRoom);
            this.panel1.Location = new System.Drawing.Point(210, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(884, 387);
            this.panel1.TabIndex = 0;
            // 
            // buttonDetailsCustomer
            // 
            this.buttonDetailsCustomer.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.buttonDetailsCustomer.Location = new System.Drawing.Point(356, 196);
            this.buttonDetailsCustomer.Name = "buttonDetailsCustomer";
            this.buttonDetailsCustomer.Size = new System.Drawing.Size(232, 168);
            this.buttonDetailsCustomer.TabIndex = 3;
            this.buttonDetailsCustomer.Text = "Chi tiết Khách hàng";
            this.buttonDetailsCustomer.UseVisualStyleBackColor = true;
            // 
            // buttonCheckOut
            // 
            this.buttonCheckOut.Location = new System.Drawing.Point(30, 196);
            this.buttonCheckOut.Name = "buttonCheckOut";
            this.buttonCheckOut.Size = new System.Drawing.Size(236, 168);
            this.buttonCheckOut.TabIndex = 2;
            this.buttonCheckOut.Text = "Check Out";
            this.buttonCheckOut.UseVisualStyleBackColor = true;
            // 
            // buttonDkyCustomer
            // 
            this.buttonDkyCustomer.Location = new System.Drawing.Point(356, 14);
            this.buttonDkyCustomer.Name = "buttonDkyCustomer";
            this.buttonDkyCustomer.Size = new System.Drawing.Size(232, 156);
            this.buttonDkyCustomer.TabIndex = 1;
            this.buttonDkyCustomer.Text = "Đăng Ký Khách hàng";
            this.buttonDkyCustomer.UseVisualStyleBackColor = true;
            // 
            // buttonAddRoom
            // 
            this.buttonAddRoom.Location = new System.Drawing.Point(30, 14);
            this.buttonAddRoom.Name = "buttonAddRoom";
            this.buttonAddRoom.Size = new System.Drawing.Size(236, 156);
            this.buttonAddRoom.TabIndex = 0;
            this.buttonAddRoom.Text = "Add Room";
            this.buttonAddRoom.UseVisualStyleBackColor = true;
            this.buttonAddRoom.Click += new System.EventHandler(this.buttonAddRoom_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(12, 12);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(142, 50);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // MainForm_TiepTan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 508);
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
        private System.Windows.Forms.Button buttonCheckOut;
        private System.Windows.Forms.Button buttonDkyCustomer;
        private System.Windows.Forms.Button buttonAddRoom;
        private System.Windows.Forms.Button buttonExit;
    }
}