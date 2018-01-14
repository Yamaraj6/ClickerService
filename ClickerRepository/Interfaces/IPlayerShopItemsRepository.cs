using System.Collections.Generic;

namespace ClickerRepository.Interfaces
{
    public interface IPlayerShopItemsRepository
    {
        Dictionary<int, int> GetPlayerShopItems(string idPlayer);
        void UpdatePlayerShopItems(string idPlayer, Dictionary<int, int> shopItemsWithLvls); 
    }
}