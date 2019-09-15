using System;

public class Subject
{
    int id;
    string name;
        
    public Subject(string name)
    {
        this.name = name;
    }

    public Subject(int id, string name)
    {
        this.id = id;
        this.name = name;
    }

    public string getName()
    {
        return this.name;
    }

    public int GetId()
    {
        return id;
    }
}