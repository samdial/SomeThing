using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalStore
{
    class Menu
    {
        public static void StartMenu()
        {
            Console.Clear();
            Console.WriteLine(
                "Main page VideoRentalStore\n" +
                "Choose option:\n" +
                ".............................\n" +
                "1. Rental Movie.\n" +
                "2. Give movie back.\n" +
                "3. inventory.\n" +
                "4. Client List\n" +
                "5. Exit\n"+
                ".............................");
            var keyPushed = Console.ReadKey(true).Key;
            switch(keyPushed)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    Console.Write("=Rental Movie=\n");
                    
                    Inventory.MovieRent();
                    
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    Console.WriteLine("Movie Return");
                    CustomersRoster.GetAllCustomersInfo();
                    Console.Write("client number: ");
                    int customerIndex;
                    do
                    {
                        customerIndex = int.Parse(Console.ReadLine()) - 1;
                    }
                    while (customerIndex <= 0 && customerIndex >= CustomersRoster.RentalCustomers.Count);
                    Console.Clear();
                    if (CustomersRoster.RentalCustomers[customerIndex].moviesRentedNow==null |
                        CustomersRoster.RentalCustomers[customerIndex].moviesRentedNow.Count==0)
                    {
                        Console.WriteLine("Customer`s roster is empty!");
                        break;
                    }
                    Console.WriteLine("Choose movie to return or push Enter to return all clients movies back");

                    CustomersRoster.RentalCustomers[customerIndex].GetRentedMoviesRoster();
                    var key = Console.ReadKey(true).Key;
                    if(key==ConsoleKey.Enter)
                    {
                        Console.WriteLine("Mo");
                        
                        foreach (VideoMovie mc in CustomersRoster.RentalCustomers[customerIndex].moviesRentedNow)
                        {
                            foreach (VideoMovie mInv in Inventory.allMovies)
                            {
                                if (mInv.MovieName == mc.MovieName)
                                {
                                    mInv.NowInStock = true;
                                    CustomersRoster.RentalCustomers[customerIndex].debt -=
                                    mc.rentDays * mc.TypeOfPrice;
                                    
                                    
                                }

                            }
                            CustomersRoster.RentalCustomers[customerIndex].moviesRentedNow.Clear();
                            CustomersRoster.RentalCustomers[customerIndex].debt = 0;
                            Inventory.allMovies.Sort();

                            break;
                        }
                    }
                    else
                    {
                        var movieIndex = int.Parse(Console.ReadLine());
                        if(movieIndex!=0)
                        {
                            foreach (VideoMovie m in Inventory.allMovies)
                            {
                                if (m.MovieName == CustomersRoster.RentalCustomers[customerIndex].moviesRentedNow[movieIndex].MovieName)
                                {
                                    m.NowInStock = true;
                                    CustomersRoster.RentalCustomers[customerIndex].debt -=
                                    CustomersRoster.RentalCustomers[customerIndex].moviesRentedNow[movieIndex].rentDays * CustomersRoster.RentalCustomers[customerIndex].moviesRentedNow[movieIndex].TypeOfPrice;
                                    CustomersRoster.RentalCustomers[customerIndex].moviesRentedNow.RemoveAt(movieIndex);
                                    Inventory.allMovies.Sort();

                                    break;
                                }

                            }
                        }
                    }
                    
                    
                    break;
                case ConsoleKey.D3:
                    Menu.InventoryMenu();
                    break;
                case ConsoleKey.D4:
                    CustomersRoster.GetAllCustomersInfo();
                    Console.ReadKey();
                    break;
                case ConsoleKey.D5:
                CustomersRoster.SerializeCustomers();
                Inventory.SerializeInventory();
                Console.WriteLine("press any key to exit");
                Console.ReadKey();
                Environment.Exit(0);

                    break;
                default:
                    Console.WriteLine("Something wrong. Back to main menu");
                    StartMenu();
                    break;
                   
                
            }
            
        }
        public static void InventoryMenu()
        {
            Console.Clear();
            Console.WriteLine("inventory\n" +
                                "1. All movies list\n" +
                                "2. Add movie to inventory\n" +
                                "3. Delete movie from inventory\n" +
                                "4. Back to main menu");
            var keyPushed = Console.ReadKey(true).Key;
            switch (keyPushed)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    Inventory.ShowAllMoviesRoster();
                    Console.ReadKey();
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    Console.Write("Movie name: ");
                    string MovieName = Console.ReadLine();
                    VideoMovie videoMov = new VideoMovie(MovieName);
                    Inventory.AddMovieToInventory(videoMov);
                    break;
                case ConsoleKey.D4: //4
                    Menu.StartMenu();
                    break;
                default:
                    Console.WriteLine("Something wrong. Back to main menu");
                    StartMenu();
                    break;
            }
            Menu.StartMenu();
        }
         
    }
}
