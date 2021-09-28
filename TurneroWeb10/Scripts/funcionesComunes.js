function mostrarFecha(data) {

    if (data != null) {
        var str = data.replace('/Date(', '');
        var str2 = str.replace(')/', '');
        var fecha = new Date(parseInt(str2));
        var fechaFormat = getFormattedDate(fecha);
    }
    else {
        var fechaFormat = '';
    }
    return fechaFormat;
}

var getFormattedDate = function (date) {

    var year = date.getFullYear();
    var month = (1 + date.getMonth()).toString();
    month = month.length > 1 ? month : '0' + month;
    var day = date.getDate().toString();
    day = day.length > 1 ? day : '0' + day;
    return day + '/' + month + '/' + year;
}

var getFormattedDateInversed = function (date) {

    var year = date.getFullYear();
    var month = (1 + date.getMonth()).toString();
    month = month.length > 1 ? month : '0' + month;
    var day = date.getDate().toString();
    day = day.length > 1 ? day : '0' + day;
    return year + '-' + month + '-' + day;
}

var soloNumeros = function (e) {
    var keynum = window.event ? window.event.keyCode : e.which;
    if ((keynum == 8) || (keynum == 46))
        return true;
    if (keynum == 110)
        return false;

    return /\d/.test(String.fromCharCode(keynum));
}

var soloLetras = function (e) {

    key = e.keyCode || e.which;
    teclado = String.fromCharCode(key);
    numeros = "abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
    especiales = "8-37-38-46-164";
    teclado_especial = false;

    for (var i in especiales) {
        if (key == especiales[i]) {
            teclado_especial = true; break;
        }
    }

    if (numeros.indexOf(teclado) == -1 && !teclado_especial) {
        return false;
    }
}