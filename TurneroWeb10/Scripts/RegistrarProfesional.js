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

$(document).ready(function () {

    cargarEspecialidades("#ddlEspecialidad");

    $('.date').datepicker({
        autoclose: true,
        format: "dd/mm/yyyy"
    });


    $('#tabla_profesionales').dataTable({
        "bPaginate": false,
        "oLanguage": {
            "sInfo": ""
        }
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
            console.log(profesional);
            registrarProfesional(profesional);
            limpiarCampos();
        }
        else {
            console.log("No valide datos o sali por error");
        }

    });
});

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
                alert('Error al registrar el profesional.')
            } else {
                $('#btnConfProfesional').show();
                alert('profesional registrado con Éxito.');
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(data.error);
        }

    });
}

function validarDatosProfesional() {

    if (dni == "") {
        alert("Por favor, ingrese DNI");
        return false;
    }
    else if (matricula == "") {
        alert("Por favor, ingrese Matricula");
        return false;
    }
    else if (especialidades.length < 1) {
        alert("Por favor, seleccionar Especialidades");
        return false;
    }
    else if (nombre == null) {
        alert("Por favor, ingrese Nombre");
        return false;
    }
    else if (apellido == null) {
        alert("Por favor, ingrese Apellido");
        return false;
    }
    else if (fechaNac == "") {
        alert("Por favor, ingrese Fecha de Nacimiento");
        return false;
    }
    else if (calle == "") {
        alert("Por favor, ingrese Calle");
        return false;
    }
    else if (numero == "") {
        alert("Por favor, ingrese Numero");
        return false;
    }
    else if (barrio == "") {
        alert("Por favor, ingrese Barrio");
        return false;
    }
    else if (localidad == "") {
        alert("Por favor, ingrese Localidad");
        return false;
    }
    else if (celular == "") {
        alert("Por favor, ingrese un telefono de contacto");
        return false;
    }
    else if (email1 == "") {
        alert("Por favor, ingrese un E-mail válido");
        return false;
    }
    else if (email2 == "") {
        alert("Por favor, ingrese un E-mail válido");
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

var tabla, data, id;

function addRowProfesionales(data) {
    tabla = $("#tabla_profesionales").DataTable();
    for (var i = 0; i < data.length; i++) {
        tabla.fnAddData([
            data[i].IdProfesional,
            (data[i].Nombre + ", " + data[i].Apellido),
            data[i].Documento,
            data[i].NroMatricula,
            //data[i].fechaNac, ************************* VER COMO DAR FORMATO DD/MM/YYYY ******************************
            data[i].NroContacto,
            data[i].EmailContacto,
            (data[i].Domicilio + ", " + data[i].Localidad),
            '<button title= "Consultar Especialidades" class="btn btn-warning btn-especialidades"><i class="fas fa-user-tag aria-hidden="true"></i> Consultar </button>',
            '<button title= "Actualizar" class="btn btn-primary btn-editar" data-target="#modalEditar" data-toggle="modal"><i class="fas fa-user-edit" aria-hidden="true"></i></button>&nbsp' +
            '<button title= "Inactivar" class="btn btn-danger btn-eliminar"><i class="fas fa-user-minus" aria-hidden="true"></i></button>'
        ])
    }

}

function sendDataProfesionales() {
    $.ajax(
        {
            type: "POST",
            url: "RegistrarProfesional.aspx/cargarProfesionales",
            data: {},
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOptions, thrownError) {
                //$(ddl).prop("disabled", true);
                //alert(data.error);
                console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                //console.log(data);
                addRowProfesionales(data.d);
            }
        })
}


$(document).on('click', '.btn-editar', function (e) {
    e.preventDefault();
    var row = $(this).parent().parent()[0];
    var data = tabla.fnGetData(row);
    fillModalData(data);
    console.log('clic en editar');
});

$(document).on('click', '.btn-eliminar', function (e) {
    e.preventDefault();
    console.log('clic en eliminar');
    var row = $(this).parent().parent()[0];
    var datos = tabla.fnGetData(row);
    console.log(datos);
});

$(document).on('click', '.btn-especialidades', function (e) {
    e.preventDefault();
    console.log('clic en especialidades');
});

function fillModalData(data) {

    var profesional = data[1].split(', ');
    var direccion = data[6].split(', ');
    var barrio = direccion[0].split(' Barrio: ');
    var email = data[5].split('@');
    var localidad = direccion[1];
    var domicilio = barrio[0];

    id = data[0];

    $("#txtNombreA").val(profesional[0]);
    $("#txtApellidoA").val(profesional[1]);
    $("#txtDocumentoA").val(data[2]);
    $("#txtMatriculaA").val(data[3]);
    $("#txtLocalidadA").val(localidad);
    $("#txtBarrioA").val(barrio[1]);
    $("#txtDomicilio").val(domicilio);
    $("#txtCelularA").val(data[4]);
    $("#txtEmail1A").val(email[0]);
    $("#txtEmail2A").val(email[1]);

}

$("#btnActualizar").click(function (e) {
    e.preventDefault();
    UpdateDataProfesionales(id);
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

    $.ajax(
        {
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
                    alert('Error al actualizar los datos del profesional.');
                }
                else {
                    $('#btnActfProfesional').show();
                    alert('Los datos del profesional se actualizaron con Éxito.');
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


sendDataProfesionales();