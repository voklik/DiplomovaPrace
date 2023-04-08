using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attack : Node
{//Uzel, kter� zp�sobuje c�ly zran�n�
    private NavMeshAgent agent;
    public Attack(NavMeshAgent agent, Animal ai)
    {
        this.agent = agent;
        this.character = ai;
    }
    /// <summary>
    /// Zpracov�n� uzlu - �tok na c�l
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
