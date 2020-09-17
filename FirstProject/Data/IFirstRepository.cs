using FirstProject.Data.Entities;
using System.Collections.Generic;

namespace FirstProject.Data
{
    public interface IFirstRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string catetgory);
        IEnumerable<Order> GetAllOrders();
        Order GetOrdersById(int id);
        bool SaveAll();
        void AddEnity(object model);
    }
}