using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyHotel_WindowProgramming.TIEPTAN
{
    public partial class CustomerManagementForm : Form
    {
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label label9;
        private TextBox txtCheckCccd;
        private Button buttonSearch;
        private DataGridView dgvCustomers;
        private RadioButton radioCheckout;
        private RadioButton radiodango;
    

        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCheckCccd = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.radioCheckout = new System.Windows.Forms.RadioButton();
            this.radiodango = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.DateTimePickerCheckIn = new System.Windows.Forms.DateTimePicker();
            this.DateTimePickerCheckOut = new System.Windows.Forms.DateTimePicker();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.radioMale = new System.Windows.Forms.RadioButton();
            this.radioFemale = new System.Windows.Forms.RadioButton();
            this.radioOther = new System.Windows.Forms.RadioButton();
            this.txtTotalMoney = new System.Windows.Forms.TextBox();
            this.lbTongTien = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lbTienPhong = new System.Windows.Forms.Label();
            this.lbTienDoAn = new System.Windows.Forms.Label();
            this.txtMoneyRoom = new System.Windows.Forms.TextBox();
            this.txtMoneyFood = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxThanhToan = new System.Windows.Forms.CheckBox();
            this.DateOfbirth = new System.Windows.Forms.Label();
            this.DateTimePickerBirth = new System.Windows.Forms.DateTimePicker();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtCccd = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbGioiTinh = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbBed = new System.Windows.Forms.ComboBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtRoomNo = new System.Windows.Forms.TextBox();
            this.labelPrice = new System.Windows.Forms.Label();
            this.labelBed = new System.Windows.Forms.Label();
            this.labelTypeRoom = new System.Windows.Forms.Label();
            this.labelRoomNumber = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtCheckCccd);
            this.groupBox2.Controls.Add(this.buttonSearch);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(980, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(682, 188);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm kiếm Khách";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 20);
            this.label9.TabIndex = 2;
            this.label9.Text = "CCCD";
            // 
            // txtCheckCccd
            // 
            this.txtCheckCccd.Location = new System.Drawing.Point(23, 86);
            this.txtCheckCccd.Name = "txtCheckCccd";
            this.txtCheckCccd.Size = new System.Drawing.Size(304, 26);
            this.txtCheckCccd.TabIndex = 1;
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.MediumPurple;
            this.buttonSearch.ForeColor = System.Drawing.Color.Black;
            this.buttonSearch.Location = new System.Drawing.Point(333, 86);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(106, 30);
            this.buttonSearch.TabIndex = 0;
            this.buttonSearch.Text = "tìm kiếm";
            this.buttonSearch.UseVisualStyleBackColor = false;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.dgvCustomers);
            this.groupBox3.Controls.Add(this.radioCheckout);
            this.groupBox3.Controls.Add(this.radiodango);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(833, 321);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(856, 337);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách khách hàng";
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.BackgroundColor = System.Drawing.Color.LightSkyBlue;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvCustomers.Location = new System.Drawing.Point(23, 79);
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.RowHeadersWidth = 51;
            this.dgvCustomers.RowTemplate.Height = 24;
            this.dgvCustomers.Size = new System.Drawing.Size(802, 233);
            this.dgvCustomers.TabIndex = 2;
            this.dgvCustomers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomers_CellClick);
            // 
            // radioCheckout
            // 
            this.radioCheckout.AutoSize = true;
            this.radioCheckout.Location = new System.Drawing.Point(245, 31);
            this.radioCheckout.Name = "radioCheckout";
            this.radioCheckout.Size = new System.Drawing.Size(128, 24);
            this.radioCheckout.TabIndex = 1;
            this.radioCheckout.TabStop = true;
            this.radioCheckout.Text = "Đã checkout";
            this.radioCheckout.UseVisualStyleBackColor = true;
            // 
            // radiodango
            // 
            this.radiodango.AutoSize = true;
            this.radiodango.Location = new System.Drawing.Point(37, 31);
            this.radiodango.Name = "radiodango";
            this.radiodango.Size = new System.Drawing.Size(85, 24);
            this.radiodango.TabIndex = 0;
            this.radiodango.TabStop = true;
            this.radiodango.Text = "Đang ở";
            this.radiodango.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(432, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 26);
            this.label6.TabIndex = 8;
            this.label6.Text = "Check in:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(432, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 26);
            this.label7.TabIndex = 9;
            this.label7.Text = "Check out:";
            // 
            // DateTimePickerCheckIn
            // 
            this.DateTimePickerCheckIn.Location = new System.Drawing.Point(437, 67);
            this.DateTimePickerCheckIn.Name = "DateTimePickerCheckIn";
            this.DateTimePickerCheckIn.Size = new System.Drawing.Size(394, 32);
            this.DateTimePickerCheckIn.TabIndex = 12;
            // 
            // DateTimePickerCheckOut
            // 
            this.DateTimePickerCheckOut.Location = new System.Drawing.Point(437, 138);
            this.DateTimePickerCheckOut.Name = "DateTimePickerCheckOut";
            this.DateTimePickerCheckOut.Size = new System.Drawing.Size(394, 32);
            this.DateTimePickerCheckOut.TabIndex = 13;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.BackColor = System.Drawing.Color.Linen;
            this.buttonUpdate.ForeColor = System.Drawing.Color.Black;
            this.buttonUpdate.Location = new System.Drawing.Point(24, 212);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(167, 70);
            this.buttonUpdate.TabIndex = 16;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = false;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.Red;
            this.buttonDelete.ForeColor = System.Drawing.Color.Black;
            this.buttonDelete.Location = new System.Drawing.Point(197, 211);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(145, 72);
            this.buttonDelete.TabIndex = 17;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // radioMale
            // 
            this.radioMale.AutoSize = true;
            this.radioMale.Location = new System.Drawing.Point(128, 252);
            this.radioMale.Name = "radioMale";
            this.radioMale.Size = new System.Drawing.Size(80, 30);
            this.radioMale.TabIndex = 20;
            this.radioMale.TabStop = true;
            this.radioMale.Text = "Nam";
            this.radioMale.UseVisualStyleBackColor = true;
            // 
            // radioFemale
            // 
            this.radioFemale.AutoSize = true;
            this.radioFemale.Location = new System.Drawing.Point(224, 252);
            this.radioFemale.Name = "radioFemale";
            this.radioFemale.Size = new System.Drawing.Size(60, 30);
            this.radioFemale.TabIndex = 21;
            this.radioFemale.TabStop = true;
            this.radioFemale.Text = "Nữ";
            this.radioFemale.UseVisualStyleBackColor = true;
            // 
            // radioOther
            // 
            this.radioOther.AutoSize = true;
            this.radioOther.Location = new System.Drawing.Point(290, 252);
            this.radioOther.Name = "radioOther";
            this.radioOther.Size = new System.Drawing.Size(84, 30);
            this.radioOther.TabIndex = 22;
            this.radioOther.TabStop = true;
            this.radioOther.Text = "Khác";
            this.radioOther.UseVisualStyleBackColor = true;
            // 
            // txtTotalMoney
            // 
            this.txtTotalMoney.Location = new System.Drawing.Point(237, 104);
            this.txtTotalMoney.Name = "txtTotalMoney";
            this.txtTotalMoney.Size = new System.Drawing.Size(235, 26);
            this.txtTotalMoney.TabIndex = 2;
            // 
            // lbTongTien
            // 
            this.lbTongTien.AutoSize = true;
            this.lbTongTien.Location = new System.Drawing.Point(21, 107);
            this.lbTongTien.Name = "lbTongTien";
            this.lbTongTien.Size = new System.Drawing.Size(202, 20);
            this.lbTongTien.TabIndex = 27;
            this.lbTongTien.Text = "Số tiền cần thanh toán: ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(478, 110);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(106, 20);
            this.label14.TabIndex = 28;
            this.label14.Text = "Đơn vị: VNĐ";
            // 
            // lbTienPhong
            // 
            this.lbTienPhong.AutoSize = true;
            this.lbTienPhong.Location = new System.Drawing.Point(24, 37);
            this.lbTienPhong.Name = "lbTienPhong";
            this.lbTienPhong.Size = new System.Drawing.Size(104, 20);
            this.lbTienPhong.TabIndex = 29;
            this.lbTienPhong.Text = "Tiền Phòng:";
            // 
            // lbTienDoAn
            // 
            this.lbTienDoAn.AutoSize = true;
            this.lbTienDoAn.Location = new System.Drawing.Point(21, 69);
            this.lbTienDoAn.Name = "lbTienDoAn";
            this.lbTienDoAn.Size = new System.Drawing.Size(98, 20);
            this.lbTienDoAn.TabIndex = 30;
            this.lbTienDoAn.Text = "Tiền đồ ăn:";
            // 
            // txtMoneyRoom
            // 
            this.txtMoneyRoom.Location = new System.Drawing.Point(237, 37);
            this.txtMoneyRoom.Name = "txtMoneyRoom";
            this.txtMoneyRoom.Size = new System.Drawing.Size(235, 26);
            this.txtMoneyRoom.TabIndex = 31;
            // 
            // txtMoneyFood
            // 
            this.txtMoneyFood.Location = new System.Drawing.Point(237, 72);
            this.txtMoneyFood.Name = "txtMoneyFood";
            this.txtMoneyFood.Size = new System.Drawing.Size(235, 26);
            this.txtMoneyFood.TabIndex = 32;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.checkBoxThanhToan);
            this.groupBox1.Controls.Add(this.txtMoneyFood);
            this.groupBox1.Controls.Add(this.txtMoneyRoom);
            this.groupBox1.Controls.Add(this.lbTienDoAn);
            this.groupBox1.Controls.Add(this.lbTienPhong);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.lbTongTien);
            this.groupBox1.Controls.Add(this.txtTotalMoney);
            this.groupBox1.Controls.Add(this.buttonDelete);
            this.groupBox1.Controls.Add(this.buttonUpdate);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(21, 514);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(751, 298);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập thông tin khách";
            // 
            // checkBoxThanhToan
            // 
            this.checkBoxThanhToan.AutoSize = true;
            this.checkBoxThanhToan.Location = new System.Drawing.Point(237, 152);
            this.checkBoxThanhToan.Name = "checkBoxThanhToan";
            this.checkBoxThanhToan.Size = new System.Drawing.Size(263, 24);
            this.checkBoxThanhToan.TabIndex = 2;
            this.checkBoxThanhToan.Text = "Đã Thanh Toán và Check Out";
            this.checkBoxThanhToan.UseVisualStyleBackColor = true;
            // 
            // DateOfbirth
            // 
            this.DateOfbirth.AutoSize = true;
            this.DateOfbirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateOfbirth.ForeColor = System.Drawing.Color.Red;
            this.DateOfbirth.Location = new System.Drawing.Point(24, 172);
            this.DateOfbirth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DateOfbirth.Name = "DateOfbirth";
            this.DateOfbirth.Size = new System.Drawing.Size(87, 20);
            this.DateOfbirth.TabIndex = 46;
            this.DateOfbirth.Text = "Ngày sinh";
            // 
            // DateTimePickerBirth
            // 
            this.DateTimePickerBirth.Location = new System.Drawing.Point(27, 204);
            this.DateTimePickerBirth.Margin = new System.Windows.Forms.Padding(2);
            this.DateTimePickerBirth.Name = "DateTimePickerBirth";
            this.DateTimePickerBirth.Size = new System.Drawing.Size(347, 32);
            this.DateTimePickerBirth.TabIndex = 45;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(223, 138);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(2);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(151, 32);
            this.txtAddress.TabIndex = 43;
            // 
            // txtCccd
            // 
            this.txtCccd.Location = new System.Drawing.Point(223, 69);
            this.txtCccd.Margin = new System.Windows.Forms.Padding(2);
            this.txtCccd.Name = "txtCccd";
            this.txtCccd.Size = new System.Drawing.Size(151, 32);
            this.txtCccd.TabIndex = 42;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(26, 138);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(2);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(151, 32);
            this.txtPhone.TabIndex = 41;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(26, 69);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(151, 32);
            this.txtName.TabIndex = 40;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(220, 116);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 20);
            this.label8.TabIndex = 39;
            this.label8.Text = "Địa chỉ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(219, 37);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 20);
            this.label11.TabIndex = 38;
            this.label11.Text = "Cccd/Cmnd";
            // 
            // lbGioiTinh
            // 
            this.lbGioiTinh.AutoSize = true;
            this.lbGioiTinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGioiTinh.ForeColor = System.Drawing.Color.Red;
            this.lbGioiTinh.Location = new System.Drawing.Point(22, 252);
            this.lbGioiTinh.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbGioiTinh.Name = "lbGioiTinh";
            this.lbGioiTinh.Size = new System.Drawing.Size(81, 20);
            this.lbGioiTinh.TabIndex = 37;
            this.lbGioiTinh.Text = "Giới tính:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(24, 116);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(115, 20);
            this.label15.TabIndex = 35;
            this.label15.Text = "Số điện thoại";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(23, 37);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(86, 20);
            this.label16.TabIndex = 34;
            this.label16.Text = "Họ và tên";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.radioMale);
            this.groupBox4.Controls.Add(this.radioFemale);
            this.groupBox4.Controls.Add(this.lbGioiTinh);
            this.groupBox4.Controls.Add(this.DateTimePickerBirth);
            this.groupBox4.Controls.Add(this.DateOfbirth);
            this.groupBox4.Controls.Add(this.radioOther);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.DateTimePickerCheckIn);
            this.groupBox4.Controls.Add(this.txtAddress);
            this.groupBox4.Controls.Add(this.DateTimePickerCheckOut);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.txtPhone);
            this.groupBox4.Controls.Add(this.txtCccd);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.txtName);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.Red;
            this.groupBox4.Location = new System.Drawing.Point(21, 12);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(902, 296);
            this.groupBox4.TabIndex = 48;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Thông tin khách hàng";
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.cbBed);
            this.groupBox5.Controls.Add(this.cbType);
            this.groupBox5.Controls.Add(this.txtPrice);
            this.groupBox5.Controls.Add(this.txtRoomNo);
            this.groupBox5.Controls.Add(this.labelPrice);
            this.groupBox5.Controls.Add(this.labelBed);
            this.groupBox5.Controls.Add(this.labelTypeRoom);
            this.groupBox5.Controls.Add(this.labelRoomNumber);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.ForeColor = System.Drawing.Color.Red;
            this.groupBox5.Location = new System.Drawing.Point(21, 321);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(751, 188);
            this.groupBox5.TabIndex = 49;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Thông tin phòng";
            // 
            // cbBed
            // 
            this.cbBed.FormattingEnabled = true;
            this.cbBed.Location = new System.Drawing.Point(290, 74);
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
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(290, 142);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(2);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(173, 32);
            this.txtPrice.TabIndex = 15;
            // 
            // txtRoomNo
            // 
            this.txtRoomNo.Location = new System.Drawing.Point(25, 74);
            this.txtRoomNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtRoomNo.Name = "txtRoomNo";
            this.txtRoomNo.Size = new System.Drawing.Size(175, 32);
            this.txtRoomNo.TabIndex = 14;
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(286, 112);
            this.labelPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(49, 26);
            this.labelPrice.TabIndex = 13;
            this.labelPrice.Text = "Giá";
            // 
            // labelBed
            // 
            this.labelBed.AutoSize = true;
            this.labelBed.Location = new System.Drawing.Point(286, 37);
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
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(348, 211);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(152, 72);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // CustomerManagementForm
            // 
            this.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.ClientSize = new System.Drawing.Size(1780, 839);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "CustomerManagementForm";
            this.Text = "Quản lý khách";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }
        private Label label6;
        private Label label7;
        private DateTimePicker DateTimePickerCheckIn;
        private DateTimePicker DateTimePickerCheckOut;
        private Button buttonUpdate;
        private Button buttonDelete;
        private RadioButton radioMale;
        private RadioButton radioFemale;
        private RadioButton radioOther;
        private TextBox txtTotalMoney;
        private Label lbTongTien;
        private Label label14;
        private Label lbTienPhong;
        private Label lbTienDoAn;
        private TextBox txtMoneyRoom;
        private TextBox txtMoneyFood;
        private GroupBox groupBox1;
        private CheckBox checkBoxThanhToan;
        private Label DateOfbirth;
        private DateTimePicker DateTimePickerBirth;
        private TextBox txtAddress;
        private TextBox txtCccd;
        private TextBox txtPhone;
        private TextBox txtName;
        private Label label8;
        private Label label11;
        private Label lbGioiTinh;
        private Label label15;
        private Label label16;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private ComboBox cbBed;
        private ComboBox cbType;
        private TextBox txtPrice;
        private TextBox txtRoomNo;
        private Label labelPrice;
        private Label labelBed;
        private Label labelTypeRoom;
        private Label labelRoomNumber;
        private Button btnRefresh;
    }
}