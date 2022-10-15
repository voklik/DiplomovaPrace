using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsLive : Node
{//Uzel, který øekne, zda cíl zvíøete je živý, èi mrtvý
    private Animal character;

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
                character.Vypis("Food Nepøítel nežije" + character.getFoodTarget().name); //TODO SMAZAT
                // character.setStav(Stav.GoingForFood);
                return NodeState.FAILURE;
            }
            else
            {
                // character.setStav(Stav.GoingForFight);
                character.Vypis("Food  Nepøítel žije" + character.getFoodTarget().name); //TODO SMAZAT
                return NodeState.SUCCESS;
            }
        }
        else
        {
            character.Vypis("nepøítel neexistuje"); //TODO SMAZAT
            return NodeState.FAILURE;
        }
    }
}