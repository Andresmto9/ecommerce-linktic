using ecommerce_linktic.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.Intrinsics.Arm;

namespace ecommerce_linktic.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var contexto = serviceScope.ServiceProvider.GetService<AppDBContext>();

                contexto.Database.EnsureCreated();

                //Categorias
                if (!contexto.Categorias.Any())
                    contexto.Categorias.AddRange(new List<Categorias>(){ 
                        new Categorias()
                        {
                            NombreCategoria = "Teclado"
                        },
                        new Categorias()
                        {
                            NombreCategoria = "Raton"
                        },
                        new Categorias()
                        {
                            NombreCategoria = "Pantalla"
                        },
                        new Categorias()
                        {
                            NombreCategoria = "Ram"
                        },
                        new Categorias()
                        {
                            NombreCategoria = "Tarjeta gráfica"
                        },
                        new Categorias()
                        {
                            NombreCategoria = "Fuente de poder"
                        }
                    });
                    contexto.SaveChanges();
                {
                }
                //Productos
                if (!contexto.Productos.Any())
                {
                    contexto.Productos.AddRange(new List<Productos>(){
                        new Productos()
                        {
                            NombreProducto = "Teclado Mecanico Redragon Yama K550 RGB",
                            Descripcion = "Teclado Gamer; teclado mecánico para juegos de 104 teclas con interruptores mecánicos personalizados (equivalente a marrón cereza) diseñado para una mayor durabilidad y capacidad de respuesta. Las teclas de teclado mecánico ofrecen resistencia media, sonido de clic medio y retroalimentación táctil nítida y precisa. Ideal para ambos; el máximo rendimiento de juego y para entornos de oficina, donde un sonido de clic demasiado fuerte puede molestar a los demás.",
                            ImagenProducto = "https://i0.wp.com/clonesyperifericos.com/wp-content/uploads/2024/09/Teclado-Mecanico-Redragon-Yama-K550-RGB.png?fit=800%2C800&ssl=1",
                            Precio = 200000,
                            FechaCreacion = new DateTime(2024, 10, 02),
                        },
                        new Productos()
                        {
                            NombreProducto = "Mouse Steelseries Aerox 3 Wireless Faze Clan Edition",
                            Descripcion = "Domina el campo de batalla como FaZe con su mouse de juego favorito mientras repite sus colores. Con equipos avalados por ellos, conviértete en un disruptor global.",
                            ImagenProducto = "https://i0.wp.com/clonesyperifericos.com/wp-content/uploads/2024/08/Mouse-Aerox-3-Wireless-Faze-Clan-Edition.png?fit=800%2C800&ssl=1",
                            Precio = 120000,
                            FechaCreacion = new DateTime(2024, 10, 02),
                        },
                        new Productos()
                        {
                            NombreProducto = "Tarjeta de Video INNO3D GEFORCE RTX 3050 TWIN X2 8G",
                            Descripcion = "Reloj: GPU / Reloj de aumento de memoria, Hasta 2799 MHz/ 18 Gbps, Reloj de juego**: 2516 MHz/ 18 Gbps.",
                            ImagenProducto = "https://i0.wp.com/clonesyperifericos.com/wp-content/uploads/2024/08/Tarjetas-de-Video-ASRock-AMD-RX-7600-XT-Challenger-16GB-OC.png?fit=800%2C800&ssl=1",
                            Precio = 1000000,
                            FechaCreacion = new DateTime(2024, 10, 02),
                        },

                    });
                    contexto.SaveChanges();
                }
                //Tiendas
                if (!contexto.Tiendas.Any())
                {
                    contexto.Tiendas.AddRange(new List<Tiendas>(){
                        new Tiendas()
                        {
                            NombreTienda = "Redragon",
                            Direccion = "Carrera 1 # 2 - 3",
                            Logo = "https://cdn.worldvectorlogo.com/logos/redragon.svg",
                            Estado = 1,
                            FechaCreacion = new DateTime(2024, 10, 02),
                        },
                        new Tiendas()
                        {
                            NombreTienda = "Steelseries",
                            Direccion = "Carrera 3 # 2 - 1",
                            Logo = "https://1000logos.net/wp-content/uploads/2020/09/Steelseries-logo.png",
                            Estado = 1,
                            FechaCreacion = new DateTime(2024, 10, 02),
                        },
                        new Tiendas()
                        {
                            NombreTienda = "AMD",
                            Direccion = "Carrera 2 # 1 - 3",
                            Logo = "https://i.pinimg.com/originals/ea/be/15/eabe15e49d4f9f613a0734c2a0aba60f.png",
                            Estado = 1,
                            FechaCreacion = new DateTime(2024, 10, 02),
                        },
                    });
                    contexto.SaveChanges();
                }
                //Categoría productos
                if (!contexto.CategoriasProductos.Any())
                {
                    contexto.CategoriasProductos.AddRange(new List<CategoriasProductos>(){
                        new CategoriasProductos()
                        {
                            CategoriasId = 1,
                            ProductosId = 1,
                        },
                        new CategoriasProductos()
                        {
                            CategoriasId = 2,
                            ProductosId = 2,
                        },
                        new CategoriasProductos()
                        {
                            CategoriasId = 5,
                            ProductosId = 3,
                        },
                    });
                    contexto.SaveChanges();
                }
                //Productos tienda
                if (!contexto.ProductosTiendas.Any())
                {
                    contexto.ProductosTiendas.AddRange(new List<ProductosTiendas>(){
                        new ProductosTiendas()
                        {
                            TiendasId = 1,
                            ProductosId = 1,
                        },
                        new ProductosTiendas()
                        {
                            TiendasId = 1,
                            ProductosId = 2,
                        },
                        new ProductosTiendas()
                        {
                            TiendasId = 2,
                            ProductosId = 3,
                        },
                        new ProductosTiendas()
                        {
                            TiendasId = 3,
                            ProductosId = 1,
                        },
                        new ProductosTiendas()
                        {
                            TiendasId = 3,
                            ProductosId = 2,
                        },
                    });
                    contexto.SaveChanges();
                }
                //Usuario
                if (!contexto.Usuarios.Any())
                {
                    contexto.Usuarios.AddRange(new List<Usuarios>(){
                        new Usuarios()
                        {
                            NombreUsuario = "admin",
                            CorreoUsuario = "admin@correo.com",
                            PasswordUsuario = "password",
                        },
                    });
                    contexto.SaveChanges();
                }
            }
        }
    }
}
