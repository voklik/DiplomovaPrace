using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsLive : Node
{//Uzel, kter� �ekne, zda c�l zv��ete je �iv�, �i mrtv�

    public IsLive(Animal ai)
    {
        this.character = ai;
    }
    /// <summary>
    /// Zpracov�n� uzlu - Je c�l �iv� ?
    /// </summary>
    /// <returns></returns>
    public override NodeState Evaluate()
    {
        //Dotazuji si na sv�j c�l j�dla
        if (character.getFoodTarget() != null)
        {
            bool target = character.getFoodTarget().GetIsLive();
            if ((target == false))
            {
                return NodeState.FAILURE;
            }
            else
            {
                return NodeState.SUCCESS;
            }
        }
        else
        {
            return NodeState.FAILURE;
        }
    }
}