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
    public partial class RoomManagement : Form
    {
        private string connectionString;

        public RoomManagement()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvRooms.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn phòng cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!dgvRooms.Columns.Contains("RoomId"))
            {
                MessageBox.Show("Cột RoomId không tồn tại trong DataGridView. Vui lòng kiểm tra lại dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int roomId = Convert.ToInt32(dgvRooms.CurrentRow.Cells["RoomId"].Value);
            using (SqlConnection conn = Database.GetConnection())
            {
                try
                {
                    conn.Open();
                    // Loại bỏ cột booked khỏi câu lệnh UPDATE
                    string query = "UPDATE Room SET RoomNo=@RoomNo, RoomType=@RoomType, bed=@Bed, price=@Price WHERE RoomId=@RoomId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@RoomNo", txtRoomNo.Text);
                        cmd.Parameters.AddWithValue("@RoomType", txtRoomType.Text);
                        cmd.Parameters.AddWithValue("@Bed", txtBed.Text);
                        cmd.Parameters.AddWithValue("@Price", long.Parse(txtPrice.Text));
                        cmd.Parameters.AddWithValue("@RoomId", roomId);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Cập nhật phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRoomData();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Fix for CS0103: Adding the missing LoadRoomData method  
        private void LoadRoomData()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT RoomId, RoomNo, RoomType, bed, price, booked FROM Room";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Kiểm tra xem DataTable có chứa các cột cần thiết không
                    if (dataTable.Columns.Contains("RoomId") && dataTable.Columns.Contains("RoomNo") &&
                        dataTable.Columns.Contains("RoomType") && dataTable.Columns.Contains("bed") &&
                        dataTable.Columns.Contains("price") && dataTable.Columns.Contains("booked"))
                    {
                        dgvRooms.AutoGenerateColumns = false;
                        dgvRooms.Columns.Clear();

                        dgvRooms.Columns.Add(new DataGridViewTextBoxColumn()
                        {
                            DataPropertyName = "RoomId",
                            HeaderText = "Room ID",
                            Name = "RoomId" // Đặt Name để khớp với truy cập trong CellClick
                        });

                        dgvRooms.Columns.Add(new DataGridViewTextBoxColumn()
                        {
                            DataPropertyName = "RoomNo",
                            HeaderText = "Room Number",
                            Name = "RoomNo" // Đặt Name để khớp với truy cập trong CellClick
                        });

                        dgvRooms.Columns.Add(new DataGridViewTextBoxColumn()
                        {
                            DataPropertyName = "RoomType",
                            HeaderText = "Room Type",
                            Name = "RoomType"
                        });

                        dgvRooms.Columns.Add(new DataGridViewTextBoxColumn()
                        {
                            DataPropertyName = "bed",
                            HeaderText = "Bed Type",
                            Name = "bed"
                        });

                        dgvRooms.Columns.Add(new DataGridViewTextBoxColumn()
                        {
                            DataPropertyName = "price",
                            HeaderText = "Price",
                            DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" },
                            Name = "price"
                        });

                        dgvRooms.Columns.Add(new DataGridViewTextBoxColumn()
                        {
                            DataPropertyName = "booked",
                            HeaderText = "Status",
                            Name = "booked"
                        });

                        dgvRooms.DataSource = dataTable;
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu từ cơ sở dữ liệu thiếu các cột cần thiết!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void ClearForm()
        {
            txtRoomNo.Text = string.Empty;
            txtRoomType.Text = string.Empty;
            txtBed.Text = string.Empty;
            txtPrice.Text = string.Empty;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvRooms.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn phòng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!dgvRooms.Columns.Contains("RoomId"))
            {
                MessageBox.Show("Cột RoomId không tồn tại trong DataGridView. Vui lòng kiểm tra lại dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int roomId = Convert.ToInt32(dgvRooms.CurrentRow.Cells["RoomId"].Value);
            if (IsRoomInUse(roomId))
            {
                MessageBox.Show("Không thể xóa phòng này vì đang được sử dụng bởi khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa phòng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM Room WHERE RoomId = @RoomId";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@RoomId", roomId);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Xóa phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadRoomData();
                        ClearForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private bool IsRoomInUse(int roomId)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Customer WHERE RoomId = @RoomId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@RoomId", roomId);
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }


        
        private void RoomManagement_Load(object sender, EventArgs e)
        {
            LoadRoomData();
        }
        private void dgvRooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvRooms.Rows[e.RowIndex];
                txtRoomNo.Text = row.Cells["RoomNo"].Value?.ToString() ?? string.Empty;
                txtRoomType.Text = row.Cells["RoomType"].Value?.ToString() ?? string.Empty;
                txtBed.Text = row.Cells["bed"].Value?.ToString() ?? string.Empty;
                txtPrice.Text = row.Cells["price"].Value?.ToString() ?? string.Empty;
            }
        }
    }
}
