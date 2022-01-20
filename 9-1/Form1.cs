using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReservationTotals
{
    public partial class form1 : Form
    {
        public form1()
        {
            InitializeComponent();
        }

        public bool IsDateTime(TextBox textBox, string name)
        {
            DateTime tempDT;

            if (!DateTime.TryParse(txtArrival.Text, out tempDT)){
                return false;
                MessageBox.Show("Please enter date in mm/dd/yyyy format");
            }
            if(!DateTime.TryParse(txtDeparture.Text, out tempDT))
            {
                return false;
                MessageBox.Show("Please enter date in mm/dd/yyyy format");
            }
            return true;
        }

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

        public bool IsWithinRange(TextBox textbox, String name, DateTime min, DateTime max) 
        {
            DateTime temp = DateTime.Parse(textbox.Text, new System.Globalization.CultureInfo("en-US")).Date;

            if (temp.Date > max.Date || temp.Date < min.Date)
            {
                return false;
                MessageBox.Show("Please enter date withing 5 years of current date");
            }
            return true;
        }

        public bool isValidData()
        {
            //calls the other three functions to validate data
            if(!IsPresent(txtArrival, "Arrival Date"))
            {
                return false;
            }
            if (!IsPresent(txtDeparture, "Departure Date"))
            {
                return false;
            }
            if (!IsDateTime(txtArrival, "Arrival Date"))
            {
                return false;
            }
            if (!IsDateTime(txtDeparture, "Departure Date"))
            {
                return false;
            }
            if (!IsWithinRange(txtArrival, "Arrival Date", DateTime.MinValue, DateTime.MaxValue)){
                return false;
            }
            if (!IsWithinRange(txtDeparture, "Departure Date", DateTime.MinValue, DateTime.MaxValue))
            {
                return false;
            }
            return true;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //data doesnt validate correctly :/ 
            if (isValidData()){
                DateTime arrivalDT = Convert.ToDateTime(txtArrival.Text);
                DateTime departureDT = Convert.ToDateTime(txtDeparture.Text);
                int numNights = (departureDT - arrivalDT).Days;

                int totalPrice = 0;

                int i = 0;

                //while loop to iterate through each day of stay
                while (i < numNights)
                {
                    //adds i to arrivale date every iteration
                    DateTime temp = arrivalDT.AddDays(i);
                    string DayOfWeek = temp.DayOfWeek.ToString();
                    
                    //checks if day is friday or saturday and adds 150 to price
                    if (DayOfWeek.Equals("Friday") || DayOfWeek.Equals("Saturday"))
                    {
                        totalPrice += 150;
                    }
                    else
                    {
                        totalPrice += 120;
                    }
                    i++;
                }

                int avgPrice = totalPrice / numNights;

                txtNumOfNights.Text = numNights.ToString();
                txtTotal.Text = totalPrice.ToString();
                txtAvg.Text = avgPrice.ToString();
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void form1_Load(object sender, EventArgs e)
        {
            //gets todays date and three days from nows date and puts them in
            //arrival and departure textboxes in format mm/dd/yyyy
            DateTime todayDate = DateTime.Now;
            DateTime threeDaysAhead = DateTime.Now.AddDays(3);

            txtArrival.Text = todayDate.ToString("MM/dd/yyyy");
            txtDeparture.Text = threeDaysAhead.ToString("MM/dd/yyyy");
        }
    }
}
