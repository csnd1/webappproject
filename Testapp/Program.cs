using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace Testapp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NewDatabase())
            {
                Console.Write("Please insert database name: ");
                var name = Console.ReadLine();
                var databaseID = Guid.NewGuid().ToString();

                var database = new Database { Name = name, DatabaseID = databaseID };
                db.Databases.Add(database);
                db.SaveChanges();


                Console.WriteLine($"Dataabase created with name: {name}");
                Console.WriteLine("Press any key to see menu");
                Console.ReadKey();


                bool showMenu = true;
                while (showMenu)
                {
                    showMenu = MainMenu(db, database);
                }
            }
        }

        private static bool MainMenu(NewDatabase databaseContext, Database database)
        {
            Console.WriteLine("Choose what you want to do");
            Console.WriteLine("1: Add new customer");
            Console.WriteLine("2: Update current customer");
            Console.WriteLine("3: Remove current customer");
            Console.WriteLine("4: View all customers");
            Console.WriteLine("5: Quit and delete database");
            Console.WriteLine("Enter a number choice: ");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    Functions.AddDetails(databaseContext, database);
                    return true;
                case "2":
                    Console.Clear();
                    Functions.UpdateCustomer(databaseContext, database);
                    return true;
                case "3":
                    Console.Clear();
                    Functions.RemoveCustomer(databaseContext, database);
                    return true;
                case "4":
                    Console.Clear();
                    Functions.QueryDatabse(databaseContext, database);
                    return true;
                case "5":
                    Functions.DeleteDatabase(databaseContext, database);
                    return false;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid input please try again");
                    return true;
            }
        }

    }
}
