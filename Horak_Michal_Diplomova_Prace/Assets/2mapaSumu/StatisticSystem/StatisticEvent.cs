using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticEvent
{
    StatisticEntity FromEntity, TargetEntity;
    string Time;
    string Thing;
    int ID;

    public StatisticEntity GetFromEntity() { return FromEntity; }
    public StatisticEntity GetTargetEntity() { return TargetEntity; }
    public string GetTime() { return Time; }
    public string GetThing() { return Thing; }
    public int GetID() { return ID; }

    public StatisticEvent(int iD, string thing, string time, StatisticEntity fromEntity, StatisticEntity targetEntity)
    {
        ID = iD;
        Thing = thing;
        Time = time;
        FromEntity = fromEntity;
        TargetEntity = targetEntity;
    }
    public StatisticEvent(int iD, string thing, string time, StatisticEntity fromEntity)
    {
        ID = iD;
        Thing = thing;
        Time = time;
        FromEntity = fromEntity;
        TargetEntity = null;
       
    }

    public override string ToString()
    {
        string text = "";
        text += "ID ( " + ID + " ) ";
        text += "Time ( " + Time + " ) ";
        text += "From ( " + FromEntity.ToString() + " ) ";
        text += "Thing ( " + Thing + " ) ";
        if (TargetEntity!=null)
        { text += "Target ( " + TargetEntity.ToString() + " ) "; }

        return text;
    }

    public string getExcelRow()
    {
        return "Excel statistic default null";
    }
}
