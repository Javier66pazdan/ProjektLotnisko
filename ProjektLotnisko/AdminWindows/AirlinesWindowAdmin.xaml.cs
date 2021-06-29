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
    /// Interaction logic for AirlinesWindowAdmin.xaml
    /// </summary>
    public partial class AirlinesWindowAdmin : Window
    {
        Airline selectedAirline;
        ObservableCollection<Airline> listAirlines;
        DatabaseManager db;
        public AirlinesWindowAdmin()
        {
            InitializeComponent();
            db = new DatabaseManager();
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
        }

        private void buttonRemoveUser_Click(object sender, RoutedEventArgs e)
        {
            if (AirlinesListView.SelectedValue != null)
            {
                db.removeAirline(selectedAirline);
                listAirlines.Remove(selectedAirline);
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
    }
}
