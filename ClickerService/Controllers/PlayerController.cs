using ClickerRepository.Interfaces;
using ClickerService.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ClickerService.Controllers
{
    [Route("api/[controller]")]
    public class PlayerController : Controller
    {
        private IPlayerRepository playerRepository;

        public PlayerController(IPlayerRepository playerRepository)
        {
            this.playerRepository = playerRepository;
        }

        // GET api/player/5
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
        
        // PUT api/player/5
        [HttpPut]
        public void Put([FromBody]Player player)
        {
            playerRepository.UpdatePlayer(player);
        }

        // DELETE api/player/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            playerRepository.RemovePlayer(id);
        }
    }
}
