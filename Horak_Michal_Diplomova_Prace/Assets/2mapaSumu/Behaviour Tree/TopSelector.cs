using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TopSelector : Node
{

    /*Hlavní a prvotní uzel.
     * Existuje seznam priorit, které by mohou pøedstavovat vìtev hlavního uzlu. Vìtev se vždy projde celá a pokud
     * není nalezen uzel, který by se aktuálnì zpracoval, tak se pøejde k další vìtvi.
     */
    protected List<Node> priority1 = new List<Node>();// osobní obrana, èi obrana partnera /dítìte.....doplniot
    protected List<Node> priority2 = new List<Node>();//osobní potøeby
    protected List<Node> priority3 = new List<Node>();//sociální potøeby
    /// <summary>
    /// Konsturkor hlavního uzlu
    /// </summary>
    /// <param name="animal"> Odkaz na tøídu zvíøete > pøes to se pøejde k hernímu objektu</param>
    /// <param name="_id">Pomocný parametr, který slouží pro debugovací úèely, aby se mohlo zjistit, kde nastal problém</param>
    /// <param name="priorita">Seznam Prioritních rozhodování (obrana atd)</param>
    /// <param name="osobníPotreby">Seznam rozhodovvni (osobni potøeby)</param>
    /// <param name="socialniPotreby">Seznam rozhodování (sociální potøeby)</param>
    public TopSelector(Animal animal,int _id, List<Node> priorita, List<Node> osobníPotreby, List<Node> socialniPotreby)
    {
        character = animal;
        id = _id;
        original_id = id;
        priority1 = priorita;
        priority2 = osobníPotreby;
        priority3 = socialniPotreby;
    }
    /// <summary>
    /// Konsturkor hlavního uzlu
    /// </summary>
    /// <param name="animal"> Odkaz na tøídu zvíøete > pøes to se pøejde k hernímu objektu</param>
    /// <param name="priorita">Seznam Prioritních rozhodování (obrana atd)</param>
    /// <param name="osobníPotreby">Seznam rozhodovvni (osobni potøeby)</param>
    /// <param name="socialniPotreby">Seznam rozhodování (sociální potøeby)</param>
    public TopSelector(Animal animal, List<Node> priorita, List<Node> osobníPotreby, List<Node> socialniPotreby)
    {
        character = animal;
        id = 100;
        original_id = id;
        priority1 = priorita;
        priority2 = osobníPotreby;
        priority3 = socialniPotreby;
    }
    /// <summary>
    /// Zpracování hlavního uzlu
    /// </summary>
    /// <returns></returns>
    public override NodeState Evaluate()
    {   
    /*Hlavní a prvotní uzel.
     * Existuje seznam priorit, které by mohou pøedstavovat vìtev hlavního uzlu. Vìtev se vždy projde celá a pokud
     * není nalezen uzel, který by se aktuálnì zpracoval, tak se pøejde k další vìtvi.
     */

        foreach (var node in priority1)
        { NodeState vysledek = node.Evaluate();
            character.Vypis("node " + node.GetNick() + " " + vysledek.ToString());
            switch (vysledek)
            {
                case NodeState.RUNNING:
                    _nodeState = NodeState.RUNNING;
                    id = node.GetID;
                    return _nodeState;

                case NodeState.SUCCESS:
                    id = original_id;
                    _nodeState = NodeState.SUCCESS;
                    return _nodeState;

                case NodeState.FAILURE:
                    break;
                default:
                    break;
            }
        }
        foreach (var node in priority2)
        {
            NodeState vysledek = node.Evaluate();
            character.Vypis("node " + node.GetNick() + " " + vysledek.ToString());
            switch (vysledek)
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
        foreach (var node in priority3)
        {
            NodeState vysledek = node.Evaluate();
            character.Vypis("node " + node.GetNick() + " " + vysledek.ToString());
            switch (vysledek)
            {
                case NodeState.RUNNING:
                    _nodeState = NodeState.RUNNING;
                    id = node.GetID;
                    return _nodeState;
                case NodeState.SUCCESS:
                    id = original_id;
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

        if (id != priority2[0].GetID)
        {

            Node item;

            foreach (var node in priority2)

            {

                if (node.GetID == id)
                {
                    item = node;
                    priority2.Remove(item);
                    priority2.Insert(0, item);
                    //id = original_id; //TODO SMAZAT

                    return;

                }

            }
        }
    }

    private void switchBackOnPlace()
    {
        return;

        Node item;


        item = priority2[0];
        priority2.Remove(item);
        priority2.Insert(item.GetID - 1, item);
        id = original_id;


    }
    public string vypis()
    {
        string x = "";
        foreach (Node item in priority1)
        {
            x += item.GetNick() + " - ";
        }
        foreach (Node item in priority2)
        {
            x += item.GetNick() + " - ";
        }
        foreach (Node item in priority3)
        {
            x += item.GetNick() + " - ";
        }
        return x;
    }

}





