using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPartnerUnderAttack : Node
{//Uzel, kter� oznamuje, �e partner je pod �tokem.
    public IsPartnerUnderAttack(Animal ai)
    {
        this.character = ai;
    }

    public override NodeState Evaluate()
    {
        GameObject enemy = character.getAttackingPartnerClosestEntity();
        if (enemy != null)
        {
            return NodeState.SUCCESS;
        }
        else
            return NodeState.FAILURE;

    }
}
