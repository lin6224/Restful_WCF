using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ProductService
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(WCFProductService)))
            {
                host.Open();
                Console.WriteLine("Service is open ...");
                Console.WriteLine("Press enter to close server");
                Console.ReadKey();
            }
        }
    }
}
