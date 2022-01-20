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
 * Extra Exercises 4-2
 */

namespace ScoreCalculator
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            /*default values of the 4 text boxes are all set to 0
            * initalizes the ints as the values of those text boxes
            * if i were to initilize them as = 0, every click would set them back to 0
            * 
            * instead, every click sets them to the value that was already in that respective box
            * then does the math considering the previous values
            */
            int scoreTotal = Convert.ToInt32(txtbxTotal.Text);
            int scoreCount = Convert.ToInt32(txtbxCount.Text);
            int scoreAvg = Convert.ToInt32(txtbxAverage.Text);

            scoreTotal += Convert.ToInt32(txtbxScore.Text); //adds input to score total
            scoreCount++; //adds 1 to count
            scoreAvg = scoreTotal / scoreCount; //divides total by count for average

            txtbxTotal.Text = scoreTotal.ToString();
            txtbxCount.Text = scoreCount.ToString();
            txtbxAverage.Text = scoreAvg.ToString();

            txtbxScore.Focus();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            int zero = 0;

            //sets all text boxes back to 0 on click of clear button
            txtbxScore.Text = zero.ToString();
            txtbxTotal.Text = zero.ToString();
            txtbxCount.Text = zero.ToString();
            txtbxAverage.Text = zero.ToString();

            txtbxScore.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
