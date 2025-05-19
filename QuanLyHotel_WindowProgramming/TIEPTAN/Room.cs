using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHotel_WindowProgramming
{   
    class Room
    {
        protected SqlConnection getConnection()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HotelManagement;Integrated Security=True;Connect Timeout=30;Encrypt=False";
            return con;
        } 
        public DataSet getData(string query) // Get data from database
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public void setData(string query, string v) // Set data to database
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Thao tác thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public SqlDataReader getForCombo(string query)
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

    }
}
