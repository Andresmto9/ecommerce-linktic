using System.ComponentModel.DataAnnotations;

namespace ecommerce_linktic.Models
{
    public class Categorias
    {
        [Key]

        public int Id { get; set; }

        public string NombreCategoria { get; set; }

        public List<CategoriasProductos> CategoriasProductos { get; set; }
    }
}
