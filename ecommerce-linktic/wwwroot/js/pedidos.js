//////////////////////////////////////////// SECCIÓN PARA LLAMADO DE LAS FUNCIONES ////////////////////////////////////////////
mostrarCantidadProductos()
mostrarTablaPedidos()
setPedidoActual()
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//////////////////////////////////////////// SECCIÓN DE FUNCIONES ////////////////////////////////////////////
function setPedidoActual() {
    let pedido = '';
    let arrPedido = localStorage.getItem("arrProd");
    let total = 0;

    if (arrPedido == null || JSON.parse(arrPedido).length == 0) {
        pedido = `
            <div class="col-12 text-center">
                <p class="fs-1 fw-bold">NO HAY PEDIDO ACTUAL</p>
            </div>
        `;
    } else {
        let subTotal = 0

        $.each(JSON.parse(arrPedido), function (key, value) {
            pedido += `
                <div class="col-10">
                    <div class="card l-bg-cherry">
                        <div class="card-statistic-3 pt-2 pb-2 row">
                            <div class="col-2 d-flex justify-content-center">
                                <img class="rounded-circle img-thumbnail" src="${value.imagen}" style="width: 50%;height: 4.5rem;object-fit: cover;" />
                            </div>
                            <div class="col-10 d-flex align-items-center justify-content-center">
                                <div class="row align-items-center mb-2 col-12">
                                    <div class="col-8">
                                        <h5 class="d-flex align-items-center mb-0">
                                            ${value.producto}
                                        </h5>
                                    </div>
                                    <div class="col-2 text-right">
                                        <h6>$ ${new Intl.NumberFormat().format(value.precio)}</h6>
                                    </div>
                                    <div class="col-2 text-right">
                                        <button type="button" data-posi="${key}" class="btn btn-sm btn-outline-danger rounded-circle m-1 deleProdPedi" title="Borrar">
                                            <i class="bi bi-trash3-fill"></i>
                                        </button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            `
            subTotal += value.precio
        })

        total = ((subTotal * 0.19) + subTotal)

        pedido += `
        <div class="col-10">
            <div class="card l-bg-cherry">
                <div class="card-statistic-3 pt-2 pb-2 row">
                    <div class="col-12 d-flex align-items-center justify-content-center">
                        <div class="row align-items-center mb-2 col-12 text-center">
                            <div class="col-6 text-center">
                                <h4 class="align-items-center mb-0 text-center">
                                    SUBTOTAL
                                </h4>
                            </div>
                            <div class="col-6 text-right">
                                <h6>$ ${new Intl.NumberFormat().format(subTotal)}</h6>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-10">
            <div class="card l-bg-cherry">
                <div class="card-statistic-3 pt-2 pb-2 row">
                    <div class="col-12 d-flex align-items-center justify-content-center">
                        <div class="row align-items-center mb-2 col-12 text-center">
                            <div class="col-6 text-center">
                                <h4 class="align-items-center mb-0 text-center">
                                    IVA
                                </h4>
                            </div>
                            <div class="col-6 text-right">
                                <h6>$ ${new Intl.NumberFormat().format((subTotal * 0.19))}</h6>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-10">
            <div class="card l-bg-cherry">
                <div class="card-statistic-3 pt-2 pb-2 row">
                    <div class="col-12 d-flex align-items-center justify-content-center">
                        <div class="row align-items-center mb-2 col-12 text-center">
                            <div class="col-6 text-center">
                                <h4 class="align-items-center mb-0 text-center">
                                    TOTAL
                                </h4>
                            </div>
                            <div class="col-6 text-right" title="Total aplicado IVA 19%">
                                <h6>$ ${new Intl.NumberFormat().format(total)}</h6>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-10">
            <div class="card l-bg-cherry">
                <div class="card-statistic-3 pt-2 pb-2 row">
                    <div class="col-12 d-flex align-items-center justify-content-center">
                        <div class="row align-items-center mb-2 col-12 text-center">
                            <div class="col-12 pt-2">
                                <div class="d-flex justify-content-center align-items-center">
                                    <button type="button" class="btn btn-success" id="btnRealizaCompra">
                                        <i class="bi bi-bag-check-fill"></i> Realizar compra
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    `
    }

    $("#contDetallePedido").html(pedido).after(function () {
        $(".deleProdPedi").on('click', function () {
            let arrPedi = JSON.parse(arrPedido)
            arrPedi.splice($(this).data('posi'), 1);
            localStorage.setItem("arrProd", JSON.stringify(arrPedi));
            mostrarCantidadProductos()
            setPedidoActual()
        })

        $("#btnRealizaCompra").on('click', function () {
            let arrProd = [];
            $.each(JSON.parse(localStorage.getItem("arrProd")), function (key, value) {
                arrProd.push(value.id);
            })
            realizaCompraPedido(arrProd, total);
        })
    });
}

function realizaCompraPedido(arrProd, total) {
    SetCompraPedido(arrProd, total)
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
                        localStorage.removeItem("arrProd")
                        mostrarCantidadProductos()
                        mostrarTablaPedidos()
                        setPedidoActual()
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

function mostrarTablaPedidos() {
    GetPedidos()
        .then((data) => {
            let tblPedi = "";

            $("#tblPedidos").DataTable().destroy();
            $("#dataTblPedidos").empty();

            if (data["estado"] == "OK") {
                $.each(data["pedidos"], function (key, value) {
                    console.log(value);

                    let botones = '';
                    let estado = '';

                    if (value.estado == 0) {
                        botones = `
                            <button type="button" data-id="${value.id}" data-estado="1" data-mensaje="aprobar" class="btn btn-sm btn-outline-success rounded-circle m-1 editPedido" title="Aprobar pedido">
                                <i class="bi bi-check-lg"></i>
                            </button>
                            <button type="button" data-id="${value.id}" data-estado="2" data-mensaje="rechazar" class="btn btn-sm btn-outline-danger rounded-circle m-1 editPedido" title="Rechazar pedido">
                                <i class="bi bi-x-lg"></i>
                            </button>
                        `
                        estado = `<span class="badge bg-info text-dark p-2">Creado</span>`
                    } else if (value.estado == 1) {
                        botones = `
                            <p class="fw-bold">Pedido cerrado</p>
                        `
                        estado = `<span class="badge bg-success p-2">Aprobado</span>`
                    } else {
                        botones = `
                            <p class="fw-bold">Pedido cerrado</p>
                        `
                        estado = `<span class="badge bg-danger p-2">Rechazado</span>`
                    }


                    // Realiza el formato a mostrar dentro de la tabla de productos
                    tblPedi += `
                        <tr>
                            <td class="text-center">${++key}</td>
					        <td class="text-center">$ ${new Intl.NumberFormat().format(value.totalPrecioPedido) }</td>
					        <td class="text-center">${value.fechaCreacion}</td>
					        <td class="text-center">${estado}</td>
					        <td class="text-center">
                                <div class="d-flex justify-content-center align-items-center">
                                    ${botones}
                                </div>
                            </td>
                        </tr>
                    `
                })
            }

            $("#dataTblPedidos").html(tblPedi).after(function () {
                $(".editPedido").on("click", function () {
                    Swal.fire({
                        title: "¡UN MOMENTO!",
                        text: `Desea ${$(this).data('mensaje')} el pedido.`,
                        icon: 'info',
                        showCancelButton: true,
                        confirmButtonText: "SI",
                        cancelButtonText: `NO`,
                        confirmButtonColor: "#198754",
                        cancelButtonColor: "#dc3545",
                    }).then((result) => {
                        if (result.isConfirmed) {
                            actualizarPedido($(this).data('id'), $(this).data('estado'))
                        }
                    });
                })
            });

            $("#tblPedidos").DataTable();
        })
        .catch((error) => {
            console.log(error)
        });
}

function actualizarPedido(pediID, estado) {
    UpdatePedido(pediID, estado)
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
                        mostrarTablaPedidos()
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

function mostrarCantidadProductos() {
    let arrProd = localStorage.getItem("arrProd") == null ? [] : JSON.parse(localStorage.getItem("arrProd"));
    $("#cantProd").html(arrProd.length);
}
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//////////////////////////////////////////// SECCIÓN DE PETICIONES ////////////////////////////////////////////
async function SetCompraPedido(pedido, total) {
    return new Promise((resolve, reject) => {
        $.ajax({
            method: 'post',
            url: `/Pedidos/SetCompraPedido?total=${total}`,
            data: JSON.stringify(pedido),
            dataType: "json",
            contentType: "application/json",
            success: function (data) {
                resolve(data)
            },
            error: function (error) {
                reject(error)
            },
        })
    })
}

async function GetPedidos() {
    return new Promise((resolve, reject) => {
        $.ajax({
            method: 'get',
            url: `/Pedidos/GetPedidos`,
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

async function UpdatePedido(id, estado) {
    return new Promise((resolve, reject) => {
        $.ajax({
            method: 'post',
            url: `/Pedidos/UpdatePedido?id=${id}&estado=${estado}`,
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
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////