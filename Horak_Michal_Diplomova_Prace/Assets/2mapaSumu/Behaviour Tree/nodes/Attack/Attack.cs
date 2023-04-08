using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attack : Node
{//Uzel, který zpùsobuje cíly zranìní
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
            return NodeState.FAILURE;
        }
        target.TakeDMG(character.getStrenght());
        agent.isStopped = true;
        return NodeState.SUCCESS;
    }
}
