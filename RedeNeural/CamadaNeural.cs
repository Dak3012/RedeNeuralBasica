using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Aresta
{
	public int EndereçoOrigem { get; set; }
	public int EndereçoDestino { get; set; }
	public float Valor { get; set; }
}
public class CamadaNeural
{
	public List<Aresta> ListaArestas { get; set; }
	public CamadaNeural(CamadaNeural camadaNeural)
	{
		ListaArestas = camadaNeural.ListaArestas;
	}
	public CamadaNeural(int NOrigem, int NDestino)
	{
		ListaArestas = new List<Aresta>();
		for (int EndereçoOrigem = 0; EndereçoOrigem < NOrigem; EndereçoOrigem++)
		{
			for (int EndereçoDestino = 0; EndereçoDestino < NDestino; EndereçoDestino++)
			{
				ListaArestas.Add(new Aresta()
				{
					EndereçoDestino = EndereçoDestino,
					EndereçoOrigem = EndereçoOrigem,
					Valor = new Random().NextSingle(),
				});
			}
		}
	}
}
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
}
