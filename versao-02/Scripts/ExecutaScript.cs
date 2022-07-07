using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecutaScript : MonoBehaviour
{
	private Personagem personagem;
	private ControlaPrograma programa;	
	private Vector3 posicaoInicial;

	void Awake()
    {
		personagem = GetComponent<Personagem>();
	}

	void Start()
	{
		posicaoInicial = transform.position;
	}


	public void CompileAndRun(string code)
	{
		StopAllCoroutines();
		ResetTransform();
		programa = Compilador.Compile(code);
		StartCoroutine(programa.Run(personagem));
	}


	private void ResetTransform()
	{
		transform.position = posicaoInicial;
	}
}
