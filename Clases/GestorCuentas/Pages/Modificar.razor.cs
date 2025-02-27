using Microsoft.AspNetCore.Components;
using GestorCuentas.Services;
using System.Text.Json;
using Clases.Components.Pages;

namespace GestorCuentas.Pages;

public partial class Modificar : ComponentBase
{
    [Inject] private BrowserPersistence storage { get; set; }
    
    [Inject] private NavigationManager Navigation { get; set; }

    [Parameter] public string Correo { get; set; }

    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Contraseña { get; set; }

    private Usuario UsuarioSeleccionado { get; set; } = new("", "", "", "");

    protected override async Task OnInitializedAsync()
    {
        await UsuarioSeleccionado.cargarDatos(storage);

     
            UsuarioSeleccionado = UsuarioSeleccionado.listaCuentas.Find(u => u.correo == Correo);
            if (UsuarioSeleccionado != null)
            {
                Nombre = UsuarioSeleccionado.nombre;
                Apellido = UsuarioSeleccionado.apellido;
                Contraseña = UsuarioSeleccionado.contraseña;
            }
        
        await base.OnInitializedAsync();
    }

    // Método para guardar los cambios
    public async Task GuardarCambios()
    {
        if (UsuarioSeleccionado != null)
        {

     
            await UsuarioSeleccionado.cargarDatos(storage);
            UsuarioSeleccionado.modifyUsuario(UsuarioSeleccionado, Nombre, Apellido, Contraseña, UsuarioSeleccionado.correo);
            UsuarioSeleccionado.guardarDatos(storage);


            Navigation.NavigateTo("/");
        }
    }
}
