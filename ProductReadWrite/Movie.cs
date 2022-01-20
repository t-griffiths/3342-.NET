using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductRWGriffithsT
{
    //inherits entertainment class
    class Movie : Entertainment
    {
        public string Director { get; set; }
        public string Producer { get; set; }
        //default constructor
        public Movie()
        {
        }
        //sets object of type movies to these values
        public Movie(string type, string id, string desc, double price, int qty, string rDate, int size, int numDisks, string typeDisk, string rTime, string director, string producer) : base(type, id, desc, price, qty, rDate, size, numDisks, typeDisk, rTime)
        {
            this.Director = director;
            this.Producer = producer;
        }
        //combines items in movies class
        public override string GetDisplayText(string sep) => base.GetDisplayText(sep) + sep + this.Director + sep + this.Producer;
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
