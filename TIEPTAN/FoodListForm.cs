using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyHotel_WindowProgramming.TIEPTAN
{
    public partial class FoodListForm : Form
    {
        public FoodListForm()
        {
            InitializeComponent();
        }

        private void FoodListForm_Load(object sender, EventArgs e)
        {
            LoadFoodData();
        }

        private void LoadFoodData()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT FoodId, FoodName, Unit, Price FROM Food", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewFoodList.DataSource = dt;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new FoodEditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadFoodData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewFoodList.CurrentRow != null)
            {
                int foodId = Convert.ToInt32(dataGridViewFoodList.CurrentRow.Cells["FoodId"].Value);
                string foodName = dataGridViewFoodList.CurrentRow.Cells["FoodName"].Value.ToString();
                string unit = dataGridViewFoodList.CurrentRow.Cells["Unit"].Value.ToString();
                long price = Convert.ToInt64(dataGridViewFoodList.CurrentRow.Cells["Price"].Value);

                var form = new FoodEditForm(foodId, foodName, unit, price);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadFoodData();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewFoodList.CurrentRow != null)
            {
                int foodId = Convert.ToInt32(dataGridViewFoodList.CurrentRow.Cells["FoodId"].Value);

                var confirm = MessageBox.Show("Bạn có chắc muốn xóa món này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    using (SqlConnection conn = Database.GetConnection())
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM Food WHERE FoodId = @id", conn);
                        cmd.Parameters.AddWithValue("@id", foodId);
                        cmd.ExecuteNonQuery();
                    }
                    LoadFoodData();
                }
            }
        }
    }
}
