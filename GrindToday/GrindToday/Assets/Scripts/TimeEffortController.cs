using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeEffortController
{
    
    public void saveTimeEffort(TimeEffort timeEffort)
    {
        var db = new Database();
        db.saveTimeEffort(timeEffort);
    }


    public void timeEffort(Subject subject, float timeAmount)
    {
        Subject subject = 
        TimeEffort te = new TimeEffort(subject.GetId(), 
            );
    }
}
