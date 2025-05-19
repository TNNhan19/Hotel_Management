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
                dataGridViewFood.Columns.Add("TotalPrice", "Thành tiền (VND)");
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
            long grandTotal = 0;

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
                    int quantityIn = Convert.ToInt32(reader["QuantityIn"]);
                    int? quantityOut = reader["QuantityOut"] != DBNull.Value ? Convert.ToInt32(reader["QuantityOut"]) : (int?)null;
                    long price = Convert.ToInt64(reader["Price"]);

                    string quantityOutDisplay = quantityOut.HasValue ? quantityOut.ToString() : "";
                    long totalPrice = quantityOut.HasValue ? quantityOut.Value * price : 0;

                    if (quantityOut.HasValue)
                    {
                        grandTotal += totalPrice;
                    }

                    dataGridViewFood.Rows.Add(name, quantityIn, quantityOutDisplay, "", totalPrice.ToString("N0"));
                }
                reader.Close();
            }

            // Add summary row for grand total
            if (dataGridViewFood.Rows.Count > 0)
            {
                int rowIndex = dataGridViewFood.Rows.Add("TỔNG CỘNG", "", "", "", grandTotal.ToString("N0"));
                dataGridViewFood.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightGray;
                dataGridViewFood.Rows[rowIndex].DefaultCellStyle.Font = new Font(dataGridViewFood.Font, FontStyle.Bold);
            }

            labelStatus.Text = $"Đã tải dữ liệu phòng {comboBoxRoom.Text}";
        }

        private void btnCheckDeviation_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewFood.Rows)
            {
                if (row.IsNewRow || row.Cells["FoodName"].Value?.ToString() == "TỔNG CỘNG") continue;

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
           StaffCheckForm staffCheckForm = new StaffCheckForm();
            staffCheckForm.Show();
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
                if (row.IsNewRow || row.Cells["FoodName"].Value?.ToString() == "TỔNG CỘNG") continue;
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

        private void dataGridViewFood_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (comboBoxRoom.SelectedValue != null)
            {
                int roomId = Convert.ToInt32(comboBoxRoom.SelectedValue);
                LoadFoodUsageForRoom(roomId);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phòng trước khi làm mới.");
            }
        }
    }
}
