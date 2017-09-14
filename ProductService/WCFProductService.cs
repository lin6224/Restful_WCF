using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ProductInterfaces;

namespace ProductService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WCFProductService" in both code and config file together.
    public class WCFProductService : IWCFProductService
    {
        public List<string> ListProducts()
        {
            List<string> productsList = new List<string>();

            Console.WriteLine("method ListProducts is working ...");
            try
            {
                using (AdventureWorks2014Entities db = new AdventureWorks2014Entities())
                {
                    var products = from p in db.Products
                                   select p.ProductNumber;

                    productsList = products.ToList();
                    
                }
            }
            catch
            {

            }

            return productsList;
        }
    }
}
