using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBetweenScenes 
{
    public static Subject subject;
    
    public static Subject GetActualSubject()
    {
        return subject;
    }

    public static void SetActualSubject(Subject subject)
    {
        DataBetweenScenes.subject = subject;
    }
    
}
