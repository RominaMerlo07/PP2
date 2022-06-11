<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="zzEjemploEnviadorMail.aspx.cs" Inherits="TurneroWeb10.zzEjemploEnviadorMail" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card-body">
        <div class="form-row">
            <div class="col-sm-4 col-md-4 col-lg-4">
                <div class="input-group mb-3">
                    <div class="form-check">
                          <input class="form-check-input" type="checkbox" value="" id="esHtml">
                          <label class="form-check-label" for="esHtml">
                            Es HTML?
                          </label>
                    </div>
                </div>
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text">Destinatario: </span>
                    </div>
                    <input type="text" style="text-align: left" class="form-control" id="txtDestinatario"   />
                    
                </div>
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text">Mensaje: </span>
                    </div>
                    <textarea style="text-align: left" class="form-control" id="txtMensaje" > </textarea>
                </div>
 
                <button class="btn btn-secondary btn-lg " type="button" onclick="enviarMail()" id="btnMail">Enviar E-Mail</button>
            </div>
        </div>
    </div>
    <script>
        var esHtml;

        $(document).ready(function () {
            $('#esHtml').on('ifChecked ', function (event) {
                esHtml = true;
            });

            $('#esHtml').on('ifUnchecked ', function (event) {
                esHtml = false;
            });
        });

        function enviarMail() {
            $.ajax({
                url: "zzEjemploEnviadorMail.aspx/enviarMail",
                data: "{destinatario: '" + $("#txtDestinatario").val()
                    + "', mensaje: '" + $("#txtMensaje").val()
                    + "', esHtml: '" + esHtml
                        + "'}",
                type: "post",
                contentType: "application/json",
                async: false,
                success: function (data) {

                    if (data.d == "OK") {
                        swal("Hecho", "Mail Enviado!", "success");
                    } else {
                        swal("Error", "No se ha podido enviar el E-mail", "warning");
                    }
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    alert(data.error);
                }

            });
        }
    </script>
</asp:Content>
