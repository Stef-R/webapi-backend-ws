using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;

namespace Backend.WebApi.Models
{
    public class Product :TableEntity
    {
        private string name;
        private string category;
        private double price;
                
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

        public double Price
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