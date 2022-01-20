using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductRWGriffithsT
{
    //inherits disk
    class Entertainment : Disk
    {
        private TimeSpan runTime;

        //default constructor
        public Entertainment()
        {
        }

        //converts runtime to string seperated at hours minutes and seconds
        public string RunTime
        {
            get => this.runTime.Hours.ToString() + ":" + this.runTime.Minutes.ToString() + ":" + this.runTime.Seconds.ToString();
            set
            {
                string[] temp = value.Split(':');
                this.runTime = new TimeSpan(int.Parse(temp[0]), int.Parse(temp[0]), int.Parse(temp[0]));
            }
        }

        //sets objects of type entertainment to these values
        public Entertainment(string type, string id, string desc, double price, int qty, string rDate, int size, int numDisks, string typeDisk, string rTime) : base(type, id, desc, price, qty, rDate, size, numDisks, typeDisk)
        {
            this.RunTime = rTime;
        }

        //combines items in entertainment
        public override string GetDisplayText(string sep) => base.GetDisplayText(sep) + sep + this.runTime.Hours + ":" + this.runTime.Minutes + ":" + this.runTime.Seconds;
        //converts entertainment object to string
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
