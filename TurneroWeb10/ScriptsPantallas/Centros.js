
    var nombre_centro;
    var domicilio_centro;
    var localidad_centro;
    var email_centro_1;
    var email_centro_2;
    var nro_contacto_1;
    var nro_contacto_2;


     $(document).ready(function () {

      

        $('#btnGuardarNvoCentro').click(function () {

            nombre_centro = $('#txtNombreCentro').val();
            domicilio_centro = $('#txtDomicilioCentro').val();
            localidad_centro = $('#txtLocalidadCentro').val();
            email_centro_1 = $('#txtEmailCentro1').val();
            email_centro_2 = $('#txtEmailCentro2').val();
            nro_contacto_1 = $('#txtTelefonoCentro1').val();
            nro_contacto_2 = $('#txtTelefonoCentro2').val();


            var validacion = validarDatosCentro();

            if (validacion === true) {

                var centro = {

                    p_nombre: nombre_centro,
                    p_domicilio: domicilio_centro,
                    p_localidad: localidad_centro,
                    p_email1: email_centro_1,
                    p_email2: email_centro_2,
                    p_contacto_1: nro_contacto_1,
                    p_contacto_2: nro_contacto_2

                }

                console.log(centro);
                registrarCentros(centro);
                $('input[type="text"]').val('');


            }
            else {
                console.log("Error en validación de datos del centro");
            }

        });

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

        }


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
            else if ( email_centro_1 == null) {
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

                    var Nombre = data.d[i].NombreCentro;
                    var Domicilio = data.d[i].DomicilioCentro;
                    var Localidad = data.d[i].LocalidadCentro;
                    var Email = data.d[i].EmailCentro;
                    var NroCentro1 = data.d[i].NroCentro1;
                    var NroCentro2 = data.d[i].NroCentro2;
                    var Acciones = '<button title= "Actualizar" class="btn btn-primary btn-editar" data-target="#modalEditar" data-toggle="modal"><i class="fas fa-user-edit" aria-hidden="true"></i></button>&nbsp' +
                        '<button title= "Inactivar" id="btnInactivar" class="btn btn-danger btn-eliminar"><i class="fas fa-user-minus" aria-hidden="true"></i></button>';

                    arrayCentros.push([
                        Nombre, Domicilio, Localidad, Email, NroCentro1,NroCentro2, Acciones
                    ])
                }

                var table = $('#tabla_centros').DataTable({
                    data: arrayCentros,
                    "scrollX": true,
                    "languaje": {
                        "url": "//cdn.datatables.net/plug-ins/1.10.12/i18n/Spanish.json"
                    },
                    "ordering": true,
                    "bDestroy": true,
                    "bAutoWidth": true,
                    columns: [
                        { title: "Nombre" },
                        { title: "Domicilio" },
                        { title: "Localidad" },
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

sendDataCentros();
