using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Pontuacao : MonoBehaviour
{
    public int Pontos { get; private set; }
    [SerializeField] private Text textoPontuacao;
    private AudioSource audioSource;
    [SerializeField] private UnityEvent aoPontuar;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void AdicionarPontos()
    {
        Pontos += 1;
        textoPontuacao.text = Pontos + "";
        audioSource.Play();
        this.aoPontuar.Invoke();
    }

    public void Reiniciar()
    {
        Pontos = 0;
        textoPontuacao.text = Pontos + "";
    }

    public void SalvarRecorde()
    {
        int pontuacaoAtual = PlayerPrefs.GetInt("recorde");
        if (this.Pontos > pontuacaoAtual)
        {
            PlayerPrefs.SetInt("recorde", this.Pontos);

        }
        Debug.Log(PlayerPrefs.GetInt("recorde"));
    }
}
