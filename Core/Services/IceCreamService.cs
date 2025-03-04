using Application.Contracts;
using Application.Inrefaces;
using Domain.Entities;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class IceCreamService : IIceCreamService
    {
        private readonly IRepository<IceCream> _iceCreamRepository;
        private readonly IRepository<Topping> _toppingRepository;

        public IceCreamService(IRepository<IceCream> iceCreamRepository, IRepository<Topping> toppingRepository)
        {
            _iceCreamRepository = iceCreamRepository;
            _toppingRepository = toppingRepository;
        }

        public async Task<decimal> CalculatePriceAsync(IceCreamRequestDto request)
        {
            if (request == null)
            {
                throw new ValidationException("Request cannot be null.");
            }

            var iceCream = await _iceCreamRepository.GetByIdAsync(request.IceCreamId);
            if (iceCream == null)
            {
                throw new IceCreamNotFoundException(request.IceCreamId);
            }

            decimal basePrice = iceCream.BasePrice;
            switch (iceCream.Size)
            {
                case IceCreamSize.Small:
                    break;
                case IceCreamSize.Medium:
                    basePrice += 1.00m;
                    break;
                case IceCreamSize.Large:
                    basePrice += 2.00m;
                    break;
                default:
                    throw new InvalidIceCreamSizeException();
            }

            decimal toppingPrice = 0;
            foreach (var toppingId in request.ToppingIds)
            {
                var topping = await _toppingRepository.GetByIdAsync(toppingId);
                if (topping == null)
                {
                    throw new ToppingNotFoundException(toppingId);
                }
                toppingPrice += topping.Price;
            }

            return basePrice + toppingPrice;
        }
    }
}

