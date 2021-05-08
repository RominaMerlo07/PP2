<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarTurno.aspx.cs" Inherits="TurneroWeb10.RegistrarTurno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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
                                        <option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>
                                        <option value="1">Córdoba</option>
                                        <option value="2">Carlos Paz I</option>
                                        <option value="3">Carlos Paz II</option>
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
                                        <option value="1">Kinesiología y Fisioterapia</option>
                                        <option value="2">Quiropraxia</option>
                                        <option value="3">Rehabilitacion de terapias deportivas</option>
                                        <option value="4">Rehabilitacion</option>
                                        <option value="5">Osteopatia</option>
                                        <option value="6">Actividades fisicas adaptadas</option>
                                        <option value="7">Reeducacion postural global</option>
                                        <option value="8">Tratamiento de columna vertebral</option>
                                        <option value="9">Lesion Nerviosa Espinal</option>
                                        <option value="10">Terapia fisica</option>
                                        <option value="11">Pre-Post Quirurgicos</option>
                                        <option value="12">Pilates</option>
                                        <option value="13">Terapias Chinas</option>
                                    </select>
                                </div>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Fecha</span>
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
                                        <input type="search" class="form-control rounded" placeholder="Ingrese DNI" aria-label="Search"
                                            aria-describedby="search-addon" />
                                        <span class="input-group-text border-0" id="search-addon">
                                            <i class="fas fa-search"></i>
                                        </span>
                                    </div>
                                </div>
                                <div class="col">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">DNI</span>
                                        </div>
                                        <input type="text" style="text-align: left" class="form-control" id="txtDocumento" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="col">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text" id="">Nombre y Apellido</span>
                                        </div>
                                        <input type="text" style="text-align: left" class="form-control" id="txtNombre" />
                                        <input type="text" style="text-align: left" class="form-control" id="txtApeliido" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="col">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">Obra Social: </span>
                                        </div>
                                        <select class="custom-select form-control" id="ddlObraSocial">
                                            <option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>
                                            <option value="1">Particular</option>
                                            <option value="2">Omint</option>
                                            <option value="3">Sancor</option>
                                            <option value="3">Swiss Medical</option>
                                            <option value="3">Sipssa</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="col">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">Celular</span>
                                        </div>
                                        <input type="text" style="text-align: left" class="form-control" id="txtCelular" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="col">
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
            <div class="card" style="width: 40rem;">
                <div class="card-body">
                    <div id='calendarioTurno'></div>
                </div>
            </div>
        </div>
    </section>
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

        document.addEventListener('DOMContentLoaded', function () {
            var calendarEl = document.getElementById('calendarioTurno');
            var calendar = new FullCalendar.Calendar(calendarEl, {
                initialView: 'dayGridMonth'
            });
            calendar.render();
        });

        $(document).ready(function () {

            $('.date').datepicker({
                autoclose: true,
                format: "dd/mm/yyyy"
            });

            $('#crdDatosPersonales').hide();

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
                   
                }

            });

        });

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
