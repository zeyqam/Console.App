using FreshFood.Core.Enums;
using FreshFood.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshFood.Service.Services.Interfaces
{
    public interface IProductservice
    {
        public Task <string> CreateAsync(string name,double price,int RestaurantId);
        public Task<string> UpdateAsync(int id,string name,double price);
        public Task <string>RemoveAsync(int id);
        public Task<Product> GetAsync(int id);
        public Task<List<Product>> GetAllAsync();
        
    }
}
