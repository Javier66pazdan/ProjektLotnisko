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
        ObservableCollection<Flight> listFlightsSearch;
        ObservableCollection<Flight> listFlightsSearchHelper;
        ObservableCollection<Airline> listAirline;
        ObservableCollection<Airport> listAirports;
        ObservableCollection<User> listUsers;
        bool changedDateMin, changedDateMax;

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
            changedDateMin = false; changedDateMax = false;

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
                State = "Zarezerwowany",
            };
            return ticket;
        }

        private void buyTicketBtn_Click(object sender, RoutedEventArgs e)
        {
            Ticket newTicket = buyNewTicket();
            db.addTicket(newTicket);
            MessageBox.Show("Kupiono bilet");
        }

        private void btSearch_Click(object sender, RoutedEventArgs e)
        {
            listFlightsSearch = listFlights;
            if (tbFrom.Text != "")
            {
                listFlightsSearchHelper = new ObservableCollection<Flight>(listFlightsSearch.Where
           (x => x.AirportFromLocation.Name.Contains(tbFrom.Text))); listFlightsSearch = listFlightsSearchHelper;
            }
            if (tbTo.Text != "")
            {
                listFlightsSearchHelper = new ObservableCollection<Flight>(listFlightsSearch.Where
           (x => x.AirportToLocation.Name.Contains(tbTo.Text))); listFlightsSearch = listFlightsSearchHelper;
            }
            if (changedDateMin)
            {
                listFlightsSearchHelper = new ObservableCollection<Flight>(listFlightsSearch.Where
           (x => x.TimeDeparture.Day>= datePickerTimeMin.SelectedDate.Value.Day &&
           x.TimeDeparture.Month>=datePickerTimeMin.SelectedDate.Value.Month));
                listFlightsSearch = listFlightsSearchHelper;
            }
            if (changedDateMax)
            {
                listFlightsSearchHelper = new ObservableCollection<Flight>(listFlightsSearch.Where
           (x => x.TimeDeparture.Day <= datePickerTimeMax.SelectedDate.Value.Day &&
           x.TimeDeparture.Month <= datePickerTimeMax.SelectedDate.Value.Month));
                listFlightsSearch = listFlightsSearchHelper;
            }
            if (tbAirline.Text != "")
            {
                listFlightsSearchHelper = new ObservableCollection<Flight>(listFlightsSearch.Where
               (x => x.Airline.Name.Contains(tbAirline.Text))); listFlightsSearch = listFlightsSearchHelper;
            }
            if (tbCode.Text !="")
            {
                listFlightsSearchHelper = new ObservableCollection<Flight>(listFlightsSearch.Where
              (x => x.FlightCode.Contains(tbCode.Text))); listFlightsSearch = listFlightsSearchHelper;
            }
            if (tbPriceMin.Text != "")
            {
                listFlightsSearchHelper = new ObservableCollection<Flight>(listFlightsSearch.Where
              (x => x.TicketPrice >= Int32.Parse(tbPriceMin.Text))); listFlightsSearch = listFlightsSearchHelper;
            }
            if (tbPriceMax.Text != "")
            {
                listFlightsSearchHelper = new ObservableCollection<Flight>(listFlightsSearch.Where
              (x => x.TicketPrice <= Int32.Parse(tbPriceMax.Text))); listFlightsSearch = listFlightsSearchHelper;
            }

            FlightListView.ItemsSource = listFlightsSearch;
        }

        private void btReset_Click(object sender, RoutedEventArgs e)
        {
            FlightListView.ItemsSource = listFlights;
            changedDateMin = false; changedDateMax = false;
        }

        private void datePickerTimeMin_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            changedDateMin = true;
        }

        private void datePickerTimeMax_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            changedDateMax = true;
        }
    }
}
