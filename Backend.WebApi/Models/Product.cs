using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.WebApi.Models
{
    public class Product
    {
        private int id;
        private string name;
        private string category;
        private decimal price;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Category
        {
            get
            {
                return category;
            }

            set
            {
                category = value;
            }
        }

        public decimal Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }
    }
}