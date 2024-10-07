using Microsoft.EntityFrameworkCore;
using ecommerce_linktic.Models;
using System.Data.Common;

namespace ecommerce_linktic.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<Productos> Productos { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Tiendas> Tiendas { get; set; }
        public DbSet<CategoriasProductos> CategoriasProductos { get; set; }
        public DbSet<ProductosTiendas> ProductosTiendas { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }
        public DbSet<PedidosProductos> PedidosProductos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /** Creación de la entidad para la tabla de productos **/
            modelBuilder.Entity<Productos>(tp =>
            {
                tp.HasKey(col => col.Id);
                tp.Property(col => col.Id)
                    .UseIdentityColumn()
                    .ValueGeneratedOnAdd()
                    .IsRequired();

                tp.Property(col => col.NombreProducto).HasMaxLength(200);
                tp.Property(col => col.Descripcion).HasMaxLength(500);
                tp.Property(col => col.ImagenProducto).HasMaxLength(500);
                tp.Property(col => col.Precio);
                tp.Property(col => col.FechaCreacion);
            });

			modelBuilder.Entity<Productos>().ToTable("producto");
			/***********************************************************/

			/** Creación de la entidad para la tabla de categorias **/
			modelBuilder.Entity<Categorias>(tc =>
            {
                tc.HasKey(col => col.Id);
                tc.Property(col => col.Id)
                    .UseIdentityColumn()
                    .ValueGeneratedOnAdd()
                    .IsRequired();

                tc.Property(col => col.NombreCategoria).HasMaxLength(50);
            });

            modelBuilder.Entity<Categorias>().ToTable("categoria");
            /***********************************************************/

            /** Creación de la entidad para la tabla de tiendas **/
            modelBuilder.Entity<Tiendas>(tt =>
            {
                tt.HasKey(col => col.Id);
                tt.Property(col => col.Id)
                    .UseIdentityColumn()
                    .ValueGeneratedOnAdd()
                    .IsRequired();

                tt.Property(col => col.NombreTienda).HasMaxLength(100);
                tt.Property(col => col.Direccion).HasMaxLength(200);
                tt.Property(col => col.Logo).HasMaxLength(500);
                tt.Property(col => col.Estado);
                tt.Property(col => col.FechaCreacion);
            });

            modelBuilder.Entity<Tiendas>().ToTable("tienda");
            /***********************************************************/

            /** Creación de la entidad para la tabla de relacion entre categorias y productos **/

            modelBuilder.Entity<CategoriasProductos>().HasOne(c => c.Categorias).WithMany(cp => cp.CategoriasProductos).HasForeignKey(c => c.CategoriasId);

            modelBuilder.Entity<CategoriasProductos>().HasOne(p => p.Productos).WithMany(cp => cp.CategoriasProductos).HasForeignKey(p => p.ProductosId);

            modelBuilder.Entity<CategoriasProductos>().ToTable("categoria_producto");
            /***********************************************************/

            /** Creación de la entidad para la tabla de relacion entre tiendas y productos **/

            modelBuilder.Entity<ProductosTiendas>().HasOne(t => t.Tiendas).WithMany(pt => pt.ProductosTiendas).HasForeignKey(t => t.TiendasId);

            modelBuilder.Entity<ProductosTiendas>().HasOne(p => p.Productos).WithMany(pt => pt.ProductosTiendas).HasForeignKey(p => p.ProductosId);

            modelBuilder.Entity<ProductosTiendas>().ToTable("tienda_producto");
            /***********************************************************/

            /** Creación de la entidad para la tabla de usuarios **/
            modelBuilder.Entity<Usuarios>(u =>
            {
                u.HasKey(col => col.Id);
                u.Property(col => col.Id)
                    .UseIdentityColumn()
                    .ValueGeneratedOnAdd()
                    .IsRequired();

                u.Property(col => col.NombreUsuario).HasMaxLength(200);
                u.Property(col => col.CorreoUsuario).HasMaxLength(500);
                u.Property(col => col.PasswordUsuario).HasMaxLength(600);
            });

            modelBuilder.Entity<Usuarios>().ToTable("usuario");
            /***********************************************************/

            /** Creación de la entidad para la tabla de pedidos **/
            modelBuilder.Entity<Pedidos>(p =>
            {
                p.HasKey(col => col.Id);
                p.Property(col => col.Id)
                    .UseIdentityColumn()
                    .ValueGeneratedOnAdd()
                    .IsRequired();

                p.Property(col => col.TotalPrecioPedido);
                p.Property(col => col.FechaCreacion);
                p.Property(col => col.Estado);
            });

            modelBuilder.Entity<Pedidos>().HasOne(u => u.Usuarios).WithMany(p => p.Pedidos).HasForeignKey(p => p.UsuarioId);

            modelBuilder.Entity<Pedidos>().ToTable("pedido");
            /***********************************************************/

            /** Creación de la entidad para la tabla de relacion entre categorias y productos **/

            modelBuilder.Entity<PedidosProductos>().HasOne(p => p.Productos).WithMany(pp => pp.PedidosProductos).HasForeignKey(p => p.ProductosId);

            modelBuilder.Entity<PedidosProductos>().HasOne(p => p.Pedidos).WithMany(pp => pp.PedidosProductos).HasForeignKey(c => c.PedidosId);

            modelBuilder.Entity<PedidosProductos>().ToTable("pedido_producto");
            /***********************************************************/
        }
    }
}
