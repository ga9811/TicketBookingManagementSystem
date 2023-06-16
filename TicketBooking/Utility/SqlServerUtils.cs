using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TicketBookingSystemWPF.Utility
{
    public static class SqlServerUtils
    {
        private static readonly string connectionString = "Data Source=DESKTOP-D9VVUP6;Initial Catalog=TicketBooking;Integrated Security=True";

        // connect
        public static SqlConnection GetConnection()
        {
            try
            {
                var connection = new SqlConnection(connectionString);
                connection.Open();
                return connection;
            }
            catch (Exception e)
            {
                throw new Exception("Failed to get connection.", e);
            }
        }

        // close sql
        public static void Close(IDisposable disposable)
        {
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
}
