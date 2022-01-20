using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductRWGriffithsT
{
    //inherits entertainment
    class Music : Entertainment
    {
        public string Genre { get; set; }
        public string Artist { get; set; }
        public string Label { get; set; }

        //default constructor
        public Music()
        {
        }
        //sets object of type music to these values
        public Music(string type, string id, string desc, double price, int qty, string rDate, int size, int numDisks, string typeDisk, string rTime, string genre, string artist, string label) : base(type, id, desc, price, qty, rDate, size, numDisks, typeDisk, rTime)
        {
            this.Genre = genre;
            this.Artist = artist;
            this.Label = label;
        }
        //combines items in music class
        public override string GetDisplayText(string sep) => base.GetDisplayText(sep) + sep + this.Genre + sep + this.Artist + sep + this.Label;
        //converts music object to string
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
