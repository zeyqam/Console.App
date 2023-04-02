using FreshFood.Core.Enums;
using FreshFood.Core.Models;
using FreshFood.Core.Repositories.RestaurantRepostory;
using FreshFood.Data.Repositories.RestaurantRepository;
using FreshFood.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FreshFood.Service.Services.Implementations
{
    public class ProductService : IProductservice
    {
        private readonly IRestaurantRepository _restaurantRepository=new RestaurantRepository();
        public async Task<string> CreateAsync(string name, double price,int RestaurantId)
        {
            if (price<=0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return "Price must be more than 0";
            }
           Restaurant restaurant=await _restaurantRepository.GetAsync(p=>p.Id==RestaurantId);
            if(restaurant == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return "Enter correct name";
            }
           
            Product product = new Product(name,price,restaurant);
            product.CreatedDate = DateTime.Now;
            restaurant.Products.Add(product);
            Console.ForegroundColor = ConsoleColor.Green;
            return "Succesfully created";
        }

        public async Task<List<Product>> GetAllAsync()
        {

            List<Restaurant> restaurants = await _restaurantRepository.GetAllAsync();

            List<Product> products = new List<Product>();

            foreach (Restaurant restaurant in restaurants)
            {
                products.AddRange(restaurant.Products);
            }
            return products;
        }

        public async Task<Product> GetAsync(int id)
        {
            List<Restaurant> restaurants = await _restaurantRepository.GetAllAsync();

            foreach (var item in restaurants)
            {
                Product product = item.Products.Find(p => p.Id == id);
                if (product != null)
                {
                    return product;
                }
            }
            return null;
        }

        public async Task<string> RemoveAsync(int id)
        {
            List<Restaurant> restaurants = await _restaurantRepository.GetAllAsync();

            foreach (var item in restaurants)
            {
                Product product = item.Products.Find( p => p.Id == id);
                if (product != null)
                {
                    item.Products.Remove(product);
                    
                    Console.ForegroundColor = ConsoleColor.Green;
                    return "Succesfuly removed";
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;

            return "Product is not found";
        }

        public async Task<string> UpdateAsync(int id,string name,double price)
        {
            List<Restaurant> restaurants = await _restaurantRepository.GetAllAsync();

            foreach (var item in restaurants)
            {
                Product product = item.Products.Find(x => x.Id == id);
                if (product != null)
                {


                    product.Name= name;
                    product.Price = price;
                    
                    product.UpdatedDate = DateTime.Now;
                    Console.ForegroundColor = ConsoleColor.Green;
                    return "Succesfuly Updated";
                    
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;

            return "Product is not found";
        }
    }
}
