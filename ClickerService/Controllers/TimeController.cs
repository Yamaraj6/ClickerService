using System;
using System.Collections.Generic;
using ClickerRepository;
using Microsoft.AspNetCore.Mvc;

namespace ClickerService.Controllers
{
    /// </summary>
    /// Returns server time.
    /// </summary>
    [Route("api/[controller]")]
    public class TimeController : Controller
    {
        private ITimeRepository timeRepository;

        public TimeController(ITimeRepository timeRepository)
        {
            this.timeRepository = timeRepository;
        }

        /// </summary>
        /// Get actual time in the server.
        /// <returns> Actual server time. </returns>
        /// <example> GET api/time </example>
        /// </summary>
        [HttpGet]
        public DateTime Get()
        {
            return timeRepository.GetTime();
        }
    }
}
