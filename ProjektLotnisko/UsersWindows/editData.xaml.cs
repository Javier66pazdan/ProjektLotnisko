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
        AirportManagementContext db;
        User wybranyUser;
        ObservableCollection<User> listaUserow;

        public editData()
        {
            InitializeComponent();
            db = new AirportManagementContext();
            var users = (from p in db.Users select p).ToList();
            listaUserow = new ObservableCollection<User>(users);

            for (int i = 0; i < listaUserow.Count; i++)
            {
                if (listaUserow[i].Email == MainWindow.email)
                    wybranyUser = listaUserow[i];
            }
            this.DataContext = wybranyUser;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
            MessageBox.Show("Pomyślnie zmieniono dane!");
            this.Close();
        }
    }
}
