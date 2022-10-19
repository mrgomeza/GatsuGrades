function check() {
    //texto del p
    var opcion = $("#lp1").val();

    if (opcion == "Se ingreso la materia") {
        $("#L1").css("background-color", "orange");
        $("#lp1").val() = "Se ingreso la materia";
    } else if (opcion == "No se pudo ingresar"){
        $("#L1").css("background-color", "red");
        $("#lp1").val() = "No se pudo ingresar";
    }
}
