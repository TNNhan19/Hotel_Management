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
    public partial class CustomerManagementForm : Form
    {
        public CustomerManagementForm()
        {
            InitializeComponent();
        }



        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = @"INSERT INTO customer 
                            (CustomerName, Phone, Nationality, Gender, Dob, Cccd, Address, checkin, checkout, checkout_status, roomid)
                            VALUES 
                            (@name, @phone, @nation, @gender, @dob, @cccd, @address, @checkin, @checkout, @status, @roomid)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@phone", txtSdt.Text);
                    cmd.Parameters.AddWithValue("@nation", "Việt Nam"); // Hoặc có thể từ một textbox nếu cần
                    cmd.Parameters.AddWithValue("@gender", GetSelectedGender());
                    cmd.Parameters.AddWithValue("@dob", dateTimeDob.Value);
                    cmd.Parameters.AddWithValue("@cccd", txtcccd.Text);
                    cmd.Parameters.AddWithValue("@address", ""); // nếu có thêm txtAddress
                    cmd.Parameters.AddWithValue("@checkin", dateTimeCheckin.Value);
                    cmd.Parameters.AddWithValue("@checkout", dateTimeCheckout.Value);
                    cmd.Parameters.AddWithValue("@status", radioCheckout.Checked ? 1 : 0);
                    cmd.Parameters.AddWithValue("@roomid", Convert.ToInt32(comboBoxPhong.SelectedValue)); // Phải binding trước đó

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                        MessageBox.Show("Thêm khách thành công!");
                    else
                        MessageBox.Show("Thêm khách thất bại.");
                    string updateRoom = "UPDATE Room SET booked = 'YES' WHERE RoomId = @roomid";
                    SqlCommand updateCmd = new SqlCommand(updateRoom, conn);
                    updateCmd.Parameters.AddWithValue("@roomid", Convert.ToInt32(comboBoxPhong.SelectedValue));
                    updateCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private string GetSelectedGender()
        {
            if (radioMale.Checked) return "Nam";
            if (radioFemale.Checked) return "Nữ";
            return "Khác";
        }
        private void LoadRoomList()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT RoomId, RoomNo FROM Room WHERE booked = 'NO'";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBoxPhong.DataSource = dt;
                comboBoxPhong.DisplayMember = "RoomNo";
                comboBoxPhong.ValueMember = "RoomId";
                comboBoxPhong.SelectionChangeCommitted += comboBoxPhong_SelectionChangeCommitted;

            }
        }

        private void CustomerManagementForm_Load(object sender, EventArgs e)
        {
            LoadRoomList();
            LoadCustomerList();
        }
        private void LoadCustomerList()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"SELECT c.Id, c.CustomerName, c.Phone, c.Gender, c.Dob, c.Cccd, 
                         c.Checkin, c.Checkout, c.checkout_status, r.RoomNo
                         FROM customer c
                         JOIN Room r ON c.roomid = r.RoomId";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"SELECT c.Id, c.CustomerName, c.Phone, c.Gender, c.Dob, c.Cccd, 
                         c.Checkin, c.Checkout, c.checkout_status, r.RoomNo
                         FROM customer c
                         JOIN Room r ON c.roomid = r.RoomId
                         WHERE c.Cccd = @cccd";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@cccd", txtCheckCccd.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int customerId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
                int roomId = GetRoomIdFromCustomer(customerId);

                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();

                    string deleteQuery = "DELETE FROM customer WHERE Id = @id";
                    SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                    cmd.Parameters.AddWithValue("@id", customerId);
                    cmd.ExecuteNonQuery();

                    // Giải phóng phòng nếu khách đã check-out
                    string updateRoom = "UPDATE Room SET booked = 'NO' WHERE RoomId = @roomid";
                    SqlCommand cmdRoom = new SqlCommand(updateRoom, conn);
                    cmdRoom.Parameters.AddWithValue("@roomid", roomId);
                    cmdRoom.ExecuteNonQuery();

                    MessageBox.Show("Đã xóa khách.");
                    LoadCustomerList();
                    LoadRoomList();
                }
            }
        }

        private int GetRoomIdFromCustomer(int customerId)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT roomid FROM customer WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", customerId);
                return (int)cmd.ExecuteScalar();
            }
        }
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int customerId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = @"UPDATE customer SET 
                            CustomerName = @name,
                            Phone = @phone,
                            Gender = @gender,
                            Dob = @dob,
                            Cccd = @cccd,
                            checkin = @checkin,
                            checkout = @checkout,
                            checkout_status = @status
                            WHERE Id = @id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@phone", txtSdt.Text);
                    cmd.Parameters.AddWithValue("@gender", GetSelectedGender());
                    cmd.Parameters.AddWithValue("@dob", dateTimeDob.Value);
                    cmd.Parameters.AddWithValue("@cccd", txtcccd.Text);
                    cmd.Parameters.AddWithValue("@checkin", dateTimeCheckin.Value);
                    cmd.Parameters.AddWithValue("@checkout", dateTimeCheckout.Value);
                    cmd.Parameters.AddWithValue("@status", radioCheckout.Checked ? 1 : 0);
                    cmd.Parameters.AddWithValue("@id", customerId);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thành công!");
                    LoadCustomerList();
                }
            }
        }
        private void CheckOutCustomer(int customerId, int roomId)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE customer SET 
                                checkout_status = 1, 
                                checkout = GETDATE() 
                                WHERE Id = @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", customerId);
                cmd.ExecuteNonQuery();

                string updateRoom = "UPDATE Room SET booked = 'NO' WHERE RoomId = @roomid";
                SqlCommand cmdRoom = new SqlCommand(updateRoom, conn);
                cmdRoom.Parameters.AddWithValue("@roomid", roomId);
                cmdRoom.ExecuteNonQuery();
            }
        }
        private void comboBoxPhong_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int selectedRoomId = Convert.ToInt32(comboBoxPhong.SelectedValue);
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT RoomType, Bed FROM Room WHERE RoomId = @roomId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@roomId", selectedRoomId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtRoomType.Text = reader["RoomType"].ToString(); // textbox hoặc combobox
                        txtBed.Text = reader["Bed"].ToString();
                    }
                }
            }
        }
        private void CustomerManagementForm_Activated(object sender, EventArgs e)
        {
            LoadCustomerList(); // luôn cập nhật lại danh sách mỗi khi form quay lại
        }

        private void buttonDelete_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int customerId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
                int roomId = GetRoomIdFromCustomer(customerId);

                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();

                    string deleteQuery = "DELETE FROM customer WHERE Id = @id";
                    SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                    cmd.Parameters.AddWithValue("@id", customerId);
                    cmd.ExecuteNonQuery();

                    string updateRoom = "UPDATE Room SET booked = 'NO' WHERE RoomId = @roomid";
                    SqlCommand cmdRoom = new SqlCommand(updateRoom, conn);
                    cmdRoom.Parameters.AddWithValue("@roomid", roomId);
                    cmdRoom.ExecuteNonQuery();

                    MessageBox.Show("Đã xóa khách.");
                    LoadCustomerList(); // cập nhật lại danh sách
                    LoadRoomList();     // cập nhật lại danh sách phòng trống
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để xóa.");
            }
        }

        private void buttonUpdate_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int customerId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = @"UPDATE customer SET 
                            CustomerName = @name,
                            Phone = @phone,
                            Gender = @gender,
                            Dob = @dob,
                            Cccd = @cccd,
                            checkin = @checkin,
                            checkout = @checkout,
                            checkout_status = @status
                            WHERE Id = @id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@phone", txtSdt.Text);
                    cmd.Parameters.AddWithValue("@gender", GetSelectedGender());
                    cmd.Parameters.AddWithValue("@dob", dateTimeDob.Value);
                    cmd.Parameters.AddWithValue("@cccd", txtcccd.Text);
                    cmd.Parameters.AddWithValue("@checkin", dateTimeCheckin.Value);
                    cmd.Parameters.AddWithValue("@checkout", dateTimeCheckout.Value);
                    cmd.Parameters.AddWithValue("@status", radioCheckout.Checked ? 1 : 0);
                    cmd.Parameters.AddWithValue("@id", customerId);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thành công!");
                    LoadCustomerList();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để cập nhật.");
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadCustomerList();
            LoadRoomList(); // Nếu cần làm mới cả danh sách phòng
            MessageBox.Show("Danh sách đã được làm mới.");
        }
    }




}
