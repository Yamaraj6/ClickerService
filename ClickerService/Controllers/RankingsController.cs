using ClickerRepository.Interfaces;
using ClickerService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ClickerService.Controllers
{
    /// </summary>
    /// Manages and creates rankings.
    /// </summary>
    [Route("api/[controller]")]
    public class RankingsController : Controller
    {
        private IRankingsRepository rankingsRepository;

        public RankingsController(IRankingsRepository rankingsRepository)
        {
            this.rankingsRepository = rankingsRepository;
        }

        /// </summary>
        /// Create specified type ranking of players from the database.
        /// <param name="idPlayer"> Player's id for which the ranking is to be created. </param>
        /// <param name="ranking"> Ranking type data </param>
        /// <returns> Ranking in Dictionary type which the key is player place in ranking 
        /// and value is the player data. </returns>
        /// <example> PUT api/rankings/5 </example>
        /// </summary>
        [HttpPut("{idPlayer}")]
        public Dictionary<int, RankingPlayer> Put(string idPlayer, [FromBody]Ranking ranking)
        {
            return rankingsRepository.GetRanking(idPlayer, ranking);
        }
    }
}
