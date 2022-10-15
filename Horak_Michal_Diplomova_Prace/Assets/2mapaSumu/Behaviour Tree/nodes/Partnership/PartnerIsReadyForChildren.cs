using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartnerIsReadForChildren : Node
{
    private Animal character;
    private float range;



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
                        //  character.Vypis("Diglity diglity deee" + partner.name);
                        character.setStav(Stav.Fucking);
                        return NodeState.SUCCESS;
                    }

                    else
                        return NodeState.FAILURE;
                }
                else
                {
                    if (!character.getIsPregnant()&& character.GetCanReproduce() == true)

                    {
                     //   character.Vypis("Diglity diglity deee" + character.getPartner.name);
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
