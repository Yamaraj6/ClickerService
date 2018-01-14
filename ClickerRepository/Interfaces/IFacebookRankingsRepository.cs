using ClickerService.Models;
using System.Collections.Generic;

namespace ClickerRepository
{
    public interface IFacebookRankingsRepository
    {
        IEnumerable<Player> GetFacebookFriendRanking(List<string> friendsFbId);
    }
}