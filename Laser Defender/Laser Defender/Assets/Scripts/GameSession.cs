using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    //Serialized for debug purposes only
    [SerializeField] private int score = 0;

    private void Awake()
    {
        SetUpSingleton();             
    }


    public void AddToScore(int value)
    {
        score += value;
    }

    public int GetScore()
    {
        return score;
    }

    private void SetUpSingleton()
    {
        if (FindObjectsOfType<GameSession>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void Reset()
    {
        score = 0;
    }
}
