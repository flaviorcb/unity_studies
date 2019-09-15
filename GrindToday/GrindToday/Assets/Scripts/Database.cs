using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class Database : ScriptableObject
{

    public void Start()
    {
        IDbConnection dbconn = GetConnection();

        IDbCommand dbcmd = dbconn.CreateCommand();

        string sqlQuery = "SELECT id, name from subject";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            string name = reader.GetString(1);
        }

        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }


    public IDbConnection GetConnection()
    {

        //Talvez eu tenha de colocar o banco de dados no diretorio raiz e usar a linha abaixo,
        //para não dar problemas nas diferentes plataformas, como android e ios.
        //string connection = "URI=file:" + Application.persistentDataPath + "/My_Database";
        string strConn = "URI=file:" + Application.dataPath + "/Database/db.db";
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(strConn);
        dbconn.Open();
        return dbconn;
    }


    public void SaveSubject(Subject sub)
    {
        var dbconn = GetConnection();
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sql = "insert into subject (name) values(\"" + sub.getName() + "\")";
        dbcmd.CommandText = sql;
        dbcmd.ExecuteNonQuery();
        dbconn.Close();
    }

    public Subject GetSubject(int idSubject)
    {
        var dbconn = GetConnection();
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sql = "select id,name from subject where id= " + idSubject;
        dbcmd.CommandText = sql;
        IDataReader reader = dbcmd.ExecuteReader();

        Subject result = null;

        if (reader.Read())
        {
            result = new Subject(reader.GetInt32(0), reader.GetString(1));
        }

        dbconn.Close();
        return result;
    }


    public void saveTimeEffort(TimeEffort timeEffort)
    {
        var dbconn = GetConnection();
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sql = "insert into timeEffort (idSubject, dateTime, timeAmount) values(" +
                    +timeEffort.IdSubject
                    + ", " + timeEffort.DateTime
                    + "," + timeEffort.TimeAmount
                    + ")";
        dbcmd.CommandText = sql;
        dbcmd.ExecuteNonQuery();
        dbconn.Close();
    }
}
