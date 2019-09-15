using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class queen : MonoBehaviour
{

    Animator myAnimator;
    public GameObject levelcompletedPanel;
    void Start()
    {
        myAnimator = GetComponent<Animator>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colidiu");
        if (collision.gameObject.name == "king")
        {
            myAnimator.SetBool("queenSaved", true);
            levelcompletedPanel.SetActive(true);



        }
    }
}
