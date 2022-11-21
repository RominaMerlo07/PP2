/************************************** INICIO Form Registrar **************************************************/

const formulario = document.getElementById('formularioRegistrar');
const inputs = document.querySelectorAll('#formularioRegistrar input');

console.log(inputs);

const expresiones = {
    nombre: /^[a-zA-ZÀ-ÿ\s]{1,150}$/,
    plan: /[A-Za-z0-9'\.\-\s\,]/
}

const campos = {
    nombre: false,
    plan: false
}

const validarFormulario = (e) => {
    switch (e.target.name) {
        case "nombre":
            validarCampo(expresiones.nombre, e.target, 'txtObraSocial');
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


            if (campo = "txtObraSocial") {
               var obraSocial = $('#id__txtObraSocial').val();

                result = validarObraSocial(obraSocial);
                if (result) {
                    document.getElementById(`id__${campo}`).classList.remove('formulario-input-incorrecto');
                    document.getElementById(`id__${campo}`).classList.add('formulario-input');
                    document.getElementById('btnRegistrarObraS').disabled = false;                 

                } else {
                    document.getElementById(`id__${campo}`).classList.add('formulario-input-incorrecto');
                    document.getElementById(`id__${campo}`).classList.remove('formulario-input');
                    document.getElementById('btnRegistrarObraS').disabled = true;
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


function validarObraSocial(obraSocial) {

    var result;

    $.ajax({
        url: "ObrasSociales.aspx/validarObraSocial",
        data: "{obraSocial: '" + obraSocial + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            if (data.d != 'OK') {

                swal({
                    title: "Obra social ya registrada",
                    text: "La obra social " + obraSocial + " ya se encuentra registrada. Para modificar algún dato, elegi la opción modificar en el listado de obras sociales.",
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

var obraSocialP = document.getElementById('id__AtxtObraSocial');


obraSocialP.addEventListener('focus', (e) => {
    e.preventDefault(e);
    var obraSocialE = $("#id__AtxtObraSocial").val();
    console.log(obraSocialE);

    obraSocialP.addEventListener('change', (e) => {
        e.preventDefault(e);

        var obraSocialN = $("#id__AtxtObraSocial").val();

        if (obraSocialE != obraSocialN) {

            console.log("es distinto");

            var result = validarObraSocial(obraSocialN);
            if (result) {
                $("#id__AtxtObraSocial").val(obraSocialN);
            }
            else {
                $("#id__AtxtObraSocial").val(obraSocialE);
            }
        }
        else {
            console.log("es igual");
            $("#id__AtxtObraSocial").val(obraSocialE);
        }
    })

});

const validarFormularioEditar = (e) => {
    switch (e.target.name) {
        case "nombreE":
            validarCampoEditar(expresiones.nombre, e.target, 'AtxtObraSocial');
            break;
    }
}


const validarCampoEditar = (expresion, input, campo) => {

    if (expresion.test(input.value)) {
        document.getElementById(`id__${campo}`).classList.remove('formulario-input-incorrecto');
        document.getElementById(`id__${campo}`).classList.add('formulario-input');
        document.getElementById(`p__${campo}`).classList.remove('formulario__error-activo');
        document.getElementById(`p__${campo}`).classList.add('formulario__error');
        document.getElementById('btnActualizar').disabled = false;

    }
    else {
        document.getElementById(`id__${campo}`).classList.add('formulario-input-incorrecto');
        document.getElementById(`id__${campo}`).classList.remove('formulario-input');
        document.getElementById(`p__${campo}`).classList.add('formulario__error-activo');
        document.getElementById(`p__${campo}`).classList.remove('formulario__error');
        document.getElementById('btnActualizar').disabled = true;
        document.getElementById(`id__${campo}`).focus();
    }
}


inputsE.forEach((input) => {
    input.addEventListener('keyup', validarFormularioEditar);
    input.addEventListener('blur', validarFormularioEditar);
});

/************************************** FIN Form Editar **************************************************/

/************************************** INICIO Form Registrar Plan **************************************************/


const formularioM = document.getElementById('formularioModal');
const inputsM = document.querySelectorAll('#formularioModal input');

console.log(inputsM);


const validarFormularioM = (e) => {
    switch (e.target.name) {
        case "nombreP":
            validarCampoM(expresiones.plan, e.target, 'txtPlan');
            break;
    }
}


const validarCampoM = (expresion, input, campo) => {

    var result;
     
        if (expresion.test(input.value)) {
            document.getElementById(`id__${campo}`).classList.remove('formulario-input-incorrecto');
            document.getElementById(`id__${campo}`).classList.add('formulario-input');
            document.getElementById(`p__${campo}`).classList.remove('formulario__error-activo');
            document.getElementById(`p__${campo}`).classList.add('formulario__error');


            if (campo = "txtPlan") {
                var plan = $('#id__txtPlan').val();

                result = validarPlan(plan, idObraSocial);

                console.log(result);

                if (result) {
                    document.getElementById(`id__${campo}`).classList.remove('formulario-input-incorrecto');
                    document.getElementById(`id__${campo}`).classList.add('formulario-input');
                    document.getElementById('btnGuardarPlan').disabled = false;

                } else {
                    document.getElementById(`id__${campo}`).classList.add('formulario-input-incorrecto');
                    document.getElementById(`id__${campo}`).classList.remove('formulario-input');
                    document.getElementById('btnGuardarPlan').disabled = true;
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


inputsM.forEach((input) => {
    input.addEventListener('keyup', validarFormularioM);
    input.addEventListener('blur', validarFormularioM);
});


function validarPlan(plan, idObraSocial) {
       
    var result;

    var dataPlan = {

        p_id: idObraSocial,
        p_descripcion: plan

    }

    console.log(dataPlan);

    $.ajax({
        url: "ObrasSociales.aspx/validarPlan",
        data: JSON.stringify(dataPlan),
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            console.log(data.d);

            if (data.d != 'OK') {

                swal({
                    title: "Plan ya registrado",
                    text: "El plan " + plan + " ya se encuentra registrado para la obra social consultada.",
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

/************************************** FIN Form Registrar Plan **************************************************/


/************************************** INICIO Form Editar Plan **************************************************/

const formularioP = document.getElementById('formularioModalPlan');
const inputsP = document.querySelectorAll('#formularioModalPlan input');

console.log(inputsP);


var planP = document.getElementById('id__AtxtPlan');


planP.addEventListener('focus', (e) => {

    var planE = $("#id__AtxtPlan").val();
    console.log(planE);

    planP.addEventListener('change', (e) => {
        e.preventDefault(e);

        var planN = $("#id__AtxtPlan").val();

        if (planE != planN) {

            console.log("es distinto");

            var result = validarPlan(planN, idObraSocial);
            if (result) {
                $("#id__AtxtPlan").val(planN);
            }
            else {
                $("#id__AtxtPlan").val(planE);
            }
        }
        else {
            console.log("es igual");
            $("#id__AtxtPlan").val(planE);
        }
    })

});

const validarFormularioPlan= (e) => {
    switch (e.target.name) {
        case "nombrePE":
            validarCampoEditarPlan(expresiones.plan, e.target, 'AtxtPlan');
            break;
    }
}


const validarCampoEditarPlan = (expresion, input, campo) => {

    if (expresion.test(input.value)) {
        document.getElementById(`id__${campo}`).classList.remove('formulario-input-incorrecto');
        document.getElementById(`id__${campo}`).classList.add('formulario-input');
        document.getElementById(`p__${campo}`).classList.remove('formulario__error-activo');
        document.getElementById(`p__${campo}`).classList.add('formulario__error');
        document.getElementById('btnActualizarPlan').disabled = false;

    }
    else {
        document.getElementById(`id__${campo}`).classList.add('formulario-input-incorrecto');
        document.getElementById(`id__${campo}`).classList.remove('formulario-input');
        document.getElementById(`p__${campo}`).classList.add('formulario__error-activo');
        document.getElementById(`p__${campo}`).classList.remove('formulario__error');
        document.getElementById('btnActualizarPlan').disabled = true;
        document.getElementById(`id__${campo}`).focus();
    }
}


inputsP.forEach((input) => {
    input.addEventListener('keyup', validarFormularioPlan);
    input.addEventListener('blur', validarFormularioPlan);
});


/************************************** FIN Form Editar Plan **************************************************/