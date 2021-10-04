<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AgendaTurnos.ascx.cs" Inherits="TurneroWeb10.UserControls.AgendaTurnos" %>

<div class="col-md-12 pt-1" id="">
    <div class="card text-white bg-light">
        <div class="card-header bg-info">
            <h4 class="modal-title">Agenda de turnos</h4>
        </div>
        <div class="card-body">
            <div class="form-row ">
                <div class="col-sm-4 col-md-4 col-lg-4 ">
                    <div class="input-group mb-3">
                        <div class="input-group-prepend">
                            <span class="input-group-text">Sucursal: </span>
                        </div>
                        <select class="custom-select form-control" id="ddlSucursal">
                        </select>
                    </div>
                </div>   
                
                <div class="col-sm-4 col-md-4 col-lg-4 ">
                    <div class="input-group mb-3">
                        <div class="input-group-prepend">
                            <span class="input-group-text">Fecha:</span>
                        </div>
                        <div>
                            <input type='text' class="form-control datepicker date" id="dtpFecha"
                                placeholder="DD/MM/YYYY" data-provide="datepicker"
                                data-date-format="dd/mm/yyyy" />
                        </div>
                    </div>
                </div>
            </div>
                       
            <div id="tListarTurnos" >
                <table style="width:100%" class="table table-striped table-hover table-bordered table-secondary" id="tablaListarTurnos">
                    <%--<thead>
                        <tr>
                            <th>HORA</th>
                            <th>ESPECIALIDAD</th>
                            <th>PROFESIONAL</th>
                        </tr>
                    </thead>--%>
                </table>
            </div>                              
        </div>
    </div>
</div>


<script type="text/javascript">
    

    $(document).ready(function () {
        
        var rol = traerRol();

        cargarComboCentros('#ddlSucursal'); 
        $('#ddlSucursal').val('1');

        $('#dtpFecha').datepicker({ 
            autoclose: true,
            format: "dd/mm/yyyy",
            //startDate: '+1d',
            orientation: 'bottom'
        }).datepicker("setDate",'now');

        completarTurnosDelDia($('#ddlSucursal').val(), $('#dtpFecha').val());

        $("#ddlSucursal").bind("change", function () {
            completarTurnosDelDia($('#ddlSucursal').val(), $('#dtpFecha').val());
        });

        $("#dtpFecha").bind("change", function () {
            completarTurnosDelDia($('#ddlSucursal').val(), $('#dtpFecha').val());
        });

    });

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

    function cambioDeEstado(idturno) {
        
        var estado = $("#" + idturno).val();

        $.ajax({
            url: "Agenda.aspx/modificarEstadoEnTurno",
            data: "{idturno: '" + idturno + "', estado: '" + estado + "'}",
            type: "post",
            contentType: "application/json",
            async: false,
            success: function (data) {

                completarTurnosDelDia($('#ddlSucursal').val(), $('#dtpFecha').val())
                swal("Hecho", "Estado de turno modificado!", "success");

            },
            error: function (xhr, ajaxOptions, thrownError) {
                swal("Hubo un problema", "Error al modificar el estado.", "error");
            }
        });

    }

    function traerEstados() {

        var estados;

        $.ajax({
            url: "Agenda.aspx/traeEstados",
            //data: "{idCentro: '" + idCentro + "', dia: '" + dia + "'}",
            type: "post",
            contentType: "application/json",
            async: false,
            success: function (data) {
                estados = JSON.parse(data.d);
            }
        });

        return estados;
    }

    function completarTurnosDelDia(idCentro, dia) {

        $.ajax({
            url: "Agenda.aspx/traerTurnosDelDia",
            data: "{idCentro: '" + idCentro + "', dia: '" + dia + "'}",
            type: "post",
            contentType: "application/json",
            async: false,
            success: function (data) {

                var estados = traerEstados();

                var datos = JSON.parse(data.d);
                var turnos = [];
                datos.forEach(function (e)
                {
                    var IdTurno = e.ID_TURNO;
                    var Hora = e.HORA_DESDE;
                    var Especialidad = e.ESPECIALIDAD;
                    var Profesional = e.PROFESIONAL;
                    var Paciente = e.PACIENTE;
                    var Estado = e.ESTADO;
                    var Centro = e.CENTRO;
                    var fechaArr = moment(e.FECHA_TURNO).format("DD/MM/yyyy");
                    var Fecha = fechaArr;

                    var comboEstado =
                        '<select class="custom-select form-control" id="' + e.ID_TURNO + '" onchange="cambioDeEstado(' + e.ID_TURNO + ')">';

                    estados.forEach(function (f) {
                        if (e.ESTADO == f.ESTADO) {
                            comboEstado += ' <option selected value="' + f.ESTADO + '">' + f.ESTADO + '</option> '
                        }
                        else {
                            comboEstado += ' <option value="' + f.ESTADO + '">' + f.ESTADO + '</option> '
                        }
                    });

                    comboEstado += '</select>';

                    turnos.push([IdTurno, Centro, Fecha, Hora, Especialidad, Profesional, Paciente, Estado, comboEstado]);
                                    
                });

                var table = $('#tablaListarTurnos').DataTable({
                    data: turnos,
                    "scrollX": true,
                    "languaje": {
                        "url": "//cdn.datatables.net/plug-ins/1.10.12/i18n/Spanish.json"
                    },
                    "ordering": true,
                    "bDestroy": true,
                    "bAutoWidth": true,
                    //select: true,
                    columns: [
                        { title: "ID", visible: false },
                        { title: "Centro", visible: false },
                        { title: "Fecha", visible: false},
                        { title: "Hora" },
                        { title: "Especialidad" },
                        { title: "Profesional" },
                        { title: "Paciente" },
                        { title: "Estado", visible: false },
                        { title: "Estado"}
                    ],
                    //dom: 'Bfrtip',
                    dom: '<"top"B>rti<"bottom"fp><"clear">',
                    "oLanguage": {
                        "sSearch": "Filtrar:",
                        "oPaginate": {
                            "sPrevious": "Anterior",
                            "sNext": "Siguiente"
                        }
                    },
                    "rowCallback": function (row, data, index) {
                        if (data[7] == 'OTORGADO') {
                            $('td', row).css('background-color', '#90f5a6');
                            //$('td', row).css('color', 'rgba(255, 255, 255, .8)');
                            $('td', row).eq(4).css('background-color', '#28a745');
                            $('td', row).eq(4).css('color', 'rgba(255, 255, 255, .8)');
                        } else if (data[7] == 'EN ESPERA') {
                            //#ffc107
                            $('td', row).css('background-color', '#f7d260');
                            //$('td', row).css('color', 'rgba(255, 255, 255, .8)');
                            $('td', row).eq(4).css('background-color', '#ffc107');
                            $('td', row).eq(4).css('color', 'rgba(255, 255, 255, .8)');
                        }
                    },
                    "bPaginate": true,
                    "pageLength": 7,
                    buttons: [
                        //{ extend: 'copy', text: "Copiar" },
                        {
                            extend: 'print',
                            text: "Imprimir",
                            exportOptions: {
                                columns: [ 1, 2, 3, 4, 5, 6, 7 ]
                            }
                        },
                        {
                            extend: 'pdf', /*orientation: 'landscape'*/
                            exportOptions: {
                                columns: [ 1, 2, 3, 4, 5, 6, 7 ]
                            }
                        },
                        { extend: 'colvis', columns: ':not(:first-child)', text: "Ocultar/Mostrar columnas" }
                    ]
                });
                $('.dataTables_filter input').attr("placeholder", "Filtrar por...");
            }
        });   
    }


    
</script>
