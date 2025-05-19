using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHotel_WindowProgramming
{
    internal class QuanLyNhanVien
    {
        My_DB mydb = new My_DB();

        // Function to insert a new student
        public bool insertHR(int Id, string fname, string lname, DateTime bdate,
                                  string gender, string phone, string address, string role, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand(
                "INSERT INTO HR (id, fname, lname, bdate, gender, phone , address, role, picture) " +
                "VALUES (@id, @fn, @ln, @bdt, @gdr, @phn, @adrs, @role, @pic)", mydb.getConnection);

            command.Parameters.Add("@id", SqlDbType.Int).Value = Id;
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@bdt", SqlDbType.Date).Value = bdate;
            command.Parameters.Add("@gdr", SqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@adrs", SqlDbType.VarChar).Value = address;
            command.Parameters.Add("@role", SqlDbType.VarChar).Value = role;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();

            mydb.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }
        // Lấy dữ liệu từ table đẩy vào DataGirdView
        public DataTable getHR(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public bool checkHR(int id)
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM HR WHERE id = @id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            mydb.openConnection();
            int count = (int)command.ExecuteScalar();
            mydb.closeConnection();

            return count > 0; // Trả về true nếu id đã tồn tại
        }
        public bool updateHR(int Id, string fname, string lname, DateTime bdate,
                                  string gender, string phone, string address, string role, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand(
                "UPDATE HR SET fname=@fn, lname = @ln, bdate = @bdt, gender = @gdr, phone = @phn, address = @adrs,role = @role, picture = @pic WHERE id = @ID", mydb.getConnection);

            command.Parameters.Add("@id", SqlDbType.Int).Value = Id;
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@bdt", SqlDbType.Date).Value = bdate;
            command.Parameters.Add("@gdr", SqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@adrs", SqlDbType.VarChar).Value = address;
            command.Parameters.Add("@role", SqlDbType.VarChar).Value = role;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();

            mydb.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }
        public bool deleteHR(int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM HR WHERE id = @id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            mydb.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }
        public int totalHR()
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM HR", mydb.getConnection);
            mydb.openConnection();
            int count = (int)command.ExecuteScalar();
            mydb.closeConnection();
            return count;
        }
    }
}
