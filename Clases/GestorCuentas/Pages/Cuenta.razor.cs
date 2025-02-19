using Microsoft.AspNetCore.Components;

namespace GestorCuentas.Pages
{
    public partial class Cuenta : ComponentBase
    {

        public string nombre { get; set; }
        public string apellido { get; set; }
        public string correo { get; set; }
        public string contraseña { get; set; }

        public List<Usuario> listaCuentas = new List<Usuario>();

        // Método para registrar un nuevo usuario
        public void registrar()
        {
            Console.WriteLine("NUEVO USUARIO!!!");
            Usuario nuevoUsuario = new Usuario(nombre, apellido, correo, contraseña);
            listaCuentas.Add(nuevoUsuario);
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

        public partial class Usuario
        {
            public string contraseña = "------";
            public string nombre = "----";
            public string apellido = "--------";
            public string correo = "a@gmail.com";

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
