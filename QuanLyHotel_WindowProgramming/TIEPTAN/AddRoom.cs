using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHotel_WindowProgramming.TIEPTAN
{
    public partial class AddRoom : Form
    {
        Room room = new Room();
        String query;   
        public AddRoom()
        {
            InitializeComponent();
            //cbType.Items.Add("AC");
            //cbType.Items.Add("Single");
            //cbType.Items.Add("Couple");
            this.setTypeCB();
        }
        private void setTypeCB()
        {
            cbType.Items.Add("AC");
            cbType.Items.Add("Single");
            cbType.Items.Add("Couple");
        }

        private void AddRoom_Load(object sender, EventArgs e)
        {
            try
            {
                query = "select * from Room";
                DataSet ds = room.getData(query);

                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtRoomNo.Text != "" && cbType.Text != "" && txtBed.Text != "" && txtPrice.Text != "")
            {
                string roomNo = txtRoomNo.Text;
                string type = cbType.Text;
                string bed = txtBed.Text;
                string price = txtPrice.Text;

                // Câu lệnh SQL thêm phòng mới
                string query = "INSERT INTO Room (RoomNo, RoomType, bed, price) " +
                               $"VALUES ('{roomNo}', '{type}', '{bed}', '{price}')";

                // Gọi hàm thực thi câu lệnh
                room.setData(query, "Room Added Successfully!");

                // Sau khi thêm, làm mới DataGridView (tùy chọn)
                query = "SELECT * FROM Room";
                DataSet ds = room.getData(query);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Fill All Fields.", "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
