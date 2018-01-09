using System;
using System.Collections.Generic;
using System.Text;

namespace ClickerRepository
{
    public class TimeRepository : ITimeRepository
    {
        public DateTime GetTime()
        {
            return DateTime.Now;
        }
    }
}
