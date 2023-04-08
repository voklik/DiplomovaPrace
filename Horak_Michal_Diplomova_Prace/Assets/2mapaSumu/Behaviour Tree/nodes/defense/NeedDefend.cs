using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedDefend : Node
{
    //Uzel, kter� �e��, zda zv��e pot�ebuje chr�nit samo sebe
    public NeedDefend(Animal ai)
    {
        this.character = ai;
    }
    /// <summary>
    /// Zpracov�n� uzlu -pot�eba br�nit se 
    /// </summary>
    /// <returns></returns>
    public override NodeState Evaluate()
    {
        //Existuje n�jak� zv��e, kter� m� m� jako c�l �toku ?
        GameObject enemy = character.getAttackingMeClosestEntity();
        if (enemy != null)
        {
            return NodeState.SUCCESS;
        }
        else
            return NodeState.FAILURE;
    }
}
