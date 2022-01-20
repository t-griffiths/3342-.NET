using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Add a using directive for the System.Data.SqlClient namespace to the form
using System.Data.SqlClient;

namespace ProductMaintenance
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void productsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.mMABooksDataSet);

        }


        private void fillByProductCodeToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.productsTableAdapter.FillByProductCode(this.mMABooksDataSet.Products, productCodeToolStripTextBox.Text);

                if (productsBindingSource.Count == 0)
                {
                    MessageBox.Show("No products with that product id was found");
                }
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Number + " " + ex.Message, ex.GetType().ToString());
            }

        }

        private void tslblGetAll_Click(object sender, EventArgs e)
        {
            try
            {
                this.productsTableAdapter.Fill(this.mMABooksDataSet.Products);
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Number + " " + ex.Message, ex.GetType().ToString());
            }
        }
    }
}
