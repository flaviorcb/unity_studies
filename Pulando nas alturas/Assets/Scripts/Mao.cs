using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mao : MonoBehaviour
{

    private SpriteRenderer minhaImagem;
    // Start is called before the first frame update
    void Start()
    {
        minhaImagem = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            EsconderMao();
        }
        
    }

    public void EsconderMao()
    {
        minhaImagem.enabled = false;
    }

    public void MostrarMao()
    {
        minhaImagem.enabled = true;
    }
}
