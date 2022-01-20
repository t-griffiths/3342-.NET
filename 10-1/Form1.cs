using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conversions
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string[,] conversionTable = {
			{"Miles to kilometers", "Miles", "Kilometers", "1.6093"},
			{"Kilometers to miles", "Kilometers", "Miles", "0.6214"},
			{"Feet to meters", "Feet", "Meters", "0.3048"},
			{"Meters to feet", "Meters", "Feet", "3.2808"},
			{"Inches to centimeters", "Inches", "Centimeters", "2.54"},
			{"Centimeters to inches", "Centimeters", "Inches", "0.3937"}
		};

        public bool IsPresent(TextBox textBox, string name)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show(name + " is a required field.", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }

        public bool IsDecimal(TextBox textBox, string name)
        {
            try
            {
                Convert.ToDecimal(textBox.Text);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(name + " must be a decimal number.", "Entry Error");
                textBox.Focus();
                return false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (IsDecimal(txtLength, "Input"))
            {
                //sets each conversion to its respective x coordinate inthe array
                //then to the third y coordinate as that stores the converstion value
                decimal milesToKilos = Convert.ToDecimal(conversionTable[0, 3]);
                decimal kilosToMiles = Convert.ToDecimal(conversionTable[1, 3]);
                decimal feetToMeters = Convert.ToDecimal(conversionTable[2, 3]);
                decimal metersToFeet = Convert.ToDecimal(conversionTable[3, 3]);
                decimal inchesToCent = Convert.ToDecimal(conversionTable[4, 3]);
                decimal centToInches = Convert.ToDecimal(conversionTable[5, 3]);

                decimal input = Convert.ToDecimal(txtLength.Text);
                decimal output = 0;

                //checks what conversion was selected in dropdown then does 
                //the math for that respective value
                if (cboConversions.Text == (conversionTable[0, 0]))
                {
                    output = input * milesToKilos;
                    lblCalculatedLength.Text = output.ToString();
                    lblFromLength.Text = "Miles: ";
                    lblToLength.Text = "Kilometers: ";
                }
                if (cboConversions.Text == (conversionTable[1, 0]))
                {
                    output = input * kilosToMiles;
                    lblCalculatedLength.Text = output.ToString();
                    lblFromLength.Text = "Kilometers: ";
                    lblToLength.Text = "Miles: ";
                }
                if (cboConversions.Text == (conversionTable[2, 0]))
                {
                    output = input * feetToMeters;
                    lblCalculatedLength.Text = output.ToString();
                    lblFromLength.Text = "Feet: ";
                    lblToLength.Text = "Meters: ";
                }
                if (cboConversions.Text == (conversionTable[3, 0]))
                {
                    output = input * metersToFeet;
                    lblCalculatedLength.Text = output.ToString();
                    lblFromLength.Text = "Meters: ";
                    lblToLength.Text = "Feet: ";
                }
                if (cboConversions.Text == (conversionTable[4, 0]))
                {
                    output = input * inchesToCent;
                    lblCalculatedLength.Text = output.ToString();
                    lblFromLength.Text = "Inches: ";
                    lblToLength.Text = "Centimeters: ";
                }
                if (cboConversions.Text == (conversionTable[5, 0]))
                {
                    output = input * centToInches;
                    lblCalculatedLength.Text = output.ToString();
                    lblFromLength.Text = "Centimeters: ";
                    lblToLength.Text = "Inches: ";
                }


            }

        }


        private void cboConversions_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtLength.Focus();
            txtLength.Text = "";
        }
    }
}