using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceGameOver : MonoBehaviour
{
    [SerializeField] private Text valorRecorde;
    [SerializeField] private GameObject imagemGameOver;
    private Pontuacao pontuacao;
    private int recorde;
    [SerializeField] private Image posicaoMedalha;
    [SerializeField] private Sprite medalhaDeOuro;
    [SerializeField] private Sprite medalhaDePrata;
    [SerializeField] private Sprite medalhaDeBronze;


    private void Start()
    {
        pontuacao = FindObjectOfType<Pontuacao>();
    }

    public void MostrarInterface()
    {
        AtualizarInterfaceGrafica();
        this.imagemGameOver.SetActive(true);
    }

    public void EsconderInterface()
    {
        this.imagemGameOver.SetActive(false);
    }

    private void AtualizarInterfaceGrafica()
    {
        this.recorde = PlayerPrefs.GetInt("recorde");
        valorRecorde.text = recorde.ToString();
        VerificarCorMedalha();
    }

    private void VerificarCorMedalha()
    {
        if (this.pontuacao.Pontos > this.recorde - 2)
        {
            this.posicaoMedalha.sprite = this.medalhaDeOuro;
        }
        else if (this.pontuacao.Pontos > this.recorde / 2)
        {
            this.posicaoMedalha.sprite = this.medalhaDePrata;

        }
        else
        {
            this.posicaoMedalha.sprite = this.medalhaDeBronze;

        }

    }
}
