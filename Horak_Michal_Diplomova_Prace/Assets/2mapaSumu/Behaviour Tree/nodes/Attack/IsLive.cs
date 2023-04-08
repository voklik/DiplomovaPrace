using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsLive : Node
{//Uzel, který øekne, zda cíl zvíøete je živý, èi mrtvý

    public IsLive(Animal ai)
    {
        this.character = ai;
    }
    /// <summary>
    /// Zpracování uzlu - Je cíl živí ?
    /// </summary>
    /// <returns></returns>
    public override NodeState Evaluate()
    {
        //Dotazuji si na svùj cíl jídla
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