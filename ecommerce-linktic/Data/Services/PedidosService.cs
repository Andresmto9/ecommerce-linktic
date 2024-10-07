using ecommerce_linktic.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_linktic.Data.Services
{
    public class PedidosService : IPedidosService
    {
        private readonly AppDBContext _context;

        public PedidosService(AppDBContext context)
        {
            _context = context;
        }

        public int Add(Pedidos pedidos)
        {
            _context.Pedidos.Add(pedidos);
            _context.SaveChanges();

            return pedidos.Id;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<Pedidos>> GetAll()
        {
            var pedidos = await _context.Pedidos.ToListAsync();

            return pedidos;
        }

        public async Task<Pedidos> GetById(int id)
        {
            var pedidos = await _context.Pedidos.FindAsync(id);
            return pedidos;
        }

        public async Task<Pedidos> updateAsync(int id, int estado, Pedidos pedidos)
        {

            var pedidoExistente = await _context.Pedidos.FindAsync(id);

            if (pedidoExistente == null)
            {
                throw new Exception("Producto no encontrado");
            }

            pedidoExistente.Estado = estado;

            await _context.SaveChangesAsync();

            return pedidoExistente;
        }
    }
}
