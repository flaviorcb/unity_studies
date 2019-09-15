using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
   public void LoadLevelOne()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LoadOptions()
    {
        SceneManager.LoadScene("Options");
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene("StartScene");

    }

}
