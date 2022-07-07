using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradosDeBlocos : MonoBehaviour
{
    public GameObject bloco;

    public Vector3 posInicial;
    public float margenLateral;
    public float margenVertical;
    
    private Vector3 posicao;

    void Start()
    {
        posicao = posInicial;
        for(int i = 0; i < 7; i++)
        {
            posicao.x = posInicial.x;
            for(int j = 0; j < 9; j++)
            {
                Instantiate(bloco, posicao, Quaternion.identity, transform);
                posicao.x += margenLateral;
            }
            posicao.z += margenVertical;
        }
    }

   
}
