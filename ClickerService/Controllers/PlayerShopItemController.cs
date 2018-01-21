using ClickerRepository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ClickerService.Controllers
{
    [Route("api/[controller]")]
    public class PlayerShopItemController : Controller
    {
        private IPlayerShopItemsRepository playerShopItemsRepository;

        public PlayerShopItemController(IPlayerShopItemsRepository playerShopItemsRepository)
        {
            this.playerShopItemsRepository = playerShopItemsRepository;
        }

        // GET api/playershopitem/5
        [HttpGet("{idPlayer}")]
        public Dictionary<int, int> Get(string idPlayer)
        {
            return playerShopItemsRepository.GetPlayerShopItems(idPlayer);
        }

        // POST api/playershopitem/5
        [HttpPut("{idPlayer}")]
        public void Post(string idPlayer, [FromBody]Dictionary<int, int> shopItemsWithLvls)
        {
            playerShopItemsRepository.UpdatePlayerShopItems(idPlayer, shopItemsWithLvls);
        }
    }
}