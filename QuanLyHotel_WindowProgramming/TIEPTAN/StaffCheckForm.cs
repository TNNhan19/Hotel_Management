using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyHotel_WindowProgramming.TIEPTAN
{
    public partial class StaffCheckForm : Form
    {
        public StaffCheckForm()
        {
            InitializeComponent();
            LoadRoomList();
            LoadFoodList();
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

        private void LoadFoodList()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT FoodId, FoodName FROM Food", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comboBoxFood.DataSource = dt;
                comboBoxFood.DisplayMember = "FoodName";
                comboBoxFood.ValueMember = "FoodId";
            }
        }

        // Nhóm 1: Nhập thực phẩm vào phòng
        private void btnAddQuantityIn_Click(object sender, EventArgs e)
        {
            int roomId = Convert.ToInt32(comboBoxRoom.SelectedValue);
            int foodId = Convert.ToInt32(comboBoxFood.SelectedValue);
            DateTime usageDate = dateTimePickerUsage.Value.Date;
            int quantityIn = (int)numericQuantity.Value;

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"
                    IF EXISTS (SELECT 1 FROM RoomFoodUsage WHERE RoomId=@roomId AND FoodId=@foodId AND UsageDate=@date)
                        UPDATE RoomFoodUsage SET QuantityIn=@in WHERE RoomId=@roomId AND FoodId=@foodId AND UsageDate=@date
                    ELSE
                        INSERT INTO RoomFoodUsage (RoomId, FoodId, UsageDate, QuantityIn)
                        VALUES (@roomId, @foodId, @date, @in)", conn);

                cmd.Parameters.AddWithValue("@roomId", roomId);
                cmd.Parameters.AddWithValue("@foodId", foodId);
                cmd.Parameters.AddWithValue("@date", usageDate);
                cmd.Parameters.AddWithValue("@in", quantityIn);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("✅ Đã thêm số lượng thực phẩm vào phòng.");
        }

        // Nhóm 2: Cập nhật số lượng tiêu thụ thực tế theo dòng đã nhập trước đó
        private void btnAddQuantityOut_Click(object sender, EventArgs e)
        {
            int roomId = Convert.ToInt32(comboBoxRoom.SelectedValue);
            int foodId = Convert.ToInt32(comboBoxFood.SelectedValue);
            int quantityOut = (int)numericQuantity.Value;

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                SqlCommand findExisting = new SqlCommand(@"
                    SELECT TOP 1 UsageDate
                    FROM RoomFoodUsage
                    WHERE RoomId = @roomId AND FoodId = @foodId AND QuantityOut IS NULL
                    ORDER BY UsageDate DESC", conn);

                findExisting.Parameters.AddWithValue("@roomId", roomId);
                findExisting.Parameters.AddWithValue("@foodId", foodId);

                object dateFound = findExisting.ExecuteScalar();

                if (dateFound != null)
                {
                    DateTime usageDateToUpdate = (DateTime)dateFound;

                    SqlCommand update = new SqlCommand(@"
                        UPDATE RoomFoodUsage
                        SET QuantityOut = @out
                        WHERE RoomId = @roomId AND FoodId = @foodId AND UsageDate = @date", conn);

                    update.Parameters.AddWithValue("@roomId", roomId);
                    update.Parameters.AddWithValue("@foodId", foodId);
                    update.Parameters.AddWithValue("@date", usageDateToUpdate);
                    update.Parameters.AddWithValue("@out", quantityOut);
                    update.ExecuteNonQuery();

                    MessageBox.Show($"✅ Đã cập nhật tiêu thụ cho ngày nhập: {usageDateToUpdate:dd/MM/yyyy}");
                }
                else
                {
                    MessageBox.Show("⚠ Không tìm thấy dòng nào để cập nhật. Hãy đảm bảo đã nhập thực phẩm trước.");
                }
            }
        }
    }
}
