using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using TicketBookingSystemWPF.Services;
using System.Windows.Markup;

namespace TicketBookingSystemWPF.View
{
    /// <summary>
    /// Interaction logic for Ticket.xaml
    /// </summary>
    public partial class Ticket : Window
    {
        private int bookingId;
        UserService userService = new UserService();
        public Ticket(int bookingId, int train_id, string depStation,
            string arrStation, DateTime dep_time, DateTime arr_time, string seat, decimal price)
        {
            InitializeComponent();
            this.bookingId = bookingId;
            DepTimeTextBlock.Text = dep_time.ToString();
            TrainIdTextBlock.Text = train_id.ToString();
            ArrTimeTextBlock.Text = arr_time.ToString();
            PriceTextBlock.Text = price.ToString();
            SeatTextBlock.Text = seat.ToString();
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {

            int rowsAffected = userService.DeleteBookingWhenOrder(bookingId);

            if (rowsAffected > 0)
            {
                MessageBox.Show("Order Successful, Please Make Payment");
            }
            else
            {
                MessageBox.Show("Fail,Try again!");
            }

            this.Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            DepTimeTextBlock.Text = "";
            TrainIdTextBlock.Text = "";
            ArrTimeTextBlock.Text = "";
            PriceTextBlock.Text = "";
            SeatTextBlock.Text = "";

            this.Close();


        }

        private void PrintBtn_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                
                Grid printContainer = new Grid();

                // creat ContentGrid 
                foreach (UIElement element in ContentGrid.Children)
                {
                    if (!(element is Button))
                    {
                        string elementXaml = XamlWriter.Save(element);
                        UIElement elementClone = (UIElement)XamlReader.Parse(elementXaml);
                        printContainer.Children.Add(elementClone);
                    }
                }

                printDialog.PrintVisual(printContainer, "Ticket");
            }
        }
    }
}
