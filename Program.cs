using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHotel_WindowProgramming
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginHotel flogin = new LoginHotel();
            if (flogin.ShowDialog() == DialogResult.OK)
            {
                if (flogin.SelectedRole == "Quản Lý")
                {
                    Application.Run(new MainFormQuanLy());
                }
                else if (flogin.SelectedRole == "Tiếp Tân")
                {
                    Application.Run(new MainForm_TiepTan());
                }
                else if (flogin.SelectedRole == "Lao Công")
                {
                    Application.Run(new MainForm_LaoCong());
                }
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
