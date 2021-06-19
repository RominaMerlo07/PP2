<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarProfesional.aspx.cs" Inherits="TurneroWeb10.RegistrarProfesional" ClientIDMode="Static" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%--    <style>
        .multiselect{
            bottom: 5px;
        }
    </style>--%>
    <section class="content-header">
        <%-- <button class="btn btn-info btn-sm float-right" type="button" id="Listar">Listar Profesionales</button>--%>
        <h1 style="text-align: center">REGISTRO DE PROFESIONALES</h1>
    </section>
    <section class="content">
            <div class="row">
                <div class="col-md-6" id="crdDatosPersonales">
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
                                                <input type="text" style="text-align: left" class="form-control" id="txtDocumento" maxlength="8" onkeypress="return soloNumeros(event)" onpaste="return false"/>
                                            </div>
                                        </div>
                                        <div class="col-sm">
                                            <div class="input-group mb-3">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">Matricula</span>
                                                </div>
                                                <input type="text" style="text-align: left" class="form-control" id="txtMatricula" maxlength="10" onkeypress="return soloNumeros(event)" onpaste="return false"/>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="col-sm multiselect">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">Especialidad: </span>
                                        </div>
                                        <select multiple class="form-control select2" id="ddlEspecialidad">
                                            <option value="0" disabled="disabled" selected="" hidden="hidden">--Seleccione--</option>
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="col">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text" id="">Nombre y Apellido</span>
                                        </div>
                                        <input type="text" style="text-align: left" class="form-control" id="txtNombre" maxlength="150" onkeypress="return soloLetras(event)" onpaste="return false" onkeyup="javascript:this.value=this.value.toUpperCase();"/>
                                        <input type="text" style="text-align: left" class="form-control" id="txtApellido" maxlength="150" onkeypress="return soloLetras(event)" onpaste="return false" onkeyup="javascript:this.value=this.value.toUpperCase();" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="col">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">Fecha de Nacimiento</span>
                                        </div>
                                        <div>
                                            <input type='text' class="form-control datepicker date" id="dtpFechaNac"
                                                placeholder="DD/MM/YYYY" data-provide="datepicker"
                                                data-date-format="dd/mm/yyyy" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6" id="crdDatosContacto">
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
                                        <input type="text" style="text-align: left" class="form-control" id="txtCalle" maxlength="120" onkeyup="javascript:this.value=this.value.toUpperCase();" />
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">Numero</span>
                                        </div>
                                        <input type="text" style="text-align: left" class="form-control" id="txtNumero" maxlength="4"/>
                                    </div>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="col">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">Barrio</span>
                                        </div>
                                        <input type="text" style="text-align: left" class="form-control" id="txtBarrio" maxlength="100" onkeyup="javascript:this.value=this.value.toUpperCase();" />
                                    </div>
                                </div>
                                <div class="col">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">Localidad</span>
                                        </div>
                                        <input type="text" style="text-align: left" class="form-control" id="txtLocalidad" maxlength="120" onkeyup="javascript:this.value=this.value.toUpperCase();" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="col-sm-6">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">Celular</span>
                                        </div>
                                        <input type="text" style="text-align: left" class="form-control" id="txtCelular" maxlength="10" onkeypress="return soloNumeros(event)" onpaste="return false" placeholder="Ej: 3515123456" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="col">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">Email: </span>
                                        </div>
                                        <input type="text" class="form-control" id="txtEmail1" maxlength="150" onkeyup="javascript:this.value=this.value.toUpperCase();" />
                                        <div class="input-group-append">
                                            <span class="input-group-text">@</span>
                                        </div>
                                        <input type="text" class="form-control" id="txtEmail2" maxlength="100" placeholder="gmail.com" onkeyup="javascript:this.value=this.value.toUpperCase();" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        <%--<button class="btn btn-secondary btn-lg float-right" type="button" id="btnCancelar">Cancelar</button>--%>
        <button class="btn btn-success btn-lg float-right" type="button" id="btnRegistrar">Registrar</button>
        <br />
        <br />
        <br />
        <br />
        <br />

        <!-- Datatable Part -->
        <div class="row">
            <div class="box box-primary">
                <div class="box-header">
                    <h3 class="box-title">Lista de Profesionales</h3>
                </div>
                <div class="box-body table-responsive">
                    <div class="col-md-12">
                        <table id="tabla_profesionales" class="table table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th>N°</th>
                                    <th>Profesional</th>
                                    <th>DNI</th>
                                    <th>Matricula</th>
                                    <th>Contacto</th>
                                    <th>Email</th>
                                    <th>Domicilio</th>
                                    <th>Especialidad</th>
                                    <th>Acciones</th>
                                </tr>
                            </thead>
                            <tbody id="tbl_body_table">
                                <!-- DATA POR MEDIO DE AJAX-->
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <!-- End Datatable -->
    </section>


    <div class="modal fade" id="modalEditar" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header text-white bg-info">
                    <h4 class="modal-title" id="myModalLabel">Actualizar datos del Profesional</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body">
                    <div>
                        <h4 class="modal-title" id="DatosPersonales">Datos Personales</h4>
                    </div>
                    <br />
                    <div class="form-row">
                        <div class="col-sm">
                            <div class="row">
                                <div class="col-sm">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">DNI</span>
                                        </div>
                                        <input type="text" style="text-align: left" class="form-control" id="txtDocumentoA" maxlength="8" onkeypress="return soloNumeros(event)" onpaste="return false"/>
                                    </div>
                                </div>
                                <div class="col-sm">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">Matricula</span>
                                        </div>
                                        <input type="text" style="text-align: left" class="form-control" id="txtMatriculaA" maxlength="10" onkeypress="return soloNumeros(event)" onpaste="return false"/>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="col">
                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <span class="input-group-text" id="">Nombre y Apellido</span>
                                </div>
                                <input type="text" style="text-align: left" class="form-control" id="txtNombreA"  maxlength="150" onkeypress="return soloLetras(event)" onpaste="return false" onkeyup="javascript:this.value=this.value.toUpperCase();"/>
                                <input type="text" style="text-align: left" class="form-control" id="txtApellidoA"  maxlength="150" onkeypress="return soloLetras(event)" onpaste="return false" onkeyup="javascript:this.value=this.value.toUpperCase();"/>
                            </div>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="col">
                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">Fecha de Nacimiento</span>
                                </div>
                                <div>
                                    <input type='text' class="form-control datepicker date" id="dtpFechaNacA"
                                        placeholder="DD/MM/YYYY" data-provide="datepicker"
                                        data-date-format="dd/mm/yyyy" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div>
                        <h4 class="modal-title" id="DatosContacto">Datos de Contacto</h4>
                    </div>
                    <br />
                    <div class="form-row">
                        <div class="col">
                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">Direccion</span>
                                </div>
                                <input type="text" style="text-align: left" class="form-control" id="txtDomicilio"  maxlength="160" onkeyup="javascript:this.value=this.value.toUpperCase();"/>
                            </div>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="col">
                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">Barrio</span>
                                </div>
                                <input type="text" style="text-align: left" class="form-control" id="txtBarrioA" maxlength="100" onkeyup="javascript:this.value=this.value.toUpperCase();"/>
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
                                <input type="text" style="text-align: left" class="form-control" id="txtCelularA" maxlength="10" onkeypress="return soloNumeros(event)" onpaste="return false"/>
                            </div>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="col">
                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">Email: </span>
                                </div>
                                <input type="text" class="form-control" id="txtEmail1A" maxlength="150" onkeyup="javascript:this.value=this.value.toUpperCase();"/>
                                <div class="input-group-append">
                                    <span class="input-group-text">@</span>
                                </div>
                                <input type="text" class="form-control" id="txtEmail2A" placeholder="gmail.com" maxlength="100" onkeyup="javascript:this.value=this.value.toUpperCase();"/>
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


    <script type="text/javascript" src="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "Scripts/RegistrarProfesional.js"%>"></script>

</asp:Content>
