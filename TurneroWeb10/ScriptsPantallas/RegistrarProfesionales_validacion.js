/*************************************************CONTROL FORMS*************************************************************/

/************************************** INICIO Form Registrar **************************************************/


const formulario = document.getElementById('formularioRegistrar');
const inputs = document.querySelectorAll('#formularioRegistrar input'); 


const campos = {
    dni: false,
    matricula: false,
    nombre: false,
    apellido: false,
    //fecha: false,
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
       
    var result, resultMat;

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
                document.getElementById("id__txtMatricula").readOnly = false;

                if (campo = "txtMatricula") {

                    matricula = $('#id__txtMatricula').val();

                    resultMat = validarMatricula(matricula);

                    if (resultMat) {
                        document.getElementById(`id__${campo}`).classList.remove('formulario-input-incorrecto');
                        document.getElementById(`id__${campo}`).classList.add('formulario-input');
                        document.getElementById('btnRegistrar').disabled = false;
                        deshabilitarCampos(false);
                    } else {
                        document.getElementById(`id__${campo}`).classList.add('formulario-input-incorrecto');
                        document.getElementById(`id__${campo}`).classList.remove('formulario-input');
                        document.getElementById('btnRegistrar').disabled = true;
                        deshabilitarCampos(true);
                        document.getElementById("id__txtMatricula").readOnly = false;
                    }
                }           
            } else {
                document.getElementById(`id__${campo}`).classList.add('formulario-input-incorrecto');
                document.getElementById(`id__${campo}`).classList.remove('formulario-input');  
                document.getElementById('btnRegistrar').disabled = true;
                deshabilitarCampos(true);
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
        url: "RegistrarProfesional.aspx/validarDni",
        data: "{dni: '" + dni + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            if (data.d != 'OK') {

                swal({
                    title: "Personal ya registrado",
                    text: "El dni " + dni + " ya se encuentra registrado. Para modificar algun dato, elegi la opcion modificar en el listado de profesionales.",
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


function validarMatricula(matricula) {

    var result;

    $.ajax({
        url: "RegistrarProfesional.aspx/validarMatricula",
        data: "{matricula: '" + matricula + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            if (data.d != 'OK') {

                swal({
                    title: "Matricula ya registrada",
                    text: "La matricula " + matricula + " ya se encuentra registrada. Para modificar algun dato, elegi la opcion modificar en el listado de profesionales.",
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

//inputsE.forEach((input) => {
//    input.addEventListener('change', validarCambio);
//});

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

})


var matP = document.getElementById('id__AtxtMatricula');

matP.addEventListener('focus', (e) => {
    e.preventDefault(e);

    var matE = $("#id__AtxtMatricula").val();
    console.log(matE);

    matP.addEventListener('change', (e) => {
        e.preventDefault(e);

        var matN = $("#id__AtxtMatricula").val();

        if (matE != matN) {

            console.log("es distinto");

            var resultMat = validarMatricula(matN);
            if (resultMat) {
                $("#id__AtxtMatricula").val(matN);              
            }
            else {
                $("#id__AtxtMatricula").val(matE);              
            }
        }
        else {
            console.log("es igual");
            $("#id__AtxtMatricula").val(matE);
          
        }
    })

})



const validarFormularioEditar = (e) => {
    switch (e.target.name) {
        case "dniE":
            validarCampoEditar(expresiones.dni, e.target, 'AtxtDocumento');
            break;
        case "matriculaE":
            validarCampoEditar(expresiones.matricula, e.target, 'AtxtMatricula');
            break;
        case "nombreE":
            validarCampoEditar(expresiones.nombre, e.target, 'AtxtNombre');
            break;
        case "apellidoE":
            validarCampoEditar(expresiones.apellido, e.target, 'AtxtApellido');
            break;
        //case "fechaNac":
        //    validarCampo(expresiones.fecha, e.target, 'dtpFechaNac');
        //    break;
        case "domicilioE":
            validarCampoEditar(expresiones.calle, e.target, 'AtxtDomicilio');
            break     
        case "barrioE":
            validarCampoEditar(expresiones.barrio, e.target, 'AtxtBarrio');
            break;
        case "localidadE":
            validarCampoEditar(expresiones.localidad, e.target, 'AtxtLocalidad');
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
            document.getElementById('btnActualizar').disabled = false;
        }
        else {
            document.getElementById(`id__${campo}`).classList.add('formulario-input-incorrecto');
            document.getElementById(`id__${campo}`).classList.remove('formulario-input');
            document.getElementById(`p__${campo}`).classList.add('formulario__error-activo');
            document.getElementById(`p__${campo}`).classList.remove('formulario__error');
            document.getElementById(`id__${campo}`).focus();
            document.getElementById('btnActualizar').disabled = true;
        }
    
}



inputsE.forEach((input) => {
    input.addEventListener('keyup', validarFormularioEditar);
    input.addEventListener('blur', validarFormularioEditar);
});

/************************************** FIN Form Editar *****************************************************/




/************************************** GLOBALES **************************************************/


function calcularFechaMin() {
  

    var hoy = new Date();
    var anoDif = hoy.getFullYear() - 18;
    var mes = hoy.getMonth() + 1;
    var dia = hoy.getDate();

    var fecha = (dia + "/" + mes + "/" + anoDif);
  
    return fecha;
    }


var fechaMin = calcularFechaMin();


function calcularFechaMax() {


    var hoy = new Date();
    var anoDif = hoy.getFullYear() - 60;
    var mes = hoy.getMonth() + 1;
    var dia = hoy.getDate();

    var fecha = (dia + "/" + mes + "/" + anoDif);      

    return fecha;
}

var fechaMax = calcularFechaMax();


$('.date').datepicker({
    autoclose: true,
    format: "dd/mm/yyyy",
    language: 'es',
    startDate: fechaMax, //'01/11/2022',
    endDate: fechaMin,//'11/11/2022'
    defaultViewDate: fechaMin
});


const expresiones = {
    dni: /^\d{7,8}$/, // 7 a 8 numeros
    matricula: /^\d{4,8}$/, // 5 a 8 numeros
    nombre: /^[a-zA-ZÀ-ÿ\s]{1,150}$/, // Letras y espacios, pueden llevar acentos.
    apellido: /^[a-zA-ZÀ-ÿ\s]{1,150}$/, // Letras y espacios, pueden llevar acentos.
    //fecha: /^([0-2][0-9]|3[0-1])(\/|-)(0[1-9]|1[0-2])\2(\d{4})$/,
    calle: /[A-Za-z0-9'\.\-\s\,]/,
    numero: /^\d{1,8}$/,
    barrio: /[A-Za-z0-9'\.\-\s\,]/,
    localidad: /[A-Za-z0-9'\.\-\s\,]/,
    celular: /^\(?\d{2}\)?[\s\.-]?\d{4}[\s\.-]?\d{4}$/,
    email1: /^(([^<>()[\]\.,;:\s@\"]+(\.[^<>()[\]\.,;:\s@\"]+)*)|(\".+\"))/,
    email2: /(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/
}