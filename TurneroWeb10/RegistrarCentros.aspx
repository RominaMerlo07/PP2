<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarCentros.aspx.cs" Inherits="TurneroWeb10.RegistrarCentros" ClientIDMode="Static" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <section class="content-header">
        <h1>CENTROS DE ATENCIÓN</h1>
    </section>

    <section class="content">   
        
         <div class="row">
            <button class="btn btn-success btn-lg float-right" type="button" id="btnRegistrarModal"> <i class="fa-solid fa-house-medical"></i> | Registrar Centro de Atención</button>
        </div>
        <br />

        <!-- Lista centros -->
        <!-- Datatable Part -->
        <div class="row">
            <div class="box box-primary">
                <div class="box-header">
                    <h1 class="box-title">Listado de los Centros de Atención</h1>
                </div>
                <div class="box-body table-responsive">
                    <div class="col-md-12">
                        <table id="tabla_Centros" style="width:100%" class="table table-bordered table-hover">
                            <tbody id="tbl_body_table">
                                <!-- DATA POR MEDIO DE AJAX-->
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <!-- End Datatable -->
        <!-- End Lista centros -->

    </section>



    <%--Modal Registrar--%>
    <div class="modal fade" id="modalRegistrar" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header text-white bg-info">
                    <h4 class="modal-title" id="lblRegistrar">Registrar Centro de Atención</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body" id="formularioRegistrar">
                    <div class="card-body">
                        <div class="col-sm">
                            <div class="row">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Nombre Centro</span>
                                    </div>
                                    <%--<input type="text" name="nombre" style="text-align: left" class="formulario-input form-control" id="id__txtNombre" />--%>
                                     <input type="text" name="calle" id="id__txtNombre" style="text-align: left" class="form-control" maxlength="120" onkeyup="javascript:this.value=this.value.toUpperCase();" />
                                </div>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Calle</span>
                                    </div>
                                    <input type="text" name="calle" id="id__txtCalle" style="text-align: left" class="form-control" maxlength="120" onkeyup="javascript:this.value=this.value.toUpperCase();" />
                                    <%--<i class="formulario__validacion fas fa-times-circle" id="icon__txtCalle"></i>                                                    --%>
                                </div>
                                <%--<p class="formulario__error" id="p__txtCalle">Por favor, ingrese la calle</p>--%>
                            </div>
                            <div class="col-sm-4">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Numero</span>
                                    </div>
                                    <input type="text" name="numero" style="text-align: left" class="form-control" id="id__txtNumero" maxlength="4" />
                                    <%--<i class="formulario__validacion fas fa-times-circle" id="icon__txtNumero"></i>                                                    --%>
                                </div>
                                <%--<p class="formulario__error" id="p__txtNumero">Por favor, ingrese el Número o "0".</p>--%>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Barrio</span>
                                    </div>
                                    <input type="text" name="barrio" style="text-align: left" class="form-control" id="id__txtBarrio" maxlength="100" onkeyup="javascript:this.value=this.value.toUpperCase();" />
                                    <%--<i class="formulario__validacion fas fa-times-circle" id="icon__txtBarrio"></i>    --%>
                                </div>
                                <%--<p class="formulario__error" id="p__txtBarrio">Por favor, ingrese el Barrio</p>--%>
                            </div>
                            <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Localidad</span>
                                    </div>
                                    <input type="text" name="localidad" style="text-align: left" class="form-control" id="id__txtLocalidad" maxlength="120" onkeyup="javascript:this.value=this.value.toUpperCase();" />
                                    <%--<i class="formulario__validacion fas fa-times-circle" id="icon__txtLocalidad"></i>  --%>
                                </div>
                                <%--<p class="formulario__error" id="p__txtLocalidad">Por favor, ingrese la Localidad</p>--%>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Telefono</span>
                                    </div>
                                    <input type="text" name="telefono" style="text-align: left" class="form-control" id="id__txtTelefono" maxlength="100" onkeyup="javascript:this.value=this.value.toUpperCase();" placeholder="Ej.: 3514560000"/>
                                    <%--<i class="formulario__validacion fas fa-times-circle" id="icon__txtBarrio"></i>    --%>
                                </div>
                                <%--<p class="formulario__error" id="p__txtBarrio">Por favor, ingrese el Barrio</p>--%>
                            </div>
                            <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Celular</span>
                                    </div>
                                    <input type="text" name="celular" style="text-align: left" class="form-control" id="id__txtCelular" maxlength="120" onkeyup="javascript:this.value=this.value.toUpperCase();" placeholder="Ej.: 3515127426"/>
                                    <%--<i class="formulario__validacion fas fa-times-circle" id="icon__txtLocalidad"></i>  --%>
                                </div>
                                <%--<p class="formulario__error" id="p__txtLocalidad">Por favor, ingrese la Localidad</p>--%>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Email: </span>
                                    </div>
                                    <input type="text" name="email1" class="form-control" id="id__txtEmail1" maxlength="150" onkeyup="javascript:this.value=this.value.toUpperCase();" />
                                    <%-- <i class="formulario__validacion fas fa-times-circle" id="icon__txtEmail1"></i>  --%>
                                    <div class="input-group-append">
                                        <span class="input-group-text">@</span>
                                    </div>
                                    <input type="text" name="email2" class="form-control" id="id__txtEmail2" maxlength="100" placeholder="gmail.com" onkeyup="javascript:this.value=this.value.toUpperCase();" />
                                    <%--<i class="formulario__validacion fas fa-times-circle" id="icon__txtEmail2"></i>  --%>
                                </div>
                                <%--<p class="formulario__error" id="p__txtEmail2">Por favor, ingrese un email valido</p>--%>
                            </div>
                        </div>
                    </div>
                    <button class="btn btn-success btn-lg float-right" type="button" id="btnRegistrar">Registrar</button>
                </div>
            </div>
        </div>
    </div>

    <%--final Modal registrar--%>






       <%-- <h1 style="text-align: left">REGISTRAR NUEVO CENTRO</h1>
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
                </div>--%>

      

<%--     <div class="modal fade" id="modalEditarCentro" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
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
    </div>--%>

    <script type="text/javascript" src="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "ScriptsPantallas/Centros.js"%>"></script>

  </asp:Content>
