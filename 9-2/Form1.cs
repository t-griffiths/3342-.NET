using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stringhandling
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            string email = Convert.ToString(txtEmail.Text);

            //checks if @ is in email address entry
            if (email.Contains("@"))
            {
                //if it is, the username is the 0th character up until the index of the @
                string username = email.Substring(0, email.IndexOf("@"));
                //then the domain is everything after the index of @
                string domainname = email.Substring(email.IndexOf("@") + 1);
                MessageBox.Show("Username: " + username + "\n" + "Domain name: " + domainname);
            }
            else
            {
                //if no @ in entry then prompts user to imput valid email address
                MessageBox.Show("Please enter email in ____@_____.___ format");
            }
        }

        private void btnFormat_Click(object sender, EventArgs e)
        {
            string city = Convert.ToString(txtCity.Text);
            string state = Convert.ToString(txtState.Text);
            int zip = Convert.ToInt32(txtZip.Text);

            MessageBox.Show("City, State, Zip: " + city + ", " + state + " " + zip);
        }
    }
}
