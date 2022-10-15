using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attack : Node
{//Uzel, který zpùsobuje cíly zranìní
    private Animal character;
    private NavMeshAgent agent;
    public Attack(NavMeshAgent agent, Animal ai)
    {
        this.agent = agent;
        this.character = ai;
    }
    /// <summary>
    /// Zpracování uzlu - útok na cíl
    /// </summary>
    /// <returns></returns>
    public override NodeState Evaluate()
    {
        Entity target = character.getFoodTarget();
        if (target == null)
        {
            character.Vypis("Food Utoèim null"); //TODO SMAZAT
            return NodeState.FAILURE;
        }
        character.Vypis("Food Utoèim" + target.name); //TODO SMAZAT
        character.Vypis("Food Utoèim"); //TODO SMAZAT
        target.TakeDMG(character.getStrenght());
        agent.isStopped = true;
        //      character.setStav(Stav.Attacking);
        //waiter(attackcooldown)
        return NodeState.SUCCESS;
    }
}
