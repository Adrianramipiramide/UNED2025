namespace Juego.Pages
{
    public partial class Calculadora
    {
        private double num;
        private double num2;

        public double resultado = 0;
        public void suma()
        {
            resultado = (num + num2);

        }

        public void resta()
        {
            resultado = (num - num2);

        }

        public void multiplicacion()
        {
            resultado = (num * num2);

        }

        public void division()
        {
            resultado = (num / num2);
        }
    }
}
