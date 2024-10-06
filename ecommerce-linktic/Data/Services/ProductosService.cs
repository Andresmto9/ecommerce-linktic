using ecommerce_linktic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace ecommerce_linktic.Data.Services
{
    public class ProductosService : IProductosService
    {
        private readonly AppDBContext _context;

        public ProductosService(AppDBContext context)
        {
            _context = context;
        }

		public int Add(Productos producto)
		{
			_context.Productos.Add(producto);
			_context.SaveChanges();

			return producto.Id; 
		}


		public async Task DeleteAsync(int id)
        {
			var prod = await _context.Productos.FirstOrDefaultAsync(n => n.Id == id);
			_context.Productos.Remove(prod);
			await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Productos>> GetAll()
        {
            var productos = await _context.Productos.ToListAsync();

            return productos;
        }

        public async Task<Productos> GetById(int id)
        {
			var producto = await _context.Productos.FindAsync(id);
            return producto;
		}

        public async Task<Productos> updateAsync(int id, Productos producto)
        {
            //_context.Update(nuevoProducto);
            //await _context.SaveChangesAsync();
            //return nuevoProducto;

			var productoExistente = await _context.Productos.FindAsync(id);

			if (productoExistente == null)
			{
				throw new Exception("Producto no encontrado");
			}

			productoExistente.NombreProducto = producto.NombreProducto;
			productoExistente.Precio = producto.Precio;
			productoExistente.Descripcion = producto.Descripcion;
			productoExistente.ImagenProducto = producto.ImagenProducto;

			await _context.SaveChangesAsync();

			return productoExistente;
		}
    }
}
