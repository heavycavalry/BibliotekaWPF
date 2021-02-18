using System.Linq;
using System.Windows;

namespace Biblioteka
{


   


    /// <summary>
    /// Interaction logic for LendingPage.xaml
    /// </summary>
    public partial class BooksPage : Window
    {

        private class BookGridRow
        {

            public Book Ksiazka { get; set; }
            public string Imie_Autora { get; set; }
            public string Nazwisko_Autora { get; set; }
            public string Tytul { get; set; }
            public string DataWydania { get; set; }
            public string ISBN { get; set; }

        }

        LibraryEntities entities = new LibraryEntities();

        public BooksPage()
        {
            InitializeComponent();

        }

        private void addBookButton_Click(object sender, RoutedEventArgs e)
        {
            AddBookPage bookWindow = new AddBookPage();
            bookWindow.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            var query = from book in entities.Books
                        where book.InStock
                        select new BookGridRow { Ksiazka = book, Imie_Autora = book.Author.FirstName, Nazwisko_Autora = book.Author.LastName, Tytul = book.Title, DataWydania = book.PublishYear, ISBN = book.ISBN};


            bookDataGrid.ItemsSource = query.ToList();
            bookDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            bookDataGrid.Columns[1].Visibility = Visibility.Collapsed;
        }

        private void removeBtn_Click(object sender, RoutedEventArgs e)
        {
            BookGridRow selectedItem = bookDataGrid.SelectedItem as BookGridRow;
            var book = selectedItem.Ksiazka;
            book.InStock = false;
            entities.SaveChanges();
        }
    }
}
