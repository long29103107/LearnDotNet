using DemoDecorator.Models;
using System.Diagnostics;

namespace DemoDecorator.Services
{
    public class PlayerServiceLoggingDecorator : IPlayerService
    {
        private readonly IPlayerService _playerService;
        private readonly ILogger<PlayerServiceLoggingDecorator> _logger;

        public PlayerServiceLoggingDecorator(IPlayerService playersService,
            ILogger<PlayerServiceLoggingDecorator> logger)
        {
            _playerService = playersService;
            _logger = logger;
        }

        public IEnumerable<Player> GetPlayersList()
        {
            _logger.LogInformation("Starting to fetch data");

            var stopwatch = Stopwatch.StartNew();

            IEnumerable<Player> players = _playerService.GetPlayersList();

            foreach (var player in players)
            {
                _logger.LogInformation("Player: " + player.Id + ", Name: " + player.Name);
            }

            stopwatch.Stop();

            var elapsedTime = stopwatch.ElapsedMilliseconds;

            _logger.LogInformation($"Finished fetching data in {elapsedTime} milliseconds");

            return players;
        }
    }
}
