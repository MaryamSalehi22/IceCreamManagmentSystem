using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IIceCreamService _iceCreamService;
        private static Order CurrentOrder = new Order();

        public OrderController(IOrderService orderService, IIceCreamService iceCreamService)
        {
            _orderService = orderService;
            _iceCreamService = iceCreamService;
        }

        public IActionResult Index()
        {
            return View(CurrentOrder);
        }

        public IActionResult AddIceCream()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddIceCream(string name, decimal basePrice, IceCreamSize size)
        {
            var iceCream = new IceCream(name, basePrice, size);

            _orderService.AddIceCream(CurrentOrder, iceCream);
            return RedirectToAction("Index");
        }
    }
}
