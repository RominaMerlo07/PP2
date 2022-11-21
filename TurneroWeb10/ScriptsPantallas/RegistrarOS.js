var idObraSocial, idPlan;

$(document).ready(function () {

    //cargarComboCentros('#ddlSucursal');
    //cargarComboCentros('#ddlSucursalRegistrar');
    //$('#ddlSucursal').val('1');
    cargarTablaObrasSociales();


    //$("#ddlSucursal").bind("change", function () {
    //    cargarTablaObrasSociales();
    //});


    $('#btnRegistrarModal').click(function () {

        $("#modalRegistrarObraS").modal('show');
        $("#id__txtObraSocial").val(""); //limpia campo

    });

    

    $('#btnRegistrarObraS').click(function () {

        var obraSocAgregar = $("#id__txtObraSocial").val();     

        $.ajax({
            url: "ObrasSociales.aspx/agregarObraSocial",
            data: "{obraSocial: '" + obraSocAgregar + "'}",
            type: "post",
            contentType: "application/json",
            async: false,
            success: function (data) {

                console.log(data.d);

                swal("Hecho", "Se agregó la Obra Social correctamente.", "success");
                $("#id__txtObraSocial").val(""); //limpia campo
                cargarTablaObrasSociales();
                $("#modalRegistrarObraS").modal('hide');
            },
            error: function (xhr, ajaxOptions, thrownError) {
                console.log(thrownError);
            }
        });
    });


    $('#btnGuardarPlan').click(function () {

        var nombrePlan = $("#id__txtPlan").val();

        $.ajax({
            url: "ObrasSociales.aspx/agregarPlan",
            data: "{idObraSocial: '" + idObraSocial + "', nombrePlan: '" + nombrePlan + "'}",
            type: "post",
            contentType: "application/json",
            async: false,
            success: function (data) {

                swal("Hecho", "Se agregó el plan correctamente.", "success");

                $("#id__txtPlan").val(""); //limpia campo

                cargarTablaPlanes(idObraSocial);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(data.error);
            }
        });

    })

});


function cargarTablaObrasSociales() {

    $.ajax({
        url: "ObrasSociales.aspx/traerObrasSociales",
        //data: "{idCentro: '" + idSucursal + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            var datos = JSON.parse(data.d);
            var obras = [];
            datos.forEach(function (e) {
                var idObSocial = e.IdObraSocial;
                var obraSocial = e.Descripcion;
                //var Centro = e.Centro.NombreCentro;

                var particular = null;


                var Planes = '<button id="btnPlanes" class="btn btn-warning" type="reset" onclick= "return planesOS(' + idObSocial + ",'" + obraSocial + "'" + ')" > Consultar Planes </button>';

                var Acciones = '<a href="#" onclick="return actualizar(' + idObSocial + ",'" + obraSocial + "'" + ')"  class="btn btn-primary" > <span class="fa fa-pencil" title="Modificar"></span></a> ' +
                    '<a href="#" onclick="return inactivar(' + idObSocial + ",'" + obraSocial + "'" + ')"  class="btn btn-danger btnInactivar" > <span class="fa fa-trash" title="Dar de baja"></span></a > ';

                if (obraSocial == "PARTICULAR") {

                    obras.push([idObSocial, obraSocial, particular, /*Centro,*/ Acciones]);

                }
                else {
                    obras.push([idObSocial, obraSocial, Planes, /*Centro,*/ Acciones]);
                }
              

            });

            var table = $('#tablaObrasSociales').DataTable({
                data: obras,
                "scrollX": true,
                "languaje": {
                    "url": "//cdn.datatables.net/plug-ins/1.10.12/i18n/Spanish.json"
                },
                "ordering": true,
                "bDestroy": true,
                "bAutoWidth": true,
                columns: [
                    { title: "ID", visible: false },
                    { title: "Obra Social", visible: true },
                    { title: "Planes", visible: true },
                    { title: "Acciones" }
                ],
                dom: '<"top"B>rti<"bottom"fp><"clear">',
                "oLanguage": {
                    "sSearch": "Filtrar:",
                    "oPaginate": {
                        "sPrevious": "Anterior",
                        "sNext": "Siguiente"
                    }
                },
                "bPaginate": true,
                "pageLength": 5,
                buttons: [
                    //{ extend: 'copy', text: "Copiar" },
                    {
                        extend: 'print',
                        text: "Imprimir",
                        exportOptions: {
                            columns: [1]
                        }
                    },
                    {
                        extend: 'pdf', /*orientation: 'landscape'*/
                        exportOptions: {
                            columns: [1]
                        }
                    },
                    { extend: 'colvis', columns: ':not(:first-child)', text: "Ocultar/Mostrar columnas" }
                ]
            });
            $('.dataTables_filter input').attr("placeholder", "Filtrar por...");
        }
    });
}

function planesOS(idObSocial, obraSocial) {

    idObraSocial = idObSocial;
    $("#modalEditarObraS").modal('show');
    $("#id__txtPlan").val("");

    $("#lblObraSocial").text(obraSocial);

    cargarTablaPlanes(idObSocial);
}

function actualizar(idObSocial, obraSocial) {

    idObraSocial = idObSocial;

    $.ajax({
        type: "POST",
        url: "ObrasSociales.aspx/cargarObrasSociales",
        data: "{idObraSocial: '" + idObSocial + "'}",
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        async: false,
        success: function (data) {

            $("#modalEditar").modal('show');
            $("#id__AtxtObraSocial").val(data.d.Descripcion);
            
        },
        error: function (xhr, ajaxOptions, thrownError) {

        }
    })
}


$('#btnActualizar').click(function () {

    var obraSocial = $("#id__AtxtObraSocial").val();
    updateObraSocial(idObraSocial, obraSocial);

});


function updateObraSocial(idObraSocial, obraSocial) {

    var datosObraSocial = {
        p_id: idObraSocial,
        p_descripcion: obraSocial
    } 

    $.ajax({
        type: "POST",
        url: "ObrasSociales.aspx/editarObraSocial",
        data: JSON.stringify(datosObraSocial),
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        async: false,
        success: function (data) {

            if (data.d != 'OK') {
                swal("Hubo un problema", "Error al actualizar la obra social", "error"); //error
            } else {
                swal("Hecho", "Obra social actualizada con Éxito!", "success"); //error
                $("#modalEditar").modal('hide');
                cargarTablaObrasSociales();
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {

        }
    })

}

function inactivar(idObraSocial, obraSocial) {

    $.ajax({
        url: "ObrasSociales.aspx/darBajaObraSocial",
        data: "{idObraSocial: '" + idObraSocial + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            swal("Hecho", "Se dio de baja a " + obraSocial + " y sus planes.", "success");

            cargarTablaObrasSociales();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(data.error);
        }
    });
}

function cargarTablaPlanes(idObraSocial) {

    $.ajax({
        type: "POST",
        url: "ObrasSociales.aspx/traerPlanesAll",
        data: "{idObraSocial: '" + idObraSocial + "'}",
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        async: false,
        success: function (data) {

            var planes = JSON.parse(data.d);
            var planesArr = [];
            if (planes.length > 0) {
                planes.forEach(function (e) {
                    var idPlanObra = e.ID_PLANES;
                    var descripcion = e.DESCRIPCION;
                    var fechaBaja;
                    var Acciones = '';

                    if (e.FECHA_BAJA == null) {
                        Acciones = '<a href="#" onclick="return actualizarPlan(' + idPlanObra + ",'" + descripcion + "'" + ')"  class="btn btn-primary" > <span class="fa fa-pencil" title="Modificar"></span></a> ' +
                            '<a href="#" onclick="return inactivarPlan(' + idPlanObra + ",'" + descripcion + "'" + ",'" + idObraSocial + "'" + ')"  class="btn btn-danger btnInactivar" > <span class="fa fa-trash" title="Dar de baja"></span></a > ';
                        fechaBaja = null;
                    } else {
                        fechaBaja = moment(e.FECHA_BAJA).format("DD/MM/YYYY");
                    }

                    planesArr.push([idPlanObra, descripcion, fechaBaja, Acciones]);
                });
            }

            var table = $('#tablaPlanesOS').DataTable({
                data: planesArr,
                "scrollX": false,
                "languaje": {
                    "url": "//cdn.datatables.net/plug-ins/1.10.12/i18n/Spanish.json"
                },
                "ordering": true,
                "bDestroy": true,
                "order": [[1, 'asc']],
                "bAutoWidth": true,
                columns: [
                    { title: "ID", visible: false },
                    { title: "Plan", visible: true },
                    { title: "Fecha de Baja", visible: true },
                    { title: "Acciones" }
                ],
                dom: '<"top"B>rti<"bottom"fp><"clear">',
                "oLanguage": {
                    "sSearch": "Filtrar:",
                    "oPaginate": {
                        "sPrevious": "Anterior",
                        "sNext": "Siguiente"
                    }
                },
                "rowCallback": function (row, data, index) {
                    if (data[2] != null) { //tiene fecha de baja

                        $('td', row).css('background-color', '#C40000');
                        $('td', row).css('color', 'rgba(255, 255, 255, .8)');
                        $('td', row).css('pointer-events', 'none');

                    }
                },
                "bPaginate": true,
                "pageLength": 3,
                buttons: [
                    { extend: 'colvis', columns: ':not(:first-child)', text: "Ocultar/Mostrar columnas" }
                ]
            });
            $('.dataTables_filter input').attr("placeholder", "Filtrar por...");
        },
        error: function (xhr, ajaxOptions, thrownError) {

        }
    })
}


function actualizarPlan(idPlanObra, descripcion) {

    console.log(idPlanObra, descripcion);
    

    idPlan = idPlanObra;

    $.ajax({
        type: "POST",
        url: "ObrasSociales.aspx/cargarPlan",
        data: "{idPlan: '" + idPlanObra + "'}",
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        async: false,
        success: function (data) {
            
            $("#modalEditarPlan").modal('show');
            $("#modalEditarObraS").modal('hide');
            $("#id__AtxtPlan").val(data.d.Descripcion);

        },
        error: function (xhr, ajaxOptions, thrownError) {

        }
    })

}


$('#btnCerrar').click(function () {
    $("#modalEditarObraS").modal('show');
});


$('#btnActualizarPlan').click(function () {

    var plan = $("#id__AtxtPlan").val();
    updatePlan(idPlan, plan, idObraSocial);

});


function updatePlan(idPlan, plan, idObraSocial) {

    var datosPlan = {
        p_id: idPlan,
        p_descripcion: plan
    }

    $.ajax({
        type: "POST",
        url: "ObrasSociales.aspx/editarPlan",
        data: JSON.stringify(datosPlan),
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        async: false,
        success: function (data) {

            if (data.d != 'OK') {
                swal("Hubo un problema", "Error al actualizar el plan", "error"); //error
            } else {
                swal("Hecho", "Plan actualizado con Éxito!", "success"); //error
                $("#modalEditarPlan").modal('hide');
                $("#modalEditarObraS").modal('show');
                cargarTablaPlanes(idObraSocial);
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {

        }
    })

}



function inactivarPlan(idPlan, descripcion, idObraSocial) {
    $.ajax({
        url: "ObrasSociales.aspx/darBajaPlan",
        data: "{idPlan: '" + idPlan + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            swal("Hecho", "Se dio de baja a " + descripcion + " y sus planes.", "success");

            cargarTablaPlanes(idObraSocial);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(data.error);
        }
    });

}

function cargarComboCentros(ddl) {

    $.ajax({
        url: "RegistrarTurno.aspx/cargarCentros",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            if (data.d.length > 0) {
                $(ddl).empty();
                $(ddl).append('<option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>');

                for (i = 0; i < data.d.length; i++) {

                    $(ddl).append($("<option></option>").val(data.d[i].IdCentro).html(data.d[i].NombreCentro));
                }
                $(ddl).prop("disabled", false);
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            $(ddl).prop("disabled", true);
            alert(data.error);
        }
    });
}

function soloNumeros(event) {
    var regex = new RegExp("^[0-9]+$");
    var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
    if (!regex.test(key)) {
        event.preventDefault();
        return false;
    }
};


function soloLetras(event) {
    var regex = new RegExp("^[a-zA-Z ]+$");
    var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
    if (!regex.test(key)) {
        event.preventDefault();
        return false;
    }
};