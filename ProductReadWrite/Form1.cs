using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductRWGriffithsT
{
    public partial class Products : Form
    {
        private ProductList pl = new ProductList();
        private Product p;
        private int idx = -1;

        public Products()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            this.pl.Clear();
            this.pl.readFromFile("Products.csv");
            this.idx = 0;
            this.drawProduct();
            this.btnPrevious.Enabled = false;
            this.btnNext.Enabled = true;
            this.btnWrite.Enabled = true;
            this.btnWriteBin.Enabled = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (this.idx == this.pl.Count - 2)
            {
                this.idx++;
                this.p = this.pl.ElementAt<Product>(this.idx);
                this.drawProduct();
                this.btnNext.Enabled = false;
            }
            else
            {
                if (this.idx >= this.pl.Count - 2)
                {
                    return;
                }
                this.idx++;
                this.p = this.pl.ElementAt<Product>(this.idx);
                this.drawProduct();
                this.btnPrevious.Enabled = true;
            }
        }

        private void btnReadBin_Click(object sender, EventArgs e)
        {
            this.pl.Clear();
            this.pl.readFromBinary("Products.bin");
            this.idx = 0;
            this.drawProduct();
            this.btnPrevious.Enabled = false;
            this.btnNext.Enabled = true;
            this.btnWrite.Enabled = true;
            this.btnWriteBin.Enabled = true;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            this.idx--;
            this.p = this.pl.ElementAt<Product>(this.idx);
            this.drawProduct();

            if (this.idx == 1)
            {
                this.btnPrevious.Enabled = false;    
            }
            else
            {
                this.btnNext.Enabled = true;
            }
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            this.pl.writeToBinary("Output.bin");
        }

        private void btnWriteBin_Click(object sender, EventArgs e)
        {
            this.pl.writeToFile("Output.csv");
        }

        private void Products_Load(object sender, EventArgs e)
        {
            this.drawSet(false, false, false, false, false, false, false, false);
            this.btnPrevious.Enabled = false;
            this.btnNext.Enabled = false;
            this.btnWrite.Enabled = false;
            this.btnWriteBin.Enabled = false;
        }

        public void drawSet(bool b1, bool b2, bool b3, bool b4, bool b5, bool b6, bool b7, bool b8)
        {
            this.lblVar1.Visible = b1;
            this.txtVar1.Visible = b1;
            this.lblVar2.Visible = b2;
            this.txtVar2.Visible = b2;
            this.lblVar3.Visible = b3;
            this.txtVar3.Visible = b3;
            this.lblVar4.Visible = b4;
            this.txtVar4.Visible = b4;
            this.lblVar5.Visible = b5;
            this.txtVar5.Visible = b5;
            this.lblVar6.Visible = b6;
            this.txtVar6.Visible = b6;
            this.lblVar7.Visible = b7;
            this.txtVar7.Visible = b7;
            this.lblVar8.Visible = b8;
            this.txtVar8.Visible = b8;
        }
        public void drawBook()
        {
            Book b = (Book)p;
            drawSet(true, true, true, true, false, false, false, false);
            drawMedia();
            lblVar2.Text = "Author";
            txtVar2.Text = b.Author;
            lblVar3.Text = "Pages";
            txtVar3.Text = b.NumPages.ToString();
            lblVar4.Text = "Publisher";
            txtVar4.Text = b.Publisher;
        }

        public void drawMedia()
        {
            Media m = (Media)p;
            lblVar1.Text = "Release Date";
            txtVar1.Text = m.ReleaseDate;
        }

        public void drawProduct()
        {
            if (idx >= 0 && idx < pl.Count)
            {
                p = pl.ElementAt(idx);
                txtType.Text = p.Type;
                txtID.Text = p.ID;
                txtDescription.Text = p.Desc;
                txtPrice.Text = p.Price.ToString("C");
                txtQuantity.Text = p.Qty.ToString();
                if (p.Type == "Book")
                    drawBook();
                else if (p.Type == "Software")
                    drawSoftware();
                else if (p.Type == "Music")
                    drawMusic();
                else if (p.Type == "Movie")
                    drawMovie();
                else if (p.Type == "Pants")
                    drawPants();
                else if (p.Type == "TShirt")
                    drawTShirt();
                else if (p.Type == "DressShirt")
                    drawDressShirt();
                else
                    MessageBox.Show("Not found.");
            }
        }

        public void drawApparel()
        {
            Apparel p = (Apparel)this.p;
            this.lblVar1.Text = "Color";
            this.txtVar1.Text = p.Color;
            this.lblVar2.Text = "Manufacturer";
            this.txtVar2.Text = p.Manufacturer;
            this.lblVar3.Text = "Material";
            this.txtVar3.Text = p.Material;
        }

        public void drawDisk()
        {
            Disk p = (Disk)this.p;
            this.lblVar2.Text = "Num of Disks:";
            this.txtVar2.Text = p.NumDisks.ToString();
            this.lblVar3.Text = "Data Size:";
            this.txtVar3.Text = p.Size.ToString();
            this.lblVar4.Text = "Type Disk";
            this.txtVar4.Text = p.TypeDisk;
        }

        public void drawEntertainment()
        {
            Entertainment p = (Entertainment)this.p;
            this.drawDisk();
            this.lblVar5.Text = "Runtime";
            this.txtVar5.Text = p.RunTime;
        }

        public void drawSoftware()
        {
            Software s = (Software)this.p;
            this.drawSet(true, true, true, true, true, false, false, false);
            this.drawDisk();
            this.lblVar5.Text = "Software Type";
            this.txtVar2.Text = s.SoftwareType;
        }

        public void drawMusic()
        {
            Music m = (Music)this.p;
            this.drawSet(true, true, true, true, true, true, true, true);
            this.drawEntertainment();
            this.lblVar6.Text = "Artist";
            this.txtVar6.Text = m.Artist;
            this.lblVar7.Text = "Label";
            this.txtVar7.Text = m.Label;
            this.lblVar8.Text = "Genre";
            this.txtVar8.Text = m.Genre;
        }

        public void drawMovie()
        {
            Movie m = (Movie)this.p;
            this.drawSet(true, true, true, true, true, true, true, false);
            this.drawEntertainment();
            this.lblVar6.Text = "Director";
            this.txtVar6.Text = m.Director;
            this.lblVar7.Text = "Producer";
            this.txtVar7.Text = m.Producer;
        }

        public void drawPants()
        {
            Pants p = (Pants)this.p;
            this.drawSet(true, true, true, true, true, false, false, false);
            this.drawApparel();
            this.lblVar4.Text = "Waist";
            this.txtVar4.Text = p.Waist.ToString();
            this.lblVar5.Text = "Inseam";
            this.txtVar5.Text = p.Inseam.ToString();
        }

        public void drawDressShirt()
        {
            DressShirt s = (DressShirt)this.p;
            this.drawSet(true, true, true, true, true, false, false, false);
            this.drawApparel();
            this.lblVar4.Text = "Neck";
            this.txtVar4.Text = s.Neck.ToString();
            this.lblVar5.Text = "Sleeve";
            this.txtVar5.Text = s.Sleeve.ToString();
        }

        public void drawTShirt()
        {
            Tshirt t = (Tshirt)this.p;
            this.drawSet(true, true, true, true, false, false, false, false);
            this.drawApparel();
            this.lblVar4.Text = "Size";
            this.txtVar4.Text = t.Size.ToString();
        }


    }
}
