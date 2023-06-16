using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TicketBookingSystemWPF
{
     //<summary>
     //Interaction logic for App.xaml
     //</summary>
    public partial class App : Application

    {

        //public static void Main()
        //{
        //    App app = new App();
        //    app.InitializeComponent();
        //    app.OnStartup(new StartupEventArgs(null)); // 调用 OnStartup 方法
        //    app.Run();
        //}
        protected override void OnStartup(StartupEventArgs e)
        {
            //base.OnStartup(e);

            //TicketBookingSystemWPF.View.ProcessView processView = new TicketBookingSystemWPF.View.ProcessView();
            //processView.Show();
        }

    }
}
