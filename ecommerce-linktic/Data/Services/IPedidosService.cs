using ecommerce_linktic.Models;

namespace ecommerce_linktic.Data.Services
{
    public interface IPedidosService
    {
        Task<IEnumerable<Pedidos>> GetAll();

        Task<Pedidos> GetById(int id);

        int Add(Pedidos pedidos);

        Task<Pedidos> updateAsync(int id, int estado, Pedidos pedido);

        void Delete(int id);
    }
}
