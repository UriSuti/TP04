namespace TP04.Models;

public class Juego
{
    public string palabraSecreta { get; private set; }
    public string palabraMostrada { get; private set; }
    public int intentosRestantes { get; private set; }
    public List<char> letrasAdivinadas { get; private set; }
    public bool finalizo { get; private set; }
    public bool gano { get; private set; }
    public List<char> letrasJugadas { get; private set; }
    public List<string> palabrasJugadas { get; private set; }
    private List<string> palabras = new List<string>
    {
        "elefante",
        "computadora",
        "murcielago",
        "programacion",
        "pantalon",
        "bicicleta"
    };

    public Juego()
    {
        letrasAdivinadas = new List<char>();
        Random random = new Random();
        int numero = random.Next(palabras.Count);
        palabraSecreta = palabras[numero];
        palabraMostrada = new string('_', palabraSecreta.Length);
        intentosRestantes = 6;
        letrasAdivinadas.Clear();
        palabrasJugadas = new List<string>();
        letrasJugadas = new List<char>();
        finalizo = false;
        gano = false;
    }

    public int AdivinarLetra(char letra)
    {
        if (palabraSecreta.Contains(char.ToLower(letra)))
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

    private void ActualizarPalabraMostrada()
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

    public int AdivinarPalabra(string palabra)
    {   
        
        if (palabraSecreta == palabra)
        {
            return 1; //Adivinó
        }
        else if(palabrasJugadas.Contains(palabra))
        {
            return 2; //Ya jugó esa palabra
        }
        else{
            intentosRestantes -= 2;
            if (intentosRestantes <= 0)
            {
                finalizo = true;
            }
            palabrasJugadas.Add(palabra);
            return 3; //Esa palabra esta mal
        }
    }
}