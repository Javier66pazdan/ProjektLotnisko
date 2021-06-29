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
using ProjektLotnisko.DbClasses;
using ProjektLotnisko.DAL;

namespace ProjektLotnisko.AdminWindows
{
    /// <summary>
    /// Interaction logic for AirportWindowAdmin.xaml
    /// </summary>
    public partial class AirportWindowAdmin : Window
    {
        Airport selectedAirport;
        ObservableCollection<Airport> listAirports;
        DatabaseManager db;
        public AirportWindowAdmin()
        {
            InitializeComponent();
            db = new DatabaseManager();
            listAirports = new ObservableCollection<Airport>(db.airportList());
            ListViewAirport.ItemsSource = listAirports;
        }

        Airport createAirportFromTextBox()
        {
            Airport airport = new Airport()
            {
                Name = nameField.Text,
                Code = codeField.Text,
                City = cityField.Text,
                Province = provinceField.Text,
                CountryAirport = countryField.Text
            };
            return airport;
        }

        private void buttonAddUser_Click(object sender, RoutedEventArgs e)
        {
            Airport newAirport = createAirportFromTextBox();
            db.addAirport(newAirport);
            listAirports.Add(newAirport);
        }

        private void buttonRemoveUser_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewAirport.SelectedValue != null)
            {
                db.removeAirport(selectedAirport);
                listAirports.Remove(selectedAirport);
            }
            else
            {
                MessageBox.Show("Wybierz pozycję do usunięcia", "Błąd");
            }
        }

        private void buttonEditUser_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewAirport.SelectedValue != null)
            {
                Airport editAirport = createAirportFromTextBox();
                editAirport.AirportId = selectedAirport.AirportId;
                db.editAirport(editAirport);
                listAirports[ListViewAirport.SelectedIndex] = editAirport;
            }
            else
            {
                MessageBox.Show("Wybierz pozycję do edycji", "Błąd");
            }
        }

        private void UserListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedAirport = ListViewAirport.SelectedItem as Airport;
            this.DataContext = selectedAirport;
        }
    }
}
