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
        DatabaseManager db;
        public UsersWindowAdmin()
        {
            InitializeComponent();
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
            }
            else
            {
                MessageBox.Show("Wybierz pozycję do usunięcia", "Błąd");
            }
        }
    }
}
