using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyHotel_WindowProgramming
{
    public partial class FormShiftScheduler : Form
    {
        private List<ShiftItem> allShifts = new List<ShiftItem>();

        public FormShiftScheduler()
        {
            InitializeComponent();
        }

        private void FormShiftScheduler_Load(object sender, EventArgs e)
        {
            cbRole.Items.Clear();

            if (UserSession.Role.Trim() == "Quản Lý")
            {
                cbRole.Items.Add("Tất cả");
                cbRole.Items.Add("Tiếp tân");
                cbRole.Items.Add("Lao công");
                cbRole.Items.Add("Quản Lý");
                cbRole.Enabled = true;
            }
            else
            {
                cbRole.Items.Add(UserSession.Role);
                cbRole.Enabled = false;
            }

            cbRole.SelectedIndex = 0;
            cbRole.SelectedIndexChanged += (s, ev) => RefreshShiftGrid();
            dtpShiftDate.ValueChanged += (s, ev) => RefreshShiftGrid();

            LoadShiftFromDatabase();
            RefreshShiftGrid();
        }

        private void LoadShiftFromDatabase()
        {
            allShifts.Clear();

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM ShiftSchedule", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    allShifts.Add(new ShiftItem
                    {
                        ShiftId = Convert.ToInt32(reader["ShiftID"]),
                        Date = Convert.ToDateTime(reader["ShiftDate"]),
                        TimeSlot = reader["TimeSlot"].ToString(),
                        Role = reader["Role"].ToString(),
                        RequiredCount = Convert.ToInt32(reader["RequiredCount"]),
                        RegisteredEmployees = new List<string>()
                    });
                }

                reader.Close();

                foreach (var shift in allShifts)
                {
                    SqlCommand regCmd = new SqlCommand(@"
                        SELECT login.username 
                        FROM ShiftRegistration 
                        JOIN HR ON ShiftRegistration.EmployeeID = HR.Id 
                        JOIN login ON HR.LoginID = login.id 
                        WHERE ShiftID = @id", conn);

                    regCmd.Parameters.AddWithValue("@id", shift.ShiftId);
                    SqlDataReader regReader = regCmd.ExecuteReader();

                    while (regReader.Read())
                    {
                        shift.RegisteredEmployees.Add(regReader.GetString(0));
                    }

                    regReader.Close();
                }
            }
        }

        private void RefreshShiftGrid()
        {
            var selectedDate = dtpShiftDate.Value.Date;
            string selectedRole = cbRole.SelectedItem?.ToString();

            var filtered = allShifts.Where(s => s.Date == selectedDate);

            if (UserSession.Role != "Quản Lý")
            {
                filtered = filtered.Where(s => s.Role == UserSession.Role);
            }
            else
            {
                if (!string.IsNullOrEmpty(selectedRole) && selectedRole != "Tất cả")
                {
                    filtered = filtered.Where(s => s.Role == selectedRole);
                }
            }

            dgvShiftSchedule.DataSource = filtered.Select(s => new
            {
                Ngày = s.Date.ToShortDateString(),
                Ca = s.TimeSlot,
                VaiTrò = s.Role,
                SốLượngCần = s.RequiredCount,
                ĐãĐăngKý = s.RegisteredEmployees.Count,
                NgườiĐăngKý = string.Join(", ", s.RegisteredEmployees)
            }).ToList();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadShiftFromDatabase();
            RefreshShiftGrid();
        }

        private void btnRegisterShift_Click(object sender, EventArgs e)
        {
            if (dgvShiftSchedule.SelectedRows.Count == 0)
            {
                lblStatus.Text = "⚠ Vui lòng chọn 1 ca để đăng ký.";
                return;
            }

            var row = dgvShiftSchedule.SelectedRows[0];
            string timeSlot = row.Cells["Ca"].Value.ToString();
            string role = row.Cells["VaiTrò"].Value.ToString();
            DateTime date = DateTime.Parse(row.Cells["Ngày"].Value.ToString());

            var shift = allShifts.FirstOrDefault(s => s.Date == date && s.TimeSlot == timeSlot && s.Role == role);

            if (shift == null)
            {
                lblStatus.Text = "⚠ Không tìm thấy ca được chọn.";
                return;
            }

            if (shift.Role != UserSession.Role && UserSession.Role != "Quản lý")
            {
                lblStatus.Text = "⚠ Bạn chỉ có thể đăng ký ca đúng với vai trò của mình.";
                return;
            }

            if (shift.RegisteredEmployees.Contains(UserSession.Username))
            {
                lblStatus.Text = "⚠ Bạn đã đăng ký ca này rồi.";
                return;
            }

            if (shift.RegisteredEmployees.Count >= shift.RequiredCount)
            {
                lblStatus.Text = "⚠ Ca đã đủ người.";
                return;
            }

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                SqlCommand getIdCmd = new SqlCommand(@"
                    SELECT HR.Id 
                    FROM HR 
                    JOIN login ON HR.LoginID = login.id 
                    WHERE login.username = @u", conn);
                getIdCmd.Parameters.AddWithValue("@u", UserSession.Username);
                int empId = (int)getIdCmd.ExecuteScalar();

                SqlCommand insertCmd = new SqlCommand(
                    "INSERT INTO ShiftRegistration (ShiftID, EmployeeID) VALUES (@s, @e)", conn);
                insertCmd.Parameters.AddWithValue("@s", shift.ShiftId);
                insertCmd.Parameters.AddWithValue("@e", empId);
                insertCmd.ExecuteNonQuery();
            }

            lblStatus.Text = "✅ Đăng ký thành công.";
            LoadShiftFromDatabase();
            RefreshShiftGrid();
        }
        private void cbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshShiftGrid();
        }
        private void GenerateShiftsToDatabase()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                DateTime today = DateTime.Today;

                for (int i = 0; i < 14; i++) // Tạo ca cho 14 ngày
                {
                    DateTime date = today.AddDays(i);
                    bool isWeekend = date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;

                    // Ca ngày
                    InsertShift(conn, date, "07:00–19:00", "Tiếp tân", isWeekend ? 1 : 2);
                    InsertShift(conn, date, "07:00–19:00", "Lao công", isWeekend ? 3 : 4);
                    if (!isWeekend)
                        InsertShift(conn, date, "07:00–19:00", "Quản lý", 1);

                    // Ca đêm
                    InsertShift(conn, date, "20:00–06:00", "Tiếp tân", 1);
                    InsertShift(conn, date, "20:00–06:00", "Lao công", isWeekend ? 3 : 1);
                }

                MessageBox.Show("✅ Đã tạo dữ liệu ca làm mẫu thành công!");
            }
        }

        private void InsertShift(SqlConnection conn, DateTime date, string timeSlot, string role, int count)
        {
            // Kiểm tra nếu đã tồn tại thì bỏ qua
            SqlCommand checkCmd = new SqlCommand(@"
        SELECT COUNT(*) FROM ShiftSchedule 
        WHERE ShiftDate = @date AND TimeSlot = @slot AND Role = @role", conn);
            checkCmd.Parameters.AddWithValue("@date", date);
            checkCmd.Parameters.AddWithValue("@slot", timeSlot);
            checkCmd.Parameters.AddWithValue("@role", role);

            int exists = (int)checkCmd.ExecuteScalar();
            if (exists > 0) return;

            // Thêm mới
            SqlCommand insertCmd = new SqlCommand(@"
        INSERT INTO ShiftSchedule (ShiftDate, TimeSlot, Role, RequiredCount)
        VALUES (@date, @slot, @role, @count)", conn);
            insertCmd.Parameters.AddWithValue("@date", date);
            insertCmd.Parameters.AddWithValue("@slot", timeSlot);
            insertCmd.Parameters.AddWithValue("@role", role);
            insertCmd.Parameters.AddWithValue("@count", count);

            insertCmd.ExecuteNonQuery();
        }
        private void btnGenerateShifts_Click(object sender, EventArgs e)
        {
            GenerateShiftsToDatabase(); // Gọi hàm sinh ca làm
            LoadShiftFromDatabase();    // Load lại dữ liệu
            RefreshShiftGrid();         // Cập nhật hiển thị
        }

    }


}
