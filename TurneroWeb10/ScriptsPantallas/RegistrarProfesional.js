var dni;
var matricula;
var especialidades;
var nombre;
var apellido;
var fechaNac;

var calle;
var numero;
var barrio;
var localidad;
var celular;
var email1;
var email2;

var tabla, data, id, idN;




$(document).ready(function () {

    sendDataProfesionales();    
    cargarEspecialidades("#ddlEspecialidad");

    $('.date').datepicker({
        autoclose: true,
        format: "dd/mm/yyyy"
    });

    $('#btnRegistrar').click(function () {

        dni = $('#id__txtDocumento').val();
        matricula = $('#id__txtMatricula').val();
        especialidades = $('#ddlEspecialidad').val();
        nombre = $('#id__txtNombre').val();
        apellido = $('#id__txtApellido').val();
        fechaNac = $('#id__dtpFechaNac').val();
        calle = $('#id__txtCalle').val();
        numero = $('#id__txtNumero').val();
        barrio = $('#id__txtBarrio').val();
        localidad = $('#id__txtLocalidad').val();
        celular = $('#id__txtCelular').val();
        email1 = $('#id__txtEmail1').val();
        email2 = $('#id__txtEmail2').val();

        var validacion = validarDatosProfesional();

        if (validacion === true) {

            var profesional = {

                p_dni: dni,
                p_matricula: matricula,
                p_especialidades: especialidades,
                p_nombre: nombre,
                p_apellido: apellido,
                p_fechaNac: fechaNac,
                p_calle: calle,
                p_numero: numero,
                p_barrio: barrio,
                p_localidad: localidad,
                p_celular: celular,
                p_email1: email1,
                p_email2: email2
            }
            //console.log(profesional);
            registrarProfesional(profesional);
            limpiarCampos();
        }
        else {
            console.log("No valide datos o sali por error");
        }

    });

    $('#btnRegistrarModal').click(function () {
        $("#modalRegistrar").modal('show');
    });

});

function actualizar(idBuscar) {

    id = idBuscar;

    $.ajax({
        type: "POST",
        url: "RegistrarProfesional.aspx/buscaProfesional",
        data: "{idProf: '" + idBuscar + "'}",
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        async: false,
        success: function (data) {
            
            $("#modalEditar").modal('show');

            $("#txtNombreA").val(data.d.Nombre);
            $("#txtApellidoA").val(data.d.Apellido);
            $("#txtDocumentoA").val(data.d.Documento);
            $("#txtMatriculaA").val(data.d.NroMatricula);
            $("#txtLocalidadA").val(data.d.Localidad);
            $("#dtpFechaNacA").val(mostrarFecha(data.d.FechaNacimiento));
            var direccion = data.d.Domicilio.split('Barrio:')
            $("#txtDomicilio").val(direccion[0]);
            $("#txtBarrioA").val(direccion[1]);

            $("#txtCelularA").val(data.d.NroContacto);
            var email = data.d.EmailContacto.split('@');
            $("#txtEmail1A").val(email[0]);
            $("#txtEmail2A").val(email[1]);
        },
        error: function (xhr, ajaxOptions, thrownError) {

        }
    })
}


function especialidades(numero, profesional, matricula) {
   // alert(numero + ' prof: ' + profesional + 'matricula: ' + matricula);
    var texto = "Profesional: " + profesional + " -  Matrícula: " + matricula;
    $("#infoProfesional").text(texto);
    sendDataProfesional_Especialidades(numero);
    return $("#modalEspecialidades").modal('show');
}


function inactivar(id, nombre) {

    var IdProfesional = id;
    var nomApeProf = nombre;

    $.ajax({
        url: "RegistrarProfesional.aspx/darBajaProfesional",
        data: "{idProfesional: '" + IdProfesional + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            swal("Hecho", "Se dio de baja exitosamente a " + nomApeProf + ".", "success");

            sendDataProfesionales();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(data.error);
        }
    });
}

function limpiarCampos() {
    $('#id__txtDocumento').val("");
    $('#id__txtMatricula').val("");
    $('#ddlEspecialidad').val([]);
    $('#id__txtNombre').val("");
    $('#id__txtApellido').val("");
    $('#id__dtpFechaNac').datepicker('clearDates');
    $('#id__txtCalle').val("");
    $('#id__txtNumero').val("");
    $('#id__txtBarrio').val("");
    $('#id__txtLocalidad').val("");
    $('#id__txtCelular').val("");
    $('#id__txtEmail1').val("");
    $('#id__txtEmail2').val("");
}

function registrarProfesional(datosProfesional) {
    $.ajax({
        url: "RegistrarProfesional.aspx/registrarProfesional",
        data: JSON.stringify(datosProfesional),
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            if (data.d != 'OK') {

                swal("Hubo un problema", "Error al registrar el profesional!", "error"); //error
                
            } else {
                //$('#btnConfProfesional').show();
                $("#modalRegistrar").modal('hide');
                swal("Hecho", "Profesional registrado con Éxito!", "success"); //error
                //$("#tabla_profesionales").DataTable().fnClearTable();
                sendDataProfesionales();
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(data.error);
        }

    });
}

function validarDatosProfesional() {

    if (dni == "") {
        swal("Cuidado", "Por favor, ingrese DNI.", "warning");
        return false;
    }
    else if (matricula == "") {
        swal("Cuidado", "Por favor, ingrese Matricula.", "warning");
        return false;
    }
    else if (especialidades.length < 1) {
        swal("Cuidado", "Por favor, seleccionar Especialidades.", "warning");
        return false;
    }
    else if (nombre == null) {
        swal("Cuidado", "Por favor, ingrese Nombre.", "warning");
        return false;
    }
    else if (apellido == null) {
        swal("Cuidado", "Por favor, ingrese Apellido.", "warning");
        return false;
    }
    else if (fechaNac == "") {
        swal("Cuidado", "Por favor, ingrese Fecha de Nacimiento.", "warning");
        return false;
    }
    else if (calle == "") {
        swal("Cuidado", "Por favor, ingrese Calle.", "warning");
        return false;
    }
    else if (numero == "") {
        swal("Cuidado", "Por favor, ingrese Numero.", "warning");
        return false;
    }
    else if (barrio == "") {
        swal("Cuidado", "Por favor, ingrese Barrio.", "warning");
        return false;
    }
    else if (localidad == "") {
        swal("Cuidado", "Por favor, ingrese Localidad.", "warning");
        return false;
    }
    else if (celular == "") {
        swal("Cuidado", "Por favor, ingrese un telefono de contacto.", "warning");
        return false;
    }
    else if (email1 == "") {
        swal("Cuidado", "Por favor, ingrese un E-mail válido.", "warning");
        return false;
    }
    else if (email2 == "") {
        swal("Cuidado", "Por favor, ingrese un E-mail válido.", "warning");
        return false;
    }
    else {
        return true;
    };
};

function cargarEspecialidades(ddl) {
    $.ajax({
        url: "RegistrarProfesional.aspx/cargarEspecialidades",
        //data: "{idCentro: '" + idCentro + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            if (data.d.length > 0) {
                $(ddl).empty();
                $(ddl).append('<option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>');

                for (i = 0; i < data.d.length; i++) {

                    $(ddl).append($("<option></option>").val(data.d[i].IdEspecialidad).html(data.d[i].Descripcion));
                }
                $(ddl).prop("disabled", false);
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            $(ddl).prop("disabled", true);
            alert(data.error);
        }
    });
}

function sendDataProfesionales() {
    $.ajax({
        type: "POST",
        url: "RegistrarProfesional.aspx/cargarProfesionales",
        data: {},
        contentType: 'application/json; charset=utf-8', 
        async: false,
        success: function (data) {

            var arrayProfesionales = new Array();

            for (var i = 0; i < data.d.length; i++) {

                var fechaNac = data.d[i].FechaNacimiento;
                var DateFechaNac = mostrarFecha(fechaNac);
                var Numero = data.d[i].IdProfesional;
                var Profesional = (data.d[i].Nombre + ", " + data.d[i].Apellido);
                var DNI = data.d[i].Documento;
                var Matricula = data.d[i].NroMatricula;
                var Nacimiento = DateFechaNac;//data[i].fechaNac, ************************* VER COMO DAR FORMATO DD/MM/YYYY ******************************
                var Contacto = data.d[i].NroContacto;
                var Email = data.d[i].EmailContacto;
                var Domicilio = (data.d[i].Domicilio + ", " + data.d[i].Localidad);

                var jsonStr = '["' + DateFechaNac + '", "' + Numero + '", "' + Profesional + '", "' + DNI + '", "' + Matricula + '", "' + Nacimiento + '","' + Contacto + '","' + Email + '","' + Domicilio + '"]';
                //const array = JSON.parse(jsonStr);

                var Especialidad = '<button id="btnEspecialidades" class="btn btn-warning btn-especialidades" type="reset" onclick= "return especialidades(' + Numero + ",'" + Profesional + "'," + Matricula + ')" ><i class="fas fa-user-tag aria-hidden="true"></i> Consultar </button>';
             
                var Acciones = '<a href="#" onclick="return actualizar(' + Numero + ')"  class="btn btn-primary" > <span class="fas fa-user-edit"></span></a > ' +
                    '<a href="#" onclick="return inactivar(' + Numero + ",'" + Profesional + "'" +')"  class="btn btn-danger btnInactivar" > <span class="fas fa-user-minus"></span></a > ';

                //' + "'"+ Numero +"'"+ '
                arrayProfesionales.push([ 
                    Numero, Profesional, DNI, Matricula, Nacimiento, Contacto, Email, Domicilio, Especialidad, Acciones
                ])
            }

            var table = $('#tabla_profesionales').DataTable({
                data: arrayProfesionales,
                "scrollX": true,
                "languaje": {
                    "url": "//cdn.datatables.net/plug-ins/1.10.12/i18n/Spanish.json"
                },
                "ordering": true,
                "bDestroy": true,
                "bAutoWidth": true,
                columns: [
                    { title: "Numero", visible: false },
                    { title: "Profesional" },
                    { title: "DNI" },
                    { title: "Matricula" },
                    { title: "Nacimiento" },
                    { title: "Contacto" },
                    { title: "Email" },
                    { title: "Domicilio" },
                    { title: "Especialidad" },
                    { title: "Acciones" }
                ],
                dom: 'Bfrtip',
                dom: '<"top"B>rti<"bottom"fp><"clear">',
                "oLanguage": {
                    "sSearch": "Filtrar:",
                    "oPaginate": {
                        "sPrevious": "Anterior",
                        "sNext": "Siguiente"
                    }
                },
                "bPaginate": true,
                "pageLength": 3,
                buttons: [
                    //{ extend: 'copy', text: "Copiar" },
                    { extend: 'print', text: "Imprimir" },
                    { extend: 'pdf', orientation: 'landscape' },
                    { extend: 'colvis', columns: ':not(:first-child)', text: "Ocultar/Mostrar columnas" }
                ]
            });

        },
        error: function (xhr, ajaxOptions, thrownError) {
            //$(ddl).prop("disabled", true);
            //alert(data.error);
            //console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        }
    })
}


$("#btnActualizar").click(function (e) {
    e.preventDefault();
    UpdateDataProfesionales(id);

    //$("#tabla_profesionales").DataTable().fnClearTable();
    sendDataProfesionales();
    $("#modalEditar").modal('hide');

});



function UpdateDataProfesionales(id) {

    var obj = JSON.stringify({
        id: id,
        nombre: $("#txtNombreA").val(),
        apellido: $("#txtApellidoA").val(),
        dni: $("#txtDocumentoA").val(),
        matricula: $("#txtMatriculaA").val(),
        fechaNacimiento: $("#dtpFechaNacA").val(),
        localidad: $("#txtLocalidadA").val(),
        barrio: $("#txtBarrioA").val(),
        direccion: $("#txtDomicilio").val(),
        celular: $("#txtCelularA").val(),
        email1: $("#txtEmail1A").val(),
        email2: $("#txtEmail2A").val()
    })

    $.ajax({
        type: "POST",
        url: "RegistrarProfesional.aspx/actualizarProfesional",
        data: obj,
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            //$(ddl).prop("disabled", true);
            //alert(data.error);
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (response) {

            if (response.d != 'OK') {
                swal("Hubo un problema", "Error al actualizar los datos del profesional.", "error");
            }
            else {
                $('#btnActfProfesional').show();
                swal("Hecho", "Los datos del profesional se actualizaron con Éxito.", "success");
            }
            //console.log(response);
        }
    })
}

function soloNumeros(e) {

    key = e.keyCode || e.which;
    teclado = String.fromCharCode(key);
    numeros = "0123456789";
    especiales = "8-37-38-46";
    teclado_especial = false;

    for (var i in especiales) {
        if (key == especiales[i]) {
            teclado_especial = true;
        }
    }

    if (numeros.indexOf(teclado) == -1 && !teclado_especial) {
        return false;
    }
}


function soloLetras(e) {

    key = e.keyCode || e.which;
    teclado = String.fromCharCode(key);
    numeros = "abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
    especiales = "8-37-38-46-164";
    teclado_especial = false;

    for (var i in especiales) {
        if (key == especiales[i]) {
            teclado_especial = true; break;
        }
    }

    if (numeros.indexOf(teclado) == -1 && !teclado_especial) {
        return false;
    }
}


function sendDataProfesional_Especialidades(numero) {        
    $.ajax({
        type: "POST",
        url: "RegistrarProfesional.aspx/especialidadPorProfesional",
        data: "{idProfesional: '" + numero + "'}",
        contentType: 'application/json',
        async: false,
        success: function (data) {

            //	especialidades_profesional = JSON.parse(data.d);
            var datos = JSON.parse(data.d);
            var arrayEspecialidades = new Array();

            datos.forEach(function (e) {

                var idEspecialidad = e.ID_ESPECIALIDAD;
                var especialidades = e.ESPECIALIDAD;
                var estado = e.ESTADO;
                //var Acciones;

                var Acciones = '<a href="#" onclick="return inactivarE(' + numero + ",'" + idEspecialidad + "'" +')" class="btn btn-danger btn-sm btnInactivarE"> <span class="fas fa-minus-square"></span></a >';

                //DESCOMENTAR PARA MOSTRAR EN FORMA DE TABLA

               // console.log(especialidades + e.ESTADO);

                //if (estado == 'A') {
                //    estado = "ACTIVA";
                //    Acciones = '<a href="#" class="btn btn-danger btn-sm btnInactivar"> <span class="fas fa-minus-square"></span></a >';
                //}
                //else
                //{
                //    estado = "INACTIVA";
                //    Acciones = '<a href="#" class="btn btn-success btn-sm btnActivar"> <span class="fas fa-plus-square"></span></a >';
                //}
                

                arrayEspecialidades.push([
                    idEspecialidad, especialidades, /*estado,*/ Acciones
                ])

            });

            var table = $('#tabla_especialidades').DataTable({
                data: arrayEspecialidades,
                "scrollX": true,
                "languaje": {
                    "url": "//cdn.datatables.net/plug-ins/1.10.12/i18n/Spanish.json"
                },
                "ordering": true,
                "bDestroy": true,
                "bAutoWidth": true,
                "order": [2, "asc"],
               columns: [
                    { title: "idEspecialidad", visible: false }, 
                   { title: "Especialidad" },
               //     { title: "Estado" }, DESCOMENTAR PARA MOSTRAR EN FORMA DE TABLA
                    { title: "Acciones " }                                  
                ],
                dom: 'Bfrtip',
                dom: '<"top"B>rti<"bottom"fp><"clear">',
                "oLanguage": {
                    "sSearch": "Filtrar:",
                    "oPaginate": {
                        "sPrevious": "Anterior",
                        "sNext": "Siguiente"
                    }
                },
                "bPaginate": true,
                "pageLength": 8,
                buttons: [
                    //{ extend: 'copy', text: "Copiar" },
                    { extend: 'print', text: "Imprimir" },
                    { extend: 'pdf', orientation: 'landscape' },
                    { extend: 'colvis', columns: ':not(:first-child)', text: "Ocultar/Mostrar columnas" }
                ]
            });
            $('.dataTables_filter input').attr("placeholder", "Filtrar por...");


            $('#btnRegistrarEsp').click(function () {
                $("#modalAddEspecialidades").modal({
                    backdrop: 'static',
                    keyboard: true,
                    show: true
                }); 
               
                return cargarEspecialidadesProfesional("#ddlAddEspecialidad", numero);
            });

                

        },
        error: function (xhr, ajaxOptions, thrownError) {
            //$(ddl).prop("disabled", true);
            //alert(data.error);
            //console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        }
    })
}

function cargarEspecialidadesProfesional(ddl, numero) {

    idN = numero;

    $.ajax({
        url: "RegistrarProfesional.aspx/cargarEspecialidadesNotInProfesional",
        data: "{idProfesional: '" + numero + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

           // console.log(data);

            if (data.d.length > 0) {
                $(ddl).empty();
                $(ddl).append('<option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>');

                for (i = 0; i < data.d.length; i++) {

                    $(ddl).append($("<option></option>").val(data.d[i].IdEspecialidad).html(data.d[i].Descripcion));
                }
                $(ddl).prop("disabled", false);
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            $(ddl).prop("disabled", true);
            alert(data.error);
        }
    });
}


$("#btnAgregar").click(function (e) {
    e.preventDefault();
    especialidadesP = $('#ddlAddEspecialidad').val();
      
    var espeProfesional = {
        p_numero: idN,
        p_especialidadesP: especialidadesP        
    }
    
    agregarEspecialidadesProfesional(espeProfesional);

});


function agregarEspecialidadesProfesional(espeProfesional) {
    $.ajax({
        url: "RegistrarProfesional.aspx/registrarEspeProfesional",
        data: JSON.stringify(espeProfesional),
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            if (data.d != 'OK') {

                swal("Hubo un problema", "Error al cargar las especialidades para el profesional!", "error"); //error

            } else {                
                $("#modalAddEspecialidades").modal('hide');
                swal("Hecho", "Especialidades registradas con Éxito!", "success"); //error
                sendDataProfesional_Especialidades(espeProfesional.p_numero);
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(data.error);
        }

    });
};


function inactivarE(id, idEspecialidad) {


    var dataInactivarPE = {
        IdProfesional: id,
        idEspecialidad: idEspecialidad
    }


    $.ajax({
        url: "RegistrarProfesional.aspx/darBajaProfesionalE",
        data: JSON.stringify(dataInactivarPE),
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

          swal("Hecho", "Se dio de baja exitosamente la especialidad seleccionada", "success");

          sendDataProfesional_Especialidades(id);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(data.error);
        }
    });
}