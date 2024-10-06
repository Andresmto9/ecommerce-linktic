using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce_linktic.Models
{
    public class Pedidos
    {
        [Key]

        public int Id { get; set; }
        public int TotalPrecioPedido { get; set; }
        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public Usuarios Usuarios { get; set; }
        public DateTime FechaCreacion { get; set; }
        public List<PedidosProductos> PedidosProductos { get; set; }
    }
}
