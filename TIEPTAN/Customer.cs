using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHotel_WindowProgramming.TIEPTAN
{
    
        public class Customer
        {
            public int Id { get; set; }
            public string CustomerName { get; set; }
            public string Phone { get; set; }
            public string Nationality { get; set; }
            public string Gender { get; set; }
            public DateTime Dob { get; set; }
            public string Cccd { get; set; }
            public string Address { get; set; }
            public DateTime Checkin { get; set; }
            public DateTime? Checkout { get; set; }
            public bool CheckoutStatus { get; set; }
            public int RoomId { get; set; }
        }

    
}
