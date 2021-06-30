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
using ProjektLotnisko.AdminWindows;
using ProjektLotnisko.UsersWindows;
using ProjektLotnisko.DbClasses;
using ProjektLotnisko.DAL;


namespace ProjektLotnisko
{
    /// <summary>
    /// Logika interakcji dla klasy MainPage.xaml
    /// </summary>
    public partial class MainPage : Window
    {
        public MainPage()
        {
            InitializeComponent();
            nameLabel.Content = "Welcome back, " + MainWindow.email;
            if (MainWindow.accountType!="admin")
            {
                UserPanelButton.Visibility = Visibility.Hidden;
                btAirlinesAdminPanel.Visibility = Visibility.Hidden;
                btAirportsAdminWindow.Visibility = Visibility.Hidden;
                btFlightsAdminPanel.Visibility = Visibility.Hidden;
                btTicketsAdminPanel.Visibility = Visibility.Hidden;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //administratorPanel.Visibility = Visibility.Hidden;
        }

        private void UserPanelButton_Click(object sender, RoutedEventArgs e)
        {
            UsersWindowAdmin usersWindowAdmin = new UsersWindowAdmin();
            usersWindowAdmin.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            editData window = new editData();
            window.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AirlinesWindowAdmin airlinesWindowAdmin = new AirlinesWindowAdmin();
            airlinesWindowAdmin.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            FlightsWindowAdmin flightsWindowAdmin = new FlightsWindowAdmin();
            flightsWindowAdmin.ShowDialog();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            AirportWindowAdmin airportWindowAdmin = new AirportWindowAdmin();
            airportWindowAdmin.ShowDialog();
        }

        private void btTicketsAdmin_Click(object sender, RoutedEventArgs e)
        {
            TicketWindowAdmin ticketWindowAdmin = new TicketWindowAdmin();
            ticketWindowAdmin.ShowDialog();
        }

        private void btLogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow noweOkno = new MainWindow();
            this.Close();
            noweOkno.ShowDialog();
        }
    }
}
