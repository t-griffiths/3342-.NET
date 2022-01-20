using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductRWGriffithsT
{
    //inherits product
    class Media : Product
    {
        private DateTime releaseDate;

        //default constructor
        public Media()
        {
        }

        //converts release date to string
        public string ReleaseDate
        {
            get => this.releaseDate.ToShortDateString();
            set => this.releaseDate = DateTime.Parse(value);
        }

        //sets new objects of type media to these values
        public Media(string type, string id, string desc, double price, int qty, string date) : base(type, id, desc, price, qty)
        {
            this.ReleaseDate = date;
        }
        //combines items in media object
        public override string GetDisplayText(string sep) => base.GetDisplayText(sep) + sep + this.ReleaseDate;
        //converts media object to string
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
