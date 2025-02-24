using GestorCuentas.Services;
using Microsoft.AspNetCore.Components;
using System.Text.Json;
using static GestorCuentas.Pages.Cuenta;

namespace GestorCuentas.Pages
{
    public partial class Modificar
    {
        [Inject] BrowserPersistence storage { get; set; }
        public List<Usuario> listaCuentas = new List<Usuario>();

        public static string name;
        public static string contraseña ;
        public static string apellido;
        public static string email;

        Usuario usuario = new Usuario(name,apellido,email,contraseña);
        public void modifyUsuario()
        {
            usuario.setNombre(name);
            usuario.setApellido(apellido);
            usuario.setEmail(email);
            usuario.setPassword(contraseña);
        }

        protected override async Task OnInitializedAsync()
        {
            string cuentasRAW = await storage.localStorage.GetValueAsync<string>("Cuentas");
            listaCuentas = JsonSerializer.Deserialize<List<Usuario>>(cuentasRAW);
            await base.OnInitializedAsync();
        }
    }
}
