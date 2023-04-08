using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Sleep : Node
{//Uzel, který slouží pro spuštìní spánku, pøi splnìní požadavcích, nebo ukonèení probíhajícího spánku
    private NavMeshAgent agent;//Potøeba pro zastavení pohybu

    public Sleep(NavMeshAgent agent, Animal ai)
    {
        this.agent = agent;
        this.character = ai;
    }
    /// <summary>
    /// Zpracování uzlu. Spí se, dokud potøeba se nedostane pod 10% maximální hodnoty
    /// </summary>
    /// <returns></returns>
    public override NodeState Evaluate()
    {
        if (character.GetSleep() / character.GetSleepMax() < 0.10 && character.GetStav == Stav.Sleeping)
        {//Pokud charakter se dostal pod 10% procent potøeby spánku a na konci minulého cyklu Update spal, tak se ukonèí spánek 
            character.SetStav(Stav.Nothing);
            return NodeState.SUCCESS;
        }
        else
        {//Charakter jde spát
            character.Sleep();
            agent.isStopped = true;
            character.SetStav(Stav.Sleeping);
            return NodeState.RUNNING;
        }

    }
}
