<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionTratamientos.aspx.cs" Inherits="TurneroWeb10.GestionTratamientos" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style>
    </style>
    <section class="content-header">
        <h1 style="text-align: left">GESTIÓN DE TRATAMIENTOS</h1>
    </section>
    <div class="content" id="sectionEspecialidad">
        <div class="row">
            <button class="btn btn-success btn-lg float-right" type="button" id="btnModalCreaTratamiento">Crear Tratamiento</button>
        </div>
        </br>

        <!-- Datatable Part -->
        <div class="row justify-content-md-center">           
            <div class="col-md">
                <div class="box box-primary">
                    <div class="box-header">
                        <h4 class="box-title">Buscar por:</h4>
                    </div>
                    <div class="form-row ml-2">
                        <div class="col-sm-4 col-md-4 col-lg-4 ">
                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">Nro. Documento: </span>
                                </div>
                                <input type="search" class="form-control rounded" id="txtDocumentoFiltrar" placeholder="Ingrese DNI" aria-label="Search"
                                    aria-describedby="search-addon" onkeypress="return soloNumeros(event)"/>
                                <button class="btn btn-outline-secondary" id="btnBuscarDNIFiltrar" type="button">
                                    <i class="fas fa-search"></i>
                                </button>
                            </div>
                        </div>   

                        <div class="col-sm-4 col-md-4 col-lg-4 ">
                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">Nombre Paciente: </span>
                                </div>
                                <input type="text" style="text-align: left" class="form-control" id="txtPacienteFiltrar" disabled="disabled" />                                            
                            </div>
                        </div>
                        <div class="col-sm-4 col-md-4 col-lg-4" style="display:none">
                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">Id Paciente:</span>
                                </div>
                                <input type="text" style="text-align: left" class="form-control" id="txtIdPacienteFiltrar"/>
                            </div> 
                        </div>
                    </div>
                    <div class="box-body table-responsive">
                        <div class="col-md-12">
                            <div class="table table-striped table-hover">   
                                <div id="tGestionTratamiento" >
                                    <table style="width:100%" class="table table-striped table-hover table-bordered table-secondary" id="tablaTratamientos">
                                    </table>
                                </div>  
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>

        <%--MODAL GENERAR TRATAMIENTO--%>
    <div class="modal fade" tabindex="-1" role="dialog" id ="modalGenerarTratamiento" >
        <div class="modal-dialog modal-xl" role="document">
            <div class="modal-content">
              <div class="modal-header bg-info text-white">
                <h4 class="modal-title " id="lblTituloTurno">Generar Tratamiento</h4>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>       
              </div>
                <div class="modal-body">
                    <div class="col-md-12" id="crdPaciente2">
                        <div class="card text-white ">
                            <div class="card-header ">
                                <h4 class="modal-title text-dark">Datos del Paciente</h4>
                            </div>
                            <div class="card-body">
                                <div class="form-row">
                                    <div class="col-sm-4 col-md-4 col-lg-4">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">Nro. Documento: </span>
                                            </div>
                                            <input type="search" class="form-control rounded" id="txtDocumento" placeholder="Ingrese DNI" aria-label="Search"
                                                aria-describedby="search-addon" onkeypress="return soloNumeros(event)"/>
                                            <button class="btn btn-outline-secondary" id="btnBuscarDNI" type="button">
                                                <i class="fas fa-search"></i>
                                            </button>
                                        </div>
                                    </div>   
                                    <div class="col">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">Nombre Paciente: </span>
                                            </div>
                                            <input type="text" style="text-align: left" class="form-control" id="txtPaciente" disabled="disabled" />                                            
                                        </div>
                                    </div> 
                                </div>
                                <div class="form-row">
                                    <div class="col-sm-4 col-md-4 col-lg-4 ">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">Obra Social: </span>
                                            </div>
                                            <select class="custom-select form-control" id="ddlObraSocial">
                                            </select>
                                        </div>
                                    </div>
                                    <div class="col-sm-4 col-md-4 col-lg-4 ">
                                        <div class="input-group mb-3" id="frmPlanObra">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">Plan: </span>
                                            </div>
                                            <select class="custom-select form-control" id="ddlPlanObra" disabled="disabled">
                                            </select>
                                        </div>
                                    </div>
                                    <div class="col-sm-4 col-md-4 col-lg-4  ">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">Nro. Afiliado:</span>
                                            </div>
                                            <input type="text" style="text-align: left" class="form-control" id="txtNroAfiliado" onkeypress="return soloNumeros(event)" disabled="disabled"/>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="col-sm-4 col-md-4 col-lg-4  ">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">Nro. Autorización:</span>
                                            </div>
                                            <input type="text" style="text-align: left" class="form-control" id="txtNroAutorizacion" onkeypress="return soloNumeros(event)" disabled="disabled"/>
                                        </div>
                                    </div>
                                    <div class="col-sm-4 col-md-4 col-lg-4" style="display:none">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">Id Paciente:</span>
                                            </div>
                                            <input type="text" style="text-align: left" class="form-control" id="txtIdPaciente"/>
                                        </div> 
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="card text-white ">
                            <div class="card-header ">
                                <h4 class="modal-title text-dark">Datos del Tratamiento</h4>
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
                                <div class="form-row">
                                    <div class="col-sm-4 col-md-4 col-lg-4" id="divDiaTurno" style="display:none">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">Dia: </span>
                                            </div>
                                            <select class="custom-select form-control" id="ddlDiaTurno">
                                                <option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>
                                            </select>
                                        </div>
                                    </div>
                                    <div class="col-sm-4 col-md-4 col-lg-4" id="divHoraTurno" style="display:none">
                                        <div class="input-group mb-3">
                                            <div class="input-group mb-3">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">Hora: </span>
                                                </div>
                                                <select class="btn btn-white form-control" id="ddlHoraDesde">

                                                </select>
                                                <div class="input-group-append">
                                                    <span class="input-group-text">:</span>
                                                </div>
                                                <select class="btn btn-white form-control" id="ddlMinDesde">
                                                    <option value="00">00</option>
                                                    <option value="15">15</option>
                                                    <option value="30">30</option>
                                                    <option value="45">45</option>
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-1 col-md-1 col-lg-1" id="divBtnAgregarTurno" style="display:none">
                                        <button class="btn btn-success" type="button" id="btnAgregarTurno">Agregar</button> 
                                        
                                    </div>
                                    <div class="col-sm-3 col-md-3 col-lg-3" >

                                        <div class="alert alert-success" role="alert" id="msgAgregado" style="display:none">
                                            <strong>Agregado!</strong>
                                        </div>
                                        <div class="alert alert-danger" role="alert" id="msgNoDisponible" style="display:none">
                                          <strong>Turno no disponible.</strong>
                                        </div>
                                        <div class="alert alert-danger" role="alert" id="msgYaAgregado" style="display:none">
                                          <strong>Ya se ha sacado un turno para este día.</strong>
                                        </div>
                                    </div>
                                    
                                </div>
                                <div class="form-row">
                                    <div class="col" id="divAlertMsg" style="display:none">
                                        <div class="alert alert-danger alert-dismissible">
                                            <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                                            <h4><i class="icon fa fa-ban"></i> ¡Atención!</h4>
                                            No hay Disponibilidad Horaria para los datos ingresados.
                                        </div>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="col">
                                        <div id="tListarTurnos">
                                            <table style="width:100%" class="table table-striped " id="tablaTurnosTratamiento" >
                                            </table>
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

     <%--MODAL EDITAR TRATAMIENTO--%>
    <div class="modal fade" tabindex="-1" role="dialog" id ="modalEditarTratamiento" >
        <div class="modal-dialog modal-xl" role="document">
            <div class="modal-content">
              <div class="modal-header bg-info text-white">
                <h4 class="modal-title ">Editar Tratamiento</h4>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>       
              </div>
                <div class="modal-body">
                    <div class="col-md-12">
                        <div class="card text-white ">
                            <div class="card-header ">
                                <h4 class="modal-title text-dark">Datos del Tratamiento</h4>
                            </div>
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
                                        <input type="text" style="text-align: left" class="form-control" id="idTratamientoEd" disabled="disabled"/>
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
                                <h5 class="card-title mb-2 text-muted">Agregar turno al tratamiento</h5>
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
                                    <div class="col-sm-1 col-md-1 col-lg-1" id="divBtnAgregarTurnoEd" style="display:none">
                                        <button class="btn btn-success" type="button" id="btnAgregarTurnoEd">Agregar</button> 
                                        
                                    </div>
                                    <div class="col-sm-3 col-md-3 col-lg-3" >

                                        <div class="alert alert-success" role="alert" id="msgAgregadoEd" style="display:none">
                                            <strong>Agregado!</strong>
                                        </div>
                                        <div class="alert alert-danger" role="alert" id="msgNoDisponibleEd" style="display:none">
                                          <strong>Turno no disponible.</strong>
                                        </div>
                                        <div class="alert alert-danger" role="alert" id="msgYaAgregadoRd" style="display:none">
                                          <strong>Ya se ha sacado un turno para este día.</strong>
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
                        <br />
                    </div>
                </div>
                <%--<br />
                <div class="modal-footer">
                    <div class="row float-right">
                
                        <button class="btn btn-success btn-lg " type="button" id="btnEditar">Registrar</button>      
                    </div>
                </div>--%>
            </div>
        </div>
    </div>
    <script type="text/javascript">

        var centro;
        var disponibilidadHoraria;
        //var eventosDispHor = [];
        var arrayTurnosTabla = [];
        var idTurnoTratamiento = [];

        $(document).ready(function () {

            cargarTablaTratamientos("");
            $(".dataTables_scrollHeadInner").css({"width":"100%"});
            $(".table ").css({"width":"100%"});

            $('#btnBuscarDNIFiltrar').click(function () {
                
                var dniPaciente = $('#txtDocumentoFiltrar').val();
                buscarPacienteFiltrar(dniPaciente);
                cargarTablaTratamientos($('#txtIdPacienteFiltrar').val());
            });

            // #region editarTratamiento
            $("#ddlDiaTurnoEd").bind("change", function () {

                cargarHorasEd(disponibilidadHoraria);

            });

            $('#btnAgregarTurnoEd').click(function () {

                var nuevoTurnoTratamiento;
                nuevoTurnoTratamiento = armarArrayTurnoEd();

                agregarTurnoEditado(nuevoTurnoTratamiento);
            });
            // #endregion

            // #region btnModalCreaTratamiento

            $('#btnBuscarDNI').click(function () {
                
                var dniPaciente = $('#txtDocumento').val();
                buscarPaciente(dniPaciente);

            });

            $("#ddlObraSocial").bind("change", function () {

                var idObraSocial = $('#ddlObraSocial').val();
                cargarComboPlanes(idObraSocial, "#ddlPlanObra");
                //$('#ddlPlanObra').prop('disabled', false);   
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

                cargarHoras(disponibilidadHoraria);

            });

            $('#btnRegistrar').click(function () {

                var validacion = validarDatosTratamiento();

                if (validacion)
                {
                    var arrayRegistrar = [];
                    var idPaciente = $('#txtIdPaciente').val();
                    var idObraSocial = $('#ddlObraSocial').val();
                    var idPlanObra = $('#ddlPlanObra').val();
                    var nroAfiliado = $('#txtNroAfiliado').val();
                    var NroAutorizacion = $('#txtNroAutorizacion').val();

                    var longitudArray = arrayTurnosTabla.length;
                    for (var i = 0; i < longitudArray; i++)
                    {
                        var turno = {
                            p_idPaciente : idPaciente,
                            p_idObraSocial : idObraSocial,
                            p_idPlanObra : idPlanObra,
                            p_nroAfiliado : nroAfiliado,
                            p_nroAutorizacion: NroAutorizacion,
                            p_idSucursal : arrayTurnosTabla[i][1],
                            p_idEspecialidad : arrayTurnosTabla[i][3],
                            p_idProfesional : arrayTurnosTabla[i][5],
                            p_DiaTurno : arrayTurnosTabla[i][7],
                            p_HoraTurno : arrayTurnosTabla[i][9]
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
                else
                {
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
                    datos.forEach(function (e)
                    {
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
                                    columns: [ 1]
                                }
                            },
                            {
                                extend: 'pdf', /*orientation: 'landscape'*/
                                exportOptions: {
                                    columns: [ 1 ]
                                }
                            },
                            { extend: 'colvis', columns: ':not(:first-child)', text: "Ocultar/Mostrar columnas" }
                        ]
                    });
                    $('.dataTables_filter input').attr("placeholder", "Filtrar por...");                   
                }
            }); 
        }

        function buscarPacienteFiltrar(dniPaciente)
        {
            $.ajax({
                url: "GestionTratamientos.aspx/buscarPaciente",
                data: "{dniPaciente: '" + dniPaciente + "'}",
                type: "post",
                contentType: "application/json",
                async: false,
                success: function (data) {
                    var paciente = JSON.parse(data.d);
                    var datosPaciente;

                    if (data.d != "null")
                    {
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

        function obtieneDisponibilidadHorariaEd(idProfesional, idEspecialidad, centro)
        {
            var eventosDispHor = [];
            var disponibilidadHoraria = obtenerDisponibilidadHoraria(idProfesional, idEspecialidad, centro);

            disponibilidadHoraria.forEach(function (e)
            {

                var dateInic = new Date(e.FECHA_INIC);
                var dateFin = new Date(e.FECHA_FIN);

                var diasArray = obtenerDiasSinFindesemanas(dateInic, dateFin);

                eventosDispHor = armarSemanasSinFindesemanas(diasArray);
                                    
            });

            crearComboDiasEd(eventosDispHor);

        }

        function crearComboDiasEd(eventosDispHor) {

            var contadorEventos = Object.keys(eventosDispHor).length;
            if (contadorEventos > 0) {
                $("#ddlDiaTurnoEd").append('<option value="0" selected="selected" hidden="hidden">--Seleccione--</option>');
                eventosDispHor.forEach(function (e) {
                    var fecha_inicio = e.start;
                    //moment.locale('es');

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

                    $("#ddlDiaTurnoEd").append($("<option></option>").val(fecha_inicio).html(diaFormat2));
                    $("#divDiaTurnoEd").show();
                });
            } else {

                $("#ddlDiaTurnoEd").empty();
                $("#divDiaTurnoEd").hide();
                //$("#divAlertMsg").show();

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
                "order": [[ 6, "asc" ]],
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

        function cargarHorasEd(dispHoraria) {

            var contador = Object.keys(dispHoraria).length;
            if (contador > 0) {
                $("#ddlHoraDesdeEd").empty();
                $("#divHoraTurnoEd").show();
                $("#divBtnAgregarTurnoEd").show();

                var horaDesde = parseInt(dispHoraria[0].HORA_DESDE.substring(0, 2), 10);
                   
                var horaHasta = parseInt(dispHoraria[0].HORA_HASTA.substring(0, 2), 10);

                for (i = 0; horaDesde != horaHasta; i++)
                {
                    $("#ddlHoraDesdeEd").append($("<option></option>").val(horaDesde).html(horaDesde));
                    horaDesde += 1;
                }

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
            var diaTurno = diaTurnoDdl.value;

            var horaTurnoDdl = document.getElementById("ddlHoraDesdeEd");
            var horaTurno = horaTurnoDdl.value;
            var minTurnoDdl = document.getElementById("ddlMinDesdeEd");
            var minTurno = minTurnoDdl.value;

            var hora = horaTurno + ":" + minTurno;

            var turno = {
                p_idTratamiento : tratamientoId,
                p_idPaciente : pacienteId,
                p_idObraSocial : obraSocialId,
                p_idPlanObra : planObraId,
                p_nroAfiliado : nroAfiliado,
                p_nroAutorizacion: NroAutorizacion,
                p_idSucursal : sucursalId,
                p_idEspecialidad : especialidadId,
                p_idProfesional : profesionalId,
                p_DiaTurno : diaTurno,
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
                success: function (data)
                {
                    var resultado = data.d;

                    if (resultado == "OK") {
                        swal("Hecho", "Tratamiento editado con éxito!", "success");
                    } else if (resultado == "Err1") {
                        swal("Cuidado!", "Ya tiene un turno registrado ese día!", "warning");
                    } else if (resultado == "Err1") {
                        swal("Cuidado!", "Turno no disponible!", "warning");
                    }

                    var idTratamiento =  $('#idTratamientoEd').val();
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
        
        function validarDatosTratamiento()
        {

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

        function verificarTurnoDisponible(sucursalId, especialidadId, profesionalId, diaTurno, hora)
        {
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
            var diaTurno = diaTurnoDdl.value;
            var diaTurnoText = diaTurnoDdl.options[diaTurnoDdl.selectedIndex].text;

            var horaTurnoDdl = document.getElementById("ddlHoraDesde");
            var horaTurno = horaTurnoDdl.value;
            var minTurnoDdl = document.getElementById("ddlMinDesde");
            var minTurno = minTurnoDdl.value;

            var hora = horaTurno + ":" + minTurno;
            
            var numero = sucursalId.concat(especialidadId, profesionalId, diaTurno.replaceAll('-', '')); 

            var length = arrayTurnosTabla.length;
            var validacionNumeroID = true;

            for (var i = 0; i < length; i++)
            {
                var numeroComparar = arrayTurnosTabla[i][0];
                if (numero == numeroComparar)
                {
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

        function obtieneDisponibilidadHoraria(idProfesional, idEspecialidad, centro)
        {
            var eventosDispHor = [];
            var disponibilidadHoraria = obtenerDisponibilidadHoraria(idProfesional, idEspecialidad, centro);

            disponibilidadHoraria.forEach(function (e)
            {

                var dateInic = new Date(e.FECHA_INIC);
                var dateFin = new Date(e.FECHA_FIN);

                var diasArray = obtenerDiasSinFindesemanas(dateInic, dateFin);

                eventosDispHor = armarSemanasSinFindesemanas(diasArray);
                                    
            });

            crearComboDias(eventosDispHor);

        }

        function obtenerDisponibilidadHoraria(idProfesional, idEspecialidad, centro, dia="")
        {

            $.ajax({
                url: "GestionTratamientos.aspx/traerDisponibilidadHoraria",
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
                url: "GestionTratamientos.aspx/traerTurnos",
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

        function buscarPaciente(dniPaciente)
        {
            $.ajax({
                url: "GestionTratamientos.aspx/buscarPaciente",
                data: "{dniPaciente: '" + dniPaciente + "'}",
                type: "post",
                contentType: "application/json",
                async: false,
                success: function (data) {
                    var paciente = JSON.parse(data.d);
                    var datosPaciente;

                    if (data.d != "null")
                    {
                        datosPaciente = paciente.Apellido + " " + paciente.Nombre;
                        $('#txtIdPaciente').val(paciente.IdPaciente);

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

        function crearComboDias(eventosDispHor) { //"#ddlDiaTurno"

            var contadorEventos = Object.keys(eventosDispHor).length;
            if (contadorEventos > 0) {
                $("#ddlDiaTurno").append('<option value="0" selected="selected" hidden="hidden">--Seleccione--</option>');
                eventosDispHor.forEach(function (e) {
                    var fecha_inicio = e.start;
                    //moment.locale('es');

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

                    $("#ddlDiaTurno").append($("<option></option>").val(fecha_inicio).html(diaFormat2));
                    $("#divDiaTurno").show();
                });
            } else {

                $("#ddlDiaTurno").empty();
                $("#divDiaTurno").hide();
                $("#divAlertMsg").show();

            }
        }

        function cargarHoras(dispHoraria) {

            var contador = Object.keys(dispHoraria).length;
            if (contador > 0) {
                $("#ddlHoraDesde").empty();
                $("#divHoraTurno").show();
                $("#divBtnAgregarTurno").show();

                var horaDesde = parseInt(dispHoraria[0].HORA_DESDE.substring(0, 2), 10);
                   
                var horaHasta = parseInt(dispHoraria[0].HORA_HASTA.substring(0, 2), 10);

                for (i = 0; horaDesde != horaHasta; i++)
                {
                    $("#ddlHoraDesde").append($("<option></option>").val(horaDesde).html(horaDesde));
                    horaDesde += 1;
                }

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
                "order": [[ 7, "asc" ], [ 9, "desc" ]],
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

        Date.prototype.addDays = function(days) {
            var date = new Date(this.valueOf());
            date.setDate(date.getDate() + days);
            return date;
        }
        // #endregion
    </script>
</asp:Content>