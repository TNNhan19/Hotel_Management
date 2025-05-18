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

namespace QuanLyHotel_WindowProgramming
{
    public partial class KiemTraGioLam : Form
    {
        private AttendanceManage attendanceManage = new AttendanceManage();
        My_DB db = new My_DB();
        public KiemTraGioLam()
        {
            InitializeComponent();
        }

        private void KiemTraGioLam_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHRID.Text))
            {
                MessageBox.Show("Please enter HR ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int hrId = Convert.ToInt32(txtHRID.Text);
            string role = attendanceManage.GetRoleFromHR(hrId);
            if (role == null)
            {
                MessageBox.Show("Invalid HR ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (attendanceManage.CheckIn(hrId, role))
            {
                txtCheckIn.Text = DateTime.Now.ToString("HH:mm dd/MM/yyyy");
                MessageBox.Show("Check In successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHRID.Text))
            {
                MessageBox.Show("Please enter HR ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int hrId = Convert.ToInt32(txtHRID.Text);
            if (attendanceManage.CheckOut(hrId))
            {
                txtCheckOut.Text = DateTime.Now.ToString("HH:mm dd/MM/yyyy");
                MessageBox.Show("Check Out successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            DataGridViewAttendance.DataSource = attendanceManage.GetAttendanceData();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHRID.Text) || string.IsNullOrWhiteSpace(txtCheckIn.Text) || string.IsNullOrWhiteSpace(txtCheckOut.Text))
            {
                MessageBox.Show("Please enter HR ID, Check In, and Check Out times.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!DateTime.TryParseExact(txtCheckIn.Text, "HH:mm dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime checkIn) ||
                !DateTime.TryParseExact(txtCheckOut.Text, "HH:mm dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime checkOut))
            {
                MessageBox.Show("Please use format HH:mm dd/MM/yyyy.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (checkIn >= checkOut)
            {
                MessageBox.Show("Check Out time must be after Check In time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int hrId = Convert.ToInt32(txtHRID.Text);
            string role = attendanceManage.GetRoleFromHR(hrId);
            if (role == null)
            {
                MessageBox.Show("Invalid HR ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Chèn dữ liệu vào bảng Attendance
            InsertAttendanceRecord(hrId, checkIn, checkOut, role);

            // Tải lại dữ liệu để hiển thị
            LoadDataGridView();

            // Tính toán và hiển thị kết quả
            double hours = (checkOut - checkIn).TotalHours;
            double salary = GetSalaryFromDatabase(hrId, checkIn, checkOut); // Lấy lương từ cơ sở dữ liệu
            MessageBox.Show($"Total Hours: {hours:F2}\nSalary: {salary:F2} VND", "Salary Calculation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void InsertAttendanceRecord(int hrId, DateTime checkIn, DateTime checkOut, string role)
        {
            My_DB db = new My_DB();
            string query = "INSERT INTO Attendance (hr_id, check_in, check_out, role) VALUES (@hr_id, @check_in, @check_out, @role)";
            using (SqlCommand cmd = new SqlCommand(query, db.getConnection))
            {
                cmd.Parameters.AddWithValue("@hr_id", hrId);
                cmd.Parameters.AddWithValue("@check_in", checkIn);
                cmd.Parameters.AddWithValue("@check_out", checkOut);
                cmd.Parameters.AddWithValue("@role", role);
                db.openConnection();
                cmd.ExecuteNonQuery();
                db.closeConnection();
            }

            // Cập nhật total_hours và salary
            attendanceManage.CalculateTotalHoursAndSalary(hrId);
        }
        private double CalculateSalary(double hours, string role)
        {
            double baseRate = role == "Quản Lý" ? 100 : role == "Tiếp Tân" ? 60 : role == "Lao Công" ? 40 : 0;
            double penalty = hours < 8 ? (8 - hours) * (role == "Quản Lý" ? 150 : role == "Tiếp Tân" ? 120 : role == "Lao Công" ? 80 : 0) : 0;
            return (hours * baseRate) - penalty;
        }
        private double GetSalaryFromDatabase(int hrId, DateTime checkIn, DateTime checkOut)
        {
            double salary = 0;
            My_DB db = new My_DB();
            try
            {
                string query = "SELECT salary FROM Attendance WHERE hr_id = @hrId AND check_in = @checkIn AND check_out = @checkOut";
                using (SqlCommand cmd = new SqlCommand(query, db.getConnection))
                {
                    cmd.Parameters.AddWithValue("@hrId", hrId);
                    cmd.Parameters.AddWithValue("@checkIn", checkIn);
                    cmd.Parameters.AddWithValue("@checkOut", checkOut);
                    db.openConnection();
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        salary = Convert.ToDouble(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving salary: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.closeConnection();
            }
            return salary;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                Title = "Export to PDF",
                FileName = "Attendance_Report_" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".pdf"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                DataTable dt = attendanceManage.GetAttendanceReport();
                attendanceManage.ExportToPDF(dt, saveFileDialog.FileName);
                MessageBox.Show("Report exported to PDF successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnGenerateSchedule_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            DataTable schedule = attendanceManage.GenerateWorkShiftAssignments(today);
            DataGridViewAttendance.DataSource = schedule;
        }
    }
}
