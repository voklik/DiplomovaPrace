using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attack : Node
{//Uzel, kter� zp�sobuje c�ly zran�n�
    private Animal character;
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
            character.Vypis("Food Uto�im null"); //TODO SMAZAT
            return NodeState.FAILURE;
        }
        character.Vypis("Food Uto�im" + target.name); //TODO SMAZAT
        character.Vypis("Food Uto�im"); //TODO SMAZAT
        target.TakeDMG(character.getStrenght());
        agent.isStopped = true;
        //      character.setStav(Stav.Attacking);
        //waiter(attackcooldown)
        return NodeState.SUCCESS;
    }
}
