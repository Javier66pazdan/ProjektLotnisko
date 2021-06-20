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
using ProjektLotnisko.AdminWindows;

namespace ProjektLotnisko
{
    /// <summary>
    /// Logika interakcji dla klasy MainPage.xaml
    /// </summary>
    public partial class MainPage : Window
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //administratorPanel.Visibility = Visibility.Hidden;
        }

        private void UserPanelButton_Click(object sender, RoutedEventArgs e)
        {
            UsersWindowAdmin usersWindowAdmin = new UsersWindowAdmin();
            usersWindowAdmin.ShowDialog();
        }
    }
}
