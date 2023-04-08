using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NeedSleep : Node
{
    //Rozhoduje se, zda zvíøe potøebuje spát
    public NeedSleep(Animal ai)
    {
        this.character = ai;
    }
    /// <summary>
    /// Zpracování uzlu - spí se, pokud potøeba >70% maximální hodnoty
    /// </summary>
    /// <returns></returns>
    public override NodeState Evaluate()
    {
        if ((character.GetSleep() / character.GetSleepMax() > 0.7) || (character.GetSleep() / character.GetSleepMax() > 0.1 && character.GetStav == Stav.Sleeping))
        {
            character.SetStav(Stav.Sleeping);
            return NodeState.SUCCESS;
        }
        else
        {
            if (character.GetStav == Stav.Sleeping && character.GetSleep() / character.GetSleepMax() <= 0.1)
                character.SetStav(Stav.Nothing);
            return NodeState.FAILURE;
        }
    }
}

