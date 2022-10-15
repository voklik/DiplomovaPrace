using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsLive : Node
{//Uzel, kter� �ekne, zda c�l zv��ete je �iv�, �i mrtv�
    private Animal character;

    public IsLive(Animal ai)
    {
        this.character = ai;
    }
    /// <summary>
    /// Zpracov�n� uzlu - Je c�l �iv� ?
    /// </summary>
    /// <returns></returns>
    public override NodeState Evaluate()
    {
        //Dotazuji si na sv�j c�l j�dla
        if (character.getFoodTarget() != null)
        {
            bool target = character.getFoodTarget().GetIsLive();
            if ((target == false))
            {
                character.Vypis("Food Nep��tel ne�ije" + character.getFoodTarget().name); //TODO SMAZAT
                // character.setStav(Stav.GoingForFood);
                return NodeState.FAILURE;
            }
            else
            {
                // character.setStav(Stav.GoingForFight);
                character.Vypis("Food  Nep��tel �ije" + character.getFoodTarget().name); //TODO SMAZAT
                return NodeState.SUCCESS;
            }
        }
        else
        {
            character.Vypis("nep��tel neexistuje"); //TODO SMAZAT
            return NodeState.FAILURE;
        }
    }
}