using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyHotel_WindowProgramming.TIEPTAN
{
    public partial class CustomerRegistration : Form
    {
        private SqlConnection conn;
        public CustomerRegistration()
        {
            InitializeComponent();
            conn = Database.GetConnection();
            LoadRooms();
        }
        private void LoadRooms()
        {
            using (SqlConnection localConn = Database.GetConnection())
            {
                try
                {
                    localConn.Open();
                    string query = "SELECT RoomId, RoomNo, RoomType, bed, price FROM Room WHERE booked = 'NO'";
                    SqlDataAdapter da = new SqlDataAdapter(query, localConn);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    da.Fill(dt);
                    dgvRoom.DataSource = dt;
                    cbRoomID.DataSource = dt;
                    cbRoomID.DisplayMember = "RoomId";
                    cbRoomID.ValueMember = "RoomId";

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không có phòng trống để đăng ký!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cbRoomID.Enabled = false;
                    }
                    else
                    {
                        cbRoomID.SelectedIndexChanged -= cbRoomID_SelectedIndexChanged; // chống sự kiện lặp
                        cbRoomID.SelectedIndex = 0;
                        cbRoomID.SelectedIndexChanged += cbRoomID_SelectedIndexChanged;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbRoomID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRoomID.SelectedValue == null || cbRoomID.SelectedValue == DBNull.Value)
                return;

            if (!(cbRoomID.SelectedValue is int roomId))
            {
                if (cbRoomID.SelectedValue is System.Data.DataRowView drv &&
                    int.TryParse(drv["RoomId"].ToString(), out int parsedId))
                {
                    roomId = parsedId;
                }
                else
                {
                    MessageBox.Show("ID phòng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                string query = "SELECT RoomType, bed, price FROM Room WHERE RoomId = @RoomId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@RoomId", roomId);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    cbType.Text = reader["RoomType"].ToString();
                    cbBed.Text = reader["bed"].ToString();
                    txtPriceRoom.Text = reader["price"].ToString();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnAlloteRoom_Click(object sender, EventArgs e)
        {
            // Kiểm tra control tồn tại
            if (txtName == null || txtCccd == null || txtPhone == null || txtAddress == null ||
                cbRoomID == null || txtPriceRoom == null || DateTimePickerBirth == null ||
                DateTimePickerCheckIn == null || DateTimePickerCheckOut == null)
            {
                MessageBox.Show("Một số thành phần giao diện chưa được khởi tạo đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra dữ liệu bắt buộc
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtCccd.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) || string.IsNullOrWhiteSpace(txtAddress.Text) ||
                cbRoomID.SelectedValue == null || string.IsNullOrWhiteSpace(txtPriceRoom.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Giá mỗi ngày
            if (!long.TryParse(txtPriceRoom.Text, out long pricePerDay))
            {
                MessageBox.Show("Giá phòng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Ngày check-in và check-out phải hợp lệ
            if (DateTimePickerCheckIn.Value < new DateTime(1753, 1, 1) || DateTimePickerCheckOut.Value < new DateTime(1753, 1, 1))
            {
                MessageBox.Show("Ngày nhận phòng và trả phòng phải từ năm 1753 trở đi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int totalDays = (DateTimePickerCheckOut.Value - DateTimePickerCheckIn.Value).Days;
            if (totalDays <= 0)
            {
                MessageBox.Show("Ngày trả phòng phải lớn hơn ngày nhận phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            long moneyRoom = totalDays * pricePerDay;
            long moneyFood = 0; // tạm thời 0
            long totalMoney = moneyRoom + moneyFood;

            // Xác định giới tính
            string gender = radioMale != null && radioMale.Checked ? "Nam" :
                            radioFemale != null && radioFemale.Checked ? "Nữ" : "Khác";

            try
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                SqlCommand cmd = conn.CreateCommand();
                cmd.Transaction = transaction;

                try
                {
                    // Insert khách hàng mới
                    cmd.CommandText = @"
                INSERT INTO customer (CustomerName, Cccd, Phone, Address, Birth, Gender, checkin, checkout, checkout_status, roomid, MoneyRoom, MoneyFood, TotalMoney)
                VALUES (@Name, @Cccd, @Phone, @Address, @Birth, @Gender, @CheckIn, @CheckOut, 0, @RoomId, @MoneyRoom, @MoneyFood, @TotalMoney)";

                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@Cccd", txtCccd.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@Birth", DateTimePickerBirth.Value);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@CheckIn", DateTimePickerCheckIn.Value);
                    cmd.Parameters.AddWithValue("@CheckOut", DateTimePickerCheckOut.Value);
                    cmd.Parameters.AddWithValue("@RoomId", Convert.ToInt32(cbRoomID.SelectedValue));
                    cmd.Parameters.AddWithValue("@MoneyRoom", moneyRoom);
                    cmd.Parameters.AddWithValue("@MoneyFood", moneyFood);
                    cmd.Parameters.AddWithValue("@TotalMoney", totalMoney);
                    cmd.ExecuteNonQuery();

                    // Cập nhật phòng đã được đặt
                    cmd.Parameters.Clear();
                    cmd.CommandText = "UPDATE Room SET booked = 'YES' WHERE RoomId = @RoomId";
                    cmd.Parameters.AddWithValue("@RoomId", Convert.ToInt32(cbRoomID.SelectedValue));
                    cmd.ExecuteNonQuery();

                    transaction.Commit();
                    MessageBox.Show("Đặt phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRooms();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            if (!long.TryParse(txtPriceRoom.Text, out long price))
            {
                MessageBox.Show("Giá phòng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int totalDays = (DateTimePickerCheckOut.Value - DateTimePickerCheckIn.Value).Days;
            if (totalDays <= 0)
            {
                MessageBox.Show("Ngày trả phòng phải lớn hơn ngày nhận phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            long totalPrice = totalDays * price;

            txtTotalDays.Text = totalDays.ToString();
            txtTotalPrice.Text = totalPrice.ToString("N0"); // định dạng tiền có dấu chấm
        }
    }

}
