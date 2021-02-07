using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    public class BookTile
    {
			public int AuthorID { get; set; }
			public string Title { get; set; }

			public List<BookTile> listOfBooks = new List<BookTile>();
			
			public BookTile(int author, string title)
			{

				this.AuthorID = author;
				this.Title = title;
			}

		
		

	}
}
