<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarPaciente.aspx.cs" Inherits="TurneroWeb10.RegistrarPaciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%--<p>"ABM REGISTRAR PACIENTE"</p>--%>

    <section class="content-header">
        <button class="btn btn-info btn-sm float-right" type="button" id="Listar">Listar Pacientes</button>
        <h1 style="text-align: left">REGISTRO DE PACIENTES</h1>
    </section>
    <section class="content">
        <div class="row">
            <div class="col-md-6" id="crdDatosPersonales">
                <div class="card text-white bg-light">
                    <div class="card-header bg-info">
                        <h4>Datos personales</h4>
                    </div>
                    <div class="card-body">
                        <div class="form-row">
                            <div class="col-sm4">
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
                        <div>
                            <div class="form-row">
                                <div class="col">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">Fecha de Nacimiento</span>
                                        </div>
                                        <div>
                                            <input type='text' class="form-control datepicker date" id="dtpFechaTurno"
                                                placeholder="DD/MM/YYYY" data-provide="datepicker"
                                                data-date-format="dd/mm/yyyy" />
                                        </div>
                                    </div>
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
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-6" id="crdDatosContacto">
                <div class="card text-white bg-light">
                    <div class="card-header bg-info">
                        <h4>Datos de Contacto</h4>
                    </div>
                    <div class="card-body">
                        <div class="form-row">
                            <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Calle</span>
                                    </div>
                                    <input type="text" style="text-align: left" class="form-control" id="txtCalle" />
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Numero</span>
                                    </div>
                                    <input type="text" style="text-align: left" class="form-control" id="txtNumero" />
                                </div>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Barrio</span>
                                    </div>
                                    <input type="text" style="text-align: left" class="form-control" id="txtBarrio" />
                                </div>
                            </div>
                            <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Localidad</span>
                                    </div>
                                    <input type="text" style="text-align: left" class="form-control" id="txtLocalidad" />
                                </div>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Celular</span>
                                    </div>
                                    <input type="text" style="text-align: left" class="form-control" id="txtCelular" />
                                </div>
                            </div>
                            <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Telefono</span>
                                    </div>
                                    <input type="text" style="text-align: left" class="form-control" id="txtTelefono" />
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
        </div>
        <br />
        <!--VER COMO ALINEAR DOS BOTONES AL CENTRO O A LA DERECHA-->
        <%--<button class="btn btn-secondary btn-lg float-right" type="button" id="btnCancelar">Cancelar</button>--%>
        <button class="btn btn-success btn-lg float-right" type="button" id="btnRegistrar">Registrar</button>
    </section>
</asp:Content>
