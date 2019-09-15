using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{

    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] int numberOfAttackers = 0;
    bool levelTimerFinished = false;



    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);

    }

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerKilled()
    {
        numberOfAttackers--;
        if (numberOfAttackers <= 0 && levelTimerFinished)
        {
            StartCoroutine(FindObjectOfType<LevelController>().HandleWinCondition());
        }
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    internal void HandleTimerFinished()
    {
        if (FindObjectOfType<HealthDisplay>().GetHealthPoints() > 0)
        {
            StartCoroutine(FindObjectOfType<LevelController>().HandleWinCondition());
        }
        else //You lose
        {


        }
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawners)
        {
            spawner.StopSpawning();
        }
    }

    public IEnumerator HandleWinCondition()
    {
        StopSpawners();
        if (winLabel)
        {
            winLabel.SetActive(true);
        }
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("StartScene");
    }

    public void HandleLoseCondition()
    {
        StopSpawners();
        Time.timeScale = 0;
        loseLabel.SetActive(true);
    }


    public void LoadStarScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScene");
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
