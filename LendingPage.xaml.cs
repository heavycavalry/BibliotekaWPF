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
                        select new { Imie_Autora = book.Author.FirstName, Nazwisko_Autora = book.Author.LastName, Tytul = book.Title, Wypożyczono = lend != null};

            lendDataGrid.ItemsSource = query.ToList();
        }
    }
}
