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
                try
                {
                    if (conn.State != ConnectionState.Closed)
                    {
                        conn.Close();
                    }
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT RoomId, RoomNo FROM Room", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    comboBoxRoom.DataSource = dt;
                    comboBoxRoom.DisplayMember = "RoomNo";
                    comboBoxRoom.ValueMember = "RoomId";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tải danh sách phòng: {ex.Message}");
                }
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
            DateTime usageDate = dateTimePickerUsage.Value.Date;
            int quantityOut = (int)numericQuantity.Value;

            using (SqlConnection conn = Database.GetConnection())
            {
                try
                {
                    if (conn.State != ConnectionState.Closed)
                    {
                        conn.Close();
                    }
                    conn.Open();

                    // Kiểm tra tồn tại dòng dữ liệu
                    SqlCommand checkExisting = new SqlCommand(@"
                        SELECT COUNT(*) FROM RoomFoodUsage 
                        WHERE RoomId = @roomId AND FoodId = @foodId AND UsageDate = @date", conn);
                    checkExisting.Parameters.AddWithValue("@roomId", roomId);
                    checkExisting.Parameters.AddWithValue("@foodId", foodId);
                    checkExisting.Parameters.AddWithValue("@date", usageDate);
                    int count = (int)checkExisting.ExecuteScalar();

                    if (count == 0)
                    {
                        MessageBox.Show($"⚠ Không tìm thấy dòng dữ liệu cho phòng {comboBoxRoom.Text}, món {comboBoxFood.Text} vào ngày {usageDate:dd/MM/yyyy}. Hãy kiểm tra lại.");
                        return;
                    }

                    // Cập nhật QuantityOut
                    SqlCommand update = new SqlCommand(@"
                        UPDATE RoomFoodUsage
                        SET QuantityOut = @out
                        WHERE RoomId = @roomId AND FoodId = @foodId AND UsageDate = @date AND (QuantityOut IS NULL OR QuantityOut = 0)", conn);

                    update.Parameters.AddWithValue("@roomId", roomId);
                    update.Parameters.AddWithValue("@foodId", foodId);
                    update.Parameters.AddWithValue("@date", usageDate);
                    update.Parameters.AddWithValue("@out", quantityOut);

                    int rowsAffected = update.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"✅ Đã cập nhật tiêu thụ {quantityOut} cho ngày {usageDate:dd/MM/yyyy}.");
                    }
                    else
                    {
                        MessageBox.Show($"⚠ Dòng dữ liệu cho ngày {usageDate:dd/MM/yyyy} đã có số lượng tiêu thụ khác 0. Không thể cập nhật lại.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi cập nhật số lượng tiêu thụ: {ex.Message}");
                }
            }
        }
    }
}
