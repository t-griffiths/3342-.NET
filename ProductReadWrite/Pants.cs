using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductRWGriffithsT
{
    //inherits apparel
    class Pants : Apparel
    {
        public int Waist { get; set; }
        public int Inseam { get; set; }
        
        //default constructor
        public Pants()
        {
        }

        //sets object of type pants to these values
        public Pants(string type, string id, string desc, double price, int qty, string material, string color, string manufacturer, int waist, int inseam) : base(type, id, desc, price, qty, material, color, manufacturer)
        {
            this.Waist = waist;
            this.Inseam = inseam;
        }
        //combines items in pants object
        public override string GetDisplayText(string sep) => base.GetDisplayText(sep) + sep + this.Waist + sep + this.Inseam;
        //converts pants object to string
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
