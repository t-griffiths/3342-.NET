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
 * CIS 3309 Extra 5-1 Lab 1
 */ 

namespace extra_5_2_lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            double change;
            change = Convert.ToInt32(txtboxChange.Text);

            /* Takes input value ("change") and divides it by 25 and gives us number x. Rounds x down.
             * Multiplies x by 25 and subtracts that from change.
             */
            double quarters;
            quarters = change / 25;
            quarters = Math.Floor(quarters);
            change -= (quarters * 25);
            txtboxQuarters.Text = quarters.ToString();

            /* At this point change is less than 25. Divides change by 10 and gives us number x. Rounds x down.
             * Multiplies x by 10 and subtracts that from change.
             */
            double dimes;
            dimes = change / 10;
            dimes = Math.Floor(dimes);
            change -= (dimes * 10);
            txtboxDimes.Text = dimes.ToString();

            /* At this point change is less than 10. Divides change by 5 and gives us number x. Rounds x down.
             * Multiplies x by 5 and subtracts that from change.
             */ 
            double nickles;
            nickles = change / 5;
            nickles = Math.Floor(nickles);
            change -= (nickles * 5);
            txtboxNickles.Text = nickles.ToString();

            /* At this point change is less than 5. Prints change as it is the amount of pennies.
             */ 
            txtboxPennies.Text = change.ToString();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
