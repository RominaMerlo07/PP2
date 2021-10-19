<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InformeObras.aspx.cs" Inherits="TurneroWeb10.InformeObras" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style>

    </style>
    <section class="content-header">
        <h1 style="text-align: center">OBRAS SOCIALES - INFORMES</h1>
    </section>
    <section class="content">
        <div class="box box-primary">
            <div class="box-header">
                <h1 class="box-title">Buscar Turnos por Obra Social</h1>
            </div>
            <div class="box-body">
                <div class="form-row">
                    <div class="col-sm-3 col-md-3 col-lg-3">
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">Sucursal: </span>
                            </div>
                            <select class="custom-select form-control" id="ddlSucursal">
                            </select>
                        </div>
                    </div>                           
                    <div class="col-sm-4 col-md-4 col-lg-4">
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">Obra Social: </span>
                            </div>
                            <select class="custom-select form-control" id="ddlObraSocial">
                            </select>
                        </div>
                    </div>
                    <div class="col-sm-5 col-md-5 col-lg-5 ">
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">Fecha:</span>
                            </div>
                            <div>
                                <input type='text' class="form-control datepicker date" id="dtpFechaDesde"
                                    placeholder="Desde" data-provide="datepicker"
                                    data-date-format="dd/mm/yyyy" />
                            </div>
                            <div>
                                <input type='text' class="form-control datepicker date" id="dtpFechaHasta"
                                    placeholder="Hasta" data-provide="datepicker"
                                    data-date-format="dd/mm/yyyy" />
                            </div>
                        </div>
                    </div>

                </div> 
                <div class="form-row">
                    <div class="col-sm-4 col-md-4 col-lg-4">
                        <button class="btn btn-primary btn-lg " type="button" id="btnBuscar">Buscar   <i class="fas fa-search fa-xs"></i></button>  
                        
                    </div>
                </div>
            </div>
            <div class="box-body table-responsive">
                <div class="col-md-12">
                    <table style="width:100%" class="table table-striped table-hover table-bordered table-secondary" id="tablaTurnosObras">
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
    </section>
    <script type="text/javascript">
    

        $(document).ready(function () {

            $('#dtpFechaDesde').datepicker({ 
                autoclose: true,
                format: "dd/mm/yyyy",
                //startDate: '-30d',
                orientation: 'bottom'
            }).datepicker("setDate",'-30d');

            $('#dtpFechaHasta').datepicker({ 
                autoclose: true,
                format: "dd/mm/yyyy",
                //startDate: '+1d',
                orientation: 'bottom'
            }).datepicker("setDate",'now');

            cargarComboCentros('#ddlSucursal');
            cargarObrasSociales("#ddlObraSocial");

            $('#btnBuscar').click(function () {
                debugger;
                var idSucursal = $('#ddlSucursal').val();
                if (idSucursal == 0) {
                    idSucursal = "";
                }
                var obraSocial = $('#ddlObraSocial').val();
                if (obraSocial == 0) {
                    obraSocial = "";
                }
                var fechaDesde = $('#dtpFechaDesde').val();
                var fechaHasta = $('#dtpFechaHasta').val();

                var turnosArray = [];

                $.ajax({
                    url: "InformeObras.aspx/traerTurnosInformes",
                    data: "{idSucursal: '" + idSucursal + "', idObraSocial: '" + obraSocial + "', fechaDesde: '" + fechaDesde +"', fechaHasta: '" + fechaHasta + "'}",
                    type: "post",
                    contentType: "application/json",
                    async: false,
                    success: function (data) {

                        var turnos = JSON.parse(data.d);

                        turnos.forEach(function (e) {
                            debugger;
                            var Centro = e.CENTRO;
                            var Especialidad = e.ESPECIALIDAD;
                            var Profesional = e.PROFESIONAL;
                            var Paciente = e.PACIENTE;
                            var Documento = e.DOCUMENTO;
                            var ObraSocial = e.OBRA_SOCIAL;
                            var Descripcion = e.DESCRIPCION;
                            var cadena = e.FECHA_TURNO.split('T')
                            var fechaTurno = moment(cadena[0] + ' ' + e.HORA_DESDE, "YYYY-MM-DD HH:mm:ss");
                            var Turno = fechaTurno.format("DD/MM/yyyy HH:mm");
                            var Estado = e.ESTADO;
                            var NroOrden = e.NRO_ORDEN;

                            turnosArray.push([Centro, Especialidad, Profesional, Paciente, Documento, ObraSocial, Descripcion, Turno, Estado, NroOrden])
                        });
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        $(ddl).prop("disabled", true);
                    }
                });

                var table = $('#tablaTurnosObras').DataTable({
                    data: turnosArray,
                    //"scrollX": true,
                    "languaje": {
                        "url": "//cdn.datatables.net/plug-ins/1.10.12/i18n/Spanish.json"
                    },
                    "ordering": true,
                    "bDestroy": true,
                    "bAutoWidth": true,
                    columns: [
                        { title: "Centro"},
                        { title: "Especialidad" },
                        { title: "Profesional" },
                        { title: "Paciente" },
                        { title: "Documento" },
                        { title: "Obra Social" },
                        { title: "Descripcion" },
                        { title: "Turno" },
                        //{ title: "Hora" },
                        { title: "Estado" },
                        { title: "Nro. Orden", visible: false }

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
                    "pageLength": 10,
                    buttons: [
                        { extend: 'print', text: "Imprimir" },
                        { extend: 'pdf', orientation: 'landscape' },
                        { extend: 'colvis', columns: ':not(:first-child)', text: "Ocultar/Mostrar columnas" }
                    ]
                });
            });
            
        });

        function cargarComboCentros(ddl) {
            
            $.ajax({
                url: "InformeObras.aspx/cargarCentros",
                type: "post",
                contentType: "application/json",
                async: false,
                success: function (data) {

                    if (data.d.length > 0) {
                        $(ddl).empty();
                        $(ddl).append('<option value="0"  selected="selected" >TODAS</option>');
                        
                        for (i = 0; i < data.d.length; i++) {

                            $(ddl).append($("<option></option>").val(data.d[i].IdCentro).html(data.d[i].NombreCentro));
                        }
                        //$(ddl).prop("disabled", false);
                    }
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    $(ddl).prop("disabled", true);
                }
            });
        }

        function cargarObrasSociales(ddl) {
            debugger;
            $.ajax({
                url: "InformeObras.aspx/cargarObrasSociales",
                //data: "{idCentro: '" + idCentro + "'}",
                type: "post",
                contentType: "application/json",
                async: false,
                success: function (data) {

                    if (data.d.length > 0) {
                        $(ddl).empty();
                        $(ddl).append('<option value="0" selected="selected" >TODAS</option>');
                        
                        for (i = 0; i < data.d.length; i++) {

                            $(ddl).append($("<option></option>").val(data.d[i].IdObraSocial).html(data.d[i].Descripcion));
                        }
                        //$(ddl).prop("disabled", false);
                    }
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    //$(ddl).prop("disabled", true);
                }
            });
        }
    </script>
</asp:Content>
