using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace extra_5_3_lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            decimal income;
            income = Convert.ToInt32(txtboxIncome.Text);

            //calls function and formats returned value to dollar cent 
            txtboxOwed.Text = Calc(income).ToString("#,###.##");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //function that calculates the tax amount
        private static decimal Calc(decimal income)
        {
            //must use 0.0M for decimals to be read
            decimal taxowed = 0.0M;

            if (income < 9225)
            {
                taxowed = income * .10M;
            }
            //tax everything below the bracket at the below rate then everything above at the current rate
            else if (income > 9225 && income < 37450)
            {
                taxowed += (9225 * .10M);
                income -= 9225;

                taxowed += (income * .15M);
            }
            //tax everything in the two below brackets at their respective rates then everything else at current rate
            else if (income > 37450 && income < 90750)
            {
                taxowed += (9225 * .10M) + ((37450 * .15M));
                income -= 37450;

                taxowed += (income * .25M);
            }
            else if (income > 90750 && income < 189300)
            {
                taxowed += ((9225 * .10M) + (37450 * .15M) + (90750 * .25M));
                income -= 90750;

                taxowed += (income * .28M);
            }
            else if (income > 189300 && income < 411500)
            {
                taxowed += ((9225 * .10M) + (37450 * .15M) + (90750 * .25M) + (289300 * .28M));
                income -= 289300;

                taxowed += (income * .33M);
            }
            else if (income > 411500 && income < 413200)
            {
                taxowed += ((9225 * .10M) + (37450 * .15M) + (90750 * .25M) + (289300 * .28M) + (income * .33M));
                income -= 411500;

                taxowed += (income * .35M);
            }
            else
            {
                taxowed += ((9225 * .10M) + (37450 * .15M) + (90750 * .25M) + (289300 * .28M) + (income * .33M) + (income * .35M));
                income -= 413200;

                income += (income * .396M);
            }

            return taxowed; 
        }

        private void txtboxIncome_TextChanged(object sender, EventArgs e)
        {
            //when textbox is changed clear owed box
            txtboxOwed.Text = "";
        }
    }
}
