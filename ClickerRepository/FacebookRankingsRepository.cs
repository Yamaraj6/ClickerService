using System;
using System.Collections.Generic;
using System.Text;
using ClickerService.Models;

namespace ClickerRepository
{
    public class FacebookRankingsRepository : IFacebookRankingsRepository
    {
        public IEnumerable<Player> GetFacebookFriendRank(IEnumerable<string> friendsFbId)
        {
            throw new NotImplementedException();
        }
    }
}
