using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductMaintenance
{
    public partial class frmAddModifyProduct : Form
    {
        public frmAddModifyProduct()
        {
            InitializeComponent();
        }

        public bool addProduct;
        public Product product;

        private void frmAddModifyProduct_Load(object sender, EventArgs e)
        {
            if (addProduct)
            {
                this.Text = "Add Product";
                txtCode.ReadOnly = false;
                txtCode.TabStop = true;
                txtCode.Focus();
            }
            else
            {
                this.Text = "Modify Product";
                txtCode.ReadOnly = true;
                txtCode.TabStop = false;
                txtDescription.Focus();
                this.DisplayProduct();
            }
        }

        private void DisplayProduct()
        {
            txtCode.Text = product.Code;
            txtDescription.Text = product.Description;
            txtPrice.Text = product.Price.ToString();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (addProduct)
                {
                    product = new Product();
                    this.PutProductData(product);
                    try
                    {
                        //Display the code for the Add/ Modify Product form, and add code to the event
                        //handler for the Click event of the Accept button that calls the AddProduct
                        //method of the ProductDB class. If this method returns a true value, the event
                        //handler should set the DialogResult property of the form to DialogResult.OK.
                        //Otherwise, it should display an error message indicating that another product
                        //with the same code already exists, and then set the DialogResult property to
                        //DialogResult.Retry
                        if (ProductDB.AddProduct(product))
                        {
                            this.Close();
                            DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("Another product with the same code already exists");
                            DialogResult = DialogResult.Retry;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ex.GetType().ToString());
                    }
                }
                else
                {
                    Product newProduct = new Product();
                    this.PutProductData(newProduct);
                    try
                    {
                        //Add code to this event handler that calls
                        //the UpdateProduct method of the ProductDB class. If this method returns a true
                        //value, the event handler should assign the newProduct object to the product
                        //object and then set the DialogResult property of the form to DialogResult.OK.
                        //Otherwise, it should display an error message indicating that another user has
                        //updated or deleted the product, and then set the DialogResult property to
                        //DialogResult.Retry
                        if(ProductDB.UpdateProduct(product, newProduct))
                        {
                            product = newProduct;
                            this.Close();
                            DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("Another user has updated or deleted the product");
                            DialogResult = DialogResult.Retry;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ex.GetType().ToString());
                    }
                }
            }
        }

        private bool IsValidData()
        {
            return
                Validator.IsPresent(txtCode) &&
                Validator.IsPresent(txtDescription) &&
                Validator.IsPresent(txtPrice) &&
                Validator.IsDecimal(txtPrice);
        }

        private void PutProductData(Product product)
        {
            product.Code = txtCode.Text;
            product.Description = txtDescription.Text;
            product.Price = Convert.ToDecimal(txtPrice.Text);
        }
    }
}
