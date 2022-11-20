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
                        <table id="tabla_PersonalAdmin" style="width:100%" class="table table-bordered table-hover">
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
                                <div class="card text-white ">
                                    <div class="card-header  bg-info">
                                        <h4 class="modal-title text-white">Datos personales</h4>
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
                                                            <input type="text" name="dni" style="text-align: left" class="formulario-input form-control" id="id__txtDocumento" maxlength="8" onkeypress="return soloNumeros(event)" onpaste="return false" /><p style="color: red;">*</p>                                                           
                                                        </div>
                                                        <p class="formulario__error" id="p__txtDocumento"> Por favor, ingrese el DNI sin puntos.</p>
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
                                                    <input type="text" name="apellido" style="text-align: left" class="form-control" id="id__txtApellido" maxlength="150" onkeypress="return soloLetras(event)" onpaste="return false" onkeyup="javascript:this.value=this.value.toUpperCase();" /><p style="color: red;">*</p>
                                                   
                                                </div>
                                                <p class="formulario__error" id="p__txtNombre"> Por favor, ingrese el/los nombre/s</p>
                                                <p class="formulario__error" id="p__txtApellido"> Por favor, ingrese el/los apellido/s</p>
                                            </div>
                                        </div>
                                     
                                    </div>
                                </div>
                            </div>
                        </div>
                        </br>
                        <div class="row">
                            <div class="col-md" id="crdDatosContacto">
                                <div class="card text-white bg-light">
                                    <div class="card-header  bg-info" >
                                        <h4 class="modal-title text-white">Datos de Contacto</h4>
                                    </div>
                                    <div class="card-body">
                                        <div class="form-row">
                                            <div class="col">
                                                <div class="input-group mb-3">
                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text">Calle</span>
                                                    </div>                                                    
                                                        <input type="text" name="calle" id="id__txtCalle" style="text-align: left" class="form-control" maxlength="120" onkeyup="javascript:this.value=this.value.toUpperCase();" /><p style="color: red;">*</p>
                                                                                                          --%>
                                                </div>
                                                <p class="formulario__error" id="p__txtCalle">Por favor, ingrese la calle</p>
                                            </div>
                                            <div class="col-sm-4">
                                                <div class="input-group mb-3">
                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text">Numero</span>
                                                    </div>                                               
                                                    <input type="text" name="numero" style="text-align: left" class="form-control" id="id__txtNumero" onkeypress="return soloNumeros(event)"  maxlength="4"/><p style="color: red;">*</p>
                                                                                                      --%>
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
                                            <div class="col-sm-6">
                                                <div class="input-group mb-3">
                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text">Celular</span>
                                                    </div>
                                                    <input type="text" name="celular" style="text-align: left" class="form-control" id="id__txtCelular" maxlength="10" onkeypress="return soloNumeros(event)" onpaste="return false" placeholder="Ej: 3515123456" /><p style="color: red;">*</p>                                                  
                                                </div>
                                                <p class="formulario__error" id="p__txtCelular">Por favor, ingrese el Celular sin 0 y sin 15</p>
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
                                                    <input type="text" name="email2" class="form-control" id="id__txtEmail2" maxlength="100" placeholder="gmail.com" onkeyup="javascript:this.value=this.value.toUpperCase();" /><p style="color: red;">*</p>                                                  
                                                </div>                              
                                                <p class="formulario__error" id="p__txtEmail2">Por favor, ingrese un email valido</p>
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
                                <div class="card-header bg-info">
                                    <h4 class="modal-title text-white">Datos personales</h4>
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
                                                            <input type="text" name="dniE" style="text-align: left" class="formulario-input form-control" id="id__AtxtDocumento" maxlength="8" onkeypress="return soloNumeros(event)" onpaste="return false" /><p style="color: red;">*</p> 
                                                           
                                                        </div>
                                                        <p class="formulario__error" id="p__AtxtDocumento"> Por favor, ingrese el DNI sin puntos.</p>
                                                    </div>
                                                   
                                                </div>
                                            </div>
                                            <div class="col-sm">
                                                <div class="input-group mb-3">
                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text">Fecha de Nacimiento</span>
                                                    </div>
                                                  <%--  <div>--%>
                                                        <input type='text' name="fechaNacE" class="form-control datepicker date" id="id__AdtpFechaNacE"
                                                            placeholder="DD/MM/YYYY" data-provide="datepicker"
                                                            data-date-format="dd/mm/yyyy" /><p style="color: red;">*</p>                                                  
                                                </div>
                                                 <%--   <p class="formulario__error" id="p__AdtpFechaNac"> Por favor, ingrese la fecha de nacimiento</p>--%>
                                            </div>
                                        </div>       
                                    <div class="form-row">
                                            <div class="col">
                                                <div class="input-group mb-3">
                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text" id="">Nombre y Apellido</span>
                                                    </div>
                                                    <input type="text" name="nombreE" style="text-align: left" class="form-control" id="id__AtxtNombre" maxlength="150" onkeypress="return soloLetras(event)" onpaste="return false" onkeyup="javascript:this.value=this.value.toUpperCase();" />
                                                    <input type="text" name="apellidoE" style="text-align: left" class="form-control" id="id__AtxtApellido" maxlength="150" onkeypress="return soloLetras(event)" onpaste="return false" onkeyup="javascript:this.value=this.value.toUpperCase();" /><p style="color: red;">*</p>
                                                </div>
                                                <p class="formulario__error" id="p__AtxtNombre">Por favor, ingrese el/los nombre/s</p>
                                                <p class="formulario__error" id="p__AtxtApellido">Por favor, ingrese el/los apellido/s</p>
                                            </div>
                                        </div>                              
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                                <div class="col-md" id="crdDatosContactoE">
                                    <div class="card text-white bg-white">
                                        <div class="card-header text-white bg-info">
                                            <h4>Datos de Contacto</h4>
                                        </div>
                                        <div class="card-body">
                                           <div class="form-row">
                                                <div class="col">
                                                    <div class="input-group mb-3">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text">Dirección</span>
                                                        </div>
                                                        <input type="text" name="domicilioE" style="text-align: left" class="form-control" id="id__AtxtDomicilio" maxlength="160" onkeyup="javascript:this.value=this.value.toUpperCase();" /><p style="color: red;">*</p>
                                                    </div>
                                                     <p class="formulario__error" id="p__AtxtDomicilio">Por favor, ingrese el Domicilio</p>
                                                </div>
                                            </div>
                                            <div class="form-row">
                                                <div class="col">
                                                    <div class="input-group mb-3">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text">Barrio</span>
                                                        </div>
                                                        <input type="text" name="barrioE" style="text-align: left" class="form-control" id="id__AtxtBarrio" maxlength="100" onkeyup="javascript:this.value=this.value.toUpperCase();" /><p style="color: red;">*</p>
                                                    </div>
                                                    <p class="formulario__error" id="p__AtxtBarrio">Por favor, ingrese el Barrio</p>
                                                </div>
                                                <div class="col">
                                                    <div class="input-group mb-3">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text">Localidad</span>
                                                        </div>
                                                        <input type="text" name="localidadE" style="text-align: left" class="form-control" id="id__AtxtLocalidad" maxlength="120" onkeyup="javascript:this.value=this.value.toUpperCase();" /><p style="color: red;">*</p>

                                                    </div>
                                                    <p class="formulario__error" id="p__AtxtLocalidad">Por favor, ingrese la Localidad</p>
                                                </div>
                                            </div>
                                            <div class="form-row">
                                                <div class="col-sm-6">
                                                    <div class="input-group mb-3">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text">Celular</span>
                                                        </div>
                                                        <input type="text" name="celularE" style="text-align: left" class="form-control" id="id__AtxtCelular" maxlength="10" onkeypress="return soloNumeros(event)" onpaste="return false" placeholder="Ej: 3515123456" /><p style="color: red;">*</p>

                                                    </div>
                                                    <p class="formulario__error" id="p__AtxtCelular">Por favor, ingrese el Celular sin 0 y sin 15</p>
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
                                    </div>
                                </div>
                            </div>
                     <div class="modal-footer">
                        <button type="button" class="btn btn-primary btn-lg float-right" id="btnActualizar">Actualizar</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--End Modal Editar--%>


     <link href="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "Estilos/styleRegistrarProfesional.css"%>" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "ScriptsPantallas/Personal.js"%>"></script>
     <script type="text/javascript" src="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "ScriptsPantallas/Personal_validacion.js"%>"></script>


</asp:Content>
