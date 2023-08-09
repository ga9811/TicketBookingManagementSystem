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
    /// Interaction logic for Users.xaml
    /// </summary>
    public partial class Users : Window
    {
        private readonly UserService _userService;
        //internal UserService _userService;
        //public UserService _userService;

        public Users(UserService service)
        {
            _userService = service;
            InitializeComponent();
        }

        public string[] NameOfUser { get; set; }
        public Users()
        {
            InitializeComponent();
            NameOfUser = new string[] { "Customer-0", "Admin-1" };
            typeComboBox.ItemsSource = NameOfUser;
            _userService = new UserService();
            DataContext = this;

            //LoadMyGrid();
        }
        private void save_botton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int user_id = int.Parse(idbox.Text);
                string name = namebox.Text;
                string phone = phonenumberbox.Text;
                string email = emailtextbox.Text;
                string password = passwordbox.Text;

                string userTypeString = typeComboBox.SelectedItem as string;
                int user_type = 0; // default 

                var userTypeDict = new Dictionary<string, int>
                {
                    { "Customer-0", 0 },
                    { "Admin-1", 1 }
                };

                if (userTypeDict.ContainsKey(userTypeString))
                {
                    user_type = userTypeDict[userTypeString];
                }

                UserService userService = new UserService();
                userService.SaveUser2(user_id, name, phone, email, user_type, password);

                MessageBox.Show("User added successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("error message: " + ex.Message);
            }
        }


        //Data Grid Split - to load data when it is loaded not changed
        private void LoadMyGrid()
        {
            mygrid.ItemsSource = _userService.ShowMeAllUsers();
        }

        private void DataGrid_SelectionChanged(object sender, RoutedEventArgs e)
        {
            UserInfoModel selectedUser = mygrid.SelectedItem as UserInfoModel;
            if (selectedUser == null)
            {
                return;
            }

            idbox.Text = selectedUser.user_id.ToString();
            namebox.Text = selectedUser.name;
            phonenumberbox.Text = selectedUser.phone;
            emailtextbox.Text = selectedUser.email;
        }

        // GET
        private void showall_Click(object sender, RoutedEventArgs e)
        {
            if(GlobalData.findUserType == 1) {
                LoadMyGrid(); 
            }
            else
            {
                MessageBox.Show("Need be Authorited");
            }
           
        }


        // POST
        private void update_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = mygrid.SelectedItem as UserInfoModel;

            if (selectedUser == null)
            {
                return;
            }

            int userId = selectedUser.user_id;
            string name = selectedUser.name;
            string phone = selectedUser.phone;
            string email = selectedUser.email;

            _userService.UpdateUser(userId, name, phone, email);

            // Once update is done, reload the data in the grid.
            SearchReplace();
        }

        // DELETE
        private void delete_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = mygrid.SelectedItem as UserInfoModel;

            if (selectedUser == null)
            {
                return;
            }

            int user_id = selectedUser.user_id;
            _userService.DeleteUserById(user_id);


            if(GlobalData.findUserType == 1) { 
                LoadMyGrid();
            }
            
        }


        // SEARCH

        private void search_Click(object sender, RoutedEventArgs e)
        {
            SearchReplace();
        }
        private void SearchReplace()
        {
            string search_name = namebox.Text.Trim();
            
            UserService userService = new UserService();
            List<UserInfoModel> foundUsers = userService.SearchUsersByName(search_name);
             UserInfoModel firstUser = foundUsers[0];

           

            if (GlobalData.findUserType == 1 && foundUsers != null && foundUsers.Count > 0)
            {
               idbox.Text = firstUser.user_id.ToString();
                //typeComboBox.SelectedItem = typeComboBox.Items.Cast<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == firstUser.user_type.ToString());
                namebox.Text = firstUser.name;
                phonenumberbox.Text = firstUser.phone;
                emailtextbox.Text = firstUser.email;
                passwordbox.Text = firstUser.password;
                usernamebox.Text = firstUser.name;

                // Load the list 
                mygrid.ItemsSource = foundUsers;
               

            }
            else if (GlobalData.findUserId != null && GlobalData.findUserType == 0 && foundUsers != null && foundUsers.Count > 0)
            {
                 List<UserInfoModel> customer = userService.SearchUsersById(GlobalData.findUserId);
                if (customer != null && customer.Count > 0) {     
                    UserInfoModel findUser = customer[0];
                idbox.Text = findUser.user_id.ToString();
                //typeComboBox.SelectedItem = typeComboBox.Items.Cast<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == firstUser.user_type.ToString());
                namebox.Text = findUser.name;
                phonenumberbox.Text = findUser.phone;
                emailtextbox.Text = findUser.email;
                passwordbox.Text = findUser.password;
                usernamebox.Text = findUser.name;

                // Load the list 
                mygrid.ItemsSource = customer;
                }
                else { MessageBox.Show("you have no right check other"); }
            }
            else
            {
                MessageBox.Show("No user found");
            }
        }

        private void cancelbutton_Click(object sender, RoutedEventArgs e)
        {
            idbox.Clear();
            namebox.Clear();
            phonenumberbox.Clear();
            emailtextbox.Clear();
            passwordbox.Clear();
            usernamebox.Clear();
            typeComboBox.SelectedIndex = -1;
        }

        private void issueid_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int user_id = int.Parse(idbox.Text);
                string name = namebox.Text;
                string phone = phonenumberbox.Text;
                string email = emailtextbox.Text;

                // to display 
                Id idForm = new Id(user_id, name, phone, email);
                idForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
