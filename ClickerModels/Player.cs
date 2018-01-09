using System;
using System.Collections.Generic;

namespace ClickerService.Models
{
    public partial class Player
    {
        public string Id { get; set; }
        public string IdFacebook { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Country { get; set; }
        public DateTime? FirstLogin { get; set; }
        public DateTime? LastLogOut { get; set; }
        public double Money { get; set; }
        public int Diamonds { get; set; }

        public int? Rank { get; set; } 
        public double? TotalEarnings { get; set; }
        public double? TotalClicks { get; set; }
        public double? MaxCps { get; set; }
        public double? MaxClickMultiplier { get; set; }
    }
}
