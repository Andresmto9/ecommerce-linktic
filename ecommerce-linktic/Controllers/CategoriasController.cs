using ecommerce_linktic.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_linktic.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly AppDBContext _context;

        public CategoriasController(AppDBContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var Categorias = await _context.Categorias.ToListAsync();

            return View();
        }
    }
}
