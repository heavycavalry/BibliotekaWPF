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
    /// Interaction logic for addReaderPage.xaml
    /// </summary>
    public partial class addReaderPage : Window
    {
        public addReaderPage()
        {
            InitializeComponent();
        }

        private void addReaderBtn_Click(object sender, RoutedEventArgs e)
        {
            var entities = new LibraryEntities2();
            var reader = new Reader();
            reader.FirstName = imieInput.Text.Trim();
            reader.LastName = nazwiskoInput.Text.Trim();
            reader.Pesel = peselInput.Text.Trim();

            if (ReaderExists(peselInput.Text))
            {
                exceptionInfo.Text = "Użytkownik o podanym peselu istnieje w bazie danych";
                return;
            }
            if (peselInput.Text.Length < 11)
            {
                exceptionInfo.Text = "Niepoprawny pesel.";
                return;
            }
            else
            {
                exceptionInfo.Text = "";
                entities.Readers.Add(reader);
                entities.SaveChanges();
                successInfo.Text = "Dodano czytelnika";
            }
            
        }

        public bool ReaderExists(string pesel)
        {

            var entities = new LibraryEntities2();

            return entities.Readers.Any(x => x.Pesel.Equals(pesel, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
