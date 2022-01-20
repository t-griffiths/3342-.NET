using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* Thomas Griffiths
 * CIS 3309 Lab 01 Extra 5-2
 */ 

namespace extra_5_1_lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //datatype long to store large whole numbers
            //i = input
            long i;
            i = Convert.ToInt32(txtbxNum.Text);

            //initialize factorial value
            long factorial = 1;

            /* takes input and multiplies it by factorial (1 for first iteration) then subtracts
             * 1 from input then multiplies by updated factorial value then repeats until input
             * is decromented to 1 */ 
            while(i > 1)
            {
                factorial *= i;
                i -= 1;
            }

            txtbxFactorial.Text = factorial.ToString("#,###");
            // ("#,###") returns number with commas
            // referenced https://stackoverflow.com/questions/16035506/format-a-number-with-commas-and-decimals-in-c-sharp-asp-net-mvc3
  
        }

        private void btnExtit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
