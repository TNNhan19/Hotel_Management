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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace QuanLyHotel_WindowProgramming
{
    public partial class LoginHotel : Form
    {
        public string SelectedRole { get; private set; }
        public LoginHotel()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register rg = new Register();
            rg.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!RadioButtonQuanLy.Checked && !RadioButtonTiepTan.Checked && !RadioButtonLaoCong.Checked)
            {
                MessageBox.Show("Please select a role (Student or Human Resource)", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác định role được chọn
            string selectedRole = "";
            if (RadioButtonQuanLy.Checked)
                selectedRole = "Quản Lý";
            else if (RadioButtonTiepTan.Checked)
                selectedRole = "Tiếp Tân";
            else if (RadioButtonLaoCong.Checked)
                selectedRole = "Lao Công";

            // Kiểm tra thông tin đăng nhập trong cơ sở dữ liệu
            My_DB db = new My_DB();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            // Truy vấn kiểm tra username, password và role
            SqlCommand command = new SqlCommand("SELECT * FROM login WHERE username = @User AND password = @Pass AND role = @Role", db.getConnection);
            command.Parameters.Add("@User", SqlDbType.VarChar).Value = txtDangNhap.Text;
            command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = txtMatKhau.Text;
            command.Parameters.Add("@Role", SqlDbType.NChar).Value = selectedRole;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            // Kiểm tra kết quả
            if (table.Rows.Count > 0)
            {
                SelectedRole = selectedRole;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Username, Password, or Role", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
