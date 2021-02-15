using System.Linq;
using System.Windows;

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

            var entities = new LibraryEntities();

            var query = from reader in entities.Readers
                        select new { Identyfikator = reader.ID, Nazwisko = reader.LastName, Imie = reader.FirstName, Pesel = reader.Pesel };

            readersDataGrid.ItemsSource = query.ToList();
        }


        private void addReaderButton_Click(object sender, RoutedEventArgs e)
        {
            addReaderPage readerPage = new addReaderPage();
            readerPage.Show();
        }

        private void removeReaderButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
