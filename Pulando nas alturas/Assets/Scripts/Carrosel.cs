using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrosel : MonoBehaviour
{

    [SerializeField]private VariavelCompartilhadaFloat velocidade;
    private Vector3 posicaoInicial;
    private float tamanhoRealDaImagem;

    private void Awake()
    {
        this.posicaoInicial = transform.position;
        float tamanhoDaImagem = GetComponent<SpriteRenderer>().size.x ;  // como pegar o tamanho da imagem através do SpriteRenderer
        float escala = this.transform.localScale.x;
        this.tamanhoRealDaImagem = tamanhoDaImagem * escala;
    }

    // Update is called once per frame
    void Update()
    {
        float deslocamento = Mathf.Repeat(this.velocidade.valor * Time.time, this.tamanhoRealDaImagem/2);
        this.transform.position = this.posicaoInicial + Vector3.left * deslocamento;
        
    }
}
