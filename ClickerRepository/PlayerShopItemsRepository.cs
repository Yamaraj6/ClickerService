using System;
using System.Collections.Generic;
using System.Text;

namespace ClickerModels
{
    public class PlayerShopItemsRepository : IPlayerShopItemsRepository
    {
        public Dictionary<int, int> GetPlayerShopItems(string idPlayer)
        {
            throw new NotImplementedException();
        }

        public void UpdatePlayerShopItems(string idPlayer, Dictionary<int, int> shopItemsWithLvls)
        {
            throw new NotImplementedException();
        }
    }
}
