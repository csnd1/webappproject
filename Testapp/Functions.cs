using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testapp
{
    public class Functions
    {
        public static void AddDetails(NewDatabase databaseContext, Database database)
         {
            Console.Write("Please insert customer Forename: ");
            var forename = Console.ReadLine();
            Console.Write("Please insert customer Surname: ");
            var surname = Console.ReadLine();
            Console.Write("Please insert customer Address: ");
            var address = Console.ReadLine();
            var customerID = Guid.NewGuid().ToString();

            var customer = new Customer { Forename = forename, Surname = surname, Address = address, CustomerID = customerID, DatabaseID = database.DatabaseID };
            databaseContext.Customers.Add(customer);
            databaseContext.SaveChanges();


            Console.WriteLine($"customer added with name: {forename} {surname}");
            Console.WriteLine("Press any key to see menu");
            Console.ReadKey();
         }
        
        public static void UpdateCustomer(NewDatabase databaseContext, Database database)
        {
            Console.Write("Please insert customer Id you would like to update: ");
            var update = Console.ReadLine();

            var query = from item in databaseContext.Customers
                        where item.CustomerID == update
                        select item;
                
            bool showMenu = true;
            while (showMenu)
            {


                Console.WriteLine("Choose what you want to do");
                Console.WriteLine("1: Update customer forename");
                Console.WriteLine("2: Update customer surname");
                Console.WriteLine("3: Update customer address");
                Console.WriteLine("4: Return to menu");
                Console.WriteLine("Enter a number choice: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        Console.Write("Please insert customers new Forename: ");
                        var forename = Console.ReadLine();
                        foreach (var item in query)
                        {
                            item.Forename = forename;
                        }
                        databaseContext.SaveChanges();
                        Console.Write($"Forname update to {forename}");
                        break;

                    case "2":
                        Console.Write("Please insert customers new Surname: ");
                        var surname = Console.ReadLine();
                        foreach (var item in query)
                        {
                            item.Forename = surname;
                        }
                        databaseContext.SaveChanges();
                        Console.Write($"Surname update to {surname}");
                        break;
                    case "3":
                        Console.Write("Please insert customers new Address: ");
                        var address = Console.ReadLine();
                        foreach (var item in query)
                        {
                            item.Forename = address;
                        }
                        databaseContext.SaveChanges();
                        Console.Write($"Address update to {address}");
                        break;
                    case "4":
                        Console.Write("Returning to menu");
                        showMenu = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid input please try again");
                        break;

                }

            }
        }
        
        public static void RemoveCustomer(NewDatabase databaseContext, Database database)
        {
            Console.Write("Please insert customer Id you would like to remove: ");
            var delete = Console.ReadLine();

            var query = from item in databaseContext.Customers
                        where item.CustomerID == delete
                        select item;
            foreach (var item in query)
            {
                databaseContext.Customers.Remove(item);
            }
            databaseContext.SaveChanges();
            Console.Write($"Customer with ID: {delete} removed /n");
        }
        
        public static void QueryDatabse(NewDatabase databaseContext, Database database)
        {
            var query = from item in databaseContext.Customers
                        orderby item.Surname
                        select item;

            Console.WriteLine("All Customers in the database:");
            foreach (var item in query)
            {
                Console.WriteLine($"Forename: {item.Forename}");
                Console.WriteLine($"Surname: {item.Surname}");
                Console.WriteLine($"Address: {item.Address}");
                Console.WriteLine($"CustomerID: {item.CustomerID}");
                Console.WriteLine($"DatabaseID: {item.DatabaseID}");
                Console.WriteLine("\n");

            }
        }
         
        public static void DeleteDatabase(NewDatabase databaseContext, Database database)
        {
            
            databaseContext.Databases.Remove(database);
            var query = from item in databaseContext.Customers
                        where item.DatabaseID == database.DatabaseID
                        select item;
            foreach (var item in query)
            {
                databaseContext.Customers.Remove(item);
            }
            databaseContext.SaveChanges();
            
        }
    }
}
