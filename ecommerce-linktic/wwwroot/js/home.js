getProdcutosVenta()
    .then((data) => {
        let productos = '';
        $("#contProductos").empty();
        if (data["estado"] == "OK")
        {
            $.each(data["data"], function (key, value) {
                productos += `
                    <div class="col-12 col-md-6 col-lg-4 mt-5">
                        <div class="card" style="border-radius: 15px;">
                            <div class="bg-image hover-overlay ripple ripple-surface ripple-surface-light"
                                 data-mdb-ripple-color="light">
                                <img src="${value.imagenProducto}"
                                     style="border-top-left-radius: 15px; border-top-right-radius: 15px;" class="img"
                                     alt="Laptop" />
                            </div>
                            <div class="card-body pb-0">
                                <div class="d-flex justify-content-between">
                                    <div class="overflow-auto" style="height: 7rem !important;">
                                        <p class="text-dark">${value.productoNombre}</p>
                                        <p class="small text-muted">${value.categoriaNombre}</p>
                                    </div>
                                </div>
                            </div>
                            <hr class="my-0" />
                            <div class="card-body pb-0">
                                <div class="d-flex justify-content-between">
                                    <p class="text-dark">$ ${new Intl.NumberFormat().format(value.precio)}</p>
                                </div>
                                <div class="overflow-auto" style="height: 10rem !important;">
                                    <p class="small text-muted">${value.descripcion}.</p>
                                </div>
                            </div>
                            <hr class="my-0" />
                            <div class="card-body">
                                <div class="d-flex justify-content-end align-items-center pb-2 mb-1">
                                    <button type="button" class="btn btn-success addProduct" data-precio="${value.precio}" data-producto="${value.productoNombre}" data-id="${value.productoId}" data-imagen="${value.imagenProducto}">
                                        <i class="bi bi-cart-plus"></i> Agregar al carrito
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                `;
            });
        }else
        {
            productos += `
                <div class="col-12 text-center">
                    <p class="fs-1 fw-bold">NO HAY PRODUCTOS REGISTRADOS</p>
                </div>
            `
        }

        /**
         * Funcionalidad para realizar el conteo de productos añadido al carrito de compras
         */
        $("#contProductos").html(productos).after(function () {
            $("#my-tip").empty();
            let cont = 1;
            let detaProd = ''
            let arrProd = localStorage.getItem("arrProd") == null ? [] : JSON.parse(localStorage.getItem("arrProd"));
            $("#cantProd").html(arrProd.length);

            $(".addProduct").on('click', function () {
                let arrTemp = {
                    'id': $(this).data('id'),
                    'imagen': $(this).data('imagen'),
                    'producto': $(this).data('producto'),
                    'precio': $(this).data('precio'),
                }

                arrProd.push(arrTemp);

                localStorage.setItem("arrProd", JSON.stringify(arrProd));

                $("#cantProd").html(arrProd.length);
            })
        })
    })
    .catch((error) => {
        // Muestra el error en consola si falla la consulta de productos
        console.log(error)
    });

/**
 * Función para consultar los productos para la venta existentes dentro del sistema de manera asincronica
 * 
 * @returns Retorna JSON de respuesta sobre la consulta de productos
 */
async function getProdcutosVenta() {
    return new Promise((resolve, reject) => {
        $.ajax({
            method: 'get',
            url: '/Home/GetProdcutosVenta',
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