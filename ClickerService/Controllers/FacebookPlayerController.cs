using ClickerRepository.Interfaces;
using ClickerService.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClickerService.Controllers
{
    [Route("api/[controller]")]
    public class FacebookPlayerController : Controller
    {
        private IPlayerRepository playerRepository;

        public FacebookPlayerController(IPlayerRepository playerRepository)
        {
            this.playerRepository = playerRepository;
        }

        // GET api/facebookplayer/5
        [HttpGet("{idFacebook}")]
        public Player Get(string idFacebook)
        {
            return playerRepository.GetPlayerByFacebookId(idFacebook);
        }
    }
}
