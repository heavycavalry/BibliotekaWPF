using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Biblioteka
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

        }


        private void returnButton_Click(object sender, RoutedEventArgs e)
        {
            ReturnPage returnPage = new ReturnPage();
            returnPage.Show();
        }

        private void booksButton_Click(object sender, RoutedEventArgs e)
        {
            BooksPage booksPage = new BooksPage();
            booksPage.Show();
        }

        private void historyButton_Click(object sender, RoutedEventArgs e)
        {
            HistoryPage historyPage = new HistoryPage();
            historyPage.Show();
        }


        private void lendButton_Click(object sender, RoutedEventArgs e)
        {
            LendingPage lendpage = new LendingPage();
            lendpage.Show();
        }

        private void readersButton_Click(object sender, RoutedEventArgs e)
        {
            ReadersPage readersPage = new ReadersPage();
            readersPage.Show();
        }
    }
}
