using System;
using System.Collections.Generic;
using System.Data;
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

namespace Biblioteka
{
    /// <summary>
    /// Interaction logic for LendingPage.xaml
    /// </summary>
    public partial class LendingPage : Window
    {
        public LendingPage()
        {
            InitializeComponent();
        }


        public void Data_Loaded(object sender, RoutedEventArgs e)
        {
            var entities = new LibraryEntities2();

            var query = from book in entities.Books 
                        join lend in entities.Lends 
                        on book.ID equals lend.BookID into j
                        from lend in j.DefaultIfEmpty()
                        select new { Identyfikator = book.ID, Imie_Autora = book.Author.FirstName, Nazwisko_Autora = book.Author.LastName, Tytul = book.Title, Wypożyczono = lend != null};

            lendDataGrid.ItemsSource = query.ToList();

            lendDataGrid.Columns[0].Visibility = Visibility.Collapsed;
        }


        private int selectedBook; //id wybranej książki 

        private void lendDataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }

        private void lendButton_Click(object sender, RoutedEventArgs e)
        {

            Lend lend = new Lend();

            
        }

        private void lendDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = lendDataGrid.SelectedItem;
            var selectedString = selectedItem.ToString();
            Console.WriteLine(selectedString);
        }
    }
}
