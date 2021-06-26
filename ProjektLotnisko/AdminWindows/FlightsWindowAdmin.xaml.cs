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

namespace ProjektLotnisko.AdminWindows
{
    /// <summary>
    /// Interaction logic for FlightsWindowAdmin.xaml
    /// </summary>
    public partial class FlightsWindowAdmin : Window
    {
        Flight selectedFlight;
        ObservableCollection<Flight> listFlights;
        ObservableCollection<Airline> listAirline;
        DatabaseManager db;
        public FlightsWindowAdmin()
        {
            InitializeComponent();
            db = new DatabaseManager();
            listFlights = new ObservableCollection<Flight>(db.flightsList());
            listAirline = new ObservableCollection<Airline>(db.airlineList());
            refreshFlightsListView();
        }
        void refreshFlightsListView()
        {
            FlightListView.ItemsSource = listFlights;
            airlineField.ItemsSource = listAirline;
        }

        Flight createFlightFromTextBox()
        {
            Flight flight = new Flight()
            {
                AirportFromLocation = (Airport)fromField.SelectedItem,
                AirportToLocation = (Airport)toField.SelectedItem,
                Airline = (Airline)airlineField.SelectedItem,
                TimeArrival = DateTime.Now,
                TimeDeparture = DateTime.Now,
                FlightCode = flightCodeField.Text,
                SeatsNumber = Int32.Parse(seatsNumberField.Text)
            };
            return flight;
        }

        private void buttonAddUser_Click(object sender, RoutedEventArgs e)
        {
            Flight newFlight = createFlightFromTextBox();
            db.addFlight(newFlight);
            listFlights.Add(newFlight);
            refreshFlightsListView();
        }

        private void buttonRemoveUser_Click(object sender, RoutedEventArgs e)
        {
            if (FlightListView.SelectedValue != null)
            {
                db.removeFlight(selectedFlight);
                listFlights.Remove(selectedFlight);
                refreshFlightsListView();
            }
            else
            {
                MessageBox.Show("Wybierz pozycję do usunięcia", "Błąd");
            }
        }

        private void buttonEditUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FlightListWindow_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedFlight = FlightListView.SelectedItem as Flight;
                this.DataContext = selectedFlight;
        }
    }
}
