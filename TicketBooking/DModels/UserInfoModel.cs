using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingSystemWPF.DModels
{
    public class UserInfoModel
    {
        public int user_id { get; set; }
        public string password { get; set; }
        public  string name { get; set; }
        public  string phone { get; set; }
        public string email { get; set; }
        public int user_type { get; set; }

    }
}
