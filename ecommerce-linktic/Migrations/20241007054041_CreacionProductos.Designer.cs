﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ecommerce_linktic.Data;

#nullable disable

namespace ecommerce_linktic.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20241007054041_CreacionProductos")]
    partial class CreacionProductos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ecommerce_linktic.Models.Categorias", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NombreCategoria")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("categoria", (string)null);
                });

            modelBuilder.Entity("ecommerce_linktic.Models.CategoriasProductos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoriasId")
                        .HasColumnType("int");

                    b.Property<int>("ProductosId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoriasId");

                    b.HasIndex("ProductosId");

                    b.ToTable("categoria_producto", (string)null);
                });

            modelBuilder.Entity("ecommerce_linktic.Models.Pedidos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("TotalPrecioPedido")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("pedido", (string)null);
                });

            modelBuilder.Entity("ecommerce_linktic.Models.PedidosProductos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PedidosId")
                        .HasColumnType("int");

                    b.Property<int>("ProductosId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PedidosId");

                    b.HasIndex("ProductosId");

                    b.ToTable("pedido_producto", (string)null);
                });

            modelBuilder.Entity("ecommerce_linktic.Models.Productos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagenProducto")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("NombreProducto")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Precio")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("producto", (string)null);
                });

            modelBuilder.Entity("ecommerce_linktic.Models.ProductosTiendas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductosId")
                        .HasColumnType("int");

                    b.Property<int>("TiendasId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductosId");

                    b.HasIndex("TiendasId");

                    b.ToTable("tienda_producto", (string)null);
                });

            modelBuilder.Entity("ecommerce_linktic.Models.Tiendas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("NombreTienda")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("tienda", (string)null);
                });

            modelBuilder.Entity("ecommerce_linktic.Models.Usuarios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CorreoUsuario")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("PasswordUsuario")
                        .IsRequired()
                        .HasMaxLength(600)
                        .HasColumnType("nvarchar(600)");

                    b.HasKey("Id");

                    b.ToTable("usuario", (string)null);
                });

            modelBuilder.Entity("ecommerce_linktic.Models.CategoriasProductos", b =>
                {
                    b.HasOne("ecommerce_linktic.Models.Categorias", "Categorias")
                        .WithMany("CategoriasProductos")
                        .HasForeignKey("CategoriasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ecommerce_linktic.Models.Productos", "Productos")
                        .WithMany("CategoriasProductos")
                        .HasForeignKey("ProductosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorias");

                    b.Navigation("Productos");
                });

            modelBuilder.Entity("ecommerce_linktic.Models.Pedidos", b =>
                {
                    b.HasOne("ecommerce_linktic.Models.Usuarios", "Usuarios")
                        .WithMany("Pedidos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("ecommerce_linktic.Models.PedidosProductos", b =>
                {
                    b.HasOne("ecommerce_linktic.Models.Pedidos", "Pedidos")
                        .WithMany("PedidosProductos")
                        .HasForeignKey("PedidosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ecommerce_linktic.Models.Productos", "Productos")
                        .WithMany("PedidosProductos")
                        .HasForeignKey("ProductosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedidos");

                    b.Navigation("Productos");
                });

            modelBuilder.Entity("ecommerce_linktic.Models.ProductosTiendas", b =>
                {
                    b.HasOne("ecommerce_linktic.Models.Productos", "Productos")
                        .WithMany("ProductosTiendas")
                        .HasForeignKey("ProductosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ecommerce_linktic.Models.Tiendas", "Tiendas")
                        .WithMany("ProductosTiendas")
                        .HasForeignKey("TiendasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Productos");

                    b.Navigation("Tiendas");
                });

            modelBuilder.Entity("ecommerce_linktic.Models.Categorias", b =>
                {
                    b.Navigation("CategoriasProductos");
                });

            modelBuilder.Entity("ecommerce_linktic.Models.Pedidos", b =>
                {
                    b.Navigation("PedidosProductos");
                });

            modelBuilder.Entity("ecommerce_linktic.Models.Productos", b =>
                {
                    b.Navigation("CategoriasProductos");

                    b.Navigation("PedidosProductos");

                    b.Navigation("ProductosTiendas");
                });

            modelBuilder.Entity("ecommerce_linktic.Models.Tiendas", b =>
                {
                    b.Navigation("ProductosTiendas");
                });

            modelBuilder.Entity("ecommerce_linktic.Models.Usuarios", b =>
                {
                    b.Navigation("Pedidos");
                });
#pragma warning restore 612, 618
        }
    }
}
