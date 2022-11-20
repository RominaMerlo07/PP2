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

    if (expresion.test(input.value)) {
        document.getElementById(`id__${campo}`).classList.remove('formulario-input-incorrecto');
        document.getElementById(`id__${campo}`).classList.add('formulario-input');
        document.getElementById(`p__${campo}`).classList.remove('formulario__error-activo');
        document.getElementById(`p__${campo}`).classList.add('formulario__error');
    }
    else {
        document.getElementById(`id__${campo}`).classList.add('formulario-input-incorrecto');
        document.getElementById(`id__${campo}`).classList.remove('formulario-input');
        document.getElementById(`p__${campo}`).classList.add('formulario__error-activo');
        document.getElementById(`p__${campo}`).classList.remove('formulario__error');
        document.getElementById(`id__${campo}`).focus();
    }
}



inputs.forEach((input) => {
    input.addEventListener('keyup', validarFormulario);
    input.addEventListener('blur', validarFormulario);
});


/************************************** FIN Form Registrar **************************************************/