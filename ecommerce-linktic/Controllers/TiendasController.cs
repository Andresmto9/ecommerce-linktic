using ecommerce_linktic.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_linktic.Controllers
{
    public class TiendasController : Controller
    {
        private readonly AppDBContext _context;

        public TiendasController(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var Tiendas = await _context.Tiendas.ToListAsync();
            return View();
        }
    }
}
