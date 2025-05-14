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
    public partial class MainForm_TiepTan : Form
    {
        public MainForm_TiepTan()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonAddRoom_Click(object sender, EventArgs e)
        {
            AddRoom addRoomForm = new AddRoom(); // Tạo đối tượng form
            addRoomForm.ShowDialog();
        }

        private void MainForm_TiepTan_Load(object sender, EventArgs e)
        {

        }

        private void buttonDkyCustomer_Click(object sender, EventArgs e)
        {
            CustomerRegistration customerForm = new CustomerRegistration(); // Tạo đối tượng form
            customerForm.ShowDialog();
        }

        private void btnManagementRoom_Click(object sender, EventArgs e)
        {
            RoomManagement roomForm = new RoomManagement(); // Tạo đối tượng form
            roomForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomerManagementForm customerManagementForm = new CustomerManagementForm(); // Tạo đối tượng form
            customerManagementForm.ShowDialog();
        }

        private void btnFoodManagement_Click(object sender, EventArgs e)
        {
            FoodManagement foodManagement = new FoodManagement(); // Tạo đối tượng form
                foodManagement.ShowDialog();
        }
    }
}
