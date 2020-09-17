using FirstProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FirstProject.Data
{
    public class FirstRepository : IFirstRepository
    {
        private readonly FirstContext _ctx;

        public FirstRepository(FirstContext ctx)
        {
            _ctx = ctx;
        }

        public void AddEnity(object model)
        {
            _ctx.Add(model);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _ctx.Orders.ToList();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _ctx.Products
                .OrderBy(p => p.Title)
                .ToList();
        }

        public Order GetOrdersById(int id)
        {
            return _ctx.Orders
             .Include(p => p.Items)
             .Where(o=>o.Id == id)
             .FirstOrDefault();
        }

        public IEnumerable<Product> GetProductsByCategory(string catetgory)
        {
            return _ctx.Products
                .Where(p => p.Category == catetgory)
                .ToList();
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}
