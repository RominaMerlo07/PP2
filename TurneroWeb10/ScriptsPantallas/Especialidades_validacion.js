/************************************** INICIO Form Registrar **************************************************/

const formulario = document.getElementById('formularioRegistrar');
const inputs = document.querySelectorAll('#formularioRegistrar input'); 

console.log(inputs);

const expresiones = {
    nombre: /^[a-zA-ZÀ-ÿ\s]{1,150}$/
}

const campos = {
    nombre: false   
}

const validarFormulario = (e) => {
    switch (e.target.name) {
        case "nombre":
            validarCampo(expresiones.nombre, e.target, 'txtNombre');
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
                especialidad = $('#id__txtNombre').val();

                result = validarEspecialidad(especialidad);
                if (result) {
                    document.getElementById(`id__${campo}`).classList.remove('formulario-input-incorrecto');
                    document.getElementById(`id__${campo}`).classList.add('formulario-input');
                } else {
                    document.getElementById(`id__${campo}`).classList.add('formulario-input-incorrecto');
                    document.getElementById(`id__${campo}`).classList.remove('formulario-input');
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


function validarEspecialidad(especialidad) {

    var result;

    $.ajax({
        url: "RegistrarEspecialidades.aspx/validarEspecialidad",
        data: "{especialidad: '" + especialidad + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            if (data.d != 'OK') {

                swal({
                    title: "Especialidad ya registrada",
                    text: "La especialidad " + especialidad + " ya se encuentra registrada. Para modificar algún dato, elegi la opción modificar en el listado de especialidades.",
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

var especialidadP = document.getElementById('id__AtxtNombre');


especialidadP.addEventListener('focus', (e) => {
    e.preventDefault(e);
    var especialidadE = $("#id__AtxtNombre").val();
    console.log(especialidadE);

    especialidadP.addEventListener('change', (e) => {
        e.preventDefault(e);

        var especialidadN = $("#id__AtxtNombre").val();

        if (especialidadE != especialidadN) {

            console.log("es distinto");

            var result = validarEspecialidad(especialidadN);
            if (result) {
                $("#id__AtxtNombre").val(especialidadN);
            }
            else {
                $("#id__AtxtNombre").val(especialidadE);
            }
        }
        else {
            console.log("es igual");
            $("#id__AtxtNombre").val(especialidadE);
        }
    })

});

const validarFormularioEditar = (e) => {
    switch (e.target.name) {
        case "nameE":
            validarCampoEditar(expresiones.nombre, e.target, 'AtxtNombre');
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

/************************************** FIN Form Editar **************************************************/