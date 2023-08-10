using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystemWPF.DAO;
using TicketBookingSystemWPF.DModels;


namespace TicketBookingSystemWPF.Services
{
    public class UserService
    {



        public UserService()
        {
            
        }

        public List<StationsInfoModel> GetAllStations()
        {
            string sql = "SELECT * FROM Stations";
            return BasicDao<StationsInfoModel>.QueryMulti(sql);
        }

public List<BookingsInfoModel> SearchTrainByTrainId(int trainId)
{
            string sql = "SELECT Trains.train_Id, dep.station AS depStation, arr.station AS arrStation, Trains.dep_time, Trains.arr_time, Seats.name AS seatName, Trains.price " +
            "FROM Trains " +
            "JOIN Stations dep ON Trains.dep_id = dep.station_Id " +
            "JOIN Stations arr ON Trains.arr_id = arr.station_Id " +
            "JOIN Seats ON Trains.seat_Id = Seats.seat_Id " +
            "WHERE Trains.train_Id= @p0";
            //string sql = "select * from Trains where train_Id = @p0";


            return BasicDao<BookingsInfoModel>.QueryMulti(sql, trainId);
            
        }
        public void UpdateTrain(TrainInfoModel train)
        {
            string sql = "UPDATE Trains SET dep_id = @p0, arr_id = @p1, " +
    "dep_time = @p2, arr_time = @p3, seat_Id = @p4, " +
    "price = @p5 WHERE train_Id = @p6";

            Console.WriteLine("Update SQL: " + sql);

            BasicDao<TrainInfoModel>.Update(sql, train.dep_id, train.arr_id,
                train.dep_time, train.arr_time, train.seat_id, train.price, train.train_Id);

        }
        public List<UserInfoModel> SearchUserByUserId(int user_id)
        {
            string sql = "SELECT * FROM Users WHERE CAST(user_id AS NVARCHAR) LIKE '%' + CAST(@p0 AS NVARCHAR)";
            return BasicDao<UserInfoModel>.QueryMulti(sql, user_id);
        }

        public int DeleteTrainByTrainId(int trainId)
        {
            string sql = "DELETE FROM Trains WHERE train_Id = @p0";
            return BasicDao<TrainInfoModel>.Update(sql, trainId);

        }

        public List<BookingsInfoModel> SearchBookings(string depStation, string arrStation, DateTime selectedDate)
        {
            string sql = "SELECT Trains.id AS booking_id,Trains.train_Id, dep.station AS depStation, arr.station AS arrStation, Trains.dep_time, Trains.arr_time, Seats.name AS seatName, Trains.price " +
             "FROM Trains " +
             "JOIN Stations dep ON Trains.dep_id = dep.station_Id " +
             "JOIN Stations arr ON Trains.arr_id = arr.station_Id " +
             "JOIN Seats ON Trains.seat_Id = Seats.seat_Id " +
             "WHERE dep.station = @p0 AND arr.station = @p1 AND CAST(Trains.dep_time AS DATE) = CAST(@p2 AS DATE)";

            return BasicDao<BookingsInfoModel>.QueryMulti(sql, depStation, arrStation, selectedDate);
        }

        public int DeleteBookingWhenOrder(int bookingId)
        {
            string sql = "DELETE FROM Trains WHERE id = @p0";
          return  BasicDao<BookingsInfoModel>.Update(sql, bookingId);
        }

        public UserInfoModel getUserByIdAndPwd(int user_id, string password, int user_type) {
            string sql = "select * from Users where user_id = @p0 AND password = @p1 and user_type = @p2";
            return BasicDao<UserInfoModel>.QuerySingle(sql, user_id, password, user_type);

        }
        public void SaveUser(UserInfoModel user)
        {
            string sql = "insert into Users (user_id, name, phone, email, password, user_type) VALUES (@p0, @p1, @p2, @p3, @p4, @p5)";
            BasicDao<UserInfoModel>.Update(sql, user.user_id, user.name, user.phone, user.email, user.password, user.user_type);
        }

        //for userClass
        public void SaveUser2(int user_id, string name, string phone, string email, int user_type, string password)
        {
            string sql = "insert into Users (user_id, name, phone, email, password, user_type) VALUES (@p0, @p1, @p2, @p3, @p4, @p5)";
            BasicDao<UserInfoModel>.Update(sql, user_id, name, phone, email, password, user_type);
        }

        //myGrid
        public List<UserInfoModel> ShowMeAllUsers()
        {
            string sql = "select * from Users";
            return BasicDao<UserInfoModel>.QueryMulti(sql);
        }

        public void UpdateUser(int userId, string name, string phone, string email)
        {
            string updateQuery = "update Users set name = @p0, phone = @p1, email = @p2 where user_id = @p3";
            BasicDao<UserInfoModel>.Update(updateQuery, name, phone, email, userId);
        }

        // Delete
        public void DeleteUserById(int userId)
        {
            string sql = "delete from Users where user_id = @p0";
            BasicDao<UserInfoModel>.Update(sql, userId);
        }

        //Search by name only
        public List<UserInfoModel> SearchUsersByName(string name)
        {
            string sql = "select * from Users where name LIKE @p0";
            return BasicDao<UserInfoModel>.QueryMulti(sql, "%" + name + "%");
        }
        public List<UserInfoModel> SearchUsersById(int id)
        {
            string sql = "select * from Users where user_id = @p0";
            return BasicDao<UserInfoModel>.QueryMulti(sql, id);
        }
        
    }
}
