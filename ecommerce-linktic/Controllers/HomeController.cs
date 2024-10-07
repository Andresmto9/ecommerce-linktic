using ecommerce_linktic.Data;
using ecommerce_linktic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ecommerce_linktic.Controllers
{
    public class HomeController : Controller
    {
        // private readonly ILogger<HomeController> _logger;

        /*
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        */

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private readonly AppDBContext _context;

        public HomeController(AppDBContext context)
        {
            _context = context;
        }

        /** Funcionalidad para consultar los procutos existentes dentro del sistema y su categoría asociada **/
        [HttpGet]
        public JsonResult GetProdcutosVenta()
        {
            var productos = _context.Productos
                .Join(
                    _context.CategoriasProductos,
                    p => p.Id,
                    cp => cp.ProductosId,
                    (p, cp) => new { Producto = p, CategoriaProducto = cp }
                )
                .Join(
                    _context.Categorias,
                    pc => pc.CategoriaProducto.CategoriasId,
                    c => c.Id,
                    (pc, c) => new {
                        ProductoId = pc.Producto.Id,
                        ProductoNombre = pc.Producto.NombreProducto,
                        Descripcion = pc.Producto.Descripcion,
                        ImagenProducto = pc.Producto.ImagenProducto,
                        Precio = pc.Producto.Precio,
                        CategoriaNombre = c.NombreCategoria
                    }
                )
                .ToList();

            var arrResult = new object();

            if (productos.Count > 0)
            {
                arrResult = new { estado = "OK", data = productos };
            }
            else
            {
                arrResult = new { estado = "FAIL", data = new { } };
            }

            return Json(arrResult);
        }
        /***************************************************************************************************/
    }
}
