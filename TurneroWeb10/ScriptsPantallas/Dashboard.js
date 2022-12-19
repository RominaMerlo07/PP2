var fechaDesde;
var fechaHasta;
var cantidadTurnosTotales;
var estado;
let myChart;
let myChart0;
let myChart1;
let myChart2;
let myChart3;
let myChart4;
let myChart51;
let myChart6;
let myChart7;
let myChart8;
let myChart9;

const format = "YYYY-MM-DD";
const format2 = "DD-MM-YYYY";

$(document).ready(function () {

/*  Fechas1();*/
    $('#i-calendario').click(function () {
        $("#date_range").focus();
    });

    $('#i-flechita').click(function () {
        $("#date_range").focus();
    });

    $('#i-calendario1').click(function () {
        $("#date_range1").focus();
    });

    $('#i-flechita1').click(function () {
        $("#date_range1").focus();
    });

    $('#date_range').daterangepicker({
        autoUpdateInput: false,
        opens: 'left',
        locale: {
            daysOfWeek: [
                "Do",
                "Lu",
                "Ma",
                "Mi",
                "Ju",
                "Vi",
                "Sa"
            ],
            applyLabel: "Guardar",
            cancelLabel: "Cancelar",
            fromLabel: "Desde",
            toLabel: "Hasta",
            customRangeLabel: "Personalizar",
            monthNames: [
                "Enero",
                "Febrero",
                "Marzo",
                "Abril",
                "Mayo",
                "Junio",
                "Julio",
                "Agosto",
                "Setiembre",
                "Octubre",
                "Noviembre",
                "Diciembre"
            ],
            format: "DD-MM-YYYY"

        }
    }, function (start, end, label) {
        startDate = start.format(format);
        endDate = end.format(format);
        ObtenerCantidadTurnosTotales(startDate, endDate, label)

        cb(start.format(format2), end.format(format2));

    });

    inicializarTurnosTotales();

    $('input[name="daterange1"]').daterangepicker({
        

            autoUpdateInput: false,
        opens: 'left',
        locale: {
            daysOfWeek: [
                "Do",
                "Lu",
                "Ma",
                "Mi",
                "Ju",
                "Vi",
                "Sa"
            ],
            applyLabel: "Guardar",
            cancelLabel: "Cancelar",
            fromLabel: "Desde",
            toLabel: "Hasta",
            customRangeLabel: "Personalizar",
            monthNames: [
                "Enero",
                "Febrero",
                "Marzo",
                "Abril",
                "Mayo",
                "Junio",
                "Julio",
                "Agosto",
                "Setiembre",
                "Octubre",
                "Noviembre",
                "Diciembre"
            ],
            format: "DD-MM-YYYY"

        },
    }, function (start, end, label) {


        startDate = start.format(format);
        endDate = end.format(format);
        GraficarEspMasDemandadas(startDate, endDate);

        cb1(start.format(format2), end.format(format2));

    });

    inicializarEstadisticas();

});

function cb(start, end) {
    $('#date_range').val(start + ' - ' + end);
}

function cb1(start, end) {
    $('#date_range1').val(start + ' - ' + end);
}

function inicializarTurnosTotales() {

    var startDate = moment().subtract('months', 1).format(format);
    var endDate = moment().format(format);
    ObtenerCantidadTurnosTotales(startDate, endDate, "");

    var startDate2 = moment().subtract('months', 1).format(format2);
    var endDate2 = moment().format(format2);
    cb(startDate2, endDate2);
}

function inicializarEstadisticas() {

    var startDate = moment().subtract('months',1).format(format);
    var endDate = moment().format(format);
    GraficarEspMasDemandadas(startDate,endDate);

    var startDate2 = moment().subtract('months',1).format(format2);
    var endDate2 = moment().format(format2);
    cb1(startDate2, endDate2);
}




function ObtenerCantidadTurnosTotales(fecha_desde, fecha_hasta, estado) {

    fechaDesde = fecha_desde;
    fechaHasta = fecha_hasta;

    $.ajax({
        type: "POST",
        url: "Dashboard.aspx/traerCantidadTurnosTotales",
        data: "{p_fecha_desde: '" + fechaDesde + "', p_fecha_hasta: '" + fechaHasta + "'}",
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        async: false,
        success: function (data) {

            console.log(data);

            document.getElementById('total-turnos').innerHTML = data.d[7];
            document.getElementById('turnos-atendidos').innerHTML = data.d[1];
            document.getElementById('turnos-cancelados').innerHTML = data.d[4];

        }
    })

    $.ajax({
        type: "POST",
        url: "Dashboard.aspx/ObtenerTipoObraSocialSparring",
        data: "{p_fecha_desde: '" + fechaDesde + "', p_fecha_hasta: '" + fechaHasta + "'}",
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        async: false,
        success: function (data) {

            console.log(data);



            var obra_social = [];
            var porcentaje = [];
            var cantidad = [];

            obra_social.push(data.d[0]);
            obra_social.push(data.d[3]);


            porcentaje.push(data.d[2]);
            porcentaje.push(data.d[5]);


            cantidad.push(data.d[1]);
            cantidad.push(data.d[4]);



            console.log(obra_social, porcentaje);


            const ctx = document.getElementById('grafico-os-sparring');

                
                

            if (myChart0) {
                myChart0.destroy();
            }

            myChart0 = new Chart(ctx, {
                type: 'bar',
                data: {
                    labels:obra_social,
                    datasets: [{
                        label: '',
                        data: cantidad,
                        borderWidth: 1,
                        backgroundColor: ["#81638b", "#dac9df"]
                    }
                    ]
                },
                options: {
                    plugins: {
                        legend: {
                            display: false
                        }
                    },
                    scales: {
                        y: {
                            beginAtZero: true
                        },
                        responsive: false,
                        maintainAspectRatio: true,
                        showScale: false,
                    }
                }
            });

        }

    })



    $.ajax({
        type: "POST",
        url: "Dashboard.aspx/ObtenerCantTurnosPorSucursal",
        data: "{p_fecha_desde: '" + fechaDesde + "', p_fecha_hasta: '" + fechaHasta + "'}",
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        async: false,
        success: function (data) {

            console.log(data);

                
            const ctx = document.getElementById('turnos-por-centros');
            var nombre_centro = [];
            var estado_turno = [];
            var cantidad_atendidos = [];
            var cantidad_cancelados = [];
            var porcentaje_atendidos = [];
            var porcentaje_cancelados = [];

            if (data.d !== null) {



                nombre_centro.push(data.d[0]);
                nombre_centro.push(data.d[12]);
                nombre_centro.push(data.d[24]);

                estado_turno.push(data.d[0])

                cantidad_atendidos.push(data.d[2]);
                cantidad_atendidos.push(data.d[14]);
                cantidad_atendidos.push(data.d[26]);

                cantidad_cancelados.push(data.d[6]);
                cantidad_cancelados.push(data.d[18]);
                cantidad_cancelados.push(data.d[30]);

               

                

                if(data.d[2])
                document.getElementById('atendidos-cp1').innerHTML = data.d[2];
                document.getElementById('atendidos-cp2').innerHTML = data.d[14];
                document.getElementById('atendidos-c').innerHTML = data.d[26];

                document.getElementById('cancelados-cp1').innerHTML = data.d[7] + ' %';
                document.getElementById('cancelados-cp2').innerHTML = data.d[19] + " %";
                document.getElementById('cancelados-c').innerHTML = data.d[31] + " %";

                console.log(nombre_centro);


                    




                if (myChart1) {
                    myChart1.destroy();
                }


                myChart1 = new Chart(ctx, {
                    type: 'bar',
                    data: {
                        labels: nombre_centro,
                        datasets: [
                            {
                                label: 'ATENDIDOS',
                                data: cantidad_atendidos,
                                borderWidth: 1,
                                backgroundColor: '#42ab49',
                            },
                            {
                                label: 'CANCELADOS',
                                data: cantidad_cancelados,
                                borderWidth: 1,
                                backgroundColor: '#F06057',
                            }
                        ]
                    },
                    options: {
                        scales: {
                            y: {
                                beginAtZero: true
                            },
                            responsive: false,
                            maintainAspectRatio: true,
                            showScale: false,
                        },

                        //plugins: {
                        //    //title: {
                        //    //    display: true,
                        //    //    text: 'Cantidad de turnos atentidos y cancelados por sucursal',
                        //    //    font: {
                        //    //        family: "'Arial', sans-serif",
                        //    //        size: 30
                        //    ////},
                        //    //    padding: {
                        //    //        bottom: 30
                        //    //    }
                        //    //}
                        //}


                    }
                });
            } else {


                if (myChart1) {
                    myChart1.destroy();
                }


                myChart1 = new Chart(ctx, {
                    type: 'bar',
                    data: {
                        labels: '',
                        datasets: [
                            {
                                label: 'ATENDIDOS',
                                data: 0,
                                borderWidth: 1,
                                backgroundColor: '#42ab49',
                            },
                            {
                                label: 'CANCELADOS',
                                data: 0,
                                borderWidth: 1,
                                backgroundColor: '#F06057',
                            }
                        ]
                    },
                    options: {
                        scales: {
                            y: {
                                beginAtZero: true
                            },
                            responsive: false,
                            maintainAspectRatio: true,
                            showScale: false,
                        }
                    }
                });

            }

                

                

        }

    })
};

function GraficarEspMasDemandadas(fecha_desde, fecha_hasta) {

    //$('input[name="daterange1"]').daterangepicker({
    //    locale: {

    //        autoUpdateInput: false,
    //        opens: 'left',
    //        startDate: "01/01/2021",
    //        endDate: "03/08/2022",
    //        daysOfWeek: [
    //            "Do",
    //            "Lu",
    //            "Ma",
    //            "Mi",
    //            "Ju",
    //            "Vi",
    //            "Sa"
    //        ],
    //        applyLabel: "Guardar",
    //        cancelLabel: "Cancelar",
    //        fromLabel: "Desde",
    //        toLabel: "Hasta",
    //        customRangeLabel: "Personalizar",
    //        monthNames: [
    //            "Enero",
    //            "Febrero",
    //            "Marzo",
    //            "Abril",
    //            "Mayo",
    //            "Junio",
    //            "Julio",
    //            "Agosto",
    //            "Setiembre",
    //            "Octubre",
    //            "Noviembre",
    //            "Diciembre"
    //        ],
    //        format: "DD-MM-YYYY"

    //    },
    //}, function (start, end, label) {

        fechaDesde = fecha_desde;
        fechaHasta = fecha_hasta;

        //arrayFechas = new Array();

        //arrayFechas.push(start.format('YYYY-MM-DD'), end.format('YYYY-MM-DD'));
        //console.log(arrayFechas);
        //fechaDesde = arrayFechas[0];
        //fechaHasta = arrayFechas[1];

        //console.log(fechaHasta, fechaDesde);


        $.ajax({
            type: "POST",
            url: "Dashboard.aspx/traerEspecialidadesMasDemandadas",
            data: "{p_fecha_desde: '" + fechaDesde + "', p_fecha_hasta: '" + fechaHasta + "'}",
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            async: false,
            success: function (data) {

                console.log(data);



                var especialidad = [];
                var porcentaje = [];
                var cantidad = [];


                especialidad.push(data.d[0]);
                especialidad.push(data.d[3]);
                especialidad.push(data.d[6]);
                especialidad.push(data.d[9]);
                especialidad.push(data.d[12]);



                porcentaje.push(data.d[2]);
                porcentaje.push(data.d[5]);
                porcentaje.push(data.d[8]);
                porcentaje.push(data.d[11]);
                porcentaje.push(data.d[14]);


                cantidad.push(data.d[1]);
                cantidad.push(data.d[4]);
                cantidad.push(data.d[7]);
                cantidad.push(data.d[10]);
                cantidad.push(data.d[13]);



                console.log(especialidad, porcentaje);

                const ctx = document.getElementById('grafico-especialidades');

                


                if (myChart2) {
                    myChart2.destroy();
                }

                myChart2 = new Chart(ctx, {
                    type: 'bar',
                    data: {
                        labels: especialidad,
                        datasets: [{
                            label: 'Especialidades más demandadas',
                            backgroundColor: ['#8f7193', '#a788ab', '#c0a0c3', '#dfcae1','#e5dde6'],
                            data: cantidad,
                            borderWidth: 1
                        }]
                    },
                    options: {
                        plugins: {
                            legend: {
                                display: false
                            }
                        },
                        scales: {
                            y: {
                                beginAtZero: true
                            },
                            responsive: false,
                            maintainAspectRatio: true,
                            showScale: false,
                        }
                    }
                });

            }
        })

        $.ajax({
            type: "POST",
            url: "Dashboard.aspx/traerEspecialidadesMenosDemandadas",
            data: "{p_fecha_desde: '" + fechaDesde + "', p_fecha_hasta: '" + fechaHasta + "'}",
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            async: false,
            success: function (data) {

                console.log(data);



                var especialidadm = [];
                var porcentajem = [];
                var cantidadm = [];


                especialidadm.push(data.d[0]);
                especialidadm.push(data.d[3]);
                especialidadm.push(data.d[6]);
                especialidadm.push(data.d[9]);
                especialidadm.push(data.d[12]);



                porcentajem.push(data.d[2]);
                porcentajem.push(data.d[5]);
                porcentajem.push(data.d[8]);
                porcentajem.push(data.d[11]);
                porcentajem.push(data.d[14]);


                cantidadm.push(data.d[1]);
                cantidadm.push(data.d[4]);
                cantidadm.push(data.d[7]);
                cantidadm.push(data.d[10]);
                cantidadm.push(data.d[13]);



                console.log(especialidadm, porcentajem);

                const ctx = document.getElementById('grafico-especialidades-menos');

                if (myChart3) {
                    myChart3.destroy();
                }

                myChart3 = new Chart(ctx, {
                    type: 'bar',
                    data: {
                        labels: especialidadm,
                        datasets: [{
                            label: 'Especialidades menos demandadas',
                            data: cantidadm,
                            borderWidth: 1,
                            backgroundColor: ['#b5ffff', '#8ae0db', '#5dc1b9', '#42a8a1', '#239089'],
                            
                        }]
                    },
                    options: {
                        plugins: {
                            legend: {
                                display: false
                            }
                        },
                        scales: {
                            y: {
                                beginAtZero: true
                            },
                            responsive: false,
                            maintainAspectRatio: true,
                            showScale: false,
                        }
                    }
                });

            }
        })

        $.ajax({
            type: "POST",
            url: "Dashboard.aspx/obtenerEspecialidadesMasDemandadasPorSucursal",
            data: "{p_fecha_desde: '" + fechaDesde + "', p_fecha_hasta: '" + fechaHasta + "'}",
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            async: false,
            success: function (data) {

                console.log(data);

                var nombre_centro = [];

                var especialidad_cp1 = [];
                var especialidad_cp2 = [];
                var especialidad_c = [];
                var porcentaje_cp1 = [];
                var porcentaje_cp2 = [];
                var porcentaje_c = [];
                var cantidadmS = [];


                nombre_centro.push(data.d[0]);
                nombre_centro.push(data.d[20]);
                nombre_centro.push(data.d[28]);

                especialidad_cp1.push(data.d[1]);
                especialidad_cp1.push(data.d[5]);
                especialidad_cp1.push(data.d[9]);
                especialidad_cp1.push("OTRAS");


                especialidad_cp2.push(data.d[13]);
                especialidad_cp2.push(data.d[17]);
                especialidad_cp2.push(data.d[21]);
                especialidad_cp2.push("OTRAS");

                especialidad_c.push(data.d[25]);
                especialidad_c.push(data.d[29]);
                especialidad_c.push(data.d[33]);
                especialidad_c.push("OTRAS");
                console.log(especialidad_cp1, especialidad_cp2, especialidad_c);




                porcentaje_cp1.push(data.d[3]);
                porcentaje_cp1.push(data.d[7]);
                porcentaje_cp1.push(data.d[11]);

                let total = porcentaje_cp1.reduce((a, b) => a + b, 0);
                console.log(total);

                let resto_cp1 = 100 - total;
                porcentaje_cp1.push(resto_cp1);

                console.log(porcentaje_cp1);


                porcentaje_cp2.push(data.d[15]);
                porcentaje_cp2.push(data.d[19]);
                porcentaje_cp2.push(data.d[23]);

                let total_cp2 = porcentaje_cp2.reduce((d, e) => d + e, 0);
                console.log(total_cp2);

                let resto_cp2 = 100 - total_cp2;
                porcentaje_cp2.push(resto_cp2);

                console.log("cp2" + porcentaje_cp2);

                porcentaje_c.push(data.d[27]);
                porcentaje_c.push(data.d[31]);
                porcentaje_c.push(data.d[35]);

                let total_c = porcentaje_c.reduce((f, g) => f + g, 0);
                console.log(total_c);

                let resto_c = 100 - total_c;
                porcentaje_c.push(resto_c);

                console.log("c: " + porcentaje_c);


                /*console.log(especialidadmS, porcentajemS);*/

                const ctx = document.getElementById('grafico-especialidades-mas-cp1');

                if (myChart4) {
                    myChart4.destroy();
                }

                myChart4 = new Chart(ctx, {
                    type: 'doughnut',
                    data: {
                        labels: especialidad_cp1,
                        datasets: [
                            {
                                label: 'Carlos Paz I',
                                data: porcentaje_cp1,
                                borderWidth: 1,
                               
                            }
                        ]
                    },
                    options: {

                        scales: {
                            y: {
                                beginAtZero: true
                            },
                            responsive: false,
                            maintainAspectRatio: true,
                            showScale: false,
                        }
                    }
                });


                const ctx11 = document.getElementById('grafico-espec-mas-cp2');

                
                if (myChart51) {
                    myChart51.destroy();

                }


                myChart51 = new Chart(ctx11, {
                    type: 'doughnut',
                    data: {
                        labels: especialidad_cp2,
                        datasets: [
                            {
                                label: 'Carlos Paz II',
                                data: porcentaje_cp2,
                                borderWidth: 1
                            }
                        ]
                    },
                    options: {
                        scales: {
                            y: {
                                beginAtZero: true
                            },
                            responsive: false,
                            maintainAspectRatio: true,
                            showScale: false,
                        },
                        
                    }
                });

                const ctx6 = document.getElementById('grafico-espec-mas-cba');


                if (myChart6) {
                    myChart6.destroy();

                }


                myChart6 = new Chart(ctx6, {
                    type: 'doughnut',
                    data: {
                        labels: especialidad_c,
                        datasets: [
                            {
                                label: 'Córdoba',
                                data: porcentaje_c,
                                borderWidth: 1
                            }
                        ]
                    },
                    options: {
                        scales: {
                            y: {
                                beginAtZero: true
                            },
                            responsive: false,
                            maintainAspectRatio: true,
                            showScale: false,
                        },

                    }
                });


            }
        })


        $.ajax({
            type: "POST",
            url: "Dashboard.aspx/obtenerEspecialidadesMenosDemandadasPorSucursal",
            data: "{p_fecha_desde: '" + fechaDesde + "', p_fecha_hasta: '" + fechaHasta + "'}",
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            async: false,
            success: function (data) {

                console.log(data);

                var nombre_centro = [];

                var especialidad_cp1 = [];
                var especialidad_cp2 = [];
                var especialidad_c = [];
                var porcentaje_cp1 = [];
                var porcentaje_cp2 = [];
                var porcentaje_c = [];
                var cantidadmS = [];


                nombre_centro.push(data.d[0]);
                nombre_centro.push(data.d[20]);
                nombre_centro.push(data.d[28]);

                especialidad_cp1.push(data.d[1]);
                especialidad_cp1.push(data.d[5]);
                especialidad_cp1.push(data.d[9]);
                especialidad_cp1.push("OTRAS");


                especialidad_cp2.push(data.d[13]);
                especialidad_cp2.push(data.d[17]);
                especialidad_cp2.push(data.d[21]);
                especialidad_cp2.push("OTRAS");

                especialidad_c.push(data.d[25]);
                especialidad_c.push(data.d[29]);
                especialidad_c.push(data.d[33]);
                especialidad_c.push("OTRAS");
                console.log(especialidad_cp1, especialidad_cp2, especialidad_c);




                porcentaje_cp1.push(data.d[3]);
                porcentaje_cp1.push(data.d[7]);
                porcentaje_cp1.push(data.d[11]);

                let total = porcentaje_cp1.reduce((a, b) => a + b, 0);
                console.log(total);

                let resto_cp1 = 100 - total;
                porcentaje_cp1.push(resto_cp1);

                console.log(porcentaje_cp1);


                porcentaje_cp2.push(data.d[15]);
                porcentaje_cp2.push(data.d[19]);
                porcentaje_cp2.push(data.d[23]);

                let total_cp2 = porcentaje_cp2.reduce((d, e) => d + e, 0);
                console.log(total_cp2);

                let resto_cp2 = 100 - total_cp2;
                porcentaje_cp2.push(resto_cp2);

                console.log("cp2" + porcentaje_cp2);

                porcentaje_c.push(data.d[27]);
                porcentaje_c.push(data.d[31]);
                porcentaje_c.push(data.d[35]);

                let total_c = porcentaje_c.reduce((f, g) => f + g, 0);
                console.log(total_c);

                let resto_c = 100 - total_c;
                porcentaje_c.push(resto_c);

                console.log("c: " + porcentaje_c);


                /*console.log(especialidadmS, porcentajemS);*/

                const ctx = document.getElementById('grafico-especialidades-menos-cp1');

                if (myChart7) {
                    myChart7.destroy();
                }

                myChart7 = new Chart(ctx, {
                    type: 'doughnut',
                    data: {
                        labels: especialidad_cp1,
                        datasets: [
                            {
                                label: 'Carlos Paz I',
                                data: porcentaje_cp1,
                                borderWidth: 1
                            }
                        ]
                    },
                    options: {
                        scales: {
                            y: {
                                beginAtZero: true
                            },
                            responsive: false,
                            maintainAspectRatio: true,
                            showScale: false,
                        }
                    }
                });


                const ctx1 = document.getElementById('grafico-especialidades-menos-cp2');

                if (myChart8) {
                    myChart8.destroy();
                }

                myChart8 = new Chart(ctx1, {
                    type: 'doughnut',
                    data: {
                        labels: especialidad_cp2,
                        datasets: [
                            {
                                label: 'Carlos Paz II',
                                data: porcentaje_cp2,
                                borderWidth: 1
                            }
                        ]
                    },
                    options: {
                        scales: {
                            y: {
                                beginAtZero: true
                            },
                            responsive: false,
                            maintainAspectRatio: true,
                            showScale: false,
                        }
                    }
                });



                const ctx3 = document.getElementById('grafico-especialidades-menos-c');

                if (myChart9) {
                    myChart9.destroy();
                }

                myChart9 = new Chart(ctx3, {
                    type: 'doughnut',
                    data: {
                        labels: especialidad_c,
                        datasets: [
                            {
                                label: 'Córdoba',
                                data: porcentaje_c,
                                borderWidth: 1
                            }
                        ]
                    },
                    options: {
                        scales: {
                            y: {
                                beginAtZero: true
                            },
                            responsive: false,
                            maintainAspectRatio: true,
                            showScale: false,
                        }
                    }
                });







            }
        })







};

    




function Fechas1() {

    $('input[name="daterange"]').daterangepicker({
        opens: 'left',
        startDate: "01/01/2021",
        endDate: "01/01/2022",
    }, function (startDate, endDate, label) {


            startDate = $('input[name="daterange"]').datepicker('setDate', now.format('DD/MM/YYYY'));
            endDate = $('input[name="daterange"]').datepicker('setDate', now.format('DD/MM/YYYY'));
            // $('input[name="daterange"]').daterangepicker.startDate;
            //endDate = $('input[name="daterange"]').daterangepicker.endDate;

        arrayFechas = new Array();

        arrayFechas.push(start.format('YYYY-MM-DD'), end.format('YYYY-MM-DD'));
        console.log(arrayFechas);
        fechaDesde = arrayFechas[0];
        fechaHasta = arrayFechas[1];
        ObtenerCantidadTurnosTotales(fechaDesde, fechaHasta, estado);

        /*console.log(fechaHasta, fechaDesde);*/

        return arrayFechas;
    }
    )

}









