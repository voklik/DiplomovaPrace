using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedDefend : Node
{
    //Uzel, který øeší, zda zvíøe potøebuje chránit samo sebe
    public NeedDefend(Animal ai)
    {
        this.character = ai;
    }
    /// <summary>
    /// Zpracování uzlu -potøeba bránit se 
    /// </summary>
    /// <returns></returns>
    public override NodeState Evaluate()
    {
        //Existuje nìjaké zvíøe, které mì má jako cíl útoku ?
        GameObject enemy = character.getAttackingMeClosestEntity();
        if (enemy != null)
        {
            return NodeState.SUCCESS;
        }
        else
            return NodeState.FAILURE;
    }
}
