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
    /// <summary>
    /// Interaction logic for LendingPage.xaml
    /// </summary>
    public partial class BooksPage : Window
    {
        public BooksPage()
        {
            InitializeComponent();

        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var entities = new LibraryEntities();

            var query = from book in entities.Books
                        select new { Imie_Autora = book.Author.FirstName, Nazwisko_Autora=book.Author.LastName, Tytul = book.Title};

            bookDataGrid.ItemsSource = query.ToList();
        }

    }
}
