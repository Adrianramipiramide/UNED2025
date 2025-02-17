namespace Juego.Pages
{
    public partial class KmCalculador
    {
        public double litros = 0;
        public double km = 0;
        public double precio = 0;
        public double precioL = 1.5;
        public const double consumo = 7;

        

        public double calculateLitros()
        {
            litros = (consumo*km)/100;
            precio = litros * precioL;
            precio = Math.Round(precio,2);
            return precio;
        }
    }
}
