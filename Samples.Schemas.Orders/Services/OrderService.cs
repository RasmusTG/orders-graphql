using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Samples.Schemas.Orders
{
    public class OrderService : IOrderService
    {
        private IList<Order> _orders;

        public OrderService(ICustomerService customerData)
        {
            _orders = new List<Order>();
            _orders.Add(new Order("Test 1", "Test 1 description", DateTime.Now, customerData.GetCustomerById(1), "FAEBD971-CBA5-4CED-8AD5-CC0B8D4B7827"));
            _orders.Add(new Order("Test 2", "Test 2 description", DateTime.Now.AddHours(1), customerData.GetCustomerById(2), "F43A4F9D-7AE9-4A19-93D9-2018387D5378"));
            _orders.Add(new Order("Test 3", "Test 3 description", DateTime.Now.AddHours(2), customerData.GetCustomerById(3), "2D542571-EF99-4786-AEB5-C997D82E57C7"));
        }

        public Task<IEnumerable<Order>> GetAsync()
        {
            return Task.FromResult(_orders.AsEnumerable());
        }

        public Task<Order> GetByIdAsync(string id)
        {
            return Task.FromResult(_orders.Single(o => Equals(o.Id, id)));
        }
    }
}