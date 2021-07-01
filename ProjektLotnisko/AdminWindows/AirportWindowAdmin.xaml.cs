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
        ObservableCollection<Airport> listAirportsSearch;
        DatabaseManager db;
        public AirportWindowAdmin()
        {
            InitializeComponent();
            db = new DatabaseManager();
            cbSearch.Items.Add("Nazwa"); cbSearch.Items.Add("Kod"); cbSearch.Items.Add("Miasto");
            cbSearch.Items.Add("Kraj");
            cbSearch.SelectedItem = null;
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
            filterList();
        }

        private void buttonRemoveUser_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewAirport.SelectedValue != null)
            {
                db.removeAirport(selectedAirport);
                listAirports.Remove(selectedAirport);
                filterList();
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
                filterList();
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

        void filterList()
        {
            if (cbSearch.SelectedItem != null)
            {
                switch (cbSearch.SelectedItem)
                {
                    case "Nazwa":
                        listAirportsSearch = new ObservableCollection<Airport>(listAirports.Where
           (x => x.Name.Contains(tbSearch.Text))); break;
                    case "Kod":
                        listAirportsSearch = new ObservableCollection<Airport>(listAirports.Where
                  (x => x.Code.Contains(tbSearch.Text))); break;
                    case "Miasto":
                        listAirportsSearch = new ObservableCollection<Airport>(listAirports.Where
                 (x => x.City.Contains(tbSearch.Text))); break;
                    case "Kraj":
                        listAirportsSearch = new ObservableCollection<Airport>(listAirports.Where
                  (x => x.CountryAirport.Contains(tbSearch.Text))); break;
                }
                ListViewAirport.ItemsSource = listAirportsSearch;
            }
        }

        private void btSearchStart_Click(object sender, RoutedEventArgs e)
        {
            if (cbSearch.SelectedItem == null)
            {
                MessageBox.Show("Wybierz pole do przeszukania");
            }
            else
            {
                filterList();
            }
        }

        private void btSearchReset_Click(object sender, RoutedEventArgs e)
        {
            ListViewAirport.ItemsSource = listAirports;
            tbSearch.Text = "Wpisz szukaną wartość";
            cbSearch.SelectedItem = null;
        }
    }
}
