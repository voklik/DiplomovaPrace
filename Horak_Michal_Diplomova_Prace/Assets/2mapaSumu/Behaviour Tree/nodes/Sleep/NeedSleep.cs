using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NeedSleep : Node
{
    //Rozhoduje se, zda zv��e pot�ebuje sp�t
    public NeedSleep(Animal ai)
    {
        this.character = ai;
    }
    /// <summary>
    /// Zpracov�n� uzlu - sp� se, pokud pot�eba >70% maxim�ln� hodnoty
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

