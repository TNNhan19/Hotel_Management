using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHotel_WindowProgramming.TIEPTAN
{
    public partial class CustomerRegistration : Form
    {
        public CustomerRegistration()
        {
            InitializeComponent();
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
        private void CustomerRegistration_Load(object sender, EventArgs e)
        {
            // Load dữ liệu mẫu
            txtNationality.Items.AddRange(new string[] { "Việt Nam", "Mỹ", "Hàn Quốc" });
            txtBed.Items.AddRange(new string[] { "Single", "Double" });
            txtType.Items.AddRange(new string[] { "Standard", "Deluxe", "VIP" });
            txtNoRoom.Items.AddRange(new string[] { "101", "102", "201", "202" });

            // Mặc định giá
            txtPrice.Text = "500000"; // ví dụ 500.000 VND/ngày
        }
        private void txtCheckOut_ValueChanged(object sender, EventArgs e)
        {
            int days = (txtCheckOut.Value.Date - txtCheckin.Value.Date).Days;
            days = Math.Max(days, 1); // ít nhất 1 ngày

            txtStayed.Text = days.ToString();

            if (int.TryParse(txtPrice.Text, out int price))
            {
                int total = days * price;
                labelTotalPrice.Text = $"Tổng giá: {total:N0} VND";
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

        private void txtCheckOut_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void labelStayed_Click(object sender, EventArgs e)
        {

        }

        private void txtStayed_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelCheckOut_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtCheckin_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtCccd_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
