$(document).ready(function () {
    var selectedCity = $("#SelectedValue").val();

    if (selectedCity == "") {
        $("#summary").hide();
    }
    else {
        $("#summary").show();
    }
})

function city_Onchange() {
    //get the selected value        
    var selectedCity = $("#SelectedValue").val();

    if (selectedCity == "") {
        alert("Please select a city");
        $("#summary").hide();
        return false;
    }
    else {
        $("#summary").show();
    }

    $.ajax({
        url: "/Home/GetWeatherByCity",
        type: "POST",
        data: {selectedCity},
        dataType: "json",
        beforeSend: function () {
            $(".loading").show();
        },
        success: function (data) {                                              
            var desc = "Description: " + data.description;
            var temp = "Temperature: " + data.temperature;
            var uvIndex = "UV Index: " + data.uvIndex;

            $("#city-header").text($("#SelectedValue").val());
            $("#description").text(desc);
            $("#temperature").text(temp);
            $("#uvindex").text(uvIndex);              
        },
        error: function (xhr, status, error) {
            // Handle errors                
            alert("An error occurred " + error);
        },
        complete: function () {
            // Hide the loading element
            $(".loading").hide();
        }
    });
}
