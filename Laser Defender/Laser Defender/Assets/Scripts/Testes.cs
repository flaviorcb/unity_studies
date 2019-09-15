using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(foo());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator foo()
    {
        Debug.Log("Oi");
        yield return new WaitForSeconds(3);
        Debug.Log("Oi, after 3 seconds");

    }

    
}
