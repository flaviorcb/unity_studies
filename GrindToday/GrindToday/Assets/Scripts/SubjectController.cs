using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubjectController : MonoBehaviour
{

    public InputField subjectText;
    Subjects subjects;

    private void Start()
    {
        subjects = FindObjectOfType<Subjects>();
        
    }

    public void SaveSubject()    {
        Subject subject = new Subject(subjectText.text);
        var db = new Database();
        db.SaveSubject(subject);
        subjects.LoadSubjectsViews();
        
    }

    public static Subject GetSubject(int idSubject) {
        var db = new Database();
        return db.GetSubject(idSubject);
    }
}
