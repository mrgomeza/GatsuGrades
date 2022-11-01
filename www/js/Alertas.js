function borrar () {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'No puedes eliminar este registro',
        footer: '<a href="">Debes llamar a un administrador</a>'
    })
};