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

        /*  // POST api/player/5
          [HttpPost]
          public void Post()
          {
              for (int i = 0; i < 100000; i++)
              {
                  Player testPlayer = new Player
                  {
                      Id = Guid.NewGuid().ToString(),
                      IdFacebook = Guid.NewGuid().ToString(),
                      FirstLogin = DateTime.Now,
                      LastLogout = DateTime.Now,
                      Name = "Andrzej",
                      Country = "Polska",
                      ImageUrl = "sadasda",
                      Money = 0,
                      Diamonds = 0,
                      MaxClickMultiplier = i,
                      MaxCps = i,
                      TotalClicks = i,
                      TotalEarnings = i
                  };
                  playerRepository.UpdatePlayer(testPlayer);
              }
          }*/

        /// </summary>
        /// Updates player in database or if the player doesn't exist adds him in the database.
        /// <param name="player"> Player data for update. </param>
        /// <example> PUT api/player </example>
        /// </summary>
        [HttpPut]
        public void Put([FromBody]Player player)
        {
            playerRepository.UpdatePlayer(player);
        }

        /// </summary>
        /// Removes the player from the database.
        /// <param name="id"> Player's id whose data to be removed. </param>
        /// <example> DELETE api/player/5 </example>
        /// </summary>
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            playerRepository.RemovePlayer(id);
        }
    }
}
