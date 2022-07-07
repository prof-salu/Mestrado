using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Personagem : MonoBehaviour
{
    public bool ligarTeclado = false;
    public GameObject GameMaster;
    public float deslocamento = 2.2f;
    public float velocidade = 0.4f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (ligarTeclado)
        {
            ControlaTeclado();
        }        
    }

    public void ParaCima()
    {
        //transform.Translate(new Vector3(0, 0, deslocamento));
        transform.DOMoveZ(transform.position.z + deslocamento, velocidade);
    }

    public void ParaBaixo()
    {
        //transform.Translate(new Vector3(0, 0, -deslocamento));
        transform.DOMoveZ(transform.position.z - deslocamento, velocidade);
    }

    public void ParaDireita()
    {
        //transform.Translate(new Vector3(deslocamento, 0, 0));
        transform.DOMoveX(transform.position.x + deslocamento, velocidade);
    }

    public void ParaEsquerda()
    {
        //transform.Translate(new Vector3(-deslocamento, 0, 0));
        transform.DOMoveX(transform.position.x - deslocamento, velocidade);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Objetivo"))
        {
            Destroy(other.gameObject);
            GameMaster.GetComponent<ControlaUI>().Completou();
        }

        if (other.CompareTag("ZonaMorta"))
        {
            Destroy(other.gameObject);
            GameMaster.GetComponent<ControlaUI>().Perdeu();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ZonaMorta"))
        {
            GameMaster.GetComponent<ControlaUI>().Perdeu();
        }
    }

    private void ControlaTeclado()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ParaCima();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ParaBaixo();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ParaEsquerda();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ParaDireita();
        }
    }
}
