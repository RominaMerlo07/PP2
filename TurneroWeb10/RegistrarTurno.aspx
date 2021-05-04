<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarTurno.aspx.cs" Inherits="TurneroWeb10.RegistrarTurno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content-header">
        <button class="btn btn-info btn-sm float-right" type="button" id="Listar">Listar Turnos</button>
        <h1 style="text-align: left">REGISTRAR TURNO</h1>
    </section>
    <section class="content">
        <div class="row">
            <div class="col-md-6" id="crdTurno">
                <div class="card text-white bg-light">
                    <div class="card-header bg-info">
                        <h4>Datos del Turno</h4>
                    </div>
                    <div class="card-body">
                        <div class="form-row">
                            <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Sucursal: </span>
                                    </div>
                                    <select class="custom-select form-control" id="ddlSucursal">
                                        <option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>
                                        <option value="1">Córdoba</option>
                                        <option value="2">Carlos Paz I</option>
                                        <option value="3">Carlos Paz II</option>
                                    </select>
                                </div>
                            </div>
                            <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Especialidad: </span>
                                    </div>
                                    <select class="custom-select form-control" id="ddlEspecialidad1">
                                        <option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>
                                        <option value="1">Kinesiología y Fisioterapia</option>
                                        <option value="2">Quiropraxia</option>
                                        <option value="3">Rehabilitacion de terapias deportivas</option>
                                        <option value="4">Rehabilitacion</option>
                                        <option value="5">Osteopatia</option>
                                        <option value="6">Actividades fisicas adaptadas</option>
                                        <option value="7">Reeducacion postural global</option>
                                        <option value="8">Tratamiento de columna vertebral</option>
                                        <option value="9">Lesion Nerviosa Espinal</option>
                                        <option value="10">Terapia fisica</option>
                                        <option value="11">Pre-Post Quirurgicos</option>
                                        <option value="12">Pilates</option>
                                        <option value="13">Terapias Chinas</option>
                                    </select>
                                </div>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Fecha</span>
                                    </div>
                                    <div>
                                        <input type='text' class="form-control datepicker date" id="dtpFechaD"
                                            placeholder="DD/MM/YYYY" data-provide="datepicker"
                                            data-date-format="dd/mm/yyyy" />
                                    </div>
                                </div>
                            </div>
                            <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Hora: </span>
                                    </div>
                                    <select class="btn btn-white form-control" id="ddlHoraDesde">
                                        <option value="8">8</option>
                                        <option value="9">9</option>
                                        <option value="10">10</option>
                                        <option value="11">11</option>
                                        <option value="12">12</option>
                                        <option value="13">13</option>
                                        <option value="14">14</option>
                                        <option value="15">15</option>
                                        <option value="16">16</option>
                                        <option value="17">17</option>
                                        <option value="18">18</option>
                                        <option value="19">19</option>
                                        <option value="20">20</option>
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
                    </div>
                    <div class="card text-white bg-light">
                        <div class="card-header bg-info">
                            <h4>Datos del Paciente</h4>
                        </div>
                        <div class="card-body">
                            <div class="form-row">
                                <div class="col">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">Paciente: </span>
                                        </div>
                                        <input type="search" class="form-control rounded" placeholder="Ingrese DNI" aria-label="Search"
                                            aria-describedby="search-addon" />
                                        <span class="input-group-text border-0" id="search-addon">
                                            <i class="fas fa-search"></i>
                                        </span>
                                    </div>
                                </div>
                                <div class="col">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">DNI</span>
                                        </div>
                                        <input type="text" style="text-align: left" class="form-control" id="txtDocumento" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="col">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text" id="">Nombre y Apellido</span>
                                        </div>
                                        <input type="text" style="text-align: left" class="form-control" id="txtNombre" />
                                        <input type="text" style="text-align: left" class="form-control" id="txtApeliido" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="col">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">Obra Social: </span>
                                        </div>
                                        <select class="custom-select form-control" id="ddlObraSocial">
                                            <option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>
                                            <option value="1">Particular</option>
                                            <option value="2">Omint</option>
                                            <option value="3">Sancor</option>
                                            <option value="3">Swiss Medical</option>
                                            <option value="3">Sipssa</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="col">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">Celular</span>
                                        </div>
                                        <input type="text" style="text-align: left" class="form-control" id="txtCelular" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="col">
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
                <br />
                <button class="btn btn-success btn-lg float-right" type="button" id="btnRegistrar">Registrar</button>
            </div>
            <div class="card" style="width: 40rem;">
                <div class="card-body">
                    <div id='calendar'></div>
                </div>
            </div>
        </div>



    </section>
</asp:Content>
