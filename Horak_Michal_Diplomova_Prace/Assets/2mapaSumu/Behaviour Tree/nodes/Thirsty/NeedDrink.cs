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
        if ((character.GetThirsty() / character.GetThirstyMax() > 0.7) || ((character.GetThirsty() / character.GetThirstyMax() > 0.1) && character.GetStav == Stav.Drinking))
        {
            character.CloseWater();
            if (character.GetTargetWater() == null)
            { return NodeState.FAILURE; }
            character.SetStav(Stav.Drinking);
            return NodeState.SUCCESS;
        }
        else
        {
            return NodeState.FAILURE;
        }
    }
}
