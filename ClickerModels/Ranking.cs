namespace ClickerService.Models
{
    public enum RankingType
    {
        AllPlayers,
        ByOffset,
        FromTo
    }

    public partial class Ranking
    {
        public RankingType rankingType { get; set; }
        public string statName { get; set; }
        public int offsetBackward { get; set; }
        public int offsetForward { get; set; }
    }
}