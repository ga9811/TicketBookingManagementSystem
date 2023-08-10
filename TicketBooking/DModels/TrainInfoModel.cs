using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingSystemWPF.DModels
{
    public class TrainInfoModel
    { 
        public decimal price { get; set; }
        public int seat_id { get; set; }
        public int train_Id { get; set; }
        public int dep_id { get; set; }
        public int arr_id { get; set; }
        public DateTime dep_time { get; set; }
        public DateTime arr_time { get; set; }
        public string dep_station { get; set; } 
        public string arr_station { get; set; }
    }


}
