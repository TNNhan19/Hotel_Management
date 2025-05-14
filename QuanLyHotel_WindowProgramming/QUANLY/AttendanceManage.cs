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
    }
}
