using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalStore
{
    [Serializable]
    public class VideoMovie : IComparable
    {
        public string MovieName { get; set; }
        public int TypeOfPrice { get; set; }
        public bool NowInStock { get; set; }
        public int rentDays;


        public VideoMovie(string name)
        {
            this.MovieName = name;

            this.TypeOfPrice = 4;
            this.NowInStock = true;

        }

        public bool PriceCalc(int a)
        {
            if (a == 1 | a == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
               
        }

        public void VideoMovieGetInfo()
        {
            Console.WriteLine(MovieName + ": price " + TypeOfPrice + "| in stock: " + (NowInStock == true ? "yes" : "no"));
        }

        public void CustomersOvnedMovieInfo()
        {
            Console.WriteLine("* "+MovieName + "|" + "days of rent + " + rentDays + " sum: " + TypeOfPrice * rentDays +"*");
        }

        public int CompareTo(object obj)
        {
            if (obj == null || !(obj is VideoMovie))
            {
                return 1;
            }

            VideoMovie videoMovie = obj as VideoMovie;

            if (videoMovie != null)
            {
                return this.MovieName.CompareTo(videoMovie.MovieName);
            }

            return -1;    
        }
    }
}
