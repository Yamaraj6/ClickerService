using ClickerService.Models;
using System.Collections.Generic;

namespace ClickerRepository.Interfaces
{
    public interface IRankingsRepository
    {
        Dictionary<IEnumerable<Player>, string> GetRankings(string playerId);
        //IEnumerable<Player> GetPlayersByOffset(string id, int offset, string statName);
        //IEnumerable<Player> TopPlayers(string id, int offset, string statName);
    }
}