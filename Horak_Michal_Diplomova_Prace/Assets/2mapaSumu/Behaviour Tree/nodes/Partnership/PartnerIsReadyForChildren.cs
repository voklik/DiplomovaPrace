using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartnerIsReadForChildren : Node
{//Uzel, který oznamuje, že partner je pøipraven pro množení.

    public PartnerIsReadForChildren(Animal ai)
    {
        this.character = ai;
    }



    public override NodeState Evaluate()
    {
        if (character.GetPartner != null)
        {if(character.GetIsMature() && character.GetPartner.GetComponent<Animal>().GetIsMature())
            {
                if (character.GetIsMale())
                {

                    Animal partner = character.GetPartner.GetComponent<Animal>();

                    if (!partner.GetIsPregnant()&& partner.GetCanReproduce()==true)
                    {
                        character.SetStav(Stav.Mating);
                        return NodeState.SUCCESS;
                    }
                    else
                        return NodeState.FAILURE;
                }
                else
                {
                    if (!character.GetIsPregnant()&& character.GetCanReproduce() == true)
                    {
                        return NodeState.SUCCESS;
                    }
                    else
                        return NodeState.FAILURE;
                }
            }
        }

        return NodeState.FAILURE;
    }
}
