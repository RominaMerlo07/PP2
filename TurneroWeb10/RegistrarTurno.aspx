<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarTurno.aspx.cs" Inherits="TurneroWeb10.RegistrarTurno" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .datepicker.date {
            width: 207px;
        }
    </style>
    <section class="content-header">
        <button class="btn btn-info btn-sm float-right" type="button" id="Listar">Listar Turnos</button>
        <h1 style="text-align: left">REGISTRAR TURNO</h1>
    </section>
    <section class="content">
        <div class="row">
            <div class="col-md-6" id="crdTurno">
                <div class="card text-white bg-light">
                    <div class="card-header bg-info">
                        <h4>Datos del Turno</h4>
                    </div>
                    <div class="card-body">
                        <div class="form-row">
                            <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Sucursal: </span>
                                    </div>
                                    <select class="custom-select form-control" id="ddlSucursal">
                                    </select>
                                </div>
                            </div>
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
                        <div class="form-row">
                            <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Fecha:</span>
                                    </div>
                                    <div>
                                        <input type='text' class="form-control datepicker date" id="dtpFechaD"
                                            placeholder="DD/MM/YYYY" data-provide="datepicker"
                                            data-date-format="dd/mm/yyyy" />
                                    </div>
                                </div>
                            </div>
                            <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Hora: </span>
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
                        </div>         
                    </div>
                    <div class="card text-white bg-light">
                        <div class="card-header bg-info">
                            <h4>Datos del Paciente</h4>
                        </div>
                        <div class="card-body">
                            <div class="form-row">
                                <div class="col">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">Paciente: </span>
                                        </div>
                                        <input type="search" class="form-control rounded" id="txtDocumento" placeholder="Ingrese DNI" aria-label="Search"
                                            aria-describedby="search-addon" />
                                        <button class="btn btn-outline-secondary" id="btnBuscarDNI" type="button">
                                            <i class="fas fa-search"></i>
                                        </button>
                                    </div>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="col paciente">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text" id="">Nombre y Apellido:</span>
                                        </div>
                                        <input type="text" style="text-align: left" class="form-control" id="txtNombre" />
                                        <input type="text" style="text-align: left" class="form-control" id="txtApeliido" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="col paciente">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">Obra Social: </span>
                                        </div>
                                        <select class="custom-select form-control" id="ddlObraSocial">
                                            <option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="col paciente">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">Celular:</span>
                                        </div>
                                        <input type="text" style="text-align: left" class="form-control" id="txtCelular" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="col paciente">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">Email: </span>
                                        </div>
                                        <input type="text" class="form-control" id="txtEmail1" />
                                        <div class="input-group-append">
                                            <span class="input-group-text">@</span>
                                        </div>
                                        <input type="text" class="form-control" id="txtEmail2" placeholder="gmail.com" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <button class="btn btn-success btn-lg float-right" type="button" id="btnRegistrar">Registrar</button>
            </div>
            <div class="col-md-6">
                <div class="card" > <%--style="width: 40rem;"--%>
                    <div class="card-body">
                        <div id='calendarioTurno'></div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <%--<script type="text/javascript" src="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "Estilos/Scripts/jquery-3.0.0.js"%>"></script>--%>
    <script type="text/javascript">
        var centro;
        var especialidad;
        var fechaTurno;
        var horaTurno;
        var minTurno;

        var nombre;
        var apellido;
        var documento;
        var celular;
        var email1;
        var email2;
        var calendar;
        var eventos =
                        {
                            title: 'Business Lunch',
                            start: '2021-05-22T13:00:00',
                            constraint: 'businessHours'
                        };
        

        $(document).ready(function () {

            dibujaCalendario();

            $('#dtpFechaD').datepicker({ //.date
                autoclose: true,
                format: "dd/mm/yyyy",
                startDate: '+1d'
            });

            $('#crdDatosPersonales').hide();
            $(".paciente").hide();
            $("#ddlSucursal").prop("disabled", true);
            $("#ddlEspecialidad").prop("disabled", true);
            $("#ddlObraSocial").prop("disabled", true);
            cargarComboCentros('#ddlSucursal'); 

            $('#btnRegistrar').click(function () {

                centro = $('#ddlSucursal').val();
                especialidad = $('#ddlEspecialidad').val();
                fechaTurno = $('#dtpFechaD').val();
                horaTurno = $('#ddlHoraDesde').val();
                obraSocial = $('#ddlObraSocial').val();
                minTurno = $('#ddlMinDesde').val();
                nombre = $('#txtNombre').val();
                apellido = $('#txtApeliido').val();
                documento = $('#txtDocumento').val();
                celular = $('#txtCelular').val();
                email1 = $('#txtEmail1').val();
                email2 = $('#txtEmail2').val();

                var validacion = validarDatosTurno();

                if (validacion === true) {

                    var turnoYPersona = {
                        p_centro: centro,
                        p_especialidad: especialidad,
                        p_fechaTurno: fechaTurno,
                        p_horaTurno: horaTurno,
                        p_obra_social: obraSocial,
                        p_minTurno: minTurno,
                        p_nombre: nombre,
                        p_apellido: apellido,
                        p_documento: documento,
                        p_celular: celular,
                        p_email1: email1,
                        p_email2: email2
                    }

                    registrarTurno(turnoYPersona);
                    limpiarCampos();
                }
            });

            $("#ddlSucursal").bind("change", function () {

                var idCentro = $('#ddlSucursal').val();
                cargarObrasSociales(idCentro, "#ddlObraSocial");
                cargarEspecialidades(idCentro, "#ddlEspecialidad");

            });

            $('#btnBuscarDNI').click(function () {

                //trae datos de paciente
                $(".paciente").show();
                //limpiarCampos();
            });
            

        });

        function dibujaCalendario() {
           
            var calendarEl = document.getElementById('calendarioTurno');
            calendar = new FullCalendar.Calendar(calendarEl, {
                initialView: 'dayGridMonth',
                selectable: true,
                dateClick: function(info) {
                    limpiarCampos();
                }
            });
            calendar.render();

            calendar.addEvent(eventos);
        }

        function limpiarCampos() {

            $('#ddlSucursal').val(0);
            $('#ddlEspecialidad').empty();
            $('#ddlEspecialidad').append('<option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>');
            $('#ddlEspecialidad').prop("disabled", true);
            $("#dtpFechaD").datepicker('clearDates');
            $('#ddlHoraDesde').val('8');
            $('#ddlObraSocial').empty();
            $('#ddlObraSocial').append('<option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>');
            $('#ddlObraSocial').prop("disabled", true);
            $('#ddlMinDesde').val('00');
            $('#txtNombre').val("");
            $('#txtApeliido').val("");
            $('#txtDocumento').val("");
            $('#txtCelular').val("");
            $('#txtEmail1').val("");
            $('#txtEmail2').val("");
        }

        function cargarEspecialidades(idCentro, ddl) {
            $.ajax({
                url: "RegistrarTurno.aspx/cargarEspecialidades",
                data: "{idCentro: '" + idCentro + "'}",
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

        function cargarObrasSociales(idCentro, ddl) {

            $.ajax({
                url: "RegistrarTurno.aspx/cargarObrasSociales",
                data: "{idCentro: '" + idCentro + "'}",
                type: "post",
                contentType: "application/json",
                async: false,
                success: function (data) {

                    if (data.d.length > 0) {
                        $(ddl).empty();
                        $(ddl).append('<option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>');
                        
                        for (i = 0; i < data.d.length; i++) {

                            $(ddl).append($("<option></option>").val(data.d[i].IdObraSocial).html(data.d[i].Descripcion));
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
                url: "RegistrarTurno.aspx/cargarCentros",
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

        function registrarTurno(datosTurno) {

            $.ajax({
                url: "RegistrarTurno.aspx/registrarTurno",
                data: JSON.stringify(datosTurno),
                type: "post",
                contentType: "application/json",
                async: false,
                success: function (data) {

                    if (data.d != 'OK') {
                        alert('Error al registrar turno.')
                    } else {
                        $('#btnConfTurno').show();
                        alert('Turno registrado con Éxito.')
                    }
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    alert(data.error);
                }

            });
        }

        function validarDatosTurno() {

            if (centro == null) {
                alert("Ingrese un Centro");
                return false;
            }
            else if (especialidad == null) {
                alert("Ingrese una Especialidad");
                return false;
            }
            else if (fechaTurno == "") {
                alert("Ingrese una Fecha");
                return false;
            }
            else if (horaTurno == null) {
                return false;
            }
            else if (minTurno == null) {
                return false;
            }
            else if (nombre == "") {
                alert("Ingrese un Nombre");
                return false;
            }
            else if (apellido == "") {
                alert("Ingrese un Apellido");
                return false;
            }
            else if (documento == "") {
                alert("Ingrese un Documento");
                return false;
            }
            else if (celular == "") {
                alert("Ingrese un Celular");
                return false;
            }
            else if (email1 == "") {
                alert("Ingrese un Email válido");
                return false;
            }
            else if (email2 == "") {
                alert("Ingrese un Email válido");
                return false;
            }
            else {
                return true;
            };
        };

    </script>
</asp:Content>
