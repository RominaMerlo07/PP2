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

  
        /*.selected{ 
            background-color: darkcyan !important;
            font-weight: bold !important;
            color: #010101 !important;
                 }*/

  
       
    
	
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
                <div class="card text-white bg-light" id="ocultoSiempre" style="display: none">
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
                <div class="card">
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
                <div class="card">
                    <button class="btn btn-secondary btn-lg " type="button" onclick="volver()" id="btnVolver">Volver a la Disponibilidad Horaria</button>
                    <div class="card-body">
                        <div id='calendarioTurnos'></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--MODAL TURNO--%>
    <div class="modal fade" tabindex="-1" role="dialog" id="modalTurno">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header bg-info text-white">
                    <h4 class="modal-title " id="lblTituloTurno">Reserva de Turno</h4>
                    <button type="button" id="btnClose" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
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
                                                aria-describedby="search-addon" onkeypress="return soloNumeros(event)" />
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
                                            <input type="text" style="text-align: left" class="form-control" id="txtCelular" onkeypress="return soloNumeros(event)" disabled="disabled" />
                                        </div>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="col">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="">Nombre y Apellido:</span>
                                            </div>
                                            <input type="text" style="text-align: left" class="form-control" id="txtNombre" onkeypress="return soloLetras(event)" disabled="disabled" onkeyup="javascript:this.value=this.value.toUpperCase();" />
                                            <input type="text" style="text-align: left" class="form-control" id="txtApeliido" onkeypress="return soloLetras(event)" disabled="disabled" onkeyup="javascript:this.value=this.value.toUpperCase();" />
                                        </div>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="col ">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">Email: </span>
                                            </div>
                                            <input type="text" class="form-control" id="txtEmail1" disabled="disabled" />
                                            <div class="input-group-append">
                                                <span class="input-group-text">@</span>
                                            </div>
                                            <input type="text" class="form-control" id="txtEmail2" placeholder="gmail.com" disabled="disabled" />
                                        </div>
                                    </div>
                                </div>                             
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12" id="crdObraSocial" style="display: none">
                        <div class="card text-white ">
                            <div class="card-header ">
                                <h4 class="modal-title text-dark" id="textObraSocial">Seleccione Obra Social</h4>
                            </div>
                            <div class="card-body">
                                <div id="formObraSocial" style="display: none">
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
                                    <div class="form-row">
                                        <div class="col ">
                                            <div class="input-group mb-3">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">Nro. Afiliado:</span>
                                                </div>
                                                <input type="text" style="text-align: left" class="form-control" id="txtNroAfiliado" onkeypress="return soloNumeros(event)" disabled="disabled" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-10 col-xs-6">
                                            <button class="btn btn-success float-right" type="button" id="btnAgregar">Agregar</button>
                                        </div>
                                        <div class="col-md-2 col-xs-6">
                                            <button class="btn btn-secondary float-right" type="button" id="btnCancelar">Cancelar</button>
                                        </div>
                                    </div>
                                </div>
                                <button class="btn btn-primary" type="button" id="btnRegistrarOS"><i class="fas fa-plus-square"></i>| Agregar Obra Social</button>

                                <div id="tblObraSocialPaciente" class="table-responsive text-dark" style="display: none">
                                    <div id="tListarOS">
                                        <table style="width: 100%" class="table  table-bordered text-dark" id="tablaOSPaciente">
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <div class="modal-footer">
                    <div class="row float-right">
                        <button class="btn btn-success btn-lg " type="button" id="btnRegistrarNew">Registrar Turno</button>
                        <button class="btn btn-success btn-lg " type="button" id="btnRegistrarExis">Registrar Turno</button>
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
    <script type="text/javascript" src="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "ScriptsPantallas/registrarTurnos.js"%>"></script>
</asp:Content>
