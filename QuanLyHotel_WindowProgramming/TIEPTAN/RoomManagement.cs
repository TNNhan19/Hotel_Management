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
            if (dgvRooms.CurrentRow != null)
            {
                int roomId = Convert.ToInt32(dgvRooms.CurrentRow.Cells["RoomId"].Value);

                using (SqlConnection conn = Database.GetConnection())
                {
                    string query = "UPDATE Room SET RoomNo=@RoomNo, RoomType=@RoomType, bed=@Bed, price=@Price, booked=@Booked WHERE RoomId=@RoomId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@RoomNo", txtRoomNo.Text);
                    cmd.Parameters.AddWithValue("@RoomType", txtRoomType.Text);
                    cmd.Parameters.AddWithValue("@Bed", txtBed.Text);  
                    cmd.Parameters.AddWithValue("@Price", long.Parse(txtPrice.Text));
                    cmd.Parameters.AddWithValue("@Booked", cmbBooked.SelectedItem.ToString());  
                    cmd.Parameters.AddWithValue("@RoomId", roomId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Cập nhật phòng thành công!");
                    LoadRoomData();
                    ClearForm();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phòng cần sửa!");
            }
        }

        // Fix for CS0103: Adding the missing LoadRoomData method  
        private void LoadRoomData()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Room";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgvRooms.DataSource = dataTable;
            }
            
        }

        // Fix for CS0103: Adding the missing ClearForm method  
        private void ClearForm()
        {
            txtRoomNo.Text = string.Empty;
            txtRoomType.Text = string.Empty;
            txtPrice.Text = string.Empty;
            // Uncomment and adjust the following lines if these controls exist in your form  
            // txtBed.Text = string.Empty;  
            // cmbBooked.SelectedIndex = -1;  
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvRooms.CurrentRow != null)
            {
                int roomId = Convert.ToInt32(dgvRooms.CurrentRow.Cells["RoomId"].Value);

                // Kiểm tra xem phòng này có đang được sử dụng không
                if (IsRoomInUse(roomId))
                {
                    MessageBox.Show("Không thể xóa phòng này vì đang được sử dụng bởi khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa phòng này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    using (SqlConnection conn = Database.GetConnection())
                    {
                        string query = "DELETE FROM Room WHERE RoomId = @RoomId";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@RoomId", roomId);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        MessageBox.Show("Xóa phòng thành công!");
                        LoadRoomData();
                        ClearForm();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phòng cần xóa!");
            }
        }

        private bool IsRoomInUse(int roomId)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM Customer WHERE RoomId = @RoomId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@RoomId", roomId);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                conn.Close();

                return count > 0;
            }
        }


        private void dgvRooms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvRooms.Rows[e.RowIndex];

                txtRoomNo.Text = row.Cells["RoomNo"].Value.ToString();
                txtRoomType.Text = row.Cells["RoomType"].Value.ToString();
                txtBed.Text = row.Cells["bed"].Value.ToString();
                txtPrice.Text = row.Cells["price"].Value.ToString();
                cmbBooked.SelectedItem = row.Cells["booked"].Value.ToString();
            }
        }
        private void RoomManagement_Load(object sender, EventArgs e)
        {
            cmbBooked.SelectedIndex = 0; // hoặc cmbStatus nếu bạn giữ tên cũ
            LoadRoomData();
        }
        private void dgvRooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvRooms.Rows[e.RowIndex];
                txtRoomNo.Text = row.Cells["RoomNo"].Value.ToString();
                txtRoomType.Text = row.Cells["RoomType"].Value.ToString();
                txtBed.Text = row.Cells["bed"].Value.ToString();
                txtPrice.Text = row.Cells["price"].Value.ToString();
                cmbBooked.SelectedItem = row.Cells["booked"].Value.ToString();
            }
        }
    }
}
