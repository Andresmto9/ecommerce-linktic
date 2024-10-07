using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ecommerce_linktic.Migrations
{
    /// <inheritdoc />
    public partial class CreacionProductos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCategoria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "producto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreProducto = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ImagenProducto = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_producto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tienda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTienda = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tienda", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CorreoUsuario = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PasswordUsuario = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "categoria_producto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriasId = table.Column<int>(type: "int", nullable: false),
                    ProductosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria_producto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_categoria_producto_categoria_CategoriasId",
                        column: x => x.CategoriasId,
                        principalTable: "categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_categoria_producto_producto_ProductosId",
                        column: x => x.ProductosId,
                        principalTable: "producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tienda_producto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductosId = table.Column<int>(type: "int", nullable: false),
                    TiendasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tienda_producto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tienda_producto_producto_ProductosId",
                        column: x => x.ProductosId,
                        principalTable: "producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tienda_producto_tienda_TiendasId",
                        column: x => x.TiendasId,
                        principalTable: "tienda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPrecioPedido = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pedido_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pedido_producto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductosId = table.Column<int>(type: "int", nullable: false),
                    PedidosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedido_producto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pedido_producto_pedido_PedidosId",
                        column: x => x.PedidosId,
                        principalTable: "pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pedido_producto_producto_ProductosId",
                        column: x => x.ProductosId,
                        principalTable: "producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_categoria_producto_CategoriasId",
                table: "categoria_producto",
                column: "CategoriasId");

            migrationBuilder.CreateIndex(
                name: "IX_categoria_producto_ProductosId",
                table: "categoria_producto",
                column: "ProductosId");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_UsuarioId",
                table: "pedido",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_producto_PedidosId",
                table: "pedido_producto",
                column: "PedidosId");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_producto_ProductosId",
                table: "pedido_producto",
                column: "ProductosId");

            migrationBuilder.CreateIndex(
                name: "IX_tienda_producto_ProductosId",
                table: "tienda_producto",
                column: "ProductosId");

            migrationBuilder.CreateIndex(
                name: "IX_tienda_producto_TiendasId",
                table: "tienda_producto",
                column: "TiendasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categoria_producto");

            migrationBuilder.DropTable(
                name: "pedido_producto");

            migrationBuilder.DropTable(
                name: "tienda_producto");

            migrationBuilder.DropTable(
                name: "categoria");

            migrationBuilder.DropTable(
                name: "pedido");

            migrationBuilder.DropTable(
                name: "producto");

            migrationBuilder.DropTable(
                name: "tienda");

            migrationBuilder.DropTable(
                name: "usuario");
        }
    }
}
