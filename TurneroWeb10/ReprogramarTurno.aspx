<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReprogramarTurno.aspx.cs" Inherits="TurneroWeb10.ReprogramarTurno" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style>

    </style>

  <section class="content-header">
        <h1 style="text-align: center">REPROGRAMAR TURNO</h1>
    </section>
    <div class="content" id="sectionEspecialidad">
        <div class="row justify-content-md-center">
            <div class="col-md">
                <div class="box box-primary">
                    <div class="box-header">
                        <h4 class="box-title">Turnos para Reprogramar</h4>
                    </div>
                    <div class="box-body ml-2">
                        <div class="col-sm-4 col-md-4 col-lg-4">
                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">Sucursal: </span>
                                </div>
                                <select class="custom-select form-control" id="ddlSucursal">
                                </select>
                            </div>
                        </div>
                    </div>
                    <div class="box-body table-responsive">                    
                        <%--<div class="row">--%>
                        <div class="col-md-12">
                            <%--<div class="" id="tblTurnosReprogramar" style="display:none">--%>
                                </br>
                                    <div id="tHorarios" >
                                        <table style=" width: 100% !important;" class="table table-hover table-bordered  table-striped" id="tablaTurnosReprogramar">
                                        </table>
                                    </div> 
                            <%--</div>--%>
                            <div class="alert alert-success" role="alert" id="msgSinTurnosReprogramar" style="display:none">
                                <strong>Esta sucursal no tiene turnos para reprogramar.</strong>
                            </div>
                        </div>
                        
                    </div>
                </div>
            </div>
        </div>
    </div>

     <%--MODAL REPROGRAMAR TURNO--%>
    <div class="modal fade" tabindex="-1" role="dialog" id ="modalReprogramarTurno" >
        <div class="modal-dialog modal-xl" role="document">
            <div class="modal-content">
              <div class="modal-header bg-info text-white">
                <h4 class="modal-title ">Reprogramar Turno</h4>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>       
              </div>
                <div class="modal-body">
                    <div class="col-md-12">
                        <div class="card text-white ">
                            <div class="card-header ">
                                <h4 class="modal-title text-dark">Selección de fecha y hora</h4>
                            </div>
                            <div class="card-body">               

                                <div class="card-body">               
                                <div class="form-row">
                                    <div class="col-sm-4 col-md-4 col-lg-4">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">Nro. Documento: </span>
                                            </div>
                                            <input type="search" class="form-control rounded" id="txtDocumentoEd" disabled="disabled" />
                                            <%--<button class="btn btn-outline-secondary" id="btnBuscarDNI" type="button">
                                                <i class="fas fa-search"></i>
                                            </button>--%>
                                        </div>
                                    </div>   
                                    <div class="col">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">Nombre Paciente: </span>
                                            </div>
                                            <input type="text" style="text-align: left" class="form-control" id="txtPacienteEd" disabled="disabled" />                                            
                                        </div>
                                    </div> 
                                </div>
                                <div class="form-row">
                                    <div class="col-sm-4 col-md-4 col-lg-4 ">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">Obra Social: </span>
                                            </div>
                                            <input type="text" style="text-align: left" class="form-control" id="txtObrasocialEd" disabled="disabled" /> 
                                        </div>
                                    </div>
                                    <div class="col-sm-4 col-md-4 col-lg-4  ">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">Nro. Afiliado:</span>
                                            </div>
                                            <input type="text" style="text-align: left" class="form-control" id="txtNroAfiliadoEd" disabled="disabled"/>
                                        </div>
                                    </div>
                                    <div class="col-sm-4 col-md-4 col-lg-4  ">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">Nro. Autorización:</span>
                                            </div>
                                            <input type="text" style="text-align: left" class="form-control" id="txtNroAutorizacionEd" disabled="disabled"/>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="col-sm-4 col-md-4 col-lg-4  ">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">Centro:</span>
                                            </div>
                                            <input type="text" style="text-align: left" class="form-control" id="txtCentroEd" disabled="disabled"/>
                                        </div>
                                    </div>
                                    <div class="col-sm-4 col-md-4 col-lg-4  ">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">Especialidad:</span>
                                            </div>
                                            <input type="text" style="text-align: left" class="form-control" id="txtEspecialidadEd" disabled="disabled"/>
                                        </div>
                                    </div>
                                    <div class="col-sm-4 col-md-4 col-lg-4  ">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">Profesional:</span>
                                            </div>
                                            <input type="text" style="text-align: left" class="form-control" id="txtProfesionalEd" disabled="disabled"/>
                                        </div>
                                    </div>
                                    <%--idPacienteEd, idProfesionalEd, idObraSocialEd, idEspecialidadEd, idCentroEd, idPlanObraEd,--%>
                                </div>
                                <div class="form-row">
                                    <div class="col-sm-4 col-md-4 col-lg-4" style="display:none">
                                        <input type="text" style="text-align: left" class="form-control" id="idPacienteEd" disabled="disabled"/>
                                    </div>
                                    <div class="col-sm-4 col-md-4 col-lg-4" style="display:none">
                                        <input type="text" style="text-align: left" class="form-control" id="idProfesionalEd" disabled="disabled"/>
                                    </div>
                                    <div class="col-sm-4 col-md-4 col-lg-4" style="display:none">
                                        <input type="text" style="text-align: left" class="form-control" id="idObraSocialEd" disabled="disabled"/>
                                    </div>
                                    <div class="col-sm-4 col-md-4 col-lg-4" style="display:none">
                                        <input type="text" style="text-align: left" class="form-control" id="idEspecialidadEd" disabled="disabled"/>
                                    </div>
                                    <div class="col-sm-4 col-md-4 col-lg-4" style="display:none">
                                        <input type="text" style="text-align: left" class="form-control" id="idCentroEd" disabled="disabled"/>
                                    </div>
                                    <div class="col-sm-4 col-md-4 col-lg-4" style="display:none">
                                        <input type="text" style="text-align: left" class="form-control" id="idPlanObraEd" disabled="disabled"/>
                                    </div>
                                    <div class="col-sm-4 col-md-4 col-lg-4" style="display:none">
                                        <input type="text" style="text-align: left" class="form-control" id="idTurnoEd" disabled="disabled"/>
                                    </div>
                                </div>

                                <%--<div class="form-row">
                                    <div class="col-sm-4 col-md-4 col-lg-4" style="display:none">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">Id Paciente:</span>
                                            </div>
                                            <input type="text" style="text-align: left" class="form-control" id="" disabled="disabled"/>
                                        </div> 
                                    </div>
                                </div>--%>
                                <br />
                                <h5 class="card-title mb-2 text-muted">Elegir el nuevo día y horario del turno</h5>
                                <div class="form-row">
                                    <div class="col-sm-4 col-md-4 col-lg-4" id="divDiaTurnoEd" >
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">Dia: </span>
                                            </div>
                                            <select class="custom-select form-control" id="ddlDiaTurnoEd">
                                                <option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>
                                            </select>
                                        </div>
                                    </div>
                                    <div class="col-sm-4 col-md-4 col-lg-4" id="divHoraTurnoEd" style="display:none">
                                        <div class="input-group mb-3">
                                            <div class="input-group mb-3">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">Hora: </span>
                                                </div>
                                                <select class="btn btn-white form-control" id="ddlHoraDesdeEd">

                                                </select>
                                                <div class="input-group-append">
                                                    <span class="input-group-text">:</span>
                                                </div>
                                                <select class="btn btn-white form-control" id="ddlMinDesdeEd">
                                                    <option value="00">00</option>
                                                    <option value="15">15</option>
                                                    <option value="30">30</option>
                                                    <option value="45">45</option>
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-2 col-md-2 col-lg-2" id="divBtnReprogramarTurnoEd" style="display:none">
                                        <button class="btn btn-success" type="button" id="btnReprogramarTurnoEd">Reprogramar Turno</button> 
                                        
                                    </div>
                                    <div class="col-sm-2 col-md-2 col-lg-2" >

                                        <div class="alert alert-success" role="alert" id="msgAgregadoEd" style="display:none">
                                            <strong>Agregado!</strong>
                                        </div>
                                        <div class="alert alert-danger" role="alert" id="msgNoDisponibleEd" style="display:none">
                                          <strong>Turno no disponible.</strong>
                                        </div>
                                        <div class="alert alert-danger" role="alert" id="msgYaAgregadoRd" style="display:none">
                                          <strong>Ya se ha sacado un turno para este día.</strong>
                                        </div>
                                        <div class="alert alert-danger" role="alert" id="msgNoDisponibleHorarioEd" style="display:none">
                                          <strong>Profesional sin horarios disponibles.</strong>
                                        </div>
                                    </div>
                                    
                                </div>
                                <br />
                                <div class="form-row">
                                    <div class="col">
                                        <div id="tListarTurnosEditar">
                                            <table style="width:100%" class="table table-striped " id="tablaTurnosEditar" >
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            </div>
                        </div>
                        <br />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">

        var disponibilidadHoraria;

        $(document).ready(function () {

            cargarComboCentros('#ddlSucursal');

            $("#ddlSucursal").bind("change", function () {

                traerTurnosReprogramar($("#ddlSucursal").val());
                

            });

            // #region editarTratamiento
            $("#ddlDiaTurnoEd").bind("change", function () {
                var valueArr = $("#ddlDiaTurnoEd").val().split('|');
                cargarHorasEd(disponibilidadHoraria, valueArr[1]);

            });

            $('#btnReprogramarTurnoEd').click(function () {
                debugger;
                if ($("#ddlDiaTurnoEd").val() != 0) {
                    var turnoReprogramado;
                    turnoReprogramado = armarArrayTurnoEd();

                    reprogramarDiaTurno(turnoReprogramado);
                } else {
                    swal("Cuidado!", "Seleccione el día!", "warning");
                }
        
            });
            // #endregion
            
        });

        // Pantalla Principal

        function traerTurnosReprogramar(idCentro) {

            $.ajax({
                url: "ReprogramarTurno.aspx/traerTurnosReprogramar",
                data: "{idCentro: '" + idCentro + "'}",
                type: "post",
                contentType: "application/json",
                async: false,
                success: function (data) {

                    
                    var result = JSON.parse(data.d);
                  

                    var turnosReprogramar = [];
                    //debugger;
                    if (result.length > 0) {
                        result.forEach(function (e) {  

                            console.log(e);

                            var idTurno = e.IdTurno;
                            var nombrePaciente = e.Paciente.Nombre + " " + e.Paciente.Apellido;
                            var pacienteNombre = nombrePaciente;
                            var telPaciente = e.Paciente.NroContacto;
                            debugger;
                            var obraPlan = "";
                            if (e.ObraSocial != null) {
                                obraPlan = e.ObraSocial.Descripcion + " (" + e.ObraSocial.PlanObraSocial.Descripcion +") ";
                            }

                            var nroAfiliado = e.NroAfiliado;

                            var fechaTurno = getFormattedDate(new Date(e.FechaTurno));
                            var fechaTurno = fechaTurno + " " + e.HoraDesde; //HoraDesde HoraHasta

                            var centro = e.Centro.NombreCentro;
                            var especialidad = e.Especialidad.Descripcion;
                            var nombreProfesional = e.Profesional.Nombre + " " + e.Profesional.Apellido;
                            var profesional = nombreProfesional;
                            var editarParam = idTurno + "&" + idCentro + "&" + e.Especialidad.IdEspecialidad + "&" + especialidad + "&" + e.Profesional.IdProfesional + "&" + profesional;
                            //' +'`'+ editarParam +'`'+ '
                            var Acciones = '<a href="#" onclick="return reprogramarTurno(' + idTurno + ', ' + idCentro + ')"  class="btn btn-primary" > <span class="fa fa-pencil" title="Editar"></span></a > ' +
                                '<a href="#" onclick="return cancelarTurno(' + idTurno + ', ' + idCentro + ')"  class="btn btn-danger btnCancelar" > <span class="fa fa-trash" title="Dar de baja"></span></a > ';

                            turnosReprogramar.push([pacienteNombre, telPaciente, obraPlan, nroAfiliado, centro, especialidad, profesional, fechaTurno, Acciones]);
                        });

                        dibujarTablaTurnosReprogramar(turnosReprogramar);
                        $("#msgSinTurnosReprogramar").hide();
                        $("#tHorarios").show();
                        
                    } else {
                        $("#msgSinTurnosReprogramar").show();
                        $("#tHorarios").hide();

                    }
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    
                }
            });
        };

        function dibujarTablaTurnosReprogramar(turnosReprogramar){
            var table = $('#tablaTurnosReprogramar').DataTable({
                data: turnosReprogramar,
                "scrollX": true,
                "languaje": {
                    "url": "//cdn.datatables.net/plug-ins/1.10.12/i18n/Spanish.json"
                },
                "ordering": true,
                "bDestroy": true,
                "bAutoWidth": true,
                columns: [
                    { title: "PACIENTE" },
                    { title: "TELÉFONO PACIENTE" },
                    { title: "OBRA SOCIAL Y PLAN" },
                    { title: "NRO. AFILIADO" },
                    { title: "CENTRO" },
                    { title: "ESPECIALIDAD" },
                    { title: "PROFESIONAL" },
                    { title: "HORARIO TURNO" },
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

        function cargarComboCentros(ddl) {

            $.ajax({
                url: "ReprogramarTurno.aspx/cargarCentros",
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

        function cancelarTurno(idTurno, idCentro) {
            swal({
                title: "¿Desea Cancelar el Turno?",
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
                            url: "ReprogramarTurno.aspx/cancelarTurnoReprogramar",
                            data: "{idTurno: '" + idTurno
                                + "'}",
                            type: "post",
                            contentType: "application/json",
                            async: false,
                            success: function (data) {
                                var resultado = data.d;

                                if (resultado == "OK") {
                                    swal("Hecho", "Turno Cancelado con éxito!", "success");
                                }
                                traerTurnosReprogramar(idCentro); // recargar tabla
                            },
                            error: function (xhr, ajaxOptions, thrownError) {
                                swal("Cuidado", "Ha habido un error al cancelar el turno.", "warning");
                            }
                        });
                    } else {
                        swal("Cancelado", "Baja de Turno cancelada.", "error");
                    }
                }
            );
        }

        // Modal Editar
        function reprogramarTurno(idTurno, idCentro) {

            limpiarModalEditarTratamiento()
            $("#modalReprogramarTurno").modal('show');
            cargarDatosEditar(idTurno);

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
            $('#idTurnoEd').val("");

            $("#ddlDiaTurnoEd").empty();
            $("#divHoraTurnoEd").hide();
            $("#ddlHoraDesdeEd").empty();
            $("#divBtnReprogramarTurnoEd").hide();

            $("#msgNoDisponibleHorarioEd").hide();

        }

        function cargarDatosEditar(IdTurno) {
            $.ajax({
                url: "ReprogramarTurno.aspx/cargarDatosTurnoReprogramar",
                data: "{idTurno: '" + IdTurno + "'}",
                type: "post",
                contentType: "application/json",
                async: false,
                success: function (data) {

                    var result = JSON.parse(data.d);


                    $('#txtDocumentoEd').val(result.Paciente.Documento);
                    var nombrePaciente = result.Paciente.Nombre + " " + result.Paciente.Apellido;
                    $('#txtPacienteEd').val(nombrePaciente);
                    var obraSocial = result.ObraSocial.Descripcion + ", " + result.ObraSocial.PlanObraSocial.Descripcion;
                    $('#txtObrasocialEd').val(obraSocial);
                    $('#txtNroAfiliadoEd').val(result.NroAfiliado);
                    $('#txtNroAutorizacionEd').val(result.NroAutorizacionObra);
                    $('#txtCentroEd').val(result.Centro.NombreCentro);
                    $('#txtEspecialidadEd').val(result.Especialidad.Descripcion);
                    var nombreProfesional = result.Profesional.Nombre + " " + result.Profesional.Apellido;
                    $('#txtProfesionalEd').val(nombreProfesional);


                    $('#idPacienteEd').val(result.Paciente.IdPaciente);
                    $('#idProfesionalEd').val(result.Profesional.IdProfesional);
                    $('#idObraSocialEd').val(result.ObraSocial.IdObraSocial);
                    $('#idEspecialidadEd').val(result.Especialidad.IdEspecialidad);
                    $('#idCentroEd').val(result.Centro.IdCentro);
                    $('#idPlanObraEd').val(result.ObraSocial.PlanObraSocial.IdPlan);
                    $('#idTurnoEd').val(IdTurno);

                    obtieneDisponibilidadHorariaEd(result.Profesional.IdProfesional, result.Especialidad.IdEspecialidad, result.Centro.IdCentro)
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    
                }
            });    
        }

        function obtieneDisponibilidadHorariaEd(idProfesional, idEspecialidad, centro) {
            var eventosDispHorArr = [];
            var profesional = obtenerDisponibilidadHoraria(idProfesional, idEspecialidad, centro);

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

                });
            }

            crearComboDiasEd(eventosDispHorArr);

        }

        function obtenerDisponibilidadHoraria(idProfesional, idEspecialidad, centro) {

            $.ajax({
                url: "ReprogramarTurno.aspx/traerDisponibilidadHoraria",
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

        Date.prototype.addDays = function (days) {
            var date = new Date(this.valueOf());
            date.setDate(date.getDate() + days);
            return date;
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

        function cargarHorasEd(dispHoraria, idDisp) {
            debugger;
            var dispHorariaArr = dispHoraria.HorariosProfesional;
            var contador = Object.keys(dispHorariaArr).length;
            if (contador > 0) {
                dispHorariaArr.forEach(function (e) {
                    if (e.IdDisponibilidadHoraria == idDisp) {
                        $("#ddlHoraDesdeEd").empty();
                        $("#divHoraTurnoEd").show();
                        $("#divBtnReprogramarTurnoEd").show();

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
                $("#divBtnReprogramarTurnoEd").hide();

            }

        }

        function crearComboDiasEd(eventosDispHorArr) {

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
                $("#divDiaTurnoEd").hide();
                $("#msgNoDisponibleHorarioEd").show();
                

            }
        }

        function armarArrayTurnoEd() {

            var turnoId = $('#idTurnoEd').val();
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
                p_idTurno: turnoId,
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

        function reprogramarDiaTurno(turnoEditar) {

            $.ajax({
                url: "ReprogramarTurno.aspx/reprogramarDiaTurno",
                data: "{objTurnoTratamiento: '" + JSON.stringify(turnoEditar)
                    + "'}",
                type: "post",
                contentType: "application/json",
                async: false,
                success: function (data) {
                    var resultado = data.d;

                    if (resultado == "OK") {
                        swal("Hecho", "Turno reprogramado con éxito!", "success");
                        $("#modalReprogramarTurno").modal('hide');
                        traerTurnosReprogramar($("#ddlSucursal").val());

                    } else if (resultado == "Err2") {
                        swal("Cuidado!", "Ya tiene un turno registrado ese día!", "warning");
                    } else if (resultado == "Err1") {
                        swal("Cuidado!", "Turno no disponible!", "warning");
                    }

                },
                error: function (xhr, ajaxOptions, thrownError) {
                    swal("Cuidado", "Ha habido un error al editar el Tratamiento.", "warning");
                }
            });
        }
    </script>
</asp:Content>
