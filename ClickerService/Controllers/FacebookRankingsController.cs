using ClickerRepository;
using ClickerService.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClickerService.Controllers
{
    [Route("api/[controller]")]
    public class FacebookRankingsController : Controller
    {
        private IFacebookRankingsRepository facebookRankingsRepository;

        public FacebookRankingsController(IFacebookRankingsRepository facebookRankingsRepository)
        {
            this.facebookRankingsRepository = facebookRankingsRepository;
        }
        
        // PUT api/facebookrankings
        [HttpPost]
        public IEnumerable<Player> Post([FromBody]List<string> friendsFbId)
        {
            return facebookRankingsRepository.GetFacebookFriendRanking(friendsFbId);
        }
    }
}
