using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using ProjektLotnisko.DAL;
using ProjektLotnisko.DbClasses;

namespace ProjektLotnisko.UsersWindows
{
    /// <summary>
    /// Logika interakcji dla klasy checkFlight.xaml
    /// </summary>
    public partial class checkFlight : Window
    {
        ObservableCollection<Flight> listFlights;
        ObservableCollection<Airline> listAirline;
        ObservableCollection<Airport> listAirports;
        ObservableCollection<User> listUsers;

        DatabaseManager db;
        Flight selectedFlight;

        public checkFlight()
        {
            InitializeComponent();
            db = new DatabaseManager();
            listFlights = new ObservableCollection<Flight>(db.flightsList());
            listAirline = new ObservableCollection<Airline>(db.airlineList());
            listAirports = new ObservableCollection<Airport>(db.airportList());
            listUsers = new ObservableCollection<User>(db.usersList());

            FlightListView.ItemsSource = listFlights;

        }

        private void FlightListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedFlight = FlightListView.SelectedItem as Flight;
        }

        Ticket buyNewTicket()
        {
            ObservableCollection<User> listuser2 = new ObservableCollection<User>(listUsers.Where
              (x => x.Email.Contains(MainWindow.zalogowanyUser.Email)));
            User uzytkownik = listuser2[0];
            Ticket ticket = new Ticket()
            {
                User = uzytkownik,
                Flight = selectedFlight,
                State = "zarezerwowany",
            };
            return ticket;
        }

        private void buyTicketBtn_Click(object sender, RoutedEventArgs e)
        {
            Ticket newTicket = buyNewTicket();
            db.addTicket(newTicket);
            MessageBox.Show("Kupiono bilet");
        }

    }
}
