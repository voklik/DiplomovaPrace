using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToBorn : Node
{/*
  *Uzel, kterı zajišuje inicializaci nové entity potomka, pokud nastal èas na porod.
    */
    private Animal character;



   
    public TimeToBorn(Animal ai)
    { //Neøeší se pohlaví zvíøete, protoe pouze samice budou mít tuto tøído ve stromì chování
        nick = "borning";
        this.character = ai;

    }



    public override NodeState Evaluate()
    {

        if (character.getIsPregnant())
        {
            if (character.getTimePregnancy() <= 0.0f)
            {//nastal èas na porod, tak se vybere random pozice v okruhu rodièky
                Vector3 teren = new Vector3(Random.Range(1, 3) + character.gameObject.transform.position.x
                    , character.gameObject.transform.position.y,
                    Random.Range(0, 1) + character.gameObject.transform.position.z);


                List<Entity> children;

                children = MaterialStorage.generator.GenerateEntityPopulation(character.GetKind(), Mathf.RoundToInt(Random.Range(1,3)), teren);

                if(children!=null)
                {
                    foreach (Entity item in children)
                    {
                        character.Vypis("narodilo se mi dítì "+item.name);
                        character.addChilren(item);
                        if(character.getPartner!=null)
                        character.getPartner.GetComponent<Animal>().addChilren(item);
                    }
                }
                else
                {   //nemùe se stát, ale pro testovací úèely vznikl else
                    Debug.LogError("Nenarodil se nikdo !!!");
                }
                character.setIsPregnant(false);
                character.ResetReproduceCooldowntToPregnant();
                character.resetTimePregnancy();
                return NodeState.SUCCESS;
            }
            else
            {//Nenastal èas porodu
                return NodeState.FAILURE;
            }
        }
        else
        {//Samice není tìhotná
            return NodeState.FAILURE;
        }
    }





}
