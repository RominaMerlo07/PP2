/************************************** INICIO Form Registrar **************************************************/

const formulario = document.getElementById('formularioRegistrar');
const inputs = document.querySelectorAll('#formularioRegistrar input'); 

const expresiones = {
    dni: /^\d{7,8}$/, // 7 a 8 numeros
    nombre: /^[a-zA-ZÀ-ÿ\s]{1,150}$/, // Letras y espacios, pueden llevar acentos.
    apellido: /^[a-zA-ZÀ-ÿ\s]{1,150}$/, // Letras y espacios, pueden llevar acentos.    
    celular: /^\(?\d{2}\)?[\s\.-]?\d{4}[\s\.-]?\d{4}$/,
    email1: /^(([^<>()[\]\.,;:\s@\"]+(\.[^<>()[\]\.,;:\s@\"]+)*)|(\".+\"))/,
    email2: /(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/,
    nro_afiliado: /^([0-9])*$/
}


const campos = {
    dni: false,
    nombre: false,
    apellido: false,   
    celular: false,
    email1: false,
    email2: false,
    nro_afiliado: false
}


const validarFormulario = (e) => {
    switch (e.target.name) {
        case "dni":
            validarCampo(expresiones.dni, e.target, 'txtDocumento');
            break;
        case "nombre":
            validarCampo(expresiones.nombre, e.target, 'txtNombre');
            break;
        case "apellido":
            validarCampo(expresiones.apellido, e.target, 'txtApellido');
            break;       
        case "celular":
            validarCampo(expresiones.celular, e.target, 'txtCelular');
            break;
        case "email1":
            validarCampo(expresiones.email1, e.target, 'txtEmail1');
            break;
        case "email2":
            validarCampo(expresiones.email2, e.target, 'txtEmail2');
            break;
        case "nro_afiliado":
            validarCampo(expresiones.nro_afiliado, e.target, 'txtNroAfiliado');
            break;
    }
}


const validarCampo = (expresion, input, campo) => {

    var result;

    var estado = document.getElementById(`id__${campo}`).readOnly;

    if (estado === false) {

        if (expresion.test(input.value)) {
            document.getElementById(`id__${campo}`).classList.remove('formulario-input-incorrecto');
            document.getElementById(`id__${campo}`).classList.add('formulario-input');
            document.getElementById(`p__${campo}`).classList.remove('formulario__error-activo');
            document.getElementById(`p__${campo}`).classList.add('formulario__error');
            document.getElementById('btnRegistrar').disabled = false;
                  

            if (campo = "txtDocumento") {
                dni = $('#id__txtDocumento').val();

                result = validarDni(dni);
                if (result) {
                    document.getElementById(`id__${campo}`).classList.remove('formulario-input-incorrecto');
                    document.getElementById(`id__${campo}`).classList.add('formulario-input');
                    document.getElementById('btnRegistrar').disabled = false;
                    deshabilitarCampos(false);
                } else {
                    document.getElementById(`id__${campo}`).classList.add('formulario-input-incorrecto');
                    document.getElementById(`id__${campo}`).classList.remove('formulario-input');
                    document.getElementById('btnRegistrar').disabled = true;
                }
            }
        }
        else {
            document.getElementById(`id__${campo}`).classList.add('formulario-input-incorrecto');
            document.getElementById(`id__${campo}`).classList.remove('formulario-input');
            document.getElementById(`p__${campo}`).classList.add('formulario__error-activo');
            document.getElementById(`p__${campo}`).classList.remove('formulario__error');
            document.getElementById('btnRegistrar').disabled = true;
            document.getElementById(`id__${campo}`).focus();
        }
    }
}


inputs.forEach((input) => {
    input.addEventListener('keyup', validarFormulario);
    input.addEventListener('blur', validarFormulario);
});

function validarDni(dni) {

    var result;

    $.ajax({
        url: "RegistrarPaciente.aspx/validarDni",
        data: "{dni: '" + dni + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            if (data.d != 'OK') {

                swal({
                    title: "Paciente ya registrado",
                    text: "El dni " + dni + " ya se encuentra registrado. Para modificar algun dato, elegi la opcion modificar en el listado de pacientes.",
                    icon: "warning",
                    //buttons: true,
                    button: "OK",
                    //dangerMode: true,
                })

                result = false;

            }
            else {
                result = true;
            }

        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(thrownError);
        }
    });

    return result;

}



/************************************** FIN Form Registrar **************************************************/


/************************************** INICIO Form Editar **************************************************/

const formularioE = document.getElementById('formularioEditar');
const inputsE = document.querySelectorAll('#formularioEditar input');

var dniP = document.getElementById('id__AtxtDocumento');

dniP.addEventListener('focus', (e) => {
    e.preventDefault(e);
    var dniE = $("#id__AtxtDocumento").val();
    console.log(dniE);

    dniP.addEventListener('change', (e) => {
        e.preventDefault(e);

        var dniN = $("#id__AtxtDocumento").val();

        if (dniE != dniN) {

            console.log("es distinto");

            var result = validarDni(dniN);
            if (result) {
                $("#id__AtxtDocumento").val(dniN);
            }
            else {
                $("#id__AtxtDocumento").val(dniE);
            }
        }
        else {
            console.log("es igual");
            $("#id__AtxtDocumento").val(dniE);
        }
    })

});


const validarFormularioEditar = (e) => {
    switch (e.target.name) {
        case "dniE":
            validarCampoEditar(expresiones.dni, e.target, 'AtxtDocumento');
            break;
        case "nombreE":
            validarCampoEditar(expresiones.nombre, e.target, 'AtxtNombre');
            break;
        case "apellidoE":
            validarCampoEditar(expresiones.apellido, e.target, 'AtxtApellido');
            break;        
        case "celularE":
            validarCampoEditar(expresiones.celular, e.target, 'AtxtCelular');
            break;
        case "email1E":
            validarCampoEditar(expresiones.email1, e.target, 'AtxtEmail1');
            break;
        case "email2E":
            validarCampoEditar(expresiones.email2, e.target, 'AtxtEmail2');
            break;
    }
}


const validarCampoEditar = (expresion, input, campo) => {

    if (expresion.test(input.value)) {
        document.getElementById(`id__${campo}`).classList.remove('formulario-input-incorrecto');
        document.getElementById(`id__${campo}`).classList.add('formulario-input');
        document.getElementById(`p__${campo}`).classList.remove('formulario__error-activo');
        document.getElementById(`p__${campo}`).classList.add('formulario__error');
        document.getElementById('btnEditar').disabled = false;
    }
    else {
        document.getElementById(`id__${campo}`).classList.add('formulario-input-incorrecto');
        document.getElementById(`id__${campo}`).classList.remove('formulario-input');
        document.getElementById(`p__${campo}`).classList.add('formulario__error-activo');
        document.getElementById(`p__${campo}`).classList.remove('formulario__error');
        document.getElementById('btnEditar').disabled = true;
        document.getElementById(`id__${campo}`).focus();
    }
}


inputsE.forEach((input) => {
    input.addEventListener('keyup', validarFormularioEditar);
    input.addEventListener('blur', validarFormularioEditar);
});


/************************************** FIN Form Editar **************************************************/