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
        DatabaseManager db;
        Flight selectedFlight;

        public checkFlight()
        {
            InitializeComponent();
            db = new DatabaseManager();
            listFlights = new ObservableCollection<Flight>(db.flightsList());
            listAirline = new ObservableCollection<Airline>(db.airlineList());
            listAirports = new ObservableCollection<Airport>(db.airportList());
            FlightListView.ItemsSource = listFlights;

        }
     

        private void FlightListWindow_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedFlight = FlightListView.SelectedItem as Flight;
        }

        Ticket buyNewTicket()
        {
            Ticket ticket = new Ticket()
            {
                User =(User)MainWindow.zalogowanyUser,
                Flight = (Flight)selectedFlight,
                State = stateField.Text,
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
