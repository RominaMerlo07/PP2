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
    </style>
    <section class="content-header">
        <%--<button class="btn btn-info btn-sm float-right" type="button" id="Listar">Listar Turnos</button>--%>
        <h1 style="text-align: left">REGISTRAR TURNO</h1>
    </section>
    <section class="content" id="sectionEspecialidad">
        <div class="row justify-content-md-center">
            <div class="col-md-8">
                <div class="card text-white bg-light">                    
                    <div class="card-header bg-info">
                        <h4>Datos del Turno</h4>
                    </div>
                    <div class="card-body">
                        <div class="form-row">
                            <div class="col-sm-6 col-md-6 col-lg-6">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Sucursal: </span>
                                    </div>
                                    <select class="custom-select form-control" id="ddlSucursal">
                                    </select>
                                </div>
                            </div>
                            <div class="col-sm-6 col-md-6 col-lg-6">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Especialidad: </span>
                                    </div>
                                    <select class="custom-select form-control" id="ddlEspecialidad">
                                        <option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>
                                    </select>
                                </div>
                            </div>
                        </div>    
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="content" id="calDisposicionHoraria">           
        <div class="row justify-content-md-center">
            <div class="col-md-8">
                <div class="card" >
                    <div class="card-body">
                        <div id='calendarioDispHor'></div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="content" id="calTurnos">    
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
    </section>
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
                                            <%--<button class="btn btn-outline-secondary" id="btnBuscarDNI" type="button">
                                                <i class="fas fa-search"></i>
                                            </button>--%>
                                        </div>
                                    </div>
                                    <div class="col ">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">Celular:</span>
                                            </div>
                                            <input type="text" style="text-align: left" class="form-control" id="txtCelular" onkeypress="return soloNumeros(event)"/>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="col">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="">Nombre y Apellido:</span>
                                            </div>
                                            <input type="text" style="text-align: left" class="form-control" id="txtNombre" />
                                            <input type="text" style="text-align: left" class="form-control" id="txtApeliido" />
                                        </div>
                                    </div>
                                </div>
                                <%--<div class="form-row">--%>
                                    <%--<div class="col ">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">Obra Social: </span>
                                            </div>
                                            <select class="custom-select form-control" id="ddlObraSocial">
                                                <option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>
                                            </select>
                                        </div>
                                    </div>--%>
                                    
                                <%--</div>--%>
                                <div class="form-row">
                                    <div class="col ">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">Email: </span>
                                            </div>
                                            <input type="text" class="form-control" id="txtEmail1" />
                                            <div class="input-group-append">
                                                <span class="input-group-text">@</span>
                                            </div>
                                            <input type="text" class="form-control" id="txtEmail2" placeholder="gmail.com" />
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
        var idProfesionalDetalle;
        var calendarDisp;
        var calendarTur;
        var infoTurno;        

        $(document).ready(function () {

            $('#dtpFechaD').datepicker({ 
                autoclose: true,
                format: "dd/mm/yyyy",
                startDate: '+1d'
            });

            swal("Good job!", "You clicked the button!", "warning");

            //$('#modalTurno').modal('show');
            $('#modalTurno').modal('hide');

            $('#tListarTurnos').show();

            $('#crdDatosPersonales').hide();
            $(".paciente").hide();
            $("#calDisposicionHoraria").hide();
            $("#calTurnos").hide();
            $("#ddlSucursal").prop("disabled", true);
            $("#ddlEspecialidad").prop("disabled", true);
            $("#ddlObraSocial").prop("disabled", true);
            cargarComboCentros('#ddlSucursal'); 

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
                        p_email2: email2
                    }
                    
                    registrarTurno(turnoYPersona);
                    $('#modalTurno').modal('hide');
                    $("#calDisposicionHoraria").hide();
                    $("#calTurnos").hide();

                    limpiarCampos();
                }
            });

            $("#ddlSucursal").bind("change", function () {

                var idCentro = $('#ddlSucursal').val();
                cargarObrasSociales(idCentro, "#ddlObraSocial");
                cargarEspecialidades(idCentro, "#ddlEspecialidad");
            });

            $("#ddlEspecialidad").bind("change", function () {

                idProfesionalDetalle = $('#ddlEspecialidad').val();
                dibujaCalendarioDisp();
                CargarEventosFullCalendar(idProfesionalDetalle);
            });
                

            $('#btnBuscarDNI').click(function () {

                //trae datos de paciente
                $(".paciente").show();
                //limpiarCampos();
            });
            

        });

        function CargarEventosFullCalendar(idProfesionalDetalle)
        {
            var eventos = [];
            disponibilidadHoraria.forEach(function (e)
            {
                if (e.ID_PROFESIONALES_DETALLE == idProfesionalDetalle)
                {
                    var dateInic = new Date(e.FECHA_INIC);
                    var dateFin = new Date(e.FECHA_FIN);

                    var diasArray = obtenerDiasSinFindesemanas(dateInic, dateFin);

                    eventos = armarSemanasSinFindesemanas(diasArray);
                }

                
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

        function obtenerTurnosXDia(idProfesionalDetalle, dia)
        {
            
            var turnos = [];

            $.ajax({
                url: "RegistrarTurno.aspx/traerTurnos",
                data: "{idProfesionalDetalle: '" + idProfesionalDetalle + "', dia: '"+ dia + "'}",
                type: "post",
                contentType: "application/json",
                async: false,
                success: function (data) {

                    turnosXIdProfDetalle = JSON.parse(data.d);
                    
                    var turnosXDia = '{"title": "Turno", "start": "", "end":""}';
            
                    for (i = 0; i < turnosXIdProfDetalle.length; i++) {

                        var obj = JSON.parse(turnosXDia);

                        var fechaTurno = turnosXIdProfDetalle[i].FECHA_TURNO;
                        var dateT = new Date(fechaTurno);
                        var horaTurno = turnosXIdProfDetalle[i].HORA_DESDE;
                        var splitResult = horaTurno.split(':');

                        var diaFormatedz = getFormattedDateInversed(dateT);
                        var diaFormated = diaFormatedz + 'T' + splitResult[0] + ':' + splitResult[1] + ':00';
                        obj.start = diaFormated;
                        var end = parseInt(splitResult[1]) + 15;
                        obj.end = diaFormatedz + 'T' + splitResult[0] + ':' + end + ':00';
                        obj.title = turnosXIdProfDetalle[i].ESPECIALIDAD + ' - Turno Confirmado.';
                        turnos.push(obj);

                    }           
                    
                }
            });
            return turnos;
        }

        Date.prototype.addDays = function(days) {
            var date = new Date(this.valueOf());
            date.setDate(date.getDate() + days);
            return date;
        }

        function dibujaCalendarioTurnos(dia)
        {
            eventosDelDia = obtenerTurnosXDia(idProfesionalDetalle, dia); // se guarda en var turnosXIdProfDetalle
           
            var calendarTurnos = document.getElementById('calendarioTurnos');
            calendarTur = new FullCalendar.Calendar(calendarTurnos, {
                initialDate: dia,//'2020-09-12',
                initialView: 'timeGridDay',
                customButtons: {
                    btnListarTurnos: {
                        text: 'Listar Turnos',
                        click: function() {
                            btnListarTurnoClick(turnosXIdProfDetalle);
                        }
                    }
                },
                headerToolbar: {
                    left: 'title',
                    center: '',
                    right: 'btnListarTurnos'
                },
                selectable: true,
                select: function (arg) {
                    mostrarModalTurno(arg);                  
                },
                locale: 'ES',
                slotMinTime: '08:00:00',
                slotMaxTime: '21:00:00',
                slotDuration: '00:15:00',
                slotLabelInterval: '00:15:00',
            });
            $("#calTurnos").show();
            calendarTur.render();

            calendarTur.addEventSource(eventosDelDia);
        }

        function btnListarTurnoClick(turnos)
        {
            
            //<th>FECHA</th> FECHA_TURNO
            //<th>HORA</th> HORA_DESDE
            //<th>ESPECIALIDAD</th> ESPECIALIDAD
            //<th>PROFESIONAL</th> PROFESIONAL
            //<th>PACIENTE</th> PACIENTE
            //tablaListarTurnos
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
            $('#modalTurno').modal('show');
           
            infoTurno = arg;
            var dia = new Date(arg.startStr);
            var hora = String(dia.getHours()).padStart(2, '0') + ':' + String(dia.getMinutes()).padStart(2, '0');
            var diaTrad = $('#ddlEspecialidad option:selected').text() + ': ' + dia.toLocaleDateString('es-ES', setTrad) + ', ' + hora + '.';
             $("#lblTituloTurno").text(diaTrad);
            fechaTurno = getFormattedDateInversed(dia);
            horaTurno = hora;
        }

        function dibujaCalendarioDisp()
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
                    dibujaCalendarioTurnos(dia);
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
            $("#dtpFechaD").datepicker('clearDates');
            $('#ddlHoraDesde').val('8');
            $('#ddlObraSocial').empty();
            $('#ddlObraSocial').append('<option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>');
            $('#ddlObraSocial').prop("disabled", true);
            $('#ddlMinDesde').val('00');
            $('#txtNombre').val("");
            $('#txtApeliido').val("");
            $('#txtDocumento').val("");
            $('#txtCelular').val("");
            $('#txtEmail1').val("");
            $('#txtEmail2').val("");
        }

        function cargarEspecialidades(idCentro, ddl) {
            $.ajax({
                url: "RegistrarTurno.aspx/cargarEspecialidades",
                data: "{idCentro: '" + idCentro + "'}",
                type: "post",
                contentType: "application/json",
                async: false,
                success: function (data) {
                    disponibilidadHoraria = JSON.parse(data.d);
                    if (disponibilidadHoraria != null) {

                        $(ddl).empty();
                        $(ddl).append('<option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>');

                        disponibilidadHoraria.forEach(function (e) {
                            $(ddl).append($("<option></option>").val(e.ID_PROFESIONALES_DETALLE).html(e.DESCRIPCION));
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

        function cargarObrasSociales(idCentro, ddl) {

            $.ajax({
                url: "RegistrarTurno.aspx/cargarObrasSociales",
                data: "{idCentro: '" + idCentro + "'}",
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
            else {
                return true;
            };
        };

    </script>
</asp:Content>
