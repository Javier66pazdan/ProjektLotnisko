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
    /// metody do obslugi okna modyfikacji listy uzytkownikow
    /// dodawanie, usuwanie, edycja uzytkownikow
    /// 
    public partial class UsersWindowAdmin : Window
    {
        User selectedUser;
        ObservableCollection<User> listaUserow;
        ObservableCollection<User> listaUserowSearch;
        DatabaseManager db;
        public UsersWindowAdmin()
        {
            InitializeComponent();
            cbSearch.Items.Add("Email"); cbSearch.Items.Add("Nazwisko"); cbSearch.Items.Add("Miasto"); 
            cbSearch.Items.Add("Ulica");  cbSearch.Items.Add("Kraj");
            cbSearch.SelectedItem = null;
            db = new DatabaseManager();
            listaUserow = new ObservableCollection<User>(db.usersList());
            UserListView.ItemsSource = listaUserow;
            
        }

        private void UserListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedUser = UserListView.SelectedItem as User;
                this.DataContext = selectedUser;
        }

        User createUserFromTextBox()
        {
            User user = new User()
            {
                Email = emailField.Text,
                Password = passwordField.Text,
                FirstName = firstNameField.Text,
                LastName = lastNameField.Text,
                SignUpDate = DateTime.Now,
                AdressStreet = streetField.Text,
                AdressNumber = numberField.Text,
                City = cityField.Text,
                Country = countryField.Text,
                AccountType = accountTypeField.Text
            };
            return user;
        }

        private void buttonAddUser_Click(object sender, RoutedEventArgs e)
        {
            User newUser = createUserFromTextBox();
            if (db.isEmailAvailable(newUser.Email))
            {
                db.addUser(newUser);
                listaUserow.Add(newUser);
                filterList();
            }
            else
            {
                MessageBox.Show("Email zajęty", "Błąd");
            }
        }

        private void buttonEditUser_Click(object sender, RoutedEventArgs e)
        {
            if (UserListView.SelectedValue != null)
            {
                User editedUser = createUserFromTextBox();
                editedUser.UserId = selectedUser.UserId;
                db.editUser(editedUser);
                listaUserow[UserListView.SelectedIndex] = editedUser;
                filterList();
            }
            else
            {
                MessageBox.Show("Wybierz pozycję do edycji", "Błąd");
            }
        }

        private void buttonRemoveUser_Click(object sender, RoutedEventArgs e)
        {
            if (UserListView.SelectedValue != null)
            {
                db.removeUser(selectedUser);
                listaUserow.Remove(selectedUser);
                filterList();
            }
            else
            {
                MessageBox.Show("Wybierz pozycję do usunięcia", "Błąd");
            }
        }

        void filterList()
        {
            if (cbSearch.SelectedItem != null)
            {
                switch (cbSearch.SelectedItem)
                {
                    case "Nazwisko":
                        listaUserowSearch = new ObservableCollection<User>(listaUserow.Where
           (x => x.LastName.Contains(tbSearch.Text))); break;
                    case "Email":
                        listaUserowSearch = new ObservableCollection<User>(listaUserow.Where
                  (x => x.Email.Contains(tbSearch.Text))); break;
                    case "Miasto":
                        listaUserowSearch = new ObservableCollection<User>(listaUserow.Where
                 (x => x.City.Contains(tbSearch.Text))); break;
                    case "Ulica":
                        listaUserowSearch = new ObservableCollection<User>(listaUserow.Where
                  (x => x.AdressStreet.Contains(tbSearch.Text))); break;
                    case "Kraj":
                        listaUserowSearch = new ObservableCollection<User>(listaUserow.Where
                   (x => x.Country.Contains(tbSearch.Text))); break;
                }
                UserListView.ItemsSource = listaUserowSearch;
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
            UserListView.ItemsSource = listaUserow;
            tbSearch.Text = "Wpisz szukaną wartość";
            cbSearch.SelectedItem = null;
        }
    }
}
