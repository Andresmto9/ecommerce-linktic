using ecommerce_linktic.Models;

namespace ecommerce_linktic.Data.Services
{
	public interface ITiendasService
	{
		Task<IEnumerable<Tiendas>> GetAll();

		Tiendas GetById(int id);

		void Add(Tiendas tienda);

		Tiendas update(int id, Tiendas tienda);

		void Delete(int id);
	}
}
