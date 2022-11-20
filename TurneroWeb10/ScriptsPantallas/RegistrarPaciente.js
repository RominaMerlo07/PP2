var dni, nombre, apellido, celular, obraSocial, plan, email1, email2, nroAfiliado, id, idPaciente, idOSP, name, idEliminar;

$(document).ready(function () {

    $('.date').datepicker({
        autoclose: true,
        format: "dd/mm/yyyy",
        language: 'es'
    });

    sendDataPacientes();

    $('#btnRegistrar').click(function () {

        dni = $('#id__txtDocumento').val();
        celular = $('#id__txtCelular').val();
        nombre = $('#id__txtNombre').val();
        apellido = $('#id__txtApellido').val();
        email1 = $('#id__txtEmail1').val();
        email2 = $('#id__txtEmail2').val();
        obraSocial = $('#ddlObraSocial').val();
        plan = $('#ddlPlanObra').val();
        nroAfiliado = $("#id__txtNroAfiliado").val();
       

        var validacion = validarDatosPaciente();

        if (validacion === true) {

            var paciente = {
                
                p_dni: dni,
                p_celular: celular,
                p_nombre: nombre,
                p_apellido: apellido,               
                p_email1: email1,
                p_email2: email2,
                p_obraSocial: obraSocial,
                p_plan: plan,
                p_nroAfiliado: nroAfiliado
            }

           console.log(paciente);
           registrarPaciente(paciente);
        };

    
    });

    $('#btnRegistrarModal').click(function () {
        $("#modalRegistrar").modal('show');
        limpiarCampos();
        deshabilitarCampos(true);
    });

    cargarObrasSociales("#ddlObraSocial");

    $("#ddlObraSocial").bind("change", function () {

        var idObraSocial = $('#ddlObraSocial').val();
        cargarComboPlanes(idObraSocial, "#ddlPlanObra");        
    });


    $("#ddlObraSocialE").bind("change", function () {

        var idObraSocial = $('#ddlObraSocialE').val();
        cargarComboPlanes(idObraSocial, "#ddlPlanObraE");
    });


    $("#agregarObraSocial").hide();
    $("#editarObraSocial").hide();
    

});


function registrarPaciente(datosPaciente) {
    $.ajax({
        url: "RegistrarPaciente.aspx/registrarPaciente",
        data: JSON.stringify(datosPaciente),
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            if (data.d != 'OK') {
                swal("Hubo un problema", "Error al registrar el paciente!", "error");
            } else {
                $('#btnConfPaciente').show();
                swal("Hecho", "Paciente registrado con Éxito!", "success");

                $("#modalRegistrar").modal('hide');
                sendDataPacientes();
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(data.error);
        }

    });

}


function validarDatosPaciente() {

    if (dni == null) {
        alert("Por favor, ingrese DNI");
        return false;
    }
    else if (nombre == null) {
        alert("Por favor, ingrese Nombre");
        return false;
    }
    else if (apellido == null) {
        alert("Por favor, ingrese Apellido");
        return false;
    }
    else if (celular == "") {
        alert("Por favor, ingrese su celular");
        return false;
    }
    else if (obraSocial == null) {
        alert("Por favor, seleccione una obra social o particular");
        return false;
    }  
    else if (email1 == "") {
        alert("Por favor, ingrese un E-mail válido");
        return false;
    }
    else if (email2 == "") {
        alert("Por favor, ingrese un E-mail válido");
        return false;
    } 
    else {
        return true;
    };
};


function cargarObrasSociales(ddl) {

    $.ajax({
        url: "RegistrarPaciente.aspx/cargarObrasSociales",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            if (data.d.length > 0) {
                $(ddl).empty();
                $(ddl).append('<option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>');

                for (i = 0; i < data.d.length; i++) {

                    $(ddl).append($("<option></option>").val(data.d[i].IdObraSocial).html(data.d[i].Descripcion));
                }
                $(ddl).prop("disabled", false);
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            $(ddl).prop("disabled", true);
            alert(data.error);
        }
    });
};


function cargarComboPlanes(idObraSocial, ddl) {
    
    $.ajax({
        url: "RegistrarPaciente.aspx/cargarPlanes",
        data: "{idObraSocial: '" + idObraSocial + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {
            var planes = JSON.parse(data.d);

            if (planes.length > 0) {

                $(ddl).empty();
                $(ddl).append('<option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>');

                planes.forEach(function (e) {
                    $(ddl).append($("<option></option>").val(e.ID_PLANES).html(e.DESCRIPCION));
                });
                $("#ddlPlanObra").prop("disabled", false);
                $('#id__txtNroAfiliado').prop('disabled', false);
                $("#ddlPlanObraE").prop("disabled", false);
                $('#id__txtNroAfiliadoE').prop('disabled', false);


            }
            else {
                $("#ddlPlanObra").prop("disabled", true);
                $("#ddlPlanObra").val([0]);
                $('#id__txtNroAfiliado').val("");
                $('#id__txtNroAfiliado').prop('disabled', true);
                $("#ddlPlanObraE").prop("disabled", true);
                $("#ddlPlanObraE").val([0]);
                $('#id__txtNroAfiliadoE').val("");
                $('#id__txtNroAfiliadoE').prop('disabled', true);                     

            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            $(ddl).prop("visible", true);
        }
    });
}


function sendDataPacientes() {
    $.ajax({
        type: "POST",
        url: "RegistrarPaciente.aspx/cargarPacientes",
        data: {},
        contentType: 'application/json; charset=utf-8',
        async: false,
        success: function (data) {

            var datos = JSON.parse(data.d);
            var arrayPacientes = new Array();

            datos.forEach(function (e) {

                var Numero = e.ID_PACIENTE;
                var Dni = e.DOCUMENTO;
                var Paciente = (e.NOMBRE + ", " + e.APELLIDO);
                var Celular = e.NRO_CONTACTO;
                var Email = e.EMAIL_CONTACTO;
                        

                var ObrasSociales = '<button id="btnObrasSocial" class="btn btn-warning btn-obrasSociales" type="reset" onclick= "return obrasSociales(' + Numero + ",'" + Paciente + "'," + Dni + ')" ><i class="fa-solid fa-id-card"></i> Consultar </button>';

                var Acciones = '<a href="#" onclick="return actualizar(' + Numero + ')"  class="btn btn-primary" > <span class="fas fa-user-edit" title="Modificar"></span></a > ' +
                    '<a href="#" onclick="return inactivar(' + Numero + ",'" + Paciente + "'" + ')"  class="btn btn-danger btnInactivar" > <span class="fas fa-user-minus" title="Dar de baja"></span></a > ';

              
                arrayPacientes.push([
                    Numero, Dni, Paciente, Celular, Email, ObrasSociales, Acciones
                ])
        });

    var table = $('#tabla_pacientes').DataTable({
        data: arrayPacientes,
        "scrollX": true,
        "languaje": {
            "url": "//cdn.datatables.net/plug-ins/1.10.12/i18n/Spanish.json"
        },
        "ordering": true,
        "bDestroy": true,
        "bAutoWidth": true,
        columns: [
            { title: "Numero", visible: false },
            { title: "DNI" },
            { title: "Paciente" },
            { title: "Contacto" },
            { title: "Email" },           
            { title: "Obra Social" },         
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

},
error: function (xhr, ajaxOptions, thrownError) {
    //$(ddl).prop("disabled", true);
    //alert(data.error);
    //console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
}
    })
};


function actualizar(idBuscar) {

    id = idBuscar;
    $.ajax({
        type: "POST",
        url: "RegistrarPaciente.aspx/buscarPaciente",
        data: "{idPaciente: '" + idBuscar + "'}",
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        async: false,
        success: function (data) {

            

            var paciente = JSON.parse(data.d); 
            console.log(paciente);
            console.log(paciente.length);

            if (paciente.length > 0) {

                if (paciente != null) {

                    paciente.forEach(function (e) {

                        id = e.ID_PACIENTE;
                        // cargo = e.cargo;

                        $("#modalEditar").modal('show');

                        $("#id__AtxtDocumento").val(e.DOCUMENTO);
                        $("#id__AtxtCelular").val(e.NRO_CONTACTO);
                        $("#id__AtxtNombre").val(e.NOMBRE);
                        $("#id__AtxtApellido").val(e.APELLIDO);
                        var email = e.EMAIL_CONTACTO.split('@');
                        $("#id__AtxtEmail1").val(email[0]);
                        $("#id__AtxtEmail2").val(email[1]);


                    });

                }
            }

            else {

                buscarPacienteParticular(idBuscar);
            }
      
        },
        error: function (xhr, ajaxOptions, thrownError) {

        }
    })
}


$("#btnEditar").click(function (e) {
    e.preventDefault();
    UpdateDataPaciente(id);
    $("#modalEditar").modal('hide');

});


function UpdateDataPaciente(id) {

    var obj = JSON.stringify({
        id: id,
        nombre: $("#id__AtxtNombre").val(),
        apellido: $("#id__AtxtApellido").val(),
        dni: $("#id__AtxtDocumento").val(),
        celular: $("#id__AtxtCelular").val(),
        email1: $("#id__AtxtEmail1").val(),
        email2: $("#id__AtxtEmail2").val()
    })

    $.ajax({
        type: "POST",
        url: "RegistrarPaciente.aspx/actualizarPaciente",
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
                swal("Hubo un problema", "Error al actualizar los datos del paciente.", "error");
            }
            else {
                $('#btnActfProfesional').show();
                swal("Hecho", "Los datos del paciente se actualizaron con Éxito.", "success");
                sendDataPacientes();
            }
            //console.log(response);
        }
    })
}


function obrasSociales(id, Paciente, Dni) {
    var texto = "Paciente: " + Paciente + " -  DNI: " + Dni;
    $("#infoPaciente").text(texto);
    idPaciente = id;
    sendDataPacienteOS(id);
    return $("#modalObrasSociales").modal('show');
 

}

function sendDataPacienteOS(numero) {
    $("#agregarObraSocial").hide();

    $.ajax({
        type: "POST",
        url: "RegistrarPaciente.aspx/obraSocialPaciente",
        data: "{idPaciente: '" + numero + "'}",
        contentType: 'application/json',
        async: false,
        success: function (data) {

            var datos = JSON.parse(data.d);
            var arrayPacienteOS = new Array();

            datos.forEach(function (e) {

                var idObraPaciente = e.ID_OBRA_PACIENTE;
                var ObraSocial = e.DESCRIPCION;
                var CodigoPlan = e.COD_PLAN;
                var Plan = e.PLAN;
                var NumAfiliado = e.NRO_AFILIADO;
                var Acciones;               


                if (ObraSocial != "PARTICULAR") {

                    Acciones = '<a href="#" onclick="return actualizarOS(' + idObraPaciente + ",'" + NumAfiliado + "'" + ')"  class="btn btn-primary btnEditarOS" > <span class="fa-solid fa-pen-to-square" title="Modificar"></span></a> ' +
                        '<a href="#" onclick="return inactivarE(' + numero + ",'" + idObraPaciente + "'" + ')" class="btn btn-danger btnInactivarE"> <span class="fas fa-minus-square" title="Dar de baja"></span></a >';

                }
                else {
                    Acciones = '<a href="#" onclick="return inactivarE(' + numero + ",'" + idObraPaciente + "'" + ')" class="btn btn-danger btnInactivarE"> <span class="fas fa-minus-square" title="Dar de baja"></span></a >';
                }


            
                arrayPacienteOS.push([
                    idObraPaciente, ObraSocial, CodigoPlan, Plan, NumAfiliado, Acciones
                ])

            });


            console.log(arrayPacienteOS);
            var table = $('#tabla_obrasSociales').DataTable({
                data: arrayPacienteOS,
                "scrollX": true,
                "languaje": {
                    "url": "//cdn.datatables.net/plug-ins/1.10.12/i18n/Spanish.json"
                },
                "ordering": true,
                "bDestroy": true,
                "bAutoWidth": true,
                "order": [2, "asc"],
                columns: [
                    { title: "idObraPaciente", visible: false },
                    { title: "Obra Social" },
                    { title: "Codigo Plan" },
                    { title: "Plan" },
                    { title: "Nro. Afiliado" },
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


            $('#btnRegistrarOS').click(function () {
                $("#agregarObraSocial").show();
                obtenerOSxPaciente("#ddlObraSocialE", numero);

                //return cargarEspecialidadesProfesional("#ddlAddEspecialidad", numero);
            });

        },
        error: function (xhr, ajaxOptions, thrownError) {
            //$(ddl).prop("disabled", true);
            //alert(data.error);
            //console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        }
    })
}


$("#btnCancelar").click(function () {
    $("#agregarObraSocial").hide();
});


function actualizarOS(idObraPaciente, NumAfiliado) {

    idOSP = idObraPaciente;

    document.getElementById("agregar").style.display = "none";
    $("#editarObraSocial").show();

    cargarObrasSocialesE("#ddlObraSocialOS", idObraPaciente);
    $("#id__txtNroAfiliadoOS").val(NumAfiliado);

    var idOS = $("#ddlObraSocialOS").val();
    cargarComboPlanes(idOS, "#ddlPlanObraOS");    
}


$("#btnCancelarOS").click(function () {
    $("#editarObraSocial").hide();
    document.getElementById("agregar").style.display = "block";
});


function inactivarE(idPaciente, idObraPaciente) {

      $.ajax({
        type: "POST",
        url: "RegistrarPaciente.aspx/inactivarOSPaciente",
        data: "{idObraPaciente: '" + idObraPaciente + "'}",       
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            //$(ddl).prop("disabled", true);
            //alert(data.error);
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (response) {

            console.log(response.d);

            if (response.d != 'OK') {
                swal("Hubo un problema", "Error al dar de baja la obra social.", "error");
            }
            else {
                $('#btnActfProfesional').show();
                swal("Hecho", "La baja de la obra social se realizó con Éxito.", "success");
                sendDataPacienteOS(idPaciente);
            }

        }
    })
}

function obtenerOSxPaciente(ddl, numero) {    

    $.ajax({
        url: "RegistrarPaciente.aspx/obtenerOSxPaciente",
        data: "{idPaciente: '" + numero + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            if (data.d.length > 0) {
                $(ddl).empty();
                $(ddl).append('<option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>');

                for (i = 0; i < data.d.length; i++) {

                    $(ddl).append($("<option></option>").val(data.d[i].IdObraSocial).html(data.d[i].Descripcion));
                }
                $(ddl).prop("disabled", false);
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            $(ddl).prop("disabled", true);
            alert(data.error);
        }
    });
};

$("#btnAgregar").click(function (e) {
    e.preventDefault();

    var obraPaciente = {

        p_idPaciente: idPaciente,
        p_obraSocial: $("#ddlObraSocialE").val(),
        p_plan: $("#ddlPlanObraE").val(),
        p_nroAfiliado: $("#id__txtNroAfiliadoE").val()       
    }

    console.log(obraPaciente);
    registrarOSxPaciente(obraPaciente);

})


function registrarOSxPaciente(obraPaciente) {

    console.log(obraPaciente);
    $.ajax({
        url: "RegistrarPaciente.aspx/registrarOSPaciente",
        data: JSON.stringify(obraPaciente),
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            console.log(data.d);

            if (data.d != 'OK') {
                alert('Error al agregar la obra social.')
            } else {
                $('#btnConfPaciente').show();
                alert('Obra social registrada con Éxito.');
                $("#agregarObraSocial").hide();
                sendDataPacienteOS(obraPaciente.p_idPaciente);

            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(data.error);
        }

    });

}


function cargarObrasSocialesE(ddl, idObraPaciente) {

    $.ajax({
        url: "RegistrarPaciente.aspx/obtenerOSePaciente",
        type: "post",
        data: "{idObraPaciente: '" + idObraPaciente + "'}",
        contentType: "application/json",
        async: false,
        success: function (data) {

            console.log(data.d[0]);

            if (data.d.length > 0) {
                $(ddl).empty();
                $(ddl).append('<option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>');

                for (i = 0; i < data.d.length; i++) {

                    $(ddl).append($("<option></option>").val(data.d[i].IdObraSocial).html(data.d[i].Descripcion));
                    $(ddl).val(data.d[0].IdObraSocial);
                }
                //$(ddl).val(data.d[0].IdObraSocial).html(data.d[0].Descripcion);
                $(ddl).prop("disabled", true);
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            $(ddl).prop("disabled", false);
            alert(data.error);
        }
    });
};


function actualizarOSPaciente(obraPaciente) {

    
    $.ajax({
        url: "RegistrarPaciente.aspx/actualizarOSPaciente",
        data: JSON.stringify(obraPaciente),
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            console.log(data.d);

            if (data.d != 'OK') {
                alert('Error al actualizar los datos de la obra social del paciente.')
            } else {
                $('#btnConfPaciente').show();
                alert('Los datos de la obra social del paciente se actualizaron con Éxito.');
                $("#agregarObraSocial").hide();
                sendDataPacienteOS(obraPaciente.p_idPaciente);

            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(data.error);
        }

    });

}

$("#btnActualizarOS").click(function (e) {
    e.preventDefault();

    var obraPaciente = {

        p_idObraPaciente: idOSP,
        p_plan: $("#ddlPlanObraOS").val(),
        p_nroAfiliado: $("#id__txtNroAfiliadoOS").val(),
        p_idPaciente: idPaciente
    }

    console.log(obraPaciente);
    actualizarOSPaciente(obraPaciente);

})


function inactivar(idPaciente, paciente) {

    name = paciente;
    idEliminar = idPaciente;

       
    $.ajax({
        url: "RegistrarPaciente.aspx/ObtenerTurnosFuturos",
        data: "{p_id: '" + idPaciente + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            if (data.d === 'sin info') {
                console.log('puedo eliminar directo');

                swal({
                    title: "¿Estas seguro que deseas eliminar el paciente " + paciente + "?",
                    text: "Una vez eliminado, ¡no podrá recuperar los datos asociados al mismo!",
                    icon: "warning",
                    buttons: true,
                    buttons: ["Cancelar", "Eliminar"],
                    dangerMode: true,
                })
                    .then((willDelete) => {
                        if (willDelete) {

                            DaDarDeBajaPaciente(idPaciente, paciente);
                            console.log('dar de baja paciente y relacion con obra social');
                        }
                    });
            }
            else {
                console.log("tengo que mostrar los turnos pendientes");
                ObtenerTurnosFuturos(idPaciente);
                $("#modalTurnos").modal('show');
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(thrownError);
        }
    });

}



function soloNumeros(event) {
    var regex = new RegExp("^[0-9]+$");
    var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
    if (!regex.test(key)) {
        event.preventDefault();
        return false;
    }
};


function soloLetras(event) {
    var regex = new RegExp("^[a-zA-Z ]+$");
    var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
    if (!regex.test(key)) {
        event.preventDefault();
        return false;
    }
};

function deshabilitarCampos(valor) {

    //document.getElementById("id__txtDocumento").focus();   
    document.getElementById("id__txtNombre").readOnly = valor;
    document.getElementById("id__txtApellido").readOnly = valor;
    document.getElementById("id__txtCelular").readOnly = valor;
    document.getElementById("id__txtEmail1").readOnly = valor;
    document.getElementById("id__txtEmail2").readOnly = valor;
    document.getElementById("id__txtNroAfiliado").readOnly = valor;
}

function limpiarCampos() {
    $('#id__txtDocumento').val("");  
    $('#id__txtNombre').val("");
    $('#id__txtApellido').val("");
    $('#id__txtCelular').val("");
    $('#id__txtEmail1').val("");
    $('#id__txtEmail2').val("");
    $('#id__txtNroAfiliado').val("");
    $('#ddlObraSocial').val([]);
    $('#ddlPlanObra').val([]);
}


function buscarPacienteParticular(idBuscar) {

    id = idBuscar;
    $.ajax({
        type: "POST",
        url: "RegistrarPaciente.aspx/buscarPacienteParticular",
        data: "{idPaciente: '" + idBuscar + "'}",
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        async: false,
        success: function (data) {

            var paciente = JSON.parse(data.d);
            console.log(paciente);
            console.log(paciente.length);


            if (paciente != null) {

                paciente.forEach(function (e) {

                    id = e.ID_PACIENTE;
                    // cargo = e.cargo;

                    $("#modalEditar").modal('show');

                    $("#id__AtxtDocumento").val(e.DOCUMENTO);
                    $("#id__AtxtCelular").val(e.NRO_CONTACTO);
                    $("#id__AtxtNombre").val(e.NOMBRE);
                    $("#id__AtxtApellido").val(e.APELLIDO);
                    var email = e.EMAIL_CONTACTO.split('@');
                    $("#id__AtxtEmail1").val(email[0]);
                    $("#id__AtxtEmail2").val(email[1]);
                });
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {

        }
    })
};

function DaDarDeBajaPaciente(IdPaciente, paciente) {

    $.ajax({
        url: "RegistrarPaciente.aspx/DaDarDeBajaPaciente",
        data: "{p_id: '" + IdPaciente + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            if (data.d == "OK") {
                swal("El paciente " + paciente + " fue eliminado con Éxito!.", {
                    icon: "success",
                });
                sendDataPacientes();
            }
            else {
                swal("Hubo un problema", "Error al eliminar el paciente.", "error");
            }

        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(data.error);
            return false;

        }
    });
}


function ObtenerTurnosFuturos(idPaciente) {

    var turnos;
    $.ajax({
        type: "POST",
        url: "RegistrarPaciente.aspx/MostrarTurnosFuturos",
        data: "{p_id: '" + idPaciente + "'}",
        contentType: 'application/json; charset=utf-8',
        async: false,
        success: function (data) {


            turnos = JSON.parse(data.d);

            var arrayTurnos = new Array();

            turnos.forEach(function (e) {

                var turno = e.TURNO;
                var hora = e.HORA;

                arrayTurnos.push([turno, hora]);

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
    DarDeBajaTurnos(idEliminar, name);
});


function DarDeBajaTurnos(idEliminar, name) {

    $.ajax({
        url: "RegistrarPaciente.aspx/DarDeBajaPacienteTurnos",
        data: "{p_id: '" + idEliminar + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            console.log(data.d);

            if (data.d != 'OK') {
                swal("Hubo un problema", "Error al eliminar el paciente.", "error");
            }
            else {
                swal("Hecho", "El paciente " + name + " se elimino con Éxito, y los turnos fueron cancelados.", "success");
                $("#modalTurnos").modal('hide');
                sendDataPacientes();
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(thrownError);
        }
    });

}