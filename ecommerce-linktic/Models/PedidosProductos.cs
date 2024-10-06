using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce_linktic.Models
{
    public class PedidosProductos
    {
        [Key]

        public int Id { get; set; }
        public int ProductosId { get; set; }
        [ForeignKey("ProductosId")]

        public Productos Productos { get; set; }
        public int PedidosId { get; set; }
        [ForeignKey("PedidosId")]

        public Pedidos Pedidos { get; set; }
    }
}
