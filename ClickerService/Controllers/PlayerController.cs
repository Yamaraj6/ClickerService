using ClickerRepository.Interfaces;
using ClickerService.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ClickerService.Controllers
{
    /// </summary>
    /// Manages players data in database.
    /// </summary>
    [Route("api/[controller]")]
    public class PlayerController : Controller
    {
        private IPlayerRepository playerRepository;

        public PlayerController(IPlayerRepository playerRepository)
        {
            this.playerRepository = playerRepository;
        }

        /// </summary>
        /// Selects player by Id in the database.
        /// <param name="id"> Player's id whose data to be extracted from the database. </param>
        /// <returns> Player from database. </returns>
        /// <example> GET api/player/5 </example>
        /// </summary>
        [HttpGet("{id}")]
        public Player Get(string id)
        {
            return playerRepository.GetPlayer(id);
        }

        /// </summary>
        /// Updates player in database or if the player doesn't exist adds him in the database.
        /// <param name="player"> Player data for update. </param>
        /// <example> POST api/player </example>
        /// </summary>
        [HttpPost]
        public void Post([FromBody]Player player)
        {
            playerRepository.UpdatePlayer(player);
        }

        /// </summary>
        /// Removes the player from the database.
        /// <param name="id"> Player's id whose data to be removed. </param>
        /// <example> POST api/player/5 </example>
        /// </summary>
        [HttpPost("{id}")]
        public void Post(string id)
        {
            playerRepository.RemovePlayer(id);
        }
    }
}
