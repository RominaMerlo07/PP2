<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="TurneroWeb10.Usuarios" ClientIDMode="Static"%>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <section class="content-header">
       <h1 style="text-align: center">USUARIOS</h1>
    </section>

    <section class="content">

        <div class="row">
            <button class="btn btn-success btn-lg float-right" type="button" id="btnRegistrarModal"> <i class="fas fa-user-plus"></i>  | Generar Usuario</button>
        </div>
        <br />

        <!-- Lista usuarios -->
        <!-- Datatable Part -->
        <div class="row">
            <div class="box box-primary">
                <div class="box-header">
                    <h1 class="box-title">Lista de Usuarios</h1>
                </div>
                <div class="box-body table-responsive">
                    <div class="col-md-12">
                        <table id="tabla_usuarios" class="table table-bordered table-hover">
                            <tbody id="tbl_body_table">
                                <!-- DATA POR MEDIO DE AJAX-->
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <!-- End Datatable -->
        <!-- End Lista usuarios -->

    </section>


    <%--Modal Registrar--%>
    <div class="modal fade" id="modalRegistrar" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header text-white bg-info">
                    <h4 class="modal-title" id="lblRegistrar">Generar Usuario</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close" onclick="return limpiarCampos();"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body" id="formularioRegistrar">
                    <div class="row">
                        <div class="col-md" id="crdDatosPersonales">
                            <div class="card text-white bg-light">
                                <div class="card-header bg-info">
                                    <h4>Buscar Personal</h4>
                                </div>
                                <div class="card-body">
                                    <div class="form-row">
                                        <div class="col">
                                            <div class="input-group mb-3">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">DNI del Personal </span>
                                                </div>
                                                <input type="search" class="form-control rounded" id="txtDocumento" placeholder="Ingrese DNI" aria-label="Search"
                                                    aria-describedby="search-addon" onkeypress="return soloNumeros(event)" />
                                                <button class="btn btn-outline-secondary" id="btnBuscarDNI" type="button">
                                                    <i class="fas fa-search"></i>
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col">
                                            <div class="input-group mb-3">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text" id="">Nombre y Apellido</span>
                                                </div>
                                                <input type="text" name="nombre" style="text-align: left" class="form-control" id="id__txtNombre" maxlength="150" onkeypress="return soloLetras(event)" onpaste="return false" onkeyup="javascript:this.value=this.value.toUpperCase();" />
                                                <%-- <i class="formulario__validacion fas fa-times-circle" id="icon__txtNombre"></i>--%>
                                                <input type="text" name="apellido" style="text-align: left" class="form-control" id="id__txtApellido" maxlength="150" onkeypress="return soloLetras(event)" onpaste="return false" onkeyup="javascript:this.value=this.value.toUpperCase();" />
                                                <%-- <i class="formulario__validacion fas fa-times-circle" id="icon__txtApellido"></i>--%>
                                            </div>
                                            <%-- <p class="formulario__error" id="p__txtNombre">Por favor, ingrese el/los nombre/s</p>
                                        <p class="formulario__error" id="p__txtApellido">Por favor, ingrese el/los apellido/s</p>--%>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md" id="crdDatosContacto">
                                        <div class="card text-white bg-light">
                                            <div class="card-header bg-info">
                                                <h4>Alta de Usuario</h4>
                                            </div>
                                            <div class="card-body">
                                                <div class="form-row">
                                                    <div class="col">
                                                        <div class="input-group mb-3">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text">Seleccionar Rol </span>
                                                            </div>
                                                            <select class="custom-select form-control" id="ddlRol">
                                                            </select>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-row">
                                                    <div class="col">
                                                        <div class="input-group mb-3">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text">Usuario</span>
                                                            </div>
                                                            <input type="text" name="usuario" style="text-align: left" class="form-control" id="id__txtUsuario" maxlength="100" onkeyup="javascript:this.value=this.value.toUpperCase();" />
                                                            <%-- <i class="formulario__validacion fas fa-times-circle" id="icon__txtUsuario"></i>--%>
                                                        </div>
                                                        <%--<p class="formulario__error" id="p__txtUsuario">Por favor, ingrese el Barrio</p>--%>
                                                    </div>
                                                    <div class="col">
                                                        <div class="input-group mb-3">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text">Contraseña</span>
                                                            </div>
                                                            <input type="password" name="password" style="text-align: left" class="form-control" id="id__txtPassword" maxlength="120" onkeyup="javascript:this.value=this.value.toUpperCase();" />
                                                             <div class="input-group-append">
                                                            <button id="show_passwordA" class="btn btn-primary" type="button" onclick="mostrarPassword('id__txtPassword')"><span class="fa fa-eye-slash icon"></span></button>
                                                            </div>
                                                            <%-- <i class="formulario__validacion fas fa-times-circle" id="icon__txtPassword"></i>--%>
                                                        </div>
                                                        <%--  <p class="formulario__error" id="p__txtPassword">Por favor, ingrese una contraseña</p>--%>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <%--<button class="btn btn-secondary btn-lg float-right" type="button" id="btnCancelar">Cancelar</button>--%>
                            <button class="btn btn-success btn-lg float-right" type="button" id="btnRegistrar">Generar</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--final Modal registrar--%>

       
    <%--Modal Editar--%>
    <div class="modal fade" id="modalEditar" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header text-white bg-info">
                    <h4 class="modal-title" id="myModalLabel">Actualizar datos del Usuario</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body" id="formularioEditar">
                    <div>
                        <h4 class="modal-title" id="infoProfesional">Personal</h4>
                    </div>
                    <div class="card-body">
                        <div class="form-row">
                            <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Seleccionar Rol </span>
                                    </div>
                                    <select class="custom-select form-control" id="ddlRolE">
                                    </select>
                                </div>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Usuario</span>
                                    </div>
                                    <input type="text" name="usuario" style="text-align: left" class="form-control" id="id__txtUsuarioE" maxlength="100" onkeyup="javascript:this.value=this.value.toUpperCase();" />
                                    <%-- <i class="formulario__validacion fas fa-times-circle" id="icon__txtUsuario"></i>--%>
                                </div>
                                <%--<p class="formulario__error" id="p__txtUsuario">Por favor, ingrese el Barrio</p>--%>
                            </div>
                            <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Contraseña</span>
                                    </div>
                                    <input type="password" name="password" style="text-align: left" class="form-control" id="id__txtPasswordE" maxlength="120" onkeyup="javascript:this.value=this.value.toUpperCase();" />
                                    <div class="input-group-append">
                                        <button id="show_password" class="btn btn-primary" type="button" onclick="mostrarPassword('id__txtPasswordE')"><span class="fa fa-eye-slash icon"></span></button>
                                    </div>
                                    <%-- <i class="formulario__validacion fas fa-times-circle" id="icon__txtPassword"></i>--%>
                                </div>
                                <%--  <p class="formulario__error" id="p__txtPassword">Por favor, ingrese una contraseña</p>--%>
                            </div>
                        </div>
                    </div>

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-success" id="btnActualizar">Actualizar</button>
                </div>
            </div>
        </div>
    </div>
    <%--End Modal Editar--%>



   <script type="text/javascript" src="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "ScriptsPantallas/Usuarios.js"%>"></script>

</asp:Content>
