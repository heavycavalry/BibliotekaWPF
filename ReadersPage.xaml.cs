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
    /// Interaction logic for ReadersPage.xaml
    /// </summary>
    public partial class ReadersPage : Window
    {
        public ReadersPage()
        {
            InitializeComponent();

            var entities = new LibraryEntities2();

            var query = from reader in entities.Readers
                        select new { Identyfikator = reader.ID, Nazwisko = reader.LastName, Imie = reader.FirstName , Pesel = reader.Pesel };

            readersDataGrid.ItemsSource = query.ToList();
        }
    }
}
