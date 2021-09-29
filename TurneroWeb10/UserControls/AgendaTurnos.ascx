<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AgendaTurnos.ascx.cs" Inherits="TurneroWeb10.UserControls.AgendaTurnos" %>

<div class="col-md-4 pt-1" id="">
    <div class="card text-white ">
        <div class="card-header ">
            <h4 class="modal-title text-dark">Turnos del Día</h4>
        </div>
        <div class="card-body">               
            <div id="tListarTurnos" >
                <table style="width:100%" class="table table-striped table-bordered" id="tablaListarTurnos">
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

        completarTurnosDelDia();


    });

    function completarTurnosDelDia() {

        $.ajax({
            url: "Agenda.aspx/traerTurnosDelDia",
            //data: "{idProfesionalDetalle: '" + idProfesionalDetalle + "', idCentro: '" + centro + "'}",
            type: "post",
            contentType: "application/json",
            async: false,
            success: function (data) {

                debugger;
                var datos = JSON.parse(data.d);
                var turnos = [];
                datos.forEach(function (e)
                {
                    var Hora = e.HORA_DESDE;
                    var Especialidad = e.ESPECIALIDAD;
                    var Profesional = e.PROFESIONAL;

                    turnos.push([Hora, Especialidad, Profesional]);
                                    
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
                    columns: [
                        { title: "Hora" },
                        { title: "Especialidad" },
                        { title: "Profesional" }
                    ],
                    dom: 'Bfrtip',
                    dom: '<"top"B>rti<"bottom"fp><"clear">',
                    "oLanguage": {
                        "sSearch": "Filtrar:",
                        "oPaginate": {
                            "sPrevious": "Anterior",
                            "sNext": "Siguiente"
                        }
                    },
                    "bPaginate": true,
                    "pageLength": 7,
                    buttons: [
                        //{ extend: 'copy', text: "Copiar" },
                        { extend: 'print', text: "Imprimir" },
                        { extend: 'pdf', orientation: 'landscape' },
                        { extend: 'colvis', columns: ':not(:first-child)', text: "Ocultar/Mostrar columnas" }
                    ]
                });
            }
        });   
    }


    
</script>
