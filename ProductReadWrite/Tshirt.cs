using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductRWGriffithsT
{
    //inherits apparel class
    class Tshirt : Apparel
    {

        public string Size { get; set; }

        //default constructor
        public Tshirt()
        {
        }
        //sets object of type tshirt to these values
        public Tshirt(string type, string id, string desc, double price, int qty, string material, string color, string manufacturer, string size) : base(type, id, desc, price, qty, material, color, manufacturer)
        {
            this.Size = size;
        }
        //combines items in Tshirt object
        public override string GetDisplayText(string sep) => base.GetDisplayText(sep) + sep + this.Size;
        //converts tshirt object to string
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
