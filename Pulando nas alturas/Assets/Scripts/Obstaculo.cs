using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{

    [SerializeField] private VariavelCompartilhadaFloat velocidade;
    [SerializeField] private float variacaoDaPosicaoY = 1.5f;
    private bool pontuei = false;
    private Pontuacao pontuacao;

    private void Awake()
    {
        this.transform.Translate(Vector3.up * UnityEngine.Random.Range(-variacaoDaPosicaoY, variacaoDaPosicaoY));
    }

    private void Start()
    {
        pontuacao = FindObjectOfType<Pontuacao>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * this.velocidade.valor * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.CompareTag("parede") )
        {
            this.Destruir();
        }

    }

    public void Destruir()
    {
        Destroy(this.gameObject);
    }
}
