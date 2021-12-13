using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace Testapp
{
    public class Database
    {
        public string DatabaseID { get; set; }
        public string Name { get; set; }
        public virtual List<Customer> Customers { get; set; }

    }

    public class Customer
    {
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string CustomerID { get; set; }
        public string DatabaseID { get; set; }

        public virtual Database Database { get; set; }
    }

    public class NewDatabase : DbContext
    {
        public DbSet<Database> Databases { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }

}
