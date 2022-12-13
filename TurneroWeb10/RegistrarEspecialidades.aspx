<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarEspecialidades.aspx.cs" Inherits="TurneroWeb10.RegistrarEspecialidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

  <section class="content-header">
        <h1 style="text-align: center">ESPECIALIDADES</h1>
    </section>

    <section class="content">   
        
         <div class="row">
            <button class="btn btn-success btn-lg float-right" type="button" id="btnRegistrarModal"> <i class="fa-solid fa-hospital-user"></i> | Registrar Especialidad</button>
        </div>
        <br />

        <!-- Lista centros -->
        <!-- Datatable Part -->
        <div class="row">
            <div class="box box-primary">
                <div class="box-header">
                    <h1 class="box-title">Listado de Especialidades</h1>
                </div>
                <div class="box-body table-responsive">
                    <div class="col-md-12">
                        <table id="tabla_Especialidades" style="width:100%" class="table table-striped table-hover table-bordered">
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
    <div class="modal fade" tabindex="-1" role="dialog" id ="modalRegistrar" >
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header bg-info text-white">
                    <h4 class="modal-title " id="lblRegistrar" >Registrar Especialidad</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>       
                </div>
                <div class="modal-body" id="formularioRegistrar">
                    <div class="col-md-12">
                        <div class="card text-white">
                            <div class="card-header bg-info">
                                <h4 class="modal-title text-white" >Completar datos</h4>
                            </div>
                            <div class="card-body">       
                                <div class="form-row">
                                    <div class="col-md-8">
                                           <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Nombre Especialidad</span>
                                    </div>
                                    <input type="text" name="nombre" style="text-align: left" class="form-control" id="id__txtNombre" maxlength="150" onkeypress="return soloLetras(event)" onpaste="return false" onkeyup="javascript:this.value=this.value.toUpperCase();" /><p style="color: red;">*</p>
                                </div>
                                 <p class="formulario__error" id="p__txtNombre">Por favor, ingrese la especialidad</p>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="col-md text-right">
                                        <button class="btn btn-success btn-lg float-right" type="button" id="btnRegistrar">Registrar</button>      
                                    </div>
                                </div>                                             
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
 <%--Final Modal registrar--%>


        <%--Modal Registrar--%>
    <div class="modal fade" tabindex="-1" role="dialog" id ="modalEditar" >
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header bg-info text-white">
                    <h4 class="modal-title ">Actualizar Especialidad</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>       
                </div>
                <div class="modal-body" id="formularioEditar">
                    <div class="col-md-12">
                        <div class="card text-white">
                            <div class="card-header bg-info">
                                <h4 class="modal-title text-white" >Modificar datos</h4>
                            </div>
                            <div class="card-body">       
                                <div class="form-row">
                                    <div class="col-md-8">
                                           <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Nombre Especialidad</span>
                                    </div>
                                    <input type="text" name="nameE" style="text-align: left" class="form-control" id="id__AtxtNombre" maxlength="150" onkeypress="return soloLetras(event)" onpaste="return false" onkeyup="javascript:this.value=this.value.toUpperCase();" /><p style="color: red;">*</p>
                                </div>
                                 <p class="formulario__error" id="p__AtxtNombre">Por favor, ingrese la especialidad</p>
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
 <%--Final Modal registrar--%>



     <%--MODAL TURNO--%>
    <div class="modal fade" tabindex="-1" role="dialog" id="modalTurnos">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header bg-info text-white">
                    <h4 class="modal-title " id="lblTituloEspecialidad">Eliminar Especialidad</h4>
                    <button type="button" id="btnClose" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body">
                    <%--<div class="row">--%>
                    <div class="box box-danger">
                        <div class="box-header">
                            <h1 class="box-title text-red">Al eliminar la Especialidad, se cancelaran los siguientes turnos</h1>
                            <h6 class="box-title text-black">Podes reprogramarlos, antes de eliminar la Especialidad, desde Mesa de Entrada > Agenda</h6>
                        </div>
                        <div class="box-body table-responsive">
                            <div class="col-md-12">
                                <table id="tabla_Especialidad" style="width: 100%" class="table table-striped table-hover table-bordered">
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
<script type="text/javascript" src="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "ScriptsPantallas/Especialidades.js"%>"></script>
<script type="text/javascript" src="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "ScriptsPantallas/Especialidades_validacion.js"%>"></script>

</asp:Content>
   
