using static GestorCuentas.Pages.Cuenta;

namespace GestorCuentas.Pages
{
    public partial class Modificar
    {

        public List<Usuario> listaCuentas = new List<Usuario>();

        public static string name = "----";
        public static string contraseña = "----";
        public static string apellido = "----";
        public static string email = "----";


        Usuario usuario = new Usuario(name,apellido,email,contraseña);
        public void modifyUsuario()
        {
            usuario.setNombre(name);
            usuario.setApellido(apellido);
            usuario.setEmail(email);
            usuario.setPassword(contraseña);

        }
    }
}
