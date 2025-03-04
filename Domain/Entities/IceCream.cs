using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class IceCream
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal BasePrice { get; set; }
        public IceCreamSize Size { get; set; }

        public Topping DefaultTopping { get; set; }

        private readonly List<Topping> _additionalToppings = new();
        public IReadOnlyCollection<Topping> AdditionalToppings => _additionalToppings.AsReadOnly();
        public IceCream() { }

        public IceCream(string name, decimal basePrice, IceCreamSize size)
        {
            Id = Guid.NewGuid();
            Name = name;
            BasePrice = basePrice;
            Size = size;
            // Create a default topping (for example, "Smarties" with 10% of base price).
            DefaultTopping = new Topping("Smarties", basePrice * 0.10m);
        }

        public void AddTopping(Topping topping)
        {
            _additionalToppings.Add(topping);
        }

        public decimal CalculatePrice()
        {
            decimal price = BasePrice;

            // Adjust price based on size.
            switch (Size)
            {
                case IceCreamSize.Medium:
                    price += 1.00m;
                    break;
                case IceCreamSize.Large:
                    price += 2.00m;
                    break;
            }

            // Add default topping price.
            price += DefaultTopping.Price;
            // Add additional toppings prices.
            price += _additionalToppings.Sum(t => t.Price);

            return price;
        }
    }
}




