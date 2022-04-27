using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{
    public GameObject GameMaster;
    public float deslocamento = 2.1f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)){
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

    private void ParaCima()
    {
        transform.Translate(new Vector3(0, 0, deslocamento));
    }

    private void ParaBaixo()
    {
        transform.Translate(new Vector3(0, 0, -deslocamento));
    }

    private void ParaDireita()
    {
        transform.Translate(new Vector3(deslocamento, 0, 0));
    }

    private void ParaEsquerda()
    {
        transform.Translate(new Vector3(-deslocamento, 0, 0));
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
}
