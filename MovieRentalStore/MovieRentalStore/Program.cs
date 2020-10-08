using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace MovieRentalStore
{
    class Program
    {
        static void Main(string[] args)
        {

            CustomersRoster.DeserializeCustomers();
            Inventory.DeserializeInventory();
            Menu.StartMenu();
            

            

            Inventory.allMovies.Sort();
            CustomersRoster.SerializeCustomers();
            Inventory.SerializeInventory();
            Console.WriteLine("end");

            Console.ReadKey();
            
            
                
        }



       
    }



}
