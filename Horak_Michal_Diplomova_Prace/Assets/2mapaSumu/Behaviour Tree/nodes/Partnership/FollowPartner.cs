using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPartner : Node
{
    private float range;

    public FollowPartner(Animal ai, float followRange)
    {
        this.character = ai;
        range = followRange;
    }

    public override NodeState Evaluate()
    {


        Stav laststav = character.GetStav;
        character.SetStav(Stav.FollowParty, false);
        GameObject followed = character.GetTarget();
        if (followed != null)
        {
            if (Vector3.Distance(character.transform.position, followed.transform.position) > range)
            {
                character.SetStav(Stav.FollowParty, true);
                return NodeState.SUCCESS;
            }
            else
            {
                character.SetAgentMovementEnabled(true);
                character.gameObject.GetComponent<NavMeshAgent>().isStopped = true;
                return NodeState.FAILURE;
            }

        }
        else
        {
            character.SetStav(laststav, false);
            return NodeState.FAILURE;
        }


    }
}
