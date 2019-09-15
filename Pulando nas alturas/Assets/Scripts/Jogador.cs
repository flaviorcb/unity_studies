using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    private Carrosel[] carrosels;
    private GeradorDeObstaculos geradorDeObstaculo;
    private Player aviao;
    private bool estouMorto = false;

    private void Start()
    {
        carrosels = this.GetComponentsInChildren<Carrosel>();
        geradorDeObstaculo = this.GetComponentInChildren<GeradorDeObstaculos>();
        aviao = GetComponent<Player>();
    }

    public void Desativar()
    {
        estouMorto = true;
        geradorDeObstaculo.Parar();

        foreach (Carrosel carrosel in carrosels)
        {
            carrosel.enabled = false;
        }

    }

    public void Ativar()
    {

        if (estouMorto)
        {
            aviao.Reiniciar();
            geradorDeObstaculo.Recomecar();
            foreach (Carrosel carrosel in carrosels)
            {
                carrosel.enabled = true;
            }
            estouMorto = false;

        }
    }
}
