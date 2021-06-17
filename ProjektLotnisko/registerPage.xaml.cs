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

namespace ProjektLotnisko
{
    /// <summary>
    /// Logika interakcji dla klasy registerPage.xaml
    /// </summary>
    public partial class registerPage : Window
    {
        public registerPage()
        {
            InitializeComponent();
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

        }
    }
}
