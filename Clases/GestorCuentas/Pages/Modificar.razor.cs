using Microsoft.AspNetCore.Components;
using GestorCuentas.Services;
using System.Text.Json;
using Clases.Components.Pages;

namespace GestorCuentas.Pages;

public partial class Modificar : ComponentBase
{
    
    [Inject] private NavigationManager Navigation { get; set; }

    [Inject] private GestorDeCuentas cuentas { get; set; }

    [Parameter] public string Correo { get; set; }

    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Contraseña { get; set; }

    private Usuario UsuarioSeleccionado { get; set; } = new("", "", "", "");

    protected override async Task OnInitializedAsync()
    {
        UsuarioSeleccionado = await cuentas.GetUser(Correo);
        await base.OnInitializedAsync();
    }

    // Método para guardar los cambios
    public async Task GuardarCambios()
    {
        if (UsuarioSeleccionado != null)
        {

            UsuarioSeleccionado.nombre = Nombre;
            UsuarioSeleccionado.apellido = Apellido;
            UsuarioSeleccionado.contraseña = Contraseña;
            await cuentas.Modificar(UsuarioSeleccionado);

            Navigation.NavigateTo("/");
        }
    }
}
