using ecommerce_linktic.Models;

namespace ecommerce_linktic.Data.Services
{
	public interface ITiendaProductosService
	{
		Task<IEnumerable<ProductosTiendas>> GetAll();

		ProductosTiendas GetById(int id);

		void Add(ProductosTiendas tienda);

		ProductosTiendas update(int id, ProductosTiendas tienda);

		void Delete(int id);
	}
}
