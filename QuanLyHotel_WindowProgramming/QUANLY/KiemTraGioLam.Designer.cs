namespace QuanLyHotel_WindowProgramming
{
    partial class KiemTraGioLam
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
            this.txtHRID = new System.Windows.Forms.TextBox();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.attendanceBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.hotelManagementDataSet3 = new QuanLyHotel_WindowProgramming.HotelManagementDataSet3();
            this.hotelManagementDataSet = new QuanLyHotel_WindowProgramming.HotelManagementDataSet();
            this.hotelManagementDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hotelManagementDataSet1 = new QuanLyHotel_WindowProgramming.HotelManagementDataSet1();
            this.attendanceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.attendanceTableAdapter = new QuanLyHotel_WindowProgramming.HotelManagementDataSet1TableAdapters.AttendanceTableAdapter();
            this.hotelManagementDataSet2 = new QuanLyHotel_WindowProgramming.HotelManagementDataSet2();
            this.dailyReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dailyReportTableAdapter = new QuanLyHotel_WindowProgramming.HotelManagementDataSet2TableAdapters.DailyReportTableAdapter();
            this.lbHRID = new System.Windows.Forms.Label();
            this.attendanceTableAdapter1 = new QuanLyHotel_WindowProgramming.HotelManagementDataSet3TableAdapters.AttendanceTableAdapter();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtCheckOut = new System.Windows.Forms.TextBox();
            this.txtCheckIn = new System.Windows.Forms.TextBox();
            this.lbCheckIn = new System.Windows.Forms.Label();
            this.lbCheckOut = new System.Windows.Forms.Label();
            this.hotelManagementDataSet4 = new QuanLyHotel_WindowProgramming.HotelManagementDataSet4();
            this.attendanceBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.attendanceTableAdapter2 = new QuanLyHotel_WindowProgramming.HotelManagementDataSet4TableAdapters.AttendanceTableAdapter();
            this.hotelManagementDataSet5 = new QuanLyHotel_WindowProgramming.HotelManagementDataSet5();
            this.attendanceBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.attendanceTableAdapter3 = new QuanLyHotel_WindowProgramming.HotelManagementDataSet5TableAdapters.AttendanceTableAdapter();
            this.DataGridViewAttendance = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.attendanceBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelManagementDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelManagementDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelManagementDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelManagementDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attendanceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelManagementDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dailyReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelManagementDataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attendanceBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelManagementDataSet5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attendanceBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewAttendance)).BeginInit();
            this.SuspendLayout();
            // 
            // txtHRID
            // 
            this.txtHRID.Location = new System.Drawing.Point(164, 25);
            this.txtHRID.Name = "txtHRID";
            this.txtHRID.Size = new System.Drawing.Size(121, 20);
            this.txtHRID.TabIndex = 0;
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.Location = new System.Drawing.Point(291, 74);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(75, 23);
            this.btnCheckIn.TabIndex = 5;
            this.btnCheckIn.Text = "Check In";
            this.btnCheckIn.UseVisualStyleBackColor = true;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Location = new System.Drawing.Point(291, 123);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(75, 23);
            this.btnCheckOut.TabIndex = 6;
            this.btnCheckOut.Text = "Check Out";
            this.btnCheckOut.UseVisualStyleBackColor = true;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // attendanceBindingSource1
            // 
            this.attendanceBindingSource1.DataMember = "Attendance";
            this.attendanceBindingSource1.DataSource = this.hotelManagementDataSet3;
            // 
            // hotelManagementDataSet3
            // 
            this.hotelManagementDataSet3.DataSetName = "HotelManagementDataSet3";
            this.hotelManagementDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // hotelManagementDataSet
            // 
            this.hotelManagementDataSet.DataSetName = "HotelManagementDataSet";
            this.hotelManagementDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // hotelManagementDataSetBindingSource
            // 
            this.hotelManagementDataSetBindingSource.DataSource = this.hotelManagementDataSet;
            this.hotelManagementDataSetBindingSource.Position = 0;
            // 
            // hotelManagementDataSet1
            // 
            this.hotelManagementDataSet1.DataSetName = "HotelManagementDataSet1";
            this.hotelManagementDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // attendanceBindingSource
            // 
            this.attendanceBindingSource.DataMember = "Attendance";
            this.attendanceBindingSource.DataSource = this.hotelManagementDataSet1;
            // 
            // attendanceTableAdapter
            // 
            this.attendanceTableAdapter.ClearBeforeFill = true;
            // 
            // hotelManagementDataSet2
            // 
            this.hotelManagementDataSet2.DataSetName = "HotelManagementDataSet2";
            this.hotelManagementDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dailyReportBindingSource
            // 
            this.dailyReportBindingSource.DataMember = "DailyReport";
            this.dailyReportBindingSource.DataSource = this.hotelManagementDataSet2;
            // 
            // dailyReportTableAdapter
            // 
            this.dailyReportTableAdapter.ClearBeforeFill = true;
            // 
            // lbHRID
            // 
            this.lbHRID.AutoSize = true;
            this.lbHRID.Location = new System.Drawing.Point(73, 28);
            this.lbHRID.Name = "lbHRID";
            this.lbHRID.Size = new System.Drawing.Size(40, 13);
            this.lbHRID.TabIndex = 12;
            this.lbHRID.Text = "HR ID:";
            // 
            // attendanceTableAdapter1
            // 
            this.attendanceTableAdapter1.ClearBeforeFill = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(164, 179);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 13;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(257, 179);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 14;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // txtCheckOut
            // 
            this.txtCheckOut.Location = new System.Drawing.Point(164, 120);
            this.txtCheckOut.Name = "txtCheckOut";
            this.txtCheckOut.Size = new System.Drawing.Size(121, 20);
            this.txtCheckOut.TabIndex = 15;
            // 
            // txtCheckIn
            // 
            this.txtCheckIn.Location = new System.Drawing.Point(164, 72);
            this.txtCheckIn.Name = "txtCheckIn";
            this.txtCheckIn.Size = new System.Drawing.Size(121, 20);
            this.txtCheckIn.TabIndex = 16;
            // 
            // lbCheckIn
            // 
            this.lbCheckIn.AutoSize = true;
            this.lbCheckIn.Location = new System.Drawing.Point(73, 79);
            this.lbCheckIn.Name = "lbCheckIn";
            this.lbCheckIn.Size = new System.Drawing.Size(78, 13);
            this.lbCheckIn.TabIndex = 17;
            this.lbCheckIn.Text = "Time Check in:";
            // 
            // lbCheckOut
            // 
            this.lbCheckOut.AutoSize = true;
            this.lbCheckOut.Location = new System.Drawing.Point(73, 123);
            this.lbCheckOut.Name = "lbCheckOut";
            this.lbCheckOut.Size = new System.Drawing.Size(85, 13);
            this.lbCheckOut.TabIndex = 18;
            this.lbCheckOut.Text = "Time Check out:";
            // 
            // hotelManagementDataSet4
            // 
            this.hotelManagementDataSet4.DataSetName = "HotelManagementDataSet4";
            this.hotelManagementDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // attendanceBindingSource2
            // 
            this.attendanceBindingSource2.DataMember = "Attendance";
            this.attendanceBindingSource2.DataSource = this.hotelManagementDataSet4;
            // 
            // attendanceTableAdapter2
            // 
            this.attendanceTableAdapter2.ClearBeforeFill = true;
            // 
            // hotelManagementDataSet5
            // 
            this.hotelManagementDataSet5.DataSetName = "HotelManagementDataSet5";
            this.hotelManagementDataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // attendanceBindingSource3
            // 
            this.attendanceBindingSource3.DataMember = "Attendance";
            this.attendanceBindingSource3.DataSource = this.hotelManagementDataSet5;
            // 
            // attendanceTableAdapter3
            // 
            this.attendanceTableAdapter3.ClearBeforeFill = true;
            // 
            // DataGridViewAttendance
            // 
            this.DataGridViewAttendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewAttendance.Location = new System.Drawing.Point(374, 25);
            this.DataGridViewAttendance.Name = "DataGridViewAttendance";
            this.DataGridViewAttendance.Size = new System.Drawing.Size(843, 150);
            this.DataGridViewAttendance.TabIndex = 19;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(164, 221);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "Xuất file sang PDF";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // KiemTraGioLam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 635);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DataGridViewAttendance);
            this.Controls.Add(this.lbCheckOut);
            this.Controls.Add(this.lbCheckIn);
            this.Controls.Add(this.txtCheckIn);
            this.Controls.Add(this.txtCheckOut);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lbHRID);
            this.Controls.Add(this.btnCheckOut);
            this.Controls.Add(this.btnCheckIn);
            this.Controls.Add(this.txtHRID);
            this.Name = "KiemTraGioLam";
            this.Text = "KiemTraGioLam";
            this.Load += new System.EventHandler(this.KiemTraGioLam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.attendanceBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelManagementDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelManagementDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelManagementDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelManagementDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attendanceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelManagementDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dailyReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelManagementDataSet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attendanceBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelManagementDataSet5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attendanceBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewAttendance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtHRID;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.BindingSource hotelManagementDataSetBindingSource;
        private HotelManagementDataSet hotelManagementDataSet;
        private HotelManagementDataSet1 hotelManagementDataSet1;
        private System.Windows.Forms.BindingSource attendanceBindingSource;
        private HotelManagementDataSet1TableAdapters.AttendanceTableAdapter attendanceTableAdapter;
        private HotelManagementDataSet2 hotelManagementDataSet2;
        private System.Windows.Forms.BindingSource dailyReportBindingSource;
        private HotelManagementDataSet2TableAdapters.DailyReportTableAdapter dailyReportTableAdapter;
        private System.Windows.Forms.Label lbHRID;
        private HotelManagementDataSet3 hotelManagementDataSet3;
        private System.Windows.Forms.BindingSource attendanceBindingSource1;
        private HotelManagementDataSet3TableAdapters.AttendanceTableAdapter attendanceTableAdapter1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtCheckOut;
        private System.Windows.Forms.TextBox txtCheckIn;
        private System.Windows.Forms.Label lbCheckIn;
        private System.Windows.Forms.Label lbCheckOut;
        private HotelManagementDataSet4 hotelManagementDataSet4;
        private System.Windows.Forms.BindingSource attendanceBindingSource2;
        private HotelManagementDataSet4TableAdapters.AttendanceTableAdapter attendanceTableAdapter2;
        private HotelManagementDataSet5 hotelManagementDataSet5;
        private System.Windows.Forms.BindingSource attendanceBindingSource3;
        private HotelManagementDataSet5TableAdapters.AttendanceTableAdapter attendanceTableAdapter3;
        private System.Windows.Forms.DataGridView DataGridViewAttendance;
        private System.Windows.Forms.Button button1;
    }
}