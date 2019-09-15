using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] Text scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Pontos: " + FindObjectOfType<GameSession>().GetScore() +  "";

        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(2, 2, 0));
        
    }

  
}
