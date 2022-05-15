var id_personal, cargo, id_per, id_prof, user, password, rol, id_usuario, rolE;


$(document).ready(function () {

    $('#btnRegistrarModal').click(function () {
        $("#modalRegistrar").modal('show');
        $("#ddlRol").prop("disabled", true);    
    });

    $('#ShowPassword').click(function () {
        $('#Password').attr('type', $(this).is(':checked') ? 'text' : 'password');
    });

    $('#show_passwordA').click(function () {
        $('#Password').attr('type', $(this).is(':checked') ? 'text' : 'password');
    });
    
    sendDataUsuarios();

});

$('#btnBuscarDNI').click(function () {

    var dniPersonal = $('#txtDocumento').val();
    buscarPersonal(dniPersonal);

});


function buscarPersonal(dniPersonal) {
         
    $.ajax({
        url: "Usuarios.aspx/buscarPersonal",
        data: "{dniPersonal: '" + dniPersonal + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            var personal = JSON.parse(data.d); 

            if (personal != null) {
                                    
                personal.forEach(function (e) {

                    id_personal = e.idPersonal;
                    cargo = e.cargo;                    

                    $('#txtDocumento').prop('disabled', true);
                    $('#id__txtNombre').prop('disabled', true);
                    $('#id__txtApellido').prop('disabled', true);
                    $('#id__txtNombre').val(e.nombre);
                    $('#id__txtApellido').val(e.apellido);                    

                    generarUsuario(e.nombre, e.apellido);

                });                     
            }
            else {         
                swal("Hubo un problema", "El personal / profesional ya posee un usuario o NO se encuentra registrado. Por favor verificar", "error");
                $("#modalRegistrar").modal('hide');
            }
        }
    });
};


function generarUsuario(nombre, apellido) {

    $.ajax({
        url: "Usuarios.aspx/generarUsuario",
        data: "{nombre: '" + nombre + "', apellido: '" + apellido + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            var usuario = JSON.parse(data.d);
                   
            if (usuario != null) {           
                                       
                $('#id__txtUsuario').prop('disabled', true);
                $('#id__txtUsuario').val(usuario);                

                cargarComboRoles('#ddlRol');  
            }           
        }
    });


}

function cargarComboRoles(ddl) {


    $.ajax({
        url: "Usuarios.aspx/cargarRoles",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            if (data.d.length > 0) {
                $(ddl).empty();
                $(ddl).append('<option value="0" disabled="disabled" selected="selected" hidden="hidden">--Seleccione--</option>');

                for (i = 0; i < data.d.length; i++) {
                                        
                    $(ddl).append($("<option></option>").val(data.d[i].IdRol).html(data.d[i].NombreRol));
                }
                $(ddl).prop("disabled", false);
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            $(ddl).prop("disabled", true);
            alert(data.error);
        }
    });
}



function validarDatosUsuario() {

    if (dni == "") {
        swal("Cuidado", "Por favor, ingrese el DNI para generar el usuario.", "warning");
        return false;
    }
    if (user == "") {
        swal("Cuidado", "Por favor, ingrese un usuario.", "warning");
        return false;
    }
    else if (password == "") {
        swal("Cuidado", "Por favor, ingrese una contraseña.", "warning");
        return false;
    }
    else if (rol.length < 1) {
        swal("Cuidado", "Por favor, seleccionar un rol.", "warning");
        return false;
    }   
    else {
        return true;
    };
};



function limpiarCampos() {
    $('#txtDocumento').val("");
    $('#id__txtNombre').val("");
    $('#id__txtApellido').val("");
    $('#ddlRol').val([]);
    $('#id__txtUsuario').val("");
    $('#id__txtPassword').val("");   
};


$('#btnRegistrar').click(function () {

    dni = $('#txtDocumento').val();
    user = $('#id__txtUsuario').val();
    password = $('#id__txtPassword').val();
    rol = $('#ddlRol').val();
    var validacion = validarDatosUsuario();

    if (validacion === true) {

        if (cargo === "PROFESIONAL") {

            id_per = null;
            id_prof = id_personal;
        }
        else {
            id_per = id_personal;
            id_prof = null;
        }

        var usuario = {

            p_idPersonal : id_per,
            p_idProfesional : id_prof,
            p_user : user,
            p_password : password,
            p_rol : rol
        }
       
        registrarUsuario(usuario);
        
    }

});


function registrarUsuario(usuario) {
   $.ajax({
        url: "Usuarios.aspx/registrarUsuario",
        data: JSON.stringify(usuario),
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {
          
            if (data.d != "OK") {
            
                swal("Hubo un problema", "Error al registrar el usuario!", "error"); //error

            } else {
                           
                $("#modalRegistrar").modal('hide');
                swal("Hecho", "Usuario registrado con Éxito!", "success"); //error
                sendDataUsuarios();
                limpiarCampos();

            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(data.error);
        }

    });
};


function sendDataUsuarios() {
    $.ajax({
        type: "POST",
        url: "Usuarios.aspx/cargarUsuarios",
        data: {},
        contentType: 'application/json; charset=utf-8',
        async: false,
        success: function (data) {

            var datos = JSON.parse(data.d);           
            var arrayUsuarios = new Array();

            datos.forEach(function (e) {

                var Numero = e.ID_USUARIO;
                var DNI = e.Documento;
                var Personal = (e.NOMBRE + ", " + e.APELLIDO);
                var Usuario = e.NOMBRE_USUARIO;
                var Rol = e.Rol;

              
                var Acciones = '<a href="#" onclick="return actualizar(' + Numero + ",'" + Personal + "'" + ",'" + Rol + "'" + ')"  class="btn btn-primary" > <span class="fas fa-user-edit"></span></a > ';

                //' + "'"+ Numero +"'"+ '
                arrayUsuarios.push([
                    Numero, DNI, Personal, Usuario, Rol, Acciones
                ])
            });

            var table = $('#tabla_usuarios').DataTable({
                data: arrayUsuarios,
                "scrollX": true,
                "languaje": {
                    "url": "//cdn.datatables.net/plug-ins/1.10.12/i18n/Spanish.json"
                },
                "ordering": true,
                "bDestroy": true,
                "bAutoWidth": true,
                columns: [
                    { title: "Numero", visible: false },
                    { title: "DNI" },
                    { title: "Personal" },
                    { title: "Usuario" },
                    { title: "Rol" },
                    { title: "Acciones" }
                ],
                dom: 'Bfrtip',
                dom: '<"top"B>rti<"bottom"fp><"clear">',
                "oLanguage": {
                    "sSearch": "Filtrar:",
                    "oPaginate": {
                        "sPrevious": "Anterior",
                        "sNext": "Siguiente"
                    }
                },
                "bPaginate": true,
                "pageLength": 5,
                buttons: [
                    //{ extend: 'copy', text: "Copiar" },
                    { extend: 'print', text: "Imprimir" },
                    { extend: 'pdf', orientation: 'landscape' },
                    { extend: 'colvis', columns: ':not(:first-child)', text: "Ocultar/Mostrar columnas" }
                ]
            });

        },
        error: function (xhr, ajaxOptions, thrownError) {
            //$(ddl).prop("disabled", true);
            //alert(data.error);
            //console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        }
    })
};



function actualizar(idBuscar, personal, rol) {   

    id_usuario = idBuscar;
    $("#ddlRol").prop("disabled", true);   
    $("#id__txtUsuarioE").prop("disabled", true);      
    $("#id__txtPasswordE").attr('type', 'password'); 

    var texto;

    if (rol === "DIRECTIVO" || rol === "PROFESIONAL") {

        texto = "Profesional: " + personal;
    }
    else {
        texto = "Personal: " + personal;
    }
       
    $("#infoProfesional").text(texto);
    cargarComboRoles('#ddlRolE'); 

    $.ajax({
        type: "POST",
        url: "Usuarios.aspx/buscarUsuarios",
        data: "{idUsuario: '" + idBuscar + "'}",
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        async: false,
        success: function (data) {
                        
            var datos = JSON.parse(data.d); 

            datos.forEach(function (e) {

                $("#id__txtUsuarioE").val(e.NOMBRE_USUARIO);
                $("#id__txtPasswordE").val(e.CLAVE_USUARIO);
                $("#ddlRolE").val(e.ID_ROL);          
                $("#modalEditar").modal('show');
                
            });
                                             
        },
        error: function (xhr, ajaxOptions, thrownError) {

        }
    })
}

$('#btnActualizar').click(function (e) {

    e.preventDefault();
    rolE = $('#ddlRolE').val();
    UpdateDataUsuarios(id_usuario, rolE);
    $("#modalEditar").modal('hide');
    

});

function UpdateDataUsuarios(id_usuario, rolE) {

    var obj = JSON.stringify({
        id: id_usuario,
        user: $("#id__txtUsuarioE").val(),
        password: $("#id__txtPasswordE").val(),
        rol: rolE      
    })
    
    $.ajax({
        type: "POST",
        url: "Usuarios.aspx/actualizarUsuario",
        data: obj,
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
        
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (response) {

            if (response.d != 'OK') {
                swal("Hubo un problema", "Error al actualizar los datos del Usuario.", "error");
            }
            else {
             
                swal("Hecho", "Los datos del usuario se actualizaron con Éxito.", "success");
                sendDataUsuarios();
            }
          
        }
    })
};

function mostrarPassword(password) {
    var cambio = document.getElementById(password);
    if (cambio.type == "password") {
        cambio.type = "text";
        $('.icon').removeClass('fa fa-eye-slash').addClass('fa fa-eye');
    } else {
        cambio.type = "password";
        $('.icon').removeClass('fa fa-eye').addClass('fa fa-eye-slash');
    }
};

//function inactivar(id, nombre) {

//    var IdUsuario = id;
//    var nomPersonal = nombre;

//    $.ajax({
//        url: "Usuarios.aspx/darBajaUsuario",
//        data: "{IdUsuario: '" + IdUsuario + "'}",
//        type: "post",
//        contentType: "application/json",
//        async: false,
//        success: function (data) {

//            swal("Hecho", "Se dio de baja exitosamente el usuario de " + nomPersonal + ".", "success");

//            sendDataUsuarios();
//        },
//        error: function (xhr, ajaxOptions, thrownError) {
//            alert(data.error);
//        }
//    });
//}