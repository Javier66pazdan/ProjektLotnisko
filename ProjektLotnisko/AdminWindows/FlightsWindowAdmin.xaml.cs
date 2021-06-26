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
            refreshUsersListView();
        }
        void refreshUsersListView()
        {
            FlightListWindow.ItemsSource = listFlights;
        }

    }
}
