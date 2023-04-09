using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticKindCoutner
{
    private string Kind;
    private int CountLive, CountDead;
    public StatisticKindCoutner(string kind, int countLive, int countdead)
    {
        Kind = kind;
        CountLive = countLive;
        CountDead = countdead;
    }
    public StatisticKindCoutner GetCopy()
    {
        return new StatisticKindCoutner(Kind, CountLive, CountDead);
    }
    public string GetKind() { return Kind; }
    public void SetText(string t) { Kind = t; }
    public int GetCountLive() { return CountLive; }
    public void SetCountLive(int n) { CountLive = n; }
    public void IncreaseCountLive() { CountLive += 1; }
    public int GetCountDead() { return CountDead; }
    public void SetCountDead(int n) { CountDead = n; }
    public void IncreaseCountDead() { CountDead += 1; }

    public void DecreaseCountDLive() { CountLive -= 1; }
    public void IDecreaseCountDead() { CountDead -= 1; }

}
