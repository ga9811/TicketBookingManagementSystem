using NUnit.Framework;
using System.Collections.Generic;
using Moq;
using TicketBookingSystemWPF.DModels;

using System;
using TicketBookingSystemWPF;
using TicketBookingSystemWPF.Services;
using System.Data.SqlClient;
using BankCharge;

namespace TicketBookingTest
{
    public class Tests
    {
        private static UserService userService;
        

        [SetUp]
        public void Setup()
        {
            userService = new UserService();
           
        }

        [Test]

        public void TestSearchTrainByTrainId()
        {
            List<BookingsInfoModel> BookingsInfoModel = userService.SearchTrainByTrainId(159);
            Assert.IsNotNull(BookingsInfoModel);
            Assert.IsTrue(BookingsInfoModel.Count > 0);
        }
        [Test]
        public void TestSearchUserByUserId()
        {
            List<UserInfoModel> userInfoModels = userService.SearchUserByUserId(1);
            Assert.IsNotNull(userInfoModels);
            Assert.IsTrue(userInfoModels.Count > 0);
        }

        [Test]
        public void TestSearchBookings() 
        {
            List<BookingsInfoModel> bookingsInfoModels = userService.SearchBookings("Montreal", "Quebec", new DateTime(2023, 07, 03));
            Assert.IsNotNull(bookingsInfoModels);
            Assert.IsTrue(bookingsInfoModels.Count > 0);
        }
        [Test]
        public void TestGetUserByIdAndPwd()
        {
            UserInfoModel user = userService.getUserByIdAndPwd(1, "1234", 0);
            Assert.IsNotNull(user);
            Assert.AreEqual(1,user.user_id);
        }
        //[Test]
        //public void TestDeleteTrainByTrainId()
        //{
        //    int rows = userService.DeleteTrainByTrainId(157);
        //    Assert.IsTrue(rows >0);
        //}
        [Test]
        public void TestDeleteBookingWhenOrder()
        {
            int rows = userService.DeleteBookingWhenOrder(777);
            Assert.IsTrue(rows > 0);
        }

    }
}