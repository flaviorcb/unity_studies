using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text lifeText;
    // Start is called before the first frame update
    
    public void ChangeLife(int value)
    {
        lifeText.text = "Heath: " + value;
    }

    public void ChangeScore(int value)
    {
        scoreText.text =  value +  "";
    }

}
