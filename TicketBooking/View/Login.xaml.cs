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

namespace TicketBookingSystemWPF.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        UserService userService = new UserService();
        public Login()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            IdTextBox.Text = "";
            PasswordBox.Clear();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(IdTextBox.Text);
            string paw = PasswordBox.Password;
            int userType = ComboBox.SelectedIndex;
          UserInfoModel user =  userService.getUserByIdAndPwd(id, paw, userType);
            
            if (user != null && userType == 0)
            {
                MessageBox.Show("Login Successful");
               
                CustomerView customerView = new CustomerView();
                customerView.Show(); 
                this.Hide();
            }
            else if(user != null && userType == 1)
            {
                MessageBox.Show("Login successfful");
                
                AdminView adminView = new AdminView();
                adminView.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Id or Password Wrong, Please Reinput Again");
                IdTextBox.Text = "";
                PasswordBox.Clear();

            }
        }
    }
}
