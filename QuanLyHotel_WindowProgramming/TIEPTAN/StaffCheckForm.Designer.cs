namespace QuanLyHotel_WindowProgramming.TIEPTAN
{
    partial class StaffCheckForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboBoxRoom;
        private System.Windows.Forms.ComboBox comboBoxFood;
        private System.Windows.Forms.DateTimePicker dateTimePickerUsage;
        private System.Windows.Forms.NumericUpDown numericQuantity;
        private System.Windows.Forms.Button btnAddQuantityIn;
        private System.Windows.Forms.Button btnAddQuantityOut;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelRoom;
        private System.Windows.Forms.Label labelFood;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelQuantity;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.comboBoxRoom = new System.Windows.Forms.ComboBox();
            this.comboBoxFood = new System.Windows.Forms.ComboBox();
            this.dateTimePickerUsage = new System.Windows.Forms.DateTimePicker();
            this.numericQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnAddQuantityIn = new System.Windows.Forms.Button();
            this.btnAddQuantityOut = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelRoom = new System.Windows.Forms.Label();
            this.labelFood = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelQuantity = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxRoom
            // 
            this.comboBoxRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRoom.Location = new System.Drawing.Point(150, 67);
            this.comboBoxRoom.Name = "comboBoxRoom";
            this.comboBoxRoom.Size = new System.Drawing.Size(200, 24);
            this.comboBoxRoom.TabIndex = 2;
            // 
            // comboBoxFood
            // 
            this.comboBoxFood.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFood.Location = new System.Drawing.Point(150, 107);
            this.comboBoxFood.Name = "comboBoxFood";
            this.comboBoxFood.Size = new System.Drawing.Size(200, 24);
            this.comboBoxFood.TabIndex = 4;
            // 
            // dateTimePickerUsage
            // 
            this.dateTimePickerUsage.Location = new System.Drawing.Point(150, 147);
            this.dateTimePickerUsage.Name = "dateTimePickerUsage";
            this.dateTimePickerUsage.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerUsage.TabIndex = 6;
            // 
            // numericQuantity
            // 
            this.numericQuantity.Location = new System.Drawing.Point(150, 187);
            this.numericQuantity.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericQuantity.Name = "numericQuantity";
            this.numericQuantity.Size = new System.Drawing.Size(120, 22);
            this.numericQuantity.TabIndex = 8;
            // 
            // btnAddQuantityIn
            // 
            this.btnAddQuantityIn.Location = new System.Drawing.Point(30, 230);
            this.btnAddQuantityIn.Name = "btnAddQuantityIn";
            this.btnAddQuantityIn.Size = new System.Drawing.Size(150, 35);
            this.btnAddQuantityIn.TabIndex = 9;
            this.btnAddQuantityIn.Text = "Thêm số lượng (In)";
            this.btnAddQuantityIn.Click += new System.EventHandler(this.btnAddQuantityIn_Click);
            // 
            // btnAddQuantityOut
            // 
            this.btnAddQuantityOut.Location = new System.Drawing.Point(200, 230);
            this.btnAddQuantityOut.Name = "btnAddQuantityOut";
            this.btnAddQuantityOut.Size = new System.Drawing.Size(180, 35);
            this.btnAddQuantityOut.TabIndex = 10;
            this.btnAddQuantityOut.Text = "Cập nhật tiêu thụ (Out)";
            this.btnAddQuantityOut.Click += new System.EventHandler(this.btnAddQuantityOut_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(20, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(478, 32);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Nhập / Kiểm tra thực phẩm trong phòng";
            // 
            // labelRoom
            // 
            this.labelRoom.AutoSize = true;
            this.labelRoom.Location = new System.Drawing.Point(30, 70);
            this.labelRoom.Name = "labelRoom";
            this.labelRoom.Size = new System.Drawing.Size(82, 16);
            this.labelRoom.TabIndex = 1;
            this.labelRoom.Text = "Chọn phòng:";
            // 
            // labelFood
            // 
            this.labelFood.AutoSize = true;
            this.labelFood.Location = new System.Drawing.Point(30, 110);
            this.labelFood.Name = "labelFood";
            this.labelFood.Size = new System.Drawing.Size(88, 16);
            this.labelFood.TabIndex = 3;
            this.labelFood.Text = "Chọn món ăn:";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(30, 150);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(74, 16);
            this.labelDate.TabIndex = 5;
            this.labelDate.Text = "Chọn ngày:";
            // 
            // labelQuantity
            // 
            this.labelQuantity.AutoSize = true;
            this.labelQuantity.Location = new System.Drawing.Point(30, 190);
            this.labelQuantity.Name = "labelQuantity";
            this.labelQuantity.Size = new System.Drawing.Size(63, 16);
            this.labelQuantity.TabIndex = 7;
            this.labelQuantity.Text = "Số lượng:";
            // 
            // StaffCheckForm
            // 
            this.ClientSize = new System.Drawing.Size(527, 302);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelRoom);
            this.Controls.Add(this.comboBoxRoom);
            this.Controls.Add(this.labelFood);
            this.Controls.Add(this.comboBoxFood);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.dateTimePickerUsage);
            this.Controls.Add(this.labelQuantity);
            this.Controls.Add(this.numericQuantity);
            this.Controls.Add(this.btnAddQuantityIn);
            this.Controls.Add(this.btnAddQuantityOut);
            this.Name = "StaffCheckForm";
            this.Text = "Lao công - Kiểm tra thực phẩm";
            ((System.ComponentModel.ISupportInitialize)(this.numericQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
