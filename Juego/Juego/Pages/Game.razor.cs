namespace Juego.Pages
{
    public partial class Game
    {
        public int numeroIncognito;
        public int numeroIntroducido;
        public string max = "----";

        private Random random = new Random();


        public void getNumero()
        {
            if (numeroIntroducido > 100 || numeroIntroducido < 0)
            {
                throw new Exception("El numero tiene que estar entre 1 y 100");
            }

            numeroIncognito = random.Next(1, 100);

            if (numeroIncognito > numeroIntroducido)
            {
                max = "mayor";
            }
            else if (numeroIncognito < numeroIntroducido)
            {
                max = "menor";
            }
            else
            {
                max = "felicidades, has ganado";
            }
        }
    }
}