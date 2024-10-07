using ecommerce_linktic.Models;

namespace ecommerce_linktic.Data.Services
{
    public class PedidosProductosService : IPedidosProductosService
    {
        private readonly AppDBContext _context;

        public PedidosProductosService(AppDBContext context)
        {
            _context = context;
        }

        public void Add(PedidosProductos pedidosProductos)
        {
            _context.PedidosProductos.Add(pedidosProductos);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PedidosProductos>> GetAll()
        {
            throw new NotImplementedException();
        }

        public PedidosProductos GetById(int id)
        {
            throw new NotImplementedException();
        }

        public PedidosProductos update(int id, PedidosProductos pedidosProductos)
        {
            throw new NotImplementedException();
        }
    }
}
