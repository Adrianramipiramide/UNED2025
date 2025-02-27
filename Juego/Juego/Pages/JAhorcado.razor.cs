using Microsoft.AspNetCore.Components;
using System.Collections;

namespace Juego.Pages
{
    public partial class JAhorcado : ComponentBase
    {

        public string esta = " -- ";

        public string victoria="";

        public string palabra;

        public char letra;

        public int fallos;

        public ArrayList letrass = new ArrayList();
        public ArrayList letrasImprimir = new ArrayList();


        public void comprobarLetra()
        {
            if (fallos == 5)
            {
                victoria = "Has perdido. La palabra era: " + palabra;
            }

            if (palabra.Contains(letra) == true)
            {
                letrass.Add(letra);

                esta = "esta";
               
            }
            else
            {
                esta = "no esta";
                fallos++;
            }
                
         //   mostrarLetras();
            imprimirPalabra();
        }
/*
 *   public string mostrarLetras()
        {
            for (int i = 0; i >= palabra.Length; i++)
            {
                if (palabra.Contains(letrass[i]))
                {
                    return (string)letrass[i];
                }
                else
                {
                    return "-";
                }
            }
            return ".";
        }
 * 
 * 
 * \//*/
      
        public string imprimirPalabra()
        {
            letrasImprimir.Clear();
            int cont = 0;
            for (int i = 0 ; i < palabra.Length; i++)
            {
                if (letrass.Contains(palabra[i]))
                {
                    cont++;

                    letrasImprimir.Add(palabra[i]);

                }
                else
                {
                    letrasImprimir.Add('-');
                    //print _
                }
            }
            if (cont == palabra.Length)
            {
                victoria = "felicidades, has acertado todas las letras de la palabra";
                return palabra;
            }
            else
            {
                return "";
            }
        }
    }
}

