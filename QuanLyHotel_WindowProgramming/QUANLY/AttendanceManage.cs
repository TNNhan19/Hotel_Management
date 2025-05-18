using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using System.ComponentModel;
using System.IO;
using System.Xml.Linq;


namespace QuanLyHotel_WindowProgramming
{
    internal class AttendanceManage
    {
        My_DB db = new My_DB();

        public bool CheckIn(int hrId, string role)
        {
            string query = "INSERT INTO Attendance (hr_id, check_in, role) VALUES (@hr_id, @check_in, @role)";
            using (SqlCommand cmd = new SqlCommand(query, db.getConnection))
            {
                cmd.Parameters.AddWithValue("@hr_id", hrId);
                cmd.Parameters.AddWithValue("@check_in", DateTime.Now);
                cmd.Parameters.AddWithValue("@role", role);
                db.openConnection();
                int result = cmd.ExecuteNonQuery();
                db.closeConnection();
                return result > 0;
            }
        }

        public bool CheckOut(int hrId)
        {
            string query = "UPDATE Attendance SET check_out = @check_out WHERE hr_id = @hr_id AND check_out IS NULL";
            using (SqlCommand cmd = new SqlCommand(query, db.getConnection))
            {
                cmd.Parameters.AddWithValue("@check_out", DateTime.Now);
                cmd.Parameters.AddWithValue("@hr_id", hrId);
                db.openConnection();
                int result = cmd.ExecuteNonQuery();
                db.closeConnection();
                if (result > 0)
                {
                    CalculateTotalHoursAndSalary(hrId);
                }
                return result > 0;
            }
        }

        public void CalculateTotalHoursAndSalary(int hrId)
        {
            string query = @"
                UPDATE Attendance
                SET total_hours = DATEDIFF(HOUR, check_in, check_out),
                    salary = CASE 
                        WHEN role = 'Quản Lý' THEN (DATEDIFF(HOUR, check_in, check_out) * 100) - 
                            (CASE WHEN DATEDIFF(HOUR, check_in, check_out) < 8 THEN (8 - DATEDIFF(HOUR, check_in, check_out)) * 150 ELSE 0 END)
                        WHEN role = 'Tiếp Tân' THEN (DATEDIFF(HOUR, check_in, check_out) * 60) - 
                            (CASE WHEN DATEDIFF(HOUR, check_in, check_out) < 8 THEN (8 - DATEDIFF(HOUR, check_in, check_out)) * 120 ELSE 0 END)
                        WHEN role = 'Lao Công' THEN (DATEDIFF(HOUR, check_in, check_out) * 40) - 
                            (CASE WHEN DATEDIFF(HOUR, check_in, check_out) < 8 THEN (8 - DATEDIFF(HOUR, check_in, check_out)) * 80 ELSE 0 END)
                        ELSE 0
                    END
                WHERE hr_id = @hr_id AND check_out IS NOT NULL";
            using (SqlCommand cmd = new SqlCommand(query, db.getConnection))
            {
                cmd.Parameters.AddWithValue("@hr_id", hrId);
                db.openConnection();
                cmd.ExecuteNonQuery();
                db.closeConnection();
            }
        }

        public DataTable GetAttendanceData()
        {
            string query = "SELECT * FROM Attendance";
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, db.getConnection))
            {
                DataTable dt = new DataTable();
                db.openConnection();
                adapter.Fill(dt);
                db.closeConnection();
                return dt;
            }
        }
        public string GetRoleFromHR(int hrId)
        {
            string role = null;
            My_DB db = new My_DB();
            try
            {
                string query = "SELECT role FROM HR WHERE id = @hrId";
                using (SqlCommand cmd = new SqlCommand(query, db.getConnection))
                {
                    cmd.Parameters.AddWithValue("@hrId", hrId);
                    db.openConnection(); // Mở kết nối
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        role = result.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving role: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.closeConnection(); // Đảm bảo đóng kết nối
            }
            return role;
        }





        public DataTable GetAttendanceReport()
        {
            string query = "SELECT * FROM Attendance";
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, db.getConnection))
            {
                DataTable dt = new DataTable();
                db.openConnection();
                adapter.Fill(dt);
                db.closeConnection();
                return dt;
            }
        }

        public void ExportToPDF(DataTable dt, string filePath)
        {
            Document document = new Document();
            PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
            document.Open();

            // Thêm tiêu đề
            Paragraph title = new Paragraph("Attendance Report - " + DateTime.Now.ToString("dd/MM/yyyy"));
            title.Alignment = Element.ALIGN_CENTER;
            document.Add(title);

            // Thêm bảng
            PdfPTable pdfTable = new PdfPTable(dt.Columns.Count);
            pdfTable.WidthPercentage = 100;

            // Thêm tiêu đề cột
            foreach (DataColumn column in dt.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName));
                pdfTable.AddCell(cell);
            }

            // Thêm dữ liệu
            foreach (DataRow row in dt.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    pdfTable.AddCell(item.ToString());
                }
            }

            document.Add(pdfTable);
            document.Close();
        }
        public DataTable GenerateWorkShiftAssignments(DateTime date)
        {
            DataTable schedule = new DataTable();
            schedule.Columns.Add("hr_id", typeof(int));
            schedule.Columns.Add("fname", typeof(string));
            schedule.Columns.Add("lname", typeof(string));
            schedule.Columns.Add("role", typeof(string));
            schedule.Columns.Add("check_in", typeof(DateTime));
            schedule.Columns.Add("check_out", typeof(DateTime));

            Dictionary<string, int> dayShiftNeeds = new Dictionary<string, int> { { "Tiếp Tân", 2 }, { "Quản Lý", 1 }, { "Lao Công", 4 } };
            Dictionary<string, int> nightShiftNeeds = new Dictionary<string, int> { { "Tiếp Tân", 1 }, { "Lao Công", 1 } };
            Dictionary<string, int> weekendShiftNeeds = new Dictionary<string, int> { { "Tiếp Tân", 1 }, { "Lao Công", 3 } };

            bool isWeekend = date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
            var shiftNeeds = isWeekend ? weekendShiftNeeds : nightShiftNeeds;

            var allHR = new List<(int id, string fname, string lname, string role)>();

            using (SqlCommand cmd = new SqlCommand("SELECT Id, fname, lname, role FROM HR", db.getConnection))
            {
                db.openConnection();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        allHR.Add((
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3).Trim()
                        ));
                    }
                }
                db.closeConnection();
            }

            // Ca ngày: 7h–19h
            if (!isWeekend)
            {
                DateTime checkIn = date.Date.AddHours(7);
                DateTime checkOut = date.Date.AddHours(19);

                foreach (var role in dayShiftNeeds.Keys)
                {
                    var available = allHR.Where(hr => hr.role == role).Take(dayShiftNeeds[role]).ToList();
                    foreach (var hr in available)
                    {
                        schedule.Rows.Add(hr.id, hr.fname, hr.lname, hr.role, checkIn, checkOut);
                    }
                }
            }

            // Ca đêm: 20h hôm nay đến 6h hôm sau
            {
                DateTime nightIn = date.Date.AddHours(20);
                DateTime nightOut = date.Date.AddDays(1).AddHours(6);

                foreach (var role in shiftNeeds.Keys)
                {
                    // Nếu cần 1 Tiếp Tân hoặc Quản Lý — chọn từ 2 nhóm gộp
                    List<(int id, string fname, string lname, string role)> available;
                    if (role == "Tiếp Tân")
                        available = allHR.Where(hr => hr.role == "Tiếp Tân" || hr.role == "Quản Lý").ToList();
                    else
                        available = allHR.Where(hr => hr.role == role).ToList();

                    foreach (var hr in available.Take(shiftNeeds[role]))
                    {
                        schedule.Rows.Add(hr.id, hr.fname, hr.lname, hr.role, nightIn, nightOut);
                    }
                }
            }

            return schedule;
        }
    }
}
