using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubjectView : MonoBehaviour
{
    public Text text;
    Subject subject;
    Canvas canvas;

    void Start()
    {
        text = GetComponent<Text>();        
    }

    public void setSubject(Subject subject)
    {
        this.text.text = subject.getName();
        this.subject = subject;
    }

    public void setCanvas(Canvas canvas)
    {
        this.canvas = canvas;
        gameObject.transform.SetParent(this.canvas.transform);
    }


    public void OpenThisSubject()
    {
        FindObjectOfType<ProgramController>().OpenSubject(subject);
    }


    
}
