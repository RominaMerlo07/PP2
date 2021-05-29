<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DisponibilidadHoraria.aspx.cs" Inherits="TurneroWeb10.DisponibilidadHoraria" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .datepicker.date {
            width: 100%;
        }
    </style>
    <section class="content-header">
        <h1 style="text-align: left">DISPONIBILIDAD HORARIA</h1>
    </section>
    <section class="content">
        <div class="row">
            <div class="col-md-6" id="crdDatosContacto">
                <div class="card text-white bg-light">
                    <div class="card-header bg-info">
                        <h4>Profesional</h4>
                    </div>
                    <div class="card-body">
                        <div class="form-row">
                            <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Profesional: </span>
                                    </div>
                                    <select class="custom-select form-control" id="ddlProfesional">
                                        <option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>
                                    </select>
                                </div>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Sucursal: </span>
                                    </div>
                                    <select class="custom-select form-control" id="ddlSucursal">
                                        <option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>
                                    </select>
                                </div>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Especialidad: </span>
                                    </div>
                                    <select class="custom-select form-control" id="ddlEspecialidad">
                                        <option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>
                                    </select>
                                </div>
                            </div>
                        </div>                            
<%--                        <div class="form-row">
                            <div class="col">
                                <div class="input-group mb-3">
                                   <button type="button" class="btn btn-outline-primary">Agregar Especialidad</button> 
                                </div>
                            </div>
                        </div> --%>
                         <div class="form-row">
                            <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Desde: </span>
                                    </div>
                                    <div>
                                        <input type='text' class="form-control datepicker date" id="dtpFechaDesde"
                                            placeholder="DD/MM/YYYY" data-provide="datepicker"
                                            data-date-format="dd/mm/yyyy" />
                                    </div>
                                </div>
                            </div>
                            <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Hasta: </span>
                                    </div>
                                    <div>
                                        <input type='text' class="form-control datepicker date" id="dtpFechaHasta"
                                            placeholder="DD/MM/YYYY" data-provide="datepicker"
                                            data-date-format="dd/mm/yyyy" />
                                    </div>
                                </div>
                            </div>                           
                        </div>
                        <div class="form-row">
                            <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Hora Desde: </span>
                                    </div>
                                    <select class="btn btn-white form-control" id="ddlHoraDesde">
                                        <option value="8">8</option>
                                        <option value="9">9</option>
                                        <option value="10">10</option>
                                        <option value="11">11</option>
                                        <option value="12">12</option>
                                        <option value="13">13</option>
                                        <option value="14">14</option>
                                        <option value="15">15</option>
                                        <option value="16">16</option>
                                        <option value="17">17</option>
                                        <option value="18">18</option>
                                        <option value="19">19</option>
                                        <option value="20">20</option>
                                    </select>
                                    <div class="input-group-append">
                                        <span class="input-group-text">:</span>
                                    </div>
                                    <select class="btn btn-white form-control" id="ddlMinDesde">
                                        <option value="00">00</option>
                                        <option value="15">15</option>
                                        <option value="30">30</option>
                                        <option value="45">45</option>
                                    </select>
                                </div>
                            </div>
                            <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Hora Hasta: </span>
                                    </div>
                                    <select class="btn btn-white form-control" id="ddlHoraHasta">
                                        <option value="8">8</option>
                                        <option value="9">9</option>
                                        <option value="10">10</option>
                                        <option value="11">11</option>
                                        <option value="12">12</option>
                                        <option value="13">13</option>
                                        <option value="14">14</option>
                                        <option value="15">15</option>
                                        <option value="16">16</option>
                                        <option value="17">17</option>
                                        <option value="18">18</option>
                                        <option value="19">19</option>
                                        <option value="20">20</option>
                                    </select>
                                    <div class="input-group-append">
                                        <span class="input-group-text">:</span>
                                    </div>
                                    <select class="btn btn-white form-control" id="ddlMinHasta">
                                        <option value="00">00</option>
                                        <option value="15">15</option>
                                        <option value="30">30</option>
                                        <option value="45">45</option>
                                    </select>
                                </div>
                            </div>
                        </div>                        
                    </div>
                </div>
                <br />
                <button class="btn btn-success btn-lg float-right" type="button" id="btnRegistrar">Registrar</button>
            </div>
            <br/>      
            <div class="card" style="width: 40rem;">
                <div class="card-body">
                    <div id='calendar'></div>
                </div>
            </div>
        </div>
    </section>
    <script type="text/javascript">

        var profesional;
        var sucursal;
        var especialidad;
        var fechaDesde;
        var fechaHasta;
        var horaDesde;
        var minDesde;
        var horaHasta;
        var minHasta;


        $(document).ready(function () {

            $("#ddlEspecialidad").prop("disabled", true);
            $("#ddlSucursal").prop("disabled", true);

            cargarComboProfesional('#ddlProfesional');
            cargarComboCentros('#ddlSucursal');

            $("#ddlProfesional").bind("change", function () {

                if ($("#ddlProfesional").val() != 0) {

                    $("#ddlSucursal").prop("disabled", false);

                    if ($("#ddlSucursal").val() != null) {
                        var idCentro = $('#ddlSucursal').val();
                        var idProfesional = $('#ddlProfesional').val();
                        cargarEspecialidades(idCentro, idProfesional, "#ddlEspecialidad");
                        $("#ddlEspecialidad").prop("disabled", false);

                    }
                    
                }

            });

            $("#ddlSucursal").bind("change", function () {

                var idCentro = $('#ddlSucursal').val();
                var idProfesional = $('#ddlProfesional').val();
                cargarEspecialidades(idCentro, idProfesional, "#ddlEspecialidad");
                $("#ddlEspecialidad").prop("disabled", false);

            });

            $('#btnRegistrar').click(function () {

                profesional = $('#ddlProfesional').val()
                sucursal = $('#ddlSucursal').val();
                especialidad = $('#ddlEspecialidad').val();
                fechaDesde = $('#dtpFechaDesde').val();
                fechaHasta = $('#dtpFechaHasta').val();
                horaDesde = $('#ddlHoraDesde').val();
                minDesde = $('#ddlMinDesde').val();
                horaHasta = $('#ddlHoraHasta').val();
                minHasta = $('#ddlMinHasta').val();

                var validacion = validarDatos();

                if (validacion === true) {



                    var disponibilidad = {
                        p_profesional: profesional,
                        p_sucursal: sucursal, 
                        p_especialidad: especialidad,
                        p_fechaDesde: fechaDesde, 
                        p_fechaHasta: fechaHasta, 
                        p_horaDesde: horaDesde, 
                        p_minDesde: minDesde, 
                        p_horaHasta: horaHasta, 
                        p_minHasta: minHasta
                    }

                    registrarDisponibilidad(disponibilidad);                  
                }
            });
        });

        function registrarDisponibilidad(diponibilidad) {

            $.ajax({
                url: "DisponibilidadHoraria.aspx/registrarDisponibilidad",
                data: JSON.stringify(diponibilidad),
                type: "post",
                contentType: "application/json",
                async: false,
                success: function (data) {

                    if (data.d != 'OK') {                       
                        alert('Error al registrar Disponibilidad Horaria.');
                    } else {                        
                        alert('Disponibilidad Horaria registradad con éxito!');
                    }
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    alert(data.error);
                }

            });
        }

        function cargarEspecialidades(idCentro, idProfesional, ddl) {
            $.ajax({
                url: "DisponibilidadHoraria.aspx/cargarEspecialidades",
                data: "{idCentro: '" + idCentro + "', idProfesional: '" + idProfesional + "'}",
                type: "post",
                contentType: "application/json",
                async: false,
                success: function (data) {

                    if (data.d.length > 0) {
                        $(ddl).empty();
                        $(ddl).append('<option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>');
                        
                        for (i = 0; i < data.d.length; i++) {

                            $(ddl).append($("<option></option>").val(data.d[i].IdEspecialidad).html(data.d[i].Descripcion));
                        }
                        $(ddl).prop("disabled", false);
                    }
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    $(ddl).prop("disabled", true);
                    alert(data.error);
                }
            });
        }

        function cargarComboProfesional(ddl) {
            
            $.ajax({
                url: "DisponibilidadHoraria.aspx/cargarProfesionales",
                type: "post",
                contentType: "application/json",
                async: false,
                success: function (data) {

                    if (data.d.length > 0) {
                        $(ddl).empty();
                        $(ddl).append('<option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>');
                        
                        for (i = 0; i < data.d.length; i++) {
                            var nombre = data.d[i].Nombre + " " + data.d[i].Apellido;
                            $(ddl).append($("<option></option>").val(data.d[i].IdProfesional).html(nombre));
                        }
                        $(ddl).prop("disabled", false);
                    }
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    $(ddl).prop("disabled", true);
                    alert(data.error);
                }
            });
        }

        function cargarComboCentros(ddl) {
            
            $.ajax({
                url: "DisponibilidadHoraria.aspx/cargarCentros",
                type: "post",
                contentType: "application/json",
                async: false,
                success: function (data) {

                    if (data.d.length > 0) {
                        $(ddl).empty();
                        $(ddl).append('<option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>');
                        
                        for (i = 0; i < data.d.length; i++) {

                            $(ddl).append($("<option></option>").val(data.d[i].IdCentro).html(data.d[i].NombreCentro));
                        }
                        $(ddl).prop("disabled", false);
                    }
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    $(ddl).prop("disabled", true);
                    alert(data.error);
                }
            });
        }

        function validarDatos() {
            if (profesional == null) {
                alert("Ingrese un Profesional");
                return false;
            } else if (sucursal == null) {
                alert("Ingrese una Sucursal");
                return false;
            } else if (especialidad == null) {
                alert("Ingrese una Especialidad");
                return false;
            } else if (fechaDesde == null) {
                alert("Ingrese una Fecha");
                return false;
            } else if (fechaHasta == null) {
                alert("Ingrese una Fecha");
                return false;
            } else if (horaDesde == null) {
                alert("Ingrese una Hora válida");
                return false;
            } else if (minDesde == null) {
                alert("Ingrese una Hora válida");
                return false;
            } else if (horaHasta == null) {
                alert("Ingrese una Hora válida");
                return false;
            } else if (minDesde == null) {
                alert("Ingrese una Hora válida");
                return false;
            } else {
                var d1 = fechaDesde.split('/');
                var d2 = fechaHasta.split('/');
                var compDesde = d1[1] + '-' + d1[0] + '-' + d1[2]
                var compHasta = d2[1] + '-' + d2[0] + '-' + d2[2]
                if (Date.parse(compDesde) > Date.parse(compHasta)) {
                    alert("Error en las Fechas ingresadas!");
                    return false
                } else {
                    return true;
                }
            };
        }
    </script>
</asp:Content>

