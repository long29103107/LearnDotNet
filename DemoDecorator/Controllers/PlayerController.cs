using DemoDecorator.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoDecorator.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerService _playersService;

        public PlayerController(IPlayerService playersService)
        {
            _playersService = playersService;
        }

        public IActionResult Index()
        {
            return View(_playersService.GetPlayersList());
        }
    }
}
