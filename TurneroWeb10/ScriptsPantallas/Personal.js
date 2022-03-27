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

var tabla, data, id, idN;



$(document).ready(function () {

    sendDataPersonal();

    $('#btnRegistrarModal').click(function () {
        $("#modalRegistrar").modal('show');
    });


    $('#btnRegistrar').click(function () {

        dni = $('#id__txtDocumento').val();
        nombre = $('#id__txtNombre').val();
        apellido = $('#id__txtApellido').val();
        fechaNac = $('#id__dtpFechaNac').val();
        calle = $('#id__txtCalle').val();
        numero = $('#id__txtNumero').val();
        barrio = $('#id__txtBarrio').val();
        localidad = $('#id__txtLocalidad').val();
        celular = $('#id__txtCelular').val();
        email1 = $('#id__txtEmail1').val();
        email2 = $('#id__txtEmail2').val();

        var validacion = validarDatosPersonal();

        if (validacion === true) {

            var personal = {

                p_dni: dni,
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

            registrarPersonal(personal);
        }

    });

});

function validarDatosPersonal() {

    if (dni == null) {
        alert("Por favor, ingrese DNI");
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



function registrarPersonal(datosPersonal) {
    $.ajax({
        url: "RegistrarPersonal.aspx/registrarPersonal",
        data: JSON.stringify(datosPersonal),
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            if (data.d != 'OK') {

                swal("Hubo un problema", "Error al registrar el personal!", "error"); //error

            } else {
                //$('#btnConfProfesional').show();
                $("#modalRegistrar").modal('hide');
                swal("Hecho", "Personal registrado con Éxito!", "success"); //error
                //$("#tabla_profesionales").DataTable().fnClearTable();
                sendDataPersonal();   
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(data.error);
        }

    });

}


function sendDataPersonal() {
    $.ajax({
        type: "POST",
        url: "RegistrarPersonal.aspx/cargarPersonal",
        data: {},
        contentType: 'application/json; charset=utf-8',
        async: false,
        success: function (data) {

            var arrayPersonal = new Array();

            for (var i = 0; i < data.d.length; i++) {

                var fechaNac = data.d[i].FechaNacimiento;
                var DateFechaNac = mostrarFecha(fechaNac);
                var Numero = data.d[i].IdPersonal;
                var Personal = (data.d[i].Nombre + ", " + data.d[i].Apellido);
                var DNI = data.d[i].Documento;
                var Nacimiento = DateFechaNac;//data[i].fechaNac,
                var Contacto = data.d[i].NroContacto;
                var Email = data.d[i].EmailContacto;
                var Domicilio = (data.d[i].Domicilio + ", " + data.d[i].Localidad);

                var jsonStr = '["' + DateFechaNac + '", "' + Numero + '", "' + Personal + '", "' + DNI + '", "' + Nacimiento + '","' + Contacto + '","' + Email + '","' + Domicilio + '"]';
                //const array = JSON.parse(jsonStr);


                var Acciones = '<a href="#" onclick="return actualizar(' + Numero + ')"  class="btn btn-primary" > <span class="fas fa-user-edit"></span></a > ' +
                    '<a href="#" onclick="return inactivar(' + Numero + ",'" + Personal + "'" + ')"  class="btn btn-danger btnInactivar" > <span class="fas fa-user-minus"></span></a > ';

                //' + "'"+ Numero +"'"+ '
                arrayPersonal.push([
                    Numero, Personal, DNI, Nacimiento, Contacto, Email, Domicilio, Acciones
                ])
            }

            var table = $('#tabla_PersonalAdmin').DataTable({
                data: arrayPersonal,
                "scrollX": true,
                "languaje": {
                    "url": "//cdn.datatables.net/plug-ins/1.10.12/i18n/Spanish.json"
                },
                "ordering": true,
                "bDestroy": true,
                "bAutoWidth": true,
                columns: [
                    { title: "Numero", visible: false },
                    { title: "Personal" },
                    { title: "DNI" },
                    { title: "Nacimiento" },
                    { title: "Contacto" },
                    { title: "Email" },
                    { title: "Domicilio" },                   
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


function actualizar(idBuscar) {

    id = idBuscar;

    $.ajax({
        type: "POST",
        url: "RegistrarPersonal.aspx/buscaPersonal",
        data: "{idPersonal: '" + idBuscar + "'}",
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        async: false,
        success: function (data) {

            $("#modalEditar").modal('show');

            $("#txtNombreA").val(data.d.Nombre);
            $("#txtApellidoA").val(data.d.Apellido);
            $("#id__txtDocumentoE").val(data.d.Documento);            
            $("#txtLocalidadA").val(data.d.Localidad);
            $("#id__dtpFechaNacE").val(mostrarFecha(data.d.FechaNacimiento));
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


$("#btnActualizar").click(function (e) {
    e.preventDefault();
    UpdateDataPersonal(id);

    //$("#tabla_profesionales").DataTable().fnClearTable();
    
    $("#modalEditar").modal('hide');

});


function UpdateDataPersonal(id) {

    var obj = JSON.stringify({
        id: id,
        nombre: $("#txtNombreA").val(),
        apellido: $("#txtApellidoA").val(),
        dni: $("#id__txtDocumentoE").val(),       
        fechaNacimiento: $("#id__dtpFechaNacE").val(),
        localidad: $("#txtLocalidadA").val(),
        barrio: $("#txtBarrioA").val(),
        direccion: $("#txtDomicilio").val(),
        celular: $("#txtCelularA").val(),
        email1: $("#txtEmail1A").val(),
        email2: $("#txtEmail2A").val()
    })

    $.ajax({
        type: "POST",
        url: "RegistrarPersonal.aspx/actualizarPersonal",
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
                swal("Hubo un problema", "Error al actualizar los datos del personal.", "error");
            }
            else {
                $('#btnActfProfesional').show();
                swal("Hecho", "Los datos del personal se actualizaron con Éxito.", "success");
                sendDataPersonal();
            }
            //console.log(response);
        }
    })
}



function inactivar(id, nombre) {

    var IdPersonal = id;
    var nomApePersonal = nombre;
    console.log(IdPersonal);

    $.ajax({
        url: "RegistrarPersonal.aspx/darBajaPersonal",
        data: "{idPersonal: '" + IdPersonal + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            swal("Hecho", "Se dio de baja exitosamente a " + nomApePersonal + ".", "success");

            sendDataPersonal();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(data.error);
        }
    });
}