using System;
using System.Linq;
using System.Windows;

namespace Biblioteka
{
    /// <summary>
    /// Interaction logic for AddReaderPage.xaml
    /// </summary>
    public partial class AddReaderPage : Window

    {

        LibraryEntities entities = new LibraryEntities();


        public AddReaderPage()
        {
            InitializeComponent();
        }


        private void addReaderBtn_Click(object sender, RoutedEventArgs e)
        {
            var reader = new Reader();
            reader.FirstName = imieInput.Text.Trim();
            reader.LastName = nazwiskoInput.Text.Trim();
            reader.Pesel = peselInput.Text.Trim();
            reader.Active = true;

            if (ReaderExists(peselInput.Text))
            {
                var queryNotActiveReader = from user in entities.Readers
                                           where user.Pesel == peselInput.Text & user.Active == false
                                           select new { user};

                queryNotActiveReader.First().user.Active = true;
                
                entities.SaveChanges();

                successInfo.Text = "";
                exceptionInfo.Text = "Dodano ponownie do czytelników.";
                return;
            }
            if (peselInput.Text.Length < 11)
            {
                successInfo.Text = "";
                exceptionInfo.Text = "Niepoprawny pesel.";
                return;
            }
            else
            {
                entities.Readers.Add(reader);
                entities.SaveChanges();
                exceptionInfo.Text = "";
                successInfo.Text = "Dodano czytelnika";
            }

        }

        private bool ReaderExists(string pesel)
        {

            return entities.Readers.Any(x => x.Pesel.Equals(pesel, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
