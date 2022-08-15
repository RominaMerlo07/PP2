var centro;
var disponibilidadHoraria;
//var eventosDispHor = [];
var arrayTurnosTabla = [];
var idTurnoTratamiento = [];
var idPaciente, nroAfiliado;

$(document).ready(function () {

    cargarTablaTratamientos("");
    $(".dataTables_scrollHeadInner").css({ "width": "100%" });
    $(".table ").css({ "width": "100%" });

    $('#btnBuscarDNIFiltrar').click(function () {

        var dniPaciente = $('#txtDocumentoFiltrar').val();
        buscarPacienteFiltrar(dniPaciente);
        cargarTablaTratamientos($('#txtIdPacienteFiltrar').val());
    });

    // #region editarTratamiento
    $("#ddlDiaTurnoEd").bind("change", function () {
        var valueArr = $("#ddlDiaTurnoEd").val().split('|');
        cargarHorasEd(disponibilidadHoraria, valueArr[1]);

    });

    $('#btnAgregarTurnoEd').click(function () {
        debugger;
        if ($("#ddlDiaTurnoEd").val() != 0) {
            var nuevoTurnoTratamiento;
            nuevoTurnoTratamiento = armarArrayTurnoEd();

            agregarTurnoEditado(nuevoTurnoTratamiento);
        } else {
            swal("Cuidado!", "Seleccione el día!", "warning");
        }
        
    });
    // #endregion

    // #region btnModalCreaTratamiento

    $('#btnBuscarDNI').click(function () {

        var dniPaciente = $('#txtDocumento').val();
        buscarPaciente(dniPaciente);

    });

    $("#ddlObraSocial").bind("change", function () {

        var idObraSocial = $('#ddlObraSocial').val();
        cargarComboPlanesPaciente(idObraSocial, "#ddlPlanObra", idPaciente);
        //cargarComboPlanes(idObraSocial, "#ddlPlanObra");
        //$('#ddlPlanObra').prop('disabled', false);   
    });


    $("#ddlPlanObra").bind("change", function () {
        $('#txtNroAfiliado').val(nroAfiliado);
        console.log(nroAfiliado);
    });

    $("#ddlSucursal").bind("change", function () {

        $('#ddlEspecialidad').empty();
        $('#ddlEspecialidad').append('<option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>');
        $('#ddlEspecialidad').prop("disabled", true);
        $('#ddlProfesional').empty();
        $('#ddlProfesional').append('<option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>');
        $('#ddlProfesional').prop("disabled", true);

        limpiarDatosTratamiento();

        centro = $('#ddlSucursal').val();
        cargarEspecialidades(centro, "#ddlEspecialidad");

    });

    $("#ddlEspecialidad").bind("change", function () {

        $('#ddlProfesional').empty();
        $('#ddlProfesional').append('<option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>');
        $('#ddlProfesional').prop("disabled", true);

        limpiarDatosTratamiento();

        var idEspecialidad = $('#ddlEspecialidad').val();
        cargarProfesionales(centro, idEspecialidad, "#ddlProfesional");

    });

    $("#ddlProfesional").bind("change", function () {

        limpiarDatosTratamiento();

        var idEspecialidad = $('#ddlEspecialidad').val();
        idProfesional = $('#ddlProfesional').val();

        obtieneDisponibilidadHoraria(idProfesional, idEspecialidad, centro);

    });

    $("#ddlDiaTurno").bind("change", function () {
        var valueArr = $("#ddlDiaTurno").val().split('|');
        cargarHoras(disponibilidadHoraria, valueArr[1]);

    });

    $('#btnRegistrar').click(function () {

        var validacion = validarDatosTratamiento();

        if (validacion) {
            var arrayRegistrar = [];
            var idPaciente = $('#txtIdPaciente').val();
            var idObraSocial = $('#ddlObraSocial').val();
            var idPlanObra = $('#ddlPlanObra').val();
            var nroAfiliado = $('#txtNroAfiliado').val();
            var NroAutorizacion = $('#txtNroAutorizacion').val();

            var longitudArray = arrayTurnosTabla.length;
            for (var i = 0; i < longitudArray; i++) {
                var turno = {
                    p_idPaciente: idPaciente,
                    p_idObraSocial: idObraSocial,
                    p_idPlanObra: idPlanObra,
                    p_nroAfiliado: nroAfiliado,
                    p_nroAutorizacion: NroAutorizacion,
                    p_idSucursal: arrayTurnosTabla[i][1],
                    p_idEspecialidad: arrayTurnosTabla[i][3],
                    p_idProfesional: arrayTurnosTabla[i][5],
                    p_DiaTurno: arrayTurnosTabla[i][7],
                    p_HoraTurno: arrayTurnosTabla[i][9]
                }

                arrayRegistrar.push(turno);
            }

            $.ajax({
                url: "GestionTratamientos.aspx/registrarTratamiento",
                data: "{arrayTratamiento: '" + JSON.stringify(arrayRegistrar)
                    + "'}",
                type: "post",
                contentType: "application/json",
                async: false,
                success: function (data) {

                    $("#modalGenerarTratamiento").modal('hide');
                    swal("Hecho", "Tratamiento registrado con éxito!", "success");

                },
                error: function (xhr, ajaxOptions, thrownError) {
                    swal("Cuidado", "Ha habido un error al registrar el Tratamiento.", "warning");
                }
            });
        }

    });

    $('#btnModalCreaTratamiento').click(function () {

        cargarObrasSociales("#ddlObraSocial");

        cargarComboCentros('#ddlSucursal');
        limpiarModalCreaTratamiento();

        $("#modalGenerarTratamiento").modal('show');
    });

    $('#btnAgregarTurno').click(function () {

        var nuevoTurnoTratamiento = []
        nuevoTurnoTratamiento = armarArrayTurno()[0];

        if (typeof nuevoTurnoTratamiento !== 'undefined') {
            var verificacion = verificarTurnoDisponible(nuevoTurnoTratamiento[1], nuevoTurnoTratamiento[3], nuevoTurnoTratamiento[5], nuevoTurnoTratamiento[7], nuevoTurnoTratamiento[9]);

            if (verificacion) {
                $("#msgAgregado").show();
                $("#msgNoDisponible").hide();
                $("#msgYaAgregado").hide();

                arrayTurnosTabla.push(nuevoTurnoTratamiento);
                dibujaTablaTurnos(arrayTurnosTabla);
                idTurnoTratamiento.push(nuevoTurnoTratamiento[0]);

            }
            else {
                $("#msgAgregado").hide();
                $("#msgNoDisponible").show();
                $("#msgYaAgregado").hide();

            }
        }
        else {
            $("#msgYaAgregado").show();
            $("#msgAgregado").hide();
            $("#msgNoDisponible").hide();
        }
    });

    // #endregion
});

function cargarTablaTratamientos(idPaciente) {

    $.ajax({
        url: "GestionTratamientos.aspx/traerTratamientos",
        data: "{idPaciente: '" + idPaciente + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            var datos = JSON.parse(data.d);
            var tratamientos = [];
            datos.forEach(function (e) {
                var idTratamiento = e.ID_TRATAMIENTO;
                var fechaAlta = getFormattedDate(new Date(e.FECHA_ALTA));
                var centro = e.CENTRO;
                var especialidad = e.ESPECIALIDAD;
                var profesional = e.PROFESIONAL;
                var paciente = e.PACIENTE;
                var obraSocial = e.OBRA_SOCIAL;
                var nroAfiliado = e.NRO_AFILIADO;
                var nroAutorizacionObra = e.NRO_AUTORIZACION_OBRA;

                var Acciones = '<a href="#" onclick="return editarTratamiento(' + idTratamiento + ')"  class="btn btn-primary" > <span class="fa fa-pencil" title="Editar"></span></a > ' +
                    '<a href="#" onclick="return cancelarTratamiento(' + idTratamiento + ')"  class="btn btn-danger btnCancelar" > <span class="fa fa-trash" title="Dar de baja"></span></a > ';

                tratamientos.push([idTratamiento, fechaAlta, centro, especialidad, profesional, paciente, obraSocial, nroAfiliado, nroAutorizacionObra, Acciones]);
            });

            var table = $('#tablaTratamientos').DataTable({
                data: tratamientos,
                "scrollX": true,
                "languaje": {
                    "url": "//cdn.datatables.net/plug-ins/1.10.12/i18n/Spanish.json"
                },
                "ordering": true,
                "bDestroy": true,
                "bAutoWidth": true,
                columns: [
                    { title: "NRO. TRATAMIENTO" },
                    { title: "FECHA ALTA" },
                    { title: "CENTRO" },
                    { title: "ESPECIALIDAD" },
                    { title: "PROFESIONAL" },
                    { title: "PACIENTE" },
                    { title: "OBRA SOCIAL" },
                    { title: "NRO. AFILIADO" },
                    { title: "NRO. AUTORIZACION" },
                    { title: "ACCIONES" }
                ],
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
                    {
                        extend: 'print',
                        text: "Imprimir",
                        exportOptions: {
                            columns: [1]
                        }
                    },
                    {
                        extend: 'pdf', /*orientation: 'landscape'*/
                        exportOptions: {
                            columns: [1]
                        }
                    },
                    { extend: 'colvis', columns: ':not(:first-child)', text: "Ocultar/Mostrar columnas" }
                ]
            });
            $('.dataTables_filter input').attr("placeholder", "Filtrar por...");
        }
    });
}

function buscarPacienteFiltrar(dniPaciente) {
    $.ajax({
        url: "GestionTratamientos.aspx/buscarPaciente",
        data: "{dniPaciente: '" + dniPaciente + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {
            var paciente = JSON.parse(data.d);
            var datosPaciente;

            if (data.d != "null") {
                datosPaciente = paciente.Apellido + " " + paciente.Nombre;
                $('#txtIdPacienteFiltrar').val(paciente.IdPaciente);

            } else {
                datosPaciente = "";
                swal("Paciente no encontrado", "Por favor primero registre al paciente.", "warning");
            }
            $('#txtPacienteFiltrar').val(datosPaciente);
        }
    });
}

// #region editarTratamiento

function editarTratamiento(idTratamiento) {

    limpiarModalEditarTratamiento();
    cargarDatosEditar(idTratamiento);

    $("#modalEditarTratamiento").modal('show');

}

function limpiarModalEditarTratamiento() {

    $('#txtDocumentoEd').val("");
    $('#txtPacienteEd').val("");
    $('#txtObrasocialEd').val("");
    $('#txtNroAfiliadoEd').val("");
    $('#txtNroAutorizacionEd').val("");
    $('#txtCentroEd').val("");
    $('#txtEspecialidadEd').val("");
    $('#txtProfesionalEd').val("");
    $('#idPacienteEd').val("");
    $('#idProfesionalEd').val("");
    $('#idObraSocialEd').val("");
    $('#idEspecialidadEd').val("");
    $('#idCentroEd').val("");
    $('#idPlanObraEd').val("");
    $('#idTratamientoEd').val("");

    $("#ddlDiaTurnoEd").empty();
    $("#divHoraTurnoEd").hide();
    $("#ddlHoraDesdeEd").empty();
    $("#divBtnAgregarTurnoEd").hide();

}

function cargarDatosEditar(idTratamiento) {

    $.ajax({
        url: "GestionTratamientos.aspx/traerTratamientoEditar",
        data: "{idTratamiento: '" + idTratamiento
            + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            var datosTurnos = JSON.parse(data.d);
            $('#txtDocumentoEd').val(datosTurnos[0].DOCUMENTO);
            $('#txtPacienteEd').val(datosTurnos[0].PACIENTE);
            $('#txtObrasocialEd').val(datosTurnos[0].OBRA_SOCIAL);
            $('#txtNroAfiliadoEd').val(datosTurnos[0].NRO_AFILIADO);
            $('#txtNroAutorizacionEd').val(datosTurnos[0].NRO_AUTORIZACION_OBRA);
            $('#txtCentroEd').val(datosTurnos[0].CENTRO);
            $('#txtEspecialidadEd').val(datosTurnos[0].ESPECIALIDAD);
            $('#txtProfesionalEd').val(datosTurnos[0].PROFESIONAL);

            var arrayTurnosEditar = [];

            $('#idPacienteEd').val(datosTurnos[0].ID_PACIENTE);
            $('#idProfesionalEd').val(datosTurnos[0].ID_PROFESIONAL);
            $('#idObraSocialEd').val(datosTurnos[0].ID_OBRA_SOCIAL);
            $('#idEspecialidadEd').val(datosTurnos[0].ID_ESPECIALIDAD);
            $('#idCentroEd').val(datosTurnos[0].ID_CENTRO);
            $('#idPlanObraEd').val(datosTurnos[0].ID_PLAN_OBRA);
            $('#idTratamientoEd').val(datosTurnos[0].ID_TRATAMIENTO);

            datosTurnos.forEach(function (e) {

                var fechaTurno = getFormattedDate(new Date(e.FECHA_TURNO))

                var validacion = moment().isSameOrBefore(e.FECHA_TURNO, 'day');

                var acciones = '';
                if (validacion) {
                    acciones = '<a href="#" onclick="return cancelarTurnoEd(' + e.ID_TURNO + ', ' + e.ID_TRATAMIENTO + ')"  class="btn btn-danger btnCancelarEd" > <span class="fa fa-trash" title="Dar de baja"></span></a > ';
                }
                //var acciones = '<a href="#" onclick="return cancelarTurnoEd(' + e.ID_TURNO + ', ' + e.ID_TRATAMIENTO + ')"  class="btn btn-danger btnCancelarEd" > <span class="fa fa-trash" title="Dar de baja"></span></a > ';

                arrayTurnosEditar.push([
                    e.ID_TURNO,
                    //e.ID_TRATAMIENTO,
                    //e.ID_PACIENTE, e.ID_PROFESIONAL,
                    //e.ID_OBRA_SOCIAL, e.ID_ESPECIALIDAD, e.ID_CENTRO, e.ID_PLAN_OBRA,
                    e.DOCUMENTO, e.PACIENTE, e.ESPECIALIDAD, e.PROFESIONAL, e.ESTADO, fechaTurno, e.HORA_DESDE, acciones
                ])
            });

            dibujarTablaTurnosEditar(arrayTurnosEditar);
            obtieneDisponibilidadHorariaEd(datosTurnos[0].ID_PROFESIONAL, datosTurnos[0].ID_ESPECIALIDAD, datosTurnos[0].ID_CENTRO);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            $("#modalEditarTratamiento").modal('hide');
            swal("Atención!", "Ha habido un error al cargar el Tratamiento.", "warning");
        }
    });
}

function obtieneDisponibilidadHorariaEd(idProfesional, idEspecialidad, centro) {
    var eventosDispHorArr = [];
    var profesional = obtenerDisponibilidadHoraria(idProfesional, idEspecialidad, centro);

    //disponibilidadHoraria.forEach(function (e) {

    //    var dateInic = new Date(e.FECHA_INIC);
    //    var dateFin = new Date(e.FECHA_FIN);

    //    var diasArray = obtenerDiasSinFindesemanas(dateInic, dateFin);

    //    eventosDispHor = armarSemanasSinFindesemanas(diasArray);

    //});
    if (!(profesional.HorariosProfesional === null)) {
        profesional.HorariosProfesional.forEach(function (e) {

            var Dias = [];

            e.Lunes == true ? Dias.push('lunes') : '';
            e.Martes == true ? Dias.push('martes') : '';
            e.Miercoles == true ? Dias.push('miércoles') : '';
            e.Jueves == true ? Dias.push('jueves') : '';
            e.Viernes == true ? Dias.push('viernes') : '';

            var dateInic = new Date(e.FechaInic);
            var dateFin = new Date(e.FechaFin);

            var descr = e.Centro.NombreCentro + " | " + e.HoraDesde.slice(0, -3) + " - " + e.HoraHasta.slice(0, -3);

            var diasArray = obtenerDiasSinFindesemanas(dateInic, dateFin, Dias);

            eventosDispHorArr.push(armarSemanasSinFindesemanas(diasArray, descr, e.IdDisponibilidadHoraria));
            //eventosDispHor = armarSemanasSinFindesemanas(diasArray, descr, e.IdDisponibilidadHoraria);
        });
    }

    crearComboDiasEd(eventosDispHorArr);

}

function crearComboDiasEd(eventosDispHorArr) {
    //var contadorEventos = Object.keys(eventosDispHor).length;
    //if (contadorEventos > 0) {
    //    $("#ddlDiaTurnoEd").append('<option value="0" selected="selected" hidden="hidden">--Seleccione--</option>');
    //    eventosDispHor.forEach(function (e) {
    //        var fecha_inicio = e.start;
    //        //moment.locale('es');

    //        moment.lang('es', {
    //            months: 'Enero_Febrero_Marzo_Abril_Mayo_Junio_Julio_Agosto_Septiembre_Octubre_Noviembre_Diciembre'.split('_'),
    //            monthsShort: 'Enero._Feb._Mar_Abr._May_Jun_Jul._Ago_Sept._Oct._Nov._Dec.'.split('_'),
    //            weekdays: 'Domingo_Lunes_Martes_Miercoles_Jueves_Viernes_Sabado'.split('_'),
    //            weekdaysShort: 'Dom._Lun._Mar._Mier._Jue._Vier._Sab.'.split('_'),
    //            weekdaysMin: 'Do_Lu_Ma_Mi_Ju_Vi_Sa'.split('_')
    //        }
    //        );

    //        var momentDay = moment(fecha_inicio, 'YYYY-MM-DD');
    //        //var diaFormat = momentDay.locale('es').format('LL');MMMM YYYY
    //        var diaFormat2 = momentDay.locale('es').format('dddd DD') + ' de ' + momentDay.locale('es').format('MMMM') + ', ' + momentDay.locale('es').format('YYYY');

    //        $("#ddlDiaTurnoEd").append($("<option></option>").val(fecha_inicio).html(diaFormat2));
    //        $("#divDiaTurnoEd").show();
    //    });
    //} else {

    //    $("#ddlDiaTurnoEd").empty();
    //    $("#divDiaTurnoEd").hide();
    //    //$("#divAlertMsg").show();

    //}

    var contadorEventos = Object.keys(eventosDispHorArr).length;
    if (contadorEventos > 0) {
        $("#ddlDiaTurnoEd").empty().append('<option value="0" selected="selected" hidden="hidden">--Seleccione--</option>');
        eventosDispHorArr.forEach(function (e) {

            var contadorEventos2 = Object.keys(e).length;
            if (contadorEventos2 > 0) {
                e.forEach(function (d) {

                    var fecha_inicio = d.start;
                    var horaArr = d.description.split('|');
                    moment.lang('es', {
                        months: 'Enero_Febrero_Marzo_Abril_Mayo_Junio_Julio_Agosto_Septiembre_Octubre_Noviembre_Diciembre'.split('_'),
                        monthsShort: 'Enero._Feb._Mar_Abr._May_Jun_Jul._Ago_Sept._Oct._Nov._Dec.'.split('_'),
                        weekdays: 'Domingo_Lunes_Martes_Miercoles_Jueves_Viernes_Sabado'.split('_'),
                        weekdaysShort: 'Dom._Lun._Mar._Mier._Jue._Vier._Sab.'.split('_'),
                        weekdaysMin: 'Do_Lu_Ma_Mi_Ju_Vi_Sa'.split('_')
                    }
                    );

                    var momentDay = moment(fecha_inicio, 'YYYY-MM-DD');
                    //var diaFormat = momentDay.locale('es').format('LL');MMMM YYYY
                    var diaFormat2 = momentDay.locale('es').format('dddd DD') + ' de ' + momentDay.locale('es').format('MMMM') + ', ' + momentDay.locale('es').format('YYYY');

                    $("#ddlDiaTurnoEd").append($("<option></option>").val(fecha_inicio + "|" + d.id).html(diaFormat2 + " |" + horaArr[1]));

                });


            }
        });
        //ordena las opciones del select
        var my_options = $("#ddlDiaTurnoEd option");
        var selected = $("#ddlDiaTurnoEd").val();

        my_options.sort(function (a, b) {
            if (a.value > b.value) return 1;
            if (a.value < b.value) return -1;
            return 0
        })

        $("#ddlDiaTurnoEd").empty().append(my_options);
        $("#ddlDiaTurnoEd").val(selected);
        //fin
        $("#ddlDiaTurnoEd").show();
    } else {

        $("#ddlDiaTurnoEd").empty();
        $("#ddlDiaTurnoEd").hide();

    }
}

function dibujarTablaTurnosEditar(arrayTurnosEditar) {

    var table = $('#tablaTurnosEditar').DataTable({
        data: arrayTurnosEditar,
        "scrollX": true,
        "languaje": {
            "url": "//cdn.datatables.net/plug-ins/1.10.12/i18n/Spanish.json"
        },
        "ordering": true,
        "order": [[6, "asc"]],
        "bDestroy": true,
        "bAutoWidth": true,
        columns: [
            { title: "ID_TURNO", visible: false },
            //{ title: "ID_TRATAMIENTO", visible: false },
            //{ title: "ID_PACIENTE", visible: false },
            //{ title: "ID_PROFESIONAL", visible: false },
            //{ title: "ID_OBRA_SOCIAL", visible: false },
            //{ title: "ID_ESPECIALIDAD", visible: false },
            //{ title: "ID_CENTRO", visible: false },
            //{ title: "ID_PLAN_OBRA", visible: false },

            { title: "DOCUMENTO" },
            { title: "PACIENTE" },
            { title: "ESPECIALIDAD" },
            { title: "PROFESIONAL" },
            { title: "ESTADO" },
            { title: "FECHA TURNO" },
            { title: "HORA DESDE" },
            { title: "ACCIONES" }
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
    $('.dataTables_filter input').attr("placeholder", "Filtrar por...");
}

function cargarHorasEd(dispHoraria, idDisp) {

    var dispHorariaArr = dispHoraria.HorariosProfesional;
    var contador = Object.keys(dispHorariaArr).length;
    if (contador > 0) {
        dispHorariaArr.forEach(function (e) {
            if (e.IdDisponibilidadHoraria == idDisp) {
                $("#ddlHoraDesdeEd").empty();
                $("#divHoraTurnoEd").show();
                $("#divBtnAgregarTurnoEd").show();

                var horaDesde = parseInt(e.HoraDesde.substring(0, 2), 10);

                var horaHasta = parseInt(e.HoraHasta.substring(0, 2), 10);

                for (i = 0; horaDesde != horaHasta; i++) {
                    $("#ddlHoraDesdeEd").append($("<option></option>").val(horaDesde).html(horaDesde));
                    horaDesde += 1;
                }
            }
        });
    }
    else {
        $("#ddlHoraDesdeEd").empty();
        $("#divHoraTurnoEd").hide();
        $("#divBtnAgregarTurnoEd").hide();

    }

}

function armarArrayTurnoEd() {

    var tratamientoId = $('#idTratamientoEd').val();
    var sucursalId = $('#idCentroEd').val();
    var especialidadId = $('#idEspecialidadEd').val();
    var profesionalId = $('#idProfesionalEd').val();
    var pacienteId = $('#idPacienteEd').val();
    var obraSocialId = $('#idObraSocialEd').val();
    var planObraId = $('#idPlanObraEd').val();
    var nroAfiliado = $('#txtNroAfiliadoEd').val();
    var NroAutorizacion = $('#txtNroAutorizacionEd').val();
    var diaTurnoDdl = document.getElementById("ddlDiaTurnoEd");
    var preDiaTurno = diaTurnoDdl.value.split('|');
    var diaTurno = preDiaTurno[0];

    var horaTurnoDdl = document.getElementById("ddlHoraDesdeEd");
    var horaTurno = horaTurnoDdl.value;
    var minTurnoDdl = document.getElementById("ddlMinDesdeEd");
    var minTurno = minTurnoDdl.value;

    var hora = horaTurno + ":" + minTurno;

    var turno = {
        p_idTratamiento: tratamientoId,
        p_idPaciente: pacienteId,
        p_idObraSocial: obraSocialId,
        p_idPlanObra: planObraId,
        p_nroAfiliado: nroAfiliado,
        p_nroAutorizacion: NroAutorizacion,
        p_idSucursal: sucursalId,
        p_idEspecialidad: especialidadId,
        p_idProfesional: profesionalId,
        p_DiaTurno: diaTurno,
        p_HoraTurno: hora
    }

    return turno;
}

function agregarTurnoEditado(turnoEditar) {

    $.ajax({
        url: "GestionTratamientos.aspx/agregarTurnoEditarTratamiento",
        data: "{objTurnoTratamiento: '" + JSON.stringify(turnoEditar)
            + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {
            var resultado = data.d;

            if (resultado == "OK") {
                swal("Hecho", "Tratamiento editado con éxito!", "success");
            } else if (resultado == "Err2") {
                swal("Cuidado!", "Ya tiene un turno registrado ese día!", "warning");
            } else if (resultado == "Err1") {
                swal("Cuidado!", "Turno no disponible!", "warning");
            }

            var idTratamiento = $('#idTratamientoEd').val();
            cargarDatosEditar(idTratamiento);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            swal("Cuidado", "Ha habido un error al editar el Tratamiento.", "warning");
        }
    });
}

function cancelarTurnoEd(idTurno, idTratamiento) {

    swal({
        title: "¿Desea Cancelar el Turno del Tratamiento?",
        text: "Una vez Cancelado no podrá recuperarlo!",
        icon: "warning",
        buttons: [
            'No, gracias!',
            'Sí, cancelar!'
        ],
        dangerMode: true,
        closeModal: true,
    }).then(
        function (isConfirm) {
            if (isConfirm) {
                $.ajax({
                    url: "GestionTratamientos.aspx/cancelarTurnoEditarTratamiento",
                    data: "{idTurno: '" + idTurno
                        + "', idTratamiento: '" + idTratamiento
                        + "'}",
                    type: "post",
                    contentType: "application/json",
                    async: false,
                    success: function (data) {
                        var resultado = data.d;

                        if (resultado == "OK") {
                            swal("Hecho", "Turno Cancelado con éxito!", "success");
                        }
                        cargarDatosEditar(idTratamiento);
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        swal("Cuidado", "Ha habido un error al editar el Tratamiento.", "warning");
                    }
                });
            } else {
                swal("Cancelado", "Baja de Tratamiento cancelada.", "error");
            }
        }
    )
        ;
}

// #endregion
// #region CancelarTratamiento
function cancelarTratamiento(idTratamiento) {

    swal({
        title: "¿Desea dar de baja el Tratamiento?",
        text: "Una vez dado de baja no podrá recuperarlo!",
        icon: "warning",
        buttons: [
            'No, cancelar la baja!',
            'Sí, dar de baja!'
        ],
        dangerMode: true,
        closeModal: true,
    }).then(
        function (isConfirm) {

            if (isConfirm) {
                $.ajax({
                    url: "GestionTratamientos.aspx/darBajaTratamiento",
                    data: "{idTratamiento: '" + idTratamiento + "'}",
                    type: "post",
                    contentType: "application/json",
                    async: false,
                    success: function () {
                        swal("Hecho!", "Se ha dado de baja el Tratamiento.", "success");
                        cargarTablaTratamientos("");
                    },
                    error: function () {
                        swal("Error", "Hubo un problema al dar de baja el Tratamiento.", "error");
                    }
                });
            } else {
                swal("Cancelado", "Baja de Tratamiento cancelada.", "error");
            }
        })
        ;
}
// #endregion

// #region funciones btnModalCreaTratamiento

function validarDatosTratamiento() {

    var idPaciente = $('#txtIdPaciente').val();
    if (idPaciente == "") {
        swal("Cuidado", "Ingrese un Paciente.", "warning");
        return false;
    }

    //var idObraSocial = $('#ddlObraSocial').val();
    //var idPlanObra = $('#ddlPlanObra').val();
    //var nroAfiliado = $('#txtNroAfiliado').val();
    //var NroAutorizacion = $('#txtNroAutorizacion').val();

    var cantidadTurnos = arrayTurnosTabla.length;

    if (cantidadTurnos == 0) {
        swal("Cuidado", "Agregue turnos al Tratamiento.", "warning");
        return false;
    }
    return true;
}

function verificarTurnoDisponible(sucursalId, especialidadId, profesionalId, diaTurno, hora) {
    var valorVerificacion = false;
    $.ajax({
        url: "GestionTratamientos.aspx/verificarTurnoDisponible",
        data: "{sucursalId: '" + sucursalId
            + "', especialidadId: '" + especialidadId
            + "', profesionalId: '" + profesionalId
            + "', diaTurno: '" + diaTurno
            + "', hora: '" + hora + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            valorVerificacion = data.d;

        }
    });

    return valorVerificacion;
}

function armarArrayTurno() {

    var arrayTurnos = [];

    var sucursalDdl = document.getElementById("ddlSucursal");
    var sucursalId = sucursalDdl.value;
    var sucursal = sucursalDdl.options[sucursalDdl.selectedIndex].text;

    var especialidadDdl = document.getElementById("ddlEspecialidad");
    var especialidadId = especialidadDdl.value;
    var especialidad = especialidadDdl.options[especialidadDdl.selectedIndex].text;

    var profesionalDdl = document.getElementById("ddlProfesional");
    var profesionalId = profesionalDdl.value;
    var profesional = profesionalDdl.options[profesionalDdl.selectedIndex].text;

    var diaTurnoDdl = document.getElementById("ddlDiaTurno");
    var preDiaTurno = diaTurnoDdl.value.split('|');
    var diaTurno = preDiaTurno[0];
    var preDiaTurnoText = diaTurnoDdl.options[diaTurnoDdl.selectedIndex].text.split('|');
    var diaTurnoText = preDiaTurnoText[0];

    var horaTurnoDdl = document.getElementById("ddlHoraDesde");
    var horaTurno = horaTurnoDdl.value;
    var minTurnoDdl = document.getElementById("ddlMinDesde");
    var minTurno = minTurnoDdl.value;

    var hora = horaTurno + ":" + minTurno;

    var numero = sucursalId.concat(especialidadId, profesionalId, diaTurno.replaceAll('-', ''));

    var length = arrayTurnosTabla.length;
    var validacionNumeroID = true;

    for (var i = 0; i < length; i++) {
        var numeroComparar = arrayTurnosTabla[i][0];
        if (numero == numeroComparar) {
            validacionNumeroID = false;
            break;
        }
    }

    var eliminar = '<a href="#" onclick="return quitarTurno(' + "'" + numero + "'" + ')"  class="btn btn-danger btnQuitar" > <span class="fa fa-trash" title="Quitar de la lista"></span></a > ';

    if (validacionNumeroID)
        arrayTurnos.push([numero, sucursalId, sucursal, especialidadId, especialidad, profesionalId, profesional, diaTurno, diaTurnoText, hora, eliminar]);


    return arrayTurnos;
}

function quitarTurno(numero) {

    var indice = idTurnoTratamiento.indexOf(numero);
    idTurnoTratamiento.splice(indice, 1);
    arrayTurnosTabla.splice(indice, 1);
    dibujaTablaTurnos(arrayTurnosTabla);

}

function obtieneDisponibilidadHoraria(idProfesional, idEspecialidad, centro) {
    var eventosDispHorArr = [];
    var profesional = obtenerDisponibilidadHoraria(idProfesional, idEspecialidad, centro);

    //disponibilidadHoraria.forEach(function (e) {

    //    var dateInic = new Date(e.FECHA_INIC);
    //    var dateFin = new Date(e.FECHA_FIN);

    //    var diasArray = obtenerDiasSinFindesemanas(dateInic, dateFin);

    //    eventosDispHor = armarSemanasSinFindesemanas(diasArray);

    //});

    if (!(profesional.HorariosProfesional === null)) {
        profesional.HorariosProfesional.forEach(function (e) {

            var Dias = [];

            e.Lunes == true ? Dias.push('lunes') : '';
            e.Martes == true ? Dias.push('martes') : '';
            e.Miercoles == true ? Dias.push('miércoles') : '';
            e.Jueves == true ? Dias.push('jueves') : '';
            e.Viernes == true ? Dias.push('viernes') : '';

            var dateInic = new Date(e.FechaInic);
            var dateFin = new Date(e.FechaFin);

            var descr = e.Centro.NombreCentro + " | " + e.HoraDesde.slice(0, -3) + " - " + e.HoraHasta.slice(0, -3);

            var diasArray = obtenerDiasSinFindesemanas(dateInic, dateFin, Dias);

            eventosDispHorArr.push(armarSemanasSinFindesemanas(diasArray, descr, e.IdDisponibilidadHoraria));
            //eventosDispHor = armarSemanasSinFindesemanas(diasArray, descr, e.IdDisponibilidadHoraria);
        });
    }

    crearComboDias(eventosDispHorArr);

}

function obtenerDisponibilidadHoraria(idProfesional, idEspecialidad, centro) {

    $.ajax({
        url: "GestionTratamientos.aspx/traerDisponibilidadHoraria",
        //data: "{idProfesional: '" + idProfesional + "', idEspecialidad: '" + idEspecialidad + "', idCentro: '" + centro + "', dia: '" + dia + "'}",
        data: "{idProfesional: '" + idProfesional + "', centro: '" + centro + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            disponibilidadHoraria = JSON.parse(data.d);

        }
    });

    return disponibilidadHoraria;
}

function obtenerDiasSinFindesemanas(startDate, stopDate, Dias) {
    //var diasArray = new Array();
    //var currentDate = startDate;
    //while (currentDate <= stopDate) {
    //    var diaNombre = currentDate.toLocaleString('es-es', { weekday: 'long' });
    //    if (!(diaNombre.startsWith('dom') || diaNombre.startsWith('sáb'))) {
    //        diasArray.push(new Date(currentDate));
    //        currentDate = currentDate.addDays(1);
    //    }
    //    else {
    //        currentDate = currentDate.addDays(1);
    //    }
    //}
    //return diasArray;

    var diasArray = new Array();
    var currentDate = startDate;

    while (currentDate <= stopDate) {
        var diaNombre = currentDate.toLocaleString('es-es', { weekday: 'long' });
        if (Dias.includes(diaNombre)) {
            diasArray.push(new Date(currentDate));
            currentDate = currentDate.addDays(1);
        }
        else {
            currentDate = currentDate.addDays(1);
        }
    }
    return diasArray;
}

function armarSemanasSinFindesemanas(diasArray, descr, idEvent) {
    var dispHor = [];

    var dispHorSemana = '{"title": "Disponible", "start": "", "end":"", "description": "", "id":"' + idEvent + '"}';

    for (i = 0; i < diasArray.length; i++) {

        var obj = JSON.parse(dispHorSemana);
        var diaObj = diasArray[i];

        var hoy = new Date();
        if (hoy <= diaObj) {
            var diaFormated = getFormattedDateInversed(diaObj);
            obj.start = diaFormated;
            obj.end = diaFormated;
            obj.description = descr;
            dispHor.push(obj);
        }
    }
    return dispHor;
}

function obtenerTurnosXDia(idProfesional, dia) {
    var turnosXIdProf;

    $.ajax({
        url: "GestionTratamientos.aspx/traerTurnos",
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

function cargarObrasSociales(ddl) {

    $.ajax({
        url: "GestionTratamientos.aspx/cargarObrasSociales",
        //data: "{idCentro: '" + idCentro + "'}",
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
                //$(ddl).prop("disabled", false);
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            $(ddl).prop("disabled", true);
            alert(data.error);
        }
    });
}



function cargarObrasSocialesPaciente(ddl,idPaciente) {

    $.ajax({
        url: "GestionTratamientos.aspx/cargarObrasSocialesPaciente",
        data: "{idPaciente: '" + idPaciente + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {
            // TODO ¿ que pasa si el paciente no tiene cargada aun ninguna obra social ?
            if (data.d != null) {
                $(ddl).empty();
                $(ddl).append('<option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>');

                for (i = 0; i < data.d.length; i++) {

                    $(ddl).append($("<option></option>").val(data.d[i].IdObraSocial).html(data.d[i].Descripcion));
                }
                //$(ddl).prop("disabled", false);
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
        url: "GestionTratamientos.aspx/cargarPlanes",
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
                $('#txtNroAfiliado').prop('disabled', false);
                $('#txtNroAutorizacion').prop('disabled', false);

                console.log(planes.NRO_AFILIADO);
                 //   $('#txtNroAfiliado').innerHTML = e.NRO_AFILIADO;
            }
            else {
                $("#ddlPlanObra").prop("disabled", true);
                $('#txtNroAfiliado').prop('disabled', true);
                $('#txtNroAutorizacion').prop('disabled', true);


            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            $(ddl).prop("visible", true);
        }
    });
}


function cargarComboPlanesPaciente(idObraSocial, ddl, idPaciente) {

    var obj = JSON.stringify({

        p_idObraSocial: idObraSocial,
        p_idPaciente: idPaciente
    });


    $.ajax({
        url: "GestionTratamientos.aspx/cargarPlanesPacientes",
        data: obj,
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
                    nroAfiliado = e.NRO_AFILIADO;
                    
                });
                $("#ddlPlanObra").prop("disabled", false);
                $('#txtNroAfiliado').prop('disabled', true);
                $('#txtNroAutorizacion').prop('disabled', false);              

            }
            else {
                $("#ddlPlanObra").prop("disabled", true);
                $('#txtNroAfiliado').prop('disabled', true);
                $('#txtNroAutorizacion').prop('disabled', true);


            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            $(ddl).prop("visible", true);
        }
    });
}

function buscarPaciente(dniPaciente) {
    $.ajax({
        url: "GestionTratamientos.aspx/buscarPaciente",
        data: "{dniPaciente: '" + dniPaciente + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {
            var paciente = JSON.parse(data.d);
            var datosPaciente;

            if (data.d != "null") {
                datosPaciente = paciente.Apellido + " " + paciente.Nombre;
                $('#txtIdPaciente').val(paciente.IdPaciente);

                idPaciente = paciente.IdPaciente;

                cargarObrasSocialesPaciente("#ddlObraSocial", paciente.IdPaciente);

            } else {
                datosPaciente = "";
                swal("Paciente no encontrado", "Por favor primero registre al paciente.", "warning");
            }
            $('#txtPaciente').val(datosPaciente);
        }
    });
}

function limpiarModalCreaTratamiento() {

    $('#txtDocumento').val("");
    $('#txtIdPaciente').val("");

    $('#ddlSucursal').val(0);
    $('#ddlEspecialidad').empty();
    $('#ddlEspecialidad').append('<option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>');
    $('#ddlEspecialidad').prop("disabled", true);
    $('#ddlProfesional').empty();
    $('#ddlProfesional').append('<option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>');
    $('#ddlProfesional').prop("disabled", true);
    $('#ddlObraSocial').val(0);
    //$('#ddlObraSocial').append('<option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>');
    //$('#ddlObraSocial').prop("disabled", true);
    $('#ddlPlanObra').empty();
    $('#ddlPlanObra').prop('disabled', true);
    $('#txtNroAfiliado').prop('disabled', true);
    $('#txtNroAfiliado').val("");
    $('#txtNroAutorizacion').prop('disabled', true);
    $('#txtNroAutorizacion').val("");

    limpiarDatosTratamiento();
}

function limpiarDatosTratamiento() {
    $("#divDiaTurno").hide();
    $("#ddlDiaTurno").empty();
    $("#divHoraTurno").hide();
    $("#ddlHoraDesde").empty();
    $("#divAlertMsg").hide();
    $("#divBtnAgregarTurno").hide();

    $("#msgYaAgregado").hide();
    $("#msgAgregado").hide();
    $("#msgNoDisponible").hide();

    idTurnoTratamiento = [];
    arrayTurnosTabla = [];
    dibujaTablaTurnos(arrayTurnosTabla);

    $("#tListarTurnos").hide();

}

function cargarComboCentros(ddl) {

    $.ajax({
        url: "GestionTratamientos.aspx/cargarCentros",
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

function cargarEspecialidades(idCentro, ddl) {

    $.ajax({
        url: "GestionTratamientos.aspx/cargarEspecialidades",
        data: "{idCentro: '" + idCentro + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {
            var especialidades = JSON.parse(data.d);

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

function cargarProfesionales(idCentro, idEspecialidad, ddl) {

    $.ajax({
        url: "GestionTratamientos.aspx/cargarProfesionales",
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

function crearComboDias(eventosDispHorArr) { //"#ddlDiaTurno"
    
    var contadorEventos = Object.keys(eventosDispHorArr).length;
    if (contadorEventos > 0) {
        $("#ddlDiaTurno").append('<option value="0" selected="selected" hidden="hidden">--Seleccione--</option>');
        eventosDispHorArr.forEach(function (e) {
            
            var contadorEventos2 = Object.keys(e).length;
            if (contadorEventos2 > 0) {
                e.forEach(function (d) {
                    
                    var fecha_inicio = d.start;
                    var horaArr = d.description.split('|');
                    moment.lang('es', {
                        months: 'Enero_Febrero_Marzo_Abril_Mayo_Junio_Julio_Agosto_Septiembre_Octubre_Noviembre_Diciembre'.split('_'),
                        monthsShort: 'Enero._Feb._Mar_Abr._May_Jun_Jul._Ago_Sept._Oct._Nov._Dec.'.split('_'),
                        weekdays: 'Domingo_Lunes_Martes_Miercoles_Jueves_Viernes_Sabado'.split('_'),
                        weekdaysShort: 'Dom._Lun._Mar._Mier._Jue._Vier._Sab.'.split('_'),
                        weekdaysMin: 'Do_Lu_Ma_Mi_Ju_Vi_Sa'.split('_')
                    }
                    );

                    var momentDay = moment(fecha_inicio, 'YYYY-MM-DD');
                    //var diaFormat = momentDay.locale('es').format('LL');MMMM YYYY
                    var diaFormat2 = momentDay.locale('es').format('dddd DD') + ' de ' + momentDay.locale('es').format('MMMM') + ', ' + momentDay.locale('es').format('YYYY');

                    $("#ddlDiaTurno").append($("<option></option>").val(fecha_inicio+"|"+d.id).html(diaFormat2 + " |"+ horaArr[1]));

                });
                

            }
        });
        //ordena las opciones del select
        var my_options = $("#ddlDiaTurno option");
        var selected = $("#ddlDiaTurno").val();

        my_options.sort(function (a, b) {
            if (a.value > b.value) return 1;
            if (a.value < b.value) return -1;
            return 0
        })

        $("#ddlDiaTurno").empty().append(my_options);
        $("#ddlDiaTurno").val(selected);
        //fin
        $("#divDiaTurno").show();
    } else {

        $("#ddlDiaTurno").empty();
        $("#divDiaTurno").hide();
        $("#divAlertMsg").show();

    }
}

function cargarHoras(dispHoraria, idDisp) {

    var dispHorariaArr = dispHoraria.HorariosProfesional;
    var contador = Object.keys(dispHorariaArr).length;
    if (contador > 0) {
        dispHorariaArr.forEach(function (e) {
            if (e.IdDisponibilidadHoraria == idDisp) {
                $("#ddlHoraDesde").empty();
                $("#divHoraTurno").show();
                $("#divBtnAgregarTurno").show();

                var horaDesde = parseInt(e.HoraDesde.substring(0, 2), 10);

                var horaHasta = parseInt(e.HoraHasta.substring(0, 2), 10);

                for (i = 0; horaDesde != horaHasta; i++) {
                    $("#ddlHoraDesde").append($("<option></option>").val(horaDesde).html(horaDesde));
                    horaDesde += 1;
                }
            }
        });
    }
    else {
        $("#ddlHoraDesde").empty();
        $("#divHoraTurno").hide();
        $("#divBtnAgregarTurno").hide();

    }

}

function dibujaTablaTurnos(arrayTurnos) {

    $("#tListarTurnos").show();

    var table = $('#tablaTurnosTratamiento').DataTable({
        data: arrayTurnos,
        "scrollX": true,
        "languaje": {
            "url": "//cdn.datatables.net/plug-ins/1.10.12/i18n/Spanish.json"
        },
        "ordering": true,
        "order": [[7, "asc"], [9, "desc"]],
        "bDestroy": true,
        "bAutoWidth": true,
        columns: [
            { title: "ALEATORIO", visible: false },
            { title: "ID_SUCURSAL", visible: false },
            { title: "SUCURSAL" },
            { title: "ID_ESPECIALIDAD", visible: false },
            { title: "ESPECIALIDAD" },
            { title: "ID_PROFESIONAL", visible: false },
            { title: "PROFESIONAL" },
            { title: "VALUE_DIA", visible: false },
            { title: "DIA" },
            { title: "HORA" },
            { title: "ACCIONES" }

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

Date.prototype.addDays = function (days) {
    var date = new Date(this.valueOf());
    date.setDate(date.getDate() + days);
    return date;
}
        // #endregion