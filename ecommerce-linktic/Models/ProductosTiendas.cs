﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce_linktic.Models
{
    public class ProductosTiendas
    {
        [Key]

        public int Id { get; set; }

        // public List<Productos> ProductoId { get; set; }

        // public List<Tiendas> TiendaId { get; set; }

        public int ProductosId { get; set; }
        [ForeignKey("ProductosId")]

        public Productos Productos { get; set; }

        public int TiendasId { get; set; }
        [ForeignKey("TiendasId")]

        public Tiendas Tiendas { get; set; }
    }
}
