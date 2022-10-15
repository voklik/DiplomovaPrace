using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeIsInRange : Node
{//Uzel, kter� rozhoduje, zda jsme se dostali k c�ly
    private Animal character;
    private float range;//Vzd�lenost na uzn�n�,�e jsme u c�le
    public NodeIsInRange(Animal ai, float _range)
    {
        this.character = ai;
        range = _range;
    }
    /// <summary>
    /// Zpracov�n� uzlu - Jsme u c�le ?
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
