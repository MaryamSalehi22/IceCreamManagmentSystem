using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class IceCreamTopping
    {
        public Guid IceCreamId { get; set; }
        public IceCream IceCream { get; set; }

        public Guid ToppingId { get; set; }
        public Topping Topping { get; set; }
    }
}
