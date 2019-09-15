using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diretor : MonoBehaviour
{

    [SerializeField] private Player player;
    [SerializeField] private InterfaceGameOver interfaceGameOver;

    private Pontuacao pontuacao;



    protected virtual void Start()
    {
        pontuacao = FindObjectOfType<Pontuacao>();
        interfaceGameOver = FindObjectOfType<InterfaceGameOver>();
        player = FindObjectOfType<Player>();
    }

    public void FinalizarJogo()
    {
        Time.timeScale = 0;
        pontuacao.SalvarRecorde();
        this.interfaceGameOver.MostrarInterface();


    }

    public virtual void ReiniciarJogo()
    {
        this.interfaceGameOver.EsconderInterface();
        Time.timeScale = 1;
        this.player.Reiniciar();
        this.DestruirObstaculos();
        this.pontuacao.Reiniciar();

    }

    private void DestruirObstaculos()
    {
        var obstaculos = FindObjectsOfType<Obstaculo>();
        foreach (var ob in obstaculos)
        {
            ob.Destruir();
        }

    }
}
