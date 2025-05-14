using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHotel_WindowProgramming.TIEPTAN
{
    public partial class FoodManagement : Form
    {
        public FoodManagement()
        {
            InitializeComponent();
        }

        private void btnCheckDeviation_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewFood.Rows)
            {
                if (row.IsNewRow) continue;

                if (double.TryParse(row.Cells["QuantityIn"].Value?.ToString(), out double quantityIn) &&
                    double.TryParse(row.Cells["QuantityOut"].Value?.ToString(), out double quantityOut))
                {
                    if (quantityIn == 0) continue;

                    double deviation = Math.Abs(quantityIn - quantityOut) / quantityIn * 100;
                    row.Cells["Deviation"].Value = $"{deviation:0.##}%";

                    if (deviation > 30)
                    {
                        row.DefaultCellStyle.ForeColor = Color.Red;
                        row.Cells["Deviation"].Value += " (!)";
                    }
                    else
                    {
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }

            labelStatus.Text = "Đã kiểm tra sai số.";
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            dataGridViewFood.Rows.Add();
        }

        private void btnRemoveFood_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewFood.SelectedRows)
            {
                if (!row.IsNewRow)
                    dataGridViewFood.Rows.Remove(row);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string room = comboBoxRoom.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(room))
            {
                MessageBox.Show("Vui lòng chọn phòng.");
                return;
            }

            List<string> foodData = new List<string>();
            foreach (DataGridViewRow row in dataGridViewFood.Rows)
            {
                if (row.IsNewRow) continue;
                string food = row.Cells["FoodName"].Value?.ToString();
                string inQty = row.Cells["QuantityIn"].Value?.ToString();
                string outQty = row.Cells["QuantityOut"].Value?.ToString();
                string deviation = row.Cells["Deviation"].Value?.ToString();

                foodData.Add($"{food},{inQty},{outQty},{deviation}");
            }

            File.WriteAllLines($"FoodData_{room}.csv", foodData);
            labelStatus.Text = $"Đã lưu dữ liệu thực phẩm cho phòng {room}.";
        }
    }
}
