using FreshFood.Core.Enums;
using FreshFood.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FreshFood.Core.Models
{
    public  class Restaurant:BaseModel
    {
        private static int _id;
        public List<Product> Products;
        public  RestaurantCategory Category { get; set; }
        

        public Restaurant( RestaurantCategory category)
        {
            _id++;
            Id = _id;
            Products = new List<Product>();
            Category = category;
            
        }
        public override string ToString()
        {
            return $"Id:{Id}  Category:{Category} ";
        }
    }

    
}
