const setTrad = { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric' };
var disponibilidadHoraria, turnosXIdProfDetalle, eventosDelDia, esEdicionPaciente, centro, especialidad;
var fechaTurno, horaTurno, minTurno, nombre, apellido, documento, celular, email1, email2, obraSocial;
var planObra, nroAfiliado, idProfesional, calendarDisp, calendarTur, infoTurno, idPaciente;
var tObraPaciente = document.getElementById("tblObraSocialPaciente");
var formObraSocial = document.getElementById("formObraSocial");
var btnRegistrarOS = document.getElementById("btnRegistrarOS");
var btnAgregar = document.getElementById("btnAgregar");
var btnCancelar = document.getElementById("btnCancelar");
var btnRegistrarNew = document.getElementById("btnRegistrarNew");
var btnRegistrarExis = document.getElementById("btnRegistrarExis");



$(document).ready(function () {

    $('#dtpFechaD').datepicker({
        autoclose: true,
        format: "dd/mm/yyyy",
        startDate: '+1d'
    });

    btnRegistrarExis.disabled = true;

    $('#modalTurno').modal('hide');
    $('#tListarTurnos').show();
   // $('#tblObraSocialPaciente').show();
    $('#ddlProfesional').select2({ theme: "bootstrap4", placeholder: "-- Seleccione --" });

    $('#crdDatosPersonales').hide();
    $(".paciente").hide();
    $("#calDisposicionHoraria").hide();
    $("#calTurnos").hide();
    $("#ddlSucursal").prop("disabled", true);
    $("#ddlEspecialidad").prop("disabled", true);
    $("#ddlProfesional").prop("disabled", true);
    $("#ddlObraSocial").prop("disabled", true);
    cargarComboCentros('#ddlSucursal');   
    //cargarObrasSociales("#ddlObraSocial");

    btnRegistrarExis.style.display = "none";
    btnRegistrarNew.style.display = "none";

    $('#btnRegistrarNew').click(function () {

        centro = $('#ddlSucursal').val();
        especialidad = $('#ddlEspecialidad').val();
        //fechaTurno = $('#dtpFechaD').val();
        //horaTurno = $('#ddlHoraDesde').val();
        //obraSocial = $('#ddlObraSocial').val();
        //minTurno = $('#ddlMinDesde').val();
        nombre = $('#txtNombre').val();
        apellido = $('#txtApeliido').val();
        documento = $('#txtDocumento').val();
        celular = $('#txtCelular').val();
        email1 = $('#txtEmail1').val();
        email2 = $('#txtEmail2').val();
        obraSocial = $('#ddlObraSocial').val();
        planObra = $('#ddlPlanObra').val();
        nroAfiliado = $('#txtNroAfiliado').val();

        var validacion = validarDatosTurno();

        if (validacion === true) {

            var turnoYPersona = {
                p_centro: centro,
                p_especialidad: especialidad,
                p_fechaTurno: fechaTurno,
                p_horaTurno: horaTurno,
                //p_obra_social: obraSocial,
                //p_minTurno: minTurno,
                p_nombre: nombre,
                p_apellido: apellido,
                p_documento: documento,
                p_celular: celular,
                p_email1: email1,
                p_email2: email2,
                p_obraSocial: obraSocial,
                p_planObra: planObra,
                p_nroAfiliado: nroAfiliado,
                p_profesional: $('#ddlProfesional').val(),
                es_edicion: esEdicionPaciente
            }

            registrarTurnoNew(turnoYPersona);
            $('#modalTurno').modal('hide');
            $("#calDisposicionHoraria").hide();
            $("#calTurnos").hide();

            limpiarCampos();
        }
    });

    $("#ddlSucursal").bind("change", function () {

        centro = $('#ddlSucursal').val();
        cargarEspecialidades(centro, "#ddlEspecialidad");
        cargarObrasSociales("#ddlObraSocial", centro);

    });

    $("#ddlEspecialidad").bind("change", function () {

        var idEspecialidad = $('#ddlEspecialidad').val();
        cargarProfesionales(centro, idEspecialidad, "#ddlProfesional");

    });

    $("#ddlProfesional").bind("change", function () {

        var idEspecialidad = $('#ddlEspecialidad').val();
        idProfesional = $('#ddlProfesional').val();
        dibujaCalendarioDisp(idEspecialidad);
        CargarEventosFullCalendar(idProfesional, idEspecialidad, centro);
    });


    $('#btnBuscarDNI').click(function () {
         
        var dniPaciente = $('#txtDocumento').val();
        buscarPaciente(dniPaciente);

    });

    $("#ddlObraSocial").bind("change", function () {

        var idObraSocial = $('#ddlObraSocial').val();
        cargarComboPlanes(idObraSocial, "#ddlPlanObra");
        //$('#ddlPlanObra').prop('disabled', false);   
    });

});

function buscarPaciente(dniPaciente) {
    $.ajax({
        url: "RegistrarTurno.aspx/buscarPaciente",
        data: "{dniPaciente: '" + dniPaciente + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            var paciente = JSON.parse(data.d); 
                        
            if (data.d != "null") {
                $('#txtDocumento').prop('disabled', true);
                $('#txtCelular').prop('disabled', false);
                $('#txtNombre').prop('disabled', false);
                $('#txtApeliido').prop('disabled', false);
                $('#txtEmail1').prop('disabled', false);
                $('#txtEmail2').prop('disabled', false);
                $('#ddlObraSocial').prop('disabled', false);
                $('#ddlPlanObra').prop('disabled', true);
                $('#txtNroAfiliado').prop('disabled', true);

                $('#txtCelular').val(paciente.NroContacto);
                $('#txtNombre').val(paciente.Nombre);
                $('#txtApeliido').val(paciente.Apellido);

                var pacienteEmail = paciente.EmailContacto.split('@');

                $('#txtEmail1').val(pacienteEmail[0]);
                $('#txtEmail2').val(pacienteEmail[1]);

                idPaciente = paciente.IdPaciente;

                esEdicionPaciente = true;

                var texto = "Seleccione Obra Social";
                $("#textObraSocial").text(texto);

                $("#crdObraSocial").show(); 
                $("#tblObraSocialPaciente").show();

                btnRegistrarExis.style.display = "block"; 
                btnRegistrarExis.disabled = true;
                formObraSocial.style.display = "none";
                btnRegistrarNew.style.display = "none";
                              
                sendDataPacienteOS(idPaciente);

            }
            else {

                $('#txtDocumento').prop('disabled', false);

                $('#txtCelular').prop('disabled', false);
                $('#txtNombre').prop('disabled', false);
                $('#txtApeliido').prop('disabled', false);
                $('#txtEmail1').prop('disabled', false);
                $('#txtEmail2').prop('disabled', false);
                $('#ddlObraSocial').prop('disabled', false);
                $('#ddlPlanObra').prop('disabled', true);
                $('#txtNroAfiliado').prop('disabled', true);


                var texto = "Datos Obra Social";
                $("#textObraSocial").text(texto);


                $("#crdObraSocial").show();
                $("#formObraSocial").show();
                btnRegistrarNew.style.display = "block";

                
                tObraPaciente.style.display = "none";                
                btnRegistrarOS.style.display = "none";                
                btnAgregar.style.display = "none";                
                btnCancelar.style.display = "none";
                btnRegistrarExis.style.display = "none";
               
                esEdicionPaciente = true;               
            }
            
        }
    });
}

function obtenerDisponibilidadHoraria(idProfesional, idEspecialidad, centro, dia = "") {
    var disponibilidadHoraria;

    $.ajax({
        url: "RegistrarTurno.aspx/traerDisponibilidadHoraria",
        data: "{idProfesional: '" + idProfesional + "', idEspecialidad: '" + idEspecialidad + "', idCentro: '" + centro + "', dia: '" + dia + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            disponibilidadHoraria = JSON.parse(data.d);

        }
    });

    return disponibilidadHoraria;
}

function CargarEventosFullCalendar(idProfesional, idEspecialidad, centro) {
    var eventos = [];

    var disponibilidadHoraria = obtenerDisponibilidadHoraria(idProfesional, idEspecialidad, centro);

    disponibilidadHoraria.forEach(function (e) {

        var dateInic = new Date(e.FECHA_INIC);
        var dateFin = new Date(e.FECHA_FIN);

        var diasArray = obtenerDiasSinFindesemanas(dateInic, dateFin);

        eventos = armarSemanasSinFindesemanas(diasArray);

    });

    calendarDisp.addEventSource(eventos);
}

function obtenerDiasSinFindesemanas(startDate, stopDate) {
    var diasArray = new Array();
    var currentDate = startDate;
    while (currentDate <= stopDate) {
        var diaNombre = currentDate.toLocaleString('es-es', { weekday: 'long' });
        if (!(diaNombre.startsWith('dom') || diaNombre.startsWith('sáb'))) {
            diasArray.push(new Date(currentDate));
            currentDate = currentDate.addDays(1);
        }
        else {
            currentDate = currentDate.addDays(1);
        }
    }
    return diasArray;
}

function armarSemanasSinFindesemanas(diasArray) {
    var dispHor = [];

    var dispHorSemana = '{"title": "Disponibilidad", "start": "", "end":""}';

    for (i = 0; i < diasArray.length; i++) {

        var obj = JSON.parse(dispHorSemana);
        var diaObj = diasArray[i];

        var hoy = new Date();
        if (hoy <= diaObj) {
            var diaFormated = getFormattedDateInversed(diaObj);
            obj.start = diaFormated;
            obj.end = diaFormated;
            dispHor.push(obj);
        }
    }
    return dispHor;
}

function obtenerTurnosXDia(idProfesional, dia) {
    var turnosXIdProf;

    $.ajax({
        url: "RegistrarTurno.aspx/traerTurnos",
        data: "{idProfesional: '" + idProfesional + "', dia: '" + dia + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            turnosXIdProf = JSON.parse(data.d);

        }
    });
    return turnosXIdProf;
}

function obtenerHorarios(idProfesional, idEspecialidad, dia) {

    var disponibilidad = [];
    var disponibilidadXDia = '{"title": "Disponible", "start": "", "end":"", "color":"green"}';
    var disponibilidadHoraria = obtenerDisponibilidadHoraria(idProfesional, idEspecialidad, centro, dia);

    for (i = 0; i < disponibilidadHoraria.length; i++) {

        var horaInicio = disponibilidadHoraria[i].HORA_DESDE;
        var horaHasta = disponibilidadHoraria[i].HORA_HASTA;
        var dispStart = moment(dia + ' ' + horaInicio, 'YYYY-MM-DD HH:mm:ss');
        var dispEnd = moment(dia + ' ' + horaHasta, 'YYYY-MM-DD HH:mm:ss');

        for (i = 0; !dispStart.isSame(dispEnd); i++) {
            var obj = JSON.parse(disponibilidadXDia);

            obj.start = dispStart.format();
            obj.end = dispStart.add(15, 'm').format();

            disponibilidad.push(obj);
        }
    }

    var turnos = [];
    var disponibilidad2 = disponibilidad;
    var turnosXIdProf = obtenerTurnosXDia(idProfesional, dia);
    var turnosXDia = '{"title": "Turno", "start": "", "end":"", "color":"#007bff"}';//, "color":"blue"  #007bff

    for (i = 0; i < turnosXIdProf.length; i++) {

        for (j = 0; j < disponibilidad.length; j++) {

            var turno = moment(dia + ' ' + turnosXIdProf[i].HORA_DESDE, 'YYYY-MM-DD HH:mm:ss');
            var fecha = disponibilidad[j].start.split('T');
            var dispon = moment(fecha[0] + ' ' + fecha[1], 'YYYY-MM-DD HH:mm:ss');

            if (turno.isSame(dispon)) {
                //elimino de disponibilidad2
                var obj = JSON.parse(turnosXDia);

                var turno = moment(dia + ' ' + turnosXIdProf[i].HORA_DESDE, 'YYYY-MM-DD HH:mm:ss');
                obj.start = turno.format();
                obj.end = turno.add(15, 'm').format();

                obj.title = turnosXIdProf[i].ESPECIALIDAD + ' - Turno Confirmado.';

                disponibilidad2[j] = obj;
            }

        }

    }
    return disponibilidad2;
}

Date.prototype.addDays = function (days) {
    var date = new Date(this.valueOf());
    date.setDate(date.getDate() + days);
    return date;
}

function dibujaCalendarioTurnos(dia, idEspecialidad) {
    eventosDelDia = obtenerHorarios(idProfesional, idEspecialidad, dia);

    var calendarTurnos = document.getElementById('calendarioTurnos');
    calendarTur = new FullCalendar.Calendar(calendarTurnos, {
        initialDate: dia,//'2020-09-12',
        initialView: 'timeGridDay',
        customButtons: {
            btnListarTurnos: {
                text: 'Listar Turnos',
                click: function () {
                    btnListarTurnoClick(obtenerTurnosXDia(idProfesional, dia));
                }
            }
        },
        headerToolbar: {
            left: 'title',
            center: '',
            right: 'btnListarTurnos'
        },
        //selectable: true,
        //editable: true,
        //select: function (arg) {
        //    mostrarModalTurno(arg);                  
        //},

        eventClick: function (info) {
            mostrarModalTurno(info)
        },

        locale: 'ES',
        slotMinTime: '08:00:00',
        slotMaxTime: '21:00:00',
        slotDuration: '00:15:00',
        slotLabelInterval: '00:15:00',
        slotLabelFormat: [
            {
                hour: 'numeric',
                minute: '2-digit',
                omitZeroMinute: false,
                meridiem: 'short'
            }
        ],
    });
    $("#calTurnos").show();
    calendarTur.render();

    calendarTur.addEventSource(eventosDelDia);
}

function btnListarTurnoClick(turnos) {

    $('#modalListarTurnos').modal('show');
    var arrayTurnosTabla = new Array();

    $('#lblListarTurnos').text($('#ddlEspecialidad option:selected').text());

    if (turnos != null) {
        turnos.forEach(function (e) {
            var fecha = getFormattedDate(new Date(e.FECHA_TURNO));
            var hora = e.HORA_DESDE;
            var especialidad = e.ESPECIALIDAD;
            var prof = e.PROFESIONAL;
            var paciente = e.PACIENTE;

            arrayTurnosTabla.push([fecha, hora, especialidad, prof, paciente]);

        });
    }
    var table = $('#tablaListarTurnos').DataTable({
        data: arrayTurnosTabla,
        "scrollX": true,
        "languaje": {
            "url": "//cdn.datatables.net/plug-ins/1.10.12/i18n/Spanish.json"
        },
        "ordering": true,
        "bDestroy": true,
        "bAutoWidth": true,
        columns: [
            { title: "FECHA" },
            { title: "HORA" },
            { title: "ESPECIALIDAD" },
            { title: "PROFESIONAL" },
            { title: "PACIENTE" }
        ],
        //dom: 'Bfrtip',
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
}

function mostrarModalTurno(arg) {
    if (arg.event.backgroundColor == 'green') {

        limpiarModalTurno();
        $('#modalTurno').modal('show');

        var dia = new Date(arg.event.startStr);
        var hora = String(dia.getHours()).padStart(2, '0') + ':' + String(dia.getMinutes()).padStart(2, '0');
        var diaTrad = $('#ddlEspecialidad option:selected').text() + ': ' + dia.toLocaleDateString('es-ES', setTrad) + ', ' + hora + '.';
        $("#lblTituloTurno").text(diaTrad);
        fechaTurno = getFormattedDateInversed(dia);
        horaTurno = hora;
    }
    else {
        swal("Cuidado", "Elija un horario Disponible.", "warning");
    }

}

function dibujaCalendarioDisp(idEspecialidad) {
    $("#calDisposicionHoraria").show();
    var calendarEl = document.getElementById('calendarioDispHor');
    calendarDisp = new FullCalendar.Calendar(calendarEl, {

        initialView: 'dayGridMonth',
        selectable: true,
        dayMaxEvents: true,
        headerToolbar: {
            left: 'title',
            center: '',
            right: 'prev,next' // timeGridWeek,
        },
        locale: 'ES',
        eventClick: function (info) {
            var dia = info.event.startStr;

            $("#calDisposicionHoraria").hide();
            $("#calTurnos").show;
            dibujaCalendarioTurnos(dia, idEspecialidad);
        }
    });
    calendarDisp.render();
}

function volver() {
    $("#calDisposicionHoraria").show();
    $("#calTurnos").hide();
}

function limpiarCampos() {

    $('#ddlSucursal').val(0);
    $('#ddlEspecialidad').empty();
    $('#ddlEspecialidad').append('<option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>');
    $('#ddlEspecialidad').prop("disabled", true);
    $('#ddlProfesional').empty();
    $('#ddlProfesional').append('<option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>');
    $('#ddlProfesional').prop("disabled", true);
    $("#dtpFechaD").datepicker('clearDates');
    $('#ddlHoraDesde').val('8');
    $('#ddlObraSocial').val(0);
    //$('#ddlObraSocial').append('<option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>');
    $('#ddlObraSocial').prop("disabled", true);
    $('#ddlMinDesde').val('00');
    $('#txtNombre').val("");
    $('#txtApeliido').val("");
    $('#txtDocumento').val("");
    $('#txtCelular').val("");
    $('#txtEmail1').val("");
    $('#txtEmail2').val("");
}

function limpiarModalTurno() {

    $('#txtDocumento').prop('disabled', false);
    $('#txtCelular').prop('disabled', true);
    $('#txtNombre').prop('disabled', true);
    $('#txtApeliido').prop('disabled', true);
    $('#txtEmail1').prop('disabled', true);
    $('#txtEmail2').prop('disabled', true);
    $('#ddlObraSocial').prop('disabled', true);
    $('#ddlPlanObra').prop('disabled', true);
    $('#txtNroAfiliado').prop('disabled', true);


    $('#txtNombre').val("");
    $('#txtApeliido').val("");
    $('#txtDocumento').val("");
    $('#txtCelular').val("");
    $('#txtEmail1').val("");
    $('#txtEmail2').val("");
    $('#ddlObraSocial').val(0);
    $('#ddlPlanObra').empty();
    $('#txtNroAfiliado').val("");;

}

function cargarProfesionales(idCentro, idEspecialidad, ddl) {

    $.ajax({
        url: "RegistrarTurno.aspx/cargarProfesionales",
        data: "{idCentro: '" + idCentro + "', idEspecialidad: '" + idEspecialidad + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {
            var profesionales = JSON.parse(data.d);
            if (profesionales != null) {

                $(ddl).empty();
                $(ddl).append('<option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>');

                profesionales.forEach(function (e) {
                    $(ddl).append($("<option></option>").val(e.ID_PROFESIONAL).html(e.NOMBRE));
                });
                $(ddl).prop("disabled", false);
            }
            else {
                $(ddl).prop("disabled", true);
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            $(ddl).prop("disabled", true);
        }
    });
}

function cargarEspecialidades(idCentro, ddl) {

    $.ajax({
        url: "RegistrarTurno.aspx/cargarEspecialidades",
        data: "{idCentro: '" + idCentro + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {
            var especialidades = JSON.parse(data.d);
            //disponibilidadHoraria = especialidades;
            if (especialidades != null) {

                $(ddl).empty();
                $(ddl).append('<option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>');

                especialidades.forEach(function (e) {
                    $(ddl).append($("<option></option>").val(e.ID_ESPECIALIDADES).html(e.DESCRIPCION));
                });
                $(ddl).prop("disabled", false);
            }
            else {
                $(ddl).prop("disabled", true);
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            $(ddl).prop("disabled", true);
        }
    });
}

function cargarObrasSociales(ddl, idCentro) {

   // idCentro = $("#ddlSucursal").val();

    $.ajax({
        url: "RegistrarTurno.aspx/cargarObrasSocialesById",
        data: "{idCentro: '" + idCentro + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            console.log(data.d);

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
}

function cargarComboCentros(ddl) {

    $.ajax({
        url: "RegistrarTurno.aspx/cargarCentros",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            if (data.d.length > 0) {
                $(ddl).empty();
                $(ddl).append('<option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>');

                for (i = 0; i < data.d.length; i++) {

                    $(ddl).append($("<option></option>").val(data.d[i].IdCentro).html(data.d[i].NombreCentro));
               
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

function cargarComboPlanes(idObraSocial, ddl) {

    $.ajax({
        url: "RegistrarTurno.aspx/cargarPlanes",
        data: "{idObraSocial: '" + idObraSocial + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {
            var planes = JSON.parse(data.d);
            //disponibilidadHoraria = especialidades;

            if (planes.length > 0) {

                $(ddl).empty();
                $(ddl).append('<option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>');

                planes.forEach(function (e) {
                    $(ddl).append($("<option></option>").val(e.ID_PLANES).html(e.DESCRIPCION));
                });
                $("#ddlPlanObra").prop("disabled", false);
                $('#txtNroAfiliado').prop('disabled', false);

            }
            else {
                $("#ddlPlanObra").prop("disabled", true);
                $('#txtNroAfiliado').prop('disabled', true);

            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            $(ddl).prop("visible", true);
        }
    });
}

function registrarTurnoNew(datosTurno) {

    $.ajax({
        url: "RegistrarTurno.aspx/RegistrarTurnoNew",
        data: JSON.stringify(datosTurno),
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            console.log(data.d);

            if (data.d != 'OK') {
                //alert('Error al registrar turno.')
                swal("Hubo un problema", "Error al registrar el turno!", "error");
            } else {
                $('#btnConfTurno').show();
                //alert('Turno registrado con Éxito.')
                swal("Hecho", "Turno registrado con éxito!", "success");
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(data.error);
        }

    });
}

function validarDatosTurno() {

    if (centro == null) {
        swal("Cuidado", "Ingrese un Centro", "warning");
        return false;
    }
    else if (especialidad == null) {
        swal("Cuidado", "Ingrese una Especialidad", "warning");
        return false;
    }
    else if (fechaTurno == "") {
        swal("Cuidado", "Ingrese una Fecha", "warning");
        return false;
    }
    else if (horaTurno == null) {
        return false;
    }
    else if (nombre == "") {
        swal("Cuidado", "Ingrese un Nombre", "warning");
        return false;
    }
    else if (apellido == "") {
        swal("Cuidado", "Ingrese un Apellido", "warning");
        return false;
    }
    else if (documento == "") {
        swal("Cuidado", "Ingrese un Documento", "warning");
        return false;
    }
    else if (celular == "") {
        swal("Cuidado", "Ingrese un Celular", "warning");
        return false;
    }
    else if (email1 == "") {
        swal("Cuidado", "Ingrese un Email válido", "warning");
        return false;
    }
    else if (email2 == "") {
        swal("Cuidado", "Ingrese un Email válido", "warning");
        return false;
    }
    else if (obraSocial == "") {
        swal("Cuidado", "Ingrese una Obra Social", "warning");
        return false;
    }
    else {
        return true;
    };
};


function sendDataPacienteOS(numero) {
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
                var idObraSocial = e.ID_OBRA_SOCIAL;
                var idCodPlan = e.ID_PLAN;
                var ObraSocial = e.DESCRIPCION;
                var CodigoPlan = e.COD_PLAN;
                var Plan = e.PLAN;
                var NumAfiliado = e.NRO_AFILIADO;
                


                var Acciones = '<a href="#" onclick="return seleccionarOS(' + idObraPaciente + ",'" + numero + "'" + ')"  class="btn btn-info btnSeleccionarOS" > <span class="fa-solid fa-square-check"></span></a>' +
                               '<a href="#" onclick="return inactivarE(' + numero + ",'" + idObraPaciente + "'" + ')" class="btn btn-danger btnInactivarE"> <span class="fas fa-minus-square"></span></a >';


                arrayPacienteOS.push([
                    idObraPaciente, idObraSocial, ObraSocial, idCodPlan, CodigoPlan, Plan, NumAfiliado, Acciones
                ])

            });

            if (arrayPacienteOS.length >= 1) {

                console.log(arrayPacienteOS);
                var table = $('#tablaOSPaciente').DataTable({
                    data: arrayPacienteOS,
                    select: true,
                    "scrollX": true,
                    "languaje": {
                        "url": "//cdn.datatables.net/plug-ins/1.10.12/i18n/Spanish.json"
                    },
                    "ordering": true,
                    "bDestroy": true,
                    "bAutoWidth": true,
                    "order": [1, "asc"],
                    columns: [
                        { title: "idObraPaciente", visible: false },
                        { title: "idObraSocial", visible: false },
                        { title: "Obra Social" },
                        { title: "idCodPlan", visible: false },
                        { title: "Codigo Plan" },
                        { title: "Plan" },
                        { title: "Nro. Afiliado" },
                        { title: "Acciones " }
                    ],
                    //dom: 'Bfrtip',
                    //dom: '<"top"B>rti<"bottom"fp><"clear">',
                    "oLanguage": {
                        "sLengthMenu": "Mostrar _MENU_ resultados por página",
                        "sSearch": "Filtrar:",
                        "oPaginate": {
                            "sPrevious": "Anterior",
                            "sNext": "Siguiente"
                        },
                    },
                    "bPaginate": true,
                    "pageLength": 3,
                    //buttons: [
                    //    //{ extend: 'copy', text: "Copiar" },
                    //    { extend: 'print', text: "Imprimir" },
                    //    { extend: 'pdf', orientation: 'landscape' },
                    //    { extend: 'colvis', columns: ':not(:first-child)', text: "Ocultar/Mostrar columnas" }
                    //]
                });
                $('.dataTables_filter input').attr("placeholder", "Filtrar por...");
                            
                btnRegistrarOS.style.display = "none";

            }
            else {

                        
                tObraPaciente.style.display = "none";            
                btnRegistrarOS.style.display = "block";
            }
         

      

        },
        error: function (xhr, ajaxOptions, thrownError) {

          
            //$(ddl).prop("disabled", true);
            //alert(data.error);
            //console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        }
    })
}


function inactivarE(idPaciente, idObraPaciente) {

    console.log(idPaciente, idObraPaciente);

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

//$("#btnRegistrarOS").click(e){ }


$("#btnRegistrarOS").click(function (e) {
    e.preventDefault();    
    formObraSocial.style.display = "block";    
    btnRegistrarOS.style.display = "none";
});


$("#btnCancelar").click(function () {   
    formObraSocial.style.display = "none";
    btnRegistrarOS.style.display = "block";
});


$("#btnAgregar").click(function (e) {
    e.preventDefault();

    var obraPaciente = {

        p_idPaciente: idPaciente,
        p_obraSocial: $("#ddlObraSocial").val(),
        p_plan: $("#ddlPlanObra").val(),
        p_nroAfiliado: $("#txtNroAfiliado").val()
    }

    //console.log(obraPaciente);
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

               
                formObraSocial.style.display = "none";
                btnRegistrarOS.style.display = "none";
                tObraPaciente.style.display = "block";
                sendDataPacienteOS(obraPaciente.p_idPaciente);

            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(data.error);
        }

    });

};


function seleccionarOS(idObraPaciente, numero) {
    btnRegistrarExis.disabled = true;

    centro = $('#ddlSucursal').val();
    especialidad = $('#ddlEspecialidad').val();

    var table = $('#tablaOSPaciente').DataTable();
    $('#tablaOSPaciente tbody').on('click', 'tr', function (e) {

        e.preventDefault();

        // console.log(table.row(this).data());

        var resulfila = [];
        resulfila = table.row(this).data();      
 
        obraTurnoPaciente = {
            p_centro: centro,
            p_especialidad: especialidad,
            p_fechaTurno: fechaTurno,
            p_horaTurno: horaTurno,
            p_idPaciente: numero,
            p_idObraSocial: resulfila[1],
            p_idPlan: resulfila[3],
            p_nroAfiliado: resulfila[6],
            p_profesional: $('#ddlProfesional').val(),
            p_idObraPaciente: idObraPaciente,
            p_descripionOS: resulfila[2],
            p_codPlan : resulfila[4],
            p_nombrePlan : resulfila[5]
        }

      //  let lengthOfObject = Object.keys(obraTurnoPaciente).length;

        console.log(obraTurnoPaciente);    
       

        btnRegistrarExis.disabled = false;
        //console.log(resulfila);
    }
    );
        
}

$('#btnRegistrarExis').click(function (e) {
    e.preventDefault();
    console.log(obraTurnoPaciente);
    registrarSoloTurno(obraTurnoPaciente);
    $('#modalTurno').modal('hide');
    $("#calDisposicionHoraria").hide();
    $("#calTurnos").hide();

});

function registrarSoloTurno(obraTurnoPaciente) {

    $.ajax({
        url: "RegistrarTurno.aspx/RegistrarSoloTurno",
        data: JSON.stringify(obraTurnoPaciente),
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            console.log(data.d);

            if (data.d != 'OK') {
                //alert('Error al registrar turno.')
                swal("Hubo un problema", "Error al registrar el turno!", "error");
            } else {
                $('#btnConfTurno').show();
                //alert('Turno registrado con Éxito.')
                swal("Hecho", "Turno registrado con éxito!", "success");
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(data.error);
        }

    });
}

