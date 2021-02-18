using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Biblioteka
{
    /// <summary>
    /// Interaction logic for ReturnPage.xaml
    /// </summary>
    public partial class ReturnPage : Window

    {



        private class ReturnGridRow
        {
            public string Imie { get; set; }
            public string Nazwisko { get; set; }
            public string Tytul { get; set; }
            public DateTime DataWypozyczenia { get; set; }
            public DateTime? DataZwrotu { get; set; }
            public string ISBN { get; set; }
            public int LendId { get; set; }

        }
        public ReturnPage()
        {
            InitializeComponent();
        }

        private void showLends()
        {

            LibraryEntities entities = new LibraryEntities();
            var pesel = peselBox.Text;



            var query = from lend in entities.LendHistories
                        where (lend.Reader.Pesel == pesel) && lend.ReturnDate == null && lend.Book.InStock == true
                        select new ReturnGridRow
                        {
                            LendId = lend.ID,
                            Imie = lend.Reader.FirstName,
                            Nazwisko = lend.Reader.LastName,
                            Tytul = lend.Book.Title,
                            DataWypozyczenia = lend.LendingDate,
                            DataZwrotu = lend.ReturnDate,
                            ISBN = lend.BookID
                        };

            returnDataGrid.ItemsSource = query.ToList();
            returnDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            returnDataGrid.Items.Refresh();
        }

        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            showLends();
        }

        private void returnBookBtn_Click(object sender, RoutedEventArgs e)
        {

            LibraryEntities entities = new LibraryEntities();
            ReturnGridRow selectedItem = returnDataGrid.SelectedItem as ReturnGridRow;

            var lendHistory = entities.LendHistories.Find(selectedItem.LendId);
            lendHistory.ReturnDate = DateTime.Now;
            entities.SaveChanges();
            showLends();
        }

    }
}
