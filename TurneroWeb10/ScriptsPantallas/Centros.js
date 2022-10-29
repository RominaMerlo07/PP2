
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


        console.log(centro);
       
        //var validacion = validarDatosCentro();

        //if (validacion === true) {

        //    var centro = {

        //        p_nombre: nombre_centro,
        //        p_domicilio: domicilio_centro,
        //        p_localidad: localidad_centro,
        //        p_email1: email_centro_1,
        //        p_email2: email_centro_2,
        //        p_contacto_1: nro_contacto_1,
        //        p_contacto_2: nro_contacto_2

        //    }

        //    console.log(centro);
        //    registrarCentros(centro);
        //    sendDataCentros();
        //    $('input[type="text"]').val('');


        //}
        //else {
        //    console.log("Error en validación de datos del centro");
        //}

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

                $("#modalEditarCentro").modal('show');


                $("#txtNombre").val(data.d.NombreCentro);
                $("#txtDomicilio").val(data.d.DomicilioCentro);
                $("#txtLocalidad").val(data.d.LocalidadCentro);
                $("#txtEmail").val(data.d.EmailCentro);
                $("#txtNcontacto1").val(data.d.NroCentro1);
                $("#txtNcontacto2").val(data.d.NroCentro2);

            },
            error: function (xhr, ajaxOptions, thrownError) {

            }
        })
    };



    $("#btnActualizarCentro").click(function (e) {
        e.preventDefault();
        UpdateDataCentros(id);
       /* $("#tabla_centros").DataTable().fnClearTable();*/
        
        $("#modalEditarCentro").modal('hide');
        sendDataCentros();

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
                    alert('Error al registrar el centro.')
                } else {
                    alert('Centro registrado con Éxito.');

                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(data.error);
            }

        });

};

    function validarDatosCentro() {

        if (nombre_centro == "") {
            alert("Por favor, ingrese el nombre del centro");
            return false;
        }
        else if (domicilio_centro == "") {
            alert("Por favor, ingrese Domicilio");
            return false;
        }
        else if (localidad_centro == null) {
            alert("Por favor, ingrese localidad del centro");
            return false;
        }
        else if (email_centro_1 == null) {
            alert("Por favor, ingrese correctamente la dirección del Email");
            return false;
        }
        else if (email_centro_2 == "") {
            alert("Por favor, ingrese correctamente la dirección del Email");
            return false;
        }
        else if (nro_contacto_1 == "") {
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
                            { title: "Nro Contacto" },
                            { title: "Nro Contacto 2" },
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

    //evento boton editar, llama al modal y lo carga

    //$(document).on('click', '.btn-editar', function (e) {

    //    e.preventDefault();
    //    console.log("boton editar");



    //    var celda = $(this).parent().parent();
        
    //    var valor_celda = celda.children();

    //    var table = $('#tabla_centros').DataTable;
    //    const id_p = table.arrayCentros.Nombre;
    //    console.log(id_p);

    //    $("#txtNombre").val($(valor_celda[0]).text());
    //    $("#txtDomicilio").val($(valor_celda[1]).text());
    //    $("#txtLocalidad").val($(valor_celda[2]).text());
    //    $("#txtEmail").val($(valor_celda[3]).text());
    //    $("#txtNcontacto1").val($(valor_celda[4]).text());
    //    $("#txtNcontacto2").val($(valor_celda[5]).text());

             
    //})


//$(document).on('click', '.btn-editar', function (e) {

//    e.preventDefault();
//    console.log(table.row(this).data().Numero);

//});


    //$(document).on('click', '.btn-eliminar', function (e) {

    //    e.preventDefault();
    //    console.log("boton elimina");

    //})

function inactivar(id, nombre) {

    var IdCentro = id;
    var nombreCentro = nombre;

    $.ajax({
        url: "RegistrarCentros.aspx/darBajaCentro",
        data: "{p_id: '" + IdCentro + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            swal("Hecho", "Se dio de baja exitosamente a " + nombreCentro+ ".", "success");

            sendDataCentros();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(data.error);
        }
    });
}


    function UpdateDataCentros(id) {

        var obj = JSON.stringify({
            p_id: id,
            p_nombre: $("#txtNombre").val(),
            p_domicilio: $("#txtDomicilio").val(),
            p_localidad: $("#txtLocalidad").val(),
            p_email: $("#txtEmail").val(),
            p_contacto_1: $("#txtNcontacto1").val(),
            p_contacto_2: $("#txtNcontacto2").val()
           


        })

        $.ajax({
            type: "POST",
            url: "RegistrarCentros.aspx/actualizarCentros",
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
                    swal("Hubo un problema", "Error al actualizar datos del centro.", "error");
                }
                else {
                    $('#btnActualizarCentro').show();
                    swal("Hecho", "Los datos del centro se actualizaron con Éxito.", "success");
                }
                //console.log(response);
            }
        })
    }


