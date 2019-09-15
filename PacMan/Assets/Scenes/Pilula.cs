using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilula : MonoBehaviour
{

    public AudioClip myAudio;
    public Camera myCamera;
    
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(myAudio, myCamera.transform.position);
    }
}
