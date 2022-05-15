<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarPersonal.aspx.cs" Inherits="TurneroWeb10.RegistrarPersonal" ClientIDMode="Static"%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

       <section class="content-header">
       <h1 style="text-align: center">PERSONAL ADMINISTRATIVO</h1>
    </section>

    <section class="content">

        <div class="row">
            <button class="btn btn-success btn-lg float-right" type="button" id="btnRegistrarModal"> <i class="fas fa-user-plus"></i>  | Registrar Personal Administrativo</button>
        </div>
        <br />

        <!-- Lista usuarios -->
        <!-- Datatable Part -->
        <div class="row">
            <div class="box box-primary">
                <div class="box-header">
                    <h1 class="box-title">Listado del Personal Administrativo</h1>
                </div>
                <div class="box-body table-responsive">
                    <div class="col-md-12">
                        <table id="tabla_PersonalAdmin" class="table table-bordered table-hover">
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
                        <h4 class="modal-title" id="lblRegistrar">Registrar Personal Administrativo</h4>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    </div>
                    <div class="modal-body" id="formularioRegistrar">                 
                        <div class="row">
                            <div class="col-md" id="crdDatosPersonales">
                                <div class="card text-white bg-light">
                                    <div class="card-header bg-info">
                                        <h4>Datos personales</h4>
                                    </div>
                                    <div class="card-body">
                                        <div class="form-row">
                                            <div class="col-sm">
                                                <div class="row">
                                                    <div class="col-sm">
                                                        <div class="input-group mb-3">                                                            
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text">DNI</span>
                                                            </div>
                                                            <input type="text" name="dni" style="text-align: left" class="formulario-input form-control" id="id__txtDocumento" maxlength="8" onkeypress="return soloNumeros(event)" onpaste="return false" />
                                                            <%--<i class="formulario__validacion fas fa-times-circle" id="icon__txtDocumento"></i>--%>
                                                        </div>
                                                       <%-- <p class="formulario__error" id="p__txtDocumento"> Por favor, ingrese el DNI sin puntos.</p>--%>
                                                    </div>
                                                   
                                                </div>
                                            </div>
                                            <div class="col-sm">
                                                <div class="input-group mb-3">
                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text">Fecha de Nacimiento</span>
                                                    </div>
                                                  <%--  <div>--%>
                                                        <input type='text' name="fechaNac" class="form-control datepicker date" id="id__dtpFechaNac"
                                                            placeholder="DD/MM/YYYY" data-provide="datepicker"
                                                            data-date-format="dd/mm/yyyy" />
                                                      <%--  <i class="formulario__validacion fas fa-times-circle" id="icon__dtpFechaNac"></i>--%>
                                                    <%--</div>--%>
                                                </div>
                                                   <%-- <p class="formulario__error" id="p__dtpFechaNac"> Por favor, ingrese la fecha de nacimiento</p>--%>
                                            </div>
                                        </div>                                        
                                        <div class="form-row">
                                            <div class="col">
                                                <div class="input-group mb-3">
                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text" id="">Nombre y Apellido</span>
                                                    </div>
                                                    <input type="text" name="nombre" style="text-align: left" class="form-control" id="id__txtNombre" maxlength="150" onkeypress="return soloLetras(event)" onpaste="return false" onkeyup="javascript:this.value=this.value.toUpperCase();"/>
                                                   <%--  <i class="formulario__validacion fas fa-times-circle" id="icon__txtNombre"></i>--%>
                                                    <input type="text" name="apellido" style="text-align: left" class="form-control" id="id__txtApellido" maxlength="150" onkeypress="return soloLetras(event)" onpaste="return false" onkeyup="javascript:this.value=this.value.toUpperCase();" />
                                                    <%--<i class="formulario__validacion fas fa-times-circle" id="icon__txtApellido"></i>--%>
                                                </div>
                                               <%-- <p class="formulario__error" id="p__txtNombre"> Por favor, ingrese el/los nombre/s</p>
                                                <p class="formulario__error" id="p__txtApellido"> Por favor, ingrese el/los apellido/s</p>--%>
                                            </div>
                                        </div>
                                     
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md" id="crdDatosContacto">
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
                                                    <input type="text" name="numero" style="text-align: left" class="form-control" id="id__txtNumero" maxlength="4"/>
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
                                            <div class="col-sm-6">
                                                <div class="input-group mb-3">
                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text">Celular</span>
                                                    </div>
                                                    <input type="text" name="celular" style="text-align: left" class="form-control" id="id__txtCelular" maxlength="10" onkeypress="return soloNumeros(event)" onpaste="return false" placeholder="Ej: 3515123456" />
                                                    <%-- <i class="formulario__validacion fas fa-times-circle" id="icon__txtCelular"></i>  --%>
                                                </div>
                                               <%-- <p class="formulario__error" id="p__txtCelular">Por favor, ingrese el Celular sin 0 y sin 15</p>--%>
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
                                </div>
                            </div>
                        </div>
                        <br />
                    <%--<button class="btn btn-secondary btn-lg float-right" type="button" id="btnCancelar">Cancelar</button>--%>
                        <button class="btn btn-success btn-lg float-right" type="button" id="btnRegistrar">Registrar</button>                       
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
                    <h4 class="modal-title" id="myModalLabel">Actualizar datos del Personal</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body" id="formularioEditar">
                    <div class="row">
                        <div class="col-md" id="crdDatosPersonalesE">
                            <div class="card text-white bg-white">
                                <div class="card-header text-black bg-light">
                                    <h4>Datos personales</h4>
                                </div>
                                <div class="card-body">
                                    <div class="form-row">
                                            <div class="col-sm">
                                                <div class="row">
                                                    <div class="col-sm">
                                                        <div class="input-group mb-3">                                                            
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text">DNI</span>
                                                            </div>
                                                            <input type="text" name="dni" style="text-align: left" class="formulario-input form-control" id="id__txtDocumentoE" maxlength="8" onkeypress="return soloNumeros(event)" onpaste="return false" />
                                                            <%--<i class="formulario__validacion fas fa-times-circle" id="icon__txtDocumento"></i>--%>
                                                        </div>
                                                       <%-- <p class="formulario__error" id="p__txtDocumento"> Por favor, ingrese el DNI sin puntos.</p>--%>
                                                    </div>
                                                   
                                                </div>
                                            </div>
                                            <div class="col-sm">
                                                <div class="input-group mb-3">
                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text">Fecha de Nacimiento</span>
                                                    </div>
                                                  <%--  <div>--%>
                                                        <input type='text' name="fechaNac" class="form-control datepicker date" id="id__dtpFechaNacE"
                                                            placeholder="DD/MM/YYYY" data-provide="datepicker"
                                                            data-date-format="dd/mm/yyyy" />
                                                      <%--  <i class="formulario__validacion fas fa-times-circle" id="icon__dtpFechaNac"></i>--%>
                                                    <%--</div>--%>
                                                </div>
                                                   <%-- <p class="formulario__error" id="p__dtpFechaNac"> Por favor, ingrese la fecha de nacimiento</p>--%>
                                            </div>
                                        </div>       
                                    <div class="form-row">
                                        <div class="col">
                                            <div class="input-group mb-3">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text" id="">Nombre y Apellido</span>
                                                </div>
                                                <input type="text" style="text-align: left" class="form-control" id="txtNombreA" maxlength="150" onkeypress="return soloLetras(event)" onpaste="return false" onkeyup="javascript:this.value=this.value.toUpperCase();" />
                                                <input type="text" style="text-align: left" class="form-control" id="txtApellidoA" maxlength="150" onkeypress="return soloLetras(event)" onpaste="return false" onkeyup="javascript:this.value=this.value.toUpperCase();" />
                                            </div>
                                        </div>
                                    </div>                                 
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md" id="crdDatosContactoE">
                            <div class="card text-white bg-white">
                                <div class="card-header text-black bg-light">
                                    <h4>Datos de Contacto</h4>
                                </div>
                                <div class="card-body">
                                    <div class="form-row">
                                        <div class="col">
                                            <div class="input-group mb-3">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">Direccion</span>
                                                </div>
                                                <input type="text" style="text-align: left" class="form-control" id="txtDomicilio" maxlength="160" onkeyup="javascript:this.value=this.value.toUpperCase();" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col">
                                            <div class="input-group mb-3">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">Barrio</span>
                                                </div>
                                                <input type="text" style="text-align: left" class="form-control" id="txtBarrioA" maxlength="100" onkeyup="javascript:this.value=this.value.toUpperCase();" />
                                            </div>
                                        </div>
                                        <div class="col">
                                            <div class="input-group mb-3">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">Localidad</span>
                                                </div>
                                                <input type="text" style="text-align: left" class="form-control" id="txtLocalidadA" maxlength="120" onkeyup="javascript:this.value=this.value.toUpperCase();" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col-sm-6">
                                            <div class="input-group mb-3">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">Celular</span>
                                                </div>
                                                <input type="text" style="text-align: left" class="form-control" id="txtCelularA" maxlength="10" onkeypress="return soloNumeros(event)" onpaste="return false" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col">
                                            <div class="input-group mb-3">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">Email: </span>
                                                </div>
                                                <input type="text" class="form-control" id="txtEmail1A" maxlength="150" onkeyup="javascript:this.value=this.value.toUpperCase();" />
                                                <div class="input-group-append">
                                                    <span class="input-group-text">@</span>
                                                </div>
                                                <input type="text" class="form-control" id="txtEmail2A" placeholder="gmail.com" maxlength="100" onkeyup="javascript:this.value=this.value.toUpperCase();" />
                                            </div>
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
            </div>
        </div>
    </div>
    <%--End Modal Editar--%>


    <script type="text/javascript" src="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "ScriptsPantallas/Personal.js"%>"></script>


</asp:Content>
