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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TicketBookingSystemWPF.View
{
    /// <summary>
    /// Interaction logic for Id.xaml
    /// </summary>
    public partial class Id : Window
    {
        public Id(int user_id, string name, string phone, string email)
        {
            InitializeComponent();
            idbox.Text = user_id.ToString();
            namebox.Text = name;
            phonebox.Text = phone;
            emailbox.Text = email;
        }

        private void printbox_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                Grid printContainer = new Grid();

                foreach (UIElement element in grid2.Children)
                {
                    if (!(element is Button))
                    {
                        string elementXaml = XamlWriter.Save(element);
                        UIElement elementClone = (UIElement)XamlReader.Parse(elementXaml);
                        printContainer.Children.Add(elementClone);
                    }
                }
                printContainer.Measure(new Size(printDialog.PrintableAreaWidth, printDialog.PrintableAreaHeight));
                printContainer.Arrange(new Rect(new Point(0, 0), printContainer.DesiredSize));

                printDialog.PrintVisual(printContainer, "IDForm Content");
            }
        }

        private void adminbox_Click(object sender, RoutedEventArgs e)
        {
            Login av = new Login();
            av.Show();
            this.Close();
        }
    }
}