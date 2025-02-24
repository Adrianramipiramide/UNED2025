using GestorCuentas.Services;
using Microsoft.AspNetCore.Components;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestorCuentas.Pages
{
    public partial class Cuenta () : ComponentBase
    {
        [Inject] BrowserPersistence storage { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string correo { get; set; }
        public string contraseña { get; set; }

        public List<Usuario> listaCuentas = new List<Usuario>();

        protected override async Task OnInitializedAsync()
        {
            string cuentasRAW = await storage.localStorage.GetValueAsync<string>("Cuentas");
            listaCuentas = JsonSerializer.Deserialize<List<Usuario>>(cuentasRAW);
            await base.OnInitializedAsync();
        }

        // Método para registrar un nuevo usuario
        public void registrar()
        {
            Console.WriteLine("NUEVO USUARIO!!!");
            Usuario nuevoUsuario = new Usuario(nombre, apellido, correo, contraseña);
            listaCuentas.Add(nuevoUsuario);

            // Guarda los datos
            string datos = JsonSerializer.Serialize(listaCuentas);
            storage.localStorage.SetValueAsync("Cuentas", datos);

            StateHasChanged();

        }

        public void eliminarUsuario(Usuario user)
        {
            listaCuentas.Remove(user);

        }

        public void modifyUsuario(Usuario user, string name, string lastName, string password, string email)
        {
            user.setNombre(name);
            user.setApellido(lastName);
            user.setEmail(email);
            user.setPassword(password);

        }

        public class Usuario
        {
            public string contraseña { get; set; } = "------";
            public string nombre { get; set; } = "----";
            public string apellido { get; set; } = "--------";
            public string correo { get; set; } = "a@gmail.com";

            private List<Usuario> listaCuentas = new List<Usuario>();


            public Usuario(string nombre, string apellido, string correo, string contraseña)
            {
                this.nombre = nombre;
                this.apellido = apellido;
                this.correo = correo;
                this.contraseña = contraseña;
            }

            //getter y setters
            public string getNombre()
            {
                return nombre;
            }

            public string getApellido()
            {
                return apellido;
            }

            public void setNombre(string nombre)
            {
                this.nombre = nombre;
            }

            public void setApellido(string apellido)
            {
                this.apellido = apellido;
            }

            public void setEmail(string email)
            {
                this.correo = email;
            }

            public void setPassword(string password)
            {
                this.contraseña = password;
            }
            //Funciones
            public List<Usuario> registrar(Usuario user)
            {
                listaCuentas.Add(user);
                return listaCuentas;
            }

            public Usuario modifyUsuario(Usuario user, string name, string lastName, string password, string email)
            {
                user.setNombre(name);
                user.setApellido(lastName);
                user.setEmail(email);
                user.setPassword(password);

                return user;
            }

            public List<Usuario> eliminarUsuario(Usuario user)
            {
                listaCuentas.Remove(user);
                return listaCuentas;
            }

            Cuenta cuentas = new Cuenta();

        }
    }
}
