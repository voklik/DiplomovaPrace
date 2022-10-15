using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticEntity
{

    string Name, Kind;

    public StatisticEntity(string name, string kind)
    {
        Name = name;
        Kind = kind;
    }

    public override string ToString()
    {
        return Kind + " / " + Name;
    }

    public string GetName() { return Name; }
    public string GetKind() { return Kind; }
}
