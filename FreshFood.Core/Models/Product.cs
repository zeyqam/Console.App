using FreshFood.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FreshFood.Core.Models
{
    public class Product:BaseModel
    {
        private static int _id;
        public string Name { get; set; }
        public double Price { get; set; }
        public Restaurant Restaurant { get; set; }

        public Product( string name,double price,Restaurant restaurant)
        {
            _id++;
            Id = _id;
            Price = price;
            Restaurant = restaurant;
            Name = name;
        }
        public override string ToString()
        {
            return $" Name: {Name} Restaurant:{Restaurant} Price:{Price} ";
        }
    }
}
