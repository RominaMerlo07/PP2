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
        <br/>

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
    <script type="text/javascript" src="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "ScriptsPantallas/Tratamientos.js"%>"></script>
</asp:Content>