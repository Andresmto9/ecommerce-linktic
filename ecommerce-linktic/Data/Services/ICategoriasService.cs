using ecommerce_linktic.Models;

namespace ecommerce_linktic.Data.Services
{
	public interface ICategoriasService
	{
		Task<IEnumerable<Categorias>> GetAll();

		Categorias GetById(int id);

		void Add(Categorias categoria);

		Categorias update(int id, Categorias categoria);

		void Delete(int id);
	}
}
