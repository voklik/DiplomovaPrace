using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeIsInRange : Node
{//Uzel, který rozhoduje, zda jsme se dostali k cíly
    private Animal character;
    private float range;//Vzdálenost na uznání,že jsme u cíle
    public NodeIsInRange(Animal ai, float _range)
    {
        this.character = ai;
        range = _range;
    }
    /// <summary>
    /// Zpracování uzlu - Jsme u cíle ?
    /// </summary>
    /// <returns></returns>
    public override NodeState Evaluate()
    {
        if (character.IsInCollisionWith(character.getTarget()))
        {
            character.Vypis("yes0"); //TODO SMAZAT
            return NodeState.SUCCESS;
        }
        else
        {
            character.Vypis("no0"); //TODO SMAZAT
            return NodeState.FAILURE;
        }
        //float distance = character.getDistanceToTarget(); //TODO SMAZAT
        //if (distance != -1)
        //{
        //    if (distance <= range && distance >=0)
        //    {
        //        character.Vypis("in range");
        //        //character.setAgentMovementEnabled(true);
        //        // if (character.getStav != Stav.Attacking)
        //        //     character.stavNext();
        //        return NodeState.SUCCESS;
        //    }
        //    else
        //    {
        //        character.Vypis("not in range");
        //        return NodeState.FAILURE;
        //    }
        //}
        //else
        //{
        //    character.Vypis("null not in range");
        //    return NodeState.FAILURE;
        //}
        // return distance <= range ? NodeState.SUCCESS : NodeState.FAILURE; //TODO SMAZAT
    }
}
