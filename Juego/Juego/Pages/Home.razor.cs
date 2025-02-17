namespace Juego.Pages
{
    public partial class Home
    {

        public int piedra = 1;
        public int papel = 2;
        public int tijera = 3;

        public int? usuario = null;
        public int? ordenador = null;
        public bool? resultado = null;
        public int numVictorias = 0;
        public int numDerrotas = 0;

        public string usuarioJ;
        public string ordenadorJ;

       


        public Boolean? randomCalcular(int obj)
        {
            int random = new Random().Next(1, 4);
            usuario = obj;
            ordenador = random;

            Console.WriteLine("Usuario: " + obj + "Ordenador: " + random);
            if (random == obj)

            {
                Console.WriteLine("___");
                return null;
            }
            else if (random == piedra && obj == papel)
            {
                Console.WriteLine("___");
                return true;
            }
            else if (random == piedra && obj == tijera)
            {
                return false;
            }
            else if (random == tijera && obj == piedra)
            {
                return false;
            }
            else if (random == tijera && obj == papel)
            {
                Console.WriteLine("___");
                return false;
            }
            else if (random == papel && obj == piedra)
            {
                return true;
            }
            else if (random == papel && obj == tijera)
            {
                return true;
            }

            Console.WriteLine("Esto no deberia aparecer");
            return null;
        }

        public void ataque(int obj)
        {
            resultado = randomCalcular(obj);
            if (resultado == true)
            {
                numVictorias++;
            }

            if(resultado == false)
            {
                numDerrotas++;
            }

            Console.WriteLine("EL resultado es " + resultado);
            numPalabras();
        }


        //segun el resultado de los random, los pasa a palabras
        public void numPalabras()
        {

            if (usuario == 1)
            {
                usuarioJ = "Piedra";
            }
            else if (usuario == 2)
            {
                usuarioJ = "Papel";
            }
            else if (usuario == 3)
            {
                usuarioJ = "Tijera";
            }
            
            if (ordenador == 1)
            {
                ordenadorJ = "Piedra";
            }
            else if (ordenador == 2)
            {
                ordenadorJ = "Papel";
            }
            else if (ordenador == 3)
            {
                ordenadorJ = "Tijera";
            }
        }
    }
}
