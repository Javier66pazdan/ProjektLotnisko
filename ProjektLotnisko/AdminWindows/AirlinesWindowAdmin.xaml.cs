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
    /// Interaction logic for AirlinesWindowAdmin.xaml
    /// </summary>
    public partial class AirlinesWindowAdmin : Window
    {
        Airline selectedAirline;
        ObservableCollection<Airline> listAirlines;
        DatabaseManager db;
        public AirlinesWindowAdmin()
        {
            db = new DatabaseManager();
            listaUserow = new ObservableCollection<User>(db.usersList());
            refreshUsersListView();
            InitializeComponent();
        }

        private void buttonAddUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonRemoveUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonEditUser_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
