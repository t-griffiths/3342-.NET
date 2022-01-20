using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductRWGriffithsT
{
    //inherits apparel
    class DressShirt : Apparel
    {
        public double Neck { get; set; }
        public double Sleeve { get; set; }

        //default constructor
        public DressShirt()
        {
        }
        //sets objects of type dress shirt to these values
        public DressShirt(string type, string id, string desc, double price, int qty, string material, string color, string manufacturer, double neck, double sleeve) : base(type, id, desc, price, qty, material, color, manufacturer)
        {
            this.Neck = neck;
            this.Sleeve = sleeve;
        }
        //combines items in DressShirt object
        public override string GetDisplayText(string sep) => base.GetDisplayText(sep) + sep + this.Neck + sep + this.Sleeve;
        //converts dress shirt object to string
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
