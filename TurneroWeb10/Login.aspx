<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TurneroWeb10.Login"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
     <link rel="stylesheet" type="text/css" href="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "Estilos/Content/bootstrap.min.css"%>" />

    <script type="text/javascript" src="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "Estilos/Scripts/jquery-3.0.0.js"%>"></script>
    <script type="text/javascript" src="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "Estilos/Scripts/umd/popper.min.js"%>"></script>
    <script type="text/javascript" src="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "Estilos/Scripts/bootstrap.min.js"%>"></script>


        <script type="text/javascript" src="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "Estilos/js/AdminLTE/app.js"%>"></script>

    <link href="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "Estilos/styleLogin.css"%>" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.0/css/all.css" integrity="sha384-lZN37f5QGtY3VHgisS14W3ExzMWZxybE1SJSEsQp9S+oqd12jhcu+A56Ebc1zFSJ" crossorigin="anonymous" />

    
    <title>LOGIN</title>
</head>
<body>
    <div class="modal-dialog text-center">
        <div class="col-sm-8 main-section">
            <div class="modal-content">
                <div class="col-12 user-img">
                    <img src="Estilos/img/user3.png" />
                </div>
                <form class="col-12" id="form-login" action="">
                    <label for="usuario">Usuario</label> 
                    <div class="form-group" id="user-group">                       
                        <input type="text" name="usuario" id="txtUsuario" required/>                         
                    </div>
                    <label for="password">Contraseña</label>
                    <div class="form-group" id="password-group">
                        <input type="password" name="password" id="txtPassword" required/> 
                    </div>
                    <button type="submit" class="btn btn-info" id="btnIngresar"><i class="fas fa-sign-in-alt"></i> INGRESAR</button>                    
                </form>
                <div>
                    <a href="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "RecuperarPassword.aspx"%>">Recuperar Contraseña</a>
                                    </div>
                <br />
            </div>
        </div>
    </div>


    <%--Modal Editar--%>
    <div class="modal fade" id="modalChangePassword" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" >
        <div class="modal-dialog text-center">
            <%--<div class="col-sm-8 main-section">--%>
            <div class="modal-content">
                <div class="modal-header">
                     <%--<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                   <h6 class="modal-title text-center text-info" id="myModalLabel">Modificar Contraseña</h6>--%>
                </div>
                <div class="card-body">
                    <h3 class="modal-title text-center text-info " id="myModalLabel">Modificar Contraseña</h3>
                    <br />
                    <p>Por cuestiones de seguridad, le solicitamos actualizar su contraseña</p>
                    <br />
                    <label for="password">Contraseña Actual</label>
                    <div class="form-group" id="passActual-group">
                        <input type="password" name="password" id="txtPasswordProv" /> 
                    </div>
                    <label for="password">Contraseña Nueva</label>
                    <div class="form-group" id="passNewUno-group">
                        <input type="password" name="password" id="txtpassNewUno" />  
                    </div>
                    <label for="password">Repetir Contraseña</label>
                    <div class="form-group" id="passNewDos-group">
                        <input type="password" name="password" id="txtpassNewDos" />
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-6 col-xs-6">
                            <button class="btn btn-info float-right" type="button" id="btnActualizar">MODIFICAR</button>
                        </div>
                        <div class="col-md-4 col-xs-6">
                            <button class="btn btn-secondary float-right" type="button" id="btnCancelar">Cerrar</button>
                        </div>
                    </div>

                    <%--<button type="submit" class="btn btn-info" id="btnActualizar">MODIFICAR</button>--%>
                    <%--    <button type="submit" class="btn btn-secondary" id="btnCancelar">CANCELAR</button>--%>
                </div>
            </div>
            <%--</div>--%>
        </div>
    </div>
    <script type="text/javascript" src="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "Scripts/sweetalert.min.js"%>"></script>
    <script type="text/javascript" src="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "ScriptsPantallas/Login.js"%>"></script>



</body>
</html>
