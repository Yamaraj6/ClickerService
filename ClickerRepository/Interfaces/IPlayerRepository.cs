using ClickerService.Models;

namespace ClickerRepository.Interfaces
{
    public interface IPlayerRepository
    {
        Player GetPlayer(string id);
        Player GetPlayerByFacebookId(string idFacebook);
        void CreatPlayer(Player player);
        void UpdatePlayer(Player player);
        void RemovePlayer(string id);
    }
}