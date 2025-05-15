using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyHotel_WindowProgramming.TIEPTAN
{
    public partial class CustomerRegistration : Form
    {
        public CustomerRegistration()
        {
            InitializeComponent();
        }

        private void CustomerRegistration_Load(object sender, EventArgs e)
        {
            txtNationality.Items.AddRange(new string[] { "Việt Nam", "Mỹ", "Hàn Quốc" });

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                // Load RoomNo vào txtNoRoom
                string roomNoQuery = "SELECT RoomNo FROM Room WHERE booked = 'NO'";
                SqlCommand cmdRoomNo = new SqlCommand(roomNoQuery, conn);
                SqlDataReader readerRoomNo = cmdRoomNo.ExecuteReader();
                while (readerRoomNo.Read())
                {
                    txtNoRoom.Items.Add(readerRoomNo["RoomNo"].ToString());
                }
                readerRoomNo.Close();

                // Load các loại giường duy nhất
                string bedQuery = "SELECT DISTINCT Bed FROM Room";
                SqlCommand cmdBed = new SqlCommand(bedQuery, conn);
                SqlDataReader readerBed = cmdBed.ExecuteReader();
                while (readerBed.Read())
                {
                    txtBed.Items.Add(readerBed["Bed"].ToString());
                }
                readerBed.Close();

                // Load các loại phòng duy nhất
                string typeQuery = "SELECT DISTINCT RoomType FROM Room";
                SqlCommand cmdType = new SqlCommand(typeQuery, conn);
                SqlDataReader readerType = cmdType.ExecuteReader();
                while (readerType.Read())
                {
                    txtType.Items.Add(readerType["RoomType"].ToString());
                }
                readerType.Close();
            }

            txtNoRoom.SelectedIndexChanged += TxtNoRoom_SelectedIndexChanged;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                string phone = txtPhone.Text;
                string nationality = txtNationality.Text;
                string gender = txtGender.Text;
                DateTime dob = txtDob.Value;
                string cccd = txtCccd.Text;
                string address = txtAddress.Text;

                DateTime checkin = txtCheckin.Value;
                DateTime checkout = txtCheckOut.Value;
                int roomId = GetRoomIdByRoomNo(txtNoRoom.Text); // Lấy RoomId từ RoomNo

                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();

                    string insertCustomer = @"INSERT INTO customer 
                    (CustomerName, Phone, Nationality, Gender, Dob, Cccd, Address, checkin, checkout, roomid)
                    VALUES 
                    (@Name, @Phone, @Nationality, @Gender, @Dob, @Cccd, @Address, @Checkin, @Checkout, @RoomId)";

                    SqlCommand cmd = new SqlCommand(insertCustomer, conn);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@Nationality", nationality);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@Dob", dob);
                    cmd.Parameters.AddWithValue("@Cccd", cccd);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@Checkin", checkin);
                    cmd.Parameters.AddWithValue("@Checkout", checkout);
                    cmd.Parameters.AddWithValue("@RoomId", roomId);

                    cmd.ExecuteNonQuery();

                    // Cập nhật trạng thái phòng
                    string updateRoom = "UPDATE Room SET booked = 'YES' WHERE RoomId = @RoomId";
                    SqlCommand cmd2 = new SqlCommand(updateRoom, conn);
                    cmd2.Parameters.AddWithValue("@RoomId", roomId);
                    cmd2.ExecuteNonQuery();
                }

                MessageBox.Show("Đặt phòng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCheckin_ValueChanged(object sender, EventArgs e)
        {
            TinhTien();
        }

        private void txtCheckOut_ValueChanged_1(object sender, EventArgs e)
        {
            TinhTien();
        }

        private void TinhTien()
        {
            int days = (txtCheckOut.Value.Date - txtCheckin.Value.Date).Days;
            days = Math.Max(days, 1); // ít nhất 1 ngày

            txtStayed.Text = days.ToString();

            if (int.TryParse(textBoxGiaPhong.Text, out int pricePerDay)) // Lấy giá mỗi ngày từ textbox giá gốc
            {
                int total = days * pricePerDay;
                txtPrice.Text = total.ToString(); // Gán tổng giá tiền vào ô txtPrice
            }
            else
            {
                txtPrice.Text = "Lỗi giá tiền";
            }
        }

        private int GetRoomIdByRoomNo(string roomNo)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT RoomId FROM Room WHERE RoomNo = @RoomNo";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@RoomNo", roomNo);

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    throw new Exception("Không tìm thấy phòng!");
                }
            }
        }
        private void TxtNoRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            string roomNo = txtNoRoom.Text;

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT Price, RoomType, Bed FROM Room WHERE RoomNo = @RoomNo";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@RoomNo", roomNo);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int price = Convert.ToInt32(reader["Price"]);
                        string roomType = reader["RoomType"].ToString();
                        string bed = reader["Bed"].ToString();

                        // Cập nhật giá, loại phòng và giường
                        textBoxGiaPhong.Text = price.ToString();
                        txtPrice.Text = price.ToString();

                        txtType.Text = roomType;
                        txtBed.Text = bed;

                        // Tính tổng tiền
                        TinhTien();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }


        // Các sự kiện UI chưa dùng
        private void labelStayed_Click(object sender, EventArgs e) { }
        private void txtStayed_TextChanged(object sender, EventArgs e) { }
        private void labelCheckOut_Click(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void txtCccd_TextChanged(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void txtAddress_TextChanged(object sender, EventArgs e) { }

    }

}
