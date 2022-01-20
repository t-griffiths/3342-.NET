using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// you’ll need to add a using directive for the System.Data.SqlClient namespace at the beginning of the class
using System.Data.SqlClient;

namespace ProductMaintenance
{
    class MMABooksDB
    {
        //add a static method named GetConnection that creates an SqlConnection object for the
        //MMABooks database and then returns that connection
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =C:\Users\Administrator\Desktop\Exercise starts\Chapter 20\ProductMaintenance\ProductMaintenance\MMABooks.mdf; Integrated Security = True");
        }
    }
}
