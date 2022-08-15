<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarPaciente.aspx.cs" Inherits="TurneroWeb10.RegistrarPaciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%--<p>"ABM REGISTRAR PACIENTE"</p>--%>

    <section class="content-header">      
        <h1 style="text-align: left">PACIENTES</h1>
    </section>
    <section class="content">
         <div class="row">
            <button class="btn btn-success btn-lg float-right" type="button" id="btnRegistrarModal"> <i class="fas fa-user-plus"></i>  | Registrar Paciente</button>
        </div>
        <br />

          <!-- Lista pacientes -->
        <!-- Datatable Part -->
        <div class="row">
            <div class="box box-primary">
                <div class="box-header">
                    <h1 class="box-title">Listado de Pacientes</h1>
                </div>
                <div class="box-body table-responsive">
                    <div class="col-md-12">
                        <table style="width:100%" id="tabla_pacientes" class="table table-bordered table-hover table-striped">
                            <tbody id="tbl_body_table">
                                <!-- DATA POR MEDIO DE AJAX-->
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <!-- End Datatable -->
        <!-- End Lista pacientes -->                                   
       
    </section>


    <%--Modal Registrar--%>
    <div class="modal fade" tabindex="-1" role="dialog" id="modalRegistrar" aria-labelledby="myModalLabel">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header bg-info text-white">
                    <h4 class="modal-title " id="lblTituloTurno">Registrar Paciente</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body" id="formularioRegistrar">
                    <div class="row">
                        <div class="col-md" id="crdPaciente2">
                            <div class="card text-white">
                                <div class="card-header bg-info">
                                    <h4 class="modal-title text-white ">Datos Personales</h4>
                                </div>
                                <div class="card-body">
                                    <div class="form-row">
                                        <div class="col-sm">
                                            <div class="input-group mb-3">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">DNI: </span>
                                                </div>
                                                <input type="text" name="dni" style="text-align: left" class="formulario-input form-control" id="id__txtDocumento" maxlength="8" onkeypress="return soloNumeros(event)" onpaste="return false" />
                                                <%-- <i class="formulario__validacion fas fa-times-circle" id="icon__txtDocumento"></i>--%>
                                            </div>
                                            <%-- <p class="formulario__error" id="p__txtDocumento"> Por favor, ingrese el DNI sin puntos.</p>--%>
                                        </div>
                                        <div class="col ">
                                            <div class="input-group mb-3">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">Celular:</span>
                                                </div>
                                                <input type="text" style="text-align: left" class="form-control" id="id__txtCelular" onkeypress="return soloNumeros(event)" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col">
                                            <div class="input-group mb-3">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text" id="">Nombre y Apellido:</span>
                                                </div>
                                                <input type="text" style="text-align: left" class="form-control" id="id__txtNombre" onkeypress="return soloLetras(event)" onkeyup="javascript:this.value=this.value.toUpperCase();" />
                                                <input type="text" style="text-align: left" class="form-control" id="id__txtApeliido" onkeypress="return soloLetras(event)" onkeyup="javascript:this.value=this.value.toUpperCase();" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col ">
                                            <div class="input-group mb-3">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">Email: </span>
                                                </div>
                                                <input type="text" class="form-control" id="id__txtEmail1" />
                                                <div class="input-group-append">
                                                    <span class="input-group-text">@</span>
                                                </div>
                                                <input type="text" class="form-control" id="id__txtEmail2" placeholder="gmail.com" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                </div>
                                <div class="row">
                                    <div class="col-md" id="crdDatosContacto">
                                        <div class="card text-white bg-light">
                                            <div class="card-header text-white bg-info">
                                                <h4>Datos Obra Social</h4>
                                            </div>
                                            <div class="card-body">
                                                <div class="form-row">
                                                    <div class="col">
                                                        <div class="form-row">
                                                            <div class="col ">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text">Obra Social: </span>
                                                                    </div>
                                                                    <select class="custom-select form-control" id="ddlObraSocial">
                                                                    </select>
                                                                </div>
                                                            </div>
                                                            <div class="col ">
                                                                <div class="input-group mb-3" id="frmPlanObra">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text">Plan: </span>
                                                                    </div>
                                                                    <select class="custom-select form-control" id="ddlPlanObra">
                                                                    </select>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="form-row">
                                                            <div class="col ">
                                                                <div class="input-group mb-3">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text">Nro. Afiliado:</span>
                                                                    </div>
                                                                    <input type="text" style="text-align: left" class="form-control" id="id__txtNroAfiliado" onkeypress="return soloNumeros(event)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            
                         </div>
                            <div class="modal-footer">
                                <div class="row float-right">
                                    <button class="btn btn-success btn-lg " type="button" id="btnRegistrar">Registrar</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>   
    <%--final Modal registrar--%>


    <%--Modal Editar--%>
    <div class="modal fade" tabindex="-1" role="dialog" id="modalEditar" aria-labelledby="myModalLabel">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header bg-info text-white">
                    <h4 class="modal-title " id="">Actualizar datos del Paciente</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body" id="formularioEditar">
                    <div class="row">
                        <div class="col-md" id="crdPacienteE">
                            <div class="card text-white bg-white">
                                <div class="card-header bg-light">
                                    <h4 class="modal-title text-black">Datos Personales</h4>
                                </div>
                                <div class="card-body">
                                    <div class="form-row">
                                        <div class="col-sm">
                                            <div class="input-group mb-3">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">DNI: </span>
                                                </div>
                                                <input type="text" name="dni" style="text-align: left" class="formulario-input form-control" id="id__txtDocumentoE" maxlength="8" onkeypress="return soloNumeros(event)" onpaste="return false" />
                                                <%-- <i class="formulario__validacion fas fa-times-circle" id="icon__txtDocumento"></i>--%>
                                            </div>
                                            <%-- <p class="formulario__error" id="p__txtDocumento"> Por favor, ingrese el DNI sin puntos.</p>--%>
                                        </div>
                                        <div class="col ">
                                            <div class="input-group mb-3">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">Celular:</span>
                                                </div>
                                                <input type="text" style="text-align: left" class="form-control" id="id__txtCelularE" onkeypress="return soloNumeros(event)" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col">
                                            <div class="input-group mb-3">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text" id="">Nombre y Apellido:</span>
                                                </div>
                                                <input type="text" style="text-align: left" class="form-control" id="id__txtNombreE" onkeypress="return soloLetras(event)" onkeyup="javascript:this.value=this.value.toUpperCase();" />
                                                <input type="text" style="text-align: left" class="form-control" id="id__txtApeliidoE" onkeypress="return soloLetras(event)" onkeyup="javascript:this.value=this.value.toUpperCase();" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col ">
                                            <div class="input-group mb-3">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">Email: </span>
                                                </div>
                                                <input type="text" class="form-control" id="id__txtEmail1E" />
                                                <div class="input-group-append">
                                                    <span class="input-group-text">@</span>
                                                </div>
                                                <input type="text" class="form-control" id="id__txtEmail2E" placeholder="gmail.com" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <div class="row float-right">
                            <button class="btn btn-success btn-lg " type="button" id="btnEditar">Actualizar</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--final Modal Editar--%>

    <%--Modal ObrasSociales--%>
    <div class="modal fade" id="modalObrasSociales" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header text-white bg-info">
                    <h4 class="modal-title" id="lblObraSocial">Obras Sociales por Paciente</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body">
                    <%--  <div class="row">--%>
                    <div class="col-md-12" id="crdDatosObraSocial">
                        <div class="card text-white">
                            <div class="card-header ">
                                <h4 class="modal-title text-dark" id="infoPaciente">Paciente - Documento</h4>
                            </div>
                            <div class="card-body">
                                <!-- Datatable Part -->
                                <div class="row">
                                    <div class="col-md" id="agregar">
                                        <button class="btn btn-success" type="button" id="btnRegistrarOS"><i class="fas fa-plus-square"></i>| Agregar Obra Social</button>
                                        <br />
                                        <br />
                                        <div class="card-body bg-light border-info" id="agregarObraSocial">
                                            <div class="form-row">
                                                <div class="col">
                                                    <div class="form-row">
                                                        <div class="col ">
                                                            <div class="input-group mb-3">
                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text">Obra Social: </span>
                                                                </div>
                                                                <select class="custom-select form-control" id="ddlObraSocialE">
                                                                </select>
                                                            </div>
                                                        </div>
                                                        <div class="col ">
                                                            <div class="input-group mb-3" id="frmPlanObraE">
                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text">Plan: </span>
                                                                </div>
                                                                <select class="custom-select form-control" id="ddlPlanObraE">
                                                                </select>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="form-row">
                                                        <div class="col ">
                                                            <div class="input-group mb-3">
                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text">Nro. Afiliado:</span>
                                                                </div>
                                                                <input type="text" style="text-align: left" class="form-control" id="id__txtNroAfiliadoE" onkeypress="return soloNumeros(event)" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-10 col-xs-6">
                                                    <button class="btn btn-success float-right" type="button" id="btnAgregar">Agregar</button>
                                                </div>
                                                <div class="col-md-2 col-xs-6">
                                                    <button class="btn btn-secondary float-right" type="button" id="btnCancelar">Cancelar</button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>                                    
                                    <div class="card-body bg-light border-info" id="editarObraSocial">
                                        <div class="card-header bg-info">
                                            <h6 class="modal-title text-white" id="editar">Actualizar obra social</h6>
                                        </div>
                                        <br />
                                        <div class="form-row">
                                            <div class="col">
                                                <div class="form-row">
                                                    <div class="col ">
                                                        <div class="input-group mb-3">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text">Obra Social: </span>
                                                            </div>
                                                            <select class="custom-select form-control" id="ddlObraSocialOS">
                                                            </select>
                                                        </div>
                                                    </div>
                                                    <div class="col ">
                                                        <div class="input-group mb-3" id="frmPlanObraOS">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text">Plan: </span>
                                                            </div>
                                                            <select class="custom-select form-control" id="ddlPlanObraOS">
                                                            </select>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-row">
                                                    <div class="col ">
                                                        <div class="input-group mb-3">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text">Nro. Afiliado:</span>
                                                            </div>
                                                            <input type="text" style="text-align: left" class="form-control" id="id__txtNroAfiliadoOS" onkeypress="return soloNumeros(event)" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-10 col-xs-6">
                                                <button class="btn btn-success float-right" type="button" id="btnActualizarOS">Actualizar</button>
                                            </div>
                                            <div class="col-md-2 col-xs-6">
                                                <button class="btn btn-secondary float-right" type="button" id="btnCancelarOS">Cancelar</button>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="box-body table-responsive text-dark">
                                        <div class="col-md-12 ">
                                            <table style="width: 100%" id="tabla_obrasSociales" class="table table-bordered table-hover">
                                                <tbody id="tbl_body_table_E">
                                                    <!-- DATA POR MEDIO DE AJAX-->
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>                                                                  
                             
                                </div>
                            </div>
                        </div>
                        <!-- End Datatable -->
                    </div>
                </div>
            </div>
            <%-- </div> --%>
        </div>
    </div>
    <%--End Modal ObrasSociales--%>



    <script type="text/javascript" src="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "ScriptsPantallas/RegistrarPaciente.js"%>"></script>

</asp:Content>
