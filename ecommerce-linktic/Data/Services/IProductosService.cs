using ecommerce_linktic.Models;

namespace ecommerce_linktic.Data.Services
{
    public interface IProductosService
    {
        Task<IEnumerable<Productos>> GetAll();

        Task<Productos> GetById(int id);

        int Add(Productos producto);

        Task<Productos> updateAsync(int id, Productos nuevoProducto);

        Task DeleteAsync(int id);
    }
}
