using System;
using System.Collections.Generic;
using ClickerRepository;
using Microsoft.AspNetCore.Mvc;

namespace ClickerService.Controllers
{
    [Route("api/[controller]")]
    public class TimeController : Controller
    {
        private ITimeRepository timeRepository;

        public TimeController(ITimeRepository timeRepository)
        {
            this.timeRepository = timeRepository;
        }

        // GET api/values
        [HttpGet]
        public DateTime Get()
        {
            return timeRepository.GetTime();
        }
    }
}
