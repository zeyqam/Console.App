
using FreshFood.Service.Services.Implementations;
using FreshFood.Service.Services.Interfaces;

IMenuService menuService = new Menuservice();
await menuService.ShowMenuAsync();
