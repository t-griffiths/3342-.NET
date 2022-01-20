using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//add using directives for the System.Data and System.Data.SqlClient namespaces to this class.
using System.Data;
using System.Data.SqlClient;

namespace ProductMaintenance
{
    class ProductDB
    {
        //Add a static method named GetProduct to the ProductDB class. This method
        //should receive the product code of the product to be retrieved, and it should
        //return a Product object for that product.If a product with the product code isn’t
        //found, this method should return null
        public static Product GetProduct(string productCode)
        {
            SqlConnection connection = MMABooksDB.GetConnection();
            string select = "SELECT ProductCode, Description, UnitPrice FROM Products WHERE ProductCode = @ProductCode";
            SqlCommand selectCommand = new SqlCommand(select, connection);
            selectCommand.Parameters.AddWithValue("@ProductCode", productCode);

            try
            {
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader(CommandBehavior.SingleRow);

                if (reader.Read())
                {
                    Product prod = new Product();
                    prod.Code = reader["ProductCode"].ToString();
                    prod.Description = reader["Description"].ToString();
                    prod.Price = (decimal)reader["UnitPrice"];

                    return prod;

                }
                else
                {
                    return null;
                }
                
            }
            catch (SqlException exception)
            {
                throw exception;
            }

            finally
            {
                connection.Dispose();
            }
        }

        //Add a static method named UpdateProduct to the ProductDB class. This method
        //should receive two Product objects.The first one should contain the original
        //product data and should be used to provide for optimistic concurrency.The
        //second one should contain the new product data and should be used to update the
        //product row.This method should also return a Boolean value that indicates if the
        //update was successful.Like the GetProduct method, this method should include a
        //try-catch statement with a catch block that catches and then throws any
        //SqlException that occurs, and a finally block that closes the connection.
        public static Boolean UpdateProduct(Product product, Product updatedProduct)
        {
            SqlConnection connection = MMABooksDB.GetConnection();
            string update = "UPDATE Products SET ProductCode = @NewCode, Description = @NewDescription, UnitPrice = @NewPrice WHERE ProductCode = @oldCode";
            SqlCommand updateCommand = new SqlCommand(update, connection);

            updateCommand.Parameters.AddWithValue("@NewCode", updatedProduct.Code);
            updateCommand.Parameters.AddWithValue("@NewDescription", updatedProduct.Description);
            updateCommand.Parameters.AddWithValue("@NewPrice", updatedProduct.Price);
            updateCommand.Parameters.AddWithValue("@OldCode", product.Code);

            try
            {
                connection.Open();
                updateCommand.ExecuteNonQuery();
                return true;
            }
            catch (SqlException exception)
            {
                throw exception;
            }
            finally
            {
                connection.Dispose();
            }
        }

        //Add a static method named AddProduct to the ProductDB class. This method
        //should receive a Product object with the data for the new product, and it should
        //return a Boolean value that indicates if the add operation was successful.Be sure
        //to include a try-catch statement with a catch block that catches and throws an
        //SqlException and a finally block that closes the connection
        public static bool AddProduct(Product product)
        {
            SqlConnection connection = MMABooksDB.GetConnection();
            string insert = "INSERT INTO Products (ProductCode, Description, UnitPrice)  VALUES (@Code, @Desc, @Price)";
            SqlCommand insertCommand = new SqlCommand(insert, connection);

            insertCommand.Parameters.AddWithValue("@Code", product.Code);
            insertCommand.Parameters.AddWithValue("@Desc", product.Description);
            insertCommand.Parameters.AddWithValue("@Price", product.Price);

            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
                return true;
            }
            catch (SqlException exception)
            {
                throw exception;
            }
            finally
            {
                connection.Dispose();
            }
        }

        //Add a static method named DeleteProduct to the ProductDB class. This method
        //should receive a Product object with the data for the product to be deleted, and it
        //should return a Boolean value that indicates if the delete operation was
        //successful.The Product object should be used to provide for optimistic
        //concurrency.Include a try-catch statement like the ones in the other methods of
        //this class
        public static bool DeleteProduct(Product product)
        {
            SqlConnection connection = MMABooksDB.GetConnection();
            string delete = "DELETE FROM Products WHERE ProductCode = @Code";
            SqlCommand deleteCommand = new SqlCommand(delete, connection);

            deleteCommand.Parameters.AddWithValue("@Code", product.Code);

            try
            {
                connection.Open();
                deleteCommand.ExecuteNonQuery();
                return true;
            }
            catch (SqlException exception)
            {
                throw exception;
            }
            finally
            {
                connection.Dispose();
            }
        }
    }
}
