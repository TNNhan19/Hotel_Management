namespace QuanLyHotel_WindowProgramming.TIEPTAN
{
    partial class CustomerRegistration
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtCccd = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.DateTimePickerBirth = new System.Windows.Forms.DateTimePicker();
            this.DateTimePickerCheckIn = new System.Windows.Forms.DateTimePicker();
            this.btnAlloteRoom = new System.Windows.Forms.Button();
            this.DateOfbirth = new System.Windows.Forms.Label();
            this.labelCheckOut = new System.Windows.Forms.Label();
            this.DateTimePickerCheckOut = new System.Windows.Forms.DateTimePicker();
            this.labelStayed = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioMale = new System.Windows.Forms.RadioButton();
            this.radioFemale = new System.Windows.Forms.RadioButton();
            this.radioOther = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtTotalDays = new System.Windows.Forms.TextBox();
            this.labelTotalPrice = new System.Windows.Forms.Label();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.dgvRoom = new System.Windows.Forms.DataGridView();
            this.roomBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hotelManagementDataSet6 = new QuanLyHotel_WindowProgramming.HotelManagementDataSet6();
            this.roomTableAdapter = new QuanLyHotel_WindowProgramming.HotelManagementDataSet6TableAdapters.RoomTableAdapter();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbRoomID = new System.Windows.Forms.ComboBox();
            this.cbBed = new System.Windows.Forms.ComboBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.txtPriceRoom = new System.Windows.Forms.TextBox();
            this.labelPrice = new System.Windows.Forms.Label();
            this.labelBed = new System.Windows.Forms.Label();
            this.labelTypeRoom = new System.Windows.Forms.Label();
            this.labelRoomNumber = new System.Windows.Forms.Label();
            this.btnTinhTien = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelManagementDataSet6)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 44);
            this.label1.TabIndex = 1;
            this.label1.Text = "Khách hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(42, 138);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Họ và tên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(42, 212);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Số điện thoại";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(42, 362);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Giới tính";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(238, 138);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Cccd/Cmnd";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(238, 212);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 20);
            this.label7.TabIndex = 7;
            this.label7.Text = "Địa chỉ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(11, 44);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 20);
            this.label8.TabIndex = 8;
            this.label8.Text = "Check in";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(44, 173);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(151, 20);
            this.txtName.TabIndex = 13;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(44, 243);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(2);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(151, 20);
            this.txtPhone.TabIndex = 14;
            // 
            // txtCccd
            // 
            this.txtCccd.Location = new System.Drawing.Point(241, 173);
            this.txtCccd.Margin = new System.Windows.Forms.Padding(2);
            this.txtCccd.Name = "txtCccd";
            this.txtCccd.Size = new System.Drawing.Size(151, 20);
            this.txtCccd.TabIndex = 16;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(241, 243);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(2);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(151, 20);
            this.txtAddress.TabIndex = 17;
            // 
            // DateTimePickerBirth
            // 
            this.DateTimePickerBirth.Location = new System.Drawing.Point(27, 253);
            this.DateTimePickerBirth.Margin = new System.Windows.Forms.Padding(2);
            this.DateTimePickerBirth.Name = "DateTimePickerBirth";
            this.DateTimePickerBirth.Size = new System.Drawing.Size(346, 32);
            this.DateTimePickerBirth.TabIndex = 23;
            // 
            // DateTimePickerCheckIn
            // 
            this.DateTimePickerCheckIn.CalendarMonthBackground = System.Drawing.Color.Aquamarine;
            this.DateTimePickerCheckIn.CalendarTitleBackColor = System.Drawing.Color.IndianRed;
            this.DateTimePickerCheckIn.Location = new System.Drawing.Point(126, 44);
            this.DateTimePickerCheckIn.Margin = new System.Windows.Forms.Padding(2);
            this.DateTimePickerCheckIn.Name = "DateTimePickerCheckIn";
            this.DateTimePickerCheckIn.Size = new System.Drawing.Size(413, 32);
            this.DateTimePickerCheckIn.TabIndex = 24;
            // 
            // btnAlloteRoom
            // 
            this.btnAlloteRoom.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.btnAlloteRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlloteRoom.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAlloteRoom.Location = new System.Drawing.Point(118, 427);
            this.btnAlloteRoom.Margin = new System.Windows.Forms.Padding(2);
            this.btnAlloteRoom.Name = "btnAlloteRoom";
            this.btnAlloteRoom.Size = new System.Drawing.Size(170, 70);
            this.btnAlloteRoom.TabIndex = 25;
            this.btnAlloteRoom.Text = "Đặt phòng";
            this.btnAlloteRoom.UseVisualStyleBackColor = false;
            this.btnAlloteRoom.Click += new System.EventHandler(this.btnAlloteRoom_Click);
            // 
            // DateOfbirth
            // 
            this.DateOfbirth.AutoSize = true;
            this.DateOfbirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateOfbirth.ForeColor = System.Drawing.Color.Red;
            this.DateOfbirth.Location = new System.Drawing.Point(23, 214);
            this.DateOfbirth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DateOfbirth.Name = "DateOfbirth";
            this.DateOfbirth.Size = new System.Drawing.Size(87, 20);
            this.DateOfbirth.TabIndex = 26;
            this.DateOfbirth.Text = "Ngày sinh";
            // 
            // labelCheckOut
            // 
            this.labelCheckOut.AutoSize = true;
            this.labelCheckOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCheckOut.ForeColor = System.Drawing.Color.Red;
            this.labelCheckOut.Location = new System.Drawing.Point(11, 96);
            this.labelCheckOut.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCheckOut.Name = "labelCheckOut";
            this.labelCheckOut.Size = new System.Drawing.Size(90, 20);
            this.labelCheckOut.TabIndex = 28;
            this.labelCheckOut.Text = "Check out";
            // 
            // DateTimePickerCheckOut
            // 
            this.DateTimePickerCheckOut.CalendarMonthBackground = System.Drawing.Color.Aquamarine;
            this.DateTimePickerCheckOut.CalendarTitleBackColor = System.Drawing.Color.IndianRed;
            this.DateTimePickerCheckOut.Location = new System.Drawing.Point(126, 94);
            this.DateTimePickerCheckOut.Margin = new System.Windows.Forms.Padding(2);
            this.DateTimePickerCheckOut.Name = "DateTimePickerCheckOut";
            this.DateTimePickerCheckOut.Size = new System.Drawing.Size(413, 32);
            this.DateTimePickerCheckOut.TabIndex = 29;
            // 
            // labelStayed
            // 
            this.labelStayed.AutoSize = true;
            this.labelStayed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStayed.ForeColor = System.Drawing.Color.Red;
            this.labelStayed.Location = new System.Drawing.Point(11, 145);
            this.labelStayed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStayed.Name = "labelStayed";
            this.labelStayed.Size = new System.Drawing.Size(107, 20);
            this.labelStayed.TabIndex = 31;
            this.labelStayed.Text = "Tổng ngày ở";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.radioMale);
            this.groupBox1.Controls.Add(this.radioFemale);
            this.groupBox1.Controls.Add(this.DateOfbirth);
            this.groupBox1.Controls.Add(this.DateTimePickerBirth);
            this.groupBox1.Controls.Add(this.radioOther);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(19, 66);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(396, 353);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin khách hàng";
            // 
            // radioMale
            // 
            this.radioMale.AutoSize = true;
            this.radioMale.Location = new System.Drawing.Point(23, 309);
            this.radioMale.Name = "radioMale";
            this.radioMale.Size = new System.Drawing.Size(80, 30);
            this.radioMale.TabIndex = 23;
            this.radioMale.TabStop = true;
            this.radioMale.Text = "Nam";
            this.radioMale.UseVisualStyleBackColor = true;
            // 
            // radioFemale
            // 
            this.radioFemale.AutoSize = true;
            this.radioFemale.Location = new System.Drawing.Point(119, 309);
            this.radioFemale.Name = "radioFemale";
            this.radioFemale.Size = new System.Drawing.Size(60, 30);
            this.radioFemale.TabIndex = 24;
            this.radioFemale.TabStop = true;
            this.radioFemale.Text = "Nữ";
            this.radioFemale.UseVisualStyleBackColor = true;
            // 
            // radioOther
            // 
            this.radioOther.AutoSize = true;
            this.radioOther.Location = new System.Drawing.Point(185, 309);
            this.radioOther.Name = "radioOther";
            this.radioOther.Size = new System.Drawing.Size(84, 30);
            this.radioOther.TabIndex = 25;
            this.radioOther.TabStop = true;
            this.radioOther.Text = "Khác";
            this.radioOther.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.btnTinhTien);
            this.groupBox3.Controls.Add(this.txtTotalDays);
            this.groupBox3.Controls.Add(this.labelStayed);
            this.groupBox3.Controls.Add(this.DateTimePickerCheckOut);
            this.groupBox3.Controls.Add(this.labelCheckOut);
            this.groupBox3.Controls.Add(this.DateTimePickerCheckIn);
            this.groupBox3.Controls.Add(this.labelTotalPrice);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtTotalPrice);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Red;
            this.groupBox3.Location = new System.Drawing.Point(833, 303);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(645, 237);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thành tiền";
            // 
            // txtTotalDays
            // 
            this.txtTotalDays.Location = new System.Drawing.Point(126, 135);
            this.txtTotalDays.Margin = new System.Windows.Forms.Padding(2);
            this.txtTotalDays.Name = "txtTotalDays";
            this.txtTotalDays.Size = new System.Drawing.Size(162, 32);
            this.txtTotalDays.TabIndex = 32;
            // 
            // labelTotalPrice
            // 
            this.labelTotalPrice.AutoSize = true;
            this.labelTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalPrice.ForeColor = System.Drawing.Color.Red;
            this.labelTotalPrice.Location = new System.Drawing.Point(11, 188);
            this.labelTotalPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTotalPrice.Name = "labelTotalPrice";
            this.labelTotalPrice.Size = new System.Drawing.Size(78, 20);
            this.labelTotalPrice.TabIndex = 12;
            this.labelTotalPrice.Text = "Tổng giá";
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Location = new System.Drawing.Point(126, 186);
            this.txtTotalPrice.Margin = new System.Windows.Forms.Padding(2);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.Size = new System.Drawing.Size(162, 32);
            this.txtTotalPrice.TabIndex = 30;
            // 
            // dgvRoom
            // 
            this.dgvRoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoom.Location = new System.Drawing.Point(833, 29);
            this.dgvRoom.Name = "dgvRoom";
            this.dgvRoom.Size = new System.Drawing.Size(645, 258);
            this.dgvRoom.TabIndex = 36;
            // 
            // roomBindingSource
            // 
            this.roomBindingSource.DataMember = "Room";
            this.roomBindingSource.DataSource = this.hotelManagementDataSet6;
            // 
            // hotelManagementDataSet6
            // 
            this.hotelManagementDataSet6.DataSetName = "HotelManagementDataSet6";
            this.hotelManagementDataSet6.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // roomTableAdapter
            // 
            this.roomTableAdapter.ClearBeforeFill = true;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.cbRoomID);
            this.groupBox5.Controls.Add(this.cbBed);
            this.groupBox5.Controls.Add(this.cbType);
            this.groupBox5.Controls.Add(this.txtPriceRoom);
            this.groupBox5.Controls.Add(this.labelPrice);
            this.groupBox5.Controls.Add(this.labelBed);
            this.groupBox5.Controls.Add(this.labelTypeRoom);
            this.groupBox5.Controls.Add(this.labelRoomNumber);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.ForeColor = System.Drawing.Color.Red;
            this.groupBox5.Location = new System.Drawing.Point(430, 66);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(378, 353);
            this.groupBox5.TabIndex = 50;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Thông tin phòng";
            // 
            // cbRoomID
            // 
            this.cbRoomID.FormattingEnabled = true;
            this.cbRoomID.Location = new System.Drawing.Point(24, 75);
            this.cbRoomID.Name = "cbRoomID";
            this.cbRoomID.Size = new System.Drawing.Size(175, 34);
            this.cbRoomID.TabIndex = 18;
            this.cbRoomID.SelectedIndexChanged += new System.EventHandler(this.cbRoomID_SelectedIndexChanged);
            // 
            // cbBed
            // 
            this.cbBed.FormattingEnabled = true;
            this.cbBed.Location = new System.Drawing.Point(24, 214);
            this.cbBed.Margin = new System.Windows.Forms.Padding(2);
            this.cbBed.Name = "cbBed";
            this.cbBed.Size = new System.Drawing.Size(175, 34);
            this.cbBed.TabIndex = 17;
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(24, 140);
            this.cbType.Margin = new System.Windows.Forms.Padding(2);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(175, 34);
            this.cbType.TabIndex = 16;
            // 
            // txtPriceRoom
            // 
            this.txtPriceRoom.Location = new System.Drawing.Point(24, 296);
            this.txtPriceRoom.Margin = new System.Windows.Forms.Padding(2);
            this.txtPriceRoom.Name = "txtPriceRoom";
            this.txtPriceRoom.Size = new System.Drawing.Size(173, 32);
            this.txtPriceRoom.TabIndex = 15;
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(22, 253);
            this.labelPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(49, 26);
            this.labelPrice.TabIndex = 13;
            this.labelPrice.Text = "Giá";
            // 
            // labelBed
            // 
            this.labelBed.AutoSize = true;
            this.labelBed.Location = new System.Drawing.Point(22, 178);
            this.labelBed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelBed.Name = "labelBed";
            this.labelBed.Size = new System.Drawing.Size(88, 26);
            this.labelBed.TabIndex = 12;
            this.labelBed.Text = "Giường";
            // 
            // labelTypeRoom
            // 
            this.labelTypeRoom.AutoSize = true;
            this.labelTypeRoom.Location = new System.Drawing.Point(22, 112);
            this.labelTypeRoom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTypeRoom.Name = "labelTypeRoom";
            this.labelTypeRoom.Size = new System.Drawing.Size(132, 26);
            this.labelTypeRoom.TabIndex = 11;
            this.labelTypeRoom.Text = "Loại Phòng";
            // 
            // labelRoomNumber
            // 
            this.labelRoomNumber.AutoSize = true;
            this.labelRoomNumber.Location = new System.Drawing.Point(21, 37);
            this.labelRoomNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRoomNumber.Name = "labelRoomNumber";
            this.labelRoomNumber.Size = new System.Drawing.Size(113, 26);
            this.labelRoomNumber.TabIndex = 10;
            this.labelRoomNumber.Text = "Số phòng";
            // 
            // btnTinhTien
            // 
            this.btnTinhTien.Location = new System.Drawing.Point(336, 185);
            this.btnTinhTien.Name = "btnTinhTien";
            this.btnTinhTien.Size = new System.Drawing.Size(163, 33);
            this.btnTinhTien.TabIndex = 33;
            this.btnTinhTien.Text = "Tính Giá";
            this.btnTinhTien.UseVisualStyleBackColor = true;
            this.btnTinhTien.Click += new System.EventHandler(this.btnTinhTien_Click);
            // 
            // CustomerRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1777, 704);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.dgvRoom);
            this.Controls.Add(this.btnAlloteRoom);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtCccd);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.ForeColor = System.Drawing.Color.Red;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CustomerRegistration";
            this.Text = "CustomerRegistration";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelManagementDataSet6)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtCccd;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.DateTimePicker DateTimePickerBirth;
        private System.Windows.Forms.DateTimePicker DateTimePickerCheckIn;
        private System.Windows.Forms.Button btnAlloteRoom;
        private System.Windows.Forms.Label DateOfbirth;
        private System.Windows.Forms.Label labelCheckOut;
        private System.Windows.Forms.DateTimePicker DateTimePickerCheckOut;
        private System.Windows.Forms.Label labelStayed;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvRoom;
        private HotelManagementDataSet6 hotelManagementDataSet6;
        private System.Windows.Forms.BindingSource roomBindingSource;
        private HotelManagementDataSet6TableAdapters.RoomTableAdapter roomTableAdapter;
        private System.Windows.Forms.TextBox txtTotalDays;
        private System.Windows.Forms.Label labelTotalPrice;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.RadioButton radioMale;
        private System.Windows.Forms.RadioButton radioFemale;
        private System.Windows.Forms.RadioButton radioOther;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cbBed;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.TextBox txtPriceRoom;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label labelBed;
        private System.Windows.Forms.Label labelTypeRoom;
        private System.Windows.Forms.Label labelRoomNumber;
        private System.Windows.Forms.ComboBox cbRoomID;
        private System.Windows.Forms.Button btnTinhTien;
    }
}