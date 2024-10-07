using System.ComponentModel.DataAnnotations;

namespace ecommerce_linktic.Models
{
    public class Usuarios
    {
        [Key]

        public int Id { get; set; }
        public string NombreUsuario { get; set; }

        public string CorreoUsuario { get; set; }

        public string PasswordUsuario { get; set; }

        public List<Pedidos> Pedidos { get; set; }
    }
}
