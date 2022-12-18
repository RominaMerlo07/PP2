<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AcercaDe.aspx.cs" Inherits="TurneroWeb10.AcercaDe" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .datepicker.date {
            width: 100%;
        }
    </style>
  <section class="content-header">
        <h1 style="text-align: left">ACERCA DE</h1>      
    </section>
    <section class="content">
        <div class="row">
            <div class="col-md-6">
                <div class="box-body table-responsive">
                    <table class="table table-striped">
                        <tbody>
                            <tr>
                                <th scope="row">Manual de Usuario</th>
                                <td>
                                    <a href="Archivos/Manual de Usuario.pdf" download="Manual_de_usuario">
                                        <i class="fas fa-file-download"></i> Descargar
                                    </a> 
                                </td>
                            </tr>
                            <tr>
                                <th scope="row">Carpeta de Administración de Proyectos</th>
                                <td>
                                    <a href="Archivos/Carpeta de Administracion de Proyectos.zip" download="Carpeta_de_administracion_de_proyectos">
                                        <i class="fas fa-file-download"></i> Descargar
                                    </a> 
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <div class="col-md-6">
                <div class="box-body table-responsive">
                    <table class="table table-striped">
                        <tbody>
                            <tr>
                                <th scope="row">Carpeta de Práctica Profesionalizante</th>
                                <td>
                                    <a href="Archivos/Carpeta de Practica Profesionalizante.zip" download="Carpeta_de_practica_profesionalizante">
                                        <i class="fas fa-file-download"></i> Descargar
                                    </a> 
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </section>

</asp:Content>

