using Clases.Components.Pages;
using GestorCuentas.Services;
using Microsoft.AspNetCore.Components;

namespace GestorCuentas.Pages
{
    public partial class Cuenta
    {
        [Inject] private GestorDeCuentas cuentas { get; set; }

        public string nombre { get; set; }
        public string apellido { get; set; }
        public string correo { get; set; }
        public string contraseña { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await cuentas.cargarDatos();
            await base.OnInitializedAsync();
        }

        // Método para registrar un nuevo usuario
        public async Task registrar()
        {
            Console.WriteLine($"NUEVO USUARIO!!! {nombre}");

            var newUser = new Usuario(nombre, apellido,correo,contraseña);
            await cuentas.RegistrarUsuario(newUser);
        }

        public async Task eliminarUsuario(Usuario user)
        {
            await cuentas.EliminarUsuario(user);
            StateHasChanged();
        }
    }
}
