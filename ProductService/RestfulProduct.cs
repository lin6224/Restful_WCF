using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;


namespace ProductService
{
    public class RestfulProduct : IRestfulProduct
    {
        public void AddProduct(string name)
        {
            using (AdventureWorks2014Entities db = new AdventureWorks2014Entities())
            {
                Product P = new Product { Name = name };
                db.Products.Add(p);
                db.SaveChanges();
            }
        }

        public void DeleteProduct(string id)
        {
            try
            {
                int pId = Convert.ToInt32(id);

                using (AdventureWorks2014Entities db = new AdventureWorks2014Entities())
                {
                    Product p = db.Products.SingleOrDefault( p => p.ID == pId);
                    db.Products.Remove(p);
                    db.SaveChanges();
                }
            }
            catch
            {
                throw new FaultException("Something went wrong");
            }
        }

        public Product GetProductById(string id)
        {
            try
            {
                int pId = Convert.ToInt32(id);

                using (AdventureWorks2014Entities db = new AdventureWorks2014Entities())
                {
                    return db.Products.SingleOrDefault(p => p.ID == pId);
                }
            }
            catch
            {
                throw new FaultException("Something went wrong");
            }
        }

        public List<Product> GetProductsList()
        {
            using (AdventureWorks2014Entities db = new AdventureWorks2014Entities())
            {
                return db.Products.ToList();
            }
        }

        public void UpdateProduct(string id, string name)
        {
            try
            {
                int pId = Convert.ToInt32(id);

                using (AdventureWorks2014Entities db = new AdventureWorks2014Entities())
                {
                    Product p = db.Products.SingleOrDefault( p => p.ID == pId);
                    p.Name = name;
                    db.SaveChanges();
                }
            }
            catch
            {
                throw new FaultException("Something went wrong");
            }
        }
    }
}
