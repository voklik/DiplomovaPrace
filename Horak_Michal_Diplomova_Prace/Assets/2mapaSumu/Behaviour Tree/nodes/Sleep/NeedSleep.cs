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
        if ((character.getSleep() / character.getSleepMax() > 0.7) || (character.getSleep() / character.getSleepMax() > 0.1 && character.getStav == Stav.Sleeping))
        {
            character.setStav(Stav.Sleeping);
            return NodeState.SUCCESS;
        }
        else
        {
            if (character.getStav == Stav.Sleeping && character.getSleep() / character.getSleepMax() <= 0.1)
                character.setStav(Stav.Nothing);
            return NodeState.FAILURE;
        }
    }
}

