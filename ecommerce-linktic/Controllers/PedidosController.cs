using ecommerce_linktic.Data.Services;
using ecommerce_linktic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;

namespace ecommerce_linktic.Controllers
{
    public class PedidosController : Controller
    {
        private readonly IPedidosService _servicePedidos;
        private readonly IPedidosProductosService _servicePedidosProductos;

        public PedidosController(IPedidosService servicePedidos, IPedidosProductosService servicePedidosProductos)
        {
            _servicePedidos = servicePedidos;
            _servicePedidosProductos = servicePedidosProductos;
        }

        public IActionResult Index()
        {
            return View();
        }
         /** Funcionalidad para registrar el pedido asociado al carrito de compras **/
        [HttpPost]

        public IActionResult SetCompraPedido([FromBody]int[] pedido, int total)
        {
            var arrResult = new object();

            try
            {
                var pedi = new Pedidos
                {
                    TotalPrecioPedido = total,
                    UsuarioId = 1,
                    FechaCreacion = (DateTime.Now)
                };

                var pediID = _servicePedidos.Add(pedi);

                foreach (int p in pedido)
                {

                    var cateProd = new PedidosProductos
                    {
                        ProductosId = p,
                        PedidosId = pediID
                    };
                    _servicePedidosProductos.Add(cateProd);
                }

                arrResult = new { estado = "OK", mensaje = "Se registro con éxito el pedido." };

                return Json(arrResult);
            }
            catch (Exception e)
            {
                arrResult = new { estado = "FAIL", mensaje = "Ocurrió un problema al registrar el pedido." };

                return Json(arrResult);
            }
        }
        /***************************************************************************************************/

        /** Funcionalidad para consultar todos los pedidos registrados en el sistema **/
        [HttpGet]
        public async Task<JsonResult> GetPedidos()
        {
            var arrResult = new object();

            try
            {
                var pedidos = await _servicePedidos.GetAll();

                arrResult = new { estado = "OK", pedidos = pedidos };

                return Json(arrResult);
            }
            catch (Exception e)
            {
                arrResult = new { estado = "FAIL", mensaje = e };

                return Json(arrResult);
            }
        }
        /***************************************************************************************************/

        /** Funcionadlidad para actualizar el estado del pedido si es aprobado o rechazado **/
        [HttpPost]

        public async Task<JsonResult> UpdatePedido(int id, int estado)
        {
            var arrResult = new object();

            try
            {
                var pedido = await _servicePedidos.GetById(id);

                if (pedido != null)
                {
                    await _servicePedidos.updateAsync(id, estado, pedido);
                }

                arrResult = new { estado = "OK", mensaje = "Se actualizo el estado del pedido con éxito." };
            }
            catch (Exception e)
            {
                arrResult = new { estado = "FAIL", mensaje = "Ocurrió un problema al actualizar el estado del pedido." };
            }

            return Json(arrResult);
        }
        /***************************************************************************************************/
    }
}
