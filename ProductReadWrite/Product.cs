using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductRWGriffithsT
{
    //referenced textbook page 469
    class Product
    {
        public string Type { get; set; }
        public string ID { get; set; }
        public string Desc { get; set; }
        public double Price { get; set; }
        public int Qty { get; set; }

        //default constructor
        public Product()
        {
        }

        //sets new objects of type product to these values
        public Product(string type, string id, string desc, double price, int qty)
        {
            this.ID = id;
            this.Desc = desc;
            this.Price = price;
            this.Qty = qty;
            this.Type = type;
        }

        //combines items in product object
        public virtual string GetDisplayText(string sep) =>
            this.Type + sep + this.ID + sep + this.Desc + sep + this.Price + sep + this.Qty;
        //converts project obect to string
        public override string ToString()
        {
            return this.GetDisplayText("\r\n");
        }
        //adds commas so is readable as csv file
        public virtual string ToCSV()
        {
            return this.GetDisplayText(",");
        }



    }
}
