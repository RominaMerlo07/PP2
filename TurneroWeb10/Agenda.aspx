<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Agenda.aspx.cs" Inherits="TurneroWeb10.Agenda" %>
<%@ Register Src="~/UserControls/AgendaTurnos.ascx" TagPrefix="uc1" TagName="control"%> 

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style>

    </style>
    <div class="content-header">
        <h1 style="text-align: left">AGENDA</h1>

        <ul class="nav nav-tabs">
            <li class="nav-item"><a class="nav-link active" data-toggle="tab" href="#userControl">Turnos</a></li>
          <%--  <li class="nav-item"><a class="nav-link " data-toggle="tab" href="#menuAlquilerD">Profesionales</a></li>  --%>     
        </ul>

        <div class="tab-content">
            
            <div id="userControl" class="tab-pane fade in active show">
                <uc1:control id="studentcontrol" runat="server" />
            </div>
           <%-- <div id="menuAlquilerD" class="tab-pane fade in active">
                <h3>Gracias, vuelva pronto.</h3>
            </div>--%>

        </div>
    </div>
    <script type="text/javascript">

    </script>
</asp:Content>