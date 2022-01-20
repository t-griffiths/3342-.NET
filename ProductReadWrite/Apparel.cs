using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductRWGriffithsT
{
    //inherits product class
    class Apparel : Product
    {
        public string Material { get; set; }
        public string Color { get; set; }
        public string Manufacturer { get; set; }

        //default constructor
        public Apparel()
        {
        }

        //sets new objects of type Apparel to these values
        public Apparel(string type, string id, string desc, double price, int qty, string material, string color, string manufacturer) : base (type, id, desc, price, qty)
        {
            this.Material = material;
            this.Color = color;
            this.Manufacturer = manufacturer;
        }

        //combines items in apparel object
        public override string GetDisplayText(string sep) => base.GetDisplayText(sep) + sep + this.Material + sep + this.Color + sep + this.Manufacturer;
        //converts apparel object to string
        public override string ToString()
        {
            return this.GetDisplayText("\r\n");
        }
        //adds commas so is readable as csv file
        public override string ToCSV() => this.GetDisplayText(",");
        
    }
}
