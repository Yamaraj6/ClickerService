using ClickerService.Models;
using System.Collections.Generic;

namespace ClickerModels
{
    public interface IShopItemsRepository
    {
        IEnumerable<ShopItem> GetShopItems();
    }
}