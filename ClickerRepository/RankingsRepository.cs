using ClickerRepository.Interfaces;
using ClickerService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClickerRepository
{
    public class RankingsRepository : IRankingsRepository
    {
        public Dictionary<IEnumerable<Player>, string> GetRankings(string id)
        {
            throw new NotImplementedException();
        }
    }
}
