using ecommerce_linktic.Data;
using System.ComponentModel.DataAnnotations;

namespace ecommerce_linktic.Models
{
    public class Productos
    {
        [Key]
        public int Id { get; set; }
        public string NombreProducto { get; set; }

        public string Descripcion { get; set; }
        public string ImagenProducto { get; set; }

        public int Precio { get; set; }

        public DateTime FechaCreacion { get; set; }

        public List<CategoriasProductos> CategoriasProductos { get; set; }

        public List<ProductosTiendas> ProductosTiendas { get; set; }
    }
}
