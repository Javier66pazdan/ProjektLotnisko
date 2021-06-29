﻿using System;
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
using ProjektLotnisko.DbClasses;
using ProjektLotnisko.DAL;

namespace ProjektLotnisko.AdminWindows
{
    /// <summary>
    /// Interaction logic for TicketWindowAdmin.xaml
    /// </summary>
    public partial class TicketWindowAdmin : Window
    {
        Ticket selectedTicket;
        ObservableCollection<Ticket> listTickets;
        ObservableCollection<User> listUsers;
        ObservableCollection<Flight> listFlights;
        DatabaseManager db;
        public TicketWindowAdmin()
        {
            InitializeComponent();
            db = new DatabaseManager();
            listTickets = new ObservableCollection<Ticket>(db.ticketList());
            listFlights = new ObservableCollection<Flight>(db.flightsList());
            listUsers = new ObservableCollection<User>(db.usersList());
            TicketsListView.ItemsSource = listTickets;
            userField.ItemsSource = listUsers;
            flightField.ItemsSource = listFlights;
        }

        Ticket createTicketFromTextBox()
        {
            Ticket ticket = new Ticket()
            {
                User = (User)userField.SelectedItem,
                Flight = (Flight)flightField.SelectedItem,
                State = stateField.Text,
            };
            return ticket;
        }

        private void buttonAddUser_Click(object sender, RoutedEventArgs e)
        {
            Ticket newTicket = createTicketFromTextBox();
            db.addTicket(newTicket);
            listTickets.Add(newTicket);
        }

        private void buttonRemoveUser_Click(object sender, RoutedEventArgs e)
        {
            if (TicketsListView.SelectedValue != null)
            {
                db.removeTicket(selectedTicket);
                listTickets.Remove(selectedTicket);
            }
            else
            {
                MessageBox.Show("Wybierz pozycję do usunięcia", "Błąd");
            }
        }

        private void buttonEditUser_Click(object sender, RoutedEventArgs e)
        {
            if (TicketsListView.SelectedValue != null)
            {
                Ticket editedTicket = createTicketFromTextBox();
                editedTicket.TicketId = selectedTicket.TicketId;
                db.editTicket(editedTicket);
                listTickets[TicketsListView.SelectedIndex] = editedTicket;
            }
            else
            {
                MessageBox.Show("Wybierz pozycję do edycji", "Błąd");
            }
        }

        private void TicketsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedTicket = TicketsListView.SelectedItem as Ticket;
            this.DataContext = selectedTicket;
        }

        private void userField_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var item = userField.SelectedItem as User;
        }

        private void flightField_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
