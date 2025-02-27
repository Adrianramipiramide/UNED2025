using Clases.Components.Pages;
using GestorCuentas.Services;
using Microsoft.AspNetCore.Components;

namespace GestorCuentas.Pages
{
    public partial class Cuenta
    {
        [Inject] private BrowserPersistence storage { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string correo { get; set; }
        public string contraseña { get; set; }

        

        private List<Usuario> listaCuentas = new List<Usuario>();

        protected override async Task OnInitializedAsync()
        {
            var instancia = new Usuario("", "", "", "");
            await instancia.cargarDatos(storage);
            listaCuentas = instancia.listaCuentas;

            await base.OnInitializedAsync();
        }

        // Método para registrar un nuevo usuario
        public async Task registrar()
        {
            Console.WriteLine($"NUEVO USUARIO!!! {nombre}");

            // Crea el nuevo usuario
            Usuario nuevoUsuario = new Usuario(nombre, apellido, correo, contraseña);
            await nuevoUsuario.cargarDatos(storage);

            // Registra el usuario
            nuevoUsuario.registrar(nuevoUsuario);
            await nuevoUsuario.guardarDatos(storage);

            // Carga la lista nueva
            listaCuentas = nuevoUsuario.listaCuentas;
            StateHasChanged();
        }

        public async Task eliminarUsuario(Usuario user)
        {
            // Carga los datos de la lista
            await user.cargarDatos(storage);
            listaCuentas = user.listaCuentas;

            // Eliminar y guarda los cambios
            listaCuentas.Remove(user.listaCuentas.Find(u => u.correo == user.correo));
            user.listaCuentas = listaCuentas;
            await user.guardarDatos(storage);

            // Carga la lista nueva
            listaCuentas = user.listaCuentas;
            StateHasChanged();
        }



    }
}
