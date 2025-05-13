namespace TP04.Models;

public class Juego
{
    public static string palabraSecreta { get; private set; }
    public static string palabraMostrada { get; private set; }
    public static int intentosRestantes { get; private set; }
    public static List<char> letrasAdivinadas { get; private set; }
    public static bool finalizo { get; private set; }
    public static bool gano { get; private set; }
    public static List<char> letrasJugadas { get; private set; }
    public static List<string> palabrasJugadas { get; private set; }
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
        int numero = random.Next(palabras.Count);
        palabraSecreta = palabras[numero];
        palabraMostrada = new string('_', palabraSecreta.Length);
        intentosRestantes = 6;
        letrasAdivinadas.Clear();
        letrasJugadas = new List<char>();
        finalizo = false;
        gano = false;
    }

    public static int AdivinarLetra(char letra)
    {
        if (finalizo) return 4;

        if (palabraSecreta.Contains(letra))
        {
            letrasAdivinadas.Add(letra);
            ActualizarPalabraMostrada();
            return 1;
        }
        else if(letrasJugadas.Contains(letra) == false)
        {
            intentosRestantes--;
            if (intentosRestantes <= 0)
            {
                finalizo = true;
            }
            letrasJugadas.Add(letra);
            return 2;
        }
        else{

            return 3;

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

    public static int AdivinarPalabra(string palabra)
    {
        if (finalizo) return 4;

        if (palabraSecreta == palabra)
        {
            ActualizarPalabraMostrada();
            return 1;
        }
        else if(palabrasJugadas.Contains(palabra) == false)
        {
            intentosRestantes--;
            if (intentosRestantes <= 0)
            {
                finalizo = true;
            }
            return 2;
        }
        else{
            return 3;
        }
    }
}