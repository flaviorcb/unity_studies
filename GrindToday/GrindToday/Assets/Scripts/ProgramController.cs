using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgramController : MonoBehaviour
{

    static int idSubjectSelected;

    private void Awake()
    {
        SetupSingleton();
    }

    private void SetupSingleton()
    {
        if (FindObjectsOfType<ProgramController>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void OpenSubject(Subject subject)
    {
        
        Debug.Log("OpenSubject");
        idSubjectSelected = subject.GetId();
        SceneManager.LoadScene(1);
    }

    public Subject GetSubject()
    {
        Subject subject = SubjectController.GetSubject(idSubjectSelected);
        return subject;
    }

    public void LoadMainScene()
    {
        Debug.Log("LoadMainScene");
        SceneManager.LoadScene(0);
    }
}
