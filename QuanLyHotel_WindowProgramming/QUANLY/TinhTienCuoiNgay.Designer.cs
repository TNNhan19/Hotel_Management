namespace QuanLyHotel_WindowProgramming
{
    partial class TinhTienCuoiNgay
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lbDayReport = new System.Windows.Forms.Label();
            this.dgvIncome = new System.Windows.Forms.DataGridView();
            this.lblTotalMoney = new System.Windows.Forms.Label();
            this.lblTotalFood = new System.Windows.Forms.Label();
            this.lblTotalRoom = new System.Windows.Forms.Label();
            this.chartIncome = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnExportPDF = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartIncome)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(176, 12);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDate.TabIndex = 0;
            // 
            // lbDayReport
            // 
            this.lbDayReport.AutoSize = true;
            this.lbDayReport.Location = new System.Drawing.Point(12, 12);
            this.lbDayReport.Name = "lbDayReport";
            this.lbDayReport.Size = new System.Drawing.Size(141, 13);
            this.lbDayReport.TabIndex = 1;
            this.lbDayReport.Text = "Chọn ngày để xem báo cáo:";
            // 
            // dgvIncome
            // 
            this.dgvIncome.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIncome.Location = new System.Drawing.Point(12, 49);
            this.dgvIncome.Name = "dgvIncome";
            this.dgvIncome.Size = new System.Drawing.Size(867, 150);
            this.dgvIncome.TabIndex = 2;
            // 
            // lblTotalMoney
            // 
            this.lblTotalMoney.AutoSize = true;
            this.lblTotalMoney.Location = new System.Drawing.Point(12, 283);
            this.lblTotalMoney.Name = "lblTotalMoney";
            this.lblTotalMoney.Size = new System.Drawing.Size(32, 13);
            this.lblTotalMoney.TabIndex = 5;
            this.lblTotalMoney.Text = "Tổng";
            // 
            // lblTotalFood
            // 
            this.lblTotalFood.AutoSize = true;
            this.lblTotalFood.Location = new System.Drawing.Point(12, 252);
            this.lblTotalFood.Name = "lblTotalFood";
            this.lblTotalFood.Size = new System.Drawing.Size(47, 13);
            this.lblTotalFood.TabIndex = 7;
            this.lblTotalFood.Text = "Thức ăn";
            // 
            // lblTotalRoom
            // 
            this.lblTotalRoom.AutoSize = true;
            this.lblTotalRoom.Location = new System.Drawing.Point(12, 226);
            this.lblTotalRoom.Name = "lblTotalRoom";
            this.lblTotalRoom.Size = new System.Drawing.Size(38, 13);
            this.lblTotalRoom.TabIndex = 8;
            this.lblTotalRoom.Text = "Phòng";
            // 
            // chartIncome
            // 
            chartArea3.Name = "ChartArea1";
            this.chartIncome.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartIncome.Legends.Add(legend3);
            this.chartIncome.Location = new System.Drawing.Point(579, 205);
            this.chartIncome.Name = "chartIncome";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartIncome.Series.Add(series3);
            this.chartIncome.Size = new System.Drawing.Size(300, 300);
            this.chartIncome.TabIndex = 9;
            this.chartIncome.Text = "chart1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Violet;
            this.btnRefresh.Location = new System.Drawing.Point(12, 319);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnExportPDF
            // 
            this.btnExportPDF.Location = new System.Drawing.Point(15, 359);
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.Size = new System.Drawing.Size(150, 23);
            this.btnExportPDF.TabIndex = 11;
            this.btnExportPDF.Text = "Xuất file sang pdf";
            this.btnExportPDF.UseVisualStyleBackColor = true;
            this.btnExportPDF.Click += new System.EventHandler(this.btnExportPDF_Click);
            // 
            // TinhTienCuoiNgay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 597);
            this.Controls.Add(this.btnExportPDF);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.chartIncome);
            this.Controls.Add(this.lblTotalRoom);
            this.Controls.Add(this.lblTotalFood);
            this.Controls.Add(this.lblTotalMoney);
            this.Controls.Add(this.dgvIncome);
            this.Controls.Add(this.lbDayReport);
            this.Controls.Add(this.dtpDate);
            this.Name = "TinhTienCuoiNgay";
            this.Text = "TinhTienCuoiNgay";
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartIncome)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lbDayReport;
        private System.Windows.Forms.DataGridView dgvIncome;
        private System.Windows.Forms.Label lblTotalMoney;
        private System.Windows.Forms.Label lblTotalFood;
        private System.Windows.Forms.Label lblTotalRoom;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartIncome;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnExportPDF;
    }
}