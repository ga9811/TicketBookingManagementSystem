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
using System.Windows.Threading;

namespace TicketBookingSystemWPF.View
{
    /// <summary>
    /// Interaction logic for ProcessView.xaml
    /// </summary>
    public partial class ProcessView : Window
    {
        private DispatcherTimer timer;
        private int progress;
        public ProcessView()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.05); // 设置计时器间隔为 1 秒
            timer.Tick += Timer_Tick;

            Loaded += ProcessView_Loaded;
        }
        private void ProcessView_Loaded(object sender, RoutedEventArgs e)
        {
            timer.Start(); // start timer
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            progress++;
            Myprogress.Value = progress;

            if (progress >= 100)
            {
                timer.Stop();
               

                // show new login window
                Login login = new Login();
                login.Show();
                this.Hide();
            }
        }

        private void Myprogress_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}
