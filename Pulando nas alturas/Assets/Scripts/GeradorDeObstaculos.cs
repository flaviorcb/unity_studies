using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeObstaculos : MonoBehaviour
{
    [SerializeField]private float tempoParaGerarFacil = 4;
    [SerializeField]private float tempoParaGerarDificil = 2;
    private float cronometro;
    [SerializeField] private GameObject prefab;
    private ControleDeDificuldade controleDeDificuldade;
    private bool parado = false;

    private void Awake()
    {
        this.cronometro = this.tempoParaGerarFacil;
    }

    internal void Parar()
    {

        parado = true;
    }

    internal void Recomecar()
    {
        parado = false;
    }


    // Start is called before the first frame update
    void Start()
    {
        controleDeDificuldade = FindObjectOfType<ControleDeDificuldade>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.parado) return;
        this.cronometro -= Time.deltaTime;
        if(this.cronometro < 0)
        {
            Instantiate(prefab, this.transform.position, Quaternion.identity);
            float dificuldade = controleDeDificuldade.Dificuldade;
            this.cronometro = Mathf.Lerp(tempoParaGerarFacil, tempoParaGerarDificil, dificuldade);
        }
        
    }
}
