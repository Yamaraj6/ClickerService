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

        // PUT api/rankings/5
        [HttpPut("{idPlayer}")]
        public Dictionary<int, RankingPlayer> Put(string idPlayer, [FromBody]Ranking ranking)
        {
            return rankingsRepository.GetRanking(idPlayer, ranking);
        }
    }
}
