namespace QuanLyHotel_WindowProgramming
{
    partial class MainFormQuanLy
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.quảnLýNhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quanLyNhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiêpTânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.laoCôngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kiểmTraGiờLàmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tínhTiềnCuốiNgàyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýNhânViênToolStripMenuItem,
            this.kiểmTraGiờLàmToolStripMenuItem,
            this.tínhTiềnCuốiNgàyToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1067, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // quảnLýNhânViênToolStripMenuItem
            // 
            this.quảnLýNhânViênToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quanLyNhânViênToolStripMenuItem,
            this.tiêpTânToolStripMenuItem,
            this.laoCôngToolStripMenuItem});
            this.quảnLýNhânViênToolStripMenuItem.Name = "quảnLýNhânViênToolStripMenuItem";
            this.quảnLýNhânViênToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.quảnLýNhânViênToolStripMenuItem.Text = "Quản Lý";
            // 
            // quanLyNhânViênToolStripMenuItem
            // 
            this.quanLyNhânViênToolStripMenuItem.Name = "quanLyNhânViênToolStripMenuItem";
            this.quanLyNhânViênToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.quanLyNhânViênToolStripMenuItem.Text = "Nhân viên";
            this.quanLyNhânViênToolStripMenuItem.Click += new System.EventHandler(this.quanLyNhânViênToolStripMenuItem_Click_1);
            // 
            // tiêpTânToolStripMenuItem
            // 
            this.tiêpTânToolStripMenuItem.Name = "tiêpTânToolStripMenuItem";
            this.tiêpTânToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.tiêpTânToolStripMenuItem.Text = "Tiếp tân";
            // 
            // laoCôngToolStripMenuItem
            // 
            this.laoCôngToolStripMenuItem.Name = "laoCôngToolStripMenuItem";
            this.laoCôngToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.laoCôngToolStripMenuItem.Text = "Lao công";
            // 
            // kiểmTraGiờLàmToolStripMenuItem
            // 
            this.kiểmTraGiờLàmToolStripMenuItem.Name = "kiểmTraGiờLàmToolStripMenuItem";
            this.kiểmTraGiờLàmToolStripMenuItem.Size = new System.Drawing.Size(140, 24);
            this.kiểmTraGiờLàmToolStripMenuItem.Text = "Kiểm Tra Giờ Làm";
            this.kiểmTraGiờLàmToolStripMenuItem.Click += new System.EventHandler(this.kiểmTraGiờLàmToolStripMenuItem_Click);
            // 
            // tínhTiềnCuốiNgàyToolStripMenuItem
            // 
            this.tínhTiềnCuốiNgàyToolStripMenuItem.Name = "tínhTiềnCuốiNgàyToolStripMenuItem";
            this.tínhTiềnCuốiNgàyToolStripMenuItem.Size = new System.Drawing.Size(156, 24);
            this.tínhTiềnCuốiNgàyToolStripMenuItem.Text = "Tính Tiền Cuối Ngày";
            this.tínhTiềnCuốiNgàyToolStripMenuItem.Click += new System.EventHandler(this.tínhTiềnCuốiNgàyToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // MainFormQuanLy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainFormQuanLy";
            this.Text = "MainFormQuanLy";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem quảnLýNhânViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kiểmTraGiờLàmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tínhTiềnCuốiNgàyToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem quanLyNhânViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiêpTânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem laoCôngToolStripMenuItem;
    }
}