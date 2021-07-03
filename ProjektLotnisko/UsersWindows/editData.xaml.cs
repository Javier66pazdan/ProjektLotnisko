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

namespace ProjektLotnisko.UsersWindows
{
    /// <summary>
    /// Logika interakcji dla klasy editData.xaml
    /// </summary>
    public partial class editData : Window
    {
        DatabaseManager db;
        User wybranyUser;
        String emailBefore;

        public editData()
        {
            InitializeComponent();
            db = new DatabaseManager();
            wybranyUser = db.findUserWithEmail(MainWindow.zalogowanyUser.Email);
            emailBefore = wybranyUser.Email;
            this.DataContext = wybranyUser;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (passBox1.Password==passBox2.Password)
            {
                wybranyUser.Password = PasswordHasher.Hash(passBox1.Password);
            }
            if (emailField.Text!=emailBefore && !db.isEmailAvailable(emailField.Text))
            {
                MessageBox.Show("Email jest zajęty", "Błąd");
            }
            else
            {
                db.saveChanges();
                MessageBox.Show("Pomyślnie zmieniono dane!");
                this.Close();
            }
        }
    }
}
