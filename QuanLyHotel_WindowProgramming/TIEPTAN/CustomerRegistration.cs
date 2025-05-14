using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHotel_WindowProgramming.TIEPTAN
{
    public partial class CustomerRegistration : Form
    {
        Room room = new Room();
        String query;
        public CustomerRegistration()
        {
            InitializeComponent();
        }

        private void CustomerRegistration_Load(object sender, EventArgs e)
        {

        }

        public void setComboBox(string query, ComboBox cb)
        {
            SqlDataReader dr = room.getForCombo(query);
            while (dr.Read())
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    cb.Items.Add(dr[i].ToString());
                }
            }
            dr.Close();
        }
        private void txtRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNoRoom.Items.Clear();
            query = "select RoomNo from Room where bed = '" + txtBed.Text + "'and RoomType'" + txtType.Text + "' and booked= 'NO'";

        }
        private void txtBed_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtType.SelectedIndex = -1;
            txtNoRoom.Items.Clear();
        }
        private void txtNoRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            query = "Select price, RoomId from Room where RoomNo = '+txtNoRoom.Text'";
            DataSet ds = room.getData(query);
            txtPrice.Text = ds.Tables[0].Rows[0][0].ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtPhone.Text != "" && txtNationality.Text != "" && txtGender.Text != "" && txtDob.Text != "" && txtCccd.Text != "" && txtAddress.Text != "" && txtCheckin.Text != "" && txtPrice.Text != "")
            {
                string name = txtName.Text;
                Int64 mobile = Int64.Parse(txtPhone.Text);
                String natinal = txtNationality.Text;
                String gender = txtGender.Text;
                String dob = txtDob.Text;
                String cccd = txtCccd.Text;
                String address = txtAddress.Text;
                String checkin = txtCheckin.Text;

                //query = "insert into customer  (CustomerName,Phone,Nationality,Gender,Dob, Cccd, Address, checkIn, roomId) values
                //    ("'+name+'", "'+Phone+'", "'+national+'", "'+gender+'", "'+dob+'", "'+idproof+'", "'+address+'", "'+checkin+'", "'+rid+'")" update rooms set booked;


            }
            else
            {
                MessageBox.Show("Fill All Fields.", "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
