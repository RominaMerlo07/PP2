var usuario, password, passOld, idResetPass, idPersonal, idProfesional;

//$("#btnAbrir").click(function () {
//    $("#modalChangePassword").modal('show');
//});

$("#btnCancelar").click(function () {
    $("#modalChangePassword").modal('hide');
});


const form = document.getElementById('form-login');
const inputs = document.querySelectorAll('#form-login input');

//inputs.forEach((input) => {
//    input.addEventListener('keyup', validarFormulario);
//    input.addEventListener('blur', validarFormulario);
//});



form.addEventListener('submit', function (e) {
    e.preventDefault();
    usuario = $('#txtUsuario').val();
    password = $('#txtPassword').val();

    var validacion = validarDatosUsuario();

    if (validacion) {

        var user = {
            p_usuario: usuario,
            p_password: password
        }
        // alert("Pase la validacion");
        validaClaveProvisoria(user);
        //accesoUsuario(user);
    }

});


function validarDatosUsuario() {

    if (usuario === "") {
        swal("Todos los datos son obligatorios", "Por favor, ingrese su usuario", "error");
       // alert("Por favor, ingrese su usuario");
        return false;
    }
    else if (password === "") {
        swal("Todos los datos son obligatorios", "Por favor, ingrese su contraseña", "error");
        //alert("Por favor, ingrese su contraseña");
        return false;
    }
    else {
        return true;
    };
};

function accesoUsuario(user) {
  //  console.log("entre accceso usuario");
    $.ajax({
        url: "../Login.aspx/accesoUser",
        data: JSON.stringify(user),
        type: "POST",
        contentType: "application/json",
        async: false,
        success: function (data) {

            if (data.d != 'OK') {
                swal("Alguno/s de los datos ingresados son incorrectos", "Por favor, verifique los mismos y reintente la operación", "error"); //error

            } else {
               
                window.location.href = 'Principal.aspx';
                //$('#btnConfUsuario').show();
                //alert('Ingreso OK');
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(data.error);
        }

    });
}

function validaClaveProvisoria(user) {
    //  console.log("entre accceso usuario");
    $.ajax({
        url: "../Login.aspx/validaClaveProvisoria",
        data: JSON.stringify(user),
        type: "POST",
        contentType: "application/json",
        async: false,
        success: function (data) {
                       
 
            var info = JSON.parse(data.d);   

            if (info.length == 0)
            {
                console.log("debo ir a validar con la tabla t_usuarios");
                accesoUsuario(user);
            }

            info.forEach(function (e) {

                if (e.CLAVE_USUARIO != null) {
                    console.log("debo ir por pop up de cambio de pass, para eliminarla y updatear en la t_usuarios");
                    idResetPass = e.ID_RESETPASS;
                    passOld = e.CLAVE_USUARIO;
                    idPersonal = e.id_personal;
                    idProfesional = e.id_profesional;
                    $("#modalChangePassword").modal('show');
                }
             
            });
           },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(data.error);
        }

    });
}

$("#btnActualizar").click(function () {

    var claveOld = $('#txtPasswordProv').val();
    var claveNew = $('#txtpassNewUno').val();
    var claveNewRepeat = $('#txtpassNewDos').val();

    var resul = validaClavesOldNew(claveOld, claveNew, claveNewRepeat);
    if (resul) {

        var datosUsuario = {
            p_user: usuario,
            p_password: claveNew            
        }
       
      bajaResetClave(idResetPass, datosUsuario);

    }
});


function validaClavesOldNew(claveOld, claveNew, claveNewRepeat) {

    if (claveOld != passOld || claveNew != claveNewRepeat || claveOld === claveNew || claveNewRepeat === claveOld)
    {
      return false;
    }
    else if (claveOld === passOld && claveNew === claveNewRepeat && claveOld != claveNew || claveNewRepeat != claveOld)
    {
      return true;
    }
    
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
                actualizarClaveUser(datosUsuario);
            }

        }
    })
};


function actualizarClaveUser(datosUsuario) {
      

    $.ajax({
        type: "POST",
        url: "Login.aspx/actualizarClaveUser",
        data: JSON.stringify(datosUsuario),
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {

            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (response) {

            if (response.d != 'OK') {
                console.log("Error al actualizar clave");
                swal("Hubo un problema", "Error al actualizar la clave", "error");
            }
            else {
                console.log("Se actualizo clave ok")
                swal("Hecho", "Los datos del usuario se actualizaron con Éxito. Por favor, probá el ingreso con tus datos actualizados", "success");
                //sendDataUsuarios();
            }

        }
    })
};

