
    var nombre_centro;
    var domicilio_centro;
    var localidad_centro;
    var email_centro_1;
    var email_centro_2;
    var nro_contacto_1;
    var nro_contacto_2;


     $(document).ready(function () {

        //       $('.date').datepicker({
        //           autoclose: true,
        //           format: "dd/mm/yyyy"
        //       });

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

