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
    /// Interaction logic for HistoryPage.xaml
    /// </summary>
    public partial class HistoryPage : Window
    {
        public HistoryPage()
        {
            InitializeComponent();
            var entities = new LibraryEntities2();

            var query = from lend in entities.LendHistories
                        select new { Data = lend.LendingDate, AutorNazwisko = lend.Book.Author.LastName, AutorImie = lend.Book.Author.FirstName, Tytul = lend.Book.Title , ImieCzytelnika = lend.Reader.FirstName, NazwiskoCzytelnika = lend.Reader.LastName};

            historyDataGrid.ItemsSource = query.ToList();

        }
    }
}
