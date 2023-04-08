using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedDrink : Node
{
    //Uzel chování, který rozhoduje, zda je potøeba se napít
    public NeedDrink(Animal ai)
    {

        this.character = ai;
    }

    /// <summary>
    /// Zpracování uzlu. Pokud žízeò >70%, nebo pokud už pije aktuálnì
    /// </summary>
    /// <returns></returns>
    public override NodeState Evaluate()
    {
        if ((character.getThirsty() / character.getThirstyMax() > 0.7) || ((character.getThirsty() / character.getThirstyMax() > 0.1) && character.getStav == Stav.Drinking))
        {
            character.closeWater();
            if (character.getTargetWater() == null)
            { return NodeState.FAILURE; }
            character.setStav(Stav.Drinking);
            return NodeState.SUCCESS;
        }
        else
        {
            return NodeState.FAILURE;
        }
    }
}
