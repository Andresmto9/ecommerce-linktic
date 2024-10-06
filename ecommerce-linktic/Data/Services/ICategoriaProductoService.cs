using ecommerce_linktic.Models;

namespace ecommerce_linktic.Data.Services
{
	public interface ICategoriaProductoService
	{
		Task<IEnumerable<CategoriasProductos>> GetAll();

		CategoriasProductos GetById(int id);

		void Add(CategoriasProductos categoria);

		CategoriasProductos update(int id, CategoriasProductos categoria);

		void Delete(int id);
	}
}
