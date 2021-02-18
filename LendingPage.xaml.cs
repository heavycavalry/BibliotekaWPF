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

    

    public partial class LendingPage : Window
    {
        private class LendGridRow
        {
            public string ISBN { get; set; }
            public string Imie_Autora { get; set; }
            public string Nazwisko_Autora { get; set; }
            public string Tytul { get; set; }
            public bool Wypozyczono { get; set; }

        }

        public LendingPage()
        {
            InitializeComponent();
        }


        private void showBooks()
        {
            var db = new LibraryEntities();

            var query = from book in db.Books
                        where book.InStock
                        join lend in db.LendHistories
                        on book.ISBN equals lend.BookID into j
                        from lend in j.DefaultIfEmpty()
                        where lend == null | lend.ReturnDate == null
                        select new LendGridRow { 
                            ISBN = book.ISBN, Imie_Autora = book.Author.FirstName, Nazwisko_Autora = book.Author.LastName, Tytul = book.Title, 
                            Wypozyczono = lend != null && lend.ReturnDate == null 
                        };

            lendDataGrid.ItemsSource = query.ToList();

            lendDataGrid.Items.Refresh();
        }

        private void Data_Loaded(object sender, RoutedEventArgs e)
        {
            showBooks();
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

                    if (!selectedItem.Wypozyczono)
                    {

                        lendHistory.ReaderID = reader.ID;
                        lendHistory.BookID = selectedItem.ISBN;
                        lendHistory.LendingDate = DateTime.Now;
                        db.LendHistories.Add(lendHistory);

                        db.SaveChanges();
                        wrongDataText.Text = "";
                        correctDataText.Text = "Wypożyczono.";
                    } else
                    {
                        wrongDataText.Text = "Książka jest już wypożyczona.";
                    }
                }
                else
                {
                    wrongDataText.Text = "Wybierz książkę.";
                }
            }
            showBooks();

        }


    }
    }

