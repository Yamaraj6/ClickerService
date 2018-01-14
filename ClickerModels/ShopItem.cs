namespace ClickerService.Models
{
    public partial class ShopItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public string Bonus { get; set; }
        public double Value { get; set; }
        public bool? IsPremium { get; set; }
    }
}
