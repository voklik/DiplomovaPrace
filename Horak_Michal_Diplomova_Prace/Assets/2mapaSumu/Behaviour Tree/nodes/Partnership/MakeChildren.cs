using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeChildren : Node
{//Uzel, kter˝ zajiöùuje mnoûenÌ

    public MakeChildren(Animal ai)
    {
        this.character = ai;
    }



    public override NodeState Evaluate()
    {
        if (character.getPartner != null)
        {
            if (character.GetIsMale())
            {
                Animal partner = character.getPartner.GetComponent<Animal>();
                if (character.getStav == Stav.Mating)
                {
                    character.setStav(Stav.Nothing);
                }
                partner.setIsPregnant(true);
                SpawnHearth();
                StatisticSystem.AddStatisticEvent(character.GetStatisticEntity(), "Making baby", partner.GetStatisticEntity());
                return NodeState.SUCCESS;
            }
            else
            {
                if (character.getPartner.GetComponent<Animal>().getStav == Stav.Mating)
                {
                    character.getPartner.GetComponent<Animal>().setStav(Stav.Nothing);
                }
                StatisticSystem.AddStatisticEvent(character.getPartner.GetComponent<Animal>().GetStatisticEntity(), "Making baby", character.GetStatisticEntity());
                character.setIsPregnant(true);
                SpawnHearth();
                return NodeState.SUCCESS;
            }
        }
        return NodeState.FAILURE;

    }
    private void SpawnHearth()
    {
        GameObject entita = Resources.Load<GameObject>("modely/hearth");
        Vector3 pozice = character.transform.position;
        pozice.y += 5;
        GameObject g = GameObject.Instantiate(entita, pozice, Quaternion.identity);
    }
}
