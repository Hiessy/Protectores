function hideAttrPerfil() {
        $("#Usuario_Organizacion").parent().parent().hide();
        $("#Usuario_Direccion").parent().parent().hide();
        $("#Usuario_Telefono").parent().parent().hide();
}

function showAttrPerfil() {
    $("#Usuario_Organizacion").parent().parent().show();
    $("#Usuario_Direccion").parent().parent().show();
    $("#Usuario_Telefono").parent().parent().show();
}

function verAttrPerfil() {
    var estadoPerfil = $("#Usuario_Perfil").val();
    if (estadoPerfil == 0) {
        hideAttrPerfil();
    } else {
        showAttrPerfil();
    }
}

hideAttrPerfil();