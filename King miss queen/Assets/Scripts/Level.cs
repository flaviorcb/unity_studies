using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public Animator cageAnimator;
    public AnimationClip cageAnimation;
    public GameObject levelCompletedPanel;

    void Update()
    {
        pawn[] pawns = FindObjectsOfType<pawn>();
        if (pawns.Length <= 0)
        {
            OpenCage();
        }

    }

    private void OpenCage()
    {
        cageAnimator.SetBool("levelClean", true);
        cageAnimator.gameObject.SetActive(false);

    }

    private void LevelComplete()
    {
        levelCompletedPanel.SetActive(true);

    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }


}
