// wwwroot/js/validation.js

document.addEventListener('DOMContentLoaded', function () {
    const form = document.querySelector('form');

    form.addEventListener('submit', function (event) {
        let valid = true;

        // Validación del nombre
        const firstName = document.querySelector('input[name="FirstName"]');
        if (firstName.value.trim() === '') {
            valid = false;
            firstName.classList.add('is-invalid');
            // Mostrar mensaje de error
            alert('El nombre es requerido.');
        } else {
            firstName.classList.remove('is-invalid');
        }

        // Puedes agregar más validaciones aquí...

        if (!valid) {
            event.preventDefault(); // Evita el envío del formulario si no es válido
        }
    });
});
