using ClickerService.Models;
using System.Collections.Generic;

namespace ClickerRepository.Interfaces
{
    public interface IRankingsRepository
    {
        Dictionary<int, RankingPlayer> GetRanking(string playerId, Ranking ranking);
    }
}