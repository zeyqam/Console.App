using FreshFood.Core.Enums;
using FreshFood.Core.Models;
using FreshFood.Core.Repositories.RestaurantRepostory;
using FreshFood.Data.Repositories.RestaurantRepository;
using FreshFood.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FreshFood.Service.Services.Implementations
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository=new RestaurantRepository();
        public async Task<string> CreateAsync( string name, RestaurantCategory restaurantCategory)
        {
            if (name==null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return "Add correct name";
            }
            Restaurant restaurant=new Restaurant(restaurantCategory); 
            Console.ForegroundColor = ConsoleColor.Green;
            await _restaurantRepository.AddAsync(restaurant);
            return "Succesfully created";
            
        }

        public async Task<List<Restaurant>> GetAllAsync()
        =>await _restaurantRepository.GetAllAsync();
            
        

        public async Task <Restaurant> GetAsync(int id)
        {
            Restaurant restaurant=await _restaurantRepository.GetAsync(p=>p.Id==id);
            if (restaurant==null)
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine ("Restaurant not found");
               
            }
            return restaurant;
        }

        public async Task<List<Product>> GetProductsById(int id)
        {
            Restaurant restaurant=await _restaurantRepository.GetAsync (p=>p.Id==id);
            if (restaurant == null)
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("Restaurant not found");
                    return null;
            }
            return restaurant.Products;
        }

        public async Task<string> RemoveAsync(int id)
        {
            Restaurant restaurant=await _restaurantRepository.GetAsync(p=>p.Id == id);
            if(restaurant == null)
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("Restaurant not found");
            }
            await _restaurantRepository.RemoveAsync(restaurant);
            Console.ForegroundColor = ConsoleColor.Green;
            return "Succesfully removed";

            
            
        }

        public async Task<string> UpdateAsync(int id)
        {
            Restaurant restaurant=await _restaurantRepository.GetAsync((p)=>p.Id==id);
            if(restaurant == null)
            {
                Console.ForegroundColor= ConsoleColor.Red;
                return"Restaurant not found";

            }
           
            await _restaurantRepository.UpdateAsync(restaurant);
            Console.ForegroundColor = ConsoleColor.Green;
            return "Succesfully Updated";
        }
    }
}
