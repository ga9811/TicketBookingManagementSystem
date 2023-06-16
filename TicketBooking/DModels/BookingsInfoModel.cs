using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingSystemWPF.DModels


{
    public class BookingsInfoModel
    {
        public int booking_id { get; set; }
        public int user_id { get; set; }
        public int train_id { get; set; }
        public DateTime booking_date { get; set; }
        public decimal price { get; set; }
        public int seat_id { get; set; }
        public int train_Id { get; set; }
        public int dep_id { get; set; }
        public int arr_id { get; set; }
        public DateTime dep_time { get; set; }
        public DateTime arr_time { get; set; }

        public int station_id { get; set; }

        public string name { get; set; }
        public string station { get; set; }

        public string depStation { get; set; }
        public string arrStation { get; set; }
        public string seatName { get; set; }



    }
}
