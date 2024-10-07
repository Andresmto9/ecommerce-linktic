using ecommerce_linktic.Data;
using ecommerce_linktic.Data.Services;
using ecommerce_linktic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_linktic.Controllers
{
    public class ProductosController : Controller
    {
		/** Llamado de los servicios para realizar la creación, consulta, acutlización y borrado
		 * de los diferentes esquemas creado para el sistema
		**/
        private readonly IProductosService _serviceProducto;
		private readonly ICategoriasService _servicecCategoria;
		private readonly ITiendasService _servicecTienda;
		private readonly ICategoriaProductoService _serviceCateProd;
		private readonly ITiendaProductosService _serviceTienProd;
        /***************************************************************************************************/

		/** Contructor para utualizar los servicios creados en el sistema **/
        public ProductosController(IProductosService serviceProducto, ICategoriasService servicecCategoria, ITiendasService servicecTienda, ICategoriaProductoService serviceCateProd, ITiendaProductosService serviceTienProd)
        {
			_serviceProducto = serviceProducto;
			_servicecCategoria = servicecCategoria;
			_servicecTienda = servicecTienda;
			_serviceCateProd = serviceCateProd;
			_serviceTienProd = serviceTienProd;
		}
        /***************************************************************************************************/

        public IActionResult Index()
        {
            return View();
        }

        /** Funcionalidad para ocnsultar la información de los productos creados dentro de los sistemas **/
        [HttpGet]
        public async Task<JsonResult> GetDataProductos()
        {
            var arrResult = new object();

            try
            {
                var productos = await _serviceProducto.GetAll();
				var categorias = await _servicecCategoria.GetAll();
                var tiendas = await _servicecTienda.GetAll();

				arrResult = new { estado = "OK", producto = productos, categoria = categorias, tienda = tiendas};

                return Json(arrResult);
            }
            catch (Exception e)
            {
                arrResult = new { estado = "FAIL", mensaje = e };

                return Json(arrResult);
            }
        }

		// [HttpPost]

		//      public async Task<JsonResult> CreateProductos([FromBody] Productos producto, int categoria, int tienda)
		//{
		//	if (producto == null)
		//	{
		//		return Json(new { success = false, message = "Producto no puede ser nulo" });
		//	}

		//	var prod = _serviceProducto.Add(producto);

		//	var arrResult = new object();

		//	arrResult = new { estado = "FAIL", data = Json(producto.value), cosa = categoria, nueva = tienda };

		//	return Json(arrResult);
		//}

		public class ProductoDto
		{
			public string Nombre { get; set; }
		}

		/** Funcionalidad para registrar un nuevo producto dentro del sistema **/

		[HttpPost]
		public async Task<JsonResult> CreateProductos([FromBody]Productos producto, int categoria, int tienda)
		{
			var arrResult = new object();

			try
			{
				producto.FechaCreacion = (DateTime.Now);
				int nuevoId = _serviceProducto.Add(producto);

				var cateProd = new CategoriasProductos { CategoriasId = categoria, ProductosId = nuevoId };
				_serviceCateProd.Add(cateProd);

				var tienProd = new ProductosTiendas { TiendasId = tienda, ProductosId = nuevoId };
				_serviceTienProd.Add(tienProd);

				arrResult = new { estado = "OK", mensaje = "Se registró el producto con éxito."};
			}
			catch (Exception e)
			{
				arrResult = new { estado = "FAIL", mensaje = "Ocurrió un problema al registrar el producto." };
			}

			return Json(arrResult);
		}
        /***************************************************************************************************/

		/** Funcionalidad para actualizar un producto seleccionado **/

        [HttpPost]
		public async Task<JsonResult> UpdateProductos([FromBody]Productos nuevoProducto, int id)
		{
			var arrResult = new object();

			try
			{
				var prod = await _serviceProducto.GetById(id);

				if (prod != null)
				{
					await _serviceProducto.updateAsync(id, nuevoProducto);
				}

				arrResult = new { estado = "OK", mensaje = "Se actualizo el producto con éxito."};
			}
			catch (Exception e)
			{
				arrResult = new { estado = "FAIL", mensaje = "Ocurrió un problema al registrar el producto." };
			}

			return Json(arrResult);
		}
        /***************************************************************************************************/

		/** Funcionalidad para borrar un producto seleecionado **/
        public async Task<JsonResult> DeleteProductos(int id)
		{
			var arrResult = new object();

			try
			{
				await _serviceProducto.DeleteAsync(id);

				arrResult = new { estado = "OK", mensaje = "El producto fue borrado con éxito." };
			}
			catch (Exception e)
			{
				arrResult = new { estado = "FAIL", mensaje = "Ocurrió un problema al borrar el producto." };
			}

			return Json(arrResult);
		}
        /***************************************************************************************************/
    }
}
