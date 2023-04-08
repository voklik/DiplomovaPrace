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
        if ((character.GetHunger() / character.GetHugerMax() > 0.7) || (character.GetStav == Stav.Eating && (character.GetHunger() / character.GetHugerMax() > 0.1)))
        {//Pokud m� zv��e hlad nad 70%, nebo pokud je hlad nad 10% a v minul�m cyklu jedl, 
         //tak se za�ne �e�it potrava/pokra�uje se v �e�en� potravy
            character.CloseFood();

            Stav last = character.GetStav;
            character.SetStav(Stav.Eating);
            if (character.GetFoodTarget() != null)
            {
                character.SetStav(Stav.Eating);
                return NodeState.SUCCESS;
            }
            else
            {
                character.SetStav(last);
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
