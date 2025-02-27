using Clases.Components.Pages;
using System.Text.Json;

namespace GestorCuentas.Services;

public class Sesion(BrowserPersistence storage) {

    private Usuario? Usuario { get; set; }

    public async Task<Usuario?> getLoggedUser()
    {
        await cargarDatos();
        return Usuario;
    }

    public async Task IniciarSesión(Usuario user)
    {
        this.Usuario = user;
        await guardarDatos();
    }


    public async Task CerrarSesion()
    {
        this.Usuario = null;
        await guardarDatos();
    }


    public async Task<bool> estaSesionIniciada()
    {
        await cargarDatos();
        return Usuario != null;
    }

    private async Task guardarDatos()
    {
        string datos = JsonSerializer.Serialize(Usuario);
        await storage.localStorage.SetValueAsync("Sesion", datos);
    }

    public async Task cargarDatos()
    {
        string cuentasRAW = await storage.localStorage.GetValueAsync<string>("Sesion");
        if (string.IsNullOrEmpty(cuentasRAW)) return;
        this.Usuario = JsonSerializer.Deserialize<Usuario>(cuentasRAW);
    }
}
