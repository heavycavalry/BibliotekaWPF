using System.Windows;
using System.Windows.Controls;

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

        private void addBookButton_Click(object sender, RoutedEventArgs e)
        {
            addBookPage bookWindow = new addBookPage();
            bookWindow.Show();
        }  

        private void returnButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void booksButton_Click(object sender, RoutedEventArgs e)
        {
            BooksPage booksPage = new BooksPage();
            booksPage.Show();
        }

        private void historyButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void addReaderButton_Click(object sender, RoutedEventArgs e)
        {
            addReaderPage readerPage = new addReaderPage();
            readerPage.Show();
        }

        private void lendButton_Click(object sender, RoutedEventArgs e)
        {
            LendingPage lendpage = new LendingPage();
            lendpage.Show();
        }
    }
}
