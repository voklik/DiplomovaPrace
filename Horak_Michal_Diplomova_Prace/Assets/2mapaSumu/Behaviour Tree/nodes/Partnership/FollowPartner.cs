using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPartner : Node
{
    private Animal character;
    private float range;



    public FollowPartner(Animal ai,float followRange)
    {

        this.character = ai;
        range = followRange;
    }



    public override NodeState Evaluate()
    {

      
        Stav laststav = character.getStav;
        character.setStav(Stav.FollowParty,false);
        GameObject followed = character.getTarget();
        if (followed != null)
        {
            if (Vector3.Distance(character.transform.position, followed.transform.position) > range)
            {
                character.setStav(Stav.FollowParty, true);
                character.Vypis("následuji" + followed.name);
                return NodeState.SUCCESS;
            }
            else {
                character.setAgentMovementEnabled(true);
                
                character.gameObject.GetComponent<NavMeshAgent>().isStopped = true;
                return NodeState.FAILURE; }
              
        }
        else {
            character.setStav(laststav,false);
            return NodeState.FAILURE; 
        }


    } }
