var descripcion, id;

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
    //$("#modalRegistrar").modal('show');
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