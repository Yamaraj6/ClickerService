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
        
        // POST api/player/5
        [HttpPost]
        public void Post([FromBody]Player player)
        {
            playerRepository.UpdatePlayer(player);
        }

        // POST api/player/5 DELETE PLAYER
        [HttpPost("{id}")]
        public void Post(string id)
        {
            playerRepository.RemovePlayer(id);
        }
    }
}
