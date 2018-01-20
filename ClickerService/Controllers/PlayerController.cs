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
