using ecommerce_linktic.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_linktic.Data.Services
{
	public class CategoriasService : ICategoriasService
	{
		private readonly AppDBContext _context;

        public CategoriasService(AppDBContext context)
        {
            _context = context;
        }

        public void Add(Categorias categoria)
		{
			throw new NotImplementedException();
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Categorias>> GetAll()
		{
			var categorias = await _context.Categorias.ToListAsync();

			return categorias;
		}

		public Categorias GetById(int id)
		{
			throw new NotImplementedException();
		}

		public Categorias update(int id, Categorias categoria)
		{
			throw new NotImplementedException();
		}
	}
}
