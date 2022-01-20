using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProductMaintenance
{
    public partial class frmProductMaintenance : Form
    {
        public frmProductMaintenance()
        {
            InitializeComponent();
        }

        private Product product;

        private void btnGetProduct_Click(object sender, EventArgs e)
        {
            if (Validator.IsPresent(txtCode))
            {
                this.GetProduct(txtCode.Text);
                if (product == null)
                {
                    MessageBox.Show("No product found with this code. " +
                         "Please try again.", "Product Not Found");
                    this.ClearControls();
                }
                else
                    this.DisplayProduct();
            }
        }

        //add a statement to the
        //GetProduct method that calls the GetProduct method of the ProductDB class to
        //get the product with the product code the user enters. Assign the product that’s
        //returned to the product variable.
        private void GetProduct(string code)
        {
            try
            {
                product = ProductDB.GetProduct(code);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void ClearControls()
        {
            txtCode.Text = "";
            txtDescription.Text = "";
            txtPrice.Text = "";
            btnModify.Enabled = false;
            btnDelete.Enabled = false;
            txtCode.Focus();
        }

        private void DisplayProduct()
        {
            txtDescription.Text = product.Description;
            txtPrice.Text = product.Price.ToString("c2");
            btnModify.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddModifyProduct addProductForm = new frmAddModifyProduct();
            addProductForm.addProduct = true;
            DialogResult result = addProductForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                product = addProductForm.product;
                txtCode.Text = product.Code;
                this.DisplayProduct();
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            frmAddModifyProduct modifyProductForm = new frmAddModifyProduct();
            modifyProductForm.addProduct = false;
            modifyProductForm.product = product;
            DialogResult result = modifyProductForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                product = modifyProductForm.product;
                this.DisplayProduct();
            }
            else if (result == DialogResult.Retry)
            {
                this.GetProduct(product.Code);
                if (product != null)
                    this.DisplayProduct();
                else
                    this.ClearControls();           
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Delete " + product.Code + "?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    //add code to the event
                    //handler for the Click event of the Delete button that calls the DeleteProduct
                    //method of the ProductDB class. If this method returns a true value, the event
                    //handler should call the ClearControls method of the form.Otherwise, it should
                    //display a message indicating that another user has updated or deleted the product.
                    //Then, it should call the GetProduct method of the form to determine if the
                    //product has been deleted.If it hasn’t, the event handler should call the
                    //DisplayProduct method of the form.Otherwise, it should call the ClearControls
                    //method of the form
                   if (ProductDB.DeleteProduct(product))
                    {
                        ClearControls();
                    }
                    else
                    {
                        MessageBox.Show("Another user has updated or deleted the product");
                        string prodCode = product.Code.ToString();
                        GetProduct(prodCode);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
