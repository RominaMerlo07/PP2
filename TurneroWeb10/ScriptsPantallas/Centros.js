
var centro, calle, numero, barrio, localidad, telefono, email1, email2, table, data, id, nombreCentro, IdCentro;


$(document).ready(function () {

    sendDataCentros();

    $('#btnRegistrar').click(function () {

        centro = $('#id__txtNombre').val();
        calle = $('#id__txtCalle').val();
        numero = $('#id__txtNumero').val();
        barrio = $('#id__txtBarrio').val();
        localidad = $('#id__txtLocalidad').val();
        telefono = $('#id__txtTelefono').val();
        celular = $('#id__txtCelular').val();
        email1 = $('#id__txtEmail1').val();
        email2 = $('#id__txtEmail2').val();

       
        var validacion = validarDatosCentro();

        if (validacion === true) {

            var sucursal = {

                p_nombre: centro,
                p_domicilio: calle,
                p_numero: numero,
                p_barrio: barrio,
                p_localidad: localidad,
                p_email1: email1,
                p_email2: email2,
                p_celular: celular,
                p_telefono: telefono

            }

            console.log(sucursal);
            registrarCentros(sucursal);


        }
        else {
            console.log("Error en validación de datos del centro");
        }

    });
});

$('#btnRegistrarModal').click(function () {
    $("#modalRegistrar").modal('show');
    deshabilitarCampos(true);
    limpiarCampos();
});



function actualizarCentro(IdCentro) {
         

        id = IdCentro;

        $.ajax({
            type: "POST",
            url: "RegistrarCentros.aspx/obtenerCentro",
            data: "{idCentro: '" + IdCentro + "'}",
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            async: false,
            success: function (data) {
                                

                $("#modalEditar").modal('show');

                $("#id__AtxtNombre").val(data.d.NombreCentro);
                var direccion = data.d.DomicilioCentro.split('Barrio:');
                $("#id__AtxtDomicilio").val(direccion[0]);
                $("#id__AtxtBarrio").val(direccion[1]);           
                $("#id__AtxtLocalidad").val(data.d.LocalidadCentro);
                var email = data.d.EmailCentro.split('@');
                $("#id__AtxtEmail1").val(email[0]);
                $("#id__AtxtEmail2").val(email[1]);
                $("#id__AtxtTelefono").val(data.d.NroCentro1);
                $("#id__AtxtCelular").val(data.d.NroCentro2);

            },
            error: function (xhr, ajaxOptions, thrownError) {

            }
        })
    };



$("#btnActualizar").click(function (e) {
        e.preventDefault();
        UpdateDataCentros(id);        
    });


function registrarCentros(datosCentro) {
        $.ajax({
            url: "RegistrarCentros.aspx/registrarCentros",
            data: JSON.stringify(datosCentro),
            type: "post",
            contentType: "application/json",
            async: false,
            success: function (data) {

                if (data.d != 'OK') {
                    swal("Hubo un problema", "Error al registrar el centro", "error"); //error
                } else {
                    $("#modalRegistrar").modal('hide');
                    swal("Hecho", "Centro de Atención registrado con Éxito!", "success"); //error
                    //$("#tabla_profesionales").DataTable().fnClearTable();
                    sendDataCentros();

                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(data.error);
            }

        });

};

function validarDatosCentro() {

        if (centro == "") {
            alert("Por favor, ingrese el nombre del centro");
            return false;
        }
        else if (calle == "") {
            alert("Por favor, ingrese Domicilio");
            return false;
        }
        else if (localidad == null) {
            alert("Por favor, ingrese localidad del centro");
            return false;
        }
        else if (email1 == null) {
            alert("Por favor, ingrese correctamente la dirección del Email");
            return false;
        }
        else if (email2 == "") {
            alert("Por favor, ingrese correctamente la dirección del Email");
            return false;
        }
        else if (celular == "") {
            alert("Por favor, un numero de contacto");
            return false;
        }
        else {
            return true;
        };
};

function sendDataCentros() {
        $.ajax(
            {
                type: "POST",
                url: "RegistrarCentros.aspx/traerCentros",
                data: {},
                contentType: 'application/json; charset=utf-8',
                async: false,
                success: function (data) {

                    var arrayCentros = new Array();

                    for (var i = 0; i < data.d.length; i++) {

                        var Numero = data.d[i].IdCentro;
                        var Nombre = data.d[i].NombreCentro;
                        var Domicilio = data.d[i].DomicilioCentro + ", " + data.d[i].LocalidadCentro;
                        var Email = data.d[i].EmailCentro;
                        var NroCentro1 = data.d[i].NroCentro1;
                        var NroCentro2 = data.d[i].NroCentro2;

                        var jsonStr = '["' + Nombre + '", "' + Numero + '", "' + Domicilio + '", "' + Email + '", "' + NroCentro1 + '","' + NroCentro2 + '"]';
                        var Acciones = '<a href="#" onclick="return actualizarCentro(' + Numero + ')"  class="btn btn-primary btn-editar"> <span class="fa fa-pencil" title="Modificar"></span></a >' +
                            '<a href="#" onclick = "return inactivar(' + Numero + ", '" + Nombre + "'" + ')"  class="btn btn-danger btn-inactivar" > <span class="fa fa-trash" title="Dar de baja"></span></a >';
                                                
                        arrayCentros.push([
                            Numero, Nombre, Domicilio, Email, NroCentro1, NroCentro2, Acciones
                        ])
                    }

                    var table = $('#tabla_Centros').DataTable({
                        data: arrayCentros,
                        "scrollX": true,
                        "languaje": {
                            "url": "//cdn.datatables.net/plug-ins/1.10.12/i18n/Spanish.json"
                        },
                        "ordering": true,
                        "bDestroy": true,
                        "bAutoWidth": true,
                        columns: [
                            { title: "Numero", visible: false },
                            { title: "Centro" },
                            { title: "Domicilio" },                   
                            { title: "Email" },
                            { title: "Telefono" },
                            { title: "Celular" },
                            { title: "Acciones" },
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
                    console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
                }
            })
}


function inactivar(id, nombre) {

    IdCentro = id;
    nombreCentro = nombre;


     $.ajax({
         url: "RegistrarCentros.aspx/ObtenerTurnosFuturos",
        data: "{p_id: '" + IdCentro + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
         success: function (data) {

             if (data.d === 'sin info') {
                 console.log('puedo eliminar directo');

                 swal({
                     title: "¿Estas seguro que deseas eliminar el centro " + nombreCentro + "?",
                     text: "Una vez eliminado, ¡no podrá recuperar los datos asociados al mismo!",
                     icon: "warning",
                     buttons: true,
                     buttons: ["Cancelar", "Eliminar"],
                     dangerMode: true,
                 })
                     .then((willDelete) => {
                         if (willDelete) {
                             darBajaCentro(IdCentro, nombreCentro);                             
                         }
                     });
             }
             else {
                 console.log("tengo que mostrar los turnos pendientes");
                 ObtenerTurnosFuturos(IdCentro);   
                 $("#modalTurnos").modal('show');                    
             }            
        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        }
    });
   
}


function UpdateDataCentros(id) {

    var obj = JSON.stringify({
        p_id: id,
        p_centro: $('#id__AtxtNombre').val(),
        p_domicilio: $('#id__AtxtDomicilio').val(),
        p_barrio: $('#id__AtxtBarrio').val(),
        p_localidad: $('#id__AtxtLocalidad').val(),
        p_telefono: $('#id__AtxtTelefono').val(),
        p_celular: $('#id__AtxtCelular').val(),
        p_email1: $('#id__AtxtEmail1').val(),
        p_email2: $('#id__AtxtEmail2').val()

    });

    console.log(obj);

   
    $.ajax({
        type: "POST",
        url: "RegistrarCentros.aspx/actualizarCentros",
        data: obj,
        dataType: "json",
        contentType: 'application/json; charset=utf-8',     
        success: function (response) {

            console.log(response);

                if (response.d != 'OK') {
                    swal("Hubo un problema", "Error al actualizar datos del centro.", "error");
                }
                else {
                    swal("Hecho", "Los datos del centro se actualizaron con Éxito.", "success");
                    $("#modalEditar").modal('hide');
                    sendDataCentros();

                }          
        },
        error: function (xhr, ajaxOptions, thrownError) {

            console.log(thrownError);
        }
    })
          
}


function ObtenerTurnosFuturos(idCentro)
{
   
    var turnos;
    $.ajax({
        type: "POST",
        url: "RegistrarCentros.aspx/MostrarTurnosFuturos",
        data: "{p_id: '" + idCentro + "'}",
        contentType: 'application/json; charset=utf-8',
        async: false,
        success: function (data) {

            turnos = JSON.parse(data.d);

            var arrayTurnos = new Array();

            turnos.forEach(function (e) {

                var turno = e.TURNO;
                var hora = e.HORA;
                var paciente = e.PACIENTE;
                var contacto = e.NRO_CONTACTO;
                var email = e.EMAIL_CONTACTO;
                             
                arrayTurnos.push([turno, hora, paciente, contacto, email]);

                console.log(arrayTurnos);
            
            });
          
            var table = $('#tabla_Turnos').DataTable({
                data: arrayTurnos,
                "scrollX": true,
                "languaje": {
                    "url": "//cdn.datatables.net/plug-ins/1.10.12/i18n/Spanish.json"
                },
                "ordering": true,
                "bDestroy": true,
                "bAutoWidth": true,
                columns: [
                    { title: "Turno" },
                    { title: "Hora" },
                    { title: "Paciente" },
                    { title: "Contacto" },
                    { title: "Email" },                
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
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        }
    })
};

$("#btnCancelar").click(function (e) {
    e.preventDefault();
    $("#modalTurnos").modal('hide');
});


$("#btnEliminar").click(function (e) {
    e.preventDefault();
    DaDarDeBajaTurnos(IdCentro, nombreCentro);
});


function DaDarDeBajaTurnos(IdCentro, nombreCentro) {

    $.ajax({
        url: "RegistrarCentros.aspx/DaDarDeBajaTurnos",
        data: "{p_id: '" + IdCentro + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {

            console.log(data.d);

            if (data.d != 'OK') {
                swal("Hubo un problema", "Error al eliminar el centro.", "error");
            }
            else {
                swal("Hecho", "El centro " + nombreCentro + " se elimino con Éxito, y los turnos fueron cancelados.", "success");
                $("#modalTurnos").modal('hide');
                sendDataCentros();
            }          
        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(thrownError);
        }
    });

}


function darBajaCentro(IdCentro, nombreCentro) {

    console.log(IdCentro, nombreCentro);

    $.ajax({
        url: "RegistrarCentros.aspx/darBajaCentro",
        data: "{p_id: '" + IdCentro + "'}",
        type: "post",
        contentType: "application/json",
        async: false,
        success: function (data) {
            
            if (data.d == "OK") {
                swal("El centro " + nombreCentro + " fue eliminado con Éxito!.", {
                    icon: "success",
                });
                sendDataCentros();
            }
            else {
                swal("Hubo un problema", "Error al eliminar el centro.", "error");
            }

        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(data.error);
            return false;      

        }
    });
}


function deshabilitarCampos(valor) {

    // document.getElementById("id__txtDocumento").focus(); 
  
    document.getElementById("id__txtCalle").readOnly = valor;
    document.getElementById("id__txtNumero").readOnly = valor;
    document.getElementById("id__txtBarrio").readOnly = valor;
    document.getElementById("id__txtLocalidad").readOnly = valor;
    document.getElementById("id__txtCelular").readOnly = valor;
    document.getElementById("id__txtEmail1").readOnly = valor;
    document.getElementById("id__txtEmail2").readOnly = valor;

}

function soloNumeros(event) {
    var regex = new RegExp("^[0-9]+$");
    var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
    if (!regex.test(key)) {
        event.preventDefault();
        return false;
    }
};


function soloLetras(event) {
    var regex = new RegExp("^[a-zA-Z ]+$");
    var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
    if (!regex.test(key)) {
        event.preventDefault();
        return false;
    }
};


function limpiarCampos() {
    $('#id__txtNombre').val("");
    $('#id__txtCalle').val("");
    $('#id__txtNumero').val("");
    $('#id__txtBarrio').val("");
    $('#id__txtLocalidad').val("");
    $('#id__txtCelular').val("");
    $('#id__txtTelefono').val("");
    $('#id__txtEmail1').val("");
    $('#id__txtEmail2').val("");
}