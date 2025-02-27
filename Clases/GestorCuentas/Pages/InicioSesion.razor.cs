using Clases.Components.Pages;
using GestorCuentas.Services;
using Microsoft.AspNetCore.Components;

namespace GestorCuentas.Pages
{
    public partial class InicioSesion
    {

        [Inject] private NavigationManager Navigation { get; set; }
        [Inject] private GestorDeCuentas cuentas { get; set; }
        [Inject] private Sesion sesion { get; set; }

        [Parameter] public string correo { get; set; }
        [Parameter] public string Contraseña { get; set; }


        public async Task<Boolean> IniciarSesion()
        {
           
            Usuario? foundUser = await cuentas.GetUser(correo);

            if (foundUser == null)
            {
                Console.WriteLine("Usuario no encontrado");
                return false;
            }

            if (foundUser.contraseña != Contraseña)
            {
                Console.WriteLine("Contraseña incorrecta");
                return false;
            }

            await sesion.IniciarSesión(foundUser);


            return true;

        }
    }
}
