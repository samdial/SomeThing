using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace MovieRentalStore
{
    [Serializable]
    class CustomersRoster
    {
        static public List<RentalCustomer> RentalCustomers = new List<RentalCustomer>();


        static public void GetAllCustomersInfo()
        {
            int i = 1;
            foreach(RentalCustomer rc in RentalCustomers)
            {
                Console.Write(i+":");
                rc.GetRentalCustomerInfo();
                i += 1;
            }
            
        }


       
        static public void SerializeCustomers()
        {
            BinaryFormatter CustomerFormatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("CustomersRoster.dat", FileMode.OpenOrCreate))
            {
                CustomerFormatter.Serialize(fs, CustomersRoster.RentalCustomers);
            }
        }
        static public void DeserializeCustomers()
        {
            BinaryFormatter CustomerFormatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("CustomersRoster.dat", FileMode.OpenOrCreate))
            {
                CustomersRoster.RentalCustomers = (List<RentalCustomer>)CustomerFormatter.Deserialize(fs);
            }
        }
    }
}
