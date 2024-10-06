using ecommerce_linktic.Models;

namespace ecommerce_linktic.Data.Services
{
	public class TiendaProductosService : ITiendaProductosService
	{
		private readonly AppDBContext _context;

        public TiendaProductosService(AppDBContext context)
        {
			_context = context;
		}

        public void Add(ProductosTiendas tienda)
		{
			_context.ProductosTiendas.Add(tienda);
			_context.SaveChanges();
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<ProductosTiendas>> GetAll()
		{
			throw new NotImplementedException();
		}

		public ProductosTiendas GetById(int id)
		{
			throw new NotImplementedException();
		}

		public ProductosTiendas update(int id, ProductosTiendas tienda)
		{
			throw new NotImplementedException();
		}
	}
}
