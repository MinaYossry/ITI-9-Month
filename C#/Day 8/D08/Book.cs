using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D08
{
    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string[] Authors { get; set; }
        public DateTime PublicationDate { get; set; }
        public decimal Price { get; set; }

        public Book(string _ISBN, string _Title, string[] _Author, DateTime _dateTime, decimal _price)
        {
            ISBN = _ISBN;
            Title = _Title;
            Authors = _Author;
            PublicationDate = _dateTime;
            Price = _price;
        }

        public override string ToString()
        {
            return $"{ISBN}: {Title}  -  {PublicationDate}   -   ${Price}";
        }
    }
}
