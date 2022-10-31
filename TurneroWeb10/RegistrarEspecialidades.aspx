<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarEspecialidades.aspx.cs" Inherits="TurneroWeb10.RegistrarEspecialidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     <section class="content-header">
        <h1>ESPECIALIDADES</h1>
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
                        <table id="tabla_Especialidades" style="width:100%" class="table table-bordered table-hover">
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
                <div class="modal-header text-white bg-success">
                    <h4 class="modal-title" id="lblRegistrar">Registrar Especialidad</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body" id="formularioRegistrar">
                    <div class="card-body">
                        <div class="col-sm">
                            <div class="row">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Nombre Especialidad</span>
                                    </div>
                                    <%--<input type="text" name="nombre" style="text-align: left" class="formulario-input form-control" id="id__txtNombre" />--%>
                                    <input type="text" name="calle" id="id__txtNombre" style="text-align: left" class="form-control" maxlength="120" onkeyup="javascript:this.value=this.value.toUpperCase();" />
                                </div>
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
                    <h4 class="modal-title" id="lblEditar">Actualizar Especialidad</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body" id="formularioEditar">
                    <div class="card-body">
                        <div class="col-sm">
                            <div class="row">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Nombre Especialidad</span>
                                    </div>
                                    <%--<input type="text" name="nombre" style="text-align: left" class="formulario-input form-control" id="id__txtNombre" />--%>
                                    <input type="text" name="calle" id="id__txtNombreE" style="text-align: left" class="form-control" maxlength="120" onkeyup="javascript:this.value=this.value.toUpperCase();" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <button class="btn btn-info btn-lg float-right" type="button" id="btnActualizar">Actualizar</button>
                </div>
            </div>
        </div>
    </div>
    <%--Final Modal Editar--%>


     <%--MODAL TURNO--%>
    <div class="modal fade" tabindex="-1" role="dialog" id="modalTurnos">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header bg-danger text-white">
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
                                <table id="tabla_Especialidad" style="width: 100%" class="table table-bordered table-hover">
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


    
<script type="text/javascript" src="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "ScriptsPantallas/Especialidades.js"%>"></script>

</asp:Content>
   
