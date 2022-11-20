/************************************** INICIO Form Registrar **************************************************/

const formulario = document.getElementById('formularioRegistrar');
const inputs = document.querySelectorAll('#formularioRegistrar input'); 

const expresiones = {
    nombre: /^[a-zA-ZÀ-ÿ\s]{1,150}$/, // Letras y espacios, pueden llevar acentos.
    calle: /[A-Za-z0-9'\.\-\s\,]/,
    numero: /^\d{1,8}$/,
    barrio: /[A-Za-z0-9'\.\-\s\,]/,
    localidad: /[A-Za-z0-9'\.\-\s\,]/,
    celular: /^\(?\d{2}\)?[\s\.-]?\d{4}[\s\.-]?\d{4}$/,
    email1: /^(([^<>()[\]\.,;:\s@\"]+(\.[^<>()[\]\.,;:\s@\"]+)*)|(\".+\"))/,
    email2: /(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/
}


const campos = {

    nombre: false,
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
        case "nombre":
            validarCampo(expresiones.nombre, e.target, 'txtNombre');
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

    var result;

    var estado = document.getElementById(`id__${campo}`).readOnly;

    if (estado === false) {

        if (expresion.test(input.value)) {
            document.getElementById(`id__${campo}`).classList.remove('formulario-input-incorrecto');
            document.getElementById(`id__${campo}`).classList.add('formulario-input');
            document.getElementById(`p__${campo}`).classList.remove('formulario__error-activo');
            document.getElementById(`p__${campo}`).classList.add('formulario__error');


            if (campo = "txtNombre") {
                centro = $('#id__txtNombre').val();

                result = validarCentro(centro);
                if (result) {
                    document.getElementById(`id__${campo}`).classList.remove('formulario-input-incorrecto');
                    document.getElementById(`id__${campo}`).classList.add('formulario-input');
                    deshabilitarCampos(false);
                } else {
                    document.getElementById(`id__${campo}`).classList.add('formulario-input-incorrecto');
                    document.getElementById(`id__${campo}`).classList.remove('formulario-input');
                    deshabilitarCampos(true);
                }
            }
        }
        else {
            document.getElementById(`id__${campo}`).classList.add('formulario-input-incorrecto');
            document.getElementById(`id__${campo}`).classList.remove('formulario-input');
            document.getElementById(`p__${campo}`).classList.add('formulario__error-activo');
            document.getElementById(`p__${campo}`).classList.remove('formulario__error');
            document.getElementById(`id__${campo}`).focus();
        }
    }
}

inputs.forEach((input) => {
    input.addEventListener('keyup', validarFormulario);
    input.addEventListener('blur', validarFormulario);
});



function validarCentro(centro) {

    var result;

    $.ajax({
        url: "RegistrarCentros.aspx/validarCentro",
        data: "{centro: '" + centro + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            if (data.d != 'OK') {

                swal({
                    title: "Centro de Atención ya registrado",
                    text: "El centro " + centro + " ya se encuentra registrado. Para modificar algún dato, elegi la opción modificar en el listado de centros.",
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

//console.log(inputsE);


var centroP = document.getElementById('id__AtxtNombre');

centroP.addEventListener('focus', (e) => {
    e.preventDefault(e);
    var centroE = $("#id__AtxtNombre").val();
    console.log(centroE);

    centroP.addEventListener('change', (e) => {
        e.preventDefault(e);

        var centroN = $("#id__AtxtNombre").val();

        if (centroE != centroN) {

            console.log("es distinto");

            var result = validarCentro(centroN);
            if (result) {
                $("#id__AtxtNombre").val(centroN);
            }
            else {
                $("#id__AtxtNombre").val(centroE);
            }
        }
        else {
            console.log("es igual");
            $("#id__AtxtNombre").val(centroE);
        }
    })

});


const validarFormularioEditar = (e) => {
    switch (e.target.name) {  
        case "nombreE":
            validarCampoEditar(expresiones.nombre, e.target, 'AtxtNombre');
            break;
        case "celularE":
            validarCampoEditar(expresiones.celular, e.target, 'AtxtCelular');
            break;
        case "domicilioE":
            validarCampoEditar(expresiones.calle, e.target, 'AtxtDomicilio');
            break;
        case "barrioE":
            validarCampoEditar(expresiones.barrio, e.target, 'AtxtBarrio');
            break;
        case "localidadE":
            validarCampoEditar(expresiones.localidad, e.target, 'AtxtLocalidad');
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
    }
    else {
        document.getElementById(`id__${campo}`).classList.add('formulario-input-incorrecto');
        document.getElementById(`id__${campo}`).classList.remove('formulario-input');
        document.getElementById(`p__${campo}`).classList.add('formulario__error-activo');
        document.getElementById(`p__${campo}`).classList.remove('formulario__error');
        document.getElementById(`id__${campo}`).focus();
    }
}


inputsE.forEach((input) => {
    input.addEventListener('keyup', validarFormularioEditar);
    input.addEventListener('blur', validarFormularioEditar);
});