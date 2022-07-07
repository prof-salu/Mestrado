using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlaUI : MonoBehaviour
{
    public GameObject telaScript;
    public GameObject telaVitoria;
    public GameObject telaDerrota;

    private Animator animator;
    private bool exibir;

    private void Awake()
    {
        animator = telaScript.GetComponent<Animator>();
    }

    private void Start()
    {
        exibir = false;
    }

    public void Interacao()
    {
        exibir = !exibir;
        animator.SetBool("exibir", exibir);
    }

    public void Completou()
    {
        telaVitoria.gameObject.SetActive(true);
    }

    public void Perdeu()
    {
        telaDerrota.gameObject.SetActive(true);
    }

    public void JogarNovamente()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ProximaFase()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
