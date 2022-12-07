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

var tabla, data, id, idN, IdProf, nombreProf, idProfE, idEsp;




$(document).ready(function () {

    sendDataProfesionales();    
    cargarEspecialidades("#ddlEspecialidad");
    $("#agregarEspecialidad").hide();

   
    $('.date').datepicker({
        autoclose: true,
        format: "dd/mm/yyyy",
        language: 'es',
        startDate: '01/11/2022'
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
        limpiarCampos();
        deshabilitarCampos(true);
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

            $("#id__AtxtNombre").val(data.d.Nombre);
            $("#id__AtxtApellido").val(data.d.Apellido);
            $("#id__AtxtDocumento").val(data.d.Documento);
            $("#id__AtxtMatricula").val(data.d.NroMatricula);
            $("#id__AtxtLocalidad").val(data.d.Localidad);
            $("#id__AdtpFechaNac").val(mostrarFecha(data.d.FechaNacimiento));
            var direccion = data.d.Domicilio.split('Barrio:')
            $("#id__AtxtDomicilio").val(direccion[0]);
            $("#id__AtxtBarrio").val(direccion[1]);

            $("#id__AtxtCelular").val(data.d.NroContacto);
            var email = data.d.EmailContacto.split('@');
            $("#id__AtxtEmail1").val(email[0]);
            $("#id__AtxtEmail2").val(email[1]);
        },
        error: function (xhr, ajaxOptions, thrownError) {

        }
    })
}

function especialidadesLoquinsongs(numero, profesional, matricula) {

    //console.log(numero, profesional, matricula);
    
    var texto = "Profesional: " + profesional + " -  Matrícula: " + matricula;
    $("#infoProfesional").text(texto);
    sendDataProfesional_Especialidades(numero);
       
    return $("#modalEspecialidades").modal('show');
}


function inactivar(id, nombre) {

    IdProf = id;
    nombreProf = nombre;


    $.ajax({
        url: "RegistrarProfesional.aspx/ObtenerTurnosFuturos",
        data: "{p_id: '" + IdProf + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            if (data.d === 'sin info') {
                console.log('puedo eliminar directo');

                swal({
                    title: "¿Estas seguro que deseas eliminar a " + nombreProf + "?",
                    text: "Una vez eliminado, ¡no podrá recuperar los datos asociados al mismo!",
                    icon: "warning",
                    buttons: true,
                    buttons: ["Cancelar", "Eliminar"],
                    dangerMode: true,
                })
                    .then((willDelete) => {
                        if (willDelete) {                       
                            DaDarDeBajaProf(IdProf, nombreProf)
                        }
                    });
            }
            else {
                console.log("tengo que mostrar los turnos pendientes");
                ObtenerTurnosFuturos(IdProf);
                $("#modalTurnos").modal('show');
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(thrownError);
        }
    });

}

function ObtenerTurnosFuturos(IdProf) {

    var turnos;
    $.ajax({
        type: "POST",
        url: "RegistrarProfesional.aspx/MostrarTurnosFuturos",
        data: "{p_id: '" + IdProf + "'}",
        contentType: 'application/json; charset=utf-8',
        async: false,
        success: function (data) {
                      

            turnos = JSON.parse(data.d);

            var arrayTurnos = new Array();

            turnos.forEach(function (e) {

                var turno = e.TURNO;
                var hora = e.HORA;
                var paciente = e.PACIENTE;
                var contacto = e.NRO_CONTACTO;
                var email = e.EMAIL_CONTACTO;

                arrayTurnos.push([turno, hora, paciente, contacto, email]);

                console.log(arrayTurnos);

            });

            var table = $('#tabla_Turnos').DataTable({
                data: arrayTurnos,
                "scrollX": true,
                "languaje": {
                    "url": "//cdn.datatables.net/plug-ins/1.10.12/i18n/Spanish.json"
                },
                "ordering": true,
                "bDestroy": true,
                "bAutoWidth": true,
                columns: [
                    { title: "Turno" },
                    { title: "Hora" },
                    { title: "Paciente" },
                    { title: "Contacto" },
                    { title: "Email" },
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
                "pageLength": 5,
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
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        }
    })
};



$("#btnCancelarT").click(function (e) {
    e.preventDefault();
    $("#modalTurnos").modal('hide');
});


$("#btnEliminar").click(function (e) {
    e.preventDefault();
    DarDeBajaTurnos(IdProf, nombreProf);
});


function DarDeBajaTurnos(IdProf, nombreProf) {

    $.ajax({
        url: "RegistrarProfesional.aspx/DaDarDeBajaProfTurnos",
        data: "{p_id: '" + IdProf + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            console.log(data.d);

            if (data.d != 'OK') {
                swal("Hubo un problema", "Error al eliminar el profesional.", "error");
            }
            else {
                swal("Hecho", "El profesional " + nombreProf + " se elimino con Éxito, y los turnos fueron cancelados.", "success");
                $("#modalTurnos").modal('hide');
                sendDataProfesionales();    
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(thrownError);
        }
    });

}


function DaDarDeBajaProf(IdProf, nombreProf) {
      

    $.ajax({
        url: "RegistrarProfesional.aspx/DaDarDeBajaProf",
        data: "{p_id: '" + IdProf + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            if (data.d == "OK") {
                swal("El profesional " + nombreProf + " fue eliminado con Éxito!.", {
                    icon: "success",
                });
                sendDataProfesionales();    
            }
            else {
                swal("Hubo un problema", "Error al eliminar el profesional.", "error");
            }

        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(data.error);
            return false;

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

function deshabilitarCampos(valor) {

   // document.getElementById("id__txtDocumento").focus();

    document.getElementById("id__txtMatricula").readOnly = valor;    
    document.getElementById("ddlEspecialidad").readOnly = valor;
    document.getElementById("id__txtNombre").readOnly = valor;
    document.getElementById("id__txtApellido").readOnly = valor;
    document.getElementById("id__dtpFechaNac").disable = valor;
    document.getElementById("id__dtpFechaNac").readOnly = valor;
    document.getElementById("id__txtCalle").readOnly = valor;
    document.getElementById("id__txtNumero").readOnly = valor;
    document.getElementById("id__txtBarrio").readOnly = valor;
    document.getElementById("id__txtLocalidad").readOnly = valor;
    document.getElementById("id__txtCelular").readOnly = valor;
    document.getElementById("id__txtEmail1").readOnly = valor;
    document.getElementById("id__txtEmail2").readOnly = valor;   

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

                    $(ddl).append($("<option></option>").val(data.d[i].IdEspecialidad).html(data.d[i].Descripcion).prop("disabled", false));
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

            if (data.d != null) {

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

                    var Especialidad = '<button id="btnEspecialidades" class="btn btn-warning btn-especialidades" type="reset" onclick= "return especialidadesLoquinsongs(' + Numero + ",'" + Profesional + "'," + Matricula + ')" ><i class="fa-solid fa-hospital-user"></i> Consultar </button>';

                    var Acciones = '<a href="#" onclick="return actualizar(' + Numero + ')"  class="btn btn-primary" > <span class="fas fa-user-edit" title="Modificar"></span></a > ' +
                        '<a href="#" onclick="return inactivar(' + Numero + ",'" + Profesional + "'" + ')"  class="btn btn-danger btnInactivar" > <span class="fas fa-user-minus" title="Dar de baja"></span></a > ';

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
                    "pageLength": 5,
                    buttons: [
                        //{ extend: 'copy', text: "Copiar" },
                        { extend: 'print', text: "Imprimir" },
                        { extend: 'pdf', orientation: 'landscape' },
                        { extend: 'colvis', columns: ':not(:first-child)', text: "Ocultar/Mostrar columnas" }
                    ]
                });

                $('#bxMainTable').show();
                $('#alertNullProf').hide();

            } else {
                $('#bxMainTable').hide();
                $('#alertNullProf').show();
            }

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
        nombre: $("#id__AtxtNombre").val(),
        apellido: $("#id__AtxtApellido").val(),
        dni: $("#id__AtxtDocumento").val(),
        matricula: $("#id__AtxtMatricula").val(),
        fechaNacimiento: $("#id__AdtpFechaNac").val(),
        localidad: $("#id__AtxtLocalidad").val(),
        barrio: $("#id__AtxtBarrio").val(),
        direccion: $("#id__AtxtDomicilio").val(),
        celular: $("#id__AtxtCelular").val(),
        email1: $("#id__AtxtEmail1").val(),
        email2: $("#id__AtxtEmail2").val()
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


function soloNumeros(event) {
    var regex = new RegExp("^[0-9]+$");
    var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
    if (!regex.test(key)) {
        event.preventDefault();
        return false;
    }
};


function soloLetras (event) {
    var regex = new RegExp("^[a-zA-Z ]+$");
    var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
    if (!regex.test(key)) {
        event.preventDefault();
        return false;
    }
};


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

                var Acciones = '<a href="#" onclick="return inactivarE(' + numero + ",'" + idEspecialidad + "','" + especialidades + "'" + ')" class="btn btn-danger btn-sm btnInactivarE"> <span class="fas fa-minus-square" title="Dar de baja"></span></a >';
                
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
                $("#agregarEspecialidad").show();       
               
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


$("#btnCancelar").click(function () {
    $("#agregarEspecialidad").hide();
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
                $("#agregarEspecialidad").hide();                
                swal("Hecho", "Especialidades registradas con Éxito!", "success"); //error
                sendDataProfesional_Especialidades(espeProfesional.p_numero);
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(data.error);
        }

    });
};



function emailFirst(event) {
    var regex = new RegExp("[a-zA-Z0-9-_.]+");
    var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
    if (!regex.test(key)) {
        event.preventDefault();
        return false;
    }
};


$("#btnCancelarE").click(function (e) {
    e.preventDefault();
    $("#modalTurnosE").modal('hide');
});


function inactivarE(id, idEspecialidad, especialidad) {

    console.log(especialidad);
    var dataInactivarPE = {
        IdProfesional: id,
        idEspecialidad: idEspecialidad
    }

    $.ajax({
        url: "RegistrarProfesional.aspx/ObtenerTurnosFuturosE",
        data: JSON.stringify(dataInactivarPE),
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            if (data.d === 'sin info') {
                console.log('puedo eliminar directo');

                swal({
                    title: "¿Estas seguro que deseas eliminar la espcialidad " + especialidad + " del profesional?",
                    text: "Una vez eliminada, ¡no podrá recuperar los datos asociados la misma!",
                    icon: "warning",
                    buttons: true,
                    buttons: ["Cancelar", "Eliminar"],
                    dangerMode: true,
                })
                    .then((willDelete) => {
                        if (willDelete) {
                            DarDeBajaEspecialidad(id, idEspecialidad, especialidad);
                        }
                    });
            }
            else {
                console.log("tengo que mostrar los turnos pendientes");
                ObtenerTurnosFuturosE(id, idEspecialidad);
                $("#modalTurnosE").modal('show');
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(thrownError);
        }
    });    
}

function ObtenerTurnosFuturosE(IdProf, idEspecialidad) {

    var dataInactivarPE = {
        IdProfesional: IdProf,
        idEspecialidad: idEspecialidad
    }

    idProfE = IdProf;
    idEsp = idEspecialidad;

   // console.log(idProfE, idEsp);

    var turnos;
    $.ajax({
        type: "POST",
        url: "RegistrarProfesional.aspx/MostrarTurnosFuturosE",
        data: JSON.stringify(dataInactivarPE),
        contentType: 'application/json; charset=utf-8',
        async: false,
        success: function (data) {


            turnos = JSON.parse(data.d);

            var arrayTurnos = new Array();

            turnos.forEach(function (e) {

                var turno = e.TURNO;
                var hora = e.HORA;
                var paciente = e.PACIENTE;
                var contacto = e.NRO_CONTACTO;
                var email = e.EMAIL_CONTACTO;

                arrayTurnos.push([turno, hora, paciente, contacto, email]);

                console.log(arrayTurnos);

            });

            var table = $('#tabla_TurnosE').DataTable({
                data: arrayTurnos,
                "scrollX": true,
                "languaje": {
                    "url": "//cdn.datatables.net/plug-ins/1.10.12/i18n/Spanish.json"
                },
                "ordering": true,
                "bDestroy": true,
                "bAutoWidth": true,
                columns: [
                    { title: "Turno" },
                    { title: "Hora" },
                    { title: "Paciente" },
                    { title: "Contacto" },
                    { title: "Email" },
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
                "pageLength": 5,
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
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        }
    })
};


function DarDeBajaEspecialidad(id, idEspecialidad, especialidad) {

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

            if (data.d == "OK") {
                swal("La especialidad " + especialidad + " fue eliminada con Éxito!.", {
                    icon: "success",
                });
                sendDataProfesional_Especialidades(id);
            }
            else {
                swal("Hubo un problema", "Error al eliminar la especialidad.", "error");
            } 

        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(thrownError);          
        }
    });
}


$("#btnEliminarE").click(function (e) {
    e.preventDefault();
    console.log(idProfE, idEsp);
    DarDeBajaTurnosE(idProfE, idEsp);
});



function DarDeBajaTurnosE(idProfE, idEsp) {

    var dataInactivarPE = {
        IdProfesional: idProfE,
        idEspecialidad: idEsp
    }

    console.log(dataInactivarPE);

    $.ajax({
        url: "RegistrarProfesional.aspx/DaDarDeBajaProfTurnosE",
        data: JSON.stringify(dataInactivarPE),
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            console.log(data.d);

            if (data.d != 'OK') {
                swal("Hubo un problema", "Error al eliminar la especialidad.", "error");
            }
            else {
                swal("Hecho", "La especialidad se elimino con Éxito, y los turnos fueron cancelados.", "success");
                $("#modalTurnosE").modal('hide');
                sendDataProfesional_Especialidades(idProfE);
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(thrownError);
        }
    });

}