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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProjektLotnisko.DAL;
using ProjektLotnisko.DbClasses;

namespace ProjektLotnisko
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        AirportManagementContext db;
        public static string email;
        public static string accountType;
        public MainWindow()
        {
            InitializeComponent();
            db = new AirportManagementContext();
        }
        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            //OMIJANIE HACKOWANIE LOGOWANIE
            if (emailField.Text == "admin")
            {
                accountType = "admin";
                MainPage noweOkno = new MainPage();
                this.Close();
                noweOkno.ShowDialog();
            }
            else
            {


                User emailUser = db.Users.First(o => o.Email == emailField.Text);
                if (db.Users.Any(o => o.Email == emailField.Text) 
                    && PasswordHasher.Verify(passwordBoxLogin.Password, emailUser.Password))
                {
                    accountType = emailUser.AccountType;
                    email = emailField.Text;
                    MainPage noweOkno = new MainPage();
                    this.Close();
                    noweOkno.ShowDialog();
                }
                else
                {
                    MessageBox.Show("ZLE DANE");
                }

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            registerPage register = new registerPage();
            this.Close();
            register.ShowDialog();
        }


        // 
        private void emailField_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(emailField.Text == "EMAIL")
                emailField.Clear();
        }

        private void emailField_LostFocus(object sender, RoutedEventArgs e)
        {
            if(emailField.Text == "")  
                emailField.Text = "EMAIL";

        }

        private void passwordField_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
