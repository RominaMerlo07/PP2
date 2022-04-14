<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionSeguimientoPacientes.aspx.cs" Inherits="TurneroWeb10.GestionSeguimientoPacientes" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        input .checkbox {
            background: #ffffff
        }
        textarea {
            resize: none;
        }
    </style>
    <section class="content-header">
        <h1 style="text-align: left">SEGUIMIENTO DEL PACIENTE</h1>
    </section>
    <div class="content" id="sectionEspecialidad">
        </br>
        <div class="justify-content-md-center">           
            <%--<div class="col-md">--%>
            <div class="box box-primary">
                <div class="box-header">
                    <h4 class="box-title">Buscar por:</h4>
                </div>
                <div class="form-row ml-2">
                    <div class="col-sm-4 col-md-4 col-lg-4 ">
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">Nro. Documento: </span>
                            </div>
                            <input type="search" class="form-control rounded" id="txtDocumentoFiltrar" placeholder="Ingrese DNI" aria-label="Search"
                                aria-describedby="search-addon" onkeypress="return soloNumeros(event)"/>
                            <button class="btn btn-outline-secondary" id="btnBuscarDNIFiltrar" type="button">
                                <i class="fas fa-search"></i>
                            </button>
                        </div>
                    </div>   

                    <div class="col-sm-4 col-md-4 col-lg-4 ">
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">Nombre Paciente: </span>
                            </div>
                            <input type="text" style="text-align: left" class="form-control" id="txtPacienteFiltrar" disabled="disabled" />                                            
                        </div>
                    </div>
                    <div class="col-sm-4 col-md-4 col-lg-4" style="display:none">
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">Id Paciente:</span>
                            </div>
                            <input type="text" style="text-align: left" class="form-control" id="txtIdPacienteFiltrar"/>
                        </div> 
                    </div>
                </div>
                <div class="alert alert-danger m-3" role="alert" id="msgSinHC" style="display:none">
                    Aun no se ha iniciado el seguimiento del paciente.
                </div>
                <div class="alert alert-danger m-3" role="alert" id="msgCargarPaciente" style="display:none">
                    El paciente que busca no está registrado. Primero debe registrar el paciente.
                </div>
                <div class="form-row ml-2 ">
                    <div class="col" id="btnIniciaHC" style="display:none">
                        <div class="input-group mb-3">
                            <button class="btn btn-success btn-lg" type="button" id="btnIniciarSeguimiento">Iniciar Seguimiento</button>
                        </div>
                    </div>
                </div>

                <%--<div class="box-body table-responsive" style="display:none">
                    <div class="col-md-12">
                        <div class="table table-striped table-hover">   
                            <div id="tGestionSeguimiento" >
                                <table style="width:100%" class="table table-striped table-hover table-bordered table-secondary" id="tablaSeguimientos">
                                </table>
                            </div>  
                        </div>
                    </div>
                </div>--%>
            </div>
            <div class="box box-primary" id="boxAntecedentes" style="display:none">
                <div class="box-header">
                    <h4 class="box-title" id="ttlAntecedentes">Antecedentes del paciente:</h4>
                    <a class="btn btn-light float-right" id="btcColAntecedentes" data-toggle="collapse" href="#collapseExample" aria-expanded="false" aria-controls="collapseExample">
                        <i class="fas fa-angle-down" id="icnColAntecedentes" ></i>
                    </a>
                </div>
                <div class="collapse" id="collapseExample">
                    <div class="card-body">
                        <div class="form-row">
                            <div class="col-sm-2 col-md-2 col-lg-2">
                                <div class="checkbox float-right">
                                    <label class=" text-black " >
                                        Tensión Arterial:
                                    </label>
                                    <input type="checkbox" class="flat-green "id="chkTensionM"/>
                                </div> 
                            </div>
                            <div class="col-sm-4 col-md-4 col-lg-4" id="valoresTensionM" style="display:none" >
                                <div class="input-group mb-3 pull-right">
                                    <label class="input-group-prepend text-black  ">
                                        Valores:
                                        <input style="text-align: left" class=" form-control input-sm ml-2 mr-2" id="txtTensionV1M" type="text"/>
                                        /
                                        <input style="text-align: left" class=" form-control input-sm ml-2" id="txtTensionV2M" type="text"  />
                                    </label>
                                            
                                </div> 
                            </div>

                            <div class="col-sm-2 col-md-2 col-lg-2 ">
                                <div class="checkbox float-right">
                                    <label class="text-black mr-2" >
                                        Diabetes:
                                    </label>
                                    <input type="checkbox" class="flat-green ml-2" id="chkDiabetesM"/>
                                </div> 
                            </div>

                            <div class="col-sm-2 col-md-2 col-lg-2">
                                <div class="checkbox float-right">
                                    <label class="text-black mr-2" >
                                        Fumador:
                                    </label>
                                    <input type="checkbox" class="flat-green ml-2" id="chkFumadorM"/>
                                </div> 
                            </div>
                                    
                            <div class="col-sm-2 col-md-2 col-lg-2">
                                <div class="checkbox float-right">
                                    <label class="text-black mr-2" >
                                        Cardíaco:
                                    </label>
                                    <input type="checkbox" class="flat-green ml-2" id="chkCardiacoM"/>
                                </div> 
                            </div>
                        </div>
                        </br>
                        <div class="form-row">
                            <div class="col-sm-2 col-md-2 col-lg-2">
                                <div class="checkbox float-right">
                                    <label class="text-black mr-2 " >
                                        Cirrosis:
                                    </label>
                                    <input type="checkbox" class="flat-green ml-2" id="chkCirrosisM"/>
                                </div> 
                            </div> 
                            <div class="col-sm-2 col-md-2 col-lg-2">
                                <div class="checkbox float-right">
                                    <label class="text-black mr-2 " >
                                        Artrosis:
                                    </label>
                                    <input type="checkbox" class="flat-green ml-2" id="chkArtrosisM"/>
                                </div> 
                            </div>
                            <div class="col-sm-2 col-md-2 col-lg-2">
                                <div class="checkbox float-right">
                                    <label class="text-black mr-2 " >
                                        Artritis </br> Reumatoidea:
                                    </label>
                                    <input type="checkbox" class="flat-green ml-2" id="chkArtritisReumaM"/>
                                </div> 
                            </div>
                            <div class="col-sm-2 col-md-2 col-lg-2">
                                <div class="checkbox float-right">
                                    <label class="text-black mr-2 " >
                                        Hemiplejía:
                                    </label>
                                    <input type="checkbox" class="flat-green ml-2" id="chkHemiplejiaM"/>
                                </div> 
                            </div>
                            <div class="col-sm-2 col-md-2 col-lg-2">
                                <div class="checkbox float-right">
                                    <label class="text-black mr-2 " >
                                        Asma:
                                    </label>
                                    <input type="checkbox" class="flat-green ml-2" id="chkAsmaM"/>
                                </div> 
                            </div>
                            <div class="col-sm-2 col-md-2 col-lg-2">
                                <div class="checkbox float-right">
                                    <label class="text-black mr-2 " >
                                        Marcapasos:
                                    </label>
                                    <input type="checkbox" class="flat-green ml-2" id="chkMarcapasosM"/>
                                </div> 
                            </div>
                        </div>
                        </br>
                        <div class="form-row">
                            <div class="col-sm-2 col-md-2 col-lg-2">
                                <div class="checkbox float-right">
                                    <label class="text-black mr-2 " >
                                        Usa Prótesis:
                                    </label>
                                    <input type="checkbox" class="flat-green ml-2" id="chkProtesisM"/>
                                </div> 
                            </div>
                            <div class="col-sm-2 col-md-2 col-lg-2">
                                <div class="checkbox float-right">
                                    <label class="text-black mr-2 " >
                                        Reemplazo de </br> Cadera Derecha:
                                    </label>
                                    <input type="checkbox" class="flat-green ml-2" id="chkCaderaDerM"/>
                                </div> 
                            </div>
                            <div class="col-sm-2 col-md-2 col-lg-2">
                                <div class="checkbox float-right">
                                    <label class="text-black mr-2 " >
                                        Reemplazo de </br> Cadera Izquierda:
                                    </label>
                                    <input type="checkbox" class="flat-green ml-2" id="chkCaderaIzqM"/>
                                </div> 
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col-sm col-md col-lg">
                                <div class="form-group">
                                    <label class="text-black mr-2 " >
                                        Otros:
                                    </label>
                                    <textarea class="form-control" id="txtAOtrosM" rows="3" maxlength="300"></textarea>
                                    <label class="text-black mr-2" id="lblAOtrosM" style="display:none">
                                        0/300
                                    </label>
                                </div> 
                            </div>
                        </div> 
                        <div class="form-row">
                            <div class="col-sm col-md col-lg">
                                <div class="form-group">
                                    <label class="text-black mr-2 " >
                                        Antecedentes:
                                    </label>
                                    <textarea class="form-control" id="txtAAntecedentesM" rows="3" maxlength="300"></textarea>
                                    <label class="text-black mr-2" id="lblAAntecedentesM" style="display:none">
                                        0/300
                                    </label> 
                                </div> 
                            </div>
                        </div>
                        <div class="form-row ">
                            <div class="col">
                                <button class="btn btn-success btn-lg  float-right" type="button" id="btnAntecedentesGuardar">Guardar cambios</button>  
                            </div>
                        </div>
                        
                    </div>
                </div>
            </div>
            <%--</div>--%>
        </div>
    </div>

    <%--MODAL GENERAR TRATAMIENTO--%>
    <div class="modal fade" tabindex="-1" role="dialog" id ="modalIniciaSeguimiento" >
        <div class="modal-dialog modal-xl" role="document">
            <div class="modal-content">
                <div class="modal-header bg-info text-white">
                    <h4 class="modal-title " id="lblTituloTurno">Iniciar Seguimiento</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>       
                </div>
                <div class="modal-body">
                    <div class="col-md-12" id="crdPaciente2">
                        <div class="card text-white ">
                            <div class="card-header ">
                                <h4 class="modal-title text-dark" id="hNombrePaciente">Datos del Paciente</h4>
                            </div>
                            <div class="card-body">
                                <div class="form-row">
                                    <div class="col-sm-2 col-md-2 col-lg-2">
                                        <div class="checkbox float-right">
                                            <label class=" text-black " >
                                                Tensión Arterial:
                                            </label>
                                            <input type="checkbox" class="flat-green "id="chkTension"/>
                                        </div> 
                                    </div>
                                    <div class="col-sm-4 col-md-4 col-lg-4" id="valoresTension" style="display:none" >
                                        <div class="input-group mb-3 pull-right">
                                            <label class="input-group-prepend text-black  ">
                                                Valores:
                                                <input style="text-align: left" class=" form-control input-sm ml-2 mr-2" id="txtTensionV1" type="text"/>
                                                /
                                                <input style="text-align: left" class=" form-control input-sm ml-2" id="txtTensionV2" type="text"  />
                                            </label>
                                            
                                        </div> 
                                    </div>

                                    <div class="col-sm-2 col-md-2 col-lg-2 ">
                                        <div class="checkbox float-right">
                                            <label class="text-black mr-2" >
                                                Diabetes:
                                            </label>
                                            <input type="checkbox" class="flat-green ml-2" id="chkDiabetes"/>
                                        </div> 
                                    </div>

                                    <div class="col-sm-2 col-md-2 col-lg-2">
                                        <div class="checkbox float-right">
                                            <label class="text-black mr-2" >
                                                Fumador:
                                            </label>
                                            <input type="checkbox" class="flat-green ml-2" id="chkFumador"/>
                                        </div> 
                                    </div>
                                    
                                    <div class="col-sm-2 col-md-2 col-lg-2">
                                        <div class="checkbox float-right">
                                            <label class="text-black mr-2" >
                                                Cardíaco:
                                            </label>
                                            <input type="checkbox" class="flat-green ml-2" id="chkCardiaco"/>
                                        </div> 
                                    </div>
                                </div>
                                </br>
                                <div class="form-row">
                                    <div class="col-sm-2 col-md-2 col-lg-2">
                                        <div class="checkbox float-right">
                                            <label class="text-black mr-2 " >
                                                Cirrosis:
                                            </label>
                                            <input type="checkbox" class="flat-green ml-2" id="chkCirrosis"/>
                                        </div> 
                                    </div> 
                                    <div class="col-sm-2 col-md-2 col-lg-2">
                                        <div class="checkbox float-right">
                                            <label class="text-black mr-2 " >
                                                Artrosis:
                                            </label>
                                            <input type="checkbox" class="flat-green ml-2" id="chkArtrosis"/>
                                        </div> 
                                    </div>
                                    <div class="col-sm-2 col-md-2 col-lg-2">
                                        <div class="checkbox float-right">
                                            <label class="text-black mr-2 " >
                                                Artritis </br> Reumatoidea:
                                            </label>
                                            <input type="checkbox" class="flat-green ml-2" id="chkArtritisReuma"/>
                                        </div> 
                                    </div>
                                    <div class="col-sm-2 col-md-2 col-lg-2">
                                        <div class="checkbox float-right">
                                            <label class="text-black mr-2 " >
                                                Hemiplejía:
                                            </label>
                                            <input type="checkbox" class="flat-green ml-2" id="chkHemiplejia"/>
                                        </div> 
                                    </div>
                                    <div class="col-sm-2 col-md-2 col-lg-2">
                                        <div class="checkbox float-right">
                                            <label class="text-black mr-2 " >
                                                Asma:
                                            </label>
                                            <input type="checkbox" class="flat-green ml-2" id="chkAsma"/>
                                        </div> 
                                    </div>
                                    <div class="col-sm-2 col-md-2 col-lg-2">
                                        <div class="checkbox float-right">
                                            <label class="text-black mr-2 " >
                                                Marcapasos:
                                            </label>
                                            <input type="checkbox" class="flat-green ml-2" id="chkMarcapasos"/>
                                        </div> 
                                    </div>
                                </div>
                                </br>
                                <div class="form-row">
                                    <div class="col-sm-2 col-md-2 col-lg-2">
                                        <div class="checkbox float-right">
                                            <label class="text-black mr-2 " >
                                                Usa Prótesis:
                                            </label>
                                            <input type="checkbox" class="flat-green ml-2" id="chkProtesis"/>
                                        </div> 
                                    </div>
                                    <div class="col-sm-2 col-md-2 col-lg-2">
                                        <div class="checkbox float-right">
                                            <label class="text-black mr-2 " >
                                                Reemplazo de </br> Cadera Derecha:
                                            </label>
                                            <input type="checkbox" class="flat-green ml-2" id="chkCaderaDer"/>
                                        </div> 
                                    </div>
                                    <div class="col-sm-2 col-md-2 col-lg-2">
                                        <div class="checkbox float-right">
                                            <label class="text-black mr-2 " >
                                                Reemplazo de </br> Cadera Izquierda:
                                            </label>
                                            <input type="checkbox" class="flat-green ml-2" id="chkCaderaIzq"/>
                                        </div> 
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="col-sm col-md col-lg">
                                        <div class="form-group">
                                            <label class="text-black mr-2 " >
                                                Otros:
                                            </label>
                                            <textarea class="form-control" id="txtAOtros" rows="3" maxlength="300"></textarea>
                                            <label class="text-black mr-2" id="lblAOtros">
                                                0/300
                                            </label>
                                        </div> 
                                    </div>
                                </div> 
                                <div class="form-row">
                                    <div class="col-sm col-md col-lg">
                                        <div class="form-group">
                                            <label class="text-black mr-2 " >
                                                Antecedentes:
                                            </label>
                                            <textarea class="form-control" id="txtAAntecedentes" rows="3" maxlength="300"></textarea>
                                            <label class="text-black mr-2" id="lblAAntecedentes">
                                                0/300
                                            </label> 
                                        </div> 
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <div class="modal-footer">
                    <div class="row float-right">
                
                        <button class="btn btn-success btn-lg " type="button" id="btnCargarHC">Guardar</button>      
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">

        var tensionRegistrar = false; var diabetesRegistrar = false; var fumadorRegistrar = false; var cardiacoRegistrar = false;
        var cirrosisRegistrar = false; var artrosisRegistrar = false; var artritisRegistrar = false;
        var hemiplejiaRegistrar = false; var asmaRegistrar = false; var marcapasosRegistrar = false;
        var protesisRegistrar = false; var caderaDerRegistrar = false; var caderaIzqRegistrar = false;
        var paciente;

        $(document).ready(function () {

            $('input').iCheck({
                checkboxClass: 'icheckbox_flat-green'
            });

            //$('#modalIniciaSeguimiento').modal('show'); // quitar

            $('#btnBuscarDNIFiltrar').click(function () {

                var dniPaciente = $('#txtDocumentoFiltrar').val();
                var historiaClinica = buscarPacienteFiltrar(dniPaciente);

                if ($('#txtPacienteFiltrar').val() != "") {

                    $('#msgCargarPaciente').hide();

                    if (historiaClinica != null)
                    {
                        $('#msgSinHC').hide();
                        $('#btnIniciaHC').hide();
                        // muestra datos de HC
                        mostrarDatosHC(historiaClinica, paciente);
                        $("#btcColAntecedentes").click();
                        // busca tratamientos
                        // muestra tabla con tratamientos
                    } else
                    {
                        //muestra btn para cargarla
                        $('#msgSinHC').show();
                        $('#btnIniciaHC').show();
                        $('#boxAntecedentes').hide();
                    }
                }
                else
                {
                    $('#msgCargarPaciente').show();
                }
            });

            $('#btnIniciarSeguimiento').click(function ()
            {

                $('#modalIniciaSeguimiento').modal('show');

            });

            $('#btnAntecedentesGuardar').click(function ()
            {


            });
            
            //#region controles Registrar
            $('#chkTension').on('ifChecked ', function (event) {
                $('#valoresTension').show();
                $('#txtTensionV1').val('');
                $('#txtTensionV2').val('');
                tensionRegistrar = true;
            });
            $('#chkTension').on('ifUnchecked ', function (event) {
                $('#valoresTension').hide();
                tensionRegistrar = false;
            });

            $('#chkDiabetes').on('ifChecked ', function (event) {
                diabetesRegistrar = true;
            });

            $('#chkDiabetes').on('ifUnchecked ', function (event) {
                diabetesRegistrar = false;
            });

            $('#chkFumador').on('ifChecked ', function (event) {
                fumadorRegistrar = true;
            });

            $('#chkFumador').on('ifUnchecked ', function (event) {
                fumadorRegistrar = false;
            });
            
            $('#chkCardiaco').on('ifChecked ', function (event) {
                cardiacoRegistrar = true;
            });

            $('#chkCardiaco').on('ifUnchecked ', function (event) {
                cardiacoRegistrar = false;
            });
            
            $('#chkCirrosis').on('ifChecked ', function (event) {
                cirrosisRegistrar = true;
            });

            $('#chkCirrosis').on('ifUnchecked ', function (event) {
                cirrosisRegistrar = false;
            });
            
            $('#chkArtrosis').on('ifChecked ', function (event) {
                artrosisRegistrar = true;
            });

            $('#chkArtrosis').on('ifUnchecked ', function (event) {
                artrosisRegistrar = false;
            });
            
            $('#chkArtritisReuma').on('ifChecked ', function (event) {
                artritisRegistrar = true;
            });

            $('#chkArtritisReuma').on('ifUnchecked ', function (event) {
                artritisRegistrar = false;
            });
            
            $('#chkHemiplejia').on('ifChecked ', function (event) {
                hemiplejiaRegistrar = true;
            });

            $('#chkHemiplejia').on('ifUnchecked ', function (event) {
                hemiplejiaRegistrar = false;
            });
            
            $('#chkAsma').on('ifChecked ', function (event) {
                asmaRegistrar = true;
            });

            $('#chkAsma').on('ifUnchecked ', function (event) {
                asmaRegistrar = false;
            });
            
            $('#chkMarcapasos').on('ifChecked ', function (event) {
                marcapasosRegistrar = true;
            });

            $('#chkMarcapasos').on('ifUnchecked ', function (event) {
                marcapasosRegistrar = false;
            });
            
            $('#chkProtesis').on('ifChecked ', function (event) {
                protesisRegistrar = true;
            });

            $('#chkProtesis').on('ifUnchecked ', function (event) {
                protesisRegistrar = false;
            });
            
            $('#chkCaderaDer').on('ifChecked ', function (event) {
                caderaDerRegistrar = true;
            });

            $('#chkCaderaDer').on('ifUnchecked ', function (event) {
                caderaDerRegistrar = false;
            });
            
            $('#chkCaderaIzq').on('ifChecked ', function (event) {
                caderaIzqRegistrar = true;
            });

            $('#chkCaderaIzq').on('ifUnchecked ', function (event) {
                caderaIzqRegistrar = false;
            });           

            var txtAOtros = document.getElementById("txtAOtros");
            txtAOtros.addEventListener("input", event => {
                
                const target = event.currentTarget;
                const maxLength = target.getAttribute("maxlength");
                const currentLength = target.value.length;

                if (currentLength > maxLength) {
                    return $('#lblAOtros').html('Ha excedido el límite de caracteres permitido.'); 
                }
                $('#lblAOtros').html(currentLength+'/300');  
            });
            
            var txtAAntecedentes = document.getElementById("txtAAntecedentes");
            txtAAntecedentes.addEventListener("input", event => {
                
                const target = event.currentTarget;
                const maxLength = target.getAttribute("maxlength");
                const currentLength = target.value.length;

                if (currentLength > maxLength) {
                    return  $('#lblAAntecedentes').html('Ha excedido el límite de caracteres permitido.');  

                }
                $('#lblAAntecedentes').html(currentLength+'/300');  
            });
            //#endregion

            //#region controles Editar

            $("#btcColAntecedentes").click(function(e) {
                var menuItem = $(this);

                if (menuItem.attr("aria-expanded") === "true") {
                    $("#icnColAntecedentes").removeClass();
                    $("#icnColAntecedentes").addClass('fas fa-angle-down');
                }
                else if (menuItem.attr("aria-expanded") === "false") {
                    $("#icnColAntecedentes").removeClass();
                    $("#icnColAntecedentes").addClass('fas fa-angle-up');
                }
            });

            $('#chkTensionM').on('ifChecked ', function (event) {
                $('#valoresTensionM').show();
                //$('#txtTensionV1M').val('');
                //$('#txtTensionV2M').val('');

            });
            $('#chkTensionM').on('ifUnchecked ', function (event) {
                $('#valoresTensionM').hide();

            });

            var txtAOtrosM = document.getElementById("txtAOtrosM");
            txtAOtrosM.addEventListener("input", event => {
                
                const target = event.currentTarget;
                const maxLength = target.getAttribute("maxlength");
                const currentLength = target.value.length;

                if (currentLength > maxLength) {
                    return $('#lblAOtrosM').html('Ha excedido el límite de caracteres permitido.'); 
                }
                $('#lblAOtrosM').html(currentLength + '/300');
                $('#lblAOtrosM').show();
            });
            
            var txtAAntecedentesM = document.getElementById("txtAAntecedentesM");
            txtAAntecedentesM.addEventListener("input", event => {
                
                const target = event.currentTarget;
                const maxLength = target.getAttribute("maxlength");
                const currentLength = target.value.length;

                if (currentLength > maxLength) {
                    return  $('#lblAAntecedentesM').html('Ha excedido el límite de caracteres permitido.');  

                }
                $('#lblAAntecedentesM').html(currentLength + '/300');  
                $('#lblAAntecedentesM').show();
            });
            //#endregion
            $('#btnCargarHC').click(function ()
            {
                var idPaciente = $('#txtIdPacienteFiltrar').val();
                var tensionValores = $('#txtTensionV1').val() + "/" + $('#txtTensionV2').val();
                var otros = $('#txtAOtros').val();
                var antecedentes = $('#txtAAntecedentes').val();

                var historiaClinica = {
                    p_idPaciente: idPaciente,
                    p_tension: tensionRegistrar,
                    p_tension_valores: tensionValores,
                    p_diabetes: diabetesRegistrar,
                    p_fumador: fumadorRegistrar, 
                    p_cardiaco: cardiacoRegistrar,
                    p_cirrosis: cirrosisRegistrar,
                    p_artrosis: artrosisRegistrar,
                    p_artritis: artritisRegistrar,
                    p_hemiplejia: hemiplejiaRegistrar,
                    p_asma: asmaRegistrar,
                    p_marcapasos: marcapasosRegistrar,
                    p_protesis: protesisRegistrar,
                    p_caderaDer: caderaDerRegistrar,
                    p_caderaIzq: caderaIzqRegistrar,
                    p_otros: otros,
                    p_antecedentes: antecedentes,

                    p_nombrePaciente: paciente.Nombre,
                    p_apellidoPaciente: paciente.Apellido,
                    p_documentoPaciente: paciente.Documento,
                    p_nroPaciente: paciente.NroContacto,
                    p_emailPaciente: paciente.EmailContacto
                };
                
                $.ajax({
                    url: "GestionSeguimientoPacientes.aspx/registrarHistoriaClinica",
                    data: "{historiaClinica: '" + JSON.stringify(historiaClinica)
                        + "'}",
                    type: "post",
                    contentType: "application/json",
                    async: false,
                    success: function (data) {

                        $("#modalGenerarTratamiento").modal('hide');
                        swal("Hecho", "Tratamiento registrado con éxito!", "success");

                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        swal("Cuidado", "Ha habido un error al registrar el Tratamiento.", "warning");
                    }
                });
            });
            
            
        });

        function buscarPacienteFiltrar(dniPaciente)
        {
            var historiaClinica;

            $.ajax({
                url: "GestionSeguimientoPacientes.aspx/buscarPaciente",
                data: "{dniPaciente: '" + dniPaciente + "'}",
                type: "post",
                contentType: "application/json",
                async: false,
                success: function (data) {
                    paciente = JSON.parse(data.d);
                    var datosPaciente;

                    if (data.d != "null")
                    {
                        datosPaciente = paciente.Apellido + " " + paciente.Nombre;
                        $('#txtIdPacienteFiltrar').val(paciente.IdPaciente);
                        $('#hNombrePaciente').html("Carga de Antecedentes de " + datosPaciente + ". DNI: " + paciente.Documento);
                      
                        historiaClinica = paciente.HistoriaClinica;

                    } else {
                        datosPaciente = "";
                        //swal("Paciente no encontrado", "Por favor primero registre al paciente.", "warning");
                    }
                    $('#txtPacienteFiltrar').val(datosPaciente);
                }
            }); 

            return historiaClinica;
        }
    
        function mostrarDatosHC(historiaClinica, paciente)
        {
            limpiarAntecedentes()
            $('#boxAntecedentes').show();

            $('#ttlAntecedentes').html("Antecedentes de " + paciente.Nombre + " " + paciente.Apellido);

            cargarValoresAntecedentes(historiaClinica);
            

        }

        function cargarValoresAntecedentes(historiaClinica)
        {
            if (historiaClinica.Tension == true) {
                $("#chkTensionM").iCheck('check');

                var valores = historiaClinica.TensionValores;
                var arrayvalores = valores.split('/');
                $('#valoresTensionM').show();
                $('#txtTensionV1M').val(arrayvalores[0]);
                $('#txtTensionV2M').val(arrayvalores[1]);
            } else {
                $("#chkTensionM").iCheck('uncheck');
                $('#valoresTensionM').hide();
            }

            if (historiaClinica.Diabetes == true) {
                $("#chkDiabetesM").iCheck('check');
            } else {
                $("#chkDiabetesM").iCheck('uncheck');
            }

            if (historiaClinica.Fumador == true) {
                $("#chkFumadorM").iCheck('check');
            } else {
                $("#chkFumadorM").iCheck('uncheck');
            }

            if (historiaClinica.Cardiaco == true) {
                $("#chkCardiacoM").iCheck('check');
            } else {
                $("#chkCardiacoM").iCheck('uncheck');
            }
            
            if (historiaClinica.Cirrosis == true) {
                $("#chkCirrosisM").iCheck('check');
            } else {
                $("#chkCirrosisM").iCheck('uncheck');
            }
            
            if (historiaClinica.Artrosis == true) {
                $("#chkArtrosisM").iCheck('check');
            } else {
                $("#chkArtrosisM").iCheck('uncheck');
            }
            
            if (historiaClinica.ArtritisRematoidea == true) {
                $("#chkArtritisReumaM").iCheck('check');
            } else {
                $("#chkArtritisReumaM").iCheck('uncheck');
            }
            
            if (historiaClinica.Hemiplejia == true) {
                $("#chkHemiplejiaM").iCheck('check');
            } else {
                $("#chkHemiplejiaM").iCheck('uncheck');
            }

            if (historiaClinica.Asma == true) {
                $("#chkAsmaM").iCheck('check');
            } else {
                $("#chkAsmaM").iCheck('uncheck');
            }
            
            if (historiaClinica.Marcapasos == true) {
                $("#chkMarcapasosM").iCheck('check');
            } else {
                $("#chkMarcapasosM").iCheck('uncheck');
            }
            
            if (historiaClinica.Protesis == true) {
                $("#chkProtesisM").iCheck('check');
            } else {
                $("#chkProtesisM").iCheck('uncheck');
            }
            
            if (historiaClinica.CaderaDerecha == true) {
                $("#chkCaderaDerM").iCheck('check');
            } else {
                $("#chkCaderaDerM").iCheck('uncheck');
            }
            
            if (historiaClinica.CaderaIzquierda == true) {
                $("#chkCaderaIzqM").iCheck('check');
            } else {
                $("#chkCaderaIzqM").iCheck('uncheck');
            }

            $("#txtAOtrosM").val(historiaClinica.Otros);
            $('#lblAOtrosM').hide();
            $("#txtAAntecedentesM").val(historiaClinica.Antecedentes);
            $('#lblAAntecedentesM').hide();

        }
        
        function limpiarAntecedentes()
        {

        }

    </script>
</asp:Content>
