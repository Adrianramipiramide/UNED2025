using GestorCuentas.Pages;
using GestorCuentas.Services;
using System.Text.Json;

namespace Clases.Components.Pages;

public partial class Usuario
{
    public string contraseña { get; set; } = "------";
    public string nombre { get; set; } = "----";
    public string apellido { get; set; } = "--------";
    public string correo { get; set; } = "a@gmail.com";

    public List<Usuario> listaCuentas = new List<Usuario>();


    public Usuario(string nombre, string apellido, string correo, string contraseña)
    {
        this.nombre = nombre;
        this.apellido = apellido;
        this.correo = correo;
        this.contraseña = contraseña;
    }

   
    
    //Funciones
    public List<Usuario> registrar(Usuario user)
    {
        listaCuentas.Add(user);
        return listaCuentas;
    }

    public Usuario modifyUsuario(Usuario user, string name, string lastName, string password, string email)
    {
        this.nombre=name;
        this.apellido = lastName;
        this.correo = email;
        this.contraseña = password;
            //elimina usuario antiguo y add nuevo usuario
        listaCuentas.Remove(listaCuentas.Find(u => u.correo == user.correo));
        listaCuentas.Add(this);

        

        return user;
    }

    public List<Usuario> eliminarUsuario(Usuario user)
    {
        Console.WriteLine($"{user.nombre}");
        listaCuentas.Remove(user);
        return listaCuentas;
    }

    Cuenta cuentas = new Cuenta();

    public async Task guardarDatos(BrowserPersistence persistencia)
    {
        string datos = JsonSerializer.Serialize(listaCuentas);
        await persistencia.localStorage.SetValueAsync("Cuentas", datos);
    }

    public async Task cargarDatos(BrowserPersistence persistencia)
    {
        string cuentasRAW = await persistencia.localStorage.GetValueAsync<string>("Cuentas");
        if (string.IsNullOrEmpty(cuentasRAW)) return;
        this.listaCuentas = JsonSerializer.Deserialize<List<Usuario>>(cuentasRAW);
    }

}
    