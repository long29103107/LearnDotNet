using DemoMapster.DB;
using DemoMapster.Dtos;
using DemoMapster.Entities;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoMapster.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductDto dto)
        {
            Product product = dto.ToEntity();

            _context.Add(product);

            await _context.SaveChangesAsync();

            return Ok(product);
        }


        [HttpGet]
        public async Task<IActionResult> Get(int productId)
        {
            ProductDto productDto = await _context
                .Products
                .Where(p => p.Id == productId)
                .ProjectToType<ProductDto>()
                .FirstOrDefaultAsync();

            return Ok(productDto);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _context
                .Products
                .ProjectToType<ProductDto>()
                .ToListAsync();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Products(int userFavoriteColorId)
        {
            var result = await _context
                .Products
                .ProjectToType<ProductDto>(ProductDto.GetMapsterConfig(userFavoriteColorId))
                .ToListAsync();

            return Ok(result);
        }
    }
}
