using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedEat : Node
{
  //Uzel, kter� �e��, zda Zv��e pot�ebuje j�st a zda je n�co v jeho okol�, co by mohl sn�st
    

    public NeedEat(Animal ai)
    {
        this.character = ai;
    }
    /// <summary>
    /// Zpracov�n� uzlu, kdy se �e��, zda aktu�lne zv��e j�, nebo je pot�eba hladu > 70% hladu
    /// </summary>
    /// <returns></returns>
    public override NodeState Evaluate()
    {
        if ((character.getHunger() / character.getHugerMax() > 0.7) || (character.getStav == Stav.Eating && (character.getHunger() / character.getHugerMax() > 0.1)))
        {//Pokud m� zv��e hlad nad 70%, nebo pokud je hlad nad 10% a v minul�m cyklu jedl, 
         //tak se za�ne �e�it potrava/pokra�uje se v �e�en� potravy
            character.closeFood();

            Stav last = character.getStav;
            character.setStav(Stav.Eating);
            if (character.getFoodTarget() != null)
            {
                character.setStav(Stav.Eating);
                return NodeState.SUCCESS;
            }
            else
            {
                character.setStav(last);
                return NodeState.FAILURE;
            }
        }
        else
        {
            //j�st nen� pot�eba
            return NodeState.FAILURE;
        }
    }
}
