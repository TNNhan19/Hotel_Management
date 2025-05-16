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
            this.setBedCB();
        }
        private void setTypeCB()
        {
            cbType.Items.Add("Standard");
            cbType.Items.Add("Superior");
            cbType.Items.Add("Deluxe");
            cbType.Items.Add("Suite");
        }
        private void setBedCB()
        {
            cbBed.Items.Add("Single");
            cbBed.Items.Add("Double");
            cbBed.Items.Add("Triple");
        }
        private void AddRoom_Load(object sender, EventArgs e)
        {
            try
            {
                query = "SELECT * FROM Room";
                DataSet ds = room.getData(query);

                // Clear existing columns
                dataGridView1.Columns.Clear();

                // Manually define columns with custom headers
                dataGridView1.AutoGenerateColumns = false;

                // Add columns with custom header text
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "RoomId",
                    HeaderText = "Room ID"
                });

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "RoomNo",
                    HeaderText = "Room Number"
                });

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "RoomType",
                    HeaderText = "Type"
                });

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "bed",
                    HeaderText = "Bed type"
                });

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "price",
                    HeaderText = "Price"
                });

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "booked",
                    HeaderText = "Status"
                });

                // Bind data
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (txtRoomNo.Text != "" && cbType.Text != "" && cbBed.Text != "" && txtPrice.Text != "")
            {
                string roomNo = txtRoomNo.Text;
                string type = cbType.Text;
                string bed = cbBed.Text;
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
