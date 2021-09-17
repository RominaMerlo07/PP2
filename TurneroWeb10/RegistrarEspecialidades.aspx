<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarEspecialidades.aspx.cs" Inherits="TurneroWeb10.RegistrarEspecialidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <section class="content-header">
            <button class="btn btn-info btn-sm float-right" type="button" id="Listar">Listar Especialidades</button>
        </section>
        <section class="content">
            <div class="row">
                <div class="col-md-6" id="crEpecialidades">
                    <div class="card text-white bg-light">
                        <div class="card-header bg-info">
                            <h4>Añadir Especialidad</h4>
                        </div>
                        <div class="card-body align-items-center">
                            <div class="form-row">
                                <div class="col-sm-12">
                                    <div class="input-group mb-3 d-flex align-items-center">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text text-info">Nombre:</span>
                                        </div>
                                        <input type="text" style="text-align:left" class="form-control" id="txtEspecialidad"/>
                                    </div>
                                </div>
                            </div>
                            <hr>
                            <div class="col-md-12 text-center">
                                <button	type="button" class="btn btn-primary btn-lg" id="btnGuardar">Guardar</button> 
                            </div>
                           </div>
                        </div>
                    </div>
                </div>
           
    </section>
    
    <script type="text/javascript">
        var descripcion;

        $(document).ready(function () {

            $('#btnGuardar').click(function () {

            descripcion = $('#txtEspecialidad').val();

            var validacion = validarDatosEspecialidad();

            if (validacion === true) {

                var especialidades = {

                    p_descripcion: descripcion
                }

                console.log(especialidades);
                registrarEspecialidades(especialidades);
            }

            else
            {
                console.log("No valide datos o sali por error");

            }

        });

        });

        function registrarEspecialidades(datosEspecialidades) {
            $.ajax({
                url: "RegistrarEspecialidades.aspx/registrarEspecialidades",
                data: JSON.stringify(datosEspecialidades),
                type: "post",
                contentType: "application/json",
                async: false,
                success: function(data) {

                    if (data.d != 'OK') {
                        alert('Error al registrar la especialidad.')
                    } else {
                        alert('Especialidad registrada con Éxito.')
                    }
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    alert(data.error);
                }

            });

        }

        function validarDatosEspecialidad() {

            if (descripcion == "") {
                alert("Por favor, ingrese el nombre de la especialidad a agregar");
                return false;
            }
            else {
                return true;
            };
        };
    </script>

</asp:Content>
   
