using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Eat : Node
{//Uzel, kter� sni�uje hladinu hladu
    private NavMeshAgent agent;

    public Eat(NavMeshAgent agent, Animal ai)
    {
        this.agent = agent;
        this.character = ai;
    }
    /// <summary>
    /// Zpracov�n� uzlu, kdy se j�,  dokud hladn nen� pod 10%
    /// </summary>
    /// <returns></returns>
    public override NodeState Evaluate()
    {
        if (character.GetHunger() / character.GetHugerMax() < 0.1 && character.GetStav == Stav.Eating)
        {//Pokud se Zv��e dostalo pod 10% pot�eby hladu a v minul�m cyklu Update se jedlo, tak se p�estane j�st
            agent.isStopped = true;
            character.SetStav(Stav.Nothing);
            return NodeState.SUCCESS;
        }
        else
        {//Pokra�uje se v j�dle
            if ((character.GetHunger() / character.GetHugerMax() > 0.1 && character.GetStav == Stav.Eating))
            {
                character.Eat(character.GetFoodTarget());
                character.SetStav(Stav.Eating);
                if (character.GetHunger() / character.GetHugerMax() < 0.1 && character.GetStav == Stav.Eating)
                {
                    character.SetStav(Stav.Nothing);
                    return NodeState.SUCCESS;
                }
                return NodeState.RUNNING;
            }
            else return NodeState.FAILURE;
        }
    }
}
