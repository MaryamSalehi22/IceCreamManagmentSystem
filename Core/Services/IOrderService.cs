using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IOrderService
    {
        Order CreateOrder();
        void AddIceCream(Order order, IceCream iceCream);
        decimal GetTotalPrice(Order order);
    }
}
