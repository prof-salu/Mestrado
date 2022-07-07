using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditorCodigoFonte : MonoBehaviour
{
	public Text codigoFonte;
	public ExecutaScript executaScript;

	public void OnCompileAndRunClick()
	{
		if (executaScript != null)
		{
			executaScript.CompileAndRun(codigoFonte.text);
		}
	}
}
