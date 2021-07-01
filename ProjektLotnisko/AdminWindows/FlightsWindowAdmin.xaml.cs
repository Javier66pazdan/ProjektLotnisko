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
        ObservableCollection<Flight> listFlightsSearch;
        ObservableCollection<Airline> listAirline;
        ObservableCollection<Airport> listAirports;
        DatabaseManager db;
        public FlightsWindowAdmin()
        {
            InitializeComponent();
            db = new DatabaseManager();
            cbSearch.Items.Add("Skąd"); cbSearch.Items.Add("Do"); cbSearch.Items.Add("Linia lotnicza");
            cbSearch.Items.Add("Kod"); cbSearch.Items.Add("Liczba pasażerów (więcej niż)");
            cbSearch.Items.Add("Liczba pasażerów (mniej niż)"); cbSearch.Items.Add("Cena (więcej niż)");
            cbSearch.Items.Add("Cena (mniej niż)"); cbSearch.Items.Add("Miesiąc wylotu (liczba)");
            cbSearch.Items.Add("Miesiąc przylotu (liczba)");
            cbSearch.SelectedItem = null;
            listFlights = new ObservableCollection<Flight>(db.flightsList());
            listAirline = new ObservableCollection<Airline>(db.airlineList());
            listAirports = new ObservableCollection<Airport>(db.airportList());
            FlightListView.ItemsSource = listFlights;
            airlineField.ItemsSource = listAirline;
            toField.ItemsSource = listAirports;
            fromField.ItemsSource = listAirports;
        }

        Flight createFlightFromTextBox()
        {
            TimeSpan tsArrival = new TimeSpan(Int32.Parse(hoursArrivalTimeField.Text), 
                Int32.Parse(minutesArrivalTimeField.Text), 0);
            TimeSpan tsDeparture = new TimeSpan(Int32.Parse(hoursDepartureTimeField.Text),
                Int32.Parse(minutesDepartureTimeField.Text), 0);
            DateTime dateTimeArrival = (DateTime)datePickerArrivalTime.SelectedDate+ tsArrival;
            DateTime dateTimeDeparture = (DateTime)datePickerDepartureTime.SelectedDate + tsDeparture;
            Flight flight = new Flight()
            {
                AirportFromLocation = (Airport)fromField.SelectedItem,
                AirportToLocation = (Airport)toField.SelectedItem,
                Airline = (Airline)airlineField.SelectedItem,
                TimeArrival = dateTimeArrival,
                TimeDeparture = dateTimeDeparture,
                FlightCode = flightCodeField.Text,
                SeatsNumber = Int32.Parse(seatsNumberField.Text),
                TicketPrice = Int32.Parse(ticketPriceField.Text)
            };
            return flight;
        }

        private void buttonAddUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Flight newFlight = createFlightFromTextBox();
                db.addFlight(newFlight);
                listFlights.Add(newFlight);
                filterList();
            }
            catch
            {
                MessageBox.Show("Błędne wartości");
            }
        }

        private void buttonRemoveUser_Click(object sender, RoutedEventArgs e)
        {
            if (FlightListView.SelectedValue != null)
            {
                db.removeFlight(selectedFlight);
                listFlights.Remove(selectedFlight);
                filterList();
            }
            else
            {
                MessageBox.Show("Wybierz pozycję do usunięcia", "Błąd");
            }
        }

        private void buttonEditUser_Click(object sender, RoutedEventArgs e)
        {
            if (FlightListView.SelectedValue != null)
            {
                Flight editedFlight;
                try
                {
                    editedFlight = createFlightFromTextBox();
                    editedFlight.flightId = selectedFlight.flightId;
                    db.editFlight(editedFlight);
                    listFlights[FlightListView.SelectedIndex] = editedFlight;
                    filterList();
                }
                catch
                {
                    MessageBox.Show("Błędne wartości");
                }
            }
            else
            {
                MessageBox.Show("Wybierz pozycję do edycji", "Błąd");
            }
        }

        private void FlightListWindow_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedFlight = FlightListView.SelectedItem as Flight;
            this.DataContext = selectedFlight;
        }

        private void fromField_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = fromField.SelectedItem as Airport;
        }

        private void toField_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = toField.SelectedItem as Airport;
        }

        private void airlineField_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
         var item = airlineField.SelectedItem as Airline;
        }

        void filterList()
        {
            if (cbSearch.SelectedItem != null)
            {
                switch (cbSearch.SelectedItem)
                {
                    case "Skąd":
                        listFlightsSearch = new ObservableCollection<Flight>(listFlights.Where
           (x => x.AirportFromLocation.Name.Contains(tbSearch.Text))); break;
                    case "Do":
                        listFlightsSearch = new ObservableCollection<Flight>(listFlights.Where
           (x => x.AirportToLocation.Name.Contains(tbSearch.Text))); break;
                    case "Linia lotnicza":
                        listFlightsSearch = new ObservableCollection<Flight>(listFlights.Where
           (x => x.Airline.Name.Contains(tbSearch.Text))); break;
                    case "Kod":
                        listFlightsSearch = new ObservableCollection<Flight>(listFlights.Where
           (x => x.FlightCode.Contains(tbSearch.Text))); break;
                    case "Liczba (więcej niż)":
                        listFlightsSearch = new ObservableCollection<Flight>(listFlights.Where
           (x => x.SeatsNumber >= Int32.Parse(tbSearch.Text))); break;
                    case "Liczba(mniej niż)":
                        listFlightsSearch = new ObservableCollection<Flight>(listFlights.Where
           (x => x.SeatsNumber <= Int32.Parse(tbSearch.Text))); break;
                    case "Cena (więcej niż)":
                        listFlightsSearch = new ObservableCollection<Flight>(listFlights.Where
           (x => x.TicketPrice >= Int32.Parse(tbSearch.Text))); break;
                    case "Cena (mniej niż)":
                        listFlightsSearch = new ObservableCollection<Flight>(listFlights.Where
           (x => x.TicketPrice <= Int32.Parse(tbSearch.Text))); break;
                    case "Miesiąc wylotu(liczba)":
                        listFlightsSearch = new ObservableCollection<Flight>(listFlights.Where
           (x => x.TimeDeparture.Month.ToString().Contains(tbSearch.Text))); break;
                    case "Miesiąc przylotu(liczba)":
                        listFlightsSearch = new ObservableCollection<Flight>(listFlights.Where
           (x => x.TimeArrival.Month.ToString().Contains(tbSearch.Text))); break;
                }
                FlightListView.ItemsSource = listFlightsSearch;
            }
        }

        private void btSearchStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                filterList();
            }
            catch
            {
                MessageBox.Show("Niepoprawne wartości wyszukiwania");
            }
        }

        private void btSearchReset_Click(object sender, RoutedEventArgs e)
        {
            FlightListView.ItemsSource = listFlights;
            tbSearch.Text = "Wpisz szukaną wartość";
            cbSearch.SelectedItem = null;
        }
    }
}
