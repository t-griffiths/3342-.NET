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
 * Extra 2-1 & 3-1
 */
namespace Griffiths_CalculateLetterGrade
{
    public partial class frmCalculateGrade : Form
    {
        public frmCalculateGrade()
        {
            InitializeComponent();
        }


        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //converts inputted number to numberGrade
            decimal numberGrade = Convert.ToDecimal(txtNumGrade.Text);
            string letterGrade = "";

            //returns letter grade based on numberGrade
            if (numberGrade >= 88)
            {
                letterGrade = "A";
            }

            else if (numberGrade >= 80 && numberGrade <= 87)
            {
                letterGrade = "B";
            }

            else if (numberGrade >= 68 && numberGrade <= 87)
            {
                letterGrade = "C";
            }

            else if (numberGrade >= 60 && numberGrade <= 79)
            {
                letterGrade = "D";
            }

            else
            {
                letterGrade = "F";
            }

            txtboxLetterGrade.Text = letterGrade;
            txtNumGrade.Focus();


        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
