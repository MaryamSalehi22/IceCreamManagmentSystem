using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public List<IceCream> IceCreams { get; set; }
        public DateTime OrderDate { get; set; }

        public Order()
        {
            Id = Guid.NewGuid();
            IceCreams = new List<IceCream>();
            OrderDate = DateTime.Now;
        }

        public void AddIceCream(IceCream iceCream)
        {
            IceCreams.Add(iceCream);
        }

        public decimal CalculateTotalPrice()
        {
            return IceCreams.Sum(i => i.CalculatePrice());
        }
    }
}
