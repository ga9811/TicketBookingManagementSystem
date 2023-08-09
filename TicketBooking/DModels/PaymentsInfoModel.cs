using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingSystemWPF.DModels
{
    public class PaymentsInfoModel
    {
        public int payment_id { get; set; }
        public int booking_id { get; set; }
        public double payment_amount { get; set; }
        public DateTime payment_date { get; set; }

    }
}
