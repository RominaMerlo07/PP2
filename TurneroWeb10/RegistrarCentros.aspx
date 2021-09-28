<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarCentros.aspx.cs" Inherits="TurneroWeb10.RegistrarCentros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <section class="content-header">

         <button class="btn btn-info btn-sm float-right" type="button" id="Listar">Listar Centros</button>
     
            
        <h1 style="text-align: left">REGISTRAR NUEVO CENTRO</h1>
        </section>
        <section class="content">
            <div class="row">
                <div class="col-md-6" id="crEpecialidades">
                    <div class="card text-white bg-light">
                        <div class="card-header bg-info">
                            <h4>Datos Centro</h4>
                        </div>
                        <div class="card-body align-items-center" id="form-centros">
                            <div class="form-row">
                                <div class="col-sm-12">
                                    <div class="input-group mb-3 d-flex align-items-center">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text text-info">Nombre:</span>
                                        </div>
                                        <input type="text" style="text-align:left" class="form-control" id="txtNombreCentro"/>
                                    </div>
                                    <div class="input-group mb-3 d-flex align-items-center">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text text-info">Domicilio:</span>
                                        </div>
                                        <input type="text" style="text-align:left" class="form-control" id="txtDomicilioCentro"/>
                                    </div>
                                    <div class="input-group mb-3 d-flex align-items-center">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text text-info">Localidad:</span>
                                        </div>
                                        <input type="text" style="text-align:left" class="form-control" id="txtLocalidadCentro"/>
                                    </div>
                                    <div class="input-group mb-3 d-flex align-items-center">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text text-info">E-mail:</span>
                                        </div>
                                        <input type="text" style="text-align:left" class="form-control" id="txtEmailCentro1"/>
                                        <div class="input-group-addon">
                                            <span class="input-group-text text-info">@</span>
                                        </div>
                                        <input type="text" style="text-align:left" class="form-control" id="txtEmailCentro2"/>
                                    </div>
                                    <div class="input-group mb-3 d-flex align-items-center">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text text-info">Teléfono:</span>
                                        </div>
                                        <input type="text" style="text-align:left" class="form-control" id="txtTelefonoCentro1"/>
                                    </div>
                                    <div class="input-group mb-3 d-flex align-items-center">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text text-info">Teléfono alternativo:</span>
                                        </div>
                                        <input type="text" style="text-align:left" class="form-control" id="txtTelefonoCentro2"/>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12 text-center">
                                <button	type="button" class="btn btn-primary btn-lg" id="btnGuardarNvoCentro">Crear Centro</button>
                            </div>
                           </div>
                        </div>
                    </div>
                </div>
           </section>

    <script type="text/javascript" src="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "Scripts/Centros.js"%>"></script>

  </asp:Content>
