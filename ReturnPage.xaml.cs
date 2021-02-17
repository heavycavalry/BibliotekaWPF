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

        LibraryEntities entities = new LibraryEntities();

        public class ReturnGridRow
        {
            public LendHistory Lend { get; set; }
            public string Imie { get; set; }
            public string Nazwisko { get; set; }
            public string Ksiazka { get; set; }
            public DateTime DataWypozyczenia { get; set; }
            public DateTime? DataZwrotu { get; set; }

        }
        public ReturnPage()
        {
            InitializeComponent();
        }

        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            var pesel = peselBox.Text;

           

            var query = from lend in entities.LendHistories
                        where (lend.Reader.Pesel == pesel) && lend.ReturnDate == null && lend.Book.InStock == true
                        select new ReturnGridRow
                        {
                            Lend = lend,
                            Imie = lend.Reader.FirstName,
                            Nazwisko = lend.Reader.LastName,
                            Ksiazka = lend.Book.Title,
                            DataWypozyczenia = lend.LendingDate,
                            DataZwrotu = lend.ReturnDate,
                        };


            returnDataGrid.ItemsSource = query.ToList();
            returnDataGrid.Columns[0].Visibility = Visibility.Collapsed;
        }

        private void returnBookBtn_Click(object sender, RoutedEventArgs e)
        {

            ReturnGridRow selectedItem = returnDataGrid.SelectedItem as ReturnGridRow;
            var lendHistory = selectedItem.Lend;
            lendHistory.ReturnDate = DateTime.Now;
            entities.SaveChanges();
        }

    }
}
