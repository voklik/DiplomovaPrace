using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeChildren : Node
{
    private Animal character;
    private float range;



    public MakeChildren(Animal ai)
    {

        this.character = ai;

    }



    public override NodeState Evaluate()
    {
        if (character.getPartner != null) { 
        if (character.GetIsMale())
            {
                character.Vypis("Diglity diglity deee" + character.getPartner.name);
                Animal partner = character.getPartner.GetComponent<Animal>();

                if (character.getStav == Stav.Mating)
                    character.setStav(Stav.Nothing);
            partner.setIsPregnant(true);
                SpawnHearth();
                StatisticSystem.AddStatisticEvent(character.GetStatisticEntity(), "Making baby", partner.GetStatisticEntity());
                return NodeState.SUCCESS;
        }
        else
            {
                if (character.getPartner.GetComponent<Animal>().getStav == Stav.Mating)
                    character.getPartner.GetComponent<Animal>().setStav(Stav.Nothing);
                character.Vypis("Diglity diglity deee" + character.getPartner.name);
                StatisticSystem.AddStatisticEvent(character.getPartner.GetComponent<Animal>().GetStatisticEntity(), "Making baby", character.GetStatisticEntity());
                character.setIsPregnant(true);
                SpawnHearth();
            return NodeState.SUCCESS;
        } }

        return NodeState.FAILURE;

    }
    private void SpawnHearth()
    {
        GameObject entita = Resources.Load<GameObject>("modely/hearth");
        Vector3 pozice = character.transform.position;
        pozice.y += 5;
     
        GameObject g = GameObject.Instantiate(entita, pozice, Quaternion.identity);
      //  g.AddComponent<RotationThing>();

    }
}
