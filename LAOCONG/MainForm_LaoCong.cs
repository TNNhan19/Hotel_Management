using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyHotel_WindowProgramming.TIEPTAN;

namespace QuanLyHotel_WindowProgramming
{
    public partial class MainForm_LaoCong : Form
    {
        public MainForm_LaoCong()
        {
            InitializeComponent();
        }

        private void btnShift_Click(object sender, EventArgs e)
        {
            FormShiftScheduler formShiftScheduler = new FormShiftScheduler();
            formShiftScheduler.Show();
        }

        private void MainForm_LaoCong_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Hi, " + UserSession.Username;

        }

        private void btnCheckFood_Click(object sender, EventArgs e)
        {
            StaffCheckForm staffCheckForm = new StaffCheckForm(); // Tạo đối tượng form
            staffCheckForm.ShowDialog();
        }
    }
}
