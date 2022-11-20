<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarCentros.aspx.cs" Inherits="TurneroWeb10.RegistrarCentros" ClientIDMode="Static" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   <section class="content-header">
        <h1 style="text-align: center">CENTROS DE ATENCIÓN</h1>
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
                                     <input type="text" name="nombre" id="id__txtNombre" style="text-align: left" class="form-control" maxlength="120"  onkeypress="return soloLetras(event)" onpaste="return false" onkeyup="javascript:this.value=this.value.toUpperCase();" /> <p style="color: red;">*</p>
                                </div>
                                <p class="formulario__error" id="p__txtNombre">Por favor, ingrese el nombre del centro.</p>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Calle</span>
                                    </div>
                                    <input type="text" name="calle" id="id__txtCalle" style="text-align: left" class="form-control" maxlength="120" onkeyup="javascript:this.value=this.value.toUpperCase();" /><p style="color: red;">*</p>
                                 </div>
                                <p class="formulario__error" id="p__txtCalle">Por favor, ingrese la calle</p>
                            </div>
                            <div class="col-sm-4">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Numero</span>
                                    </div>
                                    <input type="text" name="numero" style="text-align: left" class="form-control" id="id__txtNumero" maxlength="5" onkeypress="return soloNumeros(event)" /><p style="color: red;">*</p>                                                                                  
                                </div>
                                <p class="formulario__error" id="p__txtNumero">Por favor, ingrese el Número o "0".</p>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Barrio</span>
                                    </div>
                                    <input type="text" name="barrio" style="text-align: left" class="form-control" id="id__txtBarrio" maxlength="100" onkeyup="javascript:this.value=this.value.toUpperCase();" /><p style="color: red;">*</p> 
                                </div>
                                <p class="formulario__error" id="p__txtBarrio">Por favor, ingrese el Barrio</p>
                            </div>
                            <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Localidad</span>
                                    </div>
                                    <input type="text" name="localidad" style="text-align: left" class="form-control" id="id__txtLocalidad" maxlength="120" onkeyup="javascript:this.value=this.value.toUpperCase();" /><p style="color: red;">*</p>                             
                                </div>
                                <p class="formulario__error" id="p__txtLocalidad">Por favor, ingrese la Localidad</p>
                            </div>
                        </div>
                        <div class="form-row">                           
                            <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Celular</span>
                                    </div>
                                    <input type="text" name="celular" style="text-align: left" class="form-control" id="id__txtCelular" maxlength="10" onkeyup="javascript:this.value=this.value.toUpperCase();" onkeypress="return soloNumeros(event)" placeholder="Ej.: 3515127426"/><p style="color: red;">*</p>                             
                                </div>
                                <p class="formulario__error" id="p__txtCelular">Por favor, ingrese el celular sin 0 y sin 15</p>
                            </div>
                             <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Telefono</span>
                                    </div>
                                    <input type="text" name="telefono" style="text-align: left" class="form-control" id="id__txtTelefono" maxlength="10" onkeyup="javascript:this.value=this.value.toUpperCase();" placeholder="Ej.: 3514560000" onkeypress="return soloNumeros(event)"/>                                   
                                </div>                              
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Email: </span>
                                    </div>
                                    <input type="text" name="email1" class="form-control" id="id__txtEmail1" maxlength="150" onkeyup="javascript:this.value=this.value.toUpperCase();" />
                                    <div class="input-group-append">
                                        <span class="input-group-text">@</span>
                                    </div>
                                    <input type="text" name="email2" class="form-control" id="id__txtEmail2" maxlength="100" placeholder="gmail.com" onkeyup="javascript:this.value=this.value.toUpperCase();" /> <p style="color: red;">*</p>    
                                </div>
                                <p class="formulario__error" id="p__txtEmail2">Por favor, ingrese un email valido</p>
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
                                    <input type="text" name="nombreE" id="id__AtxtNombre" style="text-align: left" class="form-control"  onkeypress="return soloLetras(event)" maxlength="120" onkeyup="javascript:this.value=this.value.toUpperCase();" /><p style="color: red;">*</p>    
                                </div>
                                <p class="formulario__error" id="p__AtxtNombre">Por favor, ingrese el nombre del centro.</p>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Dirección</span>
                                    </div>
                                    <input type="text" name="domicilioE" style="text-align: left" class="form-control" id="id__AtxtDomicilio" maxlength="160" onkeyup="javascript:this.value=this.value.toUpperCase();" /><p style="color: red;">*</p>    
                                </div>
                                <p class="formulario__error" id="p__AtxtDomicilio">Por favor, ingrese el domicilio (calle y numero)</p>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Barrio</span>
                                    </div>
                                    <input type="text" name="barrioE" style="text-align: left" class="form-control" id="id__AtxtBarrio" maxlength="100" onkeyup="javascript:this.value=this.value.toUpperCase();" />  <p style="color: red;">*</p>                                
                                </div>
                                <p class="formulario__error" id="p__AtxtBarrio">Por favor, ingrese el Barrio</p>
                            </div>
                            <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Localidad</span>
                                    </div>
                                    <input type="text" name="localidadE" style="text-align: left" class="form-control" id="id__AtxtLocalidad" maxlength="120" onkeyup="javascript:this.value=this.value.toUpperCase();" /> <p style="color: red;">*</p>                                 
                                </div>
                                <p class="formulario__error" id="p__AtxtLocalidad">Por favor, ingrese la Localidad</p>
                            </div>
                        </div>
                        <div class="form-row">
                          
                            <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Celular</span>
                                    </div>
                                    <input type="text" name="celularE" style="text-align: left" class="form-control" id="id__AtxtCelular" maxlength="10" onkeyup="javascript:this.value=this.value.toUpperCase();" placeholder="Ej.: 3515127426" onkeypress="return soloNumeros(event)" /><p style="color: red;">*</p>  
           
                                </div>
                                <p class="formulario__error" id="p__AtxtCelular">Por favor, ingrese el celular sin 0 y sin 15</p>
                            </div>
                              <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Telefono</span>
                                    </div>
                                    <input type="text" name="telefonoE" style="text-align: left" class="form-control" id="id__AtxtTelefono" maxlength="10" onkeyup="javascript:this.value=this.value.toUpperCase();" onkeypress="return soloNumeros(event)" placeholder="Ej.: 3514560000" />                                  
                                </div>  
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Email: </span>
                                    </div>
                                    <input type="text" name="email1E" class="form-control" id="id__AtxtEmail1" maxlength="150" onkeyup="javascript:this.value=this.value.toUpperCase();" />                              
                                    <div class="input-group-append">
                                        <span class="input-group-text">@</span>
                                    </div>
                                    <input type="text" name="email2E" class="form-control" id="id__AtxtEmail2" maxlength="100" placeholder="gmail.com" onkeyup="javascript:this.value=this.value.toUpperCase();" /><p style="color: red;">*</p>                              
                                </div>
                                <p class="formulario__error" id="p__AtxtEmail2">Por favor, ingrese un email valido</p>
                            </div>
                        </div>
                    </div>
                    <button class="btn btn-primary btn-lg float-right" type="button" id="btnActualizar">Actualizar</button>
                </div>
            </div>
        </div>
    </div>

    <%--Final Modal Editar--%>



    <%--MODAL TURNO--%>
    <div class="modal fade" tabindex="-1" role="dialog" id="modalTurnos">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header bg-info text-white">
                    <h4 class="modal-title " id="lblTituloTurno">Eliminar Centro</h4>
                    <button type="button" id="btnClose" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body">
                    <%--<div class="row">--%>
                    <div class="box box-danger">
                        <div class="box-header">
                            <h1 class="box-title text-red">Al eliminar el centro, se cancelaran los siguientes turnos</h1>
                            <h6 class="box-title text-black">Podes reprogramarlos, antes de eliminar el centro, desde Mesa de Entrada > Agenda</h6>
                        </div>
                        <div class="box-body table-responsive">
                            <div class="col-md-12">
                                <table id="tabla_Turnos" style="width: 100%" class="table table-bordered table-hover">
                                    <tbody id="tbl_body_tableT">
                                        <!-- DATA POR MEDIO DE AJAX-->
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                    <%--</div>--%>
                    <div class="row float-right">
                        <div class="col">
                            <button class="btn btn-danger btn-lg " type="button" id="btnEliminar">Eliminar</button>
                            <button class="btn btn-secondary btn-lg " type="button" id="btnCancelar">Cancelar</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--Final Modal Turno--%>

     <link href="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "Estilos/styleRegistrarProfesional.css"%>" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "ScriptsPantallas/Centros.js"%>"></script>
    <script type="text/javascript" src="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "ScriptsPantallas/Centros_validacion.js"%>"></script>
  </asp:Content>
