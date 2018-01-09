using System.Collections.Generic;

namespace ClickerModels
{
    public interface IPlayerShopItemsRepository
    {
        Dictionary<int, int> GetPlayerShopItems(string idPlayer);
        void UpdatePlayerShopItems(string idPlayer, Dictionary<int, int> shopItemsWithLvls); 
    }
}