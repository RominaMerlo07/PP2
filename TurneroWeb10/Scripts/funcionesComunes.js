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