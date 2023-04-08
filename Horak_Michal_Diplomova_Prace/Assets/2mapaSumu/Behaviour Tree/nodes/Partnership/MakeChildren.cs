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
        if (character.GetPartner != null)
        {
            if (character.GetIsMale())
            {
                Animal partner = character.GetPartner.GetComponent<Animal>();
                if (character.GetStav == Stav.Mating)
                {
                    character.SetStav(Stav.Nothing);
                }
                partner.SetIsPregnant(true);
                SpawnHearth();
                StatisticSystem.AddStatisticEvent(character.GetStatisticEntity(), "Making baby", partner.GetStatisticEntity());
                return NodeState.SUCCESS;
            }
            else
            {
                if (character.GetPartner.GetComponent<Animal>().GetStav == Stav.Mating)
                {
                    character.GetPartner.GetComponent<Animal>().SetStav(Stav.Nothing);
                }
                StatisticSystem.AddStatisticEvent(character.GetPartner.GetComponent<Animal>().GetStatisticEntity(), "Making baby", character.GetStatisticEntity());
                character.SetIsPregnant(true);
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
