<%@ Page Title="Disponibilidad Horaria - Sistema Kinesio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HorariosProfesionales.aspx.cs" Inherits="TurneroWeb10.HorariosProfesionales" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        /*.datepicker.date {
            width: 90%;
        }*/
        /*.select2-selection {
            height: 100% !important;

        }
        
        .select2-selection__arrow {
            height: 100% !important;
        }
        .select2-selection__rendered {
            margin-top: 4px;
            height: 100% !important;
        }*/
        .noClick {
           pointer-events: none !important;
        }
        
    </style>
    <section class="content-header">
        <h1 style="text-align: left">DISPONIBILIDAD HORARIA</h1>
    </section>
    <section class="content">
        </br>
        <div class="justify-content-md-center">           
            <div class="box box-primary">
                <div class="box-header">
                    <h4 class="box-title">Buscar Profesional:</h4>
                </div>
                <div class="box-body ml-2">
                    <div class="row">
                        <div class="col-md-8 col-lg-8 col-xl-4">
                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">Profesional: </span>
                                </div>
                                <select class="form-control" id="txtNombreProf" ></select>
                            </div>
                        </div>
                        <div class="col-md-4 col-lg-4 col-xl-8" >
                            <button class="btn btn-success btn-lg float-right" style="display:none" type="button" id="btnAgregarDisponibilidad"> <i class="fas fa-plus"></i>  |  Agregar Disponibilidad</button>
                        </div>
                    </div>
                </div>
                <div class="box-body">                    
                    <div class="row">
                        <div class="col-md-12 col-lg-12 col-xl-6" id="tblTratamiento" >
                            </br>
                            <div class="table-responsive"> 
                                <div id="tHorarios" >
                                    <table style=" width: 100% !important;" class="table table-hover table-bordered  table-striped" id="tablaHorarios">
                                    </table>
                                </div> 
                            </div>  
                        </div>
                        <div class="col-md-12 col-lg-12 col-xl-6" id="calendario" >
                            <div id='calendarioDispHor'></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <%--Modal Agregar--%>
    <div class="modal fade" tabindex="-1" role="dialog" id="modalAgregar" aria-labelledby="myModalLabel">
        <div class="modal-dialog " role="document">
            <div class="modal-content">
                <div class="modal-header bg-info text-white">
                    <h4 class="modal-title " id="lblTituloTurno">Agregar Disponibilidad Horaria</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body" id="formularioAgregar">
                    <div class="row">
                        <div class="col-md" id="crdPaciente2">
                            <div class="card text-white">
                                <div class="card-header">
                                    <h4 class="modal-title text-dark " id="lblProfesional">Completar datos </h4>
                                    <div class="" style="display:none">
                                            <input type="text" style="text-align: left" class="form-control" id="nombreProfesionalAgregar"/>
                                    </div>
                                    <div class="" style="display:none">
                                            <input type="text" style="text-align: left" class="form-control" id="idProfesionalAgregar"/>
                                    </div>
                                </div>
                                <div class="card-body">
                                    <div class="form-row">
                                        <div class="col">
                                            <div class="input-group mb-3">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">Sucursal: </span>
                                                </div>
                                                <select class="custom-select form-control actualizar" id="ddlSucursal">
                                                    <option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col">
                                            <div class="input-group mb-3">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">Desde: </span>
                                                </div>
                                                <input type='text' class="form-control datepickerAgregar date actualizar" id="dtpFechaDesde"
                                                        placeholder="DD/MM/YYYY" data-provide="datepicker"
                                                        data-date-format="dd/mm/yyyy" />
                                                
                                                    
                                            </div>
                                        </div>
                                        <div class="col">
                                            <div class="input-group mb-3">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">Hasta: </span>
                                                </div>
                                                <input type='text' class="form-control datepickerAgregar date actualizar" id="dtpFechaHasta"
                                                    placeholder="DD/MM/YYYY" data-provide="datepicker"
                                                    data-date-format="dd/mm/yyyy" />

                                            </div>
                                        </div>                           
                                    </div>
                                    <div class="form-row">
                                        <div class="col">
                                            <div class="input-group mb-3">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">Hora Desde: </span>
                                                </div>
                                                <select class="btn btn-white form-control actualizar" id="ddlHoraDesde">
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
                                                <select class="btn btn-white form-control actualizar" id="ddlMinDesde">
                                                    <option value="00">00</option>
                                                    <option value="15">15</option>
                                                    <option value="30">30</option>
                                                    <option value="45">45</option>
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col">
                                            <div class="input-group mb-3">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">Hora Hasta: </span>
                                                </div>
                                                <select class="btn btn-white form-control actualizar" id="ddlHoraHasta">
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
                                                <select class="btn btn-white form-control actualizar" id="ddlMinHasta">
                                                    <option value="00">00</option>
                                                    <option value="15">15</option>
                                                    <option value="30">30</option>
                                                    <option value="45">45</option>
                                                </select>
                                            </div>
                                        </div>
                                    </div> 
                                    <div class="form-row">
                                        <div class="col">
                                            <table class="table table-borderless">
                                                <thead>
                                                    <tr>
                                                        <th class="text-center">Lunes</th>
                                                        <th class="text-center">Martes</th>
                                                        <th class="text-center">Miércoles</th>
                                                        <th class="text-center">Jueves</th>
                                                        <th class="text-center">Viernes</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td class="text-center">
                                                            <input type="checkbox" class="flat-green ml-2 actualizar" id="lunes"/>
                                                        </td>
                                                        <td class="text-center">
                                                            <input type="checkbox" class="flat-green ml-2 actualizar" id="martes"/>
                                                        </td>
                                                        <td class="text-center">
                                                            <input type="checkbox" class="flat-green ml-2 actualizar" id="miercoles"/>
                                                        </td>
                                                        <td class="text-center">
                                                            <input type="checkbox" class="flat-green ml-2 actualizar" id="jueves"/>
                                                        </td>
                                                        <td class="text-center">
                                                            <input type="checkbox" class="flat-green ml-2 actualizar" id="viernes"/>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="alert alert-danger mr-3" role="alert" id="msgRegistrarError" style="display:none" > </div>

                            <div class="alert alert-success m-3" role="alert" id="msgRegistrarExito" style="display:none" ></div>
                            <br />
                            <button class="btn btn-success btn-lg float-right ml-3" type="button" id="btnRegistrar" style="display:none">Registrar</button>

                            <button class="btn btn-warning text-white btn-lg float-right" type="button" id="btnValidar">Validar</button>
                        </div>
                    </div>
                </div> 
            </div>  
        </div>  
    </div> 
    <%--final Modal Agregar--%>

    <%--Modal Baja--%>
    <div class="modal fade" tabindex="-1" role="dialog" id="modalBaja" aria-labelledby="myModalLabel">
        <div class="modal-dialog " role="document">
            <div class="modal-content">
                <div class="modal-header bg-info text-white">
                    <h4 class="modal-title ">Dar de Baja Disponibilidad Horaria</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body" id="formularioBaja">
                    <div class="row">
                        <div class="col-md" > 
                            <div class="card text-white">
                                <div class="card-header">
                                    <h4 class="modal-title text-dark " >Datos del Horario</h4>
                                    <div class="" style="display:none">
                                            <input type="text" style="text-align: left" class="form-control" id="idProfesionalBaja"/>
                                    </div>
                                    <div class="" style="display:none"> 
                                            <input type="text" style="text-align: left" class="form-control" id="idDisponibilidadBaja"/>
                                    </div>
                                </div>
                                <div class="card-body">
                                    <div class="form-row">
                                        <div class="col">
                                            <div class="input-group mb-3">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">Sucursal: </span>
                                                </div>
                                                <select class="custom-select form-control " id="ddlSucursalBaja" disabled="disabled">
                                                    <option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col">
                                            <div class="input-group mb-3">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">Desde: </span>
                                                </div>
                                                <input type='text' class="form-control datepickerAgregar date " id="dtpFechaDesdeBaja"
                                                        placeholder="DD/MM/YYYY" data-provide="datepicker"
                                                        data-date-format="dd/mm/yyyy" disabled="disabled"/>
                                                
                                                    
                                            </div>
                                        </div>
                                        <div class="col">
                                            <div class="input-group mb-3">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">Hasta: </span>
                                                </div>
                                                <input type='text' class="form-control datepickerAgregar date " id="dtpFechaHastaBaja"
                                                    placeholder="DD/MM/YYYY" data-provide="datepicker"
                                                    data-date-format="dd/mm/yyyy" disabled="disabled"/>

                                            </div> 
                                        </div>                           
                                    </div>
                                    <div class="form-row">
                                        <div class="col">
                                            <div class="input-group mb-3">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">Hora Desde: </span>
                                                </div>
                                                <select class="btn btn-white form-control " id="ddlHoraDesdeBaja" disabled="disabled">
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
                                                <select class="btn btn-white form-control " id="ddlMinDesdeBaja" disabled="disabled">
                                                    <option value="00">00</option>
                                                    <option value="15">15</option>
                                                    <option value="30">30</option>
                                                    <option value="45">45</option>
                                                </select>
                                            </div>
                                        </div> 
                                    </div>
                                    <div class="form-row">
                                        <div class="col">
                                            <div class="input-group mb-3">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">Hora Hasta: </span>
                                                </div> 
                                                <select class="btn btn-white form-control " id="ddlHoraHastaBaja" disabled="disabled">
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
                                                <select class="btn btn-white form-control " id="ddlMinHastaBaja" disabled="disabled">
                                                    <option value="00">00</option>
                                                    <option value="15">15</option>
                                                    <option value="30">30</option>
                                                    <option value="45">45</option>
                                                </select>
                                            </div>
                                        </div>
                                    </div>  
                                    <div class="form-row">
                                        <div class="col">
                                            <table class="table table-borderless">
                                                <thead>
                                                    <tr>
                                                        <th class="text-center">Lunes</th>
                                                        <th class="text-center">Martes</th>
                                                        <th class="text-center">Miércoles</th>
                                                        <th class="text-center">Jueves</th>
                                                        <th class="text-center">Viernes</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td class="text-center noClick">
                                                            <input type="checkbox" class="flat-green ml-2 " id="lunesBaja" />
                                                        </td>
                                                        <td class="text-center noClick">
                                                            <input type="checkbox" class="flat-green ml-2 " id="martesBaja" />
                                                        </td>
                                                        <td class="text-center noClick">
                                                            <input type="checkbox" class="flat-green ml-2 " id="miercolesBaja" />
                                                        </td>
                                                        <td class="text-center noClick">
                                                            <input type="checkbox" class="flat-green ml-2 noClick" id="juevesBaja" />
                                                        </td>
                                                        <td class="text-center noClick">
                                                            <input type="checkbox" class="flat-green ml-2 noClick" id="viernesBaja" />
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <%--<div class="alert alert-danger mr-3" role="alert" id="msgRegistrarError" style="display:none" > </div>

                            <div class="alert alert-success m-3" role="alert" id="msgRegistrarExito" style="display:none" ></div>
                            --%><br />
                            <button class="btn btn-danger btn-lg float-right ml-3" type="button" id="btnBaja" style="display:none">Dar de Baja</button>
<%--
                            <button class="btn btn-warning text-white btn-lg float-right" type="button" id="btnValidar">Validar</button>
                        --%></div>
                    </div>
                </div>
            </div>  
        </div>  
    </div> 
    <%--final Modal Baja--%>

    <script type="text/javascript">

        $(document).ready(function () {

            iniciarSelect2Profesional();

            $('.datepickerAgregar').datepicker({
                format: 'dd/mm/yyyy',
                startDate: new Date(),
                language: 'es'
            });

            $('#dtpFechaDesde').datepicker().on('changeDate', function(e) {
                //$('#dtpFechaHasta').datepicker(e.format(0,"dd/mm/yyyy"));
                //$('#dtpFechaHasta').datepicker("update", $('#dtpFechaDesde').val());
                $('#dtpFechaHasta').datepicker("setStartDate", $('#dtpFechaDesde').val());
            });

            $('input').iCheck({
                checkboxClass: 'icheckbox_flat-green'
            });

            $('#txtNombreProf').on('select2:select', function (e) {
                var data = e.params.data;
                var profesional = traerHorariosProfesional(data.id);

                var btnAgregar = document.getElementById("btnAgregarDisponibilidad");
                btnAgregar.addEventListener("click", abrirPopupAgregar);
                btnAgregar.idProfesional = data.id;
                btnAgregar.nombreProfesional = data.text;

                $("#btnAgregarDisponibilidad").show();

                crearTablaHorarios(profesional, data.id);
                dibujaCalendarioDisp(profesional);
            })

            $('#btnRegistrar').click(function ()
            {
                var disponibilidad = armarDisponibilidadRegistrar();

                var resultRegistrar = registrarDisponibilidad(disponibilidad);
                var idProfesional = disponibilidad.p_idProfesional;
                if (resultRegistrar == "OK") {
                    $('#modalAgregar').modal('hide');
                    cargarTabla(idProfesional);
                    swal("Hecho", "Horario registrado con éxito!", "success");
                } else {
                    $('#msgRegistrarError').text("Error al registrar el Horario. Revise los datos ingresados y vuelva a validarlos.");
                    $('#msgRegistrarError').show();
                    $('#msgRegistrarExito').hide();
                    $('#btnRegistrar').hide();
                }

            });

            $('#btnValidar').click(function () {
                var disponibilidad = armarDisponibilidadRegistrar();
                btnValidarClick(disponibilidad);
            });

            $('#btnBaja').click(function ()
            {
                debugger;
                var idProfesional = $('#idProfesionalBaja').val();
                var idDisponibilidad = $('#idDisponibilidadBaja').val();
                var cantidadTurnos = consultarTurnosEnDisponibilidad(idDisponibilidad, idProfesional);

                swal({
                    title: "¿Desea dar de baja el Horario?",
                    text: cantidadTurnos +" turno(s) deberan reprogramarse una vez dado de baja el horario. Esta operación no se podrá volver atrás.",
                    icon: "warning",
                    buttons: [
                        'No, gracias!',
                        'Sí, dar de baja!'
                    ],
                    dangerMode: true,
                    closeModal: true,
                }).then(
                    function (isConfirm) {
                        if (isConfirm) {
                            var result = darDeBajaDisponibilidad(idDisponibilidad, idProfesional);
                            if (result == 'OK')
                            {
                                $('#modalBaja').modal('hide');
                                cargarTabla(idProfesional);
                                swal("Dado de Baja", "Baja del Horario exitosa.", "success");
                            }
                            else
                                swal("Cancelado", "Hubo un problema al dar de baja el Horario.", "error");
                        } else {
                            swal("Cancelado", "Baja del Horario cancelada.", "error");
                        }
                    }
                )
            });
        });

        function cargarTabla(idProfesional) {
            var profesional = traerHorariosProfesional(idProfesional);
            crearTablaHorarios(profesional, idProfesional);
            dibujaCalendarioDisp(profesional);
        }

        function darDeBajaDisponibilidad(idDisponibilidad, idProfesional) {
            var result;
            $.ajax({
                url: "HorariosProfesionales.aspx/darDeBajaDisponibilidad",
                data: "{idDisponibilidad: '" + idDisponibilidad + "', idProfesional: '"+ idProfesional +"'}",
                type: "post",
                contentType: "application/json",
                async: false,
                success: function (data) {
                    result = data.d;
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    
                }
            });
            return result;
        }

        function consultarTurnosEnDisponibilidad(idDisponibilidad, idProfesional) {
            var result;
            $.ajax({
                url: "HorariosProfesionales.aspx/consultarTurnosEnDisponibilidad",
                data: "{idDisponibilidad: '" + idDisponibilidad + "', idProfesional: '"+ idProfesional +"'}",
                type: "post",
                contentType: "application/json",
                async: false,
                success: function (data) {                  
                    result = data.d;
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    
                }
            });
            return result;
        }

        function registrarDisponibilidad(disponibilidad) {
            var result;
            $.ajax({
                url: "HorariosProfesionales.aspx/registrarDisponibilidad",
                data: "{disponibilidad: '" + JSON.stringify(disponibilidad) + "'}",
                type: "post",
                contentType: "application/json",
                async: false,
                success: function (data) {
                    result = data.d;
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    $('#btnRegistrar').hide();
                }
            });
            return result;
        }

        function btnValidarClick(disponibilidad) {
            var msj = validarDatosModalRegistrar(disponibilidad);

            if (msj == "OK") {
                var result = validarHorario(disponibilidad);
                if (result == "OK") {
                    $('#msgRegistrarExito').text("Horario disponible. Puede REGISTRAR la disponibilidad.");
                    $('#msgRegistrarExito').show();
                    $('#msgRegistrarError').hide();
                    $('#btnRegistrar').show();
                    return "OK";
                } else if (result == "ERR") {
                    $('#msgRegistrarError').text("Horario no disponible. Se superpone con un horario ya cargado para el Profesional.");
                    $('#msgRegistrarError').show();
                    $('#msgRegistrarExito').hide();
                    $('#btnRegistrar').hide();
                    return "Horario no disponible. Se superpone con un horario ya cargado para el Profesional.";
                }
            } else {
                $('#msgRegistrarError').text(msj);
                $('#msgRegistrarError').show();
                $('#msgRegistrarExito').hide();
                $('#btnRegistrar').hide();
                return msj;
            }
        }

        function armarDisponibilidadRegistrar() {
            var disponibilidad = {
                p_idProfesional: $('#idProfesionalAgregar').val(),
                p_sucursal: $('#ddlSucursal').val(),
                    
                p_fechaDesde: $('#dtpFechaDesde').val(),
                p_fechaHasta: $('#dtpFechaHasta').val(),
                p_horaDesde: $('#ddlHoraDesde').val(),
                p_minDesde: $('#ddlMinDesde').val(),
                p_horaHasta: $('#ddlHoraHasta').val(),
                p_minHasta: $('#ddlMinHasta').val(),

                p_lunes: ($("#lunes").prop("checked") == true ? true : false),
                p_martes:  ($("#martes").prop("checked") == true ? true : false),
                p_miercoles: ($("#miercoles").prop("checked") == true ? true : false),
                p_jueves: ($("#jueves").prop("checked") == true ? true : false),
                p_viernes: ($("#viernes").prop("checked") == true ? true : false)
            }

            return disponibilidad;
        }

        function validarDatosModalRegistrar(disponibilidad) {

            debugger;
            if (disponibilidad.p_sucursal == null) { return "Seleccione una Sucursal." }
            else if (disponibilidad.p_fechaDesde == "") { return "Seleccione correctamente la fecha." }
            else if (disponibilidad.p_fechaHasta == "") { return "Seleccione correctamente la fecha." }
            else if (+disponibilidad.p_horaDesde > +disponibilidad.p_horaHasta) { return "Seleccione correctamente la hora." }
            else if ((+disponibilidad.p_horaDesde == +disponibilidad.p_horaHasta) && (+disponibilidad.p_minDesde > +disponibilidad.p_minHasta)) { return "Seleccione correctamente la hora." }
            else if (!disponibilidad.p_lunes &&
                !disponibilidad.p_martes &&
                !disponibilidad.p_miercoles &&
                !disponibilidad.p_jueves &&
                !disponibilidad.p_viernes) { return "Elija al menos un día." }
            else { return "OK" }
        }

        function validarHorario(disponibilidad) {
            var result;
            $.ajax({
                url: "HorariosProfesionales.aspx/validarDisponibilidad",
                data: "{disponibilidad: '" + JSON.stringify(disponibilidad) + "'}",
                type: "post",
                contentType: "application/json",
                async: false,
                success: function (data) {
                    result = data.d;
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    $('#btnRegistrar').hide();
                }
            });
            return result;
        }

        //function actualizarTexto() {
        //    var nombre = $('#nombreProfesionalAgregar').val();
        //    var sucursal = $('#ddlSucursal option:selected').text();
        //    var fechaDesde = $('#dtpFechaDesde').val();
        //    var fechaHasta = $('#dtpFechaHasta').val();

        //    var horaDesde = $('#ddlHoraDesde').val();
        //    var minDesde = $('#ddlMinDesde').val();
        //    var horaHasta = $('#ddlHoraHasta').val();
        //    var minHasta = $('#ddlMinHasta').val();
               

        //    var Dias = '';
        //    Dias += ($("#lunes").prop("checked") == true ? 'Lunes, ' : '');
        //    Dias +=  ($("#martes").prop("checked") == true ? 'Martes, ' : '');
        //    Dias += ($("#miercoles").prop("checked") == true ? 'Miércoles, ' : '');
        //    Dias += ($("#jueves").prop("checked") == true ? 'Jueves, ' : '');
        //    Dias += ($("#viernes").prop("checked") == true ? 'Viernes, ' : '');
        //    Dias = Dias.slice(0, -2);

        //    var texto = nombre + ' tendrá disponibilidad horaria los días ' + Dias +
        //        ', desde el ' + fechaDesde + ' al ' + fechaHasta + ', entre las ' + horaDesde + ':' + minDesde +
        //        ' y las ' + horaHasta + ':' + minHasta + ' horas, en sucursal ' + sucursal + '.';

        //    $('#lblDisponibilidadAgregar').text(texto);
            
        //}

        function abrirPopupAgregar(params) {

            limpiarModalAgregar()

            var id = params.currentTarget.idProfesional;
            var nombre = params.currentTarget.nombreProfesional
            $('#nombreProfesionalAgregar').val(nombre);
            $('#idProfesionalAgregar').val(id);
            cargarComboCentros("#ddlSucursal");

            $('#modalAgregar').modal('show');

        }

        function limpiarModalAgregar() {
            $('#idProfesionalAgregar').val("");
            $('#ddlSucursal').val("0");
            $('#dtpFechaDesde').val("").datepicker("update");
            $('#dtpFechaHasta').val("").datepicker("update");

            $('#ddlHoraDesde').val('8');
            $('#ddlMinDesde').val('00');
            $('#ddlHoraHasta').val('8');
            $('#ddlMinHasta').val('00');

            $("#lunes").iCheck("uncheck");
            $("#martes").iCheck("uncheck");
            $("#miercoles").iCheck("uncheck");
            $("#jueves").iCheck("uncheck");
            $("#viernes").iCheck("uncheck");
            
            $('#msgRegistrarError').text("");
            $('#msgRegistrarError').hide();

            $('#msgRegistrarExito').text("");
            $('#msgRegistrarExito').hide();

            $('#btnRegistrar').hide();
        }

        function dibujaCalendarioDisp(profesional) {
            $("#calendario").show();
            var calendarEl = document.getElementById('calendarioDispHor');
            calendarDisp = new FullCalendar.Calendar(calendarEl, {

                initialView: 'dayGridMonth',
                selectable: true,
                dayMaxEvents: true,
                headerToolbar: {
                    left: 'title',
                    center: '',
                    right: 'prev,next' // timeGridWeek,
                },
                locale: 'ES',
                eventClick: function (info) {
                    
                },
                eventDidMount: function(info) {
                    $(info.el).tooltip({ 
                        title: info.event.extendedProps.description,
                        placement: 'top',
                        trigger: 'hover',
                        container: 'body'
                    });
                }
            });
            CargarEventosFullCalendar(profesional);

            calendarDisp.render();

        }

        function CargarEventosFullCalendar(profesional) {
            var eventos = [];

            if (!(profesional.HorariosProfesional === null)){
                profesional.HorariosProfesional.forEach(function (e) {

                    var Dias = [];

                    e.Lunes == true ? Dias.push('lunes') : '';
                    e.Martes == true ? Dias.push('martes') : '';
                    e.Miercoles == true ? Dias.push('miércoles') : '';
                    e.Jueves == true ? Dias.push('jueves') : '';
                    e.Viernes == true ? Dias.push('viernes') : '';

                    var dateInic = new Date(e.FechaInic);
                    var dateFin = new Date(e.FechaFin);

                    var descr = e.Centro.NombreCentro + " | " + e.HoraDesde.slice(0, -3) + " - " + e.HoraHasta.slice(0, -3);

                    var diasArray = obtenerDiasSinFindesemanas(dateInic, dateFin, Dias);

                    eventos.push(armarSemanasSinFindesemanas(diasArray, descr));

                });
                eventos.forEach(function (e) {
                    calendarDisp.addEventSource(e);
                });
            }
        }

        function obtenerDiasSinFindesemanas(startDate, stopDate, Dias) {
            var diasArray = new Array();
            var currentDate = startDate;

            while (currentDate <= stopDate) {
                var diaNombre = currentDate.toLocaleString('es-es', { weekday: 'long' });
                if (Dias.includes(diaNombre)) {
                    diasArray.push(new Date(currentDate));
                    currentDate = currentDate.addDays(1);
                }
                else {
                    currentDate = currentDate.addDays(1);
                }
            }
            return diasArray;
        }

        Date.prototype.addDays = function (days) {
            var date = new Date(this.valueOf());
            date.setDate(date.getDate() + days);
            return date;
        }

        function armarSemanasSinFindesemanas(diasArray, descr) {
            var dispHor = [];

            var dispHorSemana = '{"title": "Disponible", "start": "", "end":"", "description": ""}'; // TODO: , agregar color para distinguir por centro- "color":"green"

            for (i = 0; i < diasArray.length; i++) {

                var obj = JSON.parse(dispHorSemana);
                var diaObj = diasArray[i];

                var diaFormated = getFormattedDateInversed(diaObj);
                obj.start = diaFormated;
                obj.end = diaFormated;
                obj.description = descr;
                dispHor.push(obj);
            }
            return dispHor;
        }

        function crearTablaHorarios(profesional, idProfesional) {
            
            var horarios = [];
            var otro = profesional["HorariosProfesional"];
            
            if (otro != null) {
                otro.forEach(function (e) {
                    
                    var Id = e.IdDisponibilidadHoraria;
                    var Centro = e.Centro['NombreCentro'];
                    var diaDesde = moment(e.FechaInic).format('DD-MM-YYYY');
                    var diaHasta = moment(e.FechaFin).format('DD-MM-YYYY');

                    var horaDesde = moment({ hour: e.HoraDesde.split(':')[0], minute: e.HoraDesde.split(':')[1] }).format('HH:mm');
                    var horaHasta = moment({hour:e.HoraHasta.split(':')[0], minute:e.HoraHasta.split(':')[1]}).format('HH:mm');

                    var Fecha = 'Desde: ' + diaDesde + ' Hasta: ' + diaHasta;
                    var Hora = 'De: ' + horaDesde + ' A: ' + horaHasta;

                    var Dias = '';
                    Dias += (e.Lunes == true ? 'Lun-' : '');
                    Dias +=  (e.Martes == true ? 'Mar-' : '');
                    Dias += (e.Miercoles == true ? 'Mié-' : '');
                    Dias += (e.Jueves == true ? 'Jue-' : '');
                    Dias += (e.Viernes == true ? 'Vie-' : '');
                    Dias = Dias.slice(0, -1);

                    var Acciones = 
                        '<a href="#" onclick="return modalBorrarHorario(' + Id + ', ' + idProfesional + ')"  class="btn btn-danger" > <span class="fa fa-trash" title="Dar de Baja"></span></a > ';
                    //'<a href="#" onclick="return modalEditarHorario(' + Id + ')"  class="btn btn-primary text-white" > <span class="fa fa-pencil" title="Editar"></span></a > '
                       
                    horarios.push([Id, Centro, Fecha,  Hora,  Dias, Acciones]);
                });
            }
            
            var table = $('#tablaHorarios').DataTable({
                data: horarios,
                "scrollX": true,
                "languaje": {
                    "url": "//cdn.datatables.net/plug-ins/1.10.12/i18n/Spanish.json"
                },
                "ordering": true,
                "bDestroy": true,
                "bAutoWidth": true,
                columns: [
                    { title: "ID" , visible: false},
                    { title: "CENTRO" },
                    { title: "FECHA" },
                    //{ title: "FIN" },
                    { title: "HORA" },
                    //{ title: "HASTA" },
                    { title: "DIAS" },
                    { title: "ACCIONES" }
                ],
                dom: '<"top"B>rti<"bottom"fp><"clear">',
                "oLanguage": {
                    "sSearch": "Filtrar:",
                    "oPaginate": {
                        "sPrevious": "Anterior",
                        "sNext": "Siguiente"
                    }
                },
                "bPaginate": true,
                "pageLength": 5,
                buttons: [
                    //{ extend: 'copy', text: "Copiar" },
                    {
                        extend: 'print',
                        text: "Imprimir",
                        exportOptions: {
                            columns: [ 1]
                        }
                    },
                    {
                        extend: 'pdf', /*orientation: 'landscape'*/
                        exportOptions: {
                            columns: [ 1 ]
                        }
                    },
                    { extend: 'colvis', columns: ':not(:first-child)', text: "Ocultar/Mostrar columnas" }
                ]
            });
            $('.dataTables_filter input').attr("placeholder", "Filtrar por...");   
        }

        function modalEditarHorario(idDisponibilidad) {
            //limpiar modal
            //traer y cargar modal
            //validacion, confirmacion y editar 
        }

        function modalBorrarHorario(idDisponibilidad, idProfesional) {
            //validaciones , pedir confirmacion, y borrar
            cargarModalBaja(idDisponibilidad, idProfesional);

            $('#idProfesionalBaja').val(idProfesional);

            $('#idDisponibilidadBaja').val(idDisponibilidad);
            $('#modalBaja').modal('show');
            
        }

        function cargarModalBaja(idDisponibilidad, idProfesional) {
            debugger;
            cargarComboCentros('#ddlSucursalBaja');
            $('#idProfesionalBaja').val(idProfesional);
            $('#idDisponibilidadBaja').val(idDisponibilidad);

            $.ajax({
                url: "HorariosProfesionales.aspx/traerHorario",
                data: "{idDisponibilidad: '" + idDisponibilidad + "'}",
                type: "post",
                contentType: "application/json",
                async: false,
                success: function (data) {
                    result = JSON.parse(data.d);
                    
                    $('#ddlSucursalBaja').val(result.Centro.IdCentro);
                    $('#ddlSucursalBaja').prop("disabled", true);
                    $("#dtpFechaDesdeBaja").datepicker("update", new Date(result.FechaInic));
                    $("#dtpFechaHastaBaja").datepicker("update", new Date(result.FechaFin));

                    var horaDesde = result.HoraDesde.split(':');

                    $('#ddlHoraDesdeBaja').val(parseInt(horaDesde[0], 10));
                    $('#ddlMinDesdeBaja').val(horaDesde[1]);

                    var horaHasta = result.HoraHasta.split(':');

                    $('#ddlHoraHastaBaja').val(parseInt(horaHasta[0], 10));
                    $('#ddlMinHastaBaja').val(horaHasta[1]);

                    if (result.Lunes)
                        $("#lunesBaja").iCheck('check');
                    else
                        $("#lunesBaja").iCheck('uncheck');

                    if (result.Martes)
                        $("#martesBaja").iCheck('check');
                    else
                        $("#martesBaja").iCheck('uncheck');

                    if (result.Miercoles)
                        $("#miercolesBaja").iCheck('check');
                    else
                        $("#miercolesBaja").iCheck('uncheck');

                    if (result.Jueves)
                        $("#juevesBaja").iCheck('check');
                    else
                        $("#juevesBaja").iCheck('uncheck');

                    if (result.Viernes)
                        $("#viernesBaja").iCheck('check');
                    else
                        $("#viernesBaja").iCheck('uncheck');

                    $('#btnBaja').show();
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    $('#btnBaja').hide();
                }
            });
        }

        function traerHorariosProfesional(idProfesional) {

            var datos;
            $.ajax({
                url: "HorariosProfesionales.aspx/traerHorariosProfesional",
                data: "{idProfesional: '" + idProfesional + "'}",
                type: "post",
                contentType: "application/json",
                async: false,
                success: function (data) {
                    datos = JSON.parse(data.d);
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    datos = null;
                }

            });

            return datos;
        }

        function iniciarSelect2Profesional() {

            var data = cargarProfesionales();

            $('#txtNombreProf').select2({
                theme: "bootstrap4",
                data: data,
                placeholder: "Seleccionar un Profesional",
                width: '70%'
            });

            $('#txtNombreProf').val(null).trigger("change");
        }

        function cargarProfesionales() {
            var datos;

            $.ajax({
                url: "HorariosProfesionales.aspx/Select2Prof",
                type: "post",
                contentType: "application/json",
                async: false,
                success: function (data) {
                    datos = JSON.parse(data.d);
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    datos = null;
                }

            });
            return datos;
        }

        function cargarComboCentros(ddl) {
            
            $.ajax({
                url: "HorariosProfesionales.aspx/cargarCentros",
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
                    //alert(data.error);
                }
            });
        }
    </script>
</asp:Content>