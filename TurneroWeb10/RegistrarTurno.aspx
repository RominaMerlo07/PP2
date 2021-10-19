<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarTurno.aspx.cs" Inherits="TurneroWeb10.RegistrarTurno" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .datepicker.date {
            width: 207px;
        }
        /*div.dt-buttons {
            float: left;
            margin-left:10px;
        }*/
        div.dataTables_filter{
            float: left;
            margin-left:10px;
            color: black;
        }
         /*.card-body .typeahead { position: fixed }*/
        /*.wrapper {
            position: relative;
          }*/
        .fc-event {
            cursor: pointer !important;
        }

    </style>
    <section class="content-header">
        <%--<button class="btn btn-info btn-sm float-right" type="button" id="Listar">Listar Turnos</button>--%>
        <h1 style="text-align: left">REGISTRAR TURNO</h1>
    </section>
    <div class="content" id="sectionEspecialidad">
        
        <div class="row justify-content-md-center">
            
            <div class="col-md">
                <div class="card text-white bg-light">                    
                    <div class="card-header bg-info">
                        <h4>Datos del Turno</h4>
                    </div>
                    <div class="card-body">
                        <div class="form-row">
                            <div class="col-sm-4 col-md-4 col-lg-4">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Sucursal: </span>
                                    </div>
                                    <select class="custom-select form-control" id="ddlSucursal">
                                    </select>
                                </div>
                            </div>                           
                            <div class="col-sm-4 col-md-4 col-lg-4">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Especialidad: </span>
                                    </div>
                                    <select class="custom-select form-control" id="ddlEspecialidad">
                                        <option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>
                                    </select>
                                </div>
                            </div>
                            <div class="col-sm-4 col-md-4 col-lg-4">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Profesional: </span>
                                    </div>
                                    <select class="form-control" id="ddlProfesional">
                                        <%--<option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>--%>
                                    </select>
                                </div>
                            </div>
                        </div>    
                    </div>
                </div>
                <div class="card text-white bg-light" id="ocultoSiempre" style="display:none">                    
                    <div class="card-header bg-info">
                        <h4></h4>
                    </div>
                    <div class="card-body">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="content" id="calDisposicionHoraria">           
        <div class="row justify-content-md-center">
            <div class="col-md-8">
                <div class="card" >
                    <div class="card-body">
                        <div id='calendarioDispHor'></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="content" id="calTurnos">    
        <div class="row justify-content-md-center">
            <div class="col-md-8">
                <div class="card" > 
                    <button class="btn btn-secondary btn-lg " type="button" onclick="volver()" id="btnVolver">Volver a la Disponibilidad Horaria</button>
                    <div class="card-body">
                        <div id='calendarioTurnos'></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--MODAL TURNO--%>
    <div class="modal fade" tabindex="-1" role="dialog" id ="modalTurno" >
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
              <div class="modal-header bg-info text-white">
                <h4 class="modal-title " id="lblTituloTurno">Reserva de Turno</h4>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>       
              </div>
                <div class="modal-body">
                    <div class="col-md-12" id="crdPaciente2">
                        <div class="card text-white ">
                            <div class="card-header ">
                                <h4 class="modal-title text-dark">Datos personales</h4>
                            </div>
                            <div class="card-body">               
                                <div class="form-row">
                                    <div class="col">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">Paciente: </span>
                                            </div>
                                            <input type="search" class="form-control rounded" id="txtDocumento" placeholder="Ingrese DNI" aria-label="Search"
                                                aria-describedby="search-addon" onkeypress="return soloNumeros(event)"/>
                                            <button class="btn btn-outline-secondary" id="btnBuscarDNI" type="button">
                                                <i class="fas fa-search"></i>
                                            </button>
                                        </div>
                                    </div>
                                    <div class="col ">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">Celular:</span>
                                            </div>
                                            <input type="text" style="text-align: left" class="form-control" id="txtCelular" onkeypress="return soloNumeros(event)" disabled="disabled"/>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="col">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="">Nombre y Apellido:</span>
                                            </div>
                                            <input type="text" style="text-align: left" class="form-control" id="txtNombre" onkeypress="return soloLetras(event)" disabled="disabled" onkeyup="javascript:this.value=this.value.toUpperCase();"/>
                                            <input type="text" style="text-align: left" class="form-control" id="txtApeliido" onkeypress="return soloLetras(event)" disabled="disabled" onkeyup="javascript:this.value=this.value.toUpperCase();"/>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="col ">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">Email: </span>
                                            </div>
                                            <input type="text" class="form-control" id="txtEmail1" disabled="disabled"/>
                                            <div class="input-group-append">
                                                <span class="input-group-text">@</span>
                                            </div>
                                            <input type="text" class="form-control" id="txtEmail2" placeholder="gmail.com" disabled="disabled"/>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="col ">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">Obra Social: </span>
                                            </div>
                                            <select class="custom-select form-control" id="ddlObraSocial" disabled="disabled">
                                            </select>
                                        </div>
                                    </div>
                                    <div class="col ">
                                        <div class="input-group mb-3" id="frmPlanObra">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">Plan: </span>
                                            </div>
                                            <select class="custom-select form-control" id="ddlPlanObra" disabled="disabled">
                                            </select>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <div class="modal-footer">
                    <div class="row float-right">
                
                        <button class="btn btn-success btn-lg " type="button" id="btnRegistrar">Registrar</button>      
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" tabindex="-1" role="dialog" id ="modalListarTurnos" >
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
              <div class="modal-header bg-info text-white">
                <h4 class="modal-title " >Listar turnos</h4>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>       
              </div>
                <div class="modal-body">
                    <div class="col-md-12" id="">
                        <div class="card text-white ">
                            <div class="card-header ">
                                <h4 class="modal-title text-dark" id="lblListarTurnos"></h4>
                            </div>
                            <div class="card-body">               
                                <%--<div class="form-row">--%>
                                    <div id="tListarTurnos" style="display: none">
                                        <table style="width:100%" class="table table-striped table-bordered" id="tablaListarTurnos">
<%--                                            <thead>
                                                <tr>
                                                    <th>FECHA</th>
                                                    <th>HORA</th>
                                                    <th>ESPECIALIDAD</th>
                                                    <th>PROFESIONAL</th>
                                                    <th>PACIENTE</th>
                                                </tr>
                                            </thead>--%>
                                        </table>
                                    </div>
                                <%--</div>--%>                                
                            </div>
                        </div>
                    </div>
                </div>
                <br />
            </div>
        </div>
    </div>
    <script type="text/javascript">
        const setTrad = { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric' };
        var disponibilidadHoraria;
        var turnosXIdProfDetalle;
        var eventosDelDia;
        var esEdicionPaciente;

        var centro;
        var especialidad;
        var fechaTurno;
        var horaTurno;
        var minTurno;

        var nombre;
        var apellido;
        var documento;
        var celular;
        var email1;
        var email2;
        var obraSocial;
        var planObra;
        var idProfesional;
        var calendarDisp;
        var calendarTur;
        var infoTurno;        

        $(document).ready(function () {

            $('#dtpFechaD').datepicker({ 
                autoclose: true,
                format: "dd/mm/yyyy",
                startDate: '+1d'
            });

            $('#modalTurno').modal('hide');
            $('#tListarTurnos').show();
            $('#ddlProfesional').select2({theme: "bootstrap4", placeholder: "-- Seleccione --"});

            $('#crdDatosPersonales').hide();
            $(".paciente").hide();
            $("#calDisposicionHoraria").hide();
            $("#calTurnos").hide();
            $("#ddlSucursal").prop("disabled", true);
            $("#ddlEspecialidad").prop("disabled", true);
            $("#ddlProfesional").prop("disabled", true);
            $("#ddlObraSocial").prop("disabled", true);
            cargarComboCentros('#ddlSucursal');   
            cargarObrasSociales("#ddlObraSocial");

            $('#btnRegistrar').click(function () {

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
                        p_profesional: $('#ddlProfesional').val(),
                        es_edicion: esEdicionPaciente
                    }
                    
                    registrarTurno(turnoYPersona);
                    $('#modalTurno').modal('hide');
                    $("#calDisposicionHoraria").hide();
                    $("#calTurnos").hide();

                    limpiarCampos();
                }
            });

            $("#ddlSucursal").bind("change", function () {

                centro = $('#ddlSucursal').val();
                cargarEspecialidades(centro, "#ddlEspecialidad");
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

                //trae datos de paciente
                
                var dniPaciente = $('#txtDocumento').val();
                buscarPaciente(dniPaciente);

            });

            $("#ddlObraSocial").bind("change", function () {

                var idObraSocial = $('#ddlObraSocial').val();
                cargarComboPlanes(idObraSocial, "#ddlPlanObra");
                //$('#ddlPlanObra').prop('disabled', false);   
            });

        });

        function buscarPaciente(dniPaciente)
        {
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

                        $('#txtCelular').val(paciente.NroContacto);
                        $('#txtNombre').val(paciente.Nombre);
                        $('#txtApeliido').val(paciente.Apellido);

                        var pacienteEmail = paciente.EmailContacto.split('@');

                        $('#txtEmail1').val(pacienteEmail[0]);
                        $('#txtEmail2').val(pacienteEmail[1]);

                        esEdicionPaciente = true;
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

                        esEdicionPaciente = true;
                    }


                }
            }); 
        }

        function obtenerDisponibilidadHoraria(idProfesional, idEspecialidad, centro, dia="")
        {
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

        function CargarEventosFullCalendar(idProfesional, idEspecialidad, centro)
        {
            var eventos = [];

            var disponibilidadHoraria = obtenerDisponibilidadHoraria(idProfesional, idEspecialidad, centro);

            disponibilidadHoraria.forEach(function (e)
            {

                var dateInic = new Date(e.FECHA_INIC);
                var dateFin = new Date(e.FECHA_FIN);

                var diasArray = obtenerDiasSinFindesemanas(dateInic, dateFin);

                eventos = armarSemanasSinFindesemanas(diasArray);
                                    
            });
            
            calendarDisp.addEventSource(eventos);
        }

        function obtenerDiasSinFindesemanas(startDate, stopDate)
        {
            var diasArray = new Array();
            var currentDate = startDate;
            while (currentDate <= stopDate) {
                var diaNombre = currentDate.toLocaleString('es-es', { weekday: 'long' });
                if (!(diaNombre.startsWith('dom') || diaNombre.startsWith('sáb'))) {
                    diasArray.push(new Date(currentDate));
                    currentDate = currentDate.addDays(1);
                }
                else
                {
                    currentDate = currentDate.addDays(1);
                }
            }
            return diasArray;
        }

        function armarSemanasSinFindesemanas(diasArray)
        {
            var dispHor = [];

            var dispHorSemana = '{"title": "Disponibilidad", "start": "", "end":""}';
            
            for (i = 0; i < diasArray.length; i++) {

                var obj = JSON.parse(dispHorSemana);
                var diaObj = diasArray[i];

                var hoy = new Date();
                if (hoy <= diaObj)
                {
                    var diaFormated = getFormattedDateInversed(diaObj);
                    obj.start = diaFormated;
                    obj.end = diaFormated;
                    dispHor.push(obj);
                }
            }           
            return dispHor;
        }

        function obtenerTurnosXDia(idProfesional, dia)
        {
            var turnosXIdProf;
            
            $.ajax({
                url: "RegistrarTurno.aspx/traerTurnos",
                data: "{idProfesional: '" + idProfesional + "', dia: '"+ dia + "'}",
                type: "post",
                contentType: "application/json",
                async: false,
                success: function (data) {
                    
                    turnosXIdProf = JSON.parse(data.d);    
                 
                }
            });
            return turnosXIdProf;
        }

        function obtenerHorarios(idProfesional, idEspecialidad, dia)
        {
            
            var disponibilidad = [];
            var disponibilidadXDia = '{"title": "Disponible", "start": "", "end":"", "color":"green"}';
            var disponibilidadHoraria = obtenerDisponibilidadHoraria(idProfesional, idEspecialidad, centro, dia);

            for (i = 0; i < disponibilidadHoraria.length; i++) {

                var horaInicio = disponibilidadHoraria[i].HORA_DESDE;
                var horaHasta = disponibilidadHoraria[i].HORA_HASTA;
                var dispStart = moment(dia + ' ' + horaInicio, 'YYYY-MM-DD HH:mm:ss');
                var dispEnd = moment(dia + ' ' + horaHasta, 'YYYY-MM-DD HH:mm:ss');

                for (i = 0; !dispStart.isSame(dispEnd); i++)
                {
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

        Date.prototype.addDays = function(days) {
            var date = new Date(this.valueOf());
            date.setDate(date.getDate() + days);
            return date;
        }

        function dibujaCalendarioTurnos(dia, idEspecialidad)
        {
            eventosDelDia = obtenerHorarios(idProfesional, idEspecialidad, dia);
           
            var calendarTurnos = document.getElementById('calendarioTurnos');
            calendarTur = new FullCalendar.Calendar(calendarTurnos, {
                initialDate: dia,//'2020-09-12',
                initialView: 'timeGridDay',
                customButtons: {
                    btnListarTurnos: {
                        text: 'Listar Turnos',
                        click: function() {
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

        function btnListarTurnoClick(turnos)
        {
            
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
                    { title: "FECHA"},
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

        function mostrarModalTurno(arg)
        {
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

        function dibujaCalendarioDisp(idEspecialidad)
        {
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
                eventClick: function (info)
                {                    
                    var dia = info.event.startStr;
                    
                    $("#calDisposicionHoraria").hide();
                    $("#calTurnos").show;
                    dibujaCalendarioTurnos(dia, idEspecialidad);
                }
            });
            calendarDisp.render();
        }

        function volver()
        {
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
           
            $('#txtNombre').val("");
            $('#txtApeliido').val("");
            $('#txtDocumento').val("");
            $('#txtCelular').val("");
            $('#txtEmail1').val("");
            $('#txtEmail2').val("");
            $('#ddlObraSocial').val(0);
            $('#ddlPlanObra').empty();
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

        function cargarObrasSociales(ddl) {

            $.ajax({
                url: "RegistrarTurno.aspx/cargarObrasSociales",
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
                        
                    }
                    else {
                        $("#ddlPlanObra").prop("disabled", true);
                    }
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    $(ddl).prop("visible", true);
                }
            });
        }

        function registrarTurno(datosTurno) {

            $.ajax({
                url: "RegistrarTurno.aspx/registrarTurno",
                data: JSON.stringify(datosTurno),
                type: "post",
                contentType: "application/json",
                async: false,
                success: function (data) {

                    if (data.d != 'OK') {
                        //alert('Error al registrar turno.')
                        swal("Hubo un problema", "Error al registrar el turno!", "error");
                    } else
                    {
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

        
    </script>
</asp:Content>
