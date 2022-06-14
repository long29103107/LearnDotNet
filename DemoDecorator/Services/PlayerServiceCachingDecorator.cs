using DemoDecorator.Models;
using Microsoft.Extensions.Caching.Memory;

namespace DemoDecorator.Services
{
    public class PlayerServiceCachingDecorator : IPlayerService
    {
        private readonly IPlayerService _playerService;
        private readonly IMemoryCache _memoryCache;

        private const string GET_PLAYERS_LIST_CACHE_KEY = "players.list";

        public PlayerServiceCachingDecorator(IPlayerService playersService, IMemoryCache memoryCache)
        {
            _playerService = playersService;
            _memoryCache = memoryCache;
        }

        public IEnumerable<Player> GetPlayersList()
        {
            IEnumerable<Player> players = null;

            // Look for the cache key.
            if (!_memoryCache.TryGetValue(GET_PLAYERS_LIST_CACHE_KEY, out players))
            {
                // Cache key is not in cache, so fetch players list.
                players = _playerService.GetPlayersList();

                // Set cache options
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep the players in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromMinutes(1));


                // Save players list in cache.
                _memoryCache.Set(GET_PLAYERS_LIST_CACHE_KEY, players, cacheEntryOptions);
            }

            return players;
        }
    }
}
