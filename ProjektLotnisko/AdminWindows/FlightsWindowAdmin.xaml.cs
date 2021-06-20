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
        AirportManagementContext db;
        ObservableCollection<Flight> listaLotow;
        public FlightsWindowAdmin()
        {
            InitializeComponent();
            db = new AirportManagementContext();
            var flights = (from p in db.Flights select p).ToList();
            listaLotow = new ObservableCollection<Flight>(flights);
            FlightListWindow.ItemsSource = listaLotow;
        }
    }
}
