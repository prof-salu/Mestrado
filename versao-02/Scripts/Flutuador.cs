using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flutuador : MonoBehaviour
{
    public float variacao = .3f;
    public float graus = 15f;
    public float frequencia = 1f;

    private Vector3 tempPos;
    private Vector3 posOffset;

    void Start()
    {
        posOffset = transform.position;
    }

    void Update()
    {
        transform.Rotate(new Vector3(0f, Time.deltaTime * graus, 0f), Space.World);

        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequencia) * variacao;

        transform.position = tempPos;
    }
}
