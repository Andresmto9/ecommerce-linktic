//////////////////////////////////////////// SECCIÓN PARA DAR FORMATO A LOS PRODUCTOS ACTIVOS ////////////////////////////////////////////
let arrProd = localStorage.getItem("arrProd") == null ? [] : JSON.parse(localStorage.getItem("arrProd"));
$("#cantProd").html(arrProd.length);
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//////////////////////////////////////////// SECCIÓN DE LLAMADO DE LAS FUNCIONES ////////////////////////////////////////////

/** Llamado a la función para la contrucción de la tabla de productos **/
mostrarTablaProductos()

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//////////////////////////////////////////// SECCIÓN DE FUNCIONES ////////////////////////////////////////////

/**
 * Funcionalidad general para rezaliar el proceso de consulta y contrucción de la tabla de productos
 */
function mostrarTablaProductos()
{
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
                $.each(data["producto"], function (key, value) {

                    // Realiza el formato a mostrar dentro de la tabla de productos
                    tblProd += `
                    <tr>
                        <td class="text-center">${++key}</td>
					    <td class="text-center"><img class="img rounded-circle img-thumbnail w-50 h-50" src="${value.imagenProducto}"/></td>
					    <td class="text-center">${value.nombreProducto}</td>
					    <td class="text-center">$ ${new Intl.NumberFormat().format(value.precio)}</td>
					    <td class="text-center">${value.fechaCreacion}</td>
					    <td class="text-center">
                            <div class="d-flex">
                                <button type="button" data-prod='${JSON.stringify(value)}' class="btn btn-sm btn-outline-primary rounded-circle m-1 editProd" title="Editar">
                                    <i class="bi bi-pencil-square"></i>
                                </button>
                                <button type="button" data-id="${value.id}" class="btn btn-sm btn-outline-danger rounded-circle m-1 deleteProd" title="Borrar">
                                    <i class="bi bi-trash3-fill"></i>
                                </button>
                            </div>
                        </td>
                    </tr>
                `
                })
            }

            // Realiza la inserción a la tabla de la data asignada bajo la consulta de productos y genera procesos logicos para los botones
            $("#dataTblProductos").html(tblProd).after(function () {
                $(".editProd").on('click', function () {
                    showDataProductos($(this).data("prod"));
                })

                $(".deleteProd").on('click', function () {
                    let prodID = $(this).data("id");
                    Swal.fire({
                        icon: 'info',
                        title: "¡UN MOMENTO!",
                        text: "¿Desea eliminar este producto?",
                        showCancelButton: true,
                        confirmButtonText: "SI",
                        cancelButtonText: `NO`,
                        confirmButtonColor: "#198754",
                        cancelButtonColor: "#dc3545",
                    }).then((result) => {
                        /* Read more about isConfirmed, isDenied below */
                        if (result.isConfirmed) {
                            borrarProducto(prodID);
                        }
                    });
                })

                mostrarCategorias(data["categoria"]);
                mostrarTiendas(data["tienda"]);
            });

            // Realiza la construcción del DataTable para productos
            $("#tblProductos").DataTable();
        })
        .catch((error) => {
            // Muestra el error en consola si falla la consulta de productos
            console.log(error)
        });

}

/**
 * Función para mostrar los datos del producto que se va a editar
 */
function showDataProductos(producto) {
    $("#nombre-producto").val(producto.nombreProducto)
    $("#precio-producto").val(producto.precio)
    $("#imagen-producto").val(producto.imagenProducto)
    $("#descripcion-producto").val(producto.descripcion)

    $("#modaTituProductos").html("Editar producto").after(function () {
        $("#modalProductos").modal("show");
        $("#contCreaProdModal").html(`
            <button type="button" class="btn btn-danger close" data-dismiss="modal">Cerrar</button>
			<button type="button" class="btn btn-success" id="btnCreaProdModal">
				<i class="bi bi-pencil"></i> Actualizar producto
			</button>
        `).after(function () {
            /**
             * Funcionalidad para cerrar el modal de productos
            */
            $(".close").on('click', function () {
                $("#modalProductos").modal("hide");
            })

            $("#btnCreaProdModal").on('click', function () {

                let vali = 0;
                $(".formProd").each(function () {
                    if ($(this).val() == "") {
                        Swal.fire({
                            title: "¡UN MOMENTO!",
                            text: `Debe registrar ${$(this).data('nombre')} del producto.`,
                            icon: "info",
                            confirmButtonText: "OK",
                            confirmButtonColor: "#198754"
                        });
                        vali = 1
                    }
                })

                if (vali == 0) {
                    actualizarProducto(producto.id)
                }
            })
        });
    })
}

/**
 * Función para mostrar las categorias existentes en el sistema dentro del formulario
 */
function mostrarCategorias(categoria) {
    let selectCategoria = '<option value="" selected>Seleccione una opción</option>';
    $.each(categoria, function (key, value) {
        selectCategoria += `
            <option value="${value.id}">${value.nombreCategoria}</option>
        `
    })

    $("#categoria-producto").html(selectCategoria).html(function () {
        $('#categoria-producto').select2({
            theme: 'bootstrap-5'
        });
    })
}

/**
 * Función para mostrar las tiendas existentes en el sistema dentro del formulario
 */
function mostrarTiendas(tienda) {
    let selectTienda = '<option value="" selected>Seleccione una opción</option>';
    $.each(tienda, function (key, value) {
        selectTienda += `
            <option value="${value.id}">${value.nombreTienda}</option>
        `
    })

    $("#tienda-producto").html(selectTienda).html(function () {
        $('#tienda-producto').select2({
            theme: 'bootstrap-5'
        });
    })
}

/**
 * Funcionalidad para validar el formulario de registro de productos y enviar el producto a creación
 */
function crearProducto()
{
    let arrProducto = {
        'NombreProducto': $("#nombre-producto").val(),
        'Descripcion': $("#descripcion-producto").val(),
        'ImagenProducto': $("#imagen-producto").val(),
        'Precio': $("#precio-producto").val()
    }

    setProductos(arrProducto, $("#categoria-producto").val(), $("#tienda-producto").val())
        .then((data) => {
            if (data["estado"] == "OK") {
                Swal.fire({
                    title: "¡PERFECTO!",
                    text: data["mensaje"],
                    icon: "success",
                    confirmButtonText: "OK",
                    confirmButtonColor: "#198754"
                }).then((result) => {
                    if (result.isConfirmed) {
                        $("#categoria-producto").select2('destroy');
                        $("#tienda-producto").select2('destroy');
                        $("#modalProductos").modal("hide");
                        mostrarTablaProductos()
                    }

                });;
            } else {
                Swal.fire({
                    title: "¡UN MOMENTO!",
                    text: data["mensaje"],
                    icon: "error",
                    confirmButtonText: "OK",
                    confirmButtonColor: "#198754"
                });
            }
        })
        .catch((error) => {
            console.log(error)
        });
}

/**
 * Funcionalidad para actualizar el producto seleccionado desde la tabla
 * 
 * @param {int} id Recibe por parametro el ID del producto que se va actualizar
 */
function actualizarProducto(id)
{
    let arrProducto = {
        'NombreProducto': $("#nombre-producto").val(),
        'Descripcion': $("#descripcion-producto").val(),
        'ImagenProducto': $("#imagen-producto").val(),
        'Precio': $("#precio-producto").val()
    }

    updateProductos(arrProducto, id)
        .then((data) => {
            if (data["estado"] == "OK") {
                Swal.fire({
                    title: "¡PERFECTO!",
                    text: data["mensaje"],
                    icon: "success",
                    confirmButtonText: "OK",
                    confirmButtonColor: "#198754"
                }).then((result) => {
                    if (result.isConfirmed) {
                        $("#categoria-producto").select2('destroy');
                        $("#tienda-producto").select2('destroy');
                        $("#modalProductos").modal("hide");
                        mostrarTablaProductos()
                    }

                });;
            } else {
                Swal.fire({
                    title: "¡UN MOMENTO!",
                    text: data["mensaje"],
                    icon: "error",
                    confirmButtonText: "OK",
                    confirmButtonColor: "#198754"
                });
            }
        })
        .catch((error) => {
            console.log(error)
        });
}

/**
 * Funcionalidad para borrar el producto seleccionado desde la tabla
 */
function borrarProducto(prodID) {
    deleteProducto(prodID)
        .then((data) => {
            if (data["estado"] == "OK") {
                Swal.fire({
                    title: "¡PERFECTO!",
                    text: data["mensaje"],
                    icon: "success",
                    confirmButtonText: "OK",
                    confirmButtonColor: "#198754"
                }).then((result) => {
                    if (result.isConfirmed) {
                        $("#categoria-producto").select2('destroy');
                        $("#tienda-producto").select2('destroy');
                        $("#modalProductos").modal("hide");
                        mostrarTablaProductos()
                    }

                });
            } else {
                Swal.fire({
                    title: "¡UN MOMENTO!",
                    text: data["mensaje"],
                    icon: "error",
                    confirmButtonText: "OK",
                    confirmButtonColor: "#198754"
                });
            }
        })
        .catch((error) => {
            console.log(error)
        });
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


//////////////////////////////////////////// SECCIÓN DE PETICIONES ////////////////////////////////////////////

/**
 * Función para consultar los productos existentes dentro del sistema de manera asincronica
 * 
 * @returns {JSON} Retorna array de respuesta
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
 * Funcionalidad para ejecutar la petición de creación del producto
 * 
 * @param {JSON} producto Recibe por parametro el array de datos para crear el producto
 * @param {int} categoria Recibe por parametro el ID de la categoría asociada al producto
 * @param {int} tienda Recibe por parametro el ID de la tienda asociada al producto
 * @returns {JSON} Retorna array de respuesta
 */
async function setProductos(producto, categoria, tienda) {
    return new Promise((resolve, reject) => {
        $.ajax({
            method: 'post',
            url: `/Productos/CreateProductos?categoria=${categoria}&tienda=${tienda}`,
            dataType: "json",
            data: JSON.stringify(producto),
            contentType: 'application/json',
            success: function (data) {
                resolve(data);
            },
            error: function (error) {
                reject(error);
            },
        });
    });
}

/**
 * Funcionalidad para ejecutar la petición para la actualización del producto
 * 
 * @param {JSON} producto Recibe por parametro el array del producto a actualziar
 * @param {int} prodID Recibe por parametro el ID del producto a actualizar
 * @returns {JSON} Retorna array de respuesta
 */
async function updateProductos(producto, prodID) {
    return new Promise((resolve, reject) => {
        $.ajax({
            method: 'post',
            url: `/Productos/UpdateProductos?id=${prodID}`,
            dataType: "json",
            data: JSON.stringify(producto),
            contentType: 'application/json',
            success: function (data) {
                resolve(data);
            },
            error: function (error) {
                reject(error);
            },
        });
    });
}

/**
 * Funcion que ejecuta la petición para el borrado del producto
 * 
 * @param {int} prodID Recibe por parametro el ID del producto que se va a borrar
 * @returns {JSON} Retorna array de respuesta
 */
async function deleteProducto(prodID) {
    return new Promise((resolve, reject) => {
        $.ajax({
            method: 'post',
            url: `/Productos/DeleteProductos?id=${prodID}`,
            dataType: "json",
            contentType: 'application/json',
            success: function (data) {
                resolve(data);
            },
            error: function (error) {
                reject(error);
            },
        });
    });
}



////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


//////////////////////////////////////////// SECCIÓN DE FUNCIONALIDADES SOBRE ELEMENTOS DEL DOM ////////////////////////////////////////////

/**
 * Funcionalidad para mostrar el modal con el formulario de creación para los productos
 */
$("#btnCreaProd").on('click', function () {
    $("#nombre-producto").val('')
    $("#precio-producto").val('')
    $("#imagen-producto").val('')
    $("#descripcion-producto").val('')

    $("#modaTituProductos").html("Crear producto").after(function () {
        $("#modalProductos").modal("show");
        $("#contCreaProdModal").html(`
            <button type="button" class="btn btn-danger close" data-dismiss="modal">Cerrar</button>
			<button type="button" class="btn btn-success" id="btnCreaProdModal">
				<i class="bi bi-plus-circle"></i> Crear producto
			</button>
        `).after(function () {
            /**
                * Funcionalidad para cerrar el modal de productos
            */
            $(".close").on('click', function () {
                $("#modalProductos").modal("hide");
            })

            $("#btnCreaProdModal").on('click', function () {

                let vali = 0;
                $(".formProd").each(function () {
                    if ($(this).val() == "") {
                        Swal.fire({
                            title: "¡UN MOMENTO!",
                            text: `Debe registrar ${$(this).data('nombre')} del producto.`,
                            icon: "info",
                            confirmButtonText: "OK",
                            confirmButtonColor: "#198754"
                        });
                        vali = 1
                    }
                })

                if (vali == 0) {
                    crearProducto()
                }
            })
        });
    })
})

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
