using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using TicketBookingREST.Models;

namespace TicketBookingREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;
        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetUserByUser_idPasswordAndUser_type/{user_id}/{password}/{user_type}")]
        public Response GetUserByUser_idPasswordAndUser_type(int user_id,string password,int user_type)
        {
            Response response = new Response();
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("loginConnection").ToString());

            Applications app = new Applications();
            response = app.GetUserByUseridPasswordAndUsertype(con, user_id, password, user_type);
            return response;
        }
    }
}
