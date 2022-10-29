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

    <%--Final Modal registrar--%>


    <%--Modal Editar--%>
    <div class="modal fade" id="modalEditar" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header text-white bg-info">
                    <h4 class="modal-title" id="lblEditar">Actualizar datos del Centro de Atención</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body" id="formularioEditar">
                    <div class="card-body">
                        <div class="col-sm">
                            <div class="row">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Nombre Centro</span>
                                    </div>
                                    <%--<input type="text" name="nombre" style="text-align: left" class="formulario-input form-control" id="id__txtNombre" />--%>
                                    <input type="text" name="calle" id="id__txtNombreE" style="text-align: left" class="form-control" maxlength="120" onkeyup="javascript:this.value=this.value.toUpperCase();" />
                                </div>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Dirección</span>
                                    </div>
                                    <input type="text" style="text-align: left" class="form-control" id="id__txtDomicilioE" maxlength="160" onkeyup="javascript:this.value=this.value.toUpperCase();" />
                                </div>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Barrio</span>
                                    </div>
                                    <input type="text" name="barrio" style="text-align: left" class="form-control" id="id__txtBarrioE" maxlength="100" onkeyup="javascript:this.value=this.value.toUpperCase();" />
                                    <%--<i class="formulario__validacion fas fa-times-circle" id="icon__txtBarrio"></i>    --%>
                                </div>
                                <%--<p class="formulario__error" id="p__txtBarrio">Por favor, ingrese el Barrio</p>--%>
                            </div>
                            <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Localidad</span>
                                    </div>
                                    <input type="text" name="localidad" style="text-align: left" class="form-control" id="id__txtLocalidadE" maxlength="120" onkeyup="javascript:this.value=this.value.toUpperCase();" />
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
                                    <input type="text" name="telefono" style="text-align: left" class="form-control" id="id__txtTelefonoE" maxlength="100" onkeyup="javascript:this.value=this.value.toUpperCase();" placeholder="Ej.: 3514560000" />
                                    <%--<i class="formulario__validacion fas fa-times-circle" id="icon__txtBarrio"></i>    --%>
                                </div>
                                <%--<p class="formulario__error" id="p__txtBarrio">Por favor, ingrese el Barrio</p>--%>
                            </div>
                            <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Celular</span>
                                    </div>
                                    <input type="text" name="celular" style="text-align: left" class="form-control" id="id__txtCelularE" maxlength="120" onkeyup="javascript:this.value=this.value.toUpperCase();" placeholder="Ej.: 3515127426" />
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
                                    <input type="text" name="email1" class="form-control" id="id__txtEmail1E" maxlength="150" onkeyup="javascript:this.value=this.value.toUpperCase();" />
                                    <%-- <i class="formulario__validacion fas fa-times-circle" id="icon__txtEmail1"></i>  --%>
                                    <div class="input-group-append">
                                        <span class="input-group-text">@</span>
                                    </div>
                                    <input type="text" name="email2" class="form-control" id="id__txtEmail2E" maxlength="100" placeholder="gmail.com" onkeyup="javascript:this.value=this.value.toUpperCase();" />
                                    <%--<i class="formulario__validacion fas fa-times-circle" id="icon__txtEmail2"></i>  --%>
                                </div>
                                <%--<p class="formulario__error" id="p__txtEmail2">Por favor, ingrese un email valido</p>--%>
                            </div>
                        </div>
                    </div>
                    <button class="btn btn-success btn-lg float-right" type="button" id="btnActualizar">Actualizar</button>
                </div>
            </div>
        </div>
    </div>

    <%--Final Modal Editar--%>



    <script type="text/javascript" src="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "ScriptsPantallas/Centros.js"%>"></script>

  </asp:Content>
