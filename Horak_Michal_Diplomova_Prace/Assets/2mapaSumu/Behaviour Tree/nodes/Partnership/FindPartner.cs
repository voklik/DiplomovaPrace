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
                        character.Vypis("na�el jsem si partnera" + animal.name);

                        StatisticSystem.AddStatisticEvent(character.GetStatisticEntity(), "Na�el si partnera", animal.GetStatisticEntity());
                        StatisticSystem.AddStatisticEvent(animal.GetStatisticEntity(), "Na�el si partnera", character.GetStatisticEntity());
                        return NodeState.SUCCESS;
                    }


             }//nezn�m svobodn� opa�n� pohlav� v dostahu
                return NodeState.FAILURE;
            }
            else//nezn�m nikoho ze sv� rasy
                return NodeState.FAILURE;
        }
      //jsem zadan�
        return NodeState.FAILURE;
    }
}