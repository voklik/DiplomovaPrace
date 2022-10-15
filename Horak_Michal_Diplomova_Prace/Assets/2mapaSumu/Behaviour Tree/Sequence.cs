using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Sequence : Node
{
    /*
     *Typ Uzly, kter� obsahuje seznam uzl�. Prov�d� se postupn� jedna �innost za druhou.
     *Pokude se vr�t� Ne�sp�ch ze seznamu uzl�, p�i zpracov�n�, tak cel� sekvence vr�t� Ne�sp�ch
      */
    protected List<Node> nodes = new List<Node>();//List s uzly
    /// <summary>
    /// Konstruktor
    /// </summary>
    /// <param name="_id">Pro Debugovac� ��ely</param>
    /// <param name="nodes">Seznam uzl�</param>
    public Sequence(int _id, List<Node> nodes)
    {
        id = _id;
        original_id = id;
        this.nodes = nodes;
    }
    /// <summary>
    /// Konstruktor
    /// </summary>
    /// <param name="_nick">Pro Debugovac� ��ely</param>
    /// <param name="_id">Pro Debugovac� ��ely</param>
    /// <param name="nodes">Seznam uzl�</param>
    public Sequence(string _nick, int _id, List<Node> nodes)
    {
        nick = _nick;
        id = _id;
        original_id = id;
        this.nodes = nodes;
    }
    /// <summary>
    /// Konstruktor
    /// </summary>
    /// <param name="nodes">Seznam s Uzly</param>
    public Sequence(List<Node> nodes)
    {
        id = 100;
        original_id = 100;
        this.nodes = nodes;
    }

    //Zpracovani Uzlu
    public override NodeState Evaluate()
    {
        bool isAnyNodeRunning = false;
        foreach (var node in nodes)
        {
            switch (node.Evaluate())
            {
                case NodeState.RUNNING:
                    isAnyNodeRunning = true;
                    _nodeState = NodeState.RUNNING;
                    return _nodeState;
                    break;
                case NodeState.SUCCESS:
                    break;
                case NodeState.FAILURE:
                    _nodeState = NodeState.FAILURE;
                    return _nodeState;
                default:
                    break;
            }
        }
        _nodeState = isAnyNodeRunning ? NodeState.RUNNING : NodeState.SUCCESS;
        return _nodeState;
    }


}