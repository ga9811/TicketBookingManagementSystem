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
using System.Collections.ObjectModel;
using TicketBookingSystemWPF.DAO;


namespace TicketBookingSystemWPF.View
{
    /// <summary>
    /// Interaction logic for CustomerView.xaml
    /// </summary>
    public partial class CustomerView : Window
    {
        private ObservableCollection<BookingsInfoModel> Bookings;
        private UserService userService;
        private BookingsInfoModel selectedBooking;
       
        public CustomerView()
        {
            InitializeComponent();
            userService = new UserService();

            
            dataGrid.ItemsSource = Bookings;
        }
        

        private void Search_Click(object sender, RoutedEventArgs e)
        {   
            string depStation = depBox.SelectedItem.ToString();
            string arrStation = ArrBox.SelectedItem?.ToString();

            depStation = depStation?.Replace("System.Windows.Controls.ComboBoxItem: ", "");
            arrStation = arrStation?.Replace("System.Windows.Controls.ComboBoxItem: ", "");
            DateTime? SelectedDate = SelectDate.SelectedDate;
            //Console.WriteLine(depStation);
            //Console.WriteLine(arrStation);
            //Console.WriteLine(SelectedDate);

            // 执行搜索操作，获取符合条件的票信息
            if (depStation==arrStation|| SelectedDate ==null)
            {
                MessageBox.Show("The Dep And Arr Can't Same or Date Is Missing");
            }
            else if (SelectedDate > new DateTime(2023, 07, 06) || SelectedDate < new DateTime(2023, 07, 01))
            {
                MessageBox.Show("Please Chose 07-01 to 07-05");
            }


            else {
                List<BookingsInfoModel> bookings = userService.SearchBookings(depStation, arrStation, SelectedDate.Value);
                           
            dataGrid.ItemsSource = bookings; 
            }


        }

        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            int user_type = GlobalData.findUserType;
            if (user_type == 0) {
                MessageBox.Show("Need be Authorited");
            }else
            {
                AdminView adminView = new AdminView();
                adminView.Show();
                this.Close();
            }
            
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
            if (selectedBooking == null)
            {
                return;
            }
            int booking_id = selectedBooking.booking_id;
            int train_id = selectedBooking.train_Id;
            string depStation = selectedBooking.depStation;
            string arrStation = selectedBooking.arrStation;
            DateTime dep_time = selectedBooking.dep_time;
            DateTime arr_time = selectedBooking.arr_time;
            string seat = selectedBooking.seatName;
            decimal price = selectedBooking.price;

            Ticket ticketWindow = new Ticket(booking_id,train_id, depStation, arrStation, dep_time, arr_time, seat, price);

            
            ticketWindow.ShowDialog();

        }

        private void UserButton_Click(object sender, RoutedEventArgs e)
        {
            Users user = new Users();
            user.Show();
            this.Close();
        }

        private void BookingButton_Click(object sender, RoutedEventArgs e)
        {
            this.Show();
        }
    }
}
