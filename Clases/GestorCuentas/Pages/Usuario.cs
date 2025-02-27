using GestorCuentas.Pages;
using GestorCuentas.Services;
using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace Clases.Components.Pages;

public partial class Usuario
{
    public string contraseña { get; set; } = "------";
    public string nombre { get; set; } = "----";
    public string apellido { get; set; } = "--------";
    public string correo { get; set; } = "a@gmail.com";

    public Usuario(string nombre, string apellido, string correo, string contraseña)
    {
        this.nombre = nombre;
        this.apellido = apellido;
        this.correo = correo;
        this.contraseña = contraseña;
    }

}
