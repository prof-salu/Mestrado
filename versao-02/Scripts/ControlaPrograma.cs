using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaPrograma
{
	#region 
	public interface Comando
	{
		IEnumerator Executar(Personagem personagem);
	}

	public class ParaCima : Comando
	{
		public IEnumerator Executar(Personagem personagem)
		{
			personagem.ParaCima();

#if DEBUG
			Debug.Log("Para Cima");
#endif

			return null;
		}
	}


	public class ParaBaixo : Comando
	{
		public IEnumerator Executar(Personagem personagem)
		{
			personagem.ParaBaixo();

#if DEBUG
			Debug.Log("Para Baixo");
#endif

			return null;
		}
	}

	public class ParaEsquerda : Comando
	{
		public IEnumerator Executar(Personagem personagem)
		{
			personagem.ParaEsquerda();

#if DEBUG
			Debug.Log("Para Esquerda");
#endif

			return null;
		}
	}

	public class ParaDireita : Comando
	{
		public IEnumerator Executar(Personagem personagem)
		{
			personagem.ParaDireita();

#if DEBUG
			Debug.Log("Para Direita");
#endif

			return null;
		}
	}
	#endregion


	public static float ATRASO = 0.5f;

	private List<Comando> comandos;
	private int contador;

	public ControlaPrograma(List<Comando> comandos)
	{
		this.comandos = comandos;
		contador = 0;
	}


	public IEnumerator Run(Personagem personagem)
	{
		while (contador < comandos.Count)
		{
			yield return new WaitForSeconds(ATRASO);

			Comando proximoComando = comandos[contador++];
			yield return proximoComando.Executar(personagem);
		}
	}


	public void Reset()
	{
		contador = 0;
	}
}
