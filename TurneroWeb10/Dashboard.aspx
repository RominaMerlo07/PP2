<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="TurneroWeb10.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <style>

        #dashboard {
         background-color: white;
        }

        #date_range1, 
        #date_range {
      
        
         cursor: pointer;
         padding: 15px 15px; 
         border: none;
         
        }

        

        #tarjetas-totales{
        
         

        }

        #tarj-os {
        
            

        }

        #i-flechita, #i-calendario {
        
            cursor:pointer;
        }

        .card-body:hover {
        
        background-color:white;
        
        }

        #div-header {
        
        background-color: yellow;
        
        }
        #div-header :hover {
        
           background-color:none;
       
        background-color:hotpink;
        
        }



    </style>


        <section id="dashboard">

            <div class="row" style="padding-bottom:0px; padding-top:20px;">
                <p class="mx-auto" style="font-family:'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode'; font-size:50px;">Sparrring Dashboard</p>

            </div>

  <div class="row justify-content-end text-end pt-3 pb-2 mr-4">
      <div class="bg-white h-100 pl-3" style="border: 1px solid #ccc; border-radius:3px; width:270px;">
          <i class="fa fa-calendar" id="i-calendario"></i>&nbsp;
          <input class="h-100" type="text" name="daterange" value="01/01/2021 - 01/01/2022" id="date_range" style="width:190px;"/>
           <span><i class="fa fa-caret-down" id="i-flechita"></i></span>
      </div>
 </div>
            
  
    <div class="row">
      <div class="col-12 mb-1 justify-content-center d-flex text-center">
          <h1></h1>
      </div>
    </div>
        <div class="row justify-content-between pb-5 ml-2 mr-2" id="tarjetas-totales">

            <div class="col text-center mx-0 h-100">
                 <div class="card" style="border-color: black;">
                   <div class="card-content">
                       <div class="h-100 w-100" id="div-header">
                       <div class="card-header h-100 w-100">
                           
                               <h2 class="card-tittle" style="border-color:black; font-size: 20px;"> Turnos Otorgados</h2>
                           </div>
                           
                       </div>
                    <div class="card-body" <%--style="background-color:rgb(8,116,140,0.8);--%>">
                        <p id="total-turnos" style="font-family:'Arial Rounded MT'; font-size: 50px" ></p>
                  </div>
                </div>
              </div>
            </div>
            
            <div class="col text-center mx-0 h-100">
                 <div class="card h-100" style="border-color: black;">
                   <div class="card-content">
                        <div class="card-header">
                          <h2 class="card-tittle" style="border-color:black; font-size: 20px;">Turnos Atendidos</h2>
                        </div>
                        <div class="card-body" <%--style="background-color:rgb(8,116,140,0.8);--%>">
                                <p id="turnos-atendidos" style="font-family:'Arial Rounded MT'; font-size: 50px"></p>
                        </div>
                       </div>
                     </div>
                    </div>
                
             <div class="col text-center mx-0 h-100">
                 <div class="card h-100" style="border-color: black;">
                   <div class="card-content h-100">
                       <div class="card-header" <%--style="background-color:#fdfd96;"--%> id="tarj-os">
                           <h2 class="card-tittle" style="border-color:rgb(8,116,140,0.8);font-size: 20px;">Obra Social-Part</h2>
                       </div>
                    <div class="card-body" style="width:250px; height:130px;">
                        <div style="position:absolute; top:60px; left:10px; width:250px; height:130px;">
                            <canvas id="grafico-os-sparring"></canvas>
                    </div>
                        </div>
                       </div>
                    </div>
                </div>

            <div class="col text-center mx-0 h-100">
                <div class="card" style="border-color: black;">
                   <div class="card-content h-100">
                       <div class="card-header">
                           <h2 class="card-tittle" style="border-color:black; font-size: 20px;">Turnos Cancelados</h2>
                       </div>
                    <div class="card-body">
                <p id="turnos-cancelados" style="font-family:'Arial Rounded MT'; font-size: 50px"></p>
            </div>
           </div>
          </div>
        </div>
      
       </div>
        <div class="row justify-content-start ml-4 pb-4">
            <h1 class="text-uppercase" style="font-size:50px;">Sucursales</h1>
        </div>
        <div class="row justify-content-between">
            <div class="col-8 mx-auto">
                    <div class="card-body">
                        <div style="position:absolute; top:60px; left:60px; right:60px; width:500px; height:400px;">
                     <canvas id="turnos-por-centros"></canvas>
                     </div>
                     </div>
                     </div>
                    </div>
            <%--<div class="col">--%>
                            <div class="row justify-content-between" style="padding-top:300px;">
                                <div class="col-4">
                                    <div class="card">
                                        <div class="card-content">
                                            <div class="card-header">
                                                 <h3 class="card-title">Carlos Paz I</h3>
                                            </div>
                                            <div class="card-body">
                                               
                                    <p >Atendidos</p>
                                    <h3 id="atendidos-cp1" style="color:#F06057"></h3>
                                    <p>Cancelados</p>
                                    <h3 id="cancelados-cp1" style="color:#0D2A73"></h3>
                                    
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-4">
                                    <div class="card">
                                        <div class="card-content">
                                            <div class="card-header">
                                                <h3 class="card-title">Carlos Paz II</h3>
                                            </div>
                                            <div class="card-body">
                                    <p>Atendidos</p>
                                    <h3 id="atendidos-cp2" style="color:#F06057"></h3>
                                    <p>Cancelados</p>
                                    <h3 id="cancelados-cp2" style="color:#0D2A73">
                                        
                                    </h3>
                                    <%--<p>Nuevos Clientes</p>--%>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                 <div class="col-4">
                                    <div class="card">
                                        <div class="card-content">
                                            <div class="card-header">
                                                <h3 class="card-title">Córdoba</h3>
                                            </div>
                                            <div class="card-body">
                                    <p>Atendidos</p>
                                     <h3 id="atendidos-c" style="color:#F06057"></h3>
                                    <p>Cancelados</p>
                                     <h3 id="cancelados-c" style="color:#0D2A73"></h3>
                                               
                                    <%--<p>Nuevos Clientes</p>--%>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                            </div>

                       <%-- </div>--%>
                      
         
  <section id="stats-subtitle">
  <div class="row">
    <div class="col-12 mt-3 mb-1 pt-5 pb-3 ml-4">
      <h4 class="text-uppercase" style="font-size: 50px;">Estadísticas</h4>
    </div>
  </div>
       <div class="row pb-4 ml-3 mr-3 justify-content-end">
            <div class="bg-white col-3" style="border: 1px solid #ccc; border-radius:3px; width:10px;">
          <i class="fa fa-calendar"></i>&nbsp;
          <input class="h-100 w-75" type="text" name="daterange1" value="01/01/2021 - 15/01/2022" id="date_range1" style="width:400px;"/>
           <span></span><i class="fa fa-caret-down" id="i-flechita1"></i>
      </div>
     <%-- <div class="col-12 justify-content-end d-flex text-end h-100">
          <input class="h-100" type="text" name="daterange1" value="01/01/2021 - 01/15/2021" id="data_range1"/>
      </div>--%>
      </div>

     


 </section>
  
        <div class="row mr-3 ml-3 pb-3">
            <div class="col-6 align-content-end">
                 <div class="card">
        <div class="card-header">
            <h3 class="card-title">Especialidades más demandadas</h3>
        </div>
        <div class="card-body" style="width:450px; height:300px;">

            <div style="position:absolute; top:60px;width:450px; height:300px; padding-top:40px;">
                <canvas id="grafico-especialidades"></canvas>
            </div>
            
        </div>
        </div>
        </div>
            <div class="col-6 bg-accent-3">
                <div class="card">
        <div class="card-header">
            <h3 class="card-title">Especialidades menos demandadas</h3>
        </div>
        <div class="card-body" style="width:450px; height:300px;">
            <div style="position:absolute; top:60px;width:450px; height:300px; padding-top:40px;">
                <canvas id="grafico-especialidades-menos"></canvas>
            </div>
            
        </div>
        </div>
            </div>
              
        </div>

        
  <div class="row">
    <div class="col-12 mt-3 mb-1 pt-4 pb-4 ml-3 mr-3">
      <h2 class="text-uppercase">Especialidades más demandadas según centro</h2>
    </div>
  </div>
            

        <div class="row justify-content-between ml-3 mr-3 ">
            <div class="col-4">
             <div class="card">
                <div class="card-header">
                <h3 class="card-title">Carlos Paz I</h3>
                </div>
        <div class="card-body" style="width:400px; height: 400px;">
            <div style="position:absolute; top:60px;width:400px; height:400px; padding-top:40px;">
                <canvas id="grafico-especialidades-mas-cp1"></canvas>
            </div>
              
        </div>
        </div>
            </div>
                        <div class="col-4">
                     <div class="card">
        <div class="card-header">
            <h3 class="card-title">Carlos Paz II</h3>
        </div>
        <div class="card-body" style="width:400px; height: 400px;">
            <div style="position:absolute; top:60px;width:400px; height:400px; padding-top:40px;">

            </div>
            <canvas id="grafico-especialidades-mas-cp2"></canvas>
        </div>
        </div>
            </div>
                        <div class="col-4">
                     <div class="card">
        <div class="card-header">
            <h3 class="card-title">Córdoba</h3>
        </div>
        <div class="card-body" style="width:400px; height: 400px;">
            <div style="position:absolute; top:60px;width:400px; height:400px; padding-top:40px;">

            </div>
            <canvas id="grafico-especialidades-mas-c"></canvas>
        </div>
        </div>
            </div>
        </div>

            <div class="row justify-content-star pt-4 pb-4 ml-3 mr-3">
                <h2>ESPECIALIDADES MENOS DEMANDADAS SEGÚN CENTRO</h2>
            </div>


             <div class="row justify-content-between mr-2 ml-2 pb-5">
                        <div class="col-4">
                     <div class="card">
        <div class="card-header">
            <h3 class="card-title">Carlos Paz I</h3>
        </div>
        <div class="card-body" style="width:400px; height: 400px;">
            <div style="position:absolute; top:60px;width:400px; height:400px; padding-top:40px;">
                <canvas id="grafico-especialidades-menos-cp1"></canvas>
            </div>
            
        </div>
        </div>
            </div>
            
                        <div class="col-4">
                     <div class="card">
        <div class="card-header">
            <h3 class="card-title">Carlos Paz II</h3>
        </div>
        <div class="card-body" style="width:400px; height: 400px";>
            <div style="position:absolute; top:60px;width:400px; height:400px; padding-top:40px;">
                <canvas id="grafico-especialidades-menos-cp2"></canvas>
            </div>
            
        </div>
        </div>
            </div>
                        <div class="col-4">
                     <div class="card">
        <div class="card-header">
            <h3 class="card-title">Córdoba</h3>
        </div>
        <div class="card-body" style="width:400px; height: 400px";>
            <div style="position:absolute; top:60px;width:400px; height:400px; padding-top:40px;">
                <canvas id="grafico-especialidades-menos-c"></canvas>
            </div>
            
        </div>
        </div>
            </div>


         </div>
       
        </section>

  

        


           

           

           
       
        <%--<script type="text/javascript" src="https://cdn.jsdelivr.net/npm/daterangepicker/daterangepicker.min.js"></script>
        <link rel="stylesheet" type="text/css" href="https://cdn.jsdelivr.net/npm/daterangepicker/daterangepicker.css" />--%>
    <%--<%--<script src="http://cdnjs.cloudflare.com/ajax/libs/jquery/2.0.3/jquery.min.js"></script>--%>--%>
  <%--  <script src="http://cdnjs.cloudflare.com/ajax/libs/raphael/2.1.2/raphael-min.js"></script>--%>
    <%--<script src="https://cdnjs.cloudflare.com/ajax/libs/morris.js/0.5.0/morris.min.js"></script>--%>
    <%--<script src="js/chartdata.js"></script>--%>
  
        <script type="text/javascript" src="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "ScriptsPantallas/Dashboard.js"%>"></script>
      
       


       

    </asp:Content>
    



