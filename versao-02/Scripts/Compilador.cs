using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;

#region Aliases
using ParaCima = ControlaPrograma.ParaCima;
using ParaBaixo = ControlaPrograma.ParaBaixo;
using ParaEsquerda = ControlaPrograma.ParaEsquerda;
using ParaDireita = ControlaPrograma.ParaDireita;
#endregion
public class Compilador : MonoBehaviour
{
	public Personagem personagem;
	private List<ControlaPrograma.Comando> comandos;
	private List<ControlaPrograma.Comando> Comandos
	{
		get
		{
			return comandos;
		}
	}

	public Compilador()
	{
		comandos = new List<ControlaPrograma.Comando>();
	}

	public static ControlaPrograma Compile(string source)
	{
		AntlrInputStream antlerStream = new AntlrInputStream(source);
		MinhaLinguagemLexer lexer = new MinhaLinguagemLexer(antlerStream);
		CommonTokenStream tokenStream = new CommonTokenStream(lexer);
		MinhaLinguagemParser parser = new MinhaLinguagemParser(tokenStream);

		parser.prog(); 

		Compilador compiler = parser.Compiler;
		ControlaPrograma program = new ControlaPrograma(compiler.Comandos);

		return program;
	}


	public Compilador AddParaCima()
	{
		ParaCima comando = new ParaCima();
		comandos.Add(comando);

		return this;
	}

	public Compilador AddParaBaixo()
	{
		ParaBaixo comando = new ParaBaixo();
		comandos.Add(comando);

		return this;
	}

	public Compilador AddParaEsquerda()
	{
		ParaEsquerda comando = new ParaEsquerda();
		comandos.Add(comando);

		return this;
	}

	public Compilador AddParaDireita()
	{
		ParaDireita comando = new ParaDireita();
		comandos.Add(comando);

		return this;
	}
}
