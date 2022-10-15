using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticKindCounterOverTime
{

    StatisticKindCoutner StatisticKindCoutner;
    string Time;

    public StatisticKindCounterOverTime(StatisticKindCoutner statisticKindCoutner, string time)
    {
        this.StatisticKindCoutner = statisticKindCoutner;
        this.Time = time;
    }
    public StatisticKindCoutner GetStatisticKindCoutner()
    { return StatisticKindCoutner; }
    public string  GetTime()
    { return Time; }
}
