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
    /// Interaction logic for UsersWindowAdmin.xaml
    /// </summary>
    public partial class UsersWindowAdmin : Window
    {
        User wybranyUser;
        AirportManagementContext db;
        ObservableCollection<User> listaUserow;
        public UsersWindowAdmin()
        {
            InitializeComponent();
            db = new AirportManagementContext();
            var users = (from p in db.Users select p).ToList();
            listaUserow = new ObservableCollection<User>(users);
            refreshUsersListView();
        }

        void refreshUsersListView()
        {
            UserListView.ItemsSource = listaUserow;
            wybranyUser = listaUserow[0];
            this.DataContext = wybranyUser;
        }

        private void UserListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            wybranyUser = UserListView.SelectedItem as User;
                this.DataContext = wybranyUser;
        }

        private void buttonAddUser_Click(object sender, RoutedEventArgs e)
        {
            User nowy = new User()
            {
                Email = emailField.Text,
                Password = passwordField.Text,
                FirstName = firstNameField.Text,
                LastName = lastNameField.Text,
                SignUpDate = DateTime.Now,
                AdressStreet = streetField.Text,
                AdressNumber = numberField.Text,
                City = cityField.Text,
                Country = countryField.Text
            };
            db.Users.Add(nowy);
            listaUserow.Add(nowy);
            db.SaveChanges();
            refreshUsersListView();
        }

        private void buttonEditUser_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
            refreshUsersListView();
        }

        private void buttonRemoveUser_Click(object sender, RoutedEventArgs e)
        {
            db.Users.Remove(wybranyUser);
            listaUserow.Remove(wybranyUser);
            db.SaveChanges();
            refreshUsersListView();
        }
    }
}
