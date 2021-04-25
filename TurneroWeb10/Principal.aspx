<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="TurneroWeb10.Principal" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%--<button type="btnTurnos" class="btn btn-info">Turnos</button>--%>
    <div class="contenedor_turnos">

        <h1 class="tituloH1">Bienvenido</h1>
        <br />
        <a id="btnTurnos" name="btnTurnos" class="btn btn-info" href="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "/Turnos.aspx"%>">Turnos</a>

    </div>

</asp:Content>



