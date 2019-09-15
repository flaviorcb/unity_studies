using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;

public class Subjects : MonoBehaviour
{
    public Transform intialPosition;
    public SubjectView subjectViewPrefab;
    public int columns = 4;
    public int subjectWidth = 200;
    public int subjectHeight = 200;
    private int actualLine = 0;
    private int actualColumn = 0;
    public float widthOffSet = 10;
    public float heightOffSet = 10;

    public Canvas canvas;

    void Start()
    {
        LoadSubjectsViews();

    }

    public void LoadSubjectsViews()
    {

        deleteOldSubjecsOnScreen();
        var db = new Database();
        var connection = db.GetConnection();

        IDbCommand dbcmd = connection.CreateCommand();

        string sqlQuery = "SELECT id, name from subject";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            string name = reader.GetString(1);
            Subject subject = new Subject(id, name);
            CreateSubjectView(subject);
        }

        connection.Close();
    }

    private void deleteOldSubjecsOnScreen()
    {
        var subs = FindObjectsOfType<SubjectView>();
        Debug.Log("tamanho: " + subs.Length);
        foreach (var sub in subs)
        {
            Destroy(sub.gameObject);
        }
        actualColumn = 0;
        actualLine = 0;
    }

    private void CreateSubjectView(Subject subject)
    {
        Vector3 position = getActualPosition();

        SubjectView sv = Instantiate(subjectViewPrefab, position, Quaternion.identity);
        sv.setSubject(subject);
        sv.setCanvas(canvas);

    }

    private Vector3 getActualPosition()
    {
        Vector3 result = intialPosition.position;

        result.x = result.x + subjectWidth * actualColumn + widthOffSet * actualColumn;
        result.y = result.y - subjectHeight * actualLine - heightOffSet;

        if (actualColumn == columns-1) actualLine += 1;
        actualColumn = (actualColumn + 1) % columns;

        return result;
    }


}
