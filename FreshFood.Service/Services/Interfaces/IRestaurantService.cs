﻿using FreshFood.Core.Enums;
using FreshFood.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshFood.Service.Services.Interfaces
{
    public interface IRestaurantService
    {
        public Task<string> CreateAsync( string name,RestaurantCategory restaurantCategory);
        public Task<string> UpdateAsync(int id);
        public Task<string> RemoveAsync(int id);
        public Task<Restaurant> GetAsync(int id);
        public Task<List<Restaurant>> GetAllAsync();
        public Task<List<Product>> GetProductsById(int id);
    }
}
