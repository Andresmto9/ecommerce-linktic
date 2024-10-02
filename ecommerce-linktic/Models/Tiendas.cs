using System.ComponentModel.DataAnnotations;

namespace ecommerce_linktic.Models
{
    public class Tiendas
    {
        [Key]
        public int Id { get; set; }

        public string NombreTienda { get; set; }

        public string Direccion { get; set; }

        public string Logo { get; set; }

        public Int16 Estado { get; set; }

        public DateTime FechaCreacion { get; set; }

        public List<ProductosTiendas> ProductosTiendas { get; set; }
    }
}
