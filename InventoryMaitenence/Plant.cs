using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMaintenance
{
    // ": InvItem" inherits the InvItem class
    class Plant : InvItem 
    {
        //innitialzie public string to hold value of size
        public string size;
        //default constructor
        public Plant()
        {

        }

        //constuctor that takes item number, description, price, and size and inherits item number description and price from InvItem.cs
        public Plant(int itemNo, string description, decimal price, string size) : base(itemNo, description, price)
        {
            this.size = size;
        }

        //sets size
         public string Size
         {
            get
            {
                return size;
            }
            set
            {
                size = value;
            }
        }
        //overrides getdisplaytext to add size into string that is being displayed
        public override string GetDisplayText() => this.ItemNo + "    " + this.Size + "    " + this.Description + " (" + this.Price.ToString("c") + ")";

    }
}
