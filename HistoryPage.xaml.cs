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
            var entities = new LibraryEntities();

            var query = from lend in entities.LendHistories
                        select new { Data = lend.LendingDate, Nazwisko = lend.Reader.LastName, Imie = lend.Reader.FirstName, Autor = lend.Book.Author.LastName, Tytul = lend.Book.Title};

            historyDataGrid.ItemsSource = query.ToList();

        }
    }
}
