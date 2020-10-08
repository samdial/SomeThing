using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            int Cell100 =BinaryCellsArray.cells.GetLength(0);
            int Cell60 = BinaryCellsArray.cells.GetLength(1);
            Console.Write("z231234439023409802359275");
            Console.Write(1);
            Console.ReadKey();
        }
    }


   public class BinaryCell
    {
        public bool actived;

        public bool GetActived()
        {
            return actived;
        }

        public void SetActived(bool value)
        {
            actived = value;
        }
    }

    static class BinaryCellsArray
    {
        public static BinaryCell[,] cells = new BinaryCell[100, 60];

        public bool BinaryCellChanger(int k, int i)
        {
            if(cells[i,k].actived==true)
            {
                Console.WriteLine();
                return true;
            }
            return false;
        }

    }
}
