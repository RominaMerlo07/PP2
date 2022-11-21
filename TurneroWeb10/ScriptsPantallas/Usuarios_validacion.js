/************************************** INICIO Form Registrar **************************************************/

const formulario = document.getElementById('formularioRegistrar');
const inputs = document.querySelectorAll('#formularioRegistrar input');

console.log(inputs);

const expresiones = {
    dni: /^\d{7,8}$/
}

const campos = {
    dni: false
}

const validarFormulario = (e) => {
    switch (e.target.name) {
        case "dni":
            validarCampo(expresiones.dni, e.target, 'txtDocumento');
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