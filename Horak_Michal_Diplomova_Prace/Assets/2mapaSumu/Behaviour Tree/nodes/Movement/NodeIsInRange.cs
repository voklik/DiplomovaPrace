using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeIsInRange : Node
{//Uzel, který rozhoduje, zda jsme se dostali k cíly
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
            return NodeState.SUCCESS;
        }
        else
        {
            return NodeState.FAILURE;
        }
    }
}
