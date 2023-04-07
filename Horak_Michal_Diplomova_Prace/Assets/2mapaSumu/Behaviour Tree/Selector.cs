using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Selector : Node
{
    /*
     *Typ Uzlu,který pøi zpracování prochází vìtve uzlù v listu nodes. 
     *Pokud procházená vìtev vrátí False, tak se pøejde k další vìtvi. Pokud už nejsou vìtve, tak Selector vrátí Neúspìch.
     * Pokud Vìtev vrátí Úspìch, èi Probíhající, tak se tento stav vrátí (returne)
     */

    protected List<Node> nodes = new List<Node>();//List s uzly
    /// <summary>
    /// Konsturkotr
    /// </summary>
    /// <param name="_id">Pro Debugovací úèely</</param>
    /// <param name="nodes">Seznam uzlù</param>
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
    //Zpracování uzlu
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
    /// Prohodí se pozice "chování" na první pozici. Toto je z tohot dùvodu, aby se èinnost vždy dokonèila, když je "uspokojena".
    ///Pøíkladem je Spánek, kdy by se jinak potøeba odstraòila na pod hranici potøebnosti a následnì by se èinnost ukonèila. 
    ///Takto se èinnost provádí, dokud není potøeba odstranìna úplnì, pokud se neobjeví prioritnìjší potøeba.
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
    /// Vrátí dokonèení uzel na jeho pùvodní pozici
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




