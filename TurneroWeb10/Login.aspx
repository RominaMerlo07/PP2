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
                        <input type="text" name="usuario" id="txtUsuario" />
                    </div>
                    <label for="password">Contraseña</label>
                    <div class="form-group" id="password-group">
                        <input type="password"name="password" id="txtPassword" />                        
                    </div>
                    <button type="submit" class="btn btn-info" id="btnIngresar"><i class="fas fa-sign-in-alt"></i> INGRESAR</button>
                </form>
            </div>
        </div>
    </div>



    
    <script type="text/javascript" src="<%=ConfigurationManager.AppSettings["ROOT_PATH"] + "Scripts/Login.js"%>"></script>
    

</body>
</html>
