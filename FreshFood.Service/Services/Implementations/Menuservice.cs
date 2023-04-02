using FreshFood.Core.Enums;
using FreshFood.Core.Models;
using FreshFood.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FreshFood.Service.Services.Implementations
{
    public class Menuservice : IMenuService
    {
        private readonly IRestaurantService _restaurantService= new RestaurantService();
        private readonly IProductservice _productService= new ProductService();
        public async Task ShowMenuAsync()
        {

            Show();
            int.TryParse(Console.ReadLine(), out int result);
            while (result != 0)
            {
                switch (result)
                {
                    case 1:
                        Console.Clear();
                        await CreateRestaurant();
                        break;
                    case 2:
                        Console.Clear();
                        await ShowAllRestaurant();
                        break;
                    case 3:
                        Console.Clear();
                        await ShowRestaurant();
                        break;
                    case 4:
                        Console.Clear();
                        await UpdateRestaurant();
                        break;
                    case 5:
                        Console.Clear();
                        await RemoveRestaurant();
                        break;
                    case 6:
                        Console.Clear();
                        await CreateProduct();
                        break;
                    case 7:
                        Console.Clear();

                        await ShowAllProducts();
                        break;
                    case 8:
                        Console.Clear();

                        await GetProductById();
                        break;
                    case 9:
                        Console.Clear();
                        await UpdateProduct();
                        break;
                    case 10:
                        Console.Clear();
                        await RemoveProduct();
                        break;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("please choose valid option");
                        break;

                }
                Console.ForegroundColor = ConsoleColor.White;

                Show();
                int.TryParse(Console.ReadLine(), out result);
            }
        }
        private void Show()
        {
            Console.WriteLine("1.Create Restaurant");
            Console.WriteLine("2.Show All Reataurant");
            Console.WriteLine("3.Get Restaurant By Id");
            Console.WriteLine("4.Update Restaurant");
            Console.WriteLine("5.Remove Restaurant");
            Console.WriteLine("6.Create Product");
            Console.WriteLine("7.Show All Product");
            Console.WriteLine("8.Get Product By Id");
            Console.WriteLine("9.Update Product");
            Console.WriteLine("10.Remove Product");
            Console.WriteLine("0.Remove Product");
        }
        private async Task CreateRestaurant()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Add Restaurant name :");
            string Name = Console.ReadLine();
            
            Console.WriteLine("Choose GroupCategory :");

            var Enums = Enum.GetValues(typeof(RestaurantCategory));
            foreach (var item in Enums)
            {
                Console.WriteLine((int)item + "." + item);
            }
            int.TryParse(Console.ReadLine(), out int restaurantCategory);

            try
            {
                Enums.GetValue(restaurantCategory - 1);
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("RestaurantCategory is not valid");
                return;
            }
            string message = await _restaurantService.CreateAsync(Name, (RestaurantCategory)restaurantCategory);
            Console.WriteLine(message);
        }
        private async Task ShowAllRestaurant()
        {
            List<Restaurant> restaurants = await _restaurantService.GetAllAsync();
            Console.ForegroundColor = ConsoleColor.Blue;
            foreach (var item in restaurants)
            {
                Console.WriteLine(item);
            }
        }
        private async Task ShowRestaurant()
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Enter restaurant Id");
            int.TryParse(Console.ReadLine(), out int id);

            Restaurant restaurant = await _restaurantService.GetAsync(id);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(restaurant);
        }
        private async Task UpdateRestaurant()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Add Restaurant Id");
            int.TryParse(Console.ReadLine(), out int id);

            

            string message = await _restaurantService.UpdateAsync(id);
            Console.WriteLine(message);
        }
        private async Task RemoveRestaurant()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Add Restaurant Id");

            int.TryParse(Console.ReadLine(), out int id);

            string message = await _restaurantService.RemoveAsync(id);
            Console.WriteLine(message);
        }
        private async Task CreateProduct()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter price");
            double.TryParse(Console.ReadLine(), out double price);
            Console.WriteLine("Enter Id");
            int.TryParse(Console.ReadLine(),out int id);
            string message = await _productService.CreateAsync( name,price,id);
            Console.WriteLine(message);
        }
        private async Task ShowAllProducts()
        {
            List<Product> Products = await _productService.GetAllAsync();

            Console.ForegroundColor = ConsoleColor.Blue;
            foreach (var item in Products)
            {
                Console.WriteLine(item);
            }

        }
        private async Task GetProductById()
        {
            Console.WriteLine("enter product id");
            int.TryParse(Console.ReadLine(), out int id);
            Product product= await _productService.GetAsync(id);
            Console.WriteLine(product);
        }
        private async Task UpdateProduct()
        {

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Enter Id");

            int.TryParse(Console.ReadLine(), out int id);

            Console.WriteLine("Enter Name");
            string name = Console.ReadLine();

            Console.WriteLine("Enter price");
            double.TryParse(Console.ReadLine(), out double price);
           
            string message = await _productService.UpdateAsync(id, name, price);
            Console.WriteLine(message);

        }
        private async Task RemoveProduct()
        {
            Console.WriteLine(" enter id");

            int.TryParse(Console.ReadLine(), out int id);
            string message = await _productService.RemoveAsync(id);
            Console.WriteLine(message);
        }












    }
}

