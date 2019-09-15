using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AtivarJogador : MonoBehaviour
{

    [SerializeField] private UnityEvent aoTerminarAnimacaoTexto;

    public void AtivarJogadores()
    {
        aoTerminarAnimacaoTexto.Invoke();

    }
}
