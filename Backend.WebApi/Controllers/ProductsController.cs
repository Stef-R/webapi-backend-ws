using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Backend.WebApi;
using Backend.WebApi.Models;
using System.Web.Http.ExceptionHandling;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage;
using Microsoft.Azure;
using System.Configuration;

namespace Backend.WebApi.Controllers
{
    [RoutePrefix("products")]
    public class ProductsController : ApiController
    {
        private Product[] products;
        private Review[] reviews;
                
        public ProductsController()
        {
            products = new Product[]
            {
                new Product() { PartitionKey="xx", RowKey="1", Name="Pizza", Category= "Mad", Price=(double) 49.50 },
                new Product() { PartitionKey="xx", RowKey="2", Name="Cola", Category= "Drik", Price=(double) 19.50 },
                new Product() { PartitionKey="xx", RowKey="3", Name="Øl", Category= "Drik", Price=(double) 24.50 },
                new Product() { PartitionKey="xx", RowKey="4", Name="Is", Category= "Slik", Price=(double) 14.50 },
            };
            reviews = new Review[]
            {

                new Review() {Id=1, Productid=1, Rating=1,Text="*" },
                new Review() {Id=2, Productid=1, Rating=2,Text="**" },
                new Review() {Id=3, Productid=2, Rating=3,Text="****" },
                new Review() {Id=4, Productid=3, Rating=4,Text="super" },
                new Review() {Id=5, Productid=3, Rating=5,Text="jubi" },
                new Review() {Id=6, Productid=5, Rating=5,Text="fantstisk" },
            };

        }
        [Route("")]

        private CloudTableClient CreateTableClient()
        {

            //CloudStorageAccount storageAccount =
            //    CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
            CloudStorageAccount storageAccount =
                CloudStorageAccount.Parse(
                    ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString);

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            return tableClient;
             
        }

        internal void InitializeSample()
        {
            var cloudTableClient =  CreateTableClient();
            CloudTable table = cloudTableClient.GetTableReference("products");
            table.CreateIfNotExists();
            var prods = GetAllProducts();
            foreach (var item in prods)
            {
                TableOperation insertOp = TableOperation.InsertOrReplace(item);
                table.Execute(insertOp);
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }
        //[Route("{id}")]
        //public Product GetProduct(int id)
        //{
        //    foreach (var item in products)
        //    {
        //        if (item.Id == id)
        //        {
        //            return item;
        //        }
        //    }
        //    throw new NotFoundException();
        //}

        public class  NotFoundHandler : IExceptionHandler
        {
            public Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
            {
                if (context.ExceptionContext.Exception is NotFoundException) 
                {
                    var scr    = new StatusCodeResult( HttpStatusCode.NotFound,context.Request);
                    context.Result = scr;
                    return Task.FromResult(1);
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        [Route("{productid}/reviews")]
        public IEnumerable<Review> GetReviewsForProduct(int productid)
        {
            return  reviews.Where(id => (id.Productid == productid));
        }
        //public IHttpActionResult TestRev(int id)
        //{
        //    return GetReviewsForProduct(id);

        //}

    }
}
