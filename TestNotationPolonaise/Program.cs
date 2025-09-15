using System;

namespace TestNotationPolonaise
{
    class Program
    {
        /// <summary>
        /// Calcul d'une formule en notation polonaise
        /// </summary>
        /// <param name="formule">La formule a calculer</param>
        /// <returns>résultat du calcul</returns>
        static double Polonaise(String formule)
        {
            double resultat = double.NaN;
            String[] formuleSplit = formule.Split(' ');
            double x, y;

            int i = (formuleSplit.Length - 1);
            while ( i >= 2)
            {
                int j = i;
                while ((j > 0) && formuleSplit[j] != "+" && formuleSplit[j] != "-" && formuleSplit[j] != "*" && formuleSplit[j] != "/")
                {
                    Console.WriteLine("j = " + j);
                    j--;
                }
                
                try
                {
                    Console.WriteLine("formuleSplit[j + 2] = " + formuleSplit[j + 2]);
                    x = double.Parse(formuleSplit[j + 2]);
                }
                catch
                {
                    return double.NaN;
                }

                try
                {
                    Console.WriteLine("formuleSplit[j + 1] = " + formuleSplit[j + 1]);
                    y = double.Parse(formuleSplit[j + 1]);
                }
                catch
                {
                    return double.NaN;
                }

                Console.WriteLine("formuleSplit[j] = " + formuleSplit[j]);
                switch (formuleSplit[j])
                {
                    case "+": resultat = y + x; 
                        break;
                    case "-": resultat = y - x;
                        break;
                    case "*": resultat = y * x;
                        break;
                    case "/":
                        if (x == 0) {
                            return double.NaN;
                        }
                        else
                        {
                           resultat = y / x;
                            break;
                        }
                    default: return double.NaN;
                }

                for (int m = 0; m < formuleSplit.Length; m++)
                {
                    Console.Write(" " + formuleSplit[m]);
                }
                Console.WriteLine();

                formuleSplit[j] = resultat.ToString();

                int k;
                for (k = j + 1; k < formuleSplit.Length - 2; k++)
                {
                    formuleSplit[k] = formuleSplit[k+2];
                    formuleSplit[k + 2] = "";
                    formuleSplit[k + 1] = "";
                }
                // formuleSplit[k] = "";
                // formuleSplit[k - 1] = "";


                for (int m = 0; m < formuleSplit.Length; m++)
                {
                    Console.Write(" " + formuleSplit[m]);
                }
                Console.WriteLine();

                i = i - 2;
                Console.WriteLine("i = " + i);
            }

            if (i + 1 == 0)
            {
                return double.NaN;
            }

            if (i + 1 == 1)
            {
                try
                {
                    x = double.Parse(formuleSplit[0]);
                    resultat = x;
                }
                catch
                {
                    return double.NaN;
                }
            }

            if (i + 1 == 2)
            {
                return double.NaN;
            }

            return resultat;
        }

        /// <summary>
        /// saisie d'une réponse d'un caractère parmi 2
        /// </summary>
        /// <param name="message">message à afficher</param>
        /// <param name="carac1">premier caractère possible</param>
        /// <param name="carac2">second caractère possible</param>
        /// <returns>caractère saisi</returns>
        static char saisie(string message, char carac1, char carac2)
        {
            char reponse;
            do
            {
                Console.WriteLine();
                Console.Write(message + " (" + carac1 + "/" + carac2 + ") ");
                reponse = Console.ReadKey().KeyChar;
            } while (reponse != carac1 && reponse != carac2);
            return reponse;
        }

        /// <summary>
        /// Saisie de formules en notation polonaise pour tester la fonction de calcul
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            char reponse;
            // boucle sur la saisie de formules
            do
            {
                Console.WriteLine();
                Console.WriteLine("entrez une formule polonaise en séparant chaque partie par un espace = ");
                string laFormule = Console.ReadLine();
                // affichage du résultat
                Console.WriteLine("Résultat =  " + Polonaise(laFormule));
                reponse = saisie("Voulez-vous continuer ?", 'O', 'N');
            } while (reponse == 'O');
        }
    }
}
