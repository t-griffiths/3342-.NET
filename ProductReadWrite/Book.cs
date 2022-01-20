using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductRWGriffithsT
{
    //inherits media class
    class Book : Media
    {
        public int NumPages { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }

        //default constructor
        public Book()
        {
        }
        //sets object of type book to these values
        public Book(string type, string id, string desc, double price, int qty, string rDate, int numPages, string author, string publisher) : base(type, id, desc, price, qty, rDate)
        {
            this.NumPages = numPages;
            this.Author = author;
            this.Publisher = publisher;
        }
        //combines items in book object
        public override string GetDisplayText(string sep) => base.GetDisplayText(sep) + sep + this.NumPages + sep + this.Author + sep + this.Publisher;
        //converts book object to string
        public override string ToString()
        {
            return this.GetDisplayText("\r\n");
        }
        //adds commas so is readable as csv file
        public override string ToCSV()
        {
            return this.GetDisplayText(",");
        }
    }
}
