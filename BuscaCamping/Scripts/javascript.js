
       $(function () {
           // This will make every element with the class "date-picker" into a DatePicker element
           $('.date-picker').datepicker({ dateFormat: 'dd-mm-yy', yearRange: '1910:+nn ', changeMonth: true, changeYear: true, minDate: new Date(1910, 1, 1), maxDate: new Date() });


       })

function ServicioPorCamping(idCamping,idServicio, descripcion, precio) {

    this.idCamping = idCamping;
    this.idServicio = idServicio;
    this.descripcion = descripcion;
    this.precio = precio;
}

var servicios = [];

function cargarServicios() {

    var idCamping = parseInt(document.getElementById("camping_IdCamping").value);
    var idServicio = parseInt(document.getElementById("camping_IdServicio").value);
    var descripcion = document.getElementById("camping_IdServicio").options[document.getElementById("camping_IdServicio").selectedIndex].text;
    var precio = parseFloat(document.getElementById("camping_Precio").value);

    if (document.getElementById("camping_IdServicio").value == "") {
        alert('Debe elegir un servicio');
        return;
    } else if (document.getElementById("camping_Precio").value == "") {
        alert('Ingrese Precio');
        return;
    }

         
    var serv = new ServicioPorCamping(idCamping,idServicio, descripcion, precio);

    for (var i = 0; i < servicios.length; i++) {
        if (servicios[i].idServicio==serv.idServicio) {
            alert('El servicio ya fue agregado en la lista');
            return;
        }
    }


    servicios.push(serv);
    agregarServicio(serv);



}


function agregarServicio(servicio) {

    var tabla = document.getElementById("lstRegistro");
    var htmlTabla;

    for (var i = 0; i < servicios.length; i++) {
        var htmlTabla = "<tr><td>" + servicios[i].idServicio + "</td><td>" + servicios[i].descripcion + "</td><td>" + servicios[i].precio + "</td></tr>";
    }

    tabla.innerHTML += htmlTabla;


    document.getElementById("camping_IdServicio").value = "";
    document.getElementById("camping_Precio").value = "";

}

$(document).ready(function () {
    $("#btnAgregar").click(function () {

        //var postData = { values: servicios };
        postData = JSON.stringify({ 'values': servicios });

        $.ajax({
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            type: 'POST',
            url: '/Servicios/SaveServPorCamp',
            data: postData,
            success: function () {
                //$('#result').html('"PassThings()" successfully called.');
                document.forms[0].submit();
                window.location = '@Url.Action("IndexCamping","Camping")';// Mandar a Lista de Servicios como paso el id?
            },
            failure: function (response) {
                //$('#result').html(response);
            }
        });
    });

});






$(document).ready(function () {
    //Dropdownlist Selectedchange event

    $("#cliente_IdProvincia").change(function () {
        $("#cliente_IdDepartamento").empty();
        $("#cliente_IdLocalidad").empty();
        $("#cliente_IdDepartamento").append('<option value="">Por favor seleccione una opción</option>');
        $("#cliente_IdLocalidad").append('<option value="">Por favor seleccione una opción</option>');
        $.ajax({
            type: 'POST',
            url: '@Url.Action("ListarDepartamentos")', // we are calling json method

            dataType: 'json',

            data: { id: $("#cliente_IdProvincia").val() },
            // here we are get value of selected country and passing same value
            //as inputto json method GetStates.

            success: function (states) {
                // states contains the JSON formatted list
                // of states passed from the controller

                $.each(states, function (i, state) {
                    $("#cliente_IdDepartamento").append('<option value="' + state.Value + '">' +
                         state.Text + '</option>');
                    // here we are adding option for States

                });
            },
            error: function (ex) {
                //alert('Error al cargar departamentos.' + ex);
            }
        });
        return false;
    })
});

$(document).ready(function () {
    //Dropdownlist Selectedchange event
    $("#cliente_IdDepartamento").change(function () {
        $("#cliente_IdLocalidad").empty();
        $("#cliente_IdLocalidad").append('<option value="">Por favor Seleccione una opción</option>');
        $.ajax({
            type: 'POST',
            url: '@Url.Action("ListarLocalidades")',
            dataType: 'json',
            data: { id: $("#cliente_IdDepartamento").val() },
            success: function (citys) {
                // states contains the JSON formatted list
                // of states passed from the controller
                $.each(citys, function (i, city) {
                    $("#cliente_IdLocalidad").append('<option value="'
+ city.Value + '">'
+ city.Text + '</option>');
                });
            },
            error: function (ex) {
                //alert('Error al cargar ciudades.' + ex);
            }
        });
        return false;
    })
});

//Funciones para listar localidades, etc para camping

$(document).ready(function () {
    //Dropdownlist Selectedchange event

    $("#camping_IdProvincia").change(function () {
        $("#camping_IdDepartamento").empty();
        $("#camping_IdLocalidad").empty();
        $("#camping_IdDepartamento").append('<option value="">Por favor seleccione una opción</option>');
        $("#camping_IdLocalidad").append('<option value="">Por favor seleccione una opción</option>');
        $.ajax({
            type: 'POST',
            url: '@Url.Action("ListarDepartamentos")', // we are calling json method

            dataType: 'json',

            data: { id: $("#camping_IdProvincia").val() },
            // here we are get value of selected country and passing same value
            //as inputto json method GetStates.

            success: function (states) {
                // states contains the JSON formatted list
                // of states passed from the controller

                $.each(states, function (i, state) {
                    $("#camping_IdDepartamento").append('<option value="' + state.Value + '">' +
                         state.Text + '</option>');
                    // here we are adding option for States

                });
            },
            error: function (ex) {
                //alert('Error al cargar departamentos.' + ex);
            }
        });
        return false;
    })
});

$(document).ready(function () {
    //Dropdownlist Selectedchange event
    $("#camping_IdDepartamento").change(function () {
        $("#camping_IdLocalidad").empty();
        $("#camping_IdLocalidad").append('<option value="">Por favor Seleccione una opción</option>');
        $.ajax({
            type: 'POST',
            url: '@Url.Action("ListarLocalidades")',
            dataType: 'json',
            data: { id: $("#camping_IdDepartamento").val() },
            success: function (citys) {
                // states contains the JSON formatted list
                // of states passed from the controller
                $.each(citys, function (i, city) {
                    $("#camping_IdLocalidad").append('<option value="'
+ city.Value + '">'
+ city.Text + '</option>');
                });
            },
            error: function (ex) {
                //alert('Error al cargar ciudades.' + ex);
            }
        });
        return false;
    })
});






