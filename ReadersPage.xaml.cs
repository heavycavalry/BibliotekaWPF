using System.Linq;
using System.Windows;

namespace Biblioteka
{
    /// <summary>
    /// Interaction logic for ReadersPage.xaml
    /// </summary>
    public partial class ReadersPage : Window
    {

        LibraryEntities entities = new LibraryEntities();

        private class ReadersGridRow
        {
            public Reader Reader { get; set; }

            public int Identyfikator { get; set; }
            public string Nazwisko { get; set; }
            public string Imie { get; set; }
            public string Pesel { get; set; }

        }

        public ReadersPage()
        {
            InitializeComponent();

        }

        private void showReaders()
        {
            var query = from reader in entities.Readers
                        where reader.Active == true
                        select new ReadersGridRow { Reader = reader, Identyfikator = reader.ID, Nazwisko = reader.LastName, Imie = reader.FirstName, Pesel = reader.Pesel };

            readersDataGrid.ItemsSource = query.ToList();
            readersDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            readersDataGrid.Items.Refresh();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            showReaders();
        }


        private void addReaderButton_Click(object sender, RoutedEventArgs e)
        {
            AddReaderPage readerPage = new AddReaderPage();
            readerPage.Show();
        }

        private void removeReaderButton_Click(object sender, RoutedEventArgs e)
        {

            ReadersGridRow selectedItem = readersDataGrid.SelectedItem as ReadersGridRow;
            var reader = selectedItem.Reader;
            reader.Active = false;
            entities.SaveChanges();
            showReaders();
        }
    }
}


