var botonEnviar = document.getElementById("button");


$('#button').click(function (e) {
    e.preventDefault();
    email = $("#txtEmail").val();
    buscarEmail(email);     
});

function generatePass() {
    var pass = 'sp';
    var str = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ' +
        'abcdefghijklmnopqrstuvwxyz0123456789@#$';

    for (i = 1; i <= 8; i++) {
        var char = Math.floor(Math.random()
            * str.length + 1);

        pass += str.charAt(char)
    }

    return pass;
}


function buscarEmail(email) {

    console.log(email);

    $.ajax({
        url: "RecuperarPassword.aspx/ValidarEmail",
        data: "{email: '" + email + "'}",
        type: "post",
        contentType: "application/json",
        async: true,
        success: function (data) {             

            if (data.d.length <= 2) {
                console.log(data.d.length);
                console.log(data.d);            
                swal("Por favor, verificar", "El e-mail ingresado es incorrecto o no se encuentra registrado", "warning");
            }
            else {

                var personal = JSON.parse(data.d);

                personal.forEach(function (e) {

                    if (e.EMAIL_CONTACTO != "null") {
                        var email_contacto = e.EMAIL_CONTACTO;
                        var usuario = e.NOMBRE_USUARIO;

                        var usuario = {
                            p_email_contacto: email_contacto,
                            p_usuario: usuario
                        }

                        var idPersonal, idProfesional;
                        if (e.ID_PERSONAL != null) {
                            idPersonal = e.ID_PERSONAL;
                            idProfesional = null;
                        }
                        else {
                            idProfesional = e.ID_PROFESIONAL;
                            idPersonal = null;
                        }

                        console.log("Entre por ValidarEmail y esta ok");
                        validarResetPass(usuario, idPersonal, idProfesional);
                    }

                });
            }

        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr);
            console.log(thrownError);
        }
    });
}



function registrarResetPass(datosUsuario) {

    $.ajax({
        url: "RecuperarPassword.aspx/registrarResetPass",
        data: JSON.stringify(datosUsuario),
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {
            console.log(data.d);
            if (data.d != 'OK') {
                console.log("Error al registrar clave en base");

            } else {
                console.log("Se registro ok"); 
                botonEnviar.value = "Enviando...";
                botonEnviar.style.backgroundColor = '#088c7d';
                enviarMail(datosUsuario);
                
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(thrownError);
        }

    });

}

function validarResetPass(usuario, idPersonal, idProfesional) {
      
    $.ajax({
        url: "RecuperarPassword.aspx/validarResetPass",
        data: JSON.stringify(usuario),
        type: "post",
        contentType: "application/json",
        async: true,
        success: function (data) {

            var resetPass = JSON.parse(data.d);
            console.log(resetPass);

            if (resetPass.length == 0) {
                var pass = generatePass();

                var datosUsuario = {
                    p_nombreUsuario: usuario.p_usuario,
                    p_claveUsuario: pass,
                    p_emailContacto: usuario.p_email_contacto,
                    p_idPersonal: idPersonal,
                    p_idProfesional: idProfesional
                }
                botonEnviar.value = "Enviando...";
                botonEnviar.style.backgroundColor = '#088c7d';
                registrarResetPass(datosUsuario);
            }
            else { 
           
                resetPass.forEach(function (e) {

                    if (e.EMAIL_CONTACTO != "null") {
                        var pass = generatePass();

                        var datosUsuario = {
                            p_nombreUsuario: usuario.p_usuario,
                            p_claveUsuario: pass,
                            p_emailContacto: usuario.p_email_contacto,
                            p_idPersonal: idPersonal,
                            p_idProfesional: idProfesional
                        }
                        botonEnviar.value = "Enviando...";
                        botonEnviar.style.backgroundColor = '#088c7d';
                        bajaResetClave(e.ID_RESETPASS, datosUsuario);
                    }
                });
            }               

        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr);
            console.log(thrownError);
        }
    });
};

function bajaResetClave(id_resetpass, datosUsuario) {

    $.ajax({
        type: "POST",
        url: "RecuperarPassword.aspx/bajaResetClave",
        data: "{id_resetpass: '" + id_resetpass + "'}",
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {

            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (response) {

            if (response.d != 'OK') {
                console.log("error al dar de baja la clave");
            }
            else {

                console.log("se dio de baja ok");
                botonEnviar.value = "Enviando...";
                botonEnviar.style.backgroundColor = '#088c7d';
                registrarResetPass(datosUsuario);
            }

        }
    })
};



function enviarMail(datosUsuario) {
    botonEnviar.value = "Enviando...";
    botonEnviar.style.backgroundColor= '#088c7d';//#007bff

    var esHtml = true;

    var email = datosUsuario.p_emailContacto;
    var user = email.split("@");
    user = user[0];
    var passProvisoria = datosUsuario.p_claveUsuario;
    passProvisoria = passProvisoria.bold();
    var importante = "Recorda! que debes modificar la misma en el primer ingreso";
    importante = importante.bold().fontcolor('#8c2708');
    var urlSparring = " http://localhost:49513/Login.aspx ";
    var firma = "Sparring Rehabilitación";
    firma = firma.bold().fontcolor('#08748C').fontsize(6);
    var asunto = "Sparring Rehabilitación - Reestablecimiento de Contraseña";   
     

    var mensaje = "Hola " + user + "<br>" + "Hemos recibido una solicitud de restablecimiento de contraseña. <br> <br> Por favor, ingresa con tu usuario y la siguiente clave provisoria: " + passProvisoria + " en " + urlSparring + "<br>" + importante + ".<br> <br> En caso de que tengas problemas con el ingreso, comunicate con secretaría. <br> <br> Agradecemos tu compromiso y dedicación. <br> Saludos Cordiales <br>" + firma;

    $.ajax({
        url: "zzEjemploEnviadorMail.aspx/enviarMail",
        data: "{destinatario: '" + email
            + "', asunto: '" + asunto
            + "', mensaje: '" + mensaje
            + "', esHtml: '" + esHtml
            + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            if (data.d == "OK") {
                botonEnviar.value = "Enviar Email";
                botonEnviar.style.backgroundColor = '#007bff';
                swal("EMAIL ENVIADO", "Por favor verifica tu correo y seguí las instrucciones que te hemos enviado por email", "success");

            } else {
                botonEnviar.value = "Enviar Email"; 
                botonEnviar.style.backgroundColor = '#007bff';
                swal("Error", "No se ha podido enviar el E-mail", "warning");
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(data.error);
        }

    });
}


