using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticSystem : MonoBehaviour
{
    static List<Entity> ListOfEntit = new List<Entity>();
    static List<StatisticEvent> ListOfEvents = new List<StatisticEvent>();
    static List<StatisticKindCoutner> CounterOfKinds = new List<StatisticKindCoutner>();
    static List<StatisticKindCounterOverTime> CounterOverTimes= new List<StatisticKindCounterOverTime>();
    static float time = 0.0f;
    static int IDCounter = 0;
    private void Update()
    {
        time += Time.deltaTime;
    }
    
    public static void IAmLive(Entity entita)
    {
        bool founded = false;
        foreach (StatisticKindCoutner item in CounterOfKinds)
        {
            if (entita.GetKind().Equals(item.GetKind()))
            {
                founded = true;
                item.IncreaseCountLive();
                CounterOverTimes.Add(new StatisticKindCounterOverTime(item.GetCopy(), time.ToString()));
                break;
            }
        }
        if (founded == false)
        {
            CounterOfKinds.Add(new StatisticKindCoutner(entita.GetKind(), 1, 0));
        }
        ListOfEntit.Add(entita);
        CounterOverTimes.Add(new StatisticKindCounterOverTime(new StatisticKindCoutner(entita.GetKind(), 1, 0), time.ToString()));
    }
    public static void IAmDead(Entity entita)
    {
        bool founded = false;
        foreach (StatisticKindCoutner item in CounterOfKinds)
        {
            if (entita.GetKind().Equals(item.GetKind()))
            {
                founded = true;
                item.IncreaseCountDead();
                item.DecreaseCountDLive();
                CounterOverTimes.Add(new StatisticKindCounterOverTime(item.GetCopy(), time.ToString()));
                break;
            }
        }
        if (founded == false)
        {
            CounterOfKinds.Add(new StatisticKindCoutner(entita.GetKind(), 0,1));
            CounterOverTimes.Add(new StatisticKindCounterOverTime(new StatisticKindCoutner(entita.GetKind(), 0, 1), time.ToString()));

        }
        ListOfEntit.Remove(entita);
    }
    public static void AddStatisticEvent(StatisticEntity fromEntity, string thing)
    {
        StatisticEvent statisticEvent = new StatisticEvent(IDCounter++, thing, time.ToString(), fromEntity);
        ListOfEvents.Add(statisticEvent);
    }
    public static void AddStatisticEvent(StatisticEntity fromEntity, string thing, StatisticEntity targetEntity)
    {
        Debug.LogWarning("Event");
        StatisticEvent statisticEvent = new StatisticEvent(IDCounter++, thing, time.ToString(), fromEntity, targetEntity);
        ListOfEvents.Add(statisticEvent);
    }
    public static string StatisticEventLog()
    {
        string text = "";
        foreach (StatisticEvent item in ListOfEvents)
        {
          text+=item.ToString()+"\n";
        }
        return text;

    }
    public static string StatisticKindLog()
    {
        string text = "";
        foreach (StatisticKindCoutner item in CounterOfKinds)
        {
            text += item.GetKind() + " Live: " + item.GetCountLive() + " Dead: " + item.GetCountDead()+"\n"; 
        }
        return text;

    }
    public static string StatisticLiveAnimal()
    {
        string text = "";
        foreach (Entity item in ListOfEntit)
        {if (item is Animal)
              
            text += item.GetEntityInformation() + "\n\n";
        }
        return text;

    }
    public static string StatisticLivePlants()
    {
        string text = "";
        foreach (Entity item in ListOfEntit)
        {
            if (item is Plant)
                text += (item.GetEntityInformation() + "\n");
        }
        return text;

    }
    public static void DebugLogWriteAll()
    {
        foreach (StatisticEvent item in ListOfEvents)
        {
            Debug.LogError(item.ToString());
        }

    }

    public static List<ExportDataRow> ExportRowsKindsOverTime()
    {
        List<ExportDataRow> export = new List<ExportDataRow>();
        export.Add(new ExportDataRow(new List<string>() {"Time","Kind","Count of Lives", "Count of Deads" }));
        foreach (StatisticKindCounterOverTime item in CounterOverTimes)
        { List<string> columns = new List<string>();

            columns.Add(item.GetTime().ToString() + "#");
            columns.Add(item.GetStatisticKindCoutner().GetKind()+ "#");
            columns.Add(item.GetStatisticKindCoutner().GetCountLive().ToString() + "#");
            columns.Add(item.GetStatisticKindCoutner().GetCountDead().ToString());

            ExportDataRow row = new ExportDataRow(columns);
            export.Add(row);
        }

        return export;
    }
    public static List<ExportDataRow> ExportRowsKindsActual()
    {
        List<ExportDataRow> export = new List<ExportDataRow>();
        export.Add(new ExportDataRow(new List<string>() { "Kind", "Count of Lives", "Count of Deads" }));
        foreach (StatisticKindCoutner item in CounterOfKinds)
        {
            List<string> columns = new List<string>();


            columns.Add(item.GetKind() + "#");
            columns.Add(item.GetCountLive().ToString() + "#");
            columns.Add(item.GetCountDead().ToString());

            ExportDataRow row = new ExportDataRow(columns);
            export.Add(row);
        }

        return export;
    }
    public static List<ExportDataRow> ExportRowsAllLives()
    {//////////////////////////pozmìnit////////////////////////////
        List<ExportDataRow> export = new List<ExportDataRow>();
        export.Add(new ExportDataRow(new List<string>() {"Time", "Entity", "name", "Kind" }));
        foreach (StatisticKindCounterOverTime item in CounterOverTimes)
        {
            List<string> columns = new List<string>();

            columns.Add(item.GetTime().ToString() + "#");
            columns.Add(item.GetStatisticKindCoutner().GetKind() + "#");
            columns.Add(item.GetStatisticKindCoutner().GetCountLive().ToString() + "#");
            columns.Add(item.GetStatisticKindCoutner().GetCountDead().ToString());

            ExportDataRow row = new ExportDataRow(columns);
            export.Add(row);
        }

        return export;
    }
    public static List<ExportDataRow> ExportRowsEvents()
    {
        List<ExportDataRow> export = new List<ExportDataRow>();
        export.Add(new ExportDataRow(new List<string>() {"Time","ID","Event","From","Target"}));
        foreach (StatisticEvent item in ListOfEvents)
        {
            List<string> columns = new List<string>();


            columns.Add(item.GetTime() + "#");
            columns.Add(item.GetID() + "#");
            columns.Add(item.GetThing() + "#");
            columns.Add(item.GetFromEntity().ToString() + "#");
            columns.Add(item.GetTargetEntity().ToString());
           

            ExportDataRow row = new ExportDataRow(columns);
            export.Add(row);
        }

        return export;
    }
    public static float GetTime()
    {
        return time;
    }
}
