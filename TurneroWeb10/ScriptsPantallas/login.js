var usuario, password;

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
        accesoUsuario(user);
    }
    else {
        alert("No valide datos o sali por error");
    }

});


function validarDatosUsuario() {

    if (usuario === "") {
        alert("Por favor, ingrese su usuario");
        return false;
    }
    else if (password === "") {
        alert("Por favor, ingrese su contraseña");
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
                alert('Error al validar usuario.');

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




