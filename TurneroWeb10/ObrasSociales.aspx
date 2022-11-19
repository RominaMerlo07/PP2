<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ObrasSociales.aspx.cs" Inherits="TurneroWeb10.ObrasSociales" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style>
    </style>
    <section class="content-header">
        <h1 style="text-align: center">OBRAS SOCIALES</h1>
    </section>
    <div class="content">
        <div class="row">
            <button class="btn btn-success btn-lg float-right" type="button" id="btnRegistrarModal">Registrar Obra Social</button>
        </div>
        </br>
        <div class="row justify-content-md-center">           
            <div class="col-md">
                <%--<div class="card text-white bg-light">                    
                    <div class="card-header bg-info">--%>
                <div class="box box-primary">
                    <div class="box-header">
                        <h4 class="box-title">Búsqueda</h4>
                    </div>
                    <%--<div class="card-body">--%>
                    <div class="box-body table-responsive">

                        <%--<div class="form-row">
                            <div class="col-sm-4 col-md-4 col-lg-4 ">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Sucursal: </span>
                                    </div>
                                    <select class="custom-select form-control" id="ddlSucursal">
                                    </select>
                                </div>
                            </div> 
                        </div> --%>    
                        <div id="tListaObrasSociales" >
                            <table style="width:100%" class="table table-striped table-hover table-bordered" id="tablaObrasSociales">
                            </table>
                        </div>  
                    </div>
                </div>

            </div>
        </div>
    </div>
    <%--MODAL REGISTRAR OBRA SOCIAL--%>
    <div class="modal fade" tabindex="-1" role="dialog" id ="modalRegistrarObraS" >
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header bg-info text-white">
                    <h4 class="modal-title " id="lblRegistrar" >Alta Obra Social</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>       
                </div>
                <div class="modal-body">
                    <div class="col-md-12" id="">
                        <div class="card text-white ">
                            <div class="card-header ">
                                <h4 class="modal-title text-dark" >Completar datos</h4>
                            </div>
                            <div class="card-body">       
                                <div class="form-row">
                                    <%--<div class="col-sm-6 col-md-6 col-lg-6 ">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">Sucursal: </span>
                                            </div>
                                            <select class="custom-select form-control" id="ddlSucursalRegistrar">
                                            </select>
                                        </div>
                                    </div> --%>
                                    <div class="col-md-6">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">Obra Social: </span>
                                            </div>
                                            <input type="text" class="form-control" id="txtObraSocial" onkeyup="javascript:this.value=this.value.toUpperCase();"/>
                                        </div>
                                    </div>
                                    
                                    <%--<div class="col ">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">Código Plan:</span>
                                            </div>
                                            <input type="text" style="text-align: left" class="form-control" id="txtCelular" onkeyup="javascript:this.value=this.value.toUpperCase();"/>
                                        </div>
                                    </div>--%>
                                </div>
                                <div class="form-row">
                                    <div class="col-md text-right">
                                        <button class="btn btn-success btn-lg" type="button" id="btnRegistrarObraS">Registrar Obra Social</button>      
                                    </div>
                                </div>                                             
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%-- FIN MODAL REGISTRAR OBRA SOCIAL--%>

    <%--MODAL EDITAR OBRA SOCIAL--%>
    <div class="modal fade" tabindex="-1" role="dialog" id ="modalEditarObraS" >
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
              <div class="modal-header bg-info text-white">
                <h4 class="modal-title " id="lblObraSocial" ></h4>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>       
              </div>
                <div class="modal-body">
                    <div class="col-md-12" id="">
                        <div class="card text-white ">
                            <div class="card-header ">
                                <h4 class="modal-title text-dark" >Agregar Plan</h4>
                            </div>
                            <div class="card-body">       
                                <div class="form-row">
                                    <div class="col-md-6">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">Plan: </span>
                                            </div>
                                            <input type="text" class="form-control" id="txtPlan" onkeyup="javascript:this.value=this.value.toUpperCase();"/>
                                        </div>
                                    </div>
                                    <%--<div class="col ">
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">Código Plan:</span>
                                            </div>
                                            <input type="text" style="text-align: left" class="form-control" id="txtCelular" onkeyup="javascript:this.value=this.value.toUpperCase();"/>
                                        </div>
                                    </div>--%>
                                    <div class="col-md-6 text-right">
                                        <button class="btn btn-success" type="button" id="btnGuardarPlan">Guardar Plan</button>      
                                    </div>
                                </div>                                             
                            </div>
                        </div>
                        </br>
                        <div id="tListarTurnos">
                            <table style="width:100%" class="table table-striped table-bordered" id="tablaPlanesOS">
                            </table>
                        </div> 
                    </div>
                </div>
                <br />
            </div>
        </div>
    </div>
    <%-- FIN MODAL EDITAR OBRA SOCIAL--%>
    <script type="text/javascript">

        var idObraSocial;

        $(document).ready(function () {

            //cargarComboCentros('#ddlSucursal');
            //cargarComboCentros('#ddlSucursalRegistrar');
            //$('#ddlSucursal').val('1');
            cargarTablaObrasSociales();


            //$("#ddlSucursal").bind("change", function () {
            //    cargarTablaObrasSociales();
            //});

            
            $('#btnRegistrarModal').click(function () {

                $("#modalRegistrarObraS").modal('show');

            });

            $('#btnRegistrarObraS').click(function () {

                var obraSocAgregar = $("#txtObraSocial").val();

                $.ajax({
                    url: "ObrasSociales.aspx/agregarObraSocial",
                    data: "{obraSocial: '" + obraSocAgregar + "'}",
                    type: "post",
                    contentType: "application/json",
                    async: false,
                    success: function (data) {

                        swal("Hecho", "Se agregó la Obra Social correctamente.", "success");
                        $("#txtObraSocial").val(""); //limpia campo
                        cargarTablaObrasSociales();
                        $("#modalRegistrarObraS").modal('hide');
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert(data.error);
                    }
                });
            });


            $('#btnGuardarPlan').click(function () {

                var nombrePlan = $("#txtPlan").val();

                $.ajax({
                    url: "ObrasSociales.aspx/agregarPlan",
                    data: "{idObraSocial: '" + idObraSocial + "', nombrePlan: '" + nombrePlan + "'}",
                    type: "post",
                    contentType: "application/json",
                    async: false,
                    success: function (data) {

                        swal("Hecho", "Se agregó el plan correctamente.", "success");

                        $("#txtPlan").val(""); //limpia campo

                        cargarTablaPlanes(idObraSocial);            
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert(data.error);
                    }
                });

            })

        });

        function cargarTablaObrasSociales() {

            $.ajax({
                url: "ObrasSociales.aspx/traerObrasSociales",
                //data: "{idCentro: '" + idSucursal + "'}",
                type: "post",
                contentType: "application/json",
                async: false,
                success: function (data) {

                    var datos = JSON.parse(data.d);
                    var obras = [];
                    datos.forEach(function (e)
                    {
                        var idObSocial = e.IdObraSocial;
                        var obraSocial = e.Descripcion;
                        //var Centro = e.Centro.NombreCentro;
                        var Acciones = '<a href="#" onclick="return actualizar(' + idObSocial + ",'" + obraSocial + "'" + ')"  class="btn btn-primary" > <span class="fa fa-pencil" title="Editar"></span></a > ' +
                        '<a href="#" onclick="return inactivar(' + idObSocial + ",'" + obraSocial + "'" + ')"  class="btn btn-danger btnInactivar" > <span class="fa fa-trash" title="Dar de baja"></span></a > ';

                        obras.push([idObSocial, obraSocial, /*Centro,*/ Acciones]);                                    
                    });

                    var table = $('#tablaObrasSociales').DataTable({
                        data: obras,
                        "scrollX": true,
                        "languaje": {
                            "url": "//cdn.datatables.net/plug-ins/1.10.12/i18n/Spanish.json"
                        },
                        "ordering": true,
                        "bDestroy": true,
                        "bAutoWidth": true,
                        columns: [
                            { title: "ID", visible: false },
                            { title: "Obra Social", visible: true },
                            //{ title: "Centro", visible: true },
                            { title: "Acciones" }
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
            }); 
        }

        function actualizar(idObra, obraSocial) {

            idObraSocial = idObra;
            $("#modalEditarObraS").modal('show');

            $("#lblObraSocial").text(obraSocial);

            cargarTablaPlanes(idObra);            
        }

        function inactivar(idObraSocial, obraSocial) {
            $.ajax({
                url: "ObrasSociales.aspx/darBajaObraSocial",
                data: "{idObraSocial: '" + idObraSocial + "'}",
                type: "post",
                contentType: "application/json",
                async: false,
                success: function (data) {

                    swal("Hecho", "Se dio de baja a " + obraSocial + " y sus planes.", "success");

                    cargarTablaObrasSociales();
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    alert(data.error);
                }
            });
        }

        function cargarTablaPlanes(idObraSocial) {

            $.ajax({
                type: "POST",
                url: "ObrasSociales.aspx/traerPlanes",
                data: "{idObraSocial: '" + idObraSocial + "'}",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                async: false,
                success: function (data) {

                    var planes = JSON.parse(data.d);
                    var planesArr = [];
                    if (planes.length > 0)
                    {
                        planes.forEach(function (e)
                        {
                            var idPlanObra = e.ID_PLANES;
                            var descripcion = e.DESCRIPCION;
                            var fechaBaja = null;
                            var Acciones = '';

                            if (e.FECHA_BAJA == null) {
                                Acciones = '<a href="#" onclick="return inactivarPlan(' + idPlanObra + ",'" + descripcion + "'" + ",'" + idObraSocial + "'" + ')"  class="btn btn-danger btnInactivar" > <span class="fa fa-trash" title="Dar de baja"></span></a > ';
                            } else {
                                fechaBaja = moment(e.FECHA_BAJA).format("DD/MM/yyyy");
                            }
                                
                            planesArr.push([idPlanObra, descripcion, fechaBaja, Acciones]);                                    
                        });
                    }

                    var table = $('#tablaPlanesOS').DataTable({
                        data: planesArr,
                        "scrollX": false,
                        "languaje": {
                            "url": "//cdn.datatables.net/plug-ins/1.10.12/i18n/Spanish.json"
                        },
                        "ordering": true,
                        "bDestroy": true,
                        "bAutoWidth": true,
                        columns: [
                            { title: "ID", visible: false },
                            { title: "Plan", visible: true },
                            { title: "Fecha de Baja", visible: true },
                            { title: "Acciones" }
                        ],
                        dom: '<"top"B>rti<"bottom"fp><"clear">',
                        "oLanguage": {
                            "sSearch": "Filtrar:",
                            "oPaginate": {
                                "sPrevious": "Anterior",
                                "sNext": "Siguiente"
                            }
                        },
                        "rowCallback": function (row, data, index) {
                            if (data[2] != null) { //tiene fecha de baja

                                $('td', row).css('background-color', '#C40000');
                                $('td', row).css('color', 'rgba(255, 255, 255, .8)');
                                $('td', row).css('pointer-events', 'none');

                            }
                        },
                        "bPaginate": true,
                        "pageLength": 3,
                        buttons: [
                            { extend: 'colvis', columns: ':not(:first-child)', text: "Ocultar/Mostrar columnas" }
                        ]
                    });
                    $('.dataTables_filter input').attr("placeholder", "Filtrar por...");
                },
                error: function (xhr, ajaxOptions, thrownError) {

                }
            })
        }

        function inactivarPlan(idPlan, descripcion, idObraSocial) {
            $.ajax({
                url: "ObrasSociales.aspx/darBajaPlan",
                data: "{idPlan: '" + idPlan + "'}",
                type: "post",
                contentType: "application/json",
                async: false,
                success: function (data) {

                    swal("Hecho", "Se dio de baja a " + descripcion + " y sus planes.", "success");

                    cargarTablaPlanes(idObraSocial);
                },
                error: function (xhr, ajaxOptions, thrownError) {
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

    </script>
</asp:Content>