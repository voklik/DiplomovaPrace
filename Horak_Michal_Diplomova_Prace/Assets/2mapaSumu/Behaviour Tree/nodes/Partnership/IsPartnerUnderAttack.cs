using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPartnerUnderAttack : Node
{
    private Animal character;
 



    public IsPartnerUnderAttack(Animal ai)
    {

        this.character = ai;
      
    }



    public override NodeState Evaluate()
    {
        GameObject enemy = character.getAttackingPartnerClosestEntity();
        if(enemy!=null)
        {
            character.Vypis("partner je pod �tokem od" +enemy.name);
            return NodeState.SUCCESS;
        }
        else
            return NodeState.FAILURE;
       
    }
}
