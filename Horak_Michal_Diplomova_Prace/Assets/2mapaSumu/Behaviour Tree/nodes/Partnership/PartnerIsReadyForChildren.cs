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
        if (character.getPartner != null)
        {if(character.GetIsMature() && character.getPartner.GetComponent<Animal>().GetIsMature())
            {
                if (character.GetIsMale())
                {

                    Animal partner = character.getPartner.GetComponent<Animal>();

                    if (!partner.getIsPregnant()&& partner.GetCanReproduce()==true)
                    {
                        character.setStav(Stav.Mating);
                        return NodeState.SUCCESS;
                    }
                    else
                        return NodeState.FAILURE;
                }
                else
                {
                    if (!character.getIsPregnant()&& character.GetCanReproduce() == true)
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
