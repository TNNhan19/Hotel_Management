using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace QuanLyHotel_WindowProgramming.TIEPTAN
{
    public partial class FoodManagement : Form
    {
        public FoodManagement()
        {
            InitializeComponent();
            LoadRoomList();
            comboBoxRoom.SelectedIndexChanged += comboBoxRoom_SelectedIndexChanged;

            // Khởi tạo cột nếu chưa có
            if (dataGridViewFood.Columns.Count == 0)
            {
                dataGridViewFood.Columns.Add("FoodName", "Tên thực phẩm");
                dataGridViewFood.Columns.Add("QuantityIn", "Số lượng nhập");
                dataGridViewFood.Columns.Add("QuantityOut", "Số lượng tiêu thụ");
                dataGridViewFood.Columns.Add("Deviation", "Sai lệch (%)");
                dataGridViewFood.Columns.Add("TotalPrice", "Tổng tiền (VND)");
            }
        }

        private void LoadRoomList()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT RoomId, RoomNo FROM Room", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comboBoxRoom.DataSource = dt;
                comboBoxRoom.DisplayMember = "RoomNo";
                comboBoxRoom.ValueMember = "RoomId";
            }
        }

        private void comboBoxRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxRoom.SelectedValue != null)
            {
                int roomId = Convert.ToInt32(comboBoxRoom.SelectedValue);
                LoadFoodUsageForRoom(roomId);
            }
        }

        private void LoadFoodUsageForRoom(int roomId)
        {
            dataGridViewFood.Rows.Clear();

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT f.FoodName, r.QuantityIn, r.QuantityOut, f.Price
                    FROM RoomFoodUsage r
                    JOIN Food f ON r.FoodId = f.FoodId
                    WHERE r.RoomId = @roomId
                    ORDER BY r.UsageDate";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@roomId", roomId);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader["FoodName"].ToString();
                    string inQty = reader["QuantityIn"].ToString();
                    string outQty = reader["QuantityOut"]?.ToString() ?? "";
                    string price = reader["Price"].ToString();

                    string total = "";
                    if (int.TryParse(outQty, out int used) && int.TryParse(price, out int unitPrice))
                    {
                        total = (used * unitPrice).ToString("N0");
                    }

                    dataGridViewFood.Rows.Add(name, inQty, outQty, "", total); // Sai lệch sẽ tính sau
                }
            }

            labelStatus.Text = $"Đã tải dữ liệu phòng {comboBoxRoom.Text}";
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
                string total = row.Cells["TotalPrice"].Value?.ToString();

                foodData.Add($"{food},{inQty},{outQty},{deviation},{total}");
            }

            File.WriteAllLines($"FoodData_{room}.csv", foodData);
            labelStatus.Text = $"Đã lưu dữ liệu thực phẩm cho phòng {room}.";
        }
    }
}
