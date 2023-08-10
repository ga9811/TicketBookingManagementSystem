namespace TicketBookingREST.Models
{
    public class Response
    {
        public int statusCode { get; set; }
        public string message { get; set; }
        public UserInfoModel userInfoModel { get; set; }
       
    }
}
