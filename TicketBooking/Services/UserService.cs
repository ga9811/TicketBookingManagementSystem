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
        //public void AddTrain(TrainInfoModel train)
        //{
        //    string sql = "UPDATE Trains SET dep_id = @depId, arr_id = @arrId, " +
        //        "dep_time = @depTime, arr_time = @arrTime, " +
        //        "train_Id = @newTrainId WHERE train_Id = @oldTrainId";
        //    BasicDao<TrainInfoModel>.Update(sql, train.dep_id, train.arr_id,
        //        train.dep_time, train.arr_time, train.train_Id);

        //}
        

        public List<StationsInfoModel> GetAllStations()
        {
            string sql = "SELECT * FROM Stations";
            return BasicDao<StationsInfoModel>.QueryMulti(sql);
        }

public List<TrainInfoModel> SearchTrainByTrainId(int trainId)
{
            string sql = "select * from Trains where train_Id = @p0";


            return BasicDao<TrainInfoModel>.QueryMulti(sql, trainId);
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

    }
}
