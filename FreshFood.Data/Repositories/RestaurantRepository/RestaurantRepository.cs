using FreshFood.Core.Models;
using FreshFood.Core.Repositories.RestaurantRepostory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshFood.Data.Repositories.RestaurantRepository
{
    public  class RestaurantRepository:Repository<Restaurant>,IRestaurantRepository
    {
    }
}
