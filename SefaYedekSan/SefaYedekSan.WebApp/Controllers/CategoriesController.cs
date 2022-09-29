using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SefaYedekSan.WebApp.Data;
using SefaYedekSan.WebApp.Models;

namespace SefaYedekSan.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        private async Task LoadSubs(List<Category> categories)
        {
            foreach (var category in categories)
            {
                category.Categories = await _context.Categories.Include(x=>x.Products).Where(x => x.ParentCategoryId == category.Id).ToListAsync();
                await LoadSubs(category.Categories);
            }
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var data = await _context.Categories.Where(x => x.ParentCategoryId == null).ToListAsync();
            await LoadSubs(data);
            return Ok(data);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var data = await _context.Categories.Include(x=>x.Products).FirstOrDefaultAsync(x=>x.Id==id);    
            return Ok(data);
        }
    }
}
