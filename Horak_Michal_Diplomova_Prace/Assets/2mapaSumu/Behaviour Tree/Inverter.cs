using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inverter : Node
{//Typ uzlu, kter� obrac� �sp�ch na ne�sp�ch a opa�n�
    protected Node node; // Uzel, kter� obr�t�

    /// <summary>
    /// Konstruktor
    /// </summary>
    /// <param name="node">Uzel pro p�ehozen�</param>
    public Inverter(Node node)
    {
        this.node = node;
    }
    /// <summary>
    /// Zpracov�n� uzlu
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