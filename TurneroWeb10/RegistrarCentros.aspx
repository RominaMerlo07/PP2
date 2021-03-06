<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarCentros.aspx.cs" Inherits="TurneroWeb10.RegistrarCentros" ClientIDMode="Static" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>--%>
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

              <!-- Datatable Part -->
        <div class="row">
            <div class="box box-primary">
                <div class="box-header">
                    <h3 class="box-title">Lista de Centros Sparring</h3>
                </div>
                <div class="box-body table-responsive">
                    <div class="col-md-12">
                        <table id="tabla_centros" class="table table-bordered table-hover">
                            <%--<thead>
                                <tr>
                                    <th>Numero</th>
                                    <th>Profesional</th>
                                    <th>DNI</th>
                                    <th>Matricula</th>
                                    <th>Nacimiento</th>
                                    <th>Contacto</th>
                                    <th>Email</th>
                                    <th>Domicilio</th>
                                    <th>Especialidad</th>
                                    <th>Acciones</th>
                                </tr>
                            </thead>--%>
                            <tbody id="tbl_body_table">
                                <!-- DATA POR MEDIO DE AJAX-->
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <!-- End Datatable -->

           </section>

     <div class="modal fade" id="modalEditarCentro" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header text-white bg-info">
                    <h4 class="modal-title" id="myModalLabel">Actualizar datos del Centro</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body">
                    <div>
                        <h4 class="modal-title" id="DatosCentro">Datos Centro</h4>
                    </div>
                    <br />
                    <div class="form-row">
                        <div class="col-sm">
                            <div class="row">
                                <div class="col-sm">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">Nombre</span>
                                        </div>
                                        <input type="text" style="text-align: left" class="form-control" id="txtNombre" maxlength="8" onpaste="return false"/>
                                    </div>
                                </div>
                                <div class="col-sm">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">Domicilio</span>
                                        </div>
                                        <input type="text" style="text-align: left" class="form-control" id="txtDomicilio" maxlength="10"  onpaste="return false"/>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="col">
                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <span class="input-group-text" id="">Localidad</span>
                                </div>
                                <input type="text" style="text-align: left" class="form-control" id="txtLocalidad"  maxlength="150" onpaste="return false" onkeyup="javascript:this.value=this.value.toUpperCase();"/>
                                <%--<input type="text" style="text-align: left" class="form-control" id="txtApellidoA"  maxlength="150" onkeypress="return soloLetras(event)" onpaste="return false" onkeyup="javascript:this.value=this.value.toUpperCase();"/>--%>
                            </div>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="col">
                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">E-mail</span>
                                </div>
                                <div>
                                    <input type="text" style="text-align: left" class="form-control" id="txtEmail" maxlength="10" onpaste="return false"/>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="col">
                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">N° Contacto</span>
                                </div>
                                <input type="text" style="text-align: left" class="form-control" id="txtNcontacto1"  maxlength="160" "/>
                            </div>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="col">
                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">N° Contacto Alternativo</span>
                                </div>
                                <input type="text" style="text-align: left" class="form-control" id="txtNcontacto2" maxlength="100" onkeyup="javascript:this.value=this.value.toUpperCase();"/>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-success" id="btnActualizarCentro">Actualizar</button>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript" src="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "ScriptsPantallas/Centros.js"%>"></script>

  </asp:Content>
