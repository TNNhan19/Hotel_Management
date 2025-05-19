using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QuanLyHotel_WindowProgramming.TIEPTAN
{
    public partial class FoodEditForm : Form
    {
        private int foodId = -1;

        public FoodEditForm()
        {
            InitializeComponent();
            this.Text = "Thêm món ăn";
        }

        public FoodEditForm(int id, string name, string unit, long price)
        {
            InitializeComponent();
            this.Text = "Sửa món ăn";
            foodId = id;
            txtName.Text = name;
            txtUnit.Text = unit;
            txtPrice.Text = price.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string unit = txtUnit.Text.Trim();
            if (!long.TryParse(txtPrice.Text.Trim(), out long price))
            {
                MessageBox.Show("Giá không hợp lệ");
                return;
            }

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                if (foodId == -1)
                {
                    // Thêm mới
                    SqlCommand cmd = new SqlCommand("INSERT INTO Food (FoodName, Unit, Price) VALUES (@name, @unit, @price)", conn);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@unit", unit);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    // Cập nhật
                    SqlCommand cmd = new SqlCommand("UPDATE Food SET FoodName=@name, Unit=@unit, Price=@price WHERE FoodId=@id", conn);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@unit", unit);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@id", foodId);
                    cmd.ExecuteNonQuery();
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
