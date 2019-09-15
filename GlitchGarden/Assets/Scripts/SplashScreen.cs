using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    [SerializeField]private float dalySplashScreen = 3f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Go());
        
    }

    private IEnumerator Go()
    {
        yield return new WaitForSeconds(dalySplashScreen);
        SceneManager.LoadScene("StartScene");

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
