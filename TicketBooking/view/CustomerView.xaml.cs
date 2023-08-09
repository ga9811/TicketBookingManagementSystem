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
using System.Data.SqlClient;
using TicketBookingSystemWPF.DModels;
using TicketBookingSystemWPF.Services;

namespace TicketBookingSystemWPF.View
{
    /// <summary>
    /// Interaction logic for CustomerView.xaml
    /// </summary>
    public partial class CustomerView : Window
    {

        private UserService userService;
        private BookingsInfoModel selectedBooking;
        public CustomerView()
        {
            InitializeComponent();
            userService = new UserService();
        }
        

        private void Search_Click(object sender, RoutedEventArgs e)
        {   
            string depStation = depBox.SelectedItem.ToString();
            string arrStation = ArrBox.SelectedItem?.ToString();

            depStation = depStation?.Replace("System.Windows.Controls.ComboBoxItem: ", "");
            arrStation = arrStation?.Replace("System.Windows.Controls.ComboBoxItem: ", "");
            DateTime SelectedDate = SelectDate.SelectedDate.Value;
            //Console.WriteLine(depStation);
            //Console.WriteLine(arrStation);
            //Console.WriteLine(SelectedDate);

            // 执行搜索操作，获取符合条件的票信息
            List<BookingsInfoModel> bookings = userService.SearchBookings(depStation, arrStation, SelectedDate);
                


            // 将结果绑定到 DataGrid 控件
            dataGrid.ItemsSource = bookings;
        }

        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            CustomerView customerView = new CustomerView();
            customerView.Close();
            AdminView adminView = new AdminView();
           adminView.Show();
        }

        private void BookingButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void depBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ArrBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedBooking = dataGrid.SelectedItem as BookingsInfoModel;
            int booking_id = selectedBooking.booking_id;
            int train_id = selectedBooking.train_Id;
            string depStation = selectedBooking.depStation;
            string arrStation = selectedBooking.arrStation;
            DateTime dep_time = selectedBooking.dep_time;
            DateTime arr_time = selectedBooking.arr_time;
            string seat = selectedBooking.seatName;
            decimal price = selectedBooking.price;

            Ticket ticketWindow = new Ticket(booking_id,train_id, depStation, arrStation, dep_time, arr_time, seat, price);

            // 显示目标窗口
            ticketWindow.ShowDialog();

        }
    }
}
