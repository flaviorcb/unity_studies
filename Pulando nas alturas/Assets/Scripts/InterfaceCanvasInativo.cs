using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceCanvasInativo : MonoBehaviour
{
    [SerializeField]private GameObject fundo;
    private Canvas canvas;
    [SerializeField]private Text texto;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
    }

    public void Ativar(Camera camera)
    {
        fundo.SetActive(true);
        canvas.worldCamera = camera;
    }

    public void AtualizarTexto(int pontosParaReviver)
    {
        this.texto.text = pontosParaReviver.ToString();

    }

    public void Desativar()
    {
        fundo.SetActive(false);
    }
}
