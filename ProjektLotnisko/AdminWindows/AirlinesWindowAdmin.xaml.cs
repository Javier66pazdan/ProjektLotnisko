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
using System.Text.RegularExpressions;

namespace ProjektLotnisko.AdminWindows
{
    /// <summary>
    /// Interaction logic for AirlinesWindowAdmin.xaml
    /// </summary>
    public partial class AirlinesWindowAdmin : Window
    {

        Airline selectedAirline;
        ObservableCollection<Airline> listAirlines;
        ObservableCollection<Airline> listAirlinesSearch;
        DatabaseManager db;
        public AirlinesWindowAdmin()
        {
            InitializeComponent();
            db = new DatabaseManager();
            cbSearch.Items.Add("Nazwa"); cbSearch.Items.Add("Kod"); cbSearch.Items.Add("Kraj");
            cbSearch.SelectedItem = null;
            listAirlines = new ObservableCollection<Airline>(db.airlineList());
            AirlinesListView.ItemsSource = listAirlines;
        }

        Airline createAirlineFromTextBox()
        {
            Airline airline = new Airline()
            {
                Name = nameField.Text,
                Code = codeField.Text,
                YearFounded = Int32.Parse(yearFoundedField.Text),
                CountryAirline = countryField.Text,
                Description = descriptionField.Text
            };
            return airline;
        }

        private void buttonAddUser_Click(object sender, RoutedEventArgs e)
        {
            Airline newAirline = createAirlineFromTextBox();
            db.addAirline(newAirline);
            listAirlines.Add(newAirline);
            filterList();
        }

        private void buttonRemoveUser_Click(object sender, RoutedEventArgs e)
        {
            if (AirlinesListView.SelectedValue != null)
            {
                db.removeAirline(selectedAirline);
                listAirlines.Remove(selectedAirline);
                filterList();
            }
            else
            {
                MessageBox.Show("Wybierz pozycję do usunięcia", "Błąd");
            }
        }

        private void buttonEditUser_Click(object sender, RoutedEventArgs e)
        {
            if (AirlinesListView.SelectedValue != null)
            {
                Airline editedAirline = createAirlineFromTextBox();
                editedAirline.AirlineId = selectedAirline.AirlineId;
                db.editAirline(editedAirline);
                listAirlines[AirlinesListView.SelectedIndex] = editedAirline;
                filterList();
            }
            else
            {
                MessageBox.Show("Wybierz pozycję do edycji", "Błąd");
            }
}

        private void UserListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedAirline = AirlinesListView.SelectedItem as Airline;
            this.DataContext = selectedAirline;
        }

        void filterList()
        {
            if (cbSearch.SelectedItem != null)
            {
                switch (cbSearch.SelectedItem)
                {
                    case "Nazwa":
                        listAirlinesSearch = new ObservableCollection<Airline>(listAirlines.Where
           (x => x.Name.Contains(tbSearch.Text))); break;
                    case "Kod":
                        listAirlinesSearch = new ObservableCollection<Airline>(listAirlines.Where
                  (x => x.Code.Contains(tbSearch.Text))); break;
                    case "Kraj":
                        listAirlinesSearch = new ObservableCollection<Airline>(listAirlines.Where
                 (x => x.CountryAirline.Contains(tbSearch.Text))); break;
                }
                AirlinesListView.ItemsSource = listAirlinesSearch;
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
            AirlinesListView.ItemsSource = listAirlines;
            tbSearch.Text = "Wpisz szukaną wartość";
            cbSearch.SelectedItem = null;
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}
