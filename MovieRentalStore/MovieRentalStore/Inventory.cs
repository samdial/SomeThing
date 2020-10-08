using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MovieRentalStore
{
    [Serializable]
    public class Inventory
    {
        public static List<VideoMovie> allMovies = new List<VideoMovie>();


        static public void ShowAllMoviesRoster() //1
        {
            int i = 1;
            foreach (VideoMovie m in allMovies)
            {

                Console.Write(i + ". ");
                m.VideoMovieGetInfo();
                i += 1;
            }
            
        }

        
        static public void AddMovieToInventory(VideoMovie videoMovie)//2
        {
            allMovies.Add(videoMovie);
            
        }

        public void DeleteMovieFromInventory(int movieIndex) //3
        {
            allMovies.RemoveAt(movieIndex);
        }


        static public void MovieRent()
        {
            Console.WriteLine("1 Old customer\n" +
                              "2 new customer");
            int customerIndex;
            var keyPushed = Console.ReadKey(true).Key;
            switch(keyPushed)
            {
                case ConsoleKey.D1:
                    break;
                case ConsoleKey.D2:
                    Console.Write("New customer name: ");
                    string clientname = Console.ReadLine();
                    RentalCustomer newGuy = new RentalCustomer(clientname);
                    CustomersRoster.RentalCustomers.Add(newGuy);
                    
                    break;

                    
            }
            Console.WriteLine("Select Client ");
            CustomersRoster.GetAllCustomersInfo();
            Console.Write("client number: ");
            customerIndex = Convert.ToInt32(Console.ReadLine()) - 1;
            Inventory.ShowAllMoviesRoster();
            Console.Write("Choose movie ");
            int movieIndex = Convert.ToInt32(Console.ReadLine())-1;
            if (Inventory.allMovies[movieIndex].NowInStock==false)
            {
                Console.Write("the movie is rented at the moment\n" +
                              "press any key");
                Console.ReadKey();
                Inventory.MovieRent();
                
            }
            CustomersRoster.RentalCustomers[customerIndex].GiveMovieFromInventoryToCustomer(movieIndex);
            Console.Write("Days of film rent: ");
            int daysOfRent = Convert.ToInt32(Console.ReadLine());
            Inventory.allMovies[movieIndex].rentDays = daysOfRent;
            CustomersRoster.RentalCustomers[customerIndex].debt += daysOfRent * Inventory.allMovies[movieIndex].TypeOfPrice;

        }



        static public void SerializeInventory()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("Inventoty.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Inventory.allMovies);
            }

            
        }
        static public void DeserializeInventory()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("Inventoty.dat", FileMode.OpenOrCreate))
            {
                Inventory.allMovies = (List<VideoMovie>)formatter.Deserialize(fs);
            }
        }
                
            
        


    }

    
}
