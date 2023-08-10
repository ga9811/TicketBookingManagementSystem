using Microsoft.Data.SqlClient;
using System.Data;
using TicketBookingREST.Controllers;

namespace TicketBookingREST.Models
{
    public class Applications
    {
        internal Response GetUserByUseridPasswordAndUsertype(SqlConnection con, int user_id, string password, int user_type)
        {
            
            Response response = new Response();
        
        try
        {
           
            string query = "SELECT * FROM Users WHERE user_id = @user_id and password = @password and user_type = @user_type";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@user_id", user_id);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@user_type", user_type);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            UserInfoModel userInfoModel = new UserInfoModel();

            if (dt.Rows.Count > 0)
            {


                userInfoModel.user_id = (int)dt.Rows[0]["user_id"];
                userInfoModel.password = (string)dt.Rows[0]["password"];
                userInfoModel.name = (string)dt.Rows[0]["name"];
                userInfoModel.phone = (string)dt.Rows[0]["phone"];
                userInfoModel.email = (string)dt.Rows[0]["email"];
                userInfoModel.user_type = (int)dt.Rows[0]["user_type"];

                response.statusCode = 200;
                response.message = "retrieved successfully";
                response.userInfoModel = userInfoModel;
               

            }
            else
            {
                userInfoModel = null;
                response.statusCode = 100;
                response.message = "faild";
                response.userInfoModel = null;
              
            }

        }
        catch (SqlException ex)
        {
            response.statusCode = 500; // Internal Server Error
            response.message = "Error occurred : " + ex.Message;
            response.userInfoModel = null;
          
            Console.WriteLine(ex.ToString());
        }
        return response;
    }
        }
    }
   
