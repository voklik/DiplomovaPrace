using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPartner : Node
{
    private Animal character;
  



    public FindPartner(Animal ai)
    {
        nick = "findPartner";
        this.character = ai;

    }



    public override NodeState Evaluate()
    {if (character.getPartner == null && character.GetIsMature()) {
            
        List<GameObject> list = character.GetMyKind();
            if (list.Count != 0)
            {
                foreach (GameObject item in list)
                {
                    Animal animal = item.GetComponent<Animal>();
                    if (animal.GetIsMale() != character.GetIsMale() && animal.getPartner==null && animal.GetIsMature())
                    {
                        character.setPartner(animal);
                        animal.setPartner(character);
                        character.Vypis("našel jsem si partnera" + animal.name);

                        StatisticSystem.AddStatisticEvent(character.GetStatisticEntity(), "Našel si partnera", animal.GetStatisticEntity());
                        StatisticSystem.AddStatisticEvent(animal.GetStatisticEntity(), "Našel si partnera", character.GetStatisticEntity());
                        return NodeState.SUCCESS;
                    }


             }//neznám svobodné opaèné pohlaví v dostahu
                return NodeState.FAILURE;
            }
            else//neznám nikoho ze své rasy
                return NodeState.FAILURE;
        }
      //jsem zadaný
        return NodeState.FAILURE;
    }
}