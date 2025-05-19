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

namespace QuanLyHotel_WindowProgramming.TIEPTAN
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }
        private void btnViewReport_Click(object sender, EventArgs e)
        {
            DateTime from = dtpFrom.Value.Date;
            DateTime to = dtpTo.Value.Date;

            using (SqlConnection conn = Database.GetConnection())
            {
                string query = @"
                    SELECT 
                        R.RoomNo,
                        F.FoodName,
                        U.UsageDate,
                        U.QuantityIn,
                        U.QuantityOut,
                        F.Price,
                        (U.QuantityOut * F.Price) AS Total,
                        CAST(
                            CASE 
                                WHEN U.QuantityIn = 0 THEN NULL
                                ELSE ABS(U.QuantityIn - U.QuantityOut) * 100.0 / U.QuantityIn
                            END AS DECIMAL(5, 2)
                        ) AS DeviationPercent
                    FROM RoomFoodUsage U
                    JOIN Room R ON U.RoomId = R.RoomId
                    JOIN Food F ON U.FoodId = F.FoodId
                    WHERE U.UsageDate BETWEEN @From AND @To
                    ORDER BY U.UsageDate DESC
                ";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@From", from);
                adapter.SelectCommand.Parameters.AddWithValue("@To", to);

                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridViewReport.DataSource = table;

                // Tính tổng tiền
                decimal total = 0;
                foreach (DataRow row in table.Rows)
                {
                    if (decimal.TryParse(row["Total"].ToString(), out decimal value))
                    {
                        total += value;
                    }
                }
                labelTotal.Text = $"Tổng tiền: {total:N0} VND";

                // Đánh dấu đỏ dòng sai số > 30%
                foreach (DataGridViewRow row in dataGridViewReport.Rows)
                {
                    if (row.Cells["DeviationPercent"].Value != DBNull.Value &&
                        double.TryParse(row.Cells["DeviationPercent"].Value.ToString(), out double deviation) &&
                        deviation > 30)
                    {
                        row.DefaultCellStyle.ForeColor = Color.Red;
                    }
                }
            }
        }
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (dataGridViewReport.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel file (*.csv)|*.csv";
            saveFileDialog.FileName = "BaoCaoThucPham.csv";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                {
                    // Ghi header
                    for (int i = 0; i < dataGridViewReport.Columns.Count; i++)
                    {
                        sw.Write(dataGridViewReport.Columns[i].HeaderText);
                        if (i < dataGridViewReport.Columns.Count - 1)
                            sw.Write(",");
                    }
                    sw.WriteLine();

                    // Ghi dữ liệu
                    foreach (DataGridViewRow row in dataGridViewReport.Rows)
                    {
                        for (int i = 0; i < dataGridViewReport.Columns.Count; i++)
                        {
                            sw.Write(row.Cells[i].Value?.ToString());
                            if (i < dataGridViewReport.Columns.Count - 1)
                                sw.Write(",");
                        }
                        sw.WriteLine();
                    }
                }

                MessageBox.Show("Xuất Excel thành công!", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridViewReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
