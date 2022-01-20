using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductRWGriffithsT
{
    //inherits disk class
    class Software : Disk
    {
        public string SoftwareType { get; set; }

        //default constructor
        public Software()
        {
        }

        //sets object of type software to these values
        public Software(string type, string id, string desc, double price, int qty, string rDate, int size, int numDisks, string typeDisk, string typeSoft) : base(type, id, desc, price, qty, rDate, size, numDisks, typeDisk)
        {
            this.SoftwareType = typeSoft;
        }

        //combines items in software class
        public override string GetDisplayText(string sep) => base.GetDisplayText(sep) + sep + this.SoftwareType;
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
