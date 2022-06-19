<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecuperarPassword.aspx.cs" Inherits="TurneroWeb10.RecuperarPassword" %>

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
    <script type="text/javascript" src="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "Scripts/sweetalert.min.js"%>"></script>


    <title>RECUPERAR CONTRASEÑA</title>
</head>
<body>
    <div class="modal-dialog text-center">
        <div class="col-sm-8 main-section">
            <div class="modal-content">
                <div class="col-12 user-img">
                    <img src="Estilos/img/user3.png" />
                </div>
                <form class="col-12" id="form-login" action="">
                    <h6>Ingrese su email para enviarle las instrucciones de "Recuperación de Contraseña"</h6>
                    <label for="email">Email</label>
                    <div class="form-group" id="email-group">
                        <input type="text" name="email" id="txtEmail" />
                    </div>
                    <input type="button" class="btn btn-primary" id="button" value="Enviar Email" />
                </form>
                <div>
                     <br />
                    <a href="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "Login.aspx"%>">Iniciar Sesion</a>
                </div>
                <br />
            </div>
        </div>
    </div>
    <script type="text/javascript" src="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "Scripts/sweetalert.min.js"%>"></script>
    <script type="text/javascript" src="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "ScriptsPantallas/RecuperarPassword.js"%>"></script>
</body>
</html>
