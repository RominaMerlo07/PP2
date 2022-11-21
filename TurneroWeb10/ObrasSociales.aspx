<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ObrasSociales.aspx.cs" Inherits="TurneroWeb10.ObrasSociales" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content-header">
        <h1 style="text-align: center">OBRAS SOCIALES</h1>
    </section>
    <div class="content">
        <div class="row">
            <button class="btn btn-success btn-lg float-right" type="button" id="btnRegistrarModal">Registrar Obra Social</button>
        </div>
        <br />
        <div class="row">
            <div class="box box-primary">
                <div class="box-header">
                    <h4 class="box-title">Listado de Obras Sociales</h4>
                </div>
                <div class="box-body table-responsive">
                    <div id="tListaObrasSociales">
                        <table style="width: 100%" class="table table-bordered table-hover" id="tablaObrasSociales">
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <%--MODAL REGISTRAR OBRA SOCIAL--%>
    <div class="modal fade" tabindex="-1" role="dialog" id ="modalRegistrarObraS" >
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header bg-info text-white">
                    <h4 class="modal-title " id="lblRegistrar" >Registrar Obra Social</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>       
                </div>
                <div class="modal-body" id="formularioRegistrar">
                    <div class="col-md-12" id="">
                        <div class="card text-white ">
                            <div class="card-header bg-info">
                                <h4 class="modal-title text-white">Completar datos</h4>
                            </div>
                            <div class="card-body">       
                                <div class="form-row">
                                    <div class="col-md-8">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">Obra Social: </span>
                                            </div>
                                            <input type="text" name="nombre" style="text-align: left" maxlength="150" onkeypress="return soloLetras(event)" onpaste="return false" class="form-control" id="id__txtObraSocial" onkeyup="javascript:this.value=this.value.toUpperCase();"/><p style="color: red;">*</p>
                                        </div>
                                        <p class="formulario__error" id="p__txtObraSocial">Por favor, ingrese una obra social</p>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="col-md text-right">
                                        <button class="btn btn-success btn-lg float-right" type="button" id="btnRegistrarObraS">Registrar</button>      
                                    </div>
                                </div>                                             
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%-- FIN MODAL REGISTRAR OBRA SOCIAL--%>

    <%--MODAL EDITAR OBRA SOCIAL--%>
    <div class="modal fade" tabindex="-1" role="dialog" id ="modalEditar" >
          <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header bg-info text-white">
                    <h4 class="modal-title " >Actualizar Obra Social</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>       
                </div>
                <div class="modal-body" id="formularioEditar">
                    <div class="col-md-12" id="">
                        <div class="card text-white ">
                            <div class="card-header bg-info">
                                <h4 class="modal-title text-white">Modificar datos</h4>
                            </div>
                            <div class="card-body">       
                                <div class="form-row">
                                    <div class="col-md-8">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">Obra Social: </span>
                                            </div>
                                            <input type="text" name="nombreE" style="text-align: left" maxlength="150" onkeypress="return soloLetras(event)" onpaste="return false" class="form-control" id="id__AtxtObraSocial" onkeyup="javascript:this.value=this.value.toUpperCase();"/><p style="color: red;">*</p>
                                        </div>
                                        <p class="formulario__error" id="p__AtxtObraSocial">Por favor, ingrese una obra social</p>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="col-md text-right">
                                        <button class="btn btn-primary btn-lg float-right" type="button" id="btnActualizar">Actualizar</button>      
                                    </div>
                                </div>                                             
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%-- FIN MODAL EDITAR OBRA SOCIAL--%>



     <%--MODAL PLANES--%>
    <div class="modal fade" tabindex="-1" role="dialog" id ="modalEditarObraS" >
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
              <div class="modal-header bg-info text-white">
                <h4 class="modal-title " id="lblObraSocial" ></h4>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>       
              </div>
                <div class="modal-body" id="formularioModal">
                    <div class="col-md-12">                       
                        <br />
                        <div class="card text-white">
                            <div class="card-header bg-info">
                                <h4 class="modal-title text-white">Agregar Plan</h4>
                            </div>
                            <div class="card-body">       
                                <div class="form-row">
                                    <div class="col-md-6">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">Plan: </span>
                                            </div>
                                            <input type="text" name="nombreP" class="form-control" id="id__txtPlan" onkeyup="javascript:this.value=this.value.toUpperCase();"/>
                                        </div>
                                        <p class="formulario__error" id="p__txtPlan">Por favor, ingrese un plan</p>
                                    </div>                              
                                    <div class="col-md-6 text-right">
                                        <button class="btn btn-success" type="button" id="btnGuardarPlan">Registrar Plan</button>      
                                    </div>
                                </div>                                             
                            </div>
                        </div>
                        <br/>
                        <div id="tListarTurnos">
                            <table style="width:100%" class="table table-striped table-bordered" id="tablaPlanesOS">
                            </table>
                        </div> 
                    </div>
                </div>
                <br />
            </div>
        </div>
    </div>
    <%-- FIN MODAL PLANES--%>


      <%--MODAL EDITAR PLANES--%>
    <div class="modal fade" tabindex="-1" role="dialog" id ="modalEditarPlan" >
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
              <div class="modal-header bg-info text-white">
                <h4 class="modal-title "> Actualizar Plan</h4>
                <button type="button" id="btnCerrar" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>       
              </div>
                <div class="modal-body" id="formularioModalPlan">
                                    
                        <br />
                        <div class="card text-white">
                            <div class="card-header bg-info">
                                <h4 class="modal-title text-white">Modificar datos</h4>
                            </div>
                            <div class="card-body">       
                                <div class="form-row">
                                    <div class="col-md-6">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">Plan: </span>
                                            </div>
                                            <input type="text" name="nombrePE" class="form-control" id="id__AtxtPlan" onkeyup="javascript:this.value=this.value.toUpperCase();"/>
                                        </div>
                                        <p class="formulario__error" id="p__AtxtPlan">Por favor, ingrese un plan</p>
                                    </div>                              
                                    <div class="col-md-6 text-right">
                                        <button class="btn btn-primary" type="button" id="btnActualizarPlan">Actualizar</button>      
                                    </div>
                                </div>                                             
                            </div>
                        </div>
                        <br />                       
                    
                </div>
                <br />
            </div>
        </div>
    </div>
    <%-- FIN MODAL PLANES--%>


    <link href="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "Estilos/styleRegistrarProfesional.css"%>" rel="stylesheet" type="text/css"/>

    <script type="text/javascript" src="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "ScriptsPantallas/RegistrarOS.js"%>"></script>
    <script type="text/javascript" src="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "ScriptsPantallas/RegistrarOS_validacion.js"%>"></script>
</asp:Content>