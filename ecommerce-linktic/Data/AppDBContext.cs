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
            modelBuilder.Entity<CategoriasProductos>().HasKey(cp => new
            { 
                cp.CategoriasId,
                cp.ProductosId
            });

            modelBuilder.Entity<CategoriasProductos>().HasOne(c => c.Categorias).WithMany(cp => cp.CategoriasProductos).HasForeignKey(c => c.CategoriasId);

            modelBuilder.Entity<CategoriasProductos>().HasOne(p => p.Productos).WithMany(cp => cp.CategoriasProductos).HasForeignKey(p => p.ProductosId);

            modelBuilder.Entity<CategoriasProductos>().ToTable("categoria_producto");
            /***********************************************************/

            /** Creación de la entidad para la tabla de relacion entre tiendas y productos **/
            modelBuilder.Entity<ProductosTiendas>().HasKey(pt => new
            {
                pt.TiendasId,
                pt.ProductosId
            });

            modelBuilder.Entity<ProductosTiendas>().HasOne(t => t.Tiendas).WithMany(pt => pt.ProductosTiendas).HasForeignKey(t => t.TiendasId);

            modelBuilder.Entity<ProductosTiendas>().HasOne(p => p.Productos).WithMany(pt => pt.ProductosTiendas).HasForeignKey(p => p.ProductosId);

            modelBuilder.Entity<ProductosTiendas>().ToTable("tienda_producto");
            /***********************************************************/
        }
    }
}
