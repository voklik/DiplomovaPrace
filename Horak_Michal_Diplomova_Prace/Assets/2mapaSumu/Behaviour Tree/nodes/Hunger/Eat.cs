using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Eat : Node
{//Uzel, který snižuje hladinu hladu
    private Animal character;
    private NavMeshAgent agent;

    public Eat(NavMeshAgent agent, Animal ai)
    {
        this.agent = agent;
        this.character = ai;
    }
    /// <summary>
    /// Zpracování uzlu, kdy se jí,  dokud hladn není pod 10%
    /// </summary>
    /// <returns></returns>
    public override NodeState Evaluate()
    {
        if (character.getHunger() / character.getHugerMax() < 0.1 && character.getStav == Stav.Eating)
        {//Pokud se Zvíøe dostalo pod 10% potøeby hladu a v minulém cyklu Update se jedlo, tak se pøestane jíst
            agent.isStopped = true;
            character.setStav(Stav.Nothing);
            return NodeState.SUCCESS;
        }
        else
        {//Pokraèuje se v jídle
            if ((character.getHunger() / character.getHugerMax() > 0.1 && character.getStav == Stav.Eating))
            {
                character.Vypis("Food  Jím"); //TODO SMAZAT
                character.Eat(character.getFoodTarget());
                character.setStav(Stav.Eating);
                if (character.getHunger() / character.getHugerMax() < 0.1 && character.getStav == Stav.Eating)
                {
                    character.setStav(Stav.Nothing);
                    return NodeState.SUCCESS;
                }
                return NodeState.RUNNING;
            }
            else return NodeState.FAILURE;
        }
    }
}
