namespace TP04.Models;

public class Juego
{
    public static string palabraSecreta { get; private set; }
    public static string palabraMostrada { get; private set; }
    public static int intentosRestantes { get; private set; }
    public static List<char> letrasAdivinadas { get; private set; }
    public static bool finalizo { get; private set; }
    public static bool gano { get; private set; }
    private static List<string> palabras = new List<string>
    {
        "elefante",
        "computadora",
        "murcielago",
        "programacion",
        "pantalon",
        "bicicleta"
    };

    public static void IniciarNuevoJuego()
    {
        letrasAdivinadas = new List<char>();
        Random random = new Random();
        palabraSecreta = palabras[random.Next(palabras.Count)];
        palabraMostrada = new string('_', palabraSecreta.Length);
        intentosRestantes = 6;
        letrasAdivinadas.Clear();
        finalizo = false;
        gano = false;
    }

    public static bool AdivinarLetra(char letra)
    {
        if (finalizo) return false;

        if (palabraSecreta.Contains(letra))
        {
            letrasAdivinadas.Add(letra);
            ActualizarPalabraMostrada();
            return true;
        }
        else
        {
            intentosRestantes--;
            if (intentosRestantes <= 0)
            {
                finalizo = true;
            }
            return false;
        }
    }

    private static void ActualizarPalabraMostrada()
    {
        string nuevaPalabraMostrada = "";
        
        for (int i = 0; i < palabraSecreta.Length; i++)
        {
            if (letrasAdivinadas.Contains(palabraSecreta[i]))
            {
                nuevaPalabraMostrada += palabraSecreta[i];
            }
            else
            {
                nuevaPalabraMostrada += '_';
            }
        }

        palabraMostrada = nuevaPalabraMostrada;
        gano = !palabraMostrada.Contains('_');
        finalizo = gano || intentosRestantes <= 0;
    }
}