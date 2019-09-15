using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{

    private Rigidbody2D fisica;
    [SerializeField] private float forca = 10;
    public float maxVelocity = 2;
    //private Diretor diretor;
    private Vector3 posicaoInicial;
    private bool deveImpulsionar = false;
    private Animator animacao;
    [SerializeField] private UnityEvent aoBater;
    private Pontuacao pontuacao;

    public void DarImpulso()
    {
            this.deveImpulsionar = true;
            animacao.SetFloat("VelocidadeY", fisica.velocity.y);
    }

    // Start is called before the first frame update
    void Start()
    {
        fisica = GetComponent<Rigidbody2D>();
        //diretor = FindObjectOfType<Diretor>();
        this.posicaoInicial = this.transform.position;
        animacao = GetComponent<Animator>();
        pontuacao = FindObjectOfType<Pontuacao>();
    }

    public void Ativar()
    {
        Reiniciar();
    }

    private void FixedUpdate()
    {


        if (this.deveImpulsionar)
        {
            this.Impulsionar();

        }



    }

    private void Impulsionar()
    {
        this.fisica.velocity = Vector2.zero;
        fisica.AddForce(Vector2.up * this.forca, ForceMode2D.Impulse);
        this.deveImpulsionar = false;

    }

    private void OnCollisionEnter2D(Collision2D colisao)
    {
        this.fisica.simulated = false;
        //this.diretor.FinalizarJogo();
        aoBater.Invoke();

    }

    public void Reiniciar()
    {
        this.transform.position = this.posicaoInicial;
        this.fisica.simulated = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        pontuacao.AdicionarPontos();
        
    }
}

