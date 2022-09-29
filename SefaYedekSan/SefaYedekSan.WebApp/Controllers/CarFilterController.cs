using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SefaYedekSan.WebApp.Data;

using System.Threading.Tasks;

namespace SefaYedekSan.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFilterController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CarFilterController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _context.CarTypes
                .Include(x => x.Brands)
                .ThenInclude(x => x.Models)
                .ToListAsync();
            return Ok(data);
        }
    }
}
