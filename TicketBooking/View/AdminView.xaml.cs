using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TicketBookingSystemWPF.DModels;
using TicketBookingSystemWPF.Services;
using static System.Collections.Specialized.BitVector32;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Collections.ObjectModel;
using System.Data;
using TicketBookingSystemWPF.DAO;

namespace TicketBookingSystemWPF.View
{
    /// <summary>
    /// Interaction logic for AdminView.xaml
    /// </summary>
    public partial class AdminView : Window
    {
        private UserService userService;
        private TrainInfoModel selectedTrain;

        private Dictionary<int, string> stationNameMap;

        public AdminView()
        {
            InitializeComponent();

            populate();

            userService = new UserService();


        }


        private void DateTimePicker_SelectedDateTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {

        }

        private void BookingButton_Click(object sender, RoutedEventArgs e)
        {


            CustomerView customerView = new CustomerView();
            customerView.Show();
            AdminView adminView = new AdminView();
            adminView.Close();

        }
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-D9VVUP6;Initial Catalog=TicketBooking;Integrated Security=True");

        private void Addbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //using (var connection = new SqlConnection(@"Data Source=DESKTOP-D9VVUP6;Initial Catalog=TicketBooking;Integrated Security=True"))
                {
                    connection.Open();

                    string sql = "INSERT INTO Trains (train_Id, dep_id, arr_id, dep_time, arr_time, seat_Id, price) " +
                                 "VALUES (@trainId, @depId, @arrId, @depTime, @arrTime, @seatId, @price)";

                    using (var command = new SqlCommand(sql, connection))
                    {
                        int trainId = int.Parse(TrainId_textbox.Text);
                        //int depId = 1;
                        //int arrId = 4;
                        int depId = depBox.SelectedIndex + 1;
                        int arrId = arrBox.SelectedIndex + 1;

                        DateTime depTime = DeaprTime.SelectedDateTime.Value;
                        DateTime arrTime = ArrTime.SelectedDateTime.Value;
                        decimal price = 0;

                        for (int seatId = 1; seatId <= 20; seatId++)
                        {
                            if (seatId <= 10)
                                price = 50;
                            else
                                price = 80;

                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@trainId", trainId);
                            command.Parameters.AddWithValue("@depId", depId);
                            command.Parameters.AddWithValue("@arrId", arrId);
                            command.Parameters.AddWithValue("@depTime", depTime);
                            command.Parameters.AddWithValue("@arrTime", arrTime);
                            command.Parameters.AddWithValue("@seatId", seatId);
                            command.Parameters.AddWithValue("@price", price);

                            command.ExecuteNonQuery();
                        }
                    }
                }

                ClearInputFields();

                MessageBox.Show("Train created successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to create train: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            connection.Close();
        }





        private void TrainId_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void ClearInputFields()
        {
            DeaprTime.SelectedDateTime = DateTime.Now;
            ArrTime.SelectedDateTime = DateTime.Now;


            depBox.SelectedIndex = -1;
            arrBox.SelectedIndex = -1;


            UserId_textbox.Text = "";

        }

        private void Resetbtn_Click(object sender, RoutedEventArgs e)
        {
            ClearInputFields();
        }

        private void Searchbtn_Click(object sender, RoutedEventArgs e)
        {
            int trainId = int.Parse(TrainId_textbox.Text);
            List<TrainInfoModel> trains = userService.SearchTrainByTrainId(trainId);
            dataGrid.ItemsSource = trains;
            updateTrainId.Text = TrainId_textbox.Text;


        }


        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedTrain = (TrainInfoModel)dataGrid.SelectedItem;






        }
        private void TrainInfoUpdate()
        {

        }

        //private void Update_Click(object sender, RoutedEventArgs e)
        //{
        //    if (selectedTrain != null)
        //    {
        //        userService.UpdateTrain(selectedTrain);

        //        MessageBox.Show("Train updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please select a train to update.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //}

        private void userDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserInfoModel selectedUser = (UserInfoModel)userDataGrid.SelectedItem;
        }

        private void usersearchBtn_Click(object sender, RoutedEventArgs e)
        {
            int user_id = int.Parse(UserId_textbox.Text);
            List<UserInfoModel> users = userService.SearchUserByUserId(user_id);
            userDataGrid.ItemsSource = users;
        }

        private void depBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ArrBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ArriveTime_SelectedDateTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            int updatedTrainId = int.Parse(updateTrainId.Text);

            List<TrainInfoModel> trains = userService.SearchTrainByTrainId(int.Parse(TrainId_textbox.Text));



            if (trains.Count == 0)
            {
                // 找不到符合条件的车次信息
                return;
            }

            //更新所有符合条件的车次信息
            foreach (TrainInfoModel train in trains)
            {
                train.train_Id = updatedTrainId;
                Console.WriteLine(updatedTrainId);
                userService.UpdateTrain(train);
                Console.WriteLine("Train updated successfully!");
            }


            //显示成功的提示
            MessageBox.Show("update successful");
        }

        private void populate()
        {
            connection.Open();
            string query = "select * from Trains";
            SqlDataAdapter sda = new SqlDataAdapter(query, connection);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            dataGrid.DataContext = ds.Tables[0];
            connection.Close();
        }

        private void Deletebtn_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(TrainId_textbox.Text, out int trainId))
            {
                return;
            }

            List<TrainInfoModel> trains = userService.SearchTrainByTrainId(trainId);

           
            int deletedCount = userService.DeleteTrainByTrainId(trainId);

            if (deletedCount > 0)
            {
               
                MessageBox.Show("Delete successful");
            }
            else
            {
                
                MessageBox.Show("Delete failed");
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }
    }
}
