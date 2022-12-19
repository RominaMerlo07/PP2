<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="TurneroWeb10.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <style>

        #dashboard {
         background-color: ghostwhite;
        }

        #date_range1, 
        #date_range {
         cursor: pointer;
         padding: 15px 15px; 
         border: none;
        }

        
        #tarjetas-totales > .card:hover{
        
            
        }

        #tarj-os {
        }

        #i-flechita, 
        #i-calendario, 
        #i-flechita1,
        #i-calendario1 {
            cursor:pointer;
        }

        /*.card-body:hover {
        
        background-color:white;
        
        }

        #div-header {
        
        background-color: yellow;
        
        }*/
        #div-header :hover {
        
        /*background-color:none;*/
       
        background-color:#84b6f4;
        
        }

      

        #div-header-a :hover {
        
        background-color:#77dd77;
        
        }

          #div-header-os :hover {
        
        background-color:#ffff00;
        }

           #div-header-canc :hover {
        
        background-color:#ff6961;
        }

        canvas {
        
            cursor:pointer;
            
        }
        .card {
        
            border-style:none;
            box-shadow:#dcdcdc 3px 3px;

        }

        
        

    </style>


        <section id="dashboard">

            <div class="row" style="padding-bottom:0px; padding-top:20px;">
                <p class="ml-5" style="font-family:'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode'; font-size:50px;">
                   
                    Sparrring Dashboard</p>
            </div>
      

    <section>

  <div class="row justify-content-end text-end pt-3 pb-2 mr-4">
      <div class="bg-white h-100 pl-3" style="border: 1px solid #ccc; border-radius:3px; width:275px;">
          <i class="fa fa-calendar" id="i-calendario"></i>&nbsp;
          <input class="h-100" type="text" name="daterange"  id="date_range" style="width:190px;"/>
           <span><i class="fa fa-caret-down" id="i-flechita"></i></span>
      </div>
 </div>
            
  
    <div class="row">
     <%-- <div class="col-12 mb-1 justify-content-center d-flex text-center">
          <h1></h1>
      </div>--%>
    </div>
        <div class="row justify-content-between pb-5 ml-2 mr-2" id="tarjetas-totales" style="position:sticky;">

            <div class="col text-center mx-0 h-100">
                 <div class="card"id="card-otorgados" <%--style="border-color: black;--%>">
                   <div class="card-content">
                       <div class="h-100 w-100" id="div-header" style="background-color:#6a9eda">
                       <div class="card-header h-100 w-100">
                           <h2 class="card-tittle" style="/*border-color:black;*/ font-size:20px;">
                                 <i class="fa-sharp fa-solid fa-calendar"></i>
                                   Turnos Otorgados</h2>
                           </div>
                           
                       </div>
                    <div class="card-body" <%--style="background-color:rgb(8,116,140,0.8);--%>">
                        <p id="total-turnos" style="font-family:'Arial Rounded MT'; font-size: 50px" ></p>
                  </div>
                </div>
              </div>
            </div>
            
            <div class="col text-center mx-0 h-100">
                 <div class="card h-100" style="/*border-color: black*/;">
                   <div class="card-content">
                       <div class="h-100 w-100" id="div-header-a" style="background-color:#42ab49">

                        <div class="card-header">
                            
                          <h2 class="card-tittle" style="/*border-color:black;*/ font-size: 20px;"> 
                              <i class="fa-solid fa-calendar-check"></i>
                              Turnos Atendidos</h2>
                        </div>
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
                       <div class="h-100 w-100" id="div-header-os" style="background-color:#ffff6a">

                       <div class="card-header"  id="tarj-os">
                          
                           <h2 class="card-tittle" style="border-color:rgb(8,116,140,0.8);font-size: 20px;">
                               Obra Social-Part Atendidos</h2>
                       </div>
                     </div>
                    <div class="card-body" style="width:250px; height:130px;">
                        <div style="position:absolute; top:60px; left:10px; width:250px; height:100px;">
                            <canvas id="grafico-os-sparring"></canvas>
                    </div>
                       
                        </div>
                       </div>
                    </div>
                </div>

            <div class="col text-center mx-0 h-100">
                <div class="card" style="border-color: black;">
                   <div class="card-content h-100">
                       <div class="h-100 w-100" id="div-header-canc" style="background-color:#e2504c">

                       <div class="card-header">
                           <h2 class="card-tittle" style="border-color:black; font-size: 20px;">
                               <i class="fa-solid fa-calendar-xmark"></i>
                               Turnos Cancelados</h2>
                       </div>
                     </div>
                    <div class="card-body">
                <p id="turnos-cancelados" style="font-family:'Arial Rounded MT'; font-size: 50px"></p>
            </div>
           </div>
          </div>
        </div>
      
       </div>
    
    </section>

    <section>

    
        <div class="row justify-content-start ml-4 pb-4" style="position:static;">
            <h1 class="text-uppercase" style="font-size:50px;">Sucursales</h1>
        </div>
        <div class="row justify-content-between" >
            <div class="col-8 mx-auto">
                <div class="card">
                    <div class="card-content">
                        <div class="card-header">
                            <h3 class="card-title text-center">Cantidad de turnos atendidos y cancelados por sucursal</h3>
                        </div>
                          <div class="card-body" style="width:200px; height:300px;">
                        <div style="position:absolute; top:60px; margin-left:140px; margin-right:60px; width:500px; height:400px; padding-top:20px;">
                     <canvas id="turnos-por-centros"></canvas>
                     </div>
                     </div>
                    </div>
                </div>
                  
                     </div>
                    </div>
            <%--<div class="col">--%>
                            <div class="row justify-content-between ml-2 mr-2" style="padding-top:100px;">
                                <div class="col-4">
                                    <div class="card" style="border-color:black;">
                                        <div class="card-content">
                                            <div class="card-header">
                                                 <h3 class="card-title">Carlos Paz I</h3>
                                            </div>
                                            <div class="card-body">
                                               
                                    <p style="font-family:'Arial Rounded MT';font-size:20px;">Atendidos</p>
                                    <h3 id="atendidos-cp1" style="color:#42ab49"></h3>
                                    <p style="font-family:'Arial Rounded MT';font-size:20px;">Cancelados</p>
                                    <h3 id="cancelados-cp1" style="color:#F06057"></h3>
                                    
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-4">
                                    <div class="card" style="border-color:black;">
                                        <div class="card-content">
                                            <div class="card-header">
                                                <h3 class="card-title">Carlos Paz II</h3>
                                            </div>
                                            <div class="card-body">
                                    <p style="font-family:'Arial Rounded MT';font-size:20px;">Atendidos</p>
                                    <h3 id="atendidos-cp2" style="color:#42ab49"></h3>
                                    <p style="font-family:'Arial Rounded MT';font-size:20px;">Cancelados</p>
                                    <h3 id="cancelados-cp2" style="color:#F06057">
                                        
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
                                    <p style="font-family:'Arial Rounded MT';font-size:20px;">Atendidos</p>
                                     <h3 id="atendidos-c" style="color:#42ab49"></h3>
                                    <p style="font-family:'Arial Rounded MT';font-size:20px;">Cancelados</p>
                                     <h3 id="cancelados-c" style="color:#F06057"></h3>
                                               
                                    <%--<p>Nuevos Clientes</p>--%>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                            </div>

                       <%-- </div>--%>
    </section>                  
         
  <section id="stats-subtitle">
  <div class="row">
    <div class="col-12 mt-3 mb-1 pt-5 pb-3 ml-4">
      <h4 class="text-uppercase" style="font-size: 50px;">Estadísticas</h4>
    </div>
  </div>
       <div class="row pb-4 ml-3 mr-4 justify-content-end">
            <div class="bg-white col-3" style="border: 1px solid #ccc; border-radius:3px; width:10px; margin-right:5px;">
          <i class="fa fa-calendar" id="i-calendario1"></i>&nbsp;
          <input class="h-100 w-75" type="text" name="daterange1" id="date_range1" style="width:360px;"/>
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
            <h4 class="card-title" style="font-size:25px;">Cantidad de especialidades más demandadas</h4>
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
            <h4 class="card-title" style="font-size:25px;">Cantidad de especialidades menos demandadas</h4>
        </div>
        <div class="card-body" style="width:450px; height:300px;">
            <div style="position:absolute; top:60px;width:450px; height:300px; padding-top:40px;">
                <canvas id="grafico-especialidades-menos"></canvas>
            </div>
            
        </div>
        </div>
            </div>
              
        </div>

        
  <div class="row ml-2">
    <div class="col-12 mt-3 mb-1 pt-4 pb-4 ml-3 mr-3">
      <h3 class="text-uppercase"> Porcentaje de especialidades más demandadas según centro</h3>
    </div>
  </div>
            

        <div class="row justify-content-between ml-3 mr-3 ">
            <div class="col-4">
             <div class="card">
                <div class="card-header">
                <h3 class="card-title">Carlos Paz I</h3>
                </div>
        <div class="card-body" style="width:400px; height: 350px;">
            <div style="position:absolute; top:60px;width:300px; height:400px; padding-top:40px;">
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
        <div class="card-body" style="width:400px; height: 350px;">
            <div style="position:absolute; top:60px;width:300px; height:400px; padding-top:40px;">
                <canvas id="grafico-espec-mas-cp2"></canvas>
            </div>
            
        </div>
        </div>
            </div>
                        <div class="col-4">
                     <div class="card">
        <div class="card-header">
            <h3 class="card-title">Córdoba</h3>
        </div>
        <div class="card-body" style="width:400px; height:350px;">
            <div style="position:absolute; top:60px;width:300px; height:400px; padding-top:40px;">

            </div>
                    <canvas id="grafico-espec-mas-cba"></canvas>
           <%-- <canvas id="grafico-espec-mas-c"></canvas>--%>
        </div>
        </div>
            </div>
        </div>

            <div class="row justify-content-star pt-4 pb-4 ml-3 mr-3">
                <h3>PORCENTAJE DE ESPECIALIDADES MENOS DEMANDADAS SEGÚN CENTRO</h3>
            </div>


             <div class="row justify-content-between mr-2 ml-2 pb-5">
                        <div class="col-4">
                     <div class="card">
        <div class="card-header">
            <h3 class="card-title">Carlos Paz I</h3>
        </div>
        <div class="card-body" style="width:400px; height: 400px;">
            <div style="position:absolute; top:60px;width:350px; height:400px; padding-top:40px;">
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
            <div style="position:absolute; top:60px;width:350px; height:400px; padding-top:40px;">
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
            <div style="position:absolute; top:60px;width:350px; height:400px; padding-top:40px;">
                <canvas id="grafico-especialidades-menos-c"></canvas>
            </div>
            
        </div>
        </div>
            </div>


         </div>
       
        </section>

  

        


           

           

           
       
        <%--<script type="text/javascript" src="https://cdn.jsdelivr.net/npm/daterangepicker/daterangepicker.min.js"></script>
        <link rel="stylesheet" type="text/css" href="https://cdn.jsdelivr.net/npm/daterangepicker/daterangepicker.css" />--%>
    <%--<%--<script src="http://cdnjs.cloudflare.com/ajax/libs/jquery/2.0.3/jquery.min.js"></script>--%>
  <%--  <script src="http://cdnjs.cloudflare.com/ajax/libs/raphael/2.1.2/raphael-min.js"></script>--%>
    <%--<script src="https://cdnjs.cloudflare.com/ajax/libs/morris.js/0.5.0/morris.min.js"></script>--%>
    <%--<script src="js/chartdata.js"></script>--%>
  
        <script type="text/javascript" src="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "ScriptsPantallas/Dashboard.js"%>"></script>
      
       


       

    </asp:Content>
    



