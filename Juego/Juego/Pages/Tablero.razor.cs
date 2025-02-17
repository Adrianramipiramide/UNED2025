namespace Juego.Pages
{
    public partial class Tablero
    {
        public int numFila;
        public int numColumna;
        public void generateTablero()
        {

            if(numFila >= 25)
            {
                numFila = 3;
                numColumna = 1;
            }
            for(int i = 0; i < 3; i++)
            {
                numFila++;
                for (int j = 0; j < 2; j++)
                {
                    numColumna++;
                    
                }
            }
        }
    }
}
