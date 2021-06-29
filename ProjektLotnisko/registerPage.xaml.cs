using System;
using System.Collections.Generic;
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

namespace ProjektLotnisko
{
    /// <summary>
    /// Logika interakcji dla klasy registerPage.xaml
    /// </summary>
    public partial class registerPage : Window
    {

        //AirportManagementContext db;
        DatabaseManager db;
        DAL.Validation walidacja;
        public registerPage()
        {
            InitializeComponent();
            walidacja = new DAL.Validation();
            db = new DatabaseManager();
            //db = new AirportManagementContext();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void returnBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow loginWind = new MainWindow();
            this.Close();
            loginWind.Show();
        }

        /*protected void register()
        {
            User nowy = new User()
            {
                Email = emailField.Text,
                Password = passwordField1.Text,
                FirstName = nameField.Text,
                LastName = surnameField.Text,
                SignUpDate = DateTime.Now,
                AdressStreet = adressStreetField.Text,
                AdressNumber = adressNumberField.Text,
                Country = "Poland"
            };

            db.Users.Add(nowy);
            db.SaveChanges();
            MessageBox.Show("Pomyślnie utworzono konto");
        }
        */
        private void registerBtn_Click(object sender, RoutedEventArgs e)
        {
            /*if (nameField.Text == "" || surnameField.Text == "" || emailField.Text == "" ||
                passwordField.Text == "" || passwordField1.Text == "" || adressStreetField.Text == "" ||
                adressNumberField.Text == "")
            {
                MessageBox.Show("Pola nie mogą być puste!");
            }
            else if (nameField.Text == "Imie" || surnameField.Text == "Nazwisko" || emailField.Text == "Email" ||
              passwordField.Text == "Haslo" || passwordField1.Text == "Powtorz haslo" || adressStreetField.Text == "Ulica" ||
              adressNumberField.Text == "numer domu")
            {
                MessageBox.Show("Wprowadz prawidlowe dane");
            }
            else if (passwordField.Text != passwordField1.Text)
            {
                MessageBox.Show("Podaj takie same hasła");
            }
            else
            {*/
            //registerPage objekt2 = new registerPage();
            //objekt2.register();
            //}
            User nowy = new User()
            {
                Email = emailField.Text,
                Password = passwordField1.Text,
                FirstName = nameField.Text,
                LastName = surnameField.Text,
                SignUpDate = DateTime.Now,
                AdressStreet = adressStreetField.Text,
                AdressNumber = adressNumberField.Text,
                City = cityField.Text,
                Country = countryField.Text
            };
            if (passwordField.Text != passwordField1.Text)
            {
                MessageBox.Show("Podaj takie same hasła");
            }
            else if (!walidacja.IsEmailValid(emailField.Text))
            {
                MessageBox.Show("Niepoprawny adres email", "Błąd");
            }
            else if (walidacja.isUserValid(nowy))
            {
                MessageBox.Show("Wypełnij wszystkie pola", "Błąd");
            }
            else if(!db.isEmailAvailable(emailField.Text))
            {
                MessageBox.Show("Email jest zajęty", "Błąd");
            }
            else
            {
                nowy.Password = PasswordHasher.Hash(passwordField.Text);
                db.addUser(nowy);
                MessageBox.Show("Konto utworzono", "Sukces");
                MainWindow logowanie = new MainWindow();
                this.Close();
                logowanie.Show();
            }
        }

        private void nameField_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (nameField.Text == "Imie")
                nameField.Clear();
        }

        private void nameField_LostFocus(object sender, RoutedEventArgs e)
        {
            if (nameField.Text == "")
                nameField.Text = "Imie";
        }

        private void surnameField_LostFocus(object sender, RoutedEventArgs e)
        {
            if (surnameField.Text == "")
                surnameField.Text = "Nazwisko";
        }

        private void surnameField_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (surnameField.Text == "Nazwisko")
                surnameField.Clear();
        }

        private void emailField_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (emailField.Text == "Email")
                emailField.Clear();
        }

        private void emailField_LostFocus(object sender, RoutedEventArgs e)
        {
            if (emailField.Text == "")
                emailField.Text = "Email";
        }

        private void passwordField1_LostFocus(object sender, RoutedEventArgs e)
        {
            if (passwordField1.Text == "")
                passwordField1.Text = "Haslo";
        }

        private void passwordField1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (passwordField1.Text == "Haslo")
                passwordField1.Clear();
        }

        private void passwordField_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (passwordField.Text == "Powtorz haslo")
                passwordField.Clear();
        }

        private void passwordField_LostFocus(object sender, RoutedEventArgs e)
        {
            if (passwordField.Text == "")
                passwordField.Text = "Powtorz haslo";
        }

        private void adressStreetField_LostFocus(object sender, RoutedEventArgs e)
        {
            if (adressStreetField.Text == "")
                adressStreetField.Text = "Ulica";
        }

        private void adressStreetField_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (adressStreetField.Text == "Ulica")
                adressStreetField.Clear();
        }

        private void adressNumberField_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (adressNumberField.Text == "numer domu")
                adressNumberField.Clear();
        }

        private void adressNumberField_LostFocus(object sender, RoutedEventArgs e)
        {
            if (adressNumberField.Text == "")
                adressNumberField.Text = "numer domu";
        }

        private void cityField_LostFocus(object sender, RoutedEventArgs e)
        {
            if (cityField.Text == "")
                cityField.Text = "Miasto";
        }

        private void cityField_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (cityField.Text == "Miasto")
                cityField.Clear();
        }

        private void countryField_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (countryField.Text == "Kraj")
                countryField.Clear();
        }

        private void countryField_LostFocus(object sender, RoutedEventArgs e)
        {
            if (countryField.Text == "")
                countryField.Text = "Kraj";
        }
    }
}
