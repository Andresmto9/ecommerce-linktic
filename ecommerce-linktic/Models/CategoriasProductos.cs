using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce_linktic.Models
{
    public class CategoriasProductos
    {
        [Key]

        public int Id { get; set; }

        // Relaciones

        // public List<Categorias> Categorias { get; set; }

        // public List<Productos> Productos { get; set; }

        public int CategoriasId { get; set; }
        [ForeignKey("CategoriasId")]

        public Categorias Categorias { get; set; }

        public int ProductosId { get; set; }
        [ForeignKey("ProductosId")]

        public Productos Productos { get; set; }
    }
}
