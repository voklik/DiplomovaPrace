using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeIsInRange : Node
{//Uzel, kter� rozhoduje, zda jsme se dostali k c�ly
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
            return NodeState.SUCCESS;
        }
        else
        {
            return NodeState.FAILURE;
        }
    }
}
