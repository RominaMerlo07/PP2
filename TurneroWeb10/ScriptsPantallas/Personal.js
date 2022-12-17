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

var tabla, data, id, idN, idBuscar;



$(document).ready(function () {

    sendDataPersonal();

    $('#btnRegistrarModal').click(function () {
        $("#modalRegistrar").modal('show');
        limpiarCampos();
        deshabilitarCampos(true);
    });


    $('#btnRegistrar').click(function () {

        dni = $('#id__txtDocumento').val();
        nombre = $('#id__txtNombre').val();
        apellido = $('#id__txtApellido').val();
        fechaNac = $('#id__dtpFechaNac').val();
        calle = $('#id__txtCalle').val();
        numero = $('#id__txtNumero').val();
        piso = $('#id__txtPiso').val();
        dpto = $('#id__txtDpto').val();
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
                p_piso: piso,
                p_dpto: dpto,
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
                swal("Hecho", "Personal registrado con Éxito!", "success");
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

                idBuscar = Numero;

                var Acciones = '<a href="#" id="editar" onclick="return actualizar(' + Numero + ')"  class="btn btn-primary" > <span class="fas fa-user-edit" title="Modificar"></span></a > ' +
                    '<a href="#" onclick="return inactivar(' + Numero + ",'" + Personal + "'" + ')"  class="btn btn-danger btnInactivar" > <span class="fas fa-user-minus" title="Dar de baja"></span></a > ';

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
                    {
                        extend: 'pdf',
                        orientation: 'landscape',
                        exportOptions: {
                            columns: [1, 2, 3, 4, 5, 6]
                        },
                        title: '',
                        customize: function (doc) {
                            printDataTable(doc, "PERSONAL ADMINISTRATIVO")
                        }
                    },
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

            $("#id__AtxtNombre").val(data.d.Nombre);
            $("#id__AtxtApellido").val(data.d.Apellido);
            $("#id__AtxtDocumento").val(data.d.Documento);            
            $("#id__AtxtLocalidad").val(data.d.Localidad);
            $("#id__AdtpFechaNacE").val(mostrarFecha(data.d.FechaNacimiento));
            //var direccion = data.d.Domicilio.split('Barrio:');

            var calle_num = data.d.Domicilio.split('Piso:');
            var pisoDpto = calle_num[1].split('Dpto:');
            var barrio = pisoDpto[1].split('Barrio:');
            $("#id__AtxtDomicilio").val(calle_num[0]);
            $("#id__AtxtPiso").val(pisoDpto[0]);
            $("#id__AtxtDpto").val(barrio[0]);
            $("#id__AtxtBarrio").val(barrio[1]);

            //$("#id__AtxtDomicilio").val(direccion[0]);
            //$("#id__AtxtBarrio").val(direccion[1]);

            $("#id__AtxtCelular").val(data.d.NroContacto);
            var email = data.d.EmailContacto.split('@');
            $("#id__AtxtEmail1").val(email[0]);
            $("#id__AtxtEmail2").val(email[1]);
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
        nombre: $("#id__AtxtNombre").val(),
        apellido: $("#id__AtxtApellido").val(),
        dni: $("#id__AtxtDocumento").val(),       
        fechaNacimiento: $("#id__AdtpFechaNacE").val(),
        localidad: $("#id__AtxtLocalidad").val(),
        barrio: $("#id__AtxtBarrio").val(),
        direccion: $("#id__AtxtDomicilio").val(),
        piso: $("#id__AtxtPiso").val(),
        dpto: $("#id__AtxtDpto").val(),
        celular: $("#id__AtxtCelular").val(),
        email1: $("#id__AtxtEmail1").val(),
        email2: $("#id__AtxtEmail2").val()
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
    

    swal({
        title: "¿Estas seguro que deseas eliminar a " + nombre + "?",
        text: "Una vez eliminado, ¡no podrá recuperar los datos asociados al mismo!",
        icon: "warning",
        buttons: true,
        buttons: ["Cancelar", "Eliminar"],
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
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


function deshabilitarCampos(valor) {

    //document.getElementById("id__txtDocumento").focus();   

    document.getElementById("id__txtNombre").readOnly = valor;
    document.getElementById("id__txtApellido").readOnly = valor;
    document.getElementById("id__txtCalle").readOnly = valor;
    document.getElementById("id__txtNumero").readOnly = valor;
    document.getElementById("id__txtPiso").readOnly = valor;
    document.getElementById("id__txtDpto").readOnly = valor;
    document.getElementById("id__txtBarrio").readOnly = valor;
    document.getElementById("id__txtLocalidad").readOnly = valor;
    document.getElementById("id__txtCelular").readOnly = valor;
    document.getElementById("id__txtEmail1").readOnly = valor;
    document.getElementById("id__txtEmail2").readOnly = valor;

}


function limpiarCampos() {
    $('#id__txtDocumento').val("");
    $('#id__txtNombre').val("");
    $('#id__txtApellido').val("");
    $('#id__dtpFechaNac').datepicker('clearDates');
    $('#id__txtCalle').val("");
    $('#id__txtNumero').val("");
    $('#id__txtPiso').val("");
    $('#id__txtDpto').val("");
    $('#id__txtBarrio').val("");
    $('#id__txtLocalidad').val("");
    $('#id__txtCelular').val("");
    $('#id__txtEmail1').val("");
    $('#id__txtEmail2').val("");
}


function emailFirst(event) {
    var regex = new RegExp("[a-zA-Z0-9-_.]+");
    var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
    if (!regex.test(key)) {
        event.preventDefault();
        return false;
    }
};