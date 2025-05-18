using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyHotel_WindowProgramming
{
    public partial class TinhTienCuoiNgay : Form
    {
        private My_DB db = new My_DB();
        public TinhTienCuoiNgay()
        {
            InitializeComponent();
            InitializeChart();
            LoadIncomeData(dtpDate.Value);
            LoadChartData();
        }
        private void InitializeChart()
        {
            chartIncome.Series.Clear();
            chartIncome.Series.Add("Total Income");
            chartIncome.Series["Total Income"].ChartType = SeriesChartType.Column;
            chartIncome.ChartAreas[0].AxisX.Title = "Date";
            chartIncome.ChartAreas[0].AxisY.Title = "Total Income (VND)";
            chartIncome.ChartAreas[0].AxisY.LabelStyle.Format = "N0";
        }

        private void LoadIncomeData(DateTime selectedDate)
        {
            try
            {
                db.openConnection();
                string query = @"
                    SELECT Id, CustomerName, roomid, MoneyRoom, MoneyFood, TotalMoney
                    FROM customer
                    WHERE CAST(checkout AS DATE) = @SelectedDate AND checkout_status = 1";
                using (SqlCommand cmd = new SqlCommand(query, db.getConnection))
                {
                    cmd.Parameters.AddWithValue("@SelectedDate", selectedDate.Date);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvIncome.AutoGenerateColumns = false;
                    dgvIncome.Columns.Clear();

                    dgvIncome.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = "Id",
                        HeaderText = "ID Khách"
                    });
                    dgvIncome.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = "CustomerName",
                        HeaderText = "Tên Khách"
                    });
                    dgvIncome.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = "roomid",
                        HeaderText = "Phòng ID"
                    });
                    dgvIncome.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = "MoneyRoom",
                        HeaderText = "Tiền Phòng",
                        DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
                    });
                    dgvIncome.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = "MoneyFood",
                        HeaderText = "Tiền Đồ Ăn",
                        DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
                    });
                    dgvIncome.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = "TotalMoney",
                        HeaderText = "Tổng Tiền",
                        DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
                    });

                    dgvIncome.DataSource = dt;

                    // Tính tổng thu nhập
                    long totalRoom = 0, totalFood = 0, totalMoney = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        totalRoom += Convert.ToInt64(row["MoneyRoom"] ?? 0);
                        totalFood += Convert.ToInt64(row["MoneyFood"] ?? 0);
                        totalMoney += Convert.ToInt64(row["TotalMoney"] ?? 0);
                    }

                    lblTotalRoom.Text = $"Tổng Tiền Phòng: {totalRoom:N0} VND";
                    lblTotalFood.Text = $"Tổng Tiền Đồ Ăn: {totalFood:N0} VND";
                    lblTotalMoney.Text = $"Tổng Thu Nhập: {totalMoney:N0} VND";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.closeConnection();
            }
        }

        private void LoadChartData()
        {
            try
            {
                db.openConnection();
                string query = @"
                    SELECT CAST(checkout AS DATE) AS CheckoutDate, SUM(TotalMoney) AS TotalIncome
                    FROM customer
                    WHERE checkout IS NOT NULL AND checkout_status = 1
                    GROUP BY CAST(checkout AS DATE)
                    ORDER BY CheckoutDate";
                using (SqlCommand cmd = new SqlCommand(query, db.getConnection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    chartIncome.Series["Total Income"].Points.Clear();

                    while (reader.Read())
                    {
                        DateTime date = reader.GetDateTime(0);
                        long totalIncome = Convert.ToInt64(reader["TotalIncome"]);
                        chartIncome.Series["Total Income"].Points.AddXY(date.ToString("dd/MM/yyyy"), totalIncome);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu biểu đồ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.closeConnection();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadIncomeData(dtpDate.Value);
            LoadChartData();
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                Title = "Export to PDF",
                FileName = "Income_Report_" + dtpDate.Value.ToString("ddMMyyyy") + ".pdf"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportToPDF(saveFileDialog.FileName);
                MessageBox.Show("Report exported to PDF successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void ExportToPDF(string filePath)
        {
            try
            {
                Document doc = new Document(PageSize.A4);
                PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                doc.Open();

                // Tiêu đề
                doc.Add(new Paragraph("BÁO CÁO THU NHẬP"));
                doc.Add(new Paragraph($"Ngày: {dtpDate.Value.ToString("dd/MM/yyyy")}"));
                doc.Add(new Paragraph(" "));

                // Bảng dữ liệu
                PdfPTable table = new PdfPTable(6);
                table.AddCell("ID Khách");
                table.AddCell("Tên Khách");
                table.AddCell("Phòng ID");
                table.AddCell("Tiền Phòng");
                table.AddCell("Tiền Đồ Ăn");
                table.AddCell("Tổng Tiền");

                foreach (DataGridViewRow row in dgvIncome.Rows)
                {
                    if (row.IsNewRow) continue;
                    table.AddCell(row.Cells[0].Value?.ToString() ?? "");
                    table.AddCell(row.Cells[1].Value?.ToString() ?? "");
                    table.AddCell(row.Cells[2].Value?.ToString() ?? "");
                    table.AddCell(Convert.ToInt64(row.Cells[3].Value ?? 0).ToString("N0"));
                    table.AddCell(Convert.ToInt64(row.Cells[4].Value ?? 0).ToString("N0"));
                    table.AddCell(Convert.ToInt64(row.Cells[5].Value ?? 0).ToString("N0"));
                }

                doc.Add(table);

                // Tổng kết
                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph(lblTotalRoom.Text));
                doc.Add(new Paragraph(lblTotalFood.Text));
                doc.Add(new Paragraph(lblTotalMoney.Text));

                doc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất PDF: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
