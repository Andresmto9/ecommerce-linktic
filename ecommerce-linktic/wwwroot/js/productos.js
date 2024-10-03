/**
 * Realiza la petición para consultar y mostrar los productos existentes dentro del sistema
 */
getDataProductos()
    .then((data) => {
        // Inicia la variable de la data asociada a los productos
        let tblProd = "";

        // Realiza la destructuración del DataTable asociado a la tabla de productos
        $("#tblProductos").DataTable().destroy();
        $("#dataTblProductos").empty();

        // Realiza la validación si se encontran productos dentro del sistema
        if (data["estado"] == "OK") {

            // Realiza el recorrido del objeto de productos existentes dentro del sistema
            $.each(data["data"], function (key, value) {

                // Realiza el formato a mostrar dentro de la tabla de productos
                tblProd += `
                    <tr>
                        <td class="text-center">${value.productoId}</td>
					    <td class="text-center"><img class="rounded-circle img-thumbnail w-50 h-50" src="${value.imagenProducto}"/></td>
					    <td class="text-center">${value.productoNombre}</td>
					    <td class="text-center">$ ${new Intl.NumberFormat().format(value.precio)}</td>
                        <td class="text-center">${value.categoriaNombre}</td>
					    <td class="text-center">${value.fechaCreacion}</td>
					    <td class="text-center">
                            <div class="d-flex">
                                <button type="button" data-prod='${JSON.stringify(value)}' class="btn btn-sm btn-outline-primary rounded-circle m-1 editProd" title="Editar">
                                    <i class="bi bi-pencil-square"></i>
                                </button>
                                <button type="button" data-id="${value.productoId}" class="btn btn-sm btn-outline-danger rounded-circle m-1 deleteProd" title="Borrar">
                                    <i class="bi bi-trash3-fill"></i>
                                </button>
                            </div>
                        </td>
                    </tr>
                `
            })
        } else {

            // Si no existen productos registrados en el sistema, muestra un mensaje de error
            tblProd += `
                <tr>
                    <td colspan="6" class="text-center">NO HAY PRODUCTOS CARGADOS</td>
                </tr>
            `;
        }

        // Realiza la inserción a la tabla de la data asignada bajo la consulta de productos y genera procesos logicos para los botones
        $("#dataTblProductos").html(tblProd).after(function () {
            $(".editProd").on('click', function () {
                console.log("Editar")
                showDataProductos($(this).data("prod"));
            })

            $(".deleteProd").on('click', function () {
                deleteProd($(this).data("id"));
            })
        });

        // Realiza la construcción del DataTable para productos
        $("#tblProductos").DataTable();
    })
    .catch((error) => {
        // Muestra el error en consola si falla la consulta de productos
        console.log(error)
    });

/**
 * Función para consultar los productos existentes dentro del sistema de manera asincronica
 * 
 * @returns Retorna JSON de respuesta sobre la consulta de productos
 */
async function getDataProductos() {
    return new Promise((resolve, reject) => {
        $.ajax({
            method: 'get',
            url: '/Productos/GetDataProductos',
            dataType: "json",
            success: function (data) {
                resolve(data)
            },
            error: function (error) {
                reject(error)
            },
        })
    })
}

/**
 * Función para mostrar los datos del producto que se va a editar
 */
function showDataProductos(producto)
{
    console.log(producto);
}

/**
 * Función para borrar el producto seleccionado dentro de la tabla
 */
function deleteProd(productoID)
{
    console.log(productoID);
}