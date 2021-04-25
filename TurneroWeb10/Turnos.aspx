<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Turnos.aspx.cs" Inherits="TurneroWeb10.Turnos" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .datepicker.date{
            width: 210px;
        }

    </style>
    <div class="contenedor_turnos">   
        <h1 class="tituloH1">Turnero Online</h1>
        <div class="row">
            <div class="col-5" id="crdDatosTurno">
                <div class="card text-white bg-secondary">
                    <div class="card-header"> 
                        <h4>Datos del turno </h4>
                    </div>
                    <div class="card-body">
                        <div class="form-row">
                            <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Centro: </span>
                                    </div>
                                    <select class="btn btn-light form-control" id="ddlCentro">
                                        <option value="0" disabled selected hidden>--Seleccione--</option>
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
                                    <select class="btn btn-light form-control" id="ddlEspecialidad">
                                        <option value="0" disabled selected hidden>--Seleccione--</option>
                                        <option value="1">Especialidad 1</option>
                                        <option value="2">Especialidad 2</option>
                                        <option value="3">Especialidad 3</option>
                                        <option value="4">Especialidad 4</option>
                                        <option value="5">Especialidad 5</option>
                                    </select>
                                </div>
                            </div>
                        </div>
                        <div class="form-row">
			                <div class="col">
                                <div class="input-group mb-3" >
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Fecha: </span>
                                    </div>
                                    <div>                            
                                        <input type='text' class="form-control datepicker date" id="dtpFechaTurno"
                                                placeholder="DD/MM/YYYY" data-provide="datepicker"
                                                data-date-format="mm/dd/yyyy"/>
                                    </div>
                                </div>
                            </div>
                            <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Hora: </span>
                                    </div>
                                    <select class="btn btn-light form-control" id="ddlHoraTurno">
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
                                    <select class="btn btn-light form-control" id="ddlMinTurno">
                                        <option value="00">00</option>
                                        <option value="15">15</option>
                                        <option value="30">30</option>
                                        <option value="45">45</option>
                                    </select>
                                </div>
                            </div>
                        </div>
                        <button type="submit" class="btn btn-success btn-lg float-right" id="btnConfTurno">Confirmar</button>
                    </div>
                </div>
            </div>
            <div class="col-5" id="crdDatosPersonales">
                <div class="card text-white bg-secondary">
                    <div class="card-header"> 
                        <h4>Datos personales</h4>
                    </div>
                    <div class="card-body">
                        <div class="form-row">
                            <div class="col">
                                <div class="input-group mb-3">
                                  <div class="input-group-prepend">
                                    <span class="input-group-text" id="">Nombre y Apellido</span>
                                  </div>
                                  <input type="text" class="form-control" id="txtNombre">
                                  <input type="text" class="form-control" id="txtApeliido">
                                </div>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col">
                               <div class="input-group mb-3">
                                  <div class="input-group-prepend">
                                    <span class="input-group-text" >Documento</span>
                                  </div>
                                  <input type="text" class="form-control" id="txtDocumento">
                                </div>
                            </div>
			                <div class="col">
                                <div class="input-group mb-3">
                                  <div class="input-group-prepend">
                                    <span class="input-group-text" >Celular</span>
                                  </div>
                                  <input type="text" class="form-control" id="txtCelular">
                                </div>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend" >
                                        <span class="input-group-text">Email: </span>
                                    </div>
                                    <input type="text" class="form-control" id="txtEmail1">
                                    <div class="input-group-append">
                                        <span class="input-group-text">@</span>
                                    </div>
                                    <input type="text" class="form-control" id="txtEmail2" placeholder="gmail.com">
                                </div>
                            </div>
                        </div>
                        <button type="submit" class="btn btn-success btn-lg float-right" id="btnRegistrarTruno">Registrar Turno</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
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

        $(document).ready(function () {

            $('.date').datepicker({
                autoclose: true,
                format: "dd/mm/yyyy"
            });

            $('#crdDatosPersonales').hide();

            $('#btnConfTurno').click(function () {

                centro = $('#ddlCentro').val();
                especialidad = $('#ddlEspecialidad').val();
                fechaTurno = $('#dtpFechaTurno').val();
                horaTurno = $('#ddlHoraTurno').val();
                minTurno = $('#ddlMinTurno').val();

                var validacion = validarDatosTurno();

                if (validacion === true) {
                    $('#crdDatosPersonales').show();
                    $('#btnConfTurno').hide();
                }

            });

            $('#btnRegistrarTruno').click(function () {

                nombre = $('#txtNombre').val();
                apellido = $('#txtApeliido').val();
                documento = $('#txtDocumento').val();
                celular = $('#txtCelular').val();
                email1 = $('#txtEmail1').val();
                email2 = $('#txtEmail2').val();

                var validacion = validarDatosPersona();

                if (validacion === true) {

                    var turnoYPersona = {
                        p_centro: centro,
                        p_especialidad: especialidad,
                        p_fechaTurno: fechaTurno,
                        p_horaTurno: horaTurno,
                        p_minTurno: minTurno,
                        p_nombre: nombre,
                        p_apellido: apellido,
                        p_documento: documento,
                        p_celular: celular,
                        p_email1: email1,
                        p_email2: email2
                    }

                    $.ajax({
                        url: "Turnos.aspx/registrarTurno",
                        data: JSON.stringify(turnoYPersona),
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
            });
        });

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
            else {
                return true;
            };
        };

        function validarDatosPersona() {

            if (nombre == "") {
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


