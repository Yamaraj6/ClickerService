using ClickerModels;
using ClickerService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ClickerService.Controllers
{
    [Route("api/[controller]")]
    public class ShopItemsController : Controller
    {
        private IShopItemsRepository shopItemsRepository;

        public ShopItemsController(IShopItemsRepository shopItemsRepository)
        {
            this.shopItemsRepository = shopItemsRepository;
        }

        // GET api/shopitems
        [HttpGet]
        public IEnumerable<ShopItem> Get()
        {
            return shopItemsRepository.GetShopItems();
        }
    }
}