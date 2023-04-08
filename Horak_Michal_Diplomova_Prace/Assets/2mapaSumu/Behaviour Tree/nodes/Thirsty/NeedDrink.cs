using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedDrink : Node
{
    //Uzel chov�n�, kter� rozhoduje, zda je pot�eba se nap�t
    public NeedDrink(Animal ai)
    {

        this.character = ai;
    }

    /// <summary>
    /// Zpracov�n� uzlu. Pokud ��ze� >70%, nebo pokud u� pije aktu�ln�
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
