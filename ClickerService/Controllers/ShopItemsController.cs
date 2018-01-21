using ClickerModels;
using ClickerService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ClickerService.Controllers
{
    /// </summary>
    /// Manages items which player could buy in the shop.
    /// </summary>
    [Route("api/[controller]")]
    public class ShopItemsController : Controller
    {
        private IShopItemsRepository shopItemsRepository;

        public ShopItemsController(IShopItemsRepository shopItemsRepository)
        {
            this.shopItemsRepository = shopItemsRepository;
        }

        /// </summary>
        /// Selects items from the database.
        /// <returns> List of items which player could buy in the shop. </returns>
        /// <example> GET api/shopitems </example>
        /// </summary>
        [HttpGet]
        public IEnumerable<ShopItem> Get()
        {
            return shopItemsRepository.GetShopItems();
        }
    }
}