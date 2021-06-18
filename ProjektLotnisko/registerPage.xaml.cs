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

        AirportManagementContext db;

        public registerPage()
        {
            InitializeComponent();
            db = new AirportManagementContext();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void returnBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow loginWind = new MainWindow();
            this.Close();
            loginWind.ShowDialog();
        }

        private void registerBtn_Click(object sender, RoutedEventArgs e)
        {
            if (passwordField.Text != passwordField1.Text)
            {
                MessageBox.Show("Podaj takie same hasła");
            }
            else
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
              
                MainWindow logowanie = new MainWindow();
                this.Close();
                logowanie.Show();
            }


        }
    }
}
