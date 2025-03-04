using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class OrderService : IOrderService
    {
        public Order CreateOrder()
        {
            return new Order();
        }

        public void AddIceCream(Order order, IceCream iceCream)
        {
            order.AddIceCream(iceCream);
        }

        public decimal GetTotalPrice(Order order)
        {
            return order.CalculateTotalPrice();
        }
    }
}
