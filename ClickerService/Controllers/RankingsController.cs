using ClickerRepository.Interfaces;
using ClickerService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ClickerService.Controllers
{
    [Route("api/[controller]")]
    public class RankingsController : Controller
    {
        private IRankingsRepository rankingsRepository;

        public RankingsController(IRankingsRepository rankingsRepository)
        {
            this.rankingsRepository = rankingsRepository;
        }

        // POST api/rankings/5
        [HttpPost("{idPlayer}")]
        public Dictionary<int, RankingPlayer> Post(string idPlayer, [FromBody]Ranking ranking)
        {
            return rankingsRepository.GetRanking(idPlayer, ranking);
        }
    }
}
