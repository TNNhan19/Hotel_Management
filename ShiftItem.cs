using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHotel_WindowProgramming
{
    public class ShiftItem
    {
        public DateTime Date { get; set; }
        public string TimeSlot { get; set; }  // "07:00–19:00" hoặc "20:00–06:00"
        public string Role { get; set; }      // "Tiếp tân", "Lao công", "Quản lý"
        public int RequiredCount { get; set; }
        public List<string> RegisteredEmployees { get; set; } = new List<string>();
        public int ShiftId { get; set; } // ID của ca làm việc trong cơ sở dữ liệu
    }
}
