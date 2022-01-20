using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*Thomas Griffiths
 * Extra 4-1
 */ 

namespace AreAndPerimeter
{
    public partial class AreaPerimeterForm : Form
    {
        public AreaPerimeterForm()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //sets input value of length to length
            double length;
            length = Convert.ToDouble(txtbxLength.Text);

            //sets input value of width to width
            double width;
            width = Convert.ToDouble(txtbxWidth.Text);

            //sets area to legnth x width
            double area = length * width;
            //sets perimeter to length + length + width + width
            double perimeter = (length * 2) + (width * 2);

            txtbxArea.Text = area.ToString();
            txtbcPerimeter.Text = perimeter.ToString();

            txtbxLength.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
