using System;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using TicketBookingSystemWPF.DModels;
using Newtonsoft.Json;

using TicketBookingSystemWPF.Services;

namespace TicketBookingSystemWPF.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        UserService userService = new UserService();
        HttpClient httpClient = new HttpClient();

        public Login()
        {
            httpClient.BaseAddress = new Uri("https://localhost:7011/api/Login/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );

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

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            int user_id = int.Parse(IdTextBox.Text);
            string password = PasswordBox.Password;
            int user_type = ComboBox.SelectedIndex;
            GlobalData.findUserType = user_type;
            GlobalData.findUserId = user_id;

            var response = await httpClient.GetAsync($"GetUserByUser_idPasswordAndUser_type/{user_id}/{password}/{user_type}");
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            Response res = JsonConvert.DeserializeObject<Response>(responseContent);

            //UserInfoModel user =  userService.getUserByIdAndPwd(id, paw, userType);
            if (res.userInfoModel != null && user_type == 0)
            {
                MessageBox.Show("Login Successful");
               
                CustomerView customerView = new CustomerView();
                customerView.Show(); 
                this.Hide();
            }
            else if(res.userInfoModel != null && user_type == 1)
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

        private void RegistButton_Click(object sender, RoutedEventArgs e)
        {
            Users users = new Users();
            users.Show();
            this.Close();
        }
    }
}
