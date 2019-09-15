using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDeDificuldade : MonoBehaviour
{
    private float tempoPassado = 0;
    [SerializeField] private float tempoParaDificuldadeMaxima;
    public float Dificuldade { get; private set; }
    void Update()

    {
        tempoPassado += Time.deltaTime;
        this.Dificuldade = tempoPassado / tempoParaDificuldadeMaxima;
        this.Dificuldade = Mathf.Min(1, Dificuldade);
        
    }
}
