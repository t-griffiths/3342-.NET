using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMaintenance
{
    //inherits InvItem
    class Supply : InvItem
    {
        //innitialzie public string to hold value of manufacturer
        public string manufacturer;

        //default constructor
        public Supply()
        {

        }

        //constuctor that takes item number, description, price, and manufacturer, and inherits item number description and price from InvItem.cs
        public Supply(int itemNo, string description, decimal price, string manufacturer) : base(itemNo, description, price)
        {
            this.manufacturer = manufacturer;
        }

        //sets manufacturer
        public string Manufacturer
        {
            get
            {
                return manufacturer;
            }
            set
            {
                manufacturer = value;
            }
        }
        //overrides getdisplaytext to add manufacturer into string that is being displayed
        public override string GetDisplayText() => this.ItemNo + "    " + this.Manufacturer + "    " + this.Description + " (" + this.Price.ToString("c") + ")";
    }
}
