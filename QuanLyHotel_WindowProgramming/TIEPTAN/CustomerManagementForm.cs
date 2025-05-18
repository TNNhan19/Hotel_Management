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
        private SqlConnection conn;
        public CustomerManagementForm()
        {
            InitializeComponent();
            conn = Database.GetConnection();
            LoadCustomers();
        }
        private void LoadCustomers()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                string query = @"
            SELECT c.Id, c.CustomerName, c.Cccd, c.Phone, c.Address, c.Birth, c.Gender, 
                   c.checkin, c.checkout, c.checkout_status, c.roomid, c.MoneyRoom, c.MoneyFood, c.TotalMoney, 
                   r.RoomNo, r.bed, r.RoomType, r.price
            FROM customer c
            JOIN Room r ON c.roomid = r.RoomId";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvCustomers.AutoGenerateColumns = false;
                dgvCustomers.Columns.Clear();

                dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "Id",
                    HeaderText = "ID Khách",
                    Name = "Id"
                });
                dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "CustomerName",
                    HeaderText = "Tên Khách",
                    Name = "CustomerName"
                });
                dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "Cccd",
                    HeaderText = "CCCD",
                    Name = "Cccd"
                });
                dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "Phone",
                    HeaderText = "Số Điện Thoại",
                    Name = "Phone"
                });
                dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "Address",
                    HeaderText = "Địa Chỉ",
                    Name = "Address"
                });
                dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "Birth",
                    HeaderText = "Ngày Sinh",
                    Name = "Birth"
                });
                dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "Gender",
                    HeaderText = "Giới Tính",
                    Name = "Gender"
                });
                dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "checkin",
                    HeaderText = "Ngày Check-In",
                    Name = "checkin"
                });
                dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "checkout",
                    HeaderText = "Ngày Check-Out",
                    Name = "checkout"
                });
                dgvCustomers.Columns.Add(new DataGridViewCheckBoxColumn()
                {
                    DataPropertyName = "checkout_status",
                    HeaderText = "Trạng Thái Thanh Toán",
                    Name = "checkout_status"
                });
                dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "RoomNo",
                    HeaderText = "Phòng",
                    Name = "RoomNo"
                });
                dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "MoneyRoom",
                    HeaderText = "Tiền Phòng",
                    Name = "MoneyRoom",
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
                });
                dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "MoneyFood",
                    HeaderText = "Tiền Đồ Ăn",
                    Name = "MoneyFood",
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
                });
                dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "TotalMoney",
                    HeaderText = "Tổng Tiền",
                    Name = "TotalMoney",
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
                });
                dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "roomid",
                    HeaderText = "RoomId",
                    Name = "roomid",
                    Visible = false
                });
                dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "bed",
                    HeaderText = "Giường",
                    Name = "bed"
                });
                dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "RoomType",
                    HeaderText = "Loại Phòng",
                    Name = "RoomType"
                });
                dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "price",
                    HeaderText = "Giá",
                    Name = "price",
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
                });

                dgvCustomers.DataSource = dt;
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
        private long CalculateFoodCost(int roomId)
        {
            long totalFoodCost = 0;
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                string query = @"
            SELECT f.Price, r.QuantityOut
            FROM RoomFoodUsage r
            JOIN Food f ON r.FoodId = f.FoodId
            WHERE r.RoomId = @RoomId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@RoomId", roomId);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int? quantityOut = reader["QuantityOut"] != DBNull.Value ? Convert.ToInt32(reader["QuantityOut"]) : (int?)null;
                    long price = Convert.ToInt64(reader["Price"]);
                    if (quantityOut.HasValue)
                    {
                        totalFoodCost += quantityOut.Value * price;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính tiền đồ ăn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            return totalFoodCost;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int customerId = Convert.ToInt32(dgvCustomers.CurrentRow.Cells["Id"].Value);
            bool checkoutStatus = checkBoxThanhToan.Checked;
            int roomId = Convert.ToInt32(dgvCustomers.CurrentRow.Cells["roomid"].Value ?? 0);
            long moneyFood = CalculateFoodCost(roomId);
            long moneyRoom = Convert.ToInt64(dgvCustomers.CurrentRow.Cells["MoneyRoom"].Value ?? 0);
            long totalMoney = moneyRoom + moneyFood;

            // Kiểm tra giá trị có vượt quá giới hạn của INT không
            if (moneyRoom > int.MaxValue || moneyFood > int.MaxValue || totalMoney > int.MaxValue)
            {
                MessageBox.Show("Giá trị tiền phòng, tiền đồ ăn hoặc tổng tiền vượt quá giới hạn cho phép!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra roomid có tồn tại trong bảng Room không
            bool roomExists = false;
            try
            {
                conn.Open();
                string checkRoomQuery = "SELECT COUNT(*) FROM Room WHERE RoomId = @RoomId";
                using (SqlCommand checkCmd = new SqlCommand(checkRoomQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@RoomId", roomId);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                    roomExists = count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                conn.Close();
            }

            if (roomId > 0 && !roomExists)
            {
                MessageBox.Show("Phòng không tồn tại trong hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                SqlCommand cmd = conn.CreateCommand();
                cmd.Transaction = transaction;

                try
                {
                    cmd.CommandText = @"
                UPDATE customer 
                SET checkout_status = @CheckoutStatus, 
                    MoneyFood = @MoneyFood, 
                    TotalMoney = @TotalMoney 
                WHERE Id = @CustomerId";
                    cmd.Parameters.AddWithValue("@CheckoutStatus", checkoutStatus ? 1 : 0);
                    cmd.Parameters.AddWithValue("@MoneyFood", moneyFood);
                    cmd.Parameters.AddWithValue("@TotalMoney", totalMoney);
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    cmd.ExecuteNonQuery();

                    // Cập nhật trạng thái booked của phòng nếu khách thanh toán
                    if (checkoutStatus && roomId > 0)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = "UPDATE Room SET booked = 'NO' WHERE RoomId = @RoomId";
                        cmd.Parameters.AddWithValue("@RoomId", roomId);
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Cập nhật trạng thái thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCustomers();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];

            // Gán giá trị cho các control
            txtName.Text = row.Cells["CustomerName"]?.Value?.ToString() ?? string.Empty;
            txtCccd.Text = row.Cells["Cccd"]?.Value?.ToString() ?? string.Empty;
            txtPhone.Text = row.Cells["Phone"]?.Value?.ToString() ?? string.Empty;
            txtAddress.Text = row.Cells["Address"]?.Value?.ToString() ?? string.Empty;

            if (DateTime.TryParse(row.Cells["Birth"]?.Value?.ToString(), out DateTime birth))
                DateTimePickerBirth.Value = birth;
            else
                DateTimePickerBirth.Value = DateTime.Today;

            // Xử lý RadioButton cho giới tính
            string gender = row.Cells["Gender"]?.Value?.ToString() ?? string.Empty;
            radioMale.Checked = gender == "Nam";
            radioFemale.Checked = gender == "Nữ";
            radioOther.Checked = (gender != "Nam" && gender != "Nữ");

            if (DateTime.TryParse(row.Cells["checkin"]?.Value?.ToString(), out DateTime checkin))
                DateTimePickerCheckIn.Value = checkin;
            else
                DateTimePickerCheckIn.Value = DateTime.Today;

            // Kiểm tra nếu checkout là NULL
            if (row.Cells["checkout"]?.Value == null || row.Cells["checkout"].Value == DBNull.Value)
            {
                DateTimePickerCheckOut.Value = DateTime.Today;
                DateTimePickerCheckOut.Enabled = false;
                checkBoxThanhToan.Enabled = false;
                checkBoxThanhToan.Checked = false;
            }
            else
            {
                if (DateTime.TryParse(row.Cells["checkout"]?.Value?.ToString(), out DateTime checkout))
                    DateTimePickerCheckOut.Value = checkout;
                else
                    DateTimePickerCheckOut.Value = DateTime.Today;
                DateTimePickerCheckOut.Enabled = true;
                checkBoxThanhToan.Enabled = true;
            }

            txtRoomNo.Text = row.Cells["RoomNo"]?.Value?.ToString() ?? string.Empty;
            cbBed.Text = row.Cells["bed"]?.Value?.ToString() ?? string.Empty;
            cbType.Text = row.Cells["RoomType"]?.Value?.ToString() ?? string.Empty;
            txtPrice.Text = row.Cells["price"]?.Value != null
                ? Convert.ToInt64(row.Cells["price"].Value).ToString("N0")
                : "0";
            long moneyRoom = row.Cells["MoneyRoom"]?.Value != null ? Convert.ToInt64(row.Cells["MoneyRoom"].Value) : 0;
            txtMoneyRoom.Text = moneyRoom.ToString("N0");

            // Tính tiền đồ ăn dựa trên roomid
            int roomId = 0;
            if (row.Cells["roomid"]?.Value != null && int.TryParse(row.Cells["roomid"].Value.ToString(), out int parsedRoomId))
            {
                roomId = parsedRoomId;
            }
            long moneyFood = CalculateFoodCost(roomId);
            txtMoneyFood.Text = moneyFood.ToString("N0");

            // Tính tổng tiền
            long totalMoney = moneyRoom + moneyFood;
            txtTotalMoney.Text = totalMoney.ToString("N0");

            // Cập nhật trạng thái CheckBox
            bool checkoutStatus = false;
            if (row.Cells["checkout_status"]?.Value != null)
            {
                if (bool.TryParse(row.Cells["checkout_status"].Value.ToString(), out bool parsedStatus))
                    checkoutStatus = parsedStatus;
                else if (row.Cells["checkout_status"].Value is int intStatus)
                    checkoutStatus = intStatus != 0;
            }
            checkBoxThanhToan.Checked = checkoutStatus;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }
    }
}
