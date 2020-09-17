using FirstProject.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FirstProject.Data
{
    public class FirstSeeder
    {
        private readonly FirstContext _ctx;
        private readonly IHostingEnvironment _hosting;
        private readonly UserManager<StoreUser> _userManager;

        public FirstSeeder(FirstContext ctx, IHostingEnvironment hosting, UserManager<StoreUser> userManager)
        {
            _ctx = ctx;
            _hosting = hosting;
            _userManager = userManager;
        }
        public async Task SeedAsync()
        {
            _ctx.Database.EnsureCreated();
            StoreUser user = await _userManager.FindByNameAsync("levanphuc24@gmail.com");
            if (user == null)
            {
                user = new StoreUser()
                {
                    FirstName = "Phuc",
                    LastName = "Le",
                    Email = "levanphuc24@gmail.com",
                    UserName = "levanphuc24@gmail.com",
                };
                var result = await _userManager.CreateAsync(user, "P@ss0rd!");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not creat user");
                }
            }
            /*if (!_ctx.Products.Any())
            {
                //need create data
                var path = Path.Combine(_hosting.ContentRootPath,"Data/sample.json");
                var json = File.ReadAllText(path);
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
                _ctx.Products.AddRange(products);
                var order = _ctx.Orders.Where(o => o.Id == 1).FirstOrDefault();
                if(order != null)
                {
*//*                    order.User = user;
*//*                    order.Items = new List<OrderItem>()
                    {
                        new OrderItem(){
                            Product = products.First(),
                            Quantity =  5,
                            UnitPrice =  products.First().Price,
                        }
                    };
                }
                _ctx.SaveChanges();
            }*/
        }
    }
}
