using ClickerRepository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ClickerService.Controllers
{
    /// </summary>
    /// Manages items which players has.
    /// </summary>
    [Route("api/[controller]")]
    public class PlayerShopItemController : Controller
    {
        private IPlayerShopItemsRepository playerShopItemsRepository;

        public PlayerShopItemController(IPlayerShopItemsRepository playerShopItemsRepository)
        {
            this.playerShopItemsRepository = playerShopItemsRepository;
        }

        /// </summary>
        /// Selects player items from the database.
        /// <param name="idPlayer"> Player's id whose items will be select. </param>
        /// <returns> Dictionary which the key is item Id and value is the item level. </returns>
        /// <example> GET api/playershopitem/5 </example>
        /// </summary>
        [HttpGet("{idPlayer}")]
        public Dictionary<int, int> Get(string idPlayer)
        {
            return playerShopItemsRepository.GetPlayerShopItems(idPlayer);
        }

        /// </summary>
        /// Updates player items in database.
        /// <param name="idPlayer"> Player's id to which the items belongs. </param>
        /// <param name="shopItemsWithLvls"> Items with leves. </param>
        /// <example> POST api/playershopitem/5 </example>
        /// </summary>
        [HttpPost("{idPlayer}")]
        public void Post(string idPlayer, [FromBody]Dictionary<int, int> shopItemsWithLvls)
        {
            playerShopItemsRepository.UpdatePlayerShopItems(idPlayer, shopItemsWithLvls);
        }
    }
}