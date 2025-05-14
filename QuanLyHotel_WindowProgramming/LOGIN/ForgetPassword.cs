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
    public partial class ForgetPassword : Form
    {
        string randomCode;
        public static string to;
        public ForgetPassword()
        {
            InitializeComponent();
        }

        private void btnSendCode_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("Please enter your email address", "Forget Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string from, pass, messageBody;
            Random rand = new Random();
            randomCode = (rand.Next(999999)).ToString();
            MailMessage message = new MailMessage();
            to = txtEmail.Text.Trim(); from = "tranquochuy26022005@gmail.com";// email của bạn
            pass = "njla peoo tore hrhr";// pass
            messageBody = "Code: " + randomCode;
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messageBody;
            message.Subject = "Password reseting code";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            try
            {
                smtp.Send(message);
                MessageBox.Show("Code send successfully", "Code",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRecover_Click(object sender, EventArgs e)
        {
            if (txtCode.Text.Trim() == "")
            {
                MessageBox.Show("Please enter your code", "Forget Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (randomCode == txtCode.Text.Trim())
            {
                My_DB db = new My_DB();
                db.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT password FROM login WHERE email = @email", db.getConnection);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                string password = cmd.ExecuteScalar() as string;

                if (password != null)
                {
                    MessageBox.Show("Verification successful!\nYour password is: " + password, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No account found with this email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                db.closeConnection();
            }
            else
            {
                MessageBox.Show("Wrong code", "Forget Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
