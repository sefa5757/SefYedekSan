using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SefaYedekSan.WebApp.Areas.Admin.Controllers;
using SefaYedekSan.WebApp.Data;

using System.Threading.Tasks;

namespace SefaYedekSan.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HistoriesController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _context.Histories.Include(x => x.Brand).ToListAsync();
            return Ok(data);
        }
    }
}
