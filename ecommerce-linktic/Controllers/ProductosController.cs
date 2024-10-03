using ecommerce_linktic.Data;
using ecommerce_linktic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_linktic.Controllers
{
    public class ProductosController : Controller
    {
        private readonly AppDBContext _context;

        public ProductosController(AppDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Productos.ToList();
            return View();
        }

        /** Funcionalidad para ocnsultar la información de los productos creados dentro de los sistemas **/
        [HttpGet]
        public JsonResult GetDataProductos()
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
                        FechaCreacion = pc.Producto.FechaCreacion,
                        CategoriaId = c.Id,
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
    }
}
