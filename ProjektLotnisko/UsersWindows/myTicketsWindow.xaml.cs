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
    /// Logika interakcji dla klasy myTicketsWindow.xaml
    /// </summary>
    public partial class myTicketsWindow : Window
    {
        ObservableCollection<Flight> listFlights;
        ObservableCollection<Airline> listAirline;
        ObservableCollection<Airport> listAirports;
        ObservableCollection<Ticket> listTickets;
        Ticket selectedTicket;
        DatabaseManager db;
        public myTicketsWindow()
        {
            InitializeComponent();
            db = new DatabaseManager();
            listFlights = new ObservableCollection<Flight>(db.flightsList());
            listAirline = new ObservableCollection<Airline>(db.airlineList());
            listAirports = new ObservableCollection<Airport>(db.airportList());
            listTickets = new ObservableCollection<Ticket>(db.ticketForUserList
                (db.findUserWithEmail(MainWindow.zalogowanyUser.Email)));
            TicketList1.ItemsSource = listTickets;
        }

        private void btCancelTicket_Click(object sender, RoutedEventArgs e)
        {
            editTicket("Anulowany");
        }

        private void TicketList1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedTicket = TicketList1.SelectedItem as Ticket;
        }

        public void editTicket(string newState)
        {
            if (TicketList1.SelectedValue != null)
            {

                Ticket editedTicket = selectedTicket;
                editedTicket.State = newState;
                editedTicket.TicketId = selectedTicket.TicketId;
                db.editTicket(editedTicket);
                listTickets[TicketList1.SelectedIndex] = editedTicket;
                TicketList1.ItemsSource = listTickets;
            }
            else
            {
                MessageBox.Show("Wybierz bilet do zmiany", "Błąd");
            }
        }

        private void btPayTicket_Click(object sender, RoutedEventArgs e)
        {
            editTicket("Opłacony");
        }
    }
}
