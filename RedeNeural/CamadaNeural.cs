/// <summary>
/// Classe da camada neural responsavel por guardar as informações de intereções entre as camadas de neuronios.
/// </summary>
public class CamadaNeural
{
    public double[,] ListaArestas { get; set; }
    public CamadaNeural(double[,] listaArestas)
    {
        ListaArestas = listaArestas;
    }
    public CamadaNeural(int NOrigem, int NDestino)
    {
        ListaArestas = new double[NOrigem, NDestino];
        for (int EndereçoOrigem = 0; EndereçoOrigem < NOrigem; EndereçoOrigem++)
        {
            for (int EndereçoDestino = 0; EndereçoDestino < NDestino; EndereçoDestino++)
            {
                ListaArestas[EndereçoOrigem, EndereçoDestino] = new Random().NextDouble();
            }
        }
    }
}
/// <summary>
/// Nova rede neural, inicia uma novo "individuo" com as camadas randomicas.
/// </summary>
/// <param name="Entradas">Número de entradas da rede neural</param>
/// <param name="Saidas">Número maxímo de siada da rede neural</param>
/// <param name="tamanhoCamadas">Tamanho das camadas intermediarias</param>
/// <param name="QuantidadeCamadas">Número de camadas intermeiaras da rede neuras</param>
public class RedeNeural
{
    public List<CamadaNeural> CamadaNeural { get; set; }
    public RedeNeural(int Entradas, int Saidas, int tamanhoCamadas, int QuantidadeCamadas)
    {
        CamadaNeural = new List<CamadaNeural>();
        CamadaNeural.Add(new CamadaNeural(Entradas, tamanhoCamadas)); //Camada neural de entrada
        for (int nCamada = 0; nCamada < QuantidadeCamadas; nCamada++)
        {
            CamadaNeural.Add(new CamadaNeural(tamanhoCamadas, tamanhoCamadas)); //Camadas intermediarias
        }
        CamadaNeural.Add(new CamadaNeural(tamanhoCamadas, Saidas)); //Camada Neural de Saida
    }
    /// <summary>
    /// Deep Clone
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public RedeNeural CloneRede()
    {
        var objectserialize = JsonConvert.SerializeObject(this).ToString();
        var newObject = JsonConvert.DeserializeObject<RedeNeural>(objectserialize);
        if (newObject == null)
        {
            throw new Exception("Objeto inválido");
        }
        else
        {
            return newObject;
        }
    }
    /// <summary>
    /// Randomiza a rede de acordo o dado de entrada como sendo o valor de 0 a 1, o grau de diferença entre os individuos.
    /// </summary>
    /// <param name="Diferença">Diferença Maxima entre as redes neurais</param>
    /// <param name="grauMaximo">Grau maxímo da diferença entre os mesmos pares de arestas</param>
    /// <returns></returns>
    public RedeNeural RandomStats(double Diferença, double grauMaximo)
    {
        var redeNerural = this.CloneRede();
        var camadasNeurais = redeNerural.CamadaNeural;
        var random = new Random();
        foreach (var CamadaNeural in camadasNeurais)
        {
            var arestas = CamadaNeural.ListaArestas;
            var dimensionX = arestas.GetUpperBound(1);
            var dimensionY = arestas.GetUpperBound(2);
            for (var x = 0; x < dimensionX; x++)
            {
                for (var y = 0; y < dimensionY; y++)
                {
                    var dou = random.NextDouble();
                    if (dou > Diferença)
                    {
                        var valor = random.NextDouble() * grauMaximo * 2 - 1 + arestas[x,y];
                        arestas[x, y] = valor > 1?1:(valor < -1?-1:valor);
                    }
                }
            }
        }
        return redeNerural;
    }
}