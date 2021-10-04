var dni;
var matricula;
var especialidades;
var nombre;
var apellido;
var fechaNac;

var calle;
var numero;
var barrio;
var localidad;
var celular;
var email1;
var email2;

var tabla, data, id;

$(document).ready(function () {

    sendDataProfesionales();
    cargarEspecialidades("#ddlEspecialidad");

    $('.date').datepicker({
        autoclose: true,
        format: "dd/mm/yyyy"
    });

    $('#btnRegistrar').click(function () {

        dni = $('#txtDocumento').val();
        matricula = $('#txtMatricula').val();
        especialidades = $('#ddlEspecialidad').val();
        nombre = $('#txtNombre').val();
        apellido = $('#txtApellido').val();
        fechaNac = $('#dtpFechaNac').val();
        calle = $('#txtCalle').val();
        numero = $('#txtNumero').val();
        barrio = $('#txtBarrio').val();
        localidad = $('#txtLocalidad').val();
        celular = $('#txtCelular').val();
        email1 = $('#txtEmail1').val();
        email2 = $('#txtEmail2').val();

        var validacion = validarDatosProfesional();

        if (validacion === true) {

            var profesional = {

                p_dni: dni,
                p_matricula: matricula,
                p_especialidades: especialidades,
                p_nombre: nombre,
                p_apellido: apellido,
                p_fechaNac: fechaNac,
                p_calle: calle,
                p_numero: numero,
                p_barrio: barrio,
                p_localidad: localidad,
                p_celular: celular,
                p_email1: email1,
                p_email2: email2
            }
            //console.log(profesional);
            registrarProfesional(profesional);
            limpiarCampos();
        }
        else {
            console.log("No valide datos o sali por error");
        }

    });

    $('#btnRegistrarModal').click(function () {
        $("#modalRegistrar").modal('show');
    });

});

function actualizar(idBuscar) {

    id = idBuscar;

    $.ajax({
        type: "POST",
        url: "RegistrarProfesional.aspx/buscaProfesional",
        data: "{idProf: '" + idBuscar + "'}",
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        async: false,
        success: function (data) {
            
            $("#modalEditar").modal('show');

            $("#txtNombreA").val(data.d.Nombre);
            $("#txtApellidoA").val(data.d.Apellido);
            $("#txtDocumentoA").val(data.d.Documento);
            $("#txtMatriculaA").val(data.d.NroMatricula);
            $("#txtLocalidadA").val(data.d.Localidad);
            $("#dtpFechaNacA").val(mostrarFecha(data.d.FechaNacimiento));
            var direccion = data.d.Domicilio.split('Barrio:')
            $("#txtDomicilio").val(direccion[0]);
            $("#txtBarrioA").val(direccion[1]);

            $("#txtCelularA").val(data.d.NroContacto);
            var email = data.d.EmailContacto.split('@');
            $("#txtEmail1A").val(email[0]);
            $("#txtEmail2A").val(email[1]);
        },
        error: function (xhr, ajaxOptions, thrownError) {

        }
    })
}

function inactivar(id, nombre) {

    var IdProfesional = id;
    var nomApeProf = nombre;

    $.ajax({
        url: "RegistrarProfesional.aspx/darBajaProfesional",
        data: "{idProfesional: '" + IdProfesional + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            swal("Hecho", "Se dio de baja exitosamente a " + nomApeProf + ".", "success");

            sendDataProfesionales();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(data.error);
        }
    });
}

function limpiarCampos() {
    $('#txtDocumento').val("");
    $('#txtMatricula').val("");
    $('#ddlEspecialidad').val([]);
    $('#txtNombre').val("");
    $('#txtApellido').val("");
    $('#dtpFechaNac').datepicker('clearDates');
    $('#txtCalle').val("");
    $('#txtNumero').val("");
    $('#txtBarrio').val("");
    $('#txtLocalidad').val("");
    $('#txtCelular').val("");
    $('#txtEmail1').val("");
    $('#txtEmail2').val("");
}

function registrarProfesional(datosProfesional) {
    $.ajax({
        url: "RegistrarProfesional.aspx/registrarProfesional",
        data: JSON.stringify(datosProfesional),
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            if (data.d != 'OK') {

                swal("Hubo un problema", "Error al registrar el profesional!", "error"); //error
                
            } else {
                //$('#btnConfProfesional').show();
                $("#modalRegistrar").modal('hide');
                swal("Hecho", "Profesional registrado con Éxito!", "success"); //error
                //$("#tabla_profesionales").DataTable().fnClearTable();
                sendDataProfesionales();
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(data.error);
        }

    });
}

function validarDatosProfesional() {

    if (dni == "") {
        swal("Cuidado", "Por favor, ingrese DNI.", "warning");
        return false;
    }
    else if (matricula == "") {
        swal("Cuidado", "Por favor, ingrese Matricula.", "warning");
        return false;
    }
    else if (especialidades.length < 1) {
        swal("Cuidado", "Por favor, seleccionar Especialidades.", "warning");
        return false;
    }
    else if (nombre == null) {
        swal("Cuidado", "Por favor, ingrese Nombre.", "warning");
        return false;
    }
    else if (apellido == null) {
        swal("Cuidado", "Por favor, ingrese Apellido.", "warning");
        return false;
    }
    else if (fechaNac == "") {
        swal("Cuidado", "Por favor, ingrese Fecha de Nacimiento.", "warning");
        return false;
    }
    else if (calle == "") {
        swal("Cuidado", "Por favor, ingrese Calle.", "warning");
        return false;
    }
    else if (numero == "") {
        swal("Cuidado", "Por favor, ingrese Numero.", "warning");
        return false;
    }
    else if (barrio == "") {
        swal("Cuidado", "Por favor, ingrese Barrio.", "warning");
        return false;
    }
    else if (localidad == "") {
        swal("Cuidado", "Por favor, ingrese Localidad.", "warning");
        return false;
    }
    else if (celular == "") {
        swal("Cuidado", "Por favor, ingrese un telefono de contacto.", "warning");
        return false;
    }
    else if (email1 == "") {
        swal("Cuidado", "Por favor, ingrese un E-mail válido.", "warning");
        return false;
    }
    else if (email2 == "") {
        swal("Cuidado", "Por favor, ingrese un E-mail válido.", "warning");
        return false;
    }
    else {
        return true;
    };
};

function cargarEspecialidades(ddl) {
    $.ajax({
        url: "RegistrarProfesional.aspx/cargarEspecialidades",
        //data: "{idCentro: '" + idCentro + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            if (data.d.length > 0) {
                $(ddl).empty();
                $(ddl).append('<option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>');

                for (i = 0; i < data.d.length; i++) {

                    $(ddl).append($("<option></option>").val(data.d[i].IdEspecialidad).html(data.d[i].Descripcion));
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

function sendDataProfesionales() {
    $.ajax({
        type: "POST",
        url: "RegistrarProfesional.aspx/cargarProfesionales",
        data: {},
        contentType: 'application/json; charset=utf-8', 
        async: false,
        success: function (data) {

            var arrayProfesionales = new Array();

            for (var i = 0; i < data.d.length; i++) {

                var fechaNac = data.d[i].FechaNacimiento;
                var DateFechaNac = mostrarFecha(fechaNac);
                var Numero = data.d[i].IdProfesional;
                var Profesional = (data.d[i].Nombre + ", " + data.d[i].Apellido);
                var DNI = data.d[i].Documento;
                var Matricula = data.d[i].NroMatricula;
                var Nacimiento = DateFechaNac;//data[i].fechaNac, ************************* VER COMO DAR FORMATO DD/MM/YYYY ******************************
                var Contacto = data.d[i].NroContacto;
                var Email = data.d[i].EmailContacto;
                var Domicilio = (data.d[i].Domicilio + ", " + data.d[i].Localidad);

                var jsonStr = '["' + DateFechaNac + '", "' + Numero + '", "' + Profesional + '", "' + DNI + '", "' + Matricula + '", "' + Nacimiento + '","' + Contacto + '","' + Email + '","' + Domicilio + '"]';
                //const array = JSON.parse(jsonStr);

                var Especialidad = '<button title= "Consultar Especialidades" class="btn btn-warning btn-especialidades"><i class="fas fa-user-tag aria-hidden="true"></i> Consultar </button>';
                var Acciones = '<a href="#" onclick="return actualizar(' + Numero + ')"  class="btn btn-primary" > <span class="fas fa-user-edit"></span></a > ' +
                    '<a href="#" onclick="return inactivar(' + Numero + ",'" + Profesional + "'" +')"  class="btn btn-danger btnInactivar" > <span class="fas fa-user-minus"></span></a > ';
                

                //' + "'"+ Numero +"'"+ '
                arrayProfesionales.push([ 
                    Numero, Profesional, DNI, Matricula, Nacimiento, Contacto, Email, Domicilio, Especialidad, Acciones
                ])
            }

            var table = $('#tabla_profesionales').DataTable({
                data: arrayProfesionales,
                "scrollX": true,
                "languaje": {
                    "url": "//cdn.datatables.net/plug-ins/1.10.12/i18n/Spanish.json"
                },
                "ordering": true,
                "bDestroy": true,
                "bAutoWidth": true,
                columns: [
                    { title: "Numero", visible: false },
                    { title: "Profesional" },
                    { title: "DNI" },
                    { title: "Matricula" },
                    { title: "Nacimiento" },
                    { title: "Contacto" },
                    { title: "Email" },
                    { title: "Domicilio" },
                    { title: "Especialidad" },
                    { title: "Acciones" }
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
                "pageLength": 3,
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
            //console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        }
    })
}

//$(document).on('click', '.btn-especialidades', function (e) {
//    e.preventDefault();
//    console.log('clic en especialidades');
//});

$("#btnActualizar").click(function (e) {
    e.preventDefault();
    UpdateDataProfesionales(id);

    //$("#tabla_profesionales").DataTable().fnClearTable();
    sendDataProfesionales();
    $("#modalEditar").modal('hide');

});

function UpdateDataProfesionales(id) {

    var obj = JSON.stringify({
        id: id,
        nombre: $("#txtNombreA").val(),
        apellido: $("#txtApellidoA").val(),
        dni: $("#txtDocumentoA").val(),
        matricula: $("#txtMatriculaA").val(),
        fechaNacimiento: $("#dtpFechaNacA").val(),
        localidad: $("#txtLocalidadA").val(),
        barrio: $("#txtBarrioA").val(),
        direccion: $("#txtDomicilio").val(),
        celular: $("#txtCelularA").val(),
        email1: $("#txtEmail1A").val(),
        email2: $("#txtEmail2A").val()
    })

    $.ajax({
        type: "POST",
        url: "RegistrarProfesional.aspx/actualizarProfesional",
        data: obj,
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            //$(ddl).prop("disabled", true);
            //alert(data.error);
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (response) {

            if (response.d != 'OK') {
                swal("Hubo un problema", "Error al actualizar los datos del profesional.", "error");
            }
            else {
                $('#btnActfProfesional').show();
                swal("Hecho", "Los datos del profesional se actualizaron con Éxito.", "success");
            }
            //console.log(response);
        }
    })
}

function soloNumeros(e) {

    key = e.keyCode || e.which;
    teclado = String.fromCharCode(key);
    numeros = "0123456789";
    especiales = "8-37-38-46";
    teclado_especial = false;

    for (var i in especiales) {
        if (key == especiales[i]) {
            teclado_especial = true;
        }
    }

    if (numeros.indexOf(teclado) == -1 && !teclado_especial) {
        return false;
    }
}


function soloLetras(e) {

    key = e.keyCode || e.which;
    teclado = String.fromCharCode(key);
    numeros = "abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
    especiales = "8-37-38-46-164";
    teclado_especial = false;

    for (var i in especiales) {
        if (key == especiales[i]) {
            teclado_especial = true; break;
        }
    }

    if (numeros.indexOf(teclado) == -1 && !teclado_especial) {
        return false;
    }
}


