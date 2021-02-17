using System;
using System.Data;
using System.Linq;
using System.Windows;

namespace Biblioteka
{
    /// <summary>
    /// Interaction logic for LendingPage.xaml
    /// </summary>
    /// 

    public class LendGridRow
    {
        public int Identyfikator { get; set; }
        public string  Imie_Autora { get; set; }
        public string Nazwisko_Autora { get; set; }
        public string Tytul { get; set; }
        public bool Wypozyczono { get; set; }

    }

    public partial class LendingPage : Window
    {
        public LendingPage()
        {
            InitializeComponent();
        }


        public void Data_Loaded(object sender, RoutedEventArgs e)
        {
            var db = new LibraryEntities();

            var query = from book in db.Books
                        where book.InStock == true
                        join lend in db.LendHistories 
                        on book.ID equals lend.BookID into j
                        from lend in j.DefaultIfEmpty()
                        select new LendGridRow { Identyfikator = book.ID, Imie_Autora = book.Author.FirstName, Nazwisko_Autora = book.Author.LastName, Tytul = book.Title, Wypozyczono = lend != null && lend.ReturnDate == null};

            lendDataGrid.ItemsSource = query.ToList();

            lendDataGrid.Columns[0].Visibility = Visibility.Collapsed;
        }


        private void lendButton_Click(object sender, RoutedEventArgs e)
        {
            wrongDataText.Text = "";
            var db = new LibraryEntities();

            if (peselInput.Text.Length < 11 || !(peselInput.Text.All(char.IsDigit)))
            {
                wrongDataText.Text = "Niepoprawny pesel. Wpisz ponownie.";
            }

            var queryInputReader = from reader in db.Readers
                                   where reader.Pesel == peselInput.Text & reader.Active == true
                                   select reader;


            var readers = queryInputReader.ToList<Reader>();

            foreach (Reader reader in readers)
            {
                LendHistory lendHistory = new LendHistory();

                LendGridRow selectedItem = lendDataGrid.SelectedItem as LendGridRow;

                if (selectedItem != null) {

                    lendHistory.ReaderID = reader.ID;
                    lendHistory.BookID = selectedItem.Identyfikator;
                    lendHistory.LendingDate = DateTime.Now;
                    db.LendHistories.Add(lendHistory);

                    db.SaveChanges();
                    wrongDataText.Text = "";
                    correctDataText.Text = "Wypożyczono.";
                }
                else
                {
                    wrongDataText.Text = "Wybierz książkę.";
                }
            }
        }


    }
    }

