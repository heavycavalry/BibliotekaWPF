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

        public class ReadersGridRow
        {
            public Reader Reader { get; set; }

            public int Identyfikator { get; set; }
            public string Nazwisko { get; set; }
            public string Imie { get; set; }
            public string Pesel { get; set; }
            public bool Active { get; set; }

        }

        public ReadersPage()
        {
            InitializeComponent();


            var query = from reader in entities.Readers
                        where reader.Active == true
                        select new ReadersGridRow { Reader = reader, Identyfikator = reader.ID, Nazwisko = reader.LastName, Imie = reader.FirstName, Pesel = reader.Pesel };
            
            readersDataGrid.ItemsSource = query.ToList();
        }


        private void addReaderButton_Click(object sender, RoutedEventArgs e)
        {
            addReaderPage readerPage = new addReaderPage();
            readerPage.Show();
        }

        private void removeReaderButton_Click(object sender, RoutedEventArgs e)
        {

            ReadersGridRow selectedItem = readersDataGrid.SelectedItem as ReadersGridRow;
            var reader = selectedItem.Reader;
            reader.Active = false;
            entities.SaveChanges();
        }
    }
}


