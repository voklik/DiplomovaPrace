using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedEat : Node
{
  //Uzel, který øeší, zda Zvíøe potøebuje jíst a zda je nìco v jeho okolí, co by mohl sníst
    

    public NeedEat(Animal ai)
    {
        this.character = ai;
    }
    /// <summary>
    /// Zpracování uzlu, kdy se øeší, zda aktuálne zvíøe jí, nebo je potøeba hladu > 70% hladu
    /// </summary>
    /// <returns></returns>
    public override NodeState Evaluate()
    {
        if ((character.GetHunger() / character.GetHugerMax() > 0.7) || (character.GetStav == Stav.Eating && (character.GetHunger() / character.GetHugerMax() > 0.1)))
        {//Pokud má zvíøe hlad nad 70%, nebo pokud je hlad nad 10% a v minulém cyklu jedl, 
         //tak se zaène øešit potrava/pokraèuje se v øešení potravy
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
            //jíst není potøeba
            return NodeState.FAILURE;
        }
    }
}
