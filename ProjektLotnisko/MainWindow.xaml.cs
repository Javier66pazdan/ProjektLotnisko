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
        public MainWindow()
        {
            InitializeComponent();
            db = new AirportManagementContext();
            /*var users = new List<User>
            {
                new User{Email="admin",Password="admin",FirstName="admin",LastName="admin",
                    SignUpDate=new DateTime(2000,5,1,8,30,52), AdressStreet="adminowa",AdressNumber="123"
                    ,Country="Poland" }
            };
            users.ForEach(s => db.Users.Add(s));
            MessageBox.Show("ZAPISANO");
            db.SaveChanges();
            db.Dispose();*/


        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
          
            // string email = emailField.Text;
            //string password = passwordField.GetValue();
            if (db.Users.Any(o => o.Email == emailField.Text))
            {
                //&& o.Password == passwordField.Text
                //PasswordHasher.Verify(passwordField.Text, o.Password))
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
