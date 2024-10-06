using ecommerce_linktic.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_linktic.Data.Services
{
	public class TiendasService : ITiendasService
	{
		private readonly AppDBContext _context;

        public TiendasService(AppDBContext context)
        {
			_context = context;
        }

        public void Add(Tiendas tienda)
		{
			throw new NotImplementedException();
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Tiendas>> GetAll()
		{
			var tiendas = await _context.Tiendas.ToListAsync();

			return tiendas;
		}

		public Tiendas GetById(int id)
		{
			throw new NotImplementedException();
		}

		public Tiendas update(int id, Tiendas tienda)
		{
			throw new NotImplementedException();
		}
	}
}
