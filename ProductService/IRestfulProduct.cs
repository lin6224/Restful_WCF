using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;

using ProductService;


    [ServiceContract]
    public interface IRestfulProduct
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        List<Product> GetProductsList();

        [OperationContract]
        [WebGet(UriTemplate = "Product/{id}")]
        Product GetProductById(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "AddProduct/{name}")] 
        void AddProduct(string name);

        [OperationContract]
        [WebInvoke(UriTemplate = "UpdateProduct/{id}/{name}")]
        void UpdateProduct(string id, string name);

        [OperationContract]
        [WebInvoke(UriTemplate = "DeleteProduct/{id}")]
        void DeleteProduct(string id);
    }

