using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeEffort 
{
    int id;
    int idSubject;
    string dateTime;
    float timeAmount;

    public int Id { get => id; set => id = value; }
    public int IdSubject { get => idSubject; set => idSubject = value; }
    public string DateTime { get => dateTime; set => dateTime = value; }
    public float TimeAmount { get => timeAmount; set => timeAmount = value; }

    public TimeEffort(int id, int idSubject, string dateTime, float timeAmount)
    {
        this.Id = id;
        this.IdSubject = idSubject;
        this.DateTime = dateTime;
        this.TimeAmount = timeAmount;
    }

    public TimeEffort(int idSubject, string dateTime, float timeAmount)
    {
        this.IdSubject = idSubject;
        this.DateTime = dateTime;
        this.TimeAmount = timeAmount;
    }
}
