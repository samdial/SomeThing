using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalStore
{
    [Serializable]
    public class RentalCustomer
    {
        public string Name { get; set; }
        public int bonuspoints;
        public List<VideoMovie> moviesRentedNow = new List<VideoMovie>();
        public int debt;

        public RentalCustomer(string name)
        {
            this.Name = name;
            
        }
        public void GetRentalCustomerInfo()
        {
            
            Console.WriteLine(" " + Name + ".  BONUS points: " + bonuspoints);
            foreach(VideoMovie m in moviesRentedNow)
            {
                m.CustomersOvnedMovieInfo();
            }
            Console.WriteLine("Final price: " + debt + "\n.....................");
        }

        public void GiveMovieFromInventoryToCustomer(int movieIndex)
        {   
            if(Inventory.allMovies[movieIndex].NowInStock == true)
                {
                moviesRentedNow.Add(Inventory.allMovies[movieIndex]);
                Inventory.allMovies[movieIndex].NowInStock = false;
                }
            

        }

        public void GetRentedMoviesRoster()
        {
            int i = 1;
            foreach(VideoMovie m in moviesRentedNow)
            {
                Console.Write(i+".");
                m.VideoMovieGetInfo();
                i += 1;
            }
        }
    }
}
