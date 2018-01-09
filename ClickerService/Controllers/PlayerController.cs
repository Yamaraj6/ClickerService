using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ClickerRepository;
using ClickerRepository.Interfaces;
using ClickerService.Models;
using Microsoft.AspNetCore.Mvc;

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
            return playerRepository.GetPlayerByFacebookId(id);
        }

        // POST api/player
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/player/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
