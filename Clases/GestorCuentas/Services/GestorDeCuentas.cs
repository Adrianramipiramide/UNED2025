using Clases.Components.Pages;
using System.Text.Json;

namespace GestorCuentas.Services;

public class GestorDeCuentas {

    public List<Usuario> listaCuentas { get; private set; } = new List<Usuario>();
    private BrowserPersistence storage;

    public GestorDeCuentas(BrowserPersistence persistence) {
        this.storage = persistence;
    }

    public async Task<Usuario?> GetUser(string email)
    {
        await cargarDatos();
        return this.listaCuentas.Find(u => u.correo == email);
    }

    public async Task RegistrarUsuario(Usuario user)
    {
        listaCuentas.Add(user);
        await this.guardarDatos();
    }

    public async Task EliminarUsuario(Usuario user)
    {
        listaCuentas.Remove(listaCuentas.Find(u => u.correo == user.correo));
        await this.guardarDatos();
    }

    public async Task Modificar(Usuario user)
    {
        // Buscamos el correo del usario existentey lo borramos
        listaCuentas.Remove(listaCuentas.Find(u => u.correo == user.correo));

        // Añadimos el usuario modificado
        listaCuentas.Add(user);

        await this.guardarDatos();
    }

    private async Task guardarDatos()
    {
        string datos = JsonSerializer.Serialize(listaCuentas);
        await storage.localStorage.SetValueAsync("Cuentas", datos);
    }

    public async Task cargarDatos()
    {
        string cuentasRAW = await storage.localStorage.GetValueAsync<string>("Cuentas");
        if (string.IsNullOrEmpty(cuentasRAW)) return;
        this.listaCuentas = JsonSerializer.Deserialize<List<Usuario>>(cuentasRAW);
    }
}
