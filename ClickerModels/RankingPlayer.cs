namespace ClickerService.Models
{
    public partial class RankingPlayer
    {
        public string Id { get; set; }
        public string IdFacebook { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Country { get; set; }
        public double? Score { get; set; }
    }
}