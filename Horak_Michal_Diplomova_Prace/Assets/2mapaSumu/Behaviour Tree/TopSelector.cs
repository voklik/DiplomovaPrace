using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TopSelector : Node
{

    /*Hlavn� a prvotn� uzel.
     * Existuje seznam priorit, kter� by mohou p�edstavovat v�tev hlavn�ho uzlu. V�tev se v�dy projde cel� a pokud
     * nen� nalezen uzel, kter� by se aktu�ln� zpracoval, tak se p�ejde k dal�� v�tvi.
     */
    protected List<Node> priority1 = new List<Node>();// osobn� obrana, �i obrana partnera /d�t�te.....doplniot
    protected List<Node> priority2 = new List<Node>();//osobn� pot�eby
    protected List<Node> priority3 = new List<Node>();//soci�ln� pot�eby
    /// <summary>
    /// Konsturkor hlavn�ho uzlu
    /// </summary>
    /// <param name="animal"> Odkaz na t��du zv��ete > p�es to se p�ejde k hern�mu objektu</param>
    /// <param name="_id">Pomocn� parametr, kter� slou�� pro debugovac� ��ely, aby se mohlo zjistit, kde nastal probl�m</param>
    /// <param name="priorita">Seznam Prioritn�ch rozhodov�n� (obrana atd)</param>
    /// <param name="osobn�Potreby">Seznam rozhodovvni (osobni pot�eby)</param>
    /// <param name="socialniPotreby">Seznam rozhodov�n� (soci�ln� pot�eby)</param>
    public TopSelector(Animal animal,int _id, List<Node> priorita, List<Node> osobn�Potreby, List<Node> socialniPotreby)
    {
        character = animal;
        id = _id;
        original_id = id;
        priority1 = priorita;
        priority2 = osobn�Potreby;
        priority3 = socialniPotreby;
    }
    /// <summary>
    /// Konsturkor hlavn�ho uzlu
    /// </summary>
    /// <param name="animal"> Odkaz na t��du zv��ete > p�es to se p�ejde k hern�mu objektu</param>
    /// <param name="priorita">Seznam Prioritn�ch rozhodov�n� (obrana atd)</param>
    /// <param name="osobn�Potreby">Seznam rozhodovvni (osobni pot�eby)</param>
    /// <param name="socialniPotreby">Seznam rozhodov�n� (soci�ln� pot�eby)</param>
    public TopSelector(Animal animal, List<Node> priorita, List<Node> osobn�Potreby, List<Node> socialniPotreby)
    {
        character = animal;
        id = 100;
        original_id = id;
        priority1 = priorita;
        priority2 = osobn�Potreby;
        priority3 = socialniPotreby;
    }
    /// <summary>
    /// Zpracov�n� hlavn�ho uzlu
    /// </summary>
    /// <returns></returns>
    public override NodeState Evaluate()
    {   
    /*Hlavn� a prvotn� uzel.
     * Existuje seznam priorit, kter� by mohou p�edstavovat v�tev hlavn�ho uzlu. V�tev se v�dy projde cel� a pokud
     * nen� nalezen uzel, kter� by se aktu�ln� zpracoval, tak se p�ejde k dal�� v�tvi.
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
    /// Prohod� se pozice "chov�n�" na prvn� pozici. Toto je z tohot d�vodu, aby se �innost v�dy dokon�ila, kdy� je "uspokojena".
    ///P��kladem je Sp�nek, kdy by se jinak pot�eba odstra�ila na pod hranici pot�ebnosti a n�sledn� by se �innost ukon�ila. 
    ///Takto se �innost prov�d�, dokud nen� pot�eba odstran�na �pln�, pokud se neobjev� prioritn�j�� pot�eba.
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





