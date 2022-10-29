
var centro, calle, numero, barrio, localidad, telefono, email1, email2, table, data, id;


$(document).ready(function () {

    sendDataCentros();

    $('#btnRegistrar').click(function () {

        centro = $('#id__txtNombre').val();
        calle = $('#id__txtCalle').val();
        numero = $('#id__txtNumero').val();
        barrio = $('#id__txtBarrio').val();
        localidad = $('#id__txtLocalidad').val();
        telefono = $('#id__txtTelefono').val();
        celular = $('#id__txtCelular').val();
        email1 = $('#id__txtEmail1').val();
        email2 = $('#id__txtEmail2').val();

       
        var validacion = validarDatosCentro();

        if (validacion === true) {

            var sucursal = {

                p_nombre: centro,
                p_domicilio: calle,
                p_numero: numero,
                p_barrio: barrio,
                p_localidad: localidad,
                p_email1: email1,
                p_email2: email2,
                p_celular: celular,
                p_telefono: telefono

            }

            console.log(sucursal);
            registrarCentros(sucursal);


        }
        else {
            console.log("Error en validación de datos del centro");
        }

    });
});

$('#btnRegistrarModal').click(function () {
    $("#modalRegistrar").modal('show');
});



function actualizarCentro(IdCentro) {
         

        id = IdCentro;

        $.ajax({
            type: "POST",
            url: "RegistrarCentros.aspx/obtenerCentro",
            data: "{idCentro: '" + IdCentro + "'}",
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            async: false,
            success: function (data) {
                                

                $("#modalEditar").modal('show');

                $("#id__txtNombreE").val(data.d.NombreCentro);
                var direccion = data.d.DomicilioCentro.split('Barrio:');
                $("#id__txtDomicilioE").val(direccion[0]);
                $("#id__txtBarrioE").val(direccion[1]);           
                $("#id__txtLocalidadE").val(data.d.LocalidadCentro);
                var email = data.d.EmailCentro.split('@');
                $("#id__txtEmail1E").val(email[0]);
                $("#id__txtEmail2E").val(email[1]);
                $("#id__txtTelefonoE").val(data.d.NroCentro1);
                $("#id__txtCelularE").val(data.d.NroCentro2);

            },
            error: function (xhr, ajaxOptions, thrownError) {

            }
        })
    };



$("#btnActualizar").click(function (e) {
        e.preventDefault();
        UpdateDataCentros(id);        
    });

function registrarCentros(datosCentro) {
        $.ajax({
            url: "RegistrarCentros.aspx/registrarCentros",
            data: JSON.stringify(datosCentro),
            type: "post",
            contentType: "application/json",
            async: false,
            success: function (data) {

                if (data.d != 'OK') {
                    swal("Hubo un problema", "Error al registrar el centro", "error"); //error
                } else {
                    $("#modalRegistrar").modal('hide');
                    swal("Hecho", "Centro de Atención registrado con Éxito!", "success"); //error
                    //$("#tabla_profesionales").DataTable().fnClearTable();
                    sendDataCentros();

                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(data.error);
            }

        });

};

function validarDatosCentro() {

        if (centro == "") {
            alert("Por favor, ingrese el nombre del centro");
            return false;
        }
        else if (calle == "") {
            alert("Por favor, ingrese Domicilio");
            return false;
        }
        else if (localidad == null) {
            alert("Por favor, ingrese localidad del centro");
            return false;
        }
        else if (email1 == null) {
            alert("Por favor, ingrese correctamente la dirección del Email");
            return false;
        }
        else if (email2 == "") {
            alert("Por favor, ingrese correctamente la dirección del Email");
            return false;
        }
        else if (celular == "") {
            alert("Por favor, un numero de contacto");
            return false;
        }
        else {
            return true;
        };
};

function sendDataCentros() {
        $.ajax(
            {
                type: "POST",
                url: "RegistrarCentros.aspx/traerCentros",
                data: {},
                contentType: 'application/json; charset=utf-8',
                async: false,
                success: function (data) {

                    var arrayCentros = new Array();

                    for (var i = 0; i < data.d.length; i++) {

                        var Numero = data.d[i].IdCentro;
                        var Nombre = data.d[i].NombreCentro;
                        var Domicilio = data.d[i].DomicilioCentro + ", " + data.d[i].LocalidadCentro;
                        var Email = data.d[i].EmailCentro;
                        var NroCentro1 = data.d[i].NroCentro1;
                        var NroCentro2 = data.d[i].NroCentro2;

                        var jsonStr = '["' + Nombre + '", "' + Numero + '", "' + Domicilio + '", "' + Email + '", "' + NroCentro1 + '","' + NroCentro2 + '"]';
                        var Acciones = '<a href="#" button title= "editarCentro"  onclick="return actualizarCentro(' + Numero + ')"  class="btn btn-primary btn-editar"> <span class="fas fa-user-edit" aria-hidden="true"></span></a >' +
                            '<a href="#" onclick = "return inactivar(' + Numero + ", '" + Nombre + "'" + ')"  class="btn btn-danger btn-inactivar" > <span class="fas fa-user-minus"></span></a >';
                                                
                        arrayCentros.push([
                            Numero, Nombre, Domicilio, Email, NroCentro1, NroCentro2, Acciones
                        ])
                    }

                    var table = $('#tabla_Centros').DataTable({
                        data: arrayCentros,
                        "scrollX": true,
                        "languaje": {
                            "url": "//cdn.datatables.net/plug-ins/1.10.12/i18n/Spanish.json"
                        },
                        "ordering": true,
                        "bDestroy": true,
                        "bAutoWidth": true,
                        columns: [
                            { title: "Numero", visible: false },
                            { title: "Centro" },
                            { title: "Domicilio" },                   
                            { title: "Email" },
                            { title: "Telefono" },
                            { title: "Celular" },
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


//function inactivar(id, nombre) {

//    var IdCentro = id;
//    var nombreCentro = nombre;

//    $.ajax({
//        url: "RegistrarCentros.aspx/darBajaCentro",
//        data: "{p_id: '" + IdCentro + "'}",
//        type: "post",
//        contentType: "application/json",
//        async: false,
//        success: function (data) {

//            swal("Hecho", "Se dio de baja exitosamente a " + nombreCentro+ ".", "success");

//            sendDataCentros();
//        },
//        error: function (xhr, ajaxOptions, thrownError) {
//            alert(data.error);
//        }
//    });
//}


function UpdateDataCentros(id) {

    var obj = JSON.stringify({
        p_id: id,
        p_centro: $('#id__txtNombreE').val(),
        p_domicilio: $('#id__txtDomicilioE').val(),
        p_barrio: $('#id__txtBarrioE').val(),
        p_localidad: $('#id__txtLocalidadE').val(),
        p_telefono: $('#id__txtTelefonoE').val(),
        p_celular: $('#id__txtCelularE').val(),
        p_email1: $('#id__txtEmail1E').val(),
        p_email2: $('#id__txtEmail2E').val()

    });

   
    $.ajax({
        type: "POST",
        url: "RegistrarCentros.aspx/actualizarCentros",
        data: obj,
        dataType: "json",
        contentType: 'application/json; charset=utf-8',     
        success: function (response) {

                if (response.d != 'OK') {
                    swal("Hubo un problema", "Error al actualizar datos del centro.", "error");
                }
                else {
                    swal("Hecho", "Los datos del centro se actualizaron con Éxito.", "success");
                    $("#modalEditar").modal('hide');
                    sendDataCentros();

                }          
        },
           error: function (xhr, ajaxOptions, thrownError) {
        }
        })
    }


