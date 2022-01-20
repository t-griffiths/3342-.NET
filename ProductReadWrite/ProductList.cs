using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductRWGriffithsT
{
    //list that inherits product class
        class ProductList : List<Product>
    {
        public void Add(string[] products)
        {
            if (products[0] == "Book")
            {
                this.Add((Product)new Book(products[0], products[1], products[2], double.Parse(products[3]), int.Parse(products[4]), products[5], int.Parse(products[6]), products[7], products[8]));
            }
            else if (products[0] == "DressShirt")
            {
                this.Add((Product)new DressShirt(products[0], products[1], products[2], double.Parse(products[3]), int.Parse(products[4]), products[5], products[6], products[7], (double)int.Parse(products[8]), int.Parse(products[9])));
            }
            else if (products[0] == "Movie")
            {
                this.Add((Product)new Movie(products[0], products[1], products[2], double.Parse(products[3]), int.Parse(products[4]), products[5], int.Parse(products[6]), int.Parse(products[7]), products[8], products[9], products[10], products[11]));
            }
            else if (products[0] == "Music")
            {
                this.Add((Product)new Music(products[0], products[1], products[2], double.Parse(products[3]), int.Parse(products[4]), products[5], int.Parse(products[6]), int.Parse(products[7]), products[8], products[9], products[10], products[11], products[12]));
            }
            else if (products[0] == "Pants")
            {
                this.Add((Product)new Pants(products[0], products[1], products[2], double.Parse(products[3]), int.Parse(products[4]), products[5], products[6], products[7], int.Parse(products[8]), int.Parse(products[9])));
            }
            else if (products[0] == "Software")
            {
                this.Add((Product)new Software(products[0], products[1], products[2], double.Parse(products[3]), int.Parse(products[4]), products[5], int.Parse(products[6]), int.Parse(products[7]), products[8], products[9]));
            }
            else if (products[0] == "TShirt")
            {
                this.Add((Product)new Tshirt(products[0], products[1], products[2], double.Parse(products[3]), int.Parse(products[4]), products[5], products[6], products[7], products[8]));
            }
        }

        //reads file
        public int readFromFile(string file)
        {
            int temp = 0;
            System.IO.StreamReader streamReader = new System.IO.StreamReader(file);
            string str;
            while ((str = streamReader.ReadLine()) != null)
            {
                this.Add(str.Split(','));
                ++temp;
            }
            streamReader.Close();
            return temp;
        }
        //sets product items as string
        public override string ToString()
        {
            string temp = "";
            foreach (Product product in (List<Product>)this)
                temp += product.ToString() + "\r\n";
            return temp;
        }
        //converts string to be readable by csv
        public string ToCSV()
        {
            string temp = "";
            foreach (Product product in (List<Product>)this)
                temp += product.ToCSV() + "\r\n";
            return temp;
        }

        //writes to file
        public int writeToFile(string file)
        {
            int temp = 0;
            System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(file);
            foreach (Product product in (List<Product>)this)
            {
                streamWriter.WriteLine(product.ToCSV());
                ++temp;
            }
            streamWriter.Close();
            return temp;
        }
        //writes to binary
        public int writeToBinary(string file)
        {
            int temp = 0;
            System.IO.BinaryWriter binaryWriter = new System.IO.BinaryWriter((System.IO.Stream)new System.IO.FileStream(file, System.IO.FileMode.Create, System.IO.FileAccess.Write));
            foreach (Product product in (List<Product>)this)
            {
                binaryWriter.Write(product.ToCSV());
                ++temp;
            }
            binaryWriter.Close();
            return temp;
        }

        //reads from binary file
        //referenced textbook page 577
        public int readFromBinary(string file)
        {
            int temp = 0;
            System.IO.BinaryReader binaryReader = new System.IO.BinaryReader((System.IO.Stream)new System.IO.FileStream(file, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Read));
            while (binaryReader.PeekChar() != -1)
            {
                this.Add(binaryReader.ReadString().Split(','));
                ++temp;
            }
            binaryReader.Close();
            return temp;
        }

    }
}
