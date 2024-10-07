# Presentación Prueba Desarrollador Fullstack Linktic

## 1. Clonación del Repositorio para ser Ejecutado en Visual Studio

- Abrimos Visual Studio.
- Nos dirigimos a la pestaña **Clonar un repositorio**.
- En el apartado de **Ubicación del repositorio**, colocamos la URL de clonación SSH desde GitHub: `https://github.com/Andresmto9/ecommerce-linktic.git`.
- Damos al botón **Clonar** y esperamos a que el proyecto sea clonado.

## 2. Creación de Base de Datos

- Abrimos el gestor de bases de datos SQL Server Management Studio.
- Vamos al apartado **Databases** y damos clic derecho en **New Database**.
- Se abrirá una ventana que nos da la opción de configurar la base de datos; dejamos todas las propiedades por defecto.
- En el apartado **Database Name**, colocamos el nombre de la base de datos como `DBLinktic` y esperamos a que se cree.

## 3. Apertura y Configuración del Proyecto

- Después de tener el proyecto abierto en Visual Studio, verificamos si existe la carpeta **Migrations** y el archivo de migración creada allí.
- Si existe el archivo de migración dentro de la carpeta **Migrations**, abrimos la **Consola del Administrador de Paquetes**:
  - Vamos a **Herramientas** > **Administrador de Paquetes NuGet** > **Consola del Administrador de Paquetes**.
- En la consola, ejecutamos el comando `Update-Database`. Esto ejecutará todas las migraciones creadas para el sistema, y podremos visualizar la base de datos desde SQL Server Management Studio.
- Si no existe el archivo de migraciones dentro de **Migrations**, ejecutamos el comando `Add-Migration CreacionProductos` (el nombre es opcional).
- Luego de crear las migraciones, ejecutamos nuevamente el comando `Update-Database`.
- Si las migraciones fueron ejecutadas con éxito, iniciamos la depuración del proyecto:
  - Recomiendo utilizar el servicio HTTP local para evitar conflictos con el navegador.
  - En la parte superior, debajo de las opciones de Visual Studio, seleccionamos la opción **HTTP**.
- Luego de seleccionar la opción de depuración HTTP, hacemos clic al botón y empezará a ejecutar los seeders asociados al proyecto y abrirá un navegador para visualizar el proyecto.

## 4. Explicación del Proyecto

El proyecto **eCommerce_Linktic** es una simulación básica de un carrito de compras, donde se puede administrar productos, añadir productos a un carrito, gestionar un pedido actual y aprobar o rechazar los pedidos registrados en el sistema.

## 5. Módulo de Productos

En el apartado de productos, encontraremos una tabla con el listado de productos existentes en el sistema, donde se visualizará:

- ID del producto
- Imagen asociada al producto
- Nombre del producto
- Precio del producto
- Fecha de creación del producto
- Botones para editar y borrar

### 5.1 Creación de Productos

- En la parte superior de la tabla, hay un botón para la creación de productos que despliega un modal con un formulario de creación.
- Dentro del formulario de creación, encontraremos los siguientes campos:
  - Nombre del producto
  - Precio del producto
  - URL de imagen para el producto
  - Categoría del producto (listado predefinido en los seeders)
  - Tienda de venta del producto (listado predefinido en los seeders)
  - Descripción del producto
- El modal tiene una validación que impide registrar un producto si no se han diligenciado todos los datos.
- Si la creación del producto es exitosa, se mostrará una alerta notificando el éxito; de lo contrario, se notificará el fallo.

### 5.2 Edición del Producto

- En la tabla, hay un botón azul con un icono de un bolígrafo.
- Al hacer clic en el botón, se despliega un modal con el formulario de edición para el producto, cargando los datos asociados al producto seleccionado.
- Existe una validación que impide editar el producto si no se han registrado todos los datos del formulario.
- Al editar el producto, se mostrará una alerta notificando el éxito; de lo contrario, se notificará el fallo.

### 5.3 Borrado del Producto

- En la tabla, hay un botón rojo con un icono de un bote de basura.
- Al hacer clic en el botón, se despliega una alerta preguntando si se desea borrar el producto.
- Si se selecciona **Sí**, se notificará que el producto fue borrado exitosamente. Si se selecciona **No**, la alerta se cerrará y se visualizará de nuevo la tabla.

## 6. Carrito de Compras

- Para acceder al módulo de inicio, hay un botón llamado "Inicio".
- Se muestra un listado de todos los productos con información básica.
- Hay un botón verde "Agregar al carrito" que añade el producto seleccionado en tiempo real.

## 7. Módulo de Pedidos

- Para acceder al módulo de pedidos, clic en el ícono del carrito de compras.
- Visualizamos un acordeón con dos apartados: pedido actual e histórico de pedidos.

### 7.1 Pedido Actual

- Muestra el listado de productos en el carrito con la opción de borrarlos.
- Incluye subtotal, IVA y total de la compra.
- Al realizar la compra, se notifica el registro exitoso y se actualizan los pedidos.

### 7.2 Histórico de Pedidos

- Muestra una tabla con pedidos registrados que incluye:
- ID del pedido
- Total del pedido
- Fecha de creación
- Estado del pedido
- Botones para aprobar o rechazar.
- Se actualiza el estado del pedido al aprobar o rechazar y se muestra "pedido cerrado" para evitar cambios posteriores.

### 8 Estructura base de datos

![Estructura base de datos](https://raw.githubusercontent.com/Andresmto9/ecommerce-linktic/master/basededatoslinktick.PNG)
