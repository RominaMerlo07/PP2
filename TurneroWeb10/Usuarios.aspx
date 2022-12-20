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
                    <div class="col-md">
                        <table style="width:100%" id="tabla_usuarios" class="table table-striped table-hover table-bordered">
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
                                        <div class="col-md-6">
                                            <div class="input-group mb-3">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">DNI del Personal </span>
                                                </div>
                                                <input type="search" name="dni" class="form-control rounded" maxlength="8" id="id__txtDocumento" aria-label="Search"
                                                    aria-describedby="search-addon" onkeypress="return soloNumeros(event)" />
                                                <button class="btn btn-outline-secondary" id="btnBuscarDNI" type="button">
                                                    <i class="fas fa-search"></i>
                                                </button>
                                            </div>
                                            <p class="formulario__error" id="p__txtDocumento">Por favor, ingrese el numero de documento sin puntos</p>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col">
                                            <div class="input-group mb-3">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text" id="">Nombre y Apellido</span>
                                                </div>
                                                <input type="text" name="nombre" style="text-align: left" class="form-control" id="id__txtNombre" maxlength="150" onkeypress="return soloLetras(event)" onpaste="return false" onkeyup="javascript:this.value=this.value.toUpperCase();" />
                                                <input type="text" name="apellido" style="text-align: left" class="form-control" id="id__txtApellido" maxlength="150" onkeypress="return soloLetras(event)" onpaste="return false" onkeyup="javascript:this.value=this.value.toUpperCase();" />                                       
                                            </div>                                          
                                        </div>
                                    </div>
                                     <div class="form-row">
                                        <div class="col">
                                            <div class="input-group mb-3">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text" id="">Email</span>
                                                </div>
                                                <input type="text" name="email" style="text-align: left" class="form-control" id="id__Email" maxlength="230" onkeyup="javascript:this.value=this.value.toUpperCase();" />                                                                                        
                                            </div>                                        
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
                                                        </div>                                                        
                                                    </div>                                                 
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <br />                           
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
                                </div>                           
                            </div>                          
                        </div>
                        <p style="color: midnightblue;"> En caso de que el usuario necesite recuperar su contraseña, debe seleccionar la opcion "Recuperar contraseña" en la pantalla de inicio de sesión.</p>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary btn-lg float-right" id="btnActualizar">Actualizar</button>
                </div>
            </div>
        </div>
    </div>
    <%--End Modal Editar--%>


    <link href="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "Estilos/styleRegistrarProfesional.css"%>" rel="stylesheet" type="text/css" />
   <script type="text/javascript" src="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "ScriptsPantallas/Usuarios.js"%>"></script>
     <script type="text/javascript" src="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "ScriptsPantallas/Usuarios_validacion.js"%>"></script>

</asp:Content>
