using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductRWGriffithsT
{
    //inherits media
    class Disk : Media
    {
        public int Size { get; set; }
        public int NumDisks { get; set; }
        public string TypeDisk { get; set; }

        //default constructor
        public Disk()
        {
        }

        //sets objects of type disk to these values
        public Disk(string type, string id, string desc, double price, int qty, string rDate, int size, int numDisks, string typeDisk) : base(type, id, desc, price, qty, rDate)
        {
            this.Size = size;
            this.NumDisks = numDisks;
            this.TypeDisk = typeDisk;
        }
        //combines items in disk object
        public override string GetDisplayText(string sep) => base.GetDisplayText(sep) + sep + this.Size + sep + this.NumDisks + sep + this.TypeDisk;
        //convert disk object to string
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
