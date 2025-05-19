using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyHotel_WindowProgramming
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            cbRole.Items.Add("Quản Lý");
            cbRole.Items.Add("Tiếp Tân");
            cbRole.Items.Add("Lao Công");

            // Optionally, set a default selected item
            cbRole.SelectedIndex = 0;
            timerSendCode = new System.Windows.Forms.Timer();
            timerSendCode.Interval = 1000; // 1 giây
            timerSendCode.Tick += new EventHandler(timerSendCode_Tick); // Gắn sự kiện Tick
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        My_DB myDB = new My_DB();
        int time = 60;
        string randomCode;
        public static string to;
        private System.Windows.Forms.Timer timerSendCode; // Khai báo Timer

        private void btnSendCode_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("Please enter your email address", "Add Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (existEmail() == true)
            {
                MessageBox.Show("Email already used, please enter another email", "Add Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string from = "tranquochuy26022005@gmail.com"; // Thay bằng email của bạn
            string pass = "njla peoo tore hrhr";       // Thay bằng mật khẩu hoặc App Password của bạn
            Random rand = new Random();
            randomCode = (rand.Next(999999)).ToString();
            MailMessage message = new MailMessage();
            to = txtEmail.Text.Trim();
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = "Code: " + randomCode;
            message.Subject = "Account creation code";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            try
            {
                smtp.Send(message);
                MessageBox.Show("Code send successfully", "Code", MessageBoxButtons.OK, MessageBoxIcon.Information);
                timerSendCode.Enabled = true; // Bật timer
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool checkCode()
        {
            if (txtCode.Text.Trim() == "")
            {
                MessageBox.Show("Please enter your code", "Forget Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (randomCode == txtCode.Text.ToString())
            {
                to = txtEmail.Text;
                return true;
            }
            else
            {
                MessageBox.Show("Wrong code");
                return false;
            }
        }
        private void timerSendCode_Tick(object sender, EventArgs e)
        {
            if (time >= 0)
            {
                btnSendCode.Enabled = false;
                labelNotice.Text = "Resend code in " + time + " seconds";
                time--;
            }
            else
            {
                labelNotice.Text = "";
                time = 60;
                btnSendCode.Enabled = true;
                timerSendCode.Enabled = false;
            }
        }
        private bool checkInfor()
        {
            if (txtDangNhap.Text.Trim() == "" ||
                txtMatKhau.Text.Trim() == "" ||
                txtNhapLaiMK.Text.Trim() == "")
            {
                return false;
            }
            return true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            My_DB myDB = new My_DB();
            SqlCommand cmd = new SqlCommand("Insert into login (username, password, email, role) values (@us, @pass, @email, @role)", myDB.getConnection);
            cmd.Parameters.Add("@us", SqlDbType.Char).Value = txtDangNhap.Text;
            cmd.Parameters.Add("@pass", SqlDbType.Char).Value = txtMatKhau.Text;
            cmd.Parameters.Add("@email", SqlDbType.NChar).Value = txtEmail.Text;
            cmd.Parameters.Add("@role", SqlDbType.NChar).Value = cbRole.SelectedItem.ToString();
            if (checkInfor())
            {
                if (checkCode() == false)
                {
                    return;
                }
                if (txtMatKhau.Text != txtNhapLaiMK.Text)
                {
                    MessageBox.Show("Password authentication is wrong, please check again", "Create Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNhapLaiMK.Text = "";
                    return;
                }
                myDB.openConnection();
                if (checkUserExist(txtDangNhap.Text.Trim()) == false)
                {
                    MessageBox.Show("This username has already existed", "Create Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Account successfully created", "Create Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDangNhap.Text = "";
                    txtMatKhau.Text = "";
                    txtNhapLaiMK.Text = "";
                }
                else
                    MessageBox.Show("Registration error", "Create Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                myDB.closeConnection();
            }
            else
            {
                MessageBox.Show("Please do not leave information blank", "Create Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private bool checkUserExist(string usn)
        {
            My_DB db = new My_DB();
            db.openConnection();
            SqlCommand cmd = new SqlCommand("Select * from login where username =@username", db.getConnection);

            cmd.Parameters.Add("@username", SqlDbType.NChar).Value = usn;
            var result = cmd.ExecuteReader();
            if (result.HasRows)
            {
                db.closeConnection();
                return false;
            }
            db.closeConnection();
            return true;
        }
        private bool existEmail()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select * from login where email = '" + txtEmail.Text.Trim() + "'", myDB.getConnection);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable tb = new DataTable();
                adapter.Fill(tb);
                if (tb.Rows.Count > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "Add Account",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }
    }
}
