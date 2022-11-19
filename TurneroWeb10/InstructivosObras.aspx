<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InstructivosObras.aspx.cs" Inherits="TurneroWeb10.InstructivosObras" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .datepicker.date {
            width: 100%;
        }
    </style>
  <section class="content-header">
        <h1 style="text-align: left">INSTRUCTIVOS PARA OBRAS SOCIALES</h1>      
    </section>
    <section class="content">
        <div class="row">
            <div class="col-md-6">
                <div class="box-body table-responsive">
                    <table class="table table-striped">
                        <thead >
                        <tr class="table-success">
                            <th scope="col">Obra Social</th>
                            <th scope="col">Instructivo</th>
                        </tr>
                        </thead>
                        <tbody>
                        <tr>
                            <th scope="row">Avalian</th>
                            <td>
                                <a target="_blank" href="http://www.regional4.org.ar/administrador/kcfinder/upload/files/Nuevo%20Instructivo%20-%20Aca%20Salud.pdf">
                                    <i class="fas fa-file-download"></i> Instructivo Avalian
                                </a> <br />
                                <a target="_blank" href="http://regional4.org.ar/administrador/kcfinder/upload/files/AcaSalud.pdf">
                                    <i class="fas fa-file-download"></i> Planilla de Registro de Sesiones
                                </a>
                            </td>
                        </tr>
                        <tr>
                            <th scope="row">Amicos</th>
                            <td>Viene autorizada por el afiliado (Talonario Azul).</td>
                        </tr>
                        <tr>
                            <th scope="row">Amur</th>
                            <td>
                                <a target="_blank" href="http://regional4.org.ar/wp-content/uploads/2019/07/Nota-prestadores-Credencial-digital-AMUR-octubre-2020.docx">
                                    <i class="fas fa-file-download"></i> Nota prestadores Credencial digital AMUR
                                </a> <br/>
                                Viene autorizada por el afiliado (Talonario Azul).
                            </td>
                        </tr>
                        <tr>
                            <th scope="row">APROSS</th>             
                            <td>
                                <a target="_blank" href="http://regional4.org.ar/instructivo/apross/">
                                    <i class="fas fa-external-link-alt"></i> Instructivo
                                </a> <br/>
                            </td>
                        </tr>
                        <tr>
                            <th scope="row">Banco de Córdoba</th>
                            <td>Viene autorizada por el paciente (Talonario Azul).</td>
                        </tr>
                        <tr>
                            <th scope="row">Boreal</th>
                            <td>
                                <a target="_blank" href="http://regional4.org.ar/instructivo/boreal/">
                                    <i class="fas fa-external-link-alt"></i> Instructivo
                                </a> <br/>
                            </td>
                        </tr>
                        <tr>
                            <th scope="row">Caja de Abogados</th>
                            <td>Viene autorizada por el afiliado, el cual debe abonar el 20% del total de las sesiones (Talonario azul).</td>
                        </tr>
                        <tr>
                            <th scope="row">Caja Notarial</th>
                            <td>Viene autorizado por el paciente. (Talonario azul).</td>
                        </tr>
                        <tr>
                            <th scope="row">CPCE</th>
                            <td>
                                <a target="_blank" href="http://regional4.org.ar/instructivo/cpce/">
                                    <i class="fas fa-external-link-alt"></i> Instructivo
                                </a> <br/>
                            </td>
                        </tr>
                        <tr>
                            <th scope="row">DASPU</th>
                            <td>
                                <a target="_blank" href="http://regional4.org.ar/instructivo/daspu/">
                                    <i class="fas fa-external-link-alt"></i> Instructivo
                                </a> <br/>
                            </td>
                        </tr>
                        <tr>
                            <th scope="row">Dasuten</th>
                            <td>Viene autorizado por el paciente, si el el rp figura magnetoterapia, corroborar que venga la autorización por la magnetoterapia para poder facturarla. (Talonario azul).</td>
                        </tr>
                        <tr>
                            <th scope="row">EnSalud</th>
                            <td>
                                <a target="_blank" href="http://regional4.org.ar/instructivo/ensalud/">
                                    <i class="fas fa-external-link-alt"></i> Instructivo
                                </a> <br/>
                            </td>
                        </tr>
                        <tr>
                            <th scope="row">Federada Salud</th>
                            <td>
                                <a target="_blank" href="http://regional4.org.ar/instructivo/federada-25-de-junio/">
                                    <i class="fas fa-external-link-alt"></i> Instructivo
                                </a> <br/>
                            </td>
                        </tr>
                        <tr>
                            <th scope="row">Gráficos</th>
                            <td>Viene autorizada por el afiliado (talonario azul).</td>
                        </tr>
                        <tr>
                            <th scope="row">Integral Salud</th> 
                            <td>
                                <a target="_blank" href="http://regional4.org.ar/instructivo/integral-salud-ospoce-integral-ossdeb-integral-oscep-inte/">
                                    <i class="fas fa-external-link-alt"></i> Instructivo
                                </a> <br/>
                            </td>
                        </tr>
                        <tr>
                            <th scope="row">IOSFA</th>
                            <td>
                                <a target="_blank" href="http://regional4.org.ar/instructivo/iosfa/">
                                    <i class="fas fa-external-link-alt"></i> Instructivo
                                </a> <br/>
                            </td>
                        </tr>
                        <tr>
                            <th scope="row">Jerárquicos Salud</th>
                            <td>
                                <a target="_blank" href="http://regional4.org.ar/instructivo/jerarquicos-salud/">
                                    <i class="fas fa-external-link-alt"></i> Instructivo
                                </a> <br/>
                            </td>
                        </tr>
                        <tr>
                            <th scope="row">La Holando ART</th>
                            <td>Viene autorizado por el paciente (talonario azul). El licenciado debe completar todas las planillas que manda la ART.</td>
                        </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <div class="col-md-6">
                <div class="box-body table-responsive">
                    <table class="table table-striped">
                        <thead>
                        <tr class="table-success">
                            <th scope="col">Obra Social</th>
                            <th scope="col">Instructivo</th>
                        </tr>
                        </thead>
                        <tbody>
                        <tr>
                            <th scope="row">La Segunda ART</th>
                            <td>Viene autorizado por el paciente (talonario azul). El licenciado debe completar todas las planillas que manda la ART.</td>
                        </tr>
                        <tr>
                            <th scope="row">Luis Pasteur</th>
                            <td>Viene autorizado por el paciente. Los Copagos figuran en la autorización y serán descontados del valor total de la sesión.</td>
                        </tr>
                        <tr>
                            <th scope="row">Madereros</th>
                            <td>Viene autorizado por el paciente (talonario azul).</td>
                        </tr>
                        <tr>
                            <th scope="row">Medicus</th>
                            <td>Viene autorizado por el paciente (talonario azul).</td>
                        </tr>
                        <tr>
                            <th scope="row">Medifé</th>
                            <td>
                                <a target="_blank" href="http://regional4.org.ar/instructivo/medife/">
                                    <i class="fas fa-external-link-alt"></i> Instructivo
                                </a> <br/>
                            </td>
                        </tr>
                        <tr>
                            <th scope="row">Mutual del Clero</th>
                            <td>Viene autorizado por el paciente (talonario azul).</td>
                        </tr>
                        <tr>
                            <th scope="row">Osetya</th>
                            <td>Viene autorizado por el paciente (talonario azul).</td>
                        </tr>
                        <tr>
                            <th scope="row">Ositac</th>
                            <td>
                                <a target="_blank" href="http://regional4.org.ar/instructivo/ositac/">
                                    <i class="fas fa-external-link-alt"></i> Instructivo
                                </a> <br/>
                            </td>
                        </tr>
                        <tr>
                            <th scope="row">OSPEDYC</th> 
                            <td>
                                <a target="_blank" href="http://regional4.org.ar/instructivo/ospedyc/">
                                    <i class="fas fa-external-link-alt"></i> Instructivo
                                </a> <br/>
                            </td>
                        </tr>
                        <tr>
                            <th scope="row">OSPEDYM</th>
                            <td>
                                <a target="_blank" href="http://regional4.org.ar/instructivo/ospedym/">
                                    <i class="fas fa-external-link-alt"></i> Instructivo
                                </a> <br/>
                            </td>
                        </tr>
                        <tr>
                            <th scope="row">OSPES</th> 
                            <td>
                                <a target="_blank" href="http://www.regional4.org.ar/images/obras_sociales/instructivo/instructivo-ospes.docx">
                                    <i class="fas fa-file-download"></i> Instructivo OSPES
                                </a> <br />
                            </td>
                        </tr>
                        <tr>
                            <th scope="row">Osseg</th>
                            <td>
                                <a target="_blank" href="http://regional4.org.ar/instructivo/osseg/">
                                    <i class="fas fa-external-link-alt"></i> Instructivo
                                </a> <br/>
                            </td>
                        </tr>
                        <tr>
                            <th scope="row">Prevención Salud</th>
                            <td>
                                <a target="_blank" href="http://regional4.org.ar/instructivo/prevencion-salud/">
                                    <i class="fas fa-external-link-alt"></i> Instructivo
                                </a> <br/>
                            </td>
                        </tr>
                        <tr>
                            <th scope="row">Prevención ART</th>
                            <td>El lic. deberá llenar todos los formularios que le envía la ART (talonario azul).</td>
                        </tr>
                        <tr>
                            <th scope="row">Sadaic</th>
                            <td>
                                <a target="_blank" href="http://regional4.org.ar/instructivo/sadaic/">
                                    <i class="fas fa-external-link-alt"></i> Instructivo
                                </a> <br/>
                            </td>
                        </tr>
                        <tr>
                            <th scope="row">Sancor Salud</th>
                            <td>
                                <a target="_blank" href="http://regional4.org.ar/instructivo/sancor-salud/">
                                    <i class="fas fa-external-link-alt"></i> Instructivo
                                </a> <br/>
                            </td>
                        </tr>
                        <tr>
                            <th scope="row">Sanitas</th>
                            <td>
                                <a target="_blank" href="http://regional4.org.ar/instructivo/sanitas/">
                                    <i class="fas fa-external-link-alt"></i> Instructivo
                                </a> <br/>
                            </td>
                        </tr>
                        <tr>
                            <th scope="row">SERVIRED</th>
                            <td>
                                <a target="_blank" href="http://regional4.org.ar/instructivo/servired/">
                                    <i class="fas fa-external-link-alt"></i> Instructivo
                                </a> <br/>
                            </td>
                        </tr>
                        <tr>
                            <th scope="row">UNIMED</th>
                            <td>
                                <a target="_blank" href="http://regional4.org.ar/instructivo/unimed/">
                                    <i class="fas fa-external-link-alt"></i> Instructivo
                                </a> <br/>
                            </td>
                        </tr>                    
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
