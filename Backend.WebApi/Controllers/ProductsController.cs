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
    public class ProductsController : ApiController
    {
        private Product[] products;

        public ProductsController() 
        {
            products = new Product[]
            {
                new Product() { Id=1, Name="Pizza", Category= "Mad", Price=(decimal) 49.50 },
                new Product() { Id=2, Name="Cola", Category= "Drik", Price=(decimal) 19.50 },
                new Product() { Id=3, Name="Øl", Category= "Drik", Price=(decimal) 24.50 },
                new Product() { Id=4, Name="Is", Category= "Slik", Price=(decimal) 14.50 },
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
    }
}
