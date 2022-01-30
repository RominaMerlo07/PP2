/*************************************************CONTROL FORMS*************************************************************/

const formulario = document.getElementById('formularioRegistrar');
const inputs = document.querySelectorAll('#formularioRegistrar input');


const expresiones = {
    dni: /^\d{7,8}$/, // 7 a 8 numeros
    matricula: /^\d{5,8}$/, // 5 a 8 numeros
    nombre: /^[a-zA-ZÀ-ÿ\s]{1,150}$/, // Letras y espacios, pueden llevar acentos.
    apellido: /^[a-zA-ZÀ-ÿ\s]{1,150}$/, // Letras y espacios, pueden llevar acentos.
    fecha: /^([0-2][0-9]|3[0-1])(\/|-)(0[1-9]|1[0-2])\2(\d{4})$/,  ///^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$/
    calle: /[A-Za-z0-9'\.\-\s\,]/,
    numero: /^\d{1,8}$/,
    barrio: /[A-Za-z0-9'\.\-\s\,]/,
    localidad: /[A-Za-z0-9'\.\-\s\,]/,
    celular: /^\(?\d{2}\)?[\s\.-]?\d{4}[\s\.-]?\d{4}$/,
    email1: /^(([^<>()[\]\.,;:\s@\"]+(\.[^<>()[\]\.,;:\s@\"]+)*)|(\".+\"))/,
    email2: /(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/
    //password: /^.{4,12}$/, // 4 a 12 digitos.
    //correo: /^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$/,
    //telefono: /^\d{7,10}$/ // 7 a 10 numeros.
}

const campos = {
    dni: false,
    matricula: false,
    nombre: false,
    apellido: false,
    fecha: false,
    calle: false,
    numero: false,
    barrio: false,
    localidad: false,
    celular: false,
    email1: false,
    email2: false
}


const validarFormulario = (e) => {
    switch (e.target.name) {
        case "dni":           
            validarCampo(expresiones.dni, e.target, 'txtDocumento');
            break;
        case "matricula":
            validarCampo(expresiones.matricula, e.target, 'txtMatricula');
            break;
        case "nombre":
            validarCampo(expresiones.nombre, e.target, 'txtNombre');
            break;
        case "apellido":
            validarCampo(expresiones.apellido, e.target, 'txtApellido');
            break;
        case "fechaNac":
            validarCampo(expresiones.fecha, e.target, 'dtpFechaNac');
            break;
        case "calle":
            validarCampo(expresiones.calle, e.target, 'txtCalle');
            break;
        case "numero":
            validarCampo(expresiones.numero, e.target, 'txtNumero');
            break;
        case "barrio":
            validarCampo(expresiones.barrio, e.target, 'txtBarrio');
            break;
        case "localidad":
            validarCampo(expresiones.localidad, e.target, 'txtLocalidad');
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
    }
}



const validarCampo = (expresion, input, campo) => {
    if (expresion.test(input.value)) {
        document.getElementById(`id__${campo}`).classList.remove('formulario-input-incorrecto');
        document.getElementById(`id__${campo}`).classList.add('formulario-input');        
        document.getElementById(`icon__${campo}`).classList.remove('formulario__validacion-incorrecto');
        document.getElementById(`icon__${campo}`).classList.add('formulario__validacion-correcto');
        document.getElementById(`icon__${campo}`).classList.remove('fa-times-circle');
        document.getElementById(`icon__${campo}`).classList.add('fa-check-circle');
        document.getElementById(`p__${campo}`).classList.remove('formulario__error-activo');
        document.getElementById(`p__${campo}`).classList.add('formulario__error');

        campos[campo] = true;
    
    } else {
        document.getElementById(`id__${campo}`).classList.add('formulario-input-incorrecto');
        document.getElementById(`id__${campo}`).classList.remove('formulario-input');
        document.getElementById(`icon__${campo}`).classList.add('formulario__validacion-incorrecto');
        document.getElementById(`icon__${campo}`).classList.remove('formulario__validacion-correcto');
        document.getElementById(`icon__${campo}`).classList.add('fa-times-circle');
        document.getElementById(`icon__${campo}`).classList.remove('fa-check-circle');
        document.getElementById(`p__${campo}`).classList.add('formulario__error-activo');
        document.getElementById(`p__${campo}`).classList.remove('formulario__error');
       
        campos[campo] = false;
    }
}


inputs.forEach((input) => {
    input.addEventListener('keyup', validarFormulario); 
    input.addEventListener('blur', validarFormulario);
});


//console.log(inputs);