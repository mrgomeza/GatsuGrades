function borrar() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'No puedes eliminar este registro',
        footer: '<a href="">LLama a un administrador</a>'
    })
};