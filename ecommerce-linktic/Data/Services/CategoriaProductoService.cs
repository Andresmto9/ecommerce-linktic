using ecommerce_linktic.Models;

namespace ecommerce_linktic.Data.Services
{
	public class CategoriaProductoService : ICategoriaProductoService
	{
		private readonly AppDBContext _context;

        public CategoriaProductoService(AppDBContext context)
        {
			_context = context;
		}
        public void Add(CategoriasProductos categoria)
		{
			_context.CategoriasProductos.Add(categoria);
			_context.SaveChanges();
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<CategoriasProductos>> GetAll()
		{
			throw new NotImplementedException();
		}

		public CategoriasProductos GetById(int id)
		{
			throw new NotImplementedException();
		}

		public CategoriasProductos update(int id, CategoriasProductos categoria)
		{
			throw new NotImplementedException();
		}
	}
}
