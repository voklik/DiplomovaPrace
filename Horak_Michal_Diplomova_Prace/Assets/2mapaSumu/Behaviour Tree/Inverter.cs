using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inverter : Node
{//Typ uzlu, který obrací úspìch na neúspìch a opaènì
    protected Node node; // Uzel, který obrátí

    /// <summary>
    /// Konstruktor
    /// </summary>
    /// <param name="node">Uzel pro pøehození</param>
    public Inverter(Node node)
    {
        this.node = node;
    }
    /// <summary>
    /// Zpracování uzlu
    /// </summary>
    /// <returns></returns>
    public override NodeState Evaluate()
    {
        switch (node.Evaluate())
        {
            case NodeState.RUNNING:
                _nodeState = NodeState.RUNNING;

                break;
            case NodeState.SUCCESS:
                _nodeState = NodeState.FAILURE;
                break;
            case NodeState.FAILURE:
                _nodeState = NodeState.SUCCESS;
                break;
            default:
                break;
        }
        return _nodeState;
    }
}