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
        <h1 style="text-align: center">SEGUIMIENTO DEL PACIENTE</h1>
    </section>
    <div class="content">
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
                            <div class="col-sm-6 col-md-6 col-lg-6">
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
                        <%--</div> 
                        <div class="form-row">--%>
                            <div class="col-sm-6 col-md-6 col-lg-6">
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
        <div class="alert alert-warning alert-dismissible" id="signTratamiento" style="display:none">
            <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
            <h4><i class="icon fa fa-warning"></i> ¡Atención!</h4>
            El paciente no tiene tratamientos cargados.
        </div>
        <%--<div class="col-md-12 pt-1" id="">--%>
        <div class="box box-primary" id="boxTratamientos" style="display:none">
            <div class="box-header">
                <h4 class="box-title" id="ttlTratamiento">Tratamientos</h4>
                <a class="btn btn-light float-right" id="btcColTratamientos" data-toggle="collapse" href="#collapseExample2" aria-expanded="false" aria-controls="collapseExample2">
                    <i class="fas fa-angle-down" id="icnColTratamientos" ></i>
                </a>
            </div>
            <div class="collapse" id="collapseExample2">
                <%--<div class="card-body">--%>
                    <div class="box-body " id="tblTratamiento" style="display:none">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="table-responsive"> 
                                    <div id="tTratamiento" >
                                        <table style=" width: 100% !important;" class="table table-striped table-hover table-bordered table-secondary" id="tablaTratamiento">
                                        </table>
                                    </div> 
                                </div>  
                                
                            </div>
                        </div>
                    </div>
                <%--</div>--%>
            </div>
        </div>
        <%--</div>--%>

    </div>
     <%--MODAL DETALLE TRATAMIENTO--%>
    <div class="modal fade" tabindex="-1" role="dialog" id ="modalDetalleTratamiento" >
        <div class="modal-dialog modal-xl" role="document">
            <div class="modal-content">
                <div class="modal-header bg-info text-white">
                    <h4 class="modal-title " id="lblDetalleTratamiento">Detalle del tratamiento</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>       
                </div>
                <div class="modal-body">
                    <div class="col-md-12" id="crdDetalleTratemiento">
                        <div class="card text-white ">
                            <div class="card-header ">
                                <h4 class="modal-title text-dark" id="">Detalle de Ingreso
                                    <a class="btn btn-light float-right" id="btcColTratamientos2" data-toggle="collapse" href="#collapseExample3" aria-expanded="false" aria-controls="collapseExample3">
                                        <i class="fas fa-angle-down" id="icnColTratamientos3" ></i>
                                    </a>
                                </h4>                     
                            </div>
                            <div class="collapse" id="collapseExample3">
                                <div class="card-body">
                                    <div class="form-row">
                                        <input type="text" style="text-align: left; display: none" id="txtIdTratamientoEditar" />
                                        <div class="col-sm-4 col-md-4 col-lg-4">
                                            <div class="input-group mb-3">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">Profesional Derivante:</span>
                                                </div>
                                                <input type="text" style="text-align: left" class="form-control" id="txtProfDerivante"  maxlength="50"/>
                                            </div> 
                                        </div>
                                        <div class="col-sm-4 col-md-4 col-lg-4">
                                            <div class="input-group mb-3">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">Matricula:</span> 
                                                </div>
                                                <input type="text" style="text-align: left" class="form-control" id="txtMatriculaProfDerivante" maxlength="10" onkeypress="return soloNumeros(event)"/>
                                            </div> 
                                        </div>
                                        <div class="col-sm-4 col-md-4 col-lg-4">
                                            <div class="input-group mb-3">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">Especialidad:</span>
                                                </div>
                                                <input type="text" style="text-align: left" class="form-control" id="txtEspecProfDerivante" maxlength="20" />
                                            </div> 
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col-sm-6 col-md-6 col-lg-6">
                                            <div class="form-group">
                                                <label class="text-black mr-2 " > 
                                                    Diagnóstico de Ingreso:
                                                </label>
                                                <textarea class="form-control" id="txtDiagnIngreso" rows="3" maxlength="300"></textarea>
                                                <label class="text-black mr-2" id="lblDiagnIngreso">
                                                    0/300
                                                </label> 
                                            </div> 
                                        </div>
                                        <div class="col-sm-6 col-md-6 col-lg-6">
                                            <div class="form-group">
                                                <label class="text-black mr-2 " > 
                                                    Evaluación de Ingreso:
                                                </label>
                                                <textarea class="form-control" id="txtEvaIngreso" rows="3" maxlength="300"></textarea>
                                                <label class="text-black mr-2" id="lblEvaIngreso">
                                                    0/300
                                                </label> 
                                            </div> 
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col-sm-6 col-md-6 col-lg-6"> 
                                            <div class="form-group">
                                                <label class="text-black mr-2 " >
                                                    Descripción del Plan:
                                                </label>
                                                <textarea class="form-control" id="txtDescrPlan" rows="3" maxlength="500"></textarea>
                                                <label class="text-black mr-2" id="lblDescrPlan">
                                                    0/500
                                                </label> 
                                            </div> 
                                        </div>
                                        <div class="col-sm-6 col-md-6 col-lg-6"> 
                                            <div class="form-group">
                                                <label class="text-black mr-2 " >
                                                    Objetivo del Plan:
                                                </label>
                                                <textarea class="form-control" id="txtObjPlan" rows="3" maxlength="300"></textarea>
                                                <label class="text-black mr-2" id="lblObjPlan">
                                                    0/300
                                                </label> 
                                            </div> 
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col">
                                            <div class="checkbox float-left">
                                                <label class="text-black mr-2 " >
                                                    <strong>Consentimiento firmado:</strong> 
                                                </label>
                                                <input type="checkbox" class="flat-green ml-2" id="chkConsentimiento"/>
                                            </div> 
                                            <button class="btn btn-success float-right" type="button" id="btnGuardarDetalleTratamiento">Guardar cambios</button>  
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        </br>
                        <div class="card text-white ">
                            <div class="card-header ">
                                <h4 class="modal-title text-dark" id="">Turnos del Tratamiento</h4>
                            </div>
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="table-responsive">

                                            <div id="tTurnosTratamiento" style="display: none">
                                                <table style="width:100%" class="table table-striped table-hover table-bordered table-secondary" id="tablaTurnosTratamiento">
                                                </table>

                                            </div>  
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--MODAL GENERAR SEGUIMIENTO--%>
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
    <script type="text/javascript" src="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "Scripts/pdfmake.min.js"%>"></script>
    <script type="text/javascript" src="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "Scripts/vfs_fonts.js"%>"></script>

    <%--<script type="text/javascript" src="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "Scripts/jspdf.js"%>"></script>
    <script type="text/javascript" src="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "Scripts/html2canvas.min.js"%>"></script>--%>
    <script type="text/javascript" src="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "ScriptsPantallas/impresorPDF.js"%>"></script>

    <script type="text/javascript">

        var tensionRegistrar = false; var diabetesRegistrar = false; var fumadorRegistrar = false; var cardiacoRegistrar = false;
        var cirrosisRegistrar = false; var artrosisRegistrar = false; var artritisRegistrar = false;
        var hemiplejiaRegistrar = false; var asmaRegistrar = false; var marcapasosRegistrar = false;
        var protesisRegistrar = false; var caderaDerRegistrar = false; var caderaIzqRegistrar = false;
        var tensionEditar = false; var diabetesEditar = false; var fumadorEditar = false; var cardiacoEditar = false;
        var cirrosisEditar = false; var artrosisEditar = false; var artritisEditar = false;
        var hemiplejiaEditar = false; var asmaEditar = false; var marcapasosEditar = false;
        var protesisEditar = false; var caderaDerEditar = false; var caderaIzqEditar = false;
        var paciente;

        $(document).ready(function () {

            $('input').iCheck({
                checkboxClass: 'icheckbox_flat-green'
            });

            //funcionEntra("entranding");
            //printDiv( "sectionEspecialidad", "titulo");

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

                        mostrarDatosHC(historiaClinica, paciente);
                        mostrarTratamientos();

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

            $('#chkTensionM').on('ifChecked ', function (event) {
                $('#valoresTensionM').show();
                tensionEditar = true;
            });
            $('#chkTensionM').on('ifUnchecked ', function (event) {
                $('#valoresTensionM').hide();
                $('#txtTensionV1M').val('');
                $('#txtTensionV2M').val('');
                tensionEditar = false;
            });

            $('#chkDiabetesM').on('ifChecked ', function (event) {
                diabetesEditar = true;
            });

            $('#chkDiabetesM').on('ifUnchecked ', function (event) {
                diabetesEditar = false;
            });

            $('#chkFumadorM').on('ifChecked ', function (event) {
                fumadorEditar = true;
            });

            $('#chkFumadorM').on('ifUnchecked ', function (event) {
                fumadorEditar = false;
            });
            
            $('#chkCardiacoM').on('ifChecked ', function (event) {
                cardiacoEditar = true;
            });

            $('#chkCardiacoM').on('ifUnchecked ', function (event) {
                cardiacoEditar = false;
            });
            
            $('#chkCirrosisM').on('ifChecked ', function (event) {
                cirrosisEditar = true;
            });

            $('#chkCirrosisM').on('ifUnchecked ', function (event) {
                cirrosisEditar = false;
            });
            
            $('#chkArtrosisM').on('ifChecked ', function (event) {
                artrosisEditar = true;
            });

            $('#chkArtrosisM').on('ifUnchecked ', function (event) {
                artrosisEditar = false;
            });
            
            $('#chkArtritisReumaM').on('ifChecked ', function (event) {
                artritisEditar = true;
            });

            $('#chkArtritisReumaM').on('ifUnchecked ', function (event) {
                artritisEditar = false;
            });
            
            $('#chkHemiplejiaM').on('ifChecked ', function (event) {
                hemiplejiaEditar = true;
            });

            $('#chkHemiplejiaM').on('ifUnchecked ', function (event) {
                hemiplejiaEditar = false;
            });
            
            $('#chkAsmaM').on('ifChecked ', function (event) {
                asmaEditar = true;
            });

            $('#chkAsmaM').on('ifUnchecked ', function (event) {
                asmaEditar = false;
            });
            
            $('#chkMarcapasosM').on('ifChecked ', function (event) {
                marcapasosEditar = true;
            });

            $('#chkMarcapasosM').on('ifUnchecked ', function (event) {
                marcapasosEditar = false;
            });
            
            $('#chkProtesisM').on('ifChecked ', function (event) {
                protesisEditar = true;
            });

            $('#chkProtesisM').on('ifUnchecked ', function (event) {
                protesisEditar = false;
            });
            
            $('#chkCaderaDerM').on('ifChecked ', function (event) {
                caderaDerEditar = true;
            });

            $('#chkCaderaDerM').on('ifUnchecked ', function (event) {
                caderaDerEditar = false;
            });
            
            $('#chkCaderaIzqM').on('ifChecked ', function (event) {
                caderaIzqEditar = true;
            });

            $('#chkCaderaIzqM').on('ifUnchecked ', function (event) {
                caderaIzqEditar = false;
            });           

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
            
            $('#btnAntecedentesGuardar').click(function ()
            {
                var idPaciente = $('#txtIdPacienteFiltrar').val();
                var tensionValores = $('#txtTensionV1M').val() + "/" + $('#txtTensionV2M').val();
                var otros = $('#txtAOtrosM').val();
                var antecedentes = $('#txtAAntecedentesM').val();

                var historiaClinica = {
                    p_idPaciente: idPaciente,
                    p_tension: tensionEditar,
                    p_tension_valores: tensionValores,
                    p_diabetes: diabetesEditar,
                    p_fumador: fumadorEditar, 
                    p_cardiaco: cardiacoEditar,
                    p_cirrosis: cirrosisEditar,
                    p_artrosis: artrosisEditar,
                    p_artritis: artritisEditar,
                    p_hemiplejia: hemiplejiaEditar,
                    p_asma: asmaEditar,
                    p_marcapasos: marcapasosEditar,
                    p_protesis: protesisEditar,
                    p_caderaDer: caderaDerEditar,
                    p_caderaIzq: caderaIzqEditar,
                    p_otros: otros,
                    p_antecedentes: antecedentes,

                    p_nombrePaciente: paciente.Nombre,
                    p_apellidoPaciente: paciente.Apellido,
                    p_documentoPaciente: paciente.Documento,
                    p_nroPaciente: paciente.NroContacto,
                    p_emailPaciente: paciente.EmailContacto
                };
                
                $.ajax({
                    url: "GestionSeguimientoPacientes.aspx/editarHistoriaClinica",
                    data: "{historiaClinica: '" + JSON.stringify(historiaClinica)
                        + "'}",
                    type: "post",
                    contentType: "application/json",
                    async: false,
                    success: function (data) {

                        swal("Hecho", "Tratamiento editado con éxito!", "success");

                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        swal("Cuidado", "Ha habido un error al editar el Tratamiento.", "warning");
                    }
                });

            });


            //#region controles Tratamientos
            $("#btcColTratamientos").click(function(e) {
                var menuItem = $(this);

                if (menuItem.attr("aria-expanded") === "true") {
                    $("#icnColTratamientos").removeClass();
                    $("#icnColTratamientos").addClass('fas fa-angle-down');
                }
                else if (menuItem.attr("aria-expanded") === "false") {
                    $("#icnColTratamientos").removeClass();
                    $("#icnColTratamientos").addClass('fas fa-angle-up');
                }
            });
            //#endregion

            //#region controles Modal Detalle Tratamientos
            var txtDiagnIngreso = document.getElementById("txtDiagnIngreso");
            txtDiagnIngreso.addEventListener("input", event => {
                
                const target = event.currentTarget;
                const maxLength = target.getAttribute("maxlength");
                const currentLength = target.value.length;

                if (currentLength > maxLength) {
                    return  $('#lblDiagnIngreso').html('Ha excedido el límite de caracteres permitido.');  

                }
                $('#lblDiagnIngreso').html(currentLength+'/300');  
            });
            
            var txtEvaIngreso = document.getElementById("txtEvaIngreso");
            txtEvaIngreso.addEventListener("input", event => {
                
                const target = event.currentTarget;
                const maxLength = target.getAttribute("maxlength");
                const currentLength = target.value.length;

                if (currentLength > maxLength) {
                    return  $('#lblEvaIngreso').html('Ha excedido el límite de caracteres permitido.');  

                }
                $('#lblEvaIngreso').html(currentLength+'/300');  
            });
             
            var txtDescrPlan = document.getElementById("txtDescrPlan");
            txtDescrPlan.addEventListener("input", event => {
                
                const target = event.currentTarget;
                const maxLength = target.getAttribute("maxlength");
                const currentLength = target.value.length;

                if (currentLength > maxLength) {
                    return  $('#lblDescrPlan').html('Ha excedido el límite de caracteres permitido.');  

                }
                $('#lblDescrPlan').html(currentLength+'/300');  
            });

            var txtObjPlan = document.getElementById("txtObjPlan");
            txtObjPlan.addEventListener("input", event => {
                
                const target = event.currentTarget;
                const maxLength = target.getAttribute("maxlength");
                const currentLength = target.value.length;

                if (currentLength > maxLength) {
                    return  $('#lblObjPlan').html('Ha excedido el límite de caracteres permitido.');  

                }
                $('#lblObjPlan').html(currentLength+'/300');  
            });

            $('#btnGuardarDetalleTratamiento').click(function ()
            {
                
                var tratamientoEdit = {
                    p_idTratamiento: $("#txtIdTratamientoEditar").val(),
                    p_profDerivante: $('#txtProfDerivante').val(),
                    p_matrProfDerivante: $('#txtMatriculaProfDerivante').val(),
                    p_especProfDerivante: $('#txtEspecProfDerivante').val(),
                    p_diagnIngreso: $('#txtDiagnIngreso').val(),
                    p_evaIngreso: $('#txtEvaIngreso').val(),
                    p_descrPlan: $('#txtDescrPlan').val(),
                    p_objPlan: $('#txtObjPlan').val()
                }
                $.ajax({
                    url: "GestionSeguimientoPacientes.aspx/editarTratamiento",
                    data: "{tratamientoEdit: '" + JSON.stringify(tratamientoEdit)
                        + "'}",
                    type: "post",
                    contentType: "application/json",
                    async: false,
                    success: function (data) {

                        swal("Hecho", "Tratamiento editado con éxito!", "success");

                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        swal("Cuidado", "Ha habido un error al editar el Tratamiento.", "warning");
                    }
                });
                
                
                
                
            });

            $('#chkConsentimiento').on('ifChecked ', function (event) {
                estadoConsentimiento = true;
                estadoConsentimientoGuardar(estadoConsentimiento);
            });

            $('#chkConsentimiento').on('ifUnchecked ', function (event) {
                estadoConsentimiento = false;
                estadoConsentimientoGuardar(estadoConsentimiento);
            });
            //#endregion
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

        function mostrarTratamientos() {
            
            var id_paciente = $('#txtIdPacienteFiltrar').val();
            //var dniPaciente = $('#txtDocumentoFiltrar').val();
            $.ajax({
                url: "GestionSeguimientoPacientes.aspx/buscarTratamientos",
                data: "{idPaciente: '" + id_paciente + "'}",
                type: "post",
                contentType: "application/json",
                async: false,
                success: function (data) {
               
                    if (data.d != "null") {

                        var datos = JSON.parse(data.d);
                        $('#boxTratamientos').show();
                        $('#signTratamiento').hide();                       
                        $("#btcColTratamientos").click();
                        $('#tblTratamiento').show();


                        var tratamientos = [];
                        datos.forEach(function (e)
                        {

                            var idTratamiento = e.ID_TRATAMIENTO;
                            var fechaAlta = getFormattedDate(new Date(e.FECHA_ALTA));
                            var centro = e.CENTRO;
                            var especialidad = e.ESPECIALIDAD;
                            var profesional = e.PROFESIONAL;
                            var obraSocial = e.OBRA_SOCIAL;
                            var nroAfiliado = e.NRO_AFILIADO;
                            var nroAutorizacionObra = e.NRO_AUTORIZACION_OBRA;
                            //paciente.IdPaciente
                            var Acciones = '<a href="#" onclick="return detalleTratamiento(' + idTratamiento + ')"  class="btn btn-primary" > <span class="fas fa-file-medical" title="Detalle"></span></a > ';

                            
                            if (e.CONSENTIMIENTO_FIRMADO == false) {
                                var consentimiento = 'No';
                                //Acciones += '<a href="#" onclick="return imprimirConsentimiento(' + idTratamiento + ')"  class="btn btn-primary" > <span class="fa fa-pencil-square-o" title="Imprimir Consentimiento"></span></a > ';
                                Acciones += '<a href="#" onclick="return imprimirHC(' + idTratamiento + ')"  class="btn btn-primary" > <span class="fa fa-print" title="Imprimir Tratamiento"></span></a > ';

                            } else {
                                var consentimiento = 'Sí';

                            }

                            tratamientos.push([idTratamiento, fechaAlta, centro, especialidad, profesional, obraSocial, nroAfiliado, nroAutorizacionObra, consentimiento, Acciones]);                                    
                        });
                        creatTablaTratamientos(tratamientos);

                    } else {
                        $('#boxTratamientos').hide();
                        $('#signTratamiento').show();  
                        $('#tblTratamiento').hide();

                    }

                }
            }); 
        }



        function creatTablaTratamientos(tratamientos) {

            var table = $('#tablaTratamiento').DataTable({
                data: tratamientos,
                "scrollX": true,
                "languaje": {
                    "url": "//cdn.datatables.net/plug-ins/1.10.12/i18n/Spanish.json"
                },
                "ordering": true,
                "bDestroy": true,
                "bAutoWidth": true,
                columns: [
                    { title: "NRO. TRATAMIENTO" , visible: false},
                    { title: "FECHA ALTA" },
                    { title: "CENTRO" },
                    { title: "ESPECIALIDAD" },
                    { title: "PROFESIONAL" },
                    { title: "OBRA SOCIAL" },
                    { title: "NRO. AFILIADO" },
                    { title: "NRO. AUTORIZACION" },
                    { title: "CONSENTIMIENTO FIRMADO" },
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

        function detalleTratamiento(idTratamiento) {

            $('#modalDetalleTratamiento').modal('show');
      
            $("#txtIdTratamientoEditar").val(idTratamiento);
            cargarDetalleTratamiento(idTratamiento);
            cargarTurnosTratamiento(idTratamiento);
            
        }

        function cargarDetalleTratamiento(idTratamiento) {

            $.ajax({
                url: "GestionSeguimientoPacientes.aspx/traerTratamientoDetalle",
                data: "{idTratamiento: '" + idTratamiento
                    + "'}",
                type: "post",
                contentType: "application/json",
                async: false,
                success: function (data) {

                    var datosTurnos = JSON.parse(data.d);

                    $('#txtProfDerivante').val(datosTurnos[0].PROFESIONAL_DERIVANTE);
                    $('#txtMatriculaProfDerivante').val(datosTurnos[0].MATRICULA);
                    $('#txtEspecProfDerivante').val(datosTurnos[0].ESPECIALIDAD);
                    $('#txtDiagnIngreso').val(datosTurnos[0].DIAGNOSTICO_INGRESO);
                    $('#txtEvaIngreso').val(datosTurnos[0].EVALUACION_INGRESO);
                    $('#txtDescrPlan').val(datosTurnos[0].DESCRIPCION_PLAN);
                    $('#txtObjPlan').val(datosTurnos[0].OBJETIVO_PLAN);

                    if (datosTurnos[0].CONSENTIMIENTO_FIRMADO == false) {
                        $("#chkConsentimiento").iCheck('uncheck');
                        disableControls(false);
                        $('#btnGuardarDetalleTratamiento').show();
                    } else {
                        $("#chkConsentimiento").iCheck('check');
                        disableControls(true);
                        $('#btnGuardarDetalleTratamiento').hide();
                    }

                },
                error: function (xhr, ajaxOptions, thrownError) {
                    swal("Cuidado", "Ha habido un error al cargar el Tratamiento.", "warning");
                }
            });
        }
        function estadoConsentimientoGuardar(estadoConsentimiento) {
           

            $.ajax({
                url: "GestionSeguimientoPacientes.aspx/estadoConsentimientoGuardar",
                data: "{idTratamiento: '" + $("#txtIdTratamientoEditar").val()
                    + "', estadoConsentimiento: '" + estadoConsentimiento 
                    + "'}",
                type: "post",
                contentType: "application/json",
                async: false,
                success: function (data) {

                    disableControls(estadoConsentimiento);

                    if (estadoConsentimiento == false) {
                        $('#btnGuardarDetalleTratamiento').show();
                    } else {
                        $('#btnGuardarDetalleTratamiento').hide();
                    }

                },
                error: function (xhr, ajaxOptions, thrownError) {
                    swal("Cuidado", "Ha habido un error al guardar el estado del Conesntimiento.", "warning");
                }
            });
        }

        function disableControls(estado) {
            $('#txtProfDerivante').prop('disabled', estado);
            $('#txtMatriculaProfDerivante').prop('disabled', estado);
            $('#txtEspecProfDerivante').prop('disabled', estado);
            $('#txtDiagnIngreso').prop('disabled', estado);
            $('#txtEvaIngreso').prop('disabled', estado);
            $('#txtDescrPlan').prop('disabled', estado);
            $('#txtObjPlan').prop('disabled', estado);
        }

        function cargarTurnosTratamiento(idTratamiento) {
            $.ajax({
                url: "GestionSeguimientoPacientes.aspx/traerTratamientoEditar",
                data: "{idTratamiento: '" + idTratamiento
                    + "'}",
                type: "post",
                contentType: "application/json",
                async: false,
                success: function (data) {

                    var datosTurnos = JSON.parse(data.d);
                    $('#txtDocumentoEd').val(datosTurnos[0].DOCUMENTO);
                    $('#txtPacienteEd').val(datosTurnos[0].PACIENTE);
                    $('#txtObrasocialEd').val(datosTurnos[0].OBRA_SOCIAL);
                    $('#txtNroAfiliadoEd').val(datosTurnos[0].NRO_AFILIADO);
                    $('#txtNroAutorizacionEd').val(datosTurnos[0].NRO_AUTORIZACION_OBRA);
                    $('#txtCentroEd').val(datosTurnos[0].CENTRO);
                    $('#txtEspecialidadEd').val(datosTurnos[0].ESPECIALIDAD);
                    $('#txtProfesionalEd').val(datosTurnos[0].PROFESIONAL);

                    var arrayTurnosEditar = [];
                    
                    $('#idPacienteEd').val(datosTurnos[0].ID_PACIENTE);
                    $('#idProfesionalEd').val(datosTurnos[0].ID_PROFESIONAL);
                    $('#idObraSocialEd').val(datosTurnos[0].ID_OBRA_SOCIAL);
                    $('#idEspecialidadEd').val(datosTurnos[0].ID_ESPECIALIDAD);
                    $('#idCentroEd').val(datosTurnos[0].ID_CENTRO);
                    $('#idPlanObraEd').val(datosTurnos[0].ID_PLAN_OBRA);
                    $('#idTratamientoEd').val(datosTurnos[0].ID_TRATAMIENTO);

                    datosTurnos.forEach(function (e) {

                        var fechaTurno = getFormattedDate(new Date(e.FECHA_TURNO))

                        var observaciones = "";
                        if (e.OBSERVACIONES != null) {
                            observaciones = e.OBSERVACIONES;
                        }
                         
                        var detalleTurno = "<div class='input-group mb-3'><input type='text' value= '"+ observaciones +"' style='text-align: left' class='form-control' id='INPUT-" + e.ID_TURNO + "' maxlength='100'/><div class='input-group-append'> <button class='btn btn-outline-secondary' onclick='editaObservacionTurno(" + e.ID_TURNO + ")' type='button'><i class='fas fa-save'></i></button></div></div>";
                        
                        arrayTurnosEditar.push([
                            e.ID_TURNO,
                            e.DOCUMENTO, e.PACIENTE, e.ESPECIALIDAD, e.PROFESIONAL, e.ESTADO, fechaTurno, e.HORA_DESDE
                            , e.OBSERVACIONES
                            , detalleTurno
                            //, acciones
                        ])
                    });
                    $('#tTurnosTratamiento').hide();
                    dibujarTablaTurnosEditar(arrayTurnosEditar);
                    //obtieneDisponibilidadHorariaEd(datosTurnos[0].ID_PROFESIONAL, datosTurnos[0].ID_ESPECIALIDAD, datosTurnos[0].ID_CENTRO);
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    //$("#modalEditarTratamiento").modal('hide');
                    swal("Atención!", "Ha habido un error al cargar los turnos.", "warning");
                }
            });
        }

        function editaObservacionTurno(idTurno) {

            var observacion = $("#INPUT-" + idTurno).val();

            $.ajax({
                url: "GestionSeguimientoPacientes.aspx/editarObservacionTurno",
                data: "{idTurno: '" + idTurno + "', observacion: '" + observacion + "'}",
                type: "post",
                contentType: "application/json",
                async: false,
                success: function (data) {

                    swal("Hecho!", "Detalle guardado correctamente.", "success");
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    swal("Cuidado", "Ha habido un error al cargar la Descripción del turno.", "warning");
                }
            });
        }

        function dibujarTablaTurnosEditar(arrayTurnosEditar) {
            $('#tTurnosTratamiento').show();
            var table = $('#tablaTurnosTratamiento').DataTable({
                data: arrayTurnosEditar,
                //"scrollX": true,
                "languaje": {
                    "url": "//cdn.datatables.net/plug-ins/1.10.12/i18n/Spanish.json"
                },
                "ordering": true,
                //"order": [[ 6, "asc" ]],
                "bDestroy": true,
                //"bAutoWidth": true,
                columns: [
                    { title: "ID_TURNO", visible: false },
                    //{ title: "ID_TRATAMIENTO", visible: false },
                    //{ title: "ID_PACIENTE", visible: false },
                    //{ title: "ID_PROFESIONAL", visible: false },
                    //{ title: "ID_OBRA_SOCIAL", visible: false },
                    //{ title: "ID_ESPECIALIDAD", visible: false },
                    //{ title: "ID_CENTRO", visible: false },
                    //{ title: "ID_PLAN_OBRA", visible: false },

                    { title: "DOCUMENTO", visible: false },
                    { title: "PACIENTE", visible: false },
                    { title: "ESPECIALIDAD" },
                    { title: "PROFESIONAL" },
                    { title: "ESTADO" },
                    { title: "FECHA TURNO" },
                    { title: "HORA DESDE" },
                    { title: "DETALLE TURNO", visible: false },
                    { title: "DETALLE TURNO", "width": "150%" }  
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
                "bPaginate": true,
                "pageLength": 5,
                buttons: [
                    //{ extend: 'copy', text: "Copiar" },
                    { extend: 'print', text: "Imprimir", exportOptions: {columns: [1, 2, 3, 4, 5, 6, 7, 8]} },
                    { extend: 'pdf', orientation: 'landscape', exportOptions: {columns: [1, 2, 3, 4, 5, 6, 7, 8]} },
                    { extend: 'colvis', columns: ':not(:first-child)', text: "Ocultar/Mostrar columnas" }
                ]
            });
            $('.dataTables_filter input').attr("placeholder", "Filtrar por...");     
        }
    </script>
</asp:Content>
