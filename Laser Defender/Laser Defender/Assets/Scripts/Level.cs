using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] private float delayInSeconds = 2f;

    public void LoadGameScene()
    {
        FindObjectOfType<GameSession>().Reset();
        SceneManager.LoadScene("Game");
    }

    public void LoadStarScene()
    {
        FindObjectOfType<GameSession>().Reset();
        SceneManager.LoadScene("Start Menu");
    }

    internal void LoadGameOverScene()
    {
        StartCoroutine(WaitAndLoad());

    }

    private IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("Game Over");
    }
}
