using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Data.Entity.Core.Objects;

namespace Biblioteka
{


    public class BookGridRow
    {
        public bool CzyDostepne { get; set; }
        public string Imie_Autora { get; set; }
        public string Nazwisko_Autora { get; set; }
        public string Tytul { get; set; }
        public string DataWydania { get; set; }


    }


    /// <summary>
    /// Interaction logic for LendingPage.xaml
    /// </summary>
    public partial class BooksPage : Window
    {
        public BooksPage()
        {
            InitializeComponent();

        }

        private void addBookButton_Click(object sender, RoutedEventArgs e)
        {
            addBookPage bookWindow = new addBookPage();
            bookWindow.Show();
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var entities = new LibraryEntities();

            var query = from book in entities.Books
                        where book.InStock == true
                        select new BookGridRow { CzyDostepne = book.InStock, Imie_Autora = book.Author.FirstName, Nazwisko_Autora = book.Author.LastName, Tytul = book.Title, DataWydania = book.PublishYear};


            bookDataGrid.ItemsSource = query.ToList();
            bookDataGrid.Columns[0].Visibility = Visibility.Collapsed;
        }

        private void removeBtn_Click(object sender, RoutedEventArgs e)
        {
            BookGridRow selectedItem = bookDataGrid.SelectedItem as BookGridRow;
            selectedItem.CzyDostepne = false;
            
        }
    }
}
