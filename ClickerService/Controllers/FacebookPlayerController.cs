using ClickerRepository.Interfaces;
using ClickerService.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClickerService.Controllers
{
    /// </summary>
    /// Manages players data using Facebook Id in database.
    /// </summary>
    [Route("api/[controller]")]
    public class FacebookPlayerController : Controller
    {
        private IPlayerRepository playerRepository;

        public FacebookPlayerController(IPlayerRepository playerRepository)
        {
            this.playerRepository = playerRepository;
        }

        /// </summary>
        /// Selects player by Facebook Id.
        /// <param name="idFacebook"> Facebook Id which data will be select. </param>
        /// <returns> Player from database.</returns>
        /// <example> GET api/facebookplayer/5 </example>
        /// </summary>
        [HttpGet("{idFacebook}")]
        public Player Get(string idFacebook)
        {
            return playerRepository.GetPlayerByFacebookId(idFacebook);
        }
    }
}
