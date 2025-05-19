using System.Windows.Forms;

namespace QuanLyHotel_WindowProgramming.TIEPTAN
{
    public partial class FoodManagement : Form
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboBoxRoom;
        private System.Windows.Forms.DataGridView dataGridViewFood;
        private System.Windows.Forms.Button btnAddFood;
        private System.Windows.Forms.Button btnRemoveFood;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCheckDeviation;
        private System.Windows.Forms.Label labelRoom;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelNote;

        private System.Windows.Forms.DataGridViewTextBoxColumn colFoodName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantityIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantityOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeviation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsageDate;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FoodManagement));
            this.comboBoxRoom = new System.Windows.Forms.ComboBox();
            this.labelRoom = new System.Windows.Forms.Label();
            this.dataGridViewFood = new System.Windows.Forms.DataGridView();
            this.FoodName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantityIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantityOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Deviation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsageDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddFood = new System.Windows.Forms.Button();
            this.btnRemoveFood = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCheckDeviation = new System.Windows.Forms.Button();
            this.labelNote = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFood)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxRoom
            // 
            this.comboBoxRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRoom.FormattingEnabled = true;
            this.comboBoxRoom.Location = new System.Drawing.Point(12, 69);
            this.comboBoxRoom.Name = "comboBoxRoom";
            this.comboBoxRoom.Size = new System.Drawing.Size(150, 21);
            this.comboBoxRoom.TabIndex = 0;
            // 
            // labelRoom
            // 
            this.labelRoom.AutoSize = true;
            this.labelRoom.BackColor = System.Drawing.Color.Silver;
            this.labelRoom.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.labelRoom.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelRoom.Location = new System.Drawing.Point(12, 23);
            this.labelRoom.Name = "labelRoom";
            this.labelRoom.Size = new System.Drawing.Size(109, 21);
            this.labelRoom.TabIndex = 1;
            this.labelRoom.Text = "Chọn phòng:";
            // 
            // dataGridViewFood
            // 
            this.dataGridViewFood.AllowUserToAddRows = false;
            this.dataGridViewFood.BackgroundColor = System.Drawing.Color.Cornsilk;
            this.dataGridViewFood.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFood.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FoodName,
            this.QuantityIn,
            this.QuantityOut,
            this.Deviation,
            this.TotalPrice,
            this.UsageDate});
            this.dataGridViewFood.Location = new System.Drawing.Point(186, 23);
            this.dataGridViewFood.Name = "dataGridViewFood";
            this.dataGridViewFood.RowHeadersWidth = 51;
            this.dataGridViewFood.Size = new System.Drawing.Size(770, 298);
            this.dataGridViewFood.TabIndex = 2;
            this.dataGridViewFood.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewFood_CellContentClick);
            // 
            // FoodName
            // 
            this.FoodName.HeaderText = "Tên thực phẩm";
            this.FoodName.Name = "FoodName";
            this.FoodName.Width = 125;
            // 
            // QuantityIn
            // 
            this.QuantityIn.HeaderText = "Số lượng nhập";
            this.QuantityIn.Name = "QuantityIn";
            this.QuantityIn.Width = 125;
            // 
            // QuantityOut
            // 
            this.QuantityOut.HeaderText = "Số lượng tiêu thụ";
            this.QuantityOut.Name = "QuantityOut";
            this.QuantityOut.Width = 125;
            // 
            // Deviation
            // 
            this.Deviation.HeaderText = "Sai lệch (%)";
            this.Deviation.Name = "Deviation";
            this.Deviation.Width = 125;
            // 
            // TotalPrice
            // 
            this.TotalPrice.HeaderText = "Tổng tiền (VND)";
            this.TotalPrice.Name = "TotalPrice";
            this.TotalPrice.Width = 125;
            // 
            // UsageDate
            // 
            this.UsageDate.HeaderText = "Ngày thêm ";
            this.UsageDate.Name = "UsageDate";
            this.UsageDate.Width = 120;
            // 
            // btnAddFood
            // 
            this.btnAddFood.BackColor = System.Drawing.Color.Gold;
            this.btnAddFood.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.btnAddFood.Location = new System.Drawing.Point(974, 78);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Size = new System.Drawing.Size(120, 53);
            this.btnAddFood.TabIndex = 3;
            this.btnAddFood.Text = "+ Thêm thực phẩm";
            this.btnAddFood.UseVisualStyleBackColor = false;
            this.btnAddFood.Click += new System.EventHandler(this.btnAddFood_Click);
            // 
            // btnRemoveFood
            // 
            this.btnRemoveFood.BackColor = System.Drawing.Color.PeachPuff;
            this.btnRemoveFood.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.btnRemoveFood.Location = new System.Drawing.Point(974, 146);
            this.btnRemoveFood.Name = "btnRemoveFood";
            this.btnRemoveFood.Size = new System.Drawing.Size(120, 49);
            this.btnRemoveFood.TabIndex = 4;
            this.btnRemoveFood.Text = "Xóa dòng";
            this.btnRemoveFood.UseVisualStyleBackColor = false;
            this.btnRemoveFood.Click += new System.EventHandler(this.btnRemoveFood_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.PaleGreen;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(186, 376);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(179, 88);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Lưu dữ liệu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCheckDeviation
            // 
            this.btnCheckDeviation.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnCheckDeviation.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.btnCheckDeviation.Location = new System.Drawing.Point(549, 376);
            this.btnCheckDeviation.Name = "btnCheckDeviation";
            this.btnCheckDeviation.Size = new System.Drawing.Size(191, 88);
            this.btnCheckDeviation.TabIndex = 6;
            this.btnCheckDeviation.Text = "Kiểm tra sai số";
            this.btnCheckDeviation.UseVisualStyleBackColor = false;
            this.btnCheckDeviation.Click += new System.EventHandler(this.btnCheckDeviation_Click);
            // 
            // labelNote
            // 
            this.labelNote.AutoSize = true;
            this.labelNote.Location = new System.Drawing.Point(183, 327);
            this.labelNote.Name = "labelNote";
            this.labelNote.Size = new System.Drawing.Size(322, 16);
            this.labelNote.TabIndex = 7;
            this.labelNote.Text = "Sai lệch vượt quá 30% sẽ được cảnh báo bằng dấu (!)";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.labelStatus.Location = new System.Drawing.Point(23, 410);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(0, 15);
            this.labelStatus.TabIndex = 8;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.BlueViolet;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Location = new System.Drawing.Point(974, 214);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 49);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // FoodManagement
            // 
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1140, 496);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.comboBoxRoom);
            this.Controls.Add(this.labelRoom);
            this.Controls.Add(this.dataGridViewFood);
            this.Controls.Add(this.btnAddFood);
            this.Controls.Add(this.btnRemoveFood);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCheckDeviation);
            this.Controls.Add(this.labelNote);
            this.Controls.Add(this.labelStatus);
            this.Name = "FoodManagement";
            this.Text = "Quản lý thực phẩm trong phòng";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFood)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private DataGridViewTextBoxColumn FoodName;
        private DataGridViewTextBoxColumn QuantityIn;
        private DataGridViewTextBoxColumn QuantityOut;
        private DataGridViewTextBoxColumn Deviation;
        private DataGridViewTextBoxColumn TotalPrice;
        private DataGridViewTextBoxColumn UsageDate;
        private Button btnRefresh;
    }
}
