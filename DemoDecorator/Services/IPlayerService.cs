using DemoDecorator.Models;

namespace DemoDecorator.Services
{
    public interface IPlayerService
    {
        IEnumerable<Player> GetPlayersList();
    }
}
