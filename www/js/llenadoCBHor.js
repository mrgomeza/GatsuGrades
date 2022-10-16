

function FillComboAnio() {
    var combo = document.getElementById("calectivo");
    var option = document.createElement('option');
    // añadir el elemento option y sus valores
    combo.options.add(option, 0);
    combo.options[0].value = "valor";
    combo.options[0].innerText = "Texto";
}
function llenaComboAnios() {
    $.ajax({
        type: 'GET',
        url: 'https://localhost:44332/ANO_LECTIVO/Anios',
        success: function (data, textStatus, jqXHR) {
            $.each(data, function (key, value) {
                $(
                    
                ).appendTo('#Jugadores');
            }
            );
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alter('Estatus: ' + textStatus + '(' + errorThrown + ')');
        }
    });
}

document.addEventListener("load", llenaComboAnios);
document.getElementById('#grad').Attributes.Add("onChange", "metodoJavascript(this);");
combo = document.getElementById('#grad');
function metodoJavascript(combo) {
    var valor = combo.options[combo.selectedIndex].value;
    alert(valor);
}

alert(document.getElementById('#grad').value);


   //resto del script si lo hay

 if(ViewBag.Message != ""){

    alert('@ViewBag.Message');

 }

