using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Selector : Node
{
    /*
     *Typ Uzlu,kter� p�i zpracov�n� proch�z� v�tve uzl� v listu nodes. 
     *Pokud proch�zen� v�tev vr�t� False, tak se p�ejde k dal�� v�tvi. Pokud u� nejsou v�tve, tak Selector vr�t� Ne�sp�ch.
     * Pokud V�tev vr�t� �sp�ch, �i Prob�haj�c�, tak se tento stav vr�t� (returne)
     */

    protected List<Node> nodes = new List<Node>();//List s uzly
    /// <summary>
    /// Konsturkotr
    /// </summary>
    /// <param name="_id">Pro Debugovac� ��ely</</param>
    /// <param name="nodes">Seznam uzl�</param>
    public Selector(int _id, List<Node> nodes)
    {
        id = _id;
        original_id = id;
        this.nodes = nodes;
    }
    /// <summary>
    /// Konstuktor
    /// </summary>
    /// <param name="nodes">Seznam s uzly</param>
    public Selector(List<Node> nodes)
    {
        id = 100;
        original_id = 100;
        this.nodes = nodes;
    }
    //Zpracov�n� uzlu
    public override NodeState Evaluate()
    {
        foreach (var node in nodes)
        {
            switch (node.Evaluate())
            {
                case NodeState.RUNNING:
                    _nodeState = NodeState.RUNNING;
                    id = node.GetID;
                    if (original_id == 0)
                        SwitchOnFirstPlace();
                    return _nodeState;
                case NodeState.SUCCESS:
                    id = original_id;
                    if (original_id == 0)
                        switchBackOnPlace();
                    _nodeState = NodeState.SUCCESS;
                    return _nodeState;
                case NodeState.FAILURE:
                    break;
                default:
                    break;
            }
        }
        _nodeState = NodeState.FAILURE;
        return _nodeState;
    }
    /// <summary>
    /// Prohod� se pozice "chov�n�" na prvn� pozici. Toto je z tohot d�vodu, aby se �innost v�dy dokon�ila, kdy� je "uspokojena".
    ///P��kladem je Sp�nek, kdy by se jinak pot�eba odstra�ila na pod hranici pot�ebnosti a n�sledn� by se �innost ukon�ila. 
    ///Takto se �innost prov�d�, dokud nen� pot�eba odstran�na �pln�, pokud se neobjev� prioritn�j�� pot�eba.
    /// </summary>
    public void SwitchOnFirstPlace()
    {

        if (id != nodes[0].GetID)
        {

            Node item;

            foreach (var node in nodes)

            {

                if (node.GetID == id)
                {
                    item = node;
                    nodes.Remove(item);
                    nodes.Insert(0, item);
                    //id = original_id;

                    return;

                }

            }
        }
    }
    /// <summary>
    /// Vr�t� dokon�en� uzel na jeho p�vodn� pozici
    /// </summary>
    private void switchBackOnPlace()
    {


        Node item;


        item = nodes[0];
        nodes.Remove(item);
        nodes.Insert(item.GetID - 1, item);
        id = original_id;


    }
    //TODO SMAZAT
    public string vypis()
    {
        string x = "";
        foreach (Node item in nodes)
        {
            x += item.GetID + " - ";
        }
        return x;
    }

}




