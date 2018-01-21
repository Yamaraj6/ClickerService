using ClickerRepository;
using ClickerService.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClickerService.Controllers
{
    /// </summary>
    /// Manages rankings data using Facebook Id in database.
    /// </summary>
    [Route("api/[controller]")]
    public class FacebookRankingsController : Controller
    {
        private IFacebookRankingsRepository facebookRankingsRepository;

        public FacebookRankingsController(IFacebookRankingsRepository facebookRankingsRepository)
        {
            this.facebookRankingsRepository = facebookRankingsRepository;
        }

        /// </summary>
        /// Selects players by list of Facebook Ids in the database.
        /// <param name="friendsFbId"> List of Facebook Id Players whose to be extracted from the database. </param>
        /// <returns> Players list from database.</returns>
        /// <example> PUT api/facebookrankings </example>
        /// </summary>
        [HttpPut]
        public IEnumerable<Player> Put([FromBody]List<string> friendsFbId)
        {
            return facebookRankingsRepository.GetFacebookFriendRanking(friendsFbId);
        }
    }
}
