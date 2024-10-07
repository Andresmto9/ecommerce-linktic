using ecommerce_linktic.Models;

namespace ecommerce_linktic.Data.Services
{
    public interface IPedidosProductosService
    {
        Task<IEnumerable<PedidosProductos>> GetAll();

        PedidosProductos GetById(int id);

        void Add(PedidosProductos pedidosProductos);

        PedidosProductos update(int id, PedidosProductos pedidosProductos);

        void Delete(int id);
    }
}
