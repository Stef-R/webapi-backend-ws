using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Backend.WebApi.Models;


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
                new Product() { Id=1, Name="Pizza", Category= "Mad", Price=(decimal) 49.50 },
                new Product() { Id=2, Name="Cola", Category= "Drik", Price=(decimal) 19.50 },
                new Product() { Id=3, Name="Øl", Category= "Drik", Price=(decimal) 24.50 },
                new Product() { Id=4, Name="Is", Category= "Slik", Price=(decimal) 14.50 },
            };
            reviews = new Review[]
            {

                new Review() {Id=9, Productid=1, Rating=1,Text="*" },
                new Review() {Id=9, Productid=1, Rating=2,Text="**" },
                new Review() {Id=9, Productid=2, Rating=3,Text="****" },
                new Review() {Id=9, Productid=3, Rating=4,Text="super" },
                new Review() {Id=9, Productid=3, Rating=5,Text="jubi" },
                new Review() {Id=9, Productid=5, Rating=5,Text="fantstisk" },
            };

        }
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }
        public IHttpActionResult GetProducts(int id)
        {
            foreach (var item in products)
            {
                if (item.Id == id)
                {
                    return Ok(item);
                }
            }
            return NotFound();
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
