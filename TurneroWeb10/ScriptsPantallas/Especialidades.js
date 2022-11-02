var descripcion, id, idEspecialidades;

$(document).ready(function () {

    sendDataEspecialidad();

    $('#btnRegistrar').click(function () {

        var validacion = validarDatosEspecialidad();

        if (validacion === true) {

            var especialidades = {

                p_descripcion: $('#id__txtNombre').val()
            }

            console.log(especialidades);
            registrarEspecialidades(especialidades);
        }

        else {
            console.log("No valide datos o sali por error");

        }

    });

});

$('#btnRegistrarModal').click(function () {
    $("#modalRegistrar").modal('show');
});


function registrarEspecialidades(datosEspecialidades) {
    $.ajax({
        url: "RegistrarEspecialidades.aspx/registrarEspecialidades",
        data: JSON.stringify(datosEspecialidades),
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            if (data.d != 'OK') {
                swal("Hubo un problema", "Error al registrar la especialidad", "error"); //error
            } else {
                swal("Hecho", "Especialidad registrada con Éxito!", "success"); //error
                $("#modalRegistrar").modal('hide');
                sendDataEspecialidad();

                limpiarCampos();

            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(thrownError);
        }

    });

}

function validarDatosEspecialidad() {

    if (descripcion == "") {
        alert("Por favor, ingrese el nombre de la especialidad a agregar");
        return false;
    }
    else {
        return true;
    };
};


function sendDataEspecialidad() {
    $.ajax(
        {
            type: "POST",
            url: "RegistrarProfesional.aspx/cargarEspecialidades",
            data: {},
            contentType: 'application/json; charset=utf-8',
            async: false,
            success: function (data) {

                var arrayEspecialidades = new Array();

                for (var i = 0; i < data.d.length; i++) {

                    var Numero = data.d[i].IdEspecialidad;
                    var Nombre = data.d[i].Descripcion;
                    

                   
                    var Acciones = '<a href="#" button title= "editarEspecialidad"  onclick="return actualizarEspecialidad(' + Numero + ')"  class="btn btn-primary btn-editar"> <span class="fas fa-user-edit" aria-hidden="true"></span></a >' +
                        '<a href="#" onclick = "return inactivar(' + Numero + ", '" + Nombre + "'" + ')"  class="btn btn-danger btn-inactivar" > <span class="fas fa-user-minus"></span></a >';

                    arrayEspecialidades.push([
                        Numero, Nombre, Acciones
                    ])
                }

                var table = $('#tabla_Especialidades').DataTable({
                    data: arrayEspecialidades,
                    "scrollX": true,
                    "languaje": {
                        "url": "//cdn.datatables.net/plug-ins/1.10.12/i18n/Spanish.json"
                    },
                    "ordering": true,
                    "bDestroy": true,
                    "bAutoWidth": true,
                    columns: [
                        { title: "Numero", visible: false },
                        { title: "Especialidad" },
                        { title: "Acciones" },
                        
                    ],
                    dom: 'Bfrtip',
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
                        { extend: 'print', text: "Imprimir" },
                        { extend: 'pdf', orientation: 'landscape' },
                        { extend: 'colvis', columns: ':not(:first-child)', text: "Ocultar/Mostrar columnas" }
                    ]
                });

            },
            error: function (xhr, ajaxOptions, thrownError) {
                //$(ddl).prop("disabled", true);
                //alert(data.error);
                console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
            }
        })
}

function actualizarEspecialidad(IdEspecialidad) {


    id = IdEspecialidad;

    $.ajax({
        type: "POST",
        url: "RegistrarEspecialidades.aspx/cargarEspecialidades",
        data: "{IdEspecialidad: '" + IdEspecialidad + "'}",
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        async: false,
        success: function (data) {
            
            $("#modalEditar").modal('show');
            $("#id__txtNombreE").val(data.d.Descripcion);           

        },
        error: function (xhr, ajaxOptions, thrownError) {

        }
    })
};


$('#btnActualizar').click(function () {

    var nombreEspecialidad = $("#id__txtNombreE").val();
    editarEspecialidad(id, nombreEspecialidad);
});


function editarEspecialidad(id, nombreEspecialidad) {

   
    var datosEspecialidad = {
        p_IdEspecialidad: id,
        p_descripcion: nombreEspecialidad
    } 

    $.ajax({
        type: "POST",
        url: "RegistrarEspecialidades.aspx/editarEspecialidad",
        data: JSON.stringify(datosEspecialidad),
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        async: false,
        success: function (data) {

            if (data.d != 'OK') {
                swal("Hubo un problema", "Error al actualizar la especialidad", "error"); //error
            } else {
                swal("Hecho", "Especialidad actualizada con Éxito!", "success"); //error
                $("#modalEditar").modal('hide');
                sendDataEspecialidad();
            }                   
        },
        error: function (xhr, ajaxOptions, thrownError) {

        }
    })
};



function inactivar(id, descripcion) {

    idEspecialidades = id;    
 
    $.ajax({
        url: "RegistrarEspecialidades.aspx/ObtenerTurnosFuturos",
        data: "{p_id: '" + id + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            if (data.d === 'sin info') {
                console.log('puedo eliminar directo');

                swal({
                    title: "¿Estas seguro que deseas eliminar la especialidad " + descripcion + "?",
                    text: "Una vez eliminada, ¡no podrá recuperar los datos asociadas al mismo!",
                    icon: "warning",
                    buttons: true,
                    buttons: ["Cancelar", "Eliminar"],
                    dangerMode: true,
                })
                    .then((willDelete) => {
                        if (willDelete) {
                            darBajaEspecialidad(id, descripcion);
                        }
                    });
            }
            else {
                console.log("tengo que mostrar los turnos pendientes");
                ObtenerTurnosFuturos(id);
                $("#modalTurnos").modal('show');
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(thrownError);
        }
    });

}


function ObtenerTurnosFuturos(id) {

    var turnos;
    $.ajax({
        type: "POST",
        url: "RegistrarEspecialidades.aspx/MostrarTurnosFuturos",
        data: "{p_id: '" + id + "'}",
        contentType: 'application/json; charset=utf-8',
        async: false,
        success: function (data) {

            turnos = JSON.parse(data.d);

            var arrayTurnos = new Array();

            turnos.forEach(function (e) {

                var turno = e.TURNO;
                var hora = e.HORA;
                var paciente = e.PACIENTE;
                var contacto = e.NRO_CONTACTO;
                var email = e.EMAIL_CONTACTO;

                arrayTurnos.push([turno, hora, paciente, contacto, email]);

                console.log(arrayTurnos);

            });

            var table = $('#tabla_Especialidad').DataTable({
                data: arrayTurnos,
                "scrollX": true,
                "languaje": {
                    "url": "//cdn.datatables.net/plug-ins/1.10.12/i18n/Spanish.json"
                },
                "ordering": true,
                "bDestroy": true,
                "bAutoWidth": true,
                columns: [
                    { title: "Turno" },
                    { title: "Hora" },
                    { title: "Paciente" },
                    { title: "Contacto" },
                    { title: "Email" },
                ],
                dom: 'Bfrtip',
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
                    { extend: 'print', text: "Imprimir" },
                    { extend: 'pdf', orientation: 'landscape' },
                    { extend: 'colvis', columns: ':not(:first-child)', text: "Ocultar/Mostrar columnas" }
                ]
            });

        },
        error: function (xhr, ajaxOptions, thrownError) {
            //$(ddl).prop("disabled", true);
            //alert(data.error);
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        }
    })
};


$("#btnCancelar").click(function (e) {
    e.preventDefault();
    $("#modalTurnos").modal('hide');
});

$("#btnEliminar").click(function (e) {
    e.preventDefault();
    DarDeBajaTurnos(idEspecialidades, descripcion);
});

function DarDeBajaTurnos(idEspecialidades, descripcion) {

 //   console.log(idEspecialidades);

    $.ajax({
        url: "RegistrarEspecialidades.aspx/DarDeBajaTurnos",
        data: "{p_id: '" + idEspecialidades + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            console.log(data.d);

            if (data.d != 'OK') {
                swal("Hubo un problema", "Error al eliminar la especialidad.", "error");
            }
            else {
                swal("Hecho", "La especialidad " + descripcion + " se elimino con Éxito, y los turnos fueron cancelados.", "success");
                $("#modalTurnos").modal('hide');
                sendDataEspecialidad();
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(thrownError);
        }
    });

}


function darBajaEspecialidad(id, descripcion) {

    console.log(id, descripcion);

    $.ajax({
        url: "RegistrarEspecialidades.aspx/darBajaEspecialidad",
        data: "{p_id: '" + id + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            if (data.d == "OK") {
                swal("La especialidad " + descripcion + " fue eliminada con Éxito!.", {
                    icon: "success",
                });
                sendDataEspecialidad();
            }
            else {
                swal("Hubo un problema", "Error al eliminar la especialidad.", "error");
            }

        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(data.error);
            return false;

        }
    });
}


function limpiarCampos() {
    $('#id__txtNombre').val("");
    //$('#id__txtMatricula').val("");
    //$('#ddlEspecialidad').val([]);
    //$('#id__txtNombre').val("");
    //$('#id__txtApellido').val("");
    //$('#id__dtpFechaNac').datepicker('clearDates');
    //$('#id__txtCalle').val("");
    //$('#id__txtNumero').val("");
    //$('#id__txtBarrio').val("");
    //$('#id__txtLocalidad').val("");
    //$('#id__txtCelular').val("");
    //$('#id__txtEmail1').val("");
    //$('#id__txtEmail2').val("");
}