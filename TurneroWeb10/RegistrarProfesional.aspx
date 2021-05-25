<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarProfesional.aspx.cs" Inherits="TurneroWeb10.RegistrarProfesional" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <section class="content-header">
        <button class="btn btn-info btn-sm float-right" type="button" id="Listar">Listar Profesionales</button>
        <h1 style="text-align: left">REGISTRO DE PROFESIONALES</h1>
    </section>
    <section class="content">       
            <div class="row">
                <div class="col-md-6" id="crdDatosPersonales">
                    <div class="card text-white bg-light">
                        <div class="card-header bg-info">
                            <h4>Datos personales</h4>
                        </div>
                        <div class="card-body">
                            <div class="form-row">
                                <div class="col-sm-6">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">DNI</span>
                                        </div>
                                        <input type="text" style="text-align: left"  class="form-control" id="txtDocumento" onkeypress="return soloNumeros(event)" onpaste="return false" maxlength="8"/>
                                    </div>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="col-sm-6">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">Matricula</span>
                                        </div>
                                        <input type="text" style="text-align: left" class="form-control" id="txtMatricula" onkeypress="return soloNumeros(event)" onpaste="return false" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="col">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text" id="">Nombre y Apellido</span>
                                        </div>
                                        <input type="text" style="text-align: left; text-transform: uppercase" value="" onkeyup="javascript:this.value=this.value.toUpperCase();" class="form-control" id="txtNombre" onkeypress="return soloLetras(event)" />
                                        <input type="text" style="text-align: left; text-transform: uppercase" value="" onkeyup="javascript:this.value=this.value.toUpperCase();" class="form-control" id="txtApellido" onkeypress="return soloLetras(event)"/>
                                    </div>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="col">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">Fecha de Nacimiento</span>
                                        </div>
                                        <div>
                                            <input type='text' class="form-control datepicker date" id="dtpFechaNac"
                                                placeholder="DD/MM/YYYY" data-provide="datepicker"
                                                data-date-format="dd/mm/yyyy" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6" id="crdDatosContacto">
                    <div class="card text-white bg-light">
                        <div class="card-header bg-info">
                            <h4>Datos de Contacto</h4>
                        </div>
                        <div class="card-body">
                            <div class="form-row">
                                <div class="col">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">Calle</span>
                                        </div>
                                        <input type="text" style="text-align: left; text-transform: uppercase" value="" onkeyup="javascript:this.value=this.value.toUpperCase();" class="form-control" id="txtCalle" onkeypress="return soloLetras(event)"/>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">Numero</span>
                                        </div>
                                        <input type="text" style="text-align: left" class="form-control" id="txtNumero" onkeypress="return soloNumeros(event)" onpaste="return false" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="col">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">Barrio</span>
                                        </div>
                                        <input type="text" style="text-align: left; text-transform: uppercase" value="" onkeyup="javascript:this.value=this.value.toUpperCase();" class="form-control" id="txtBarrio" onkeypress="return soloLetras(event)"/>
                                    </div>
                                </div>
                                <div class="col">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">Localidad</span>
                                        </div>
                                        <input type="text" style="text-align: left; text-transform: uppercase" value="" onkeyup="javascript:this.value=this.value.toUpperCase();" class="form-control" id="txtLocalidad" onkeypress="return soloLetras(event)"/>
                                    </div>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="col-sm-6">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">Celular</span>
                                        </div>
                                        <input type="text" style="text-align: left" class="form-control" id="txtCelular" onkeypress="return soloNumeros(event)" onpaste="return false" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="col">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">Email: </span>
                                        </div>
                                        <input type="text" style="text-align: left; text-transform: uppercase" value="" onkeyup="javascript:this.value=this.value.toUpperCase();" class="form-control" id="txtEmail1" />
                                        <div class="input-group-append">
                                            <span class="input-group-text">@</span>
                                        </div>
                                        <input type="text" style="text-align: left; text-transform: uppercase" value="" onkeyup="javascript:this.value=this.value.toUpperCase();" class="form-control" id="txtEmail2" placeholder="gmail.com" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>    
        <div class="card-body">
            <div class="col" id="crdDatosLaborales">
                <div class="card text-white bg-light">
                    <div class="card-header bg-info">
                        <h4>Datos Laborales</h4>
                    </div>
                    <div class="card-body">
                        <div class="form-row">
                            <div class="col-md-6">
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
                            <div class="form-row">
                                <div class="col">
                                    <div class="input-group mb-3">
                                        <button type="button" class="btn btn-outline-primary">Agregar Especialidad</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col-md-6">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">Sucursal: </span>
                                    </div>
                                    <select class="custom-select form-control" id="ddlSucursal">
                                        <option value="0" disabled="disabled" selected="selected" hidden="hidden">--SELECCIONE--</option>
                                        <option value="1">CORDOBA</option>
                                        <option value="2">CARLOS PAZ I</option>
                                        <option value="3">CARLOS PAZ II</option>
                                    </select>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>

        <br />
        <!--VER COMO ALINEAR DOS BOTONES AL CENTRO O A LA DERECHA-->
        <%--<button class="btn btn-secondary btn-lg float-right" type="button" id="btnCancelar">Cancelar</button>--%>
    </section>
    <button class="btn btn-success btn-lg float-right" type="button" id="btnRegistrar">Registrar</button>
    <script type="text/javascript">
        var dni;
        var matricula;
        var nombre;
        var apellido;
        var fechaNac;

        var calle;
        var numero;
        var barrio;
        var localidad;
        var celular;
        var email1;
        var email2;

        $(document).ready(function () {

            $('.date').datepicker({
                autoclose: true,
                format: "dd/mm/yyyy"
            });

            $('#btnRegistrar').click(function () {

                dni = $('#txtDocumento').val();
                matricula = $('#txtMatricula').val();
                nombre = $('#txtNombre').val();
                apellido = $('#txtApellido').val();
                fechaNac = $('#dtpFechaNac').val();
                calle = $('#txtCalle').val();
                numero = $('#txtNumero').val();
                barrio = $('#txtBarrio').val();
                localidad = $('#txtLocalidad').val();
                celular = $('#txtCelular').val();
                email1 = $('#txtEmail1').val();
                email2 = $('#txtEmail2').val();

                var validacion = validarDatosProfesional();

                if (validacion === true) {

                    var profesional = {

                        p_dni: dni,
                        p_matricula: matricula,
                        p_nombre: nombre,
                        p_apellido: apellido,
                        p_fechaNac: fechaNac,
                        p_calle: calle,
                        p_numero: numero,
                        p_barrio: barrio,
                        p_localidad: localidad,
                        p_celular: celular,
                        p_email1: email1,
                        p_email2: email2
                    }
                    console.log(profesional);
                    registrarProfesional(profesional);
                }
                else {
                    console.log("No valide datos o sali por error");
                }

            });

        });


        function registrarProfesional(datosProfesional) {
            $.ajax({
                url: "RegistrarProfesional.aspx/registrarProfesional",
                data: JSON.stringify(datosProfesional),
                type: "post",
                contentType: "application/json",
                async: false,
                success: function (data) {

                    if (data.d != 'OK') {
                        alert('Error al registrar el profesional.')
                    } else {
                        $('#btnConfProfesional').show();
                        alert('profesional registrado con Éxito.')
                    }
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    alert(data.error);
                }

            });

        }


        function validarDatosProfesional() {

            if (dni == "") {
                alert("Por favor, ingrese DNI");
                return false;
            }
            else if (matricula == "") {
                alert("Por favor, ingrese Matricula");
                return false;
            }
            else if (nombre == null) {
                alert("Por favor, ingrese Nombre");
                return false;
            }
            else if (apellido == null) {
                alert("Por favor, ingrese Apellido");
                return false;
            }
            else if (fechaNac == "") {
                alert("Por favor, ingrese Fecha de Nacimiento");
                return false;
            }
            else if (calle == "") {
                alert("Por favor, ingrese Calle");
                return false;
            }
            else if (numero == "") {
                alert("Por favor, ingrese Numero");
                return false;
            }
            else if (barrio == "") {
                alert("Por favor, ingrese Barrio");
                return false;
            }
            else if (localidad == "") {
                alert("Por favor, ingrese Localidad");
                return false;
            }
            else if (celular == "") {
                alert("Por favor, ingrese un telefono de contacto");
                return false;
            }
            else if (email1 == "") {
                alert("Por favor, ingrese un E-mail válido");
                return false;
            }
            else if (email2 == "") {
                alert("Por favor, ingrese un E-mail válido");
                return false;
            }
            else {
                return true;
            };
        };

        //Para ingresar solo numeros
        function soloNumeros(e) {
            key = e.keyCode || e.which;
            teclado = String.fromCharCode(key);

            numero = "0123456789";
            especiales = "8-37-38-46";
            teclado_especial = false;

            for (var i in especiales) {
                if (key == especiales[i]) {
                    teclado_especial = true;
                }
            }

            if (numero.indexOf(teclado) == -1 && !teclado_especial) {
                return false;
            }
        }
              
        //Para ingresar solo letras

         function soloLetras(e) {
             key = e.keyCode || e.which;
             teclado = String.fromCharCode(key).toLowerCase();

            letras = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz";
            especiales = "8-37-38-46-164";
            teclado_especial = false;

            for (var i in especiales) {
                if (key == especiales[i]) {
                    teclado_especial = true; break;
                }
            }

            if (letras.indexOf(teclado) == -1 && !teclado_especial) {
                return false;
            }
        }
        
        
    </script>
</asp:Content>
