using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyHotel_WindowProgramming
{
    public partial class QuanLyNhanVien_ThemXoaSua : Form
    {
        QuanLyNhanVien qlnv = new QuanLyNhanVien();
        private int? IdHR;
        private string firstNameHR;
        private string lastNameHR;
        public QuanLyNhanVien_ThemXoaSua()
        {
            InitializeComponent();
            cbRole.Items.Add("Quản Lý");
            cbRole.Items.Add("Tiếp Tân");
            cbRole.Items.Add("Lao Công");
        }

        private void QuanLyNhanVien_ThemXoaSua_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hotelManagementDataSet.HR' table. You can move, or remove it, as needed.
            this.hRTableAdapter.Fill(this.hotelManagementDataSet.HR);
            lbTotalHR.Text = "Total HR: " + qlnv.totalHR();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM HR");
            DataGridViewHR.ReadOnly = true;

            // Xử lý hình ảnh, code tham khảo MSDN
            DataGridViewImageColumn picCol = new DataGridViewImageColumn(); // Đối tượng làm việc với picture của DataGridView
            DataGridViewHR.RowTemplate.Height = 80; // Dòng này tham khảo trên MSDN ngày 10/03/2019, có giãn để pic đẹp, đang tìm auto-size
            DataGridViewHR.DataSource = qlnv.getHR(command);
            picCol = (DataGridViewImageColumn)DataGridViewHR.Columns[8];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            DataGridViewHR.AllowUserToAddRows = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);
            string fname = txtFirstName.Text;
            string lname = txtLastName.Text;
            DateTime bdate = DateTimePicker.Value;
            string phone = txtPhone.Text;
            string adrs = txtAddress.Text;
            string role = cbRole.Text;
            string gender = "Male";

            if (RadioButtonFemale.Checked)
            {
                gender = "Female";
            }

            MemoryStream pic = new MemoryStream();
            int born_year = DateTimePicker.Value.Year;
            int this_year = DateTime.Now.Year;
            // Kiểm tra nếu first name hoặc last name chứa số
            if (fname.Any(char.IsDigit) || lname.Any(char.IsDigit))
            {
                MessageBox.Show("First name or last name cannot contain numbers.", "Invalid Name",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Dừng thực thi nếu phát hiện lỗi
            }
            if (qlnv.checkHR(id)) // Kiểm tra ID trùng lặp
            {
                MessageBox.Show("ID bị trùng lặp", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Kiểm tra nếu số điện thoại chứa ký tự không phải số
            if (!phone.All(char.IsDigit) || phone.Length != 10)
            {
                MessageBox.Show("Phone number must contain exactly 10 digits.", "Invalid Phone",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Dừng thực thi nếu phát hiện lỗi
            }
            // Student age must be between 10 and 100 years
            if (((this_year - born_year) < 10) || ((this_year - born_year) > 100))
            {
                MessageBox.Show("The Member Age Must Be Between 10 and 100 years", "Invalid Birth Date",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (verif())
            {
                PictureBox.Image.Save(pic, PictureBox.Image.RawFormat);
                if (qlnv.insertHR(id, fname, lname, bdate, gender, phone, adrs,role, pic))
                {
                    MessageBox.Show("New member added", "Add Member",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Error", "Add Member", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty Fields", "Add Member",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        bool verif()
        {
            if ((txtFirstName.Text.Trim() == "")
                || (txtLastName.Text.Trim() == "")
                || (txtAddress.Text.Trim() == "")
                || (txtPhone.Text.Trim() == "")
                || (cbRole.Text.Trim() == "")
                || (txtID.Text.Trim() == "")
                || (PictureBox.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtID.Text.Trim(), out int memberId))
            {
                MessageBox.Show("Please enter a valid numeric ID", "Delete member", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // display a confirmation before the delete
            if (MessageBox.Show("Are you sure you want to delete this member", "Delete member", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (qlnv.deleteHR(memberId))
                {
                    MessageBox.Show("Member Deleted", "Delete member", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields(); // dọn form sau khi xóa
                    btnRefresh_Click(null, null); // cập nhật bảng
                }
                else
                {
                    MessageBox.Show("Member Not Deleted", "Delete member", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //int id;
            string fname = txtFirstName.Text;
            string lname = txtLastName.Text;
            DateTime bdate = DateTimePicker.Value;
            string phone = txtPhone.Text;
            string adrs = txtAddress.Text;
            string role = cbRole.Text;
            string gender = "Male";

            if (RadioButtonFemale.Checked)
            {
                gender = "Female";
            }

            MemoryStream pic = new MemoryStream();
            int born_year = DateTimePicker.Value.Year;
            int this_year = DateTime.Now.Year;
            // Kiểm tra nếu first name hoặc last name chứa số
            if (fname.Any(char.IsDigit) || lname.Any(char.IsDigit))
            {
                MessageBox.Show("First name or last name cannot contain numbers.", "Invalid Name",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Dừng thực thi nếu phát hiện lỗi
            }
            // Kiểm tra nếu số điện thoại chứa ký tự không phải số
            if (!phone.All(char.IsDigit) || phone.Length != 10)
            {
                MessageBox.Show("Phone number must contain exactly 10 digits.", "Invalid Phone",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Dừng thực thi nếu phát hiện lỗi
            }
            // member age must be between 10 and 100 years
            if (((this_year - born_year) < 10) || ((this_year - born_year) > 100))
            {
                MessageBox.Show("The member Age Must Be Between 10 and 100 years", "Invalid Birth Date",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (verif())
            {
                try
                {
                    int id = Convert.ToInt32(txtID.Text);
                    PictureBox.Image.Save(pic, PictureBox.Image.RawFormat);
                    if (qlnv.updateHR(id, fname, lname, bdate, gender, phone, adrs,role, pic))
                    {
                        MessageBox.Show("Member Infor Updated", "edit Member",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Edit Member", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Edit Member", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Empty Fields", "Edit Member",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Please enter an ID to search.", "Find Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int id = Convert.ToInt32(txtID.Text);
                My_DB db = new My_DB(); // Giả sử My_DB là lớp kết nối cơ sở dữ liệu của bạn
                SqlCommand command = new SqlCommand("SELECT * FROM HR WHERE id = @Id", db.getConnection);
                command.Parameters.AddWithValue("@Id", id);

                db.openConnection();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // Điền thông tin vào các ô TextBox và điều khiển
                    txtFirstName.Text = reader["fname"].ToString();
                    txtLastName.Text = reader["lname"].ToString();
                    DateTimePicker.Value = Convert.ToDateTime(reader["bdate"]);
                    txtPhone.Text = reader["phone"].ToString();
                    txtAddress.Text = reader["address"].ToString();
                    cbRole.Text = reader["role"].ToString();

                    // Điền giới tính
                    string gender = reader["gender"].ToString();
                    RadioButtonMale.Checked = (gender == "Male");
                    RadioButtonFemale.Checked = (gender == "Female");

                    // Điền hình ảnh
                    if (!reader.IsDBNull(reader.GetOrdinal("picture")))
                    {
                        byte[] pic = (byte[])reader["picture"];
                        MemoryStream ms = new MemoryStream(pic);
                        PictureBox.Image = Image.FromStream(ms);
                    }
                    else
                    {
                        PictureBox.Image = null;
                    }
                }
                else
                {
                    MessageBox.Show("No record found with the given ID.", "Find Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    // Xóa dữ liệu trong các ô nếu không tìm thấy
                    ClearFields();
                }

                reader.Close();
                db.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Find Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearFields()
        {
            txtID.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            DateTimePicker.Value = DateTime.Now;
            txtPhone.Text = "";
            txtAddress.Text = "";
            cbRole.Text = "";
            RadioButtonMale.Checked = true; // Đặt mặc định là Male
            RadioButtonFemale.Checked = false;
            PictureBox.Image = null;
        }

        private void btnUpLoadPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                PictureBox.Image = Image.FromFile(opf.FileName);
            }
        }
    }
}
