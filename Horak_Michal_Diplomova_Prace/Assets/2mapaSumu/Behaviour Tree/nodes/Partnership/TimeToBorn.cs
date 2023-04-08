using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToBorn : Node
{//Uzel, kter� zaji��uje inicializaci nov� entity potomka, pokud nastal �as na porod.
   
  
    public TimeToBorn(Animal ai)
    { //Ne�e�� se pohlav� zv��ete, proto�e pouze samice budou m�t tuto t��do ve strom� chov�n�
        nick = "borning";
        this.character = ai;

    }



    public override NodeState Evaluate()
    {

        if (character.getIsPregnant())
        {
            if (character.getTimePregnancy() <= 0.0f)
            {//nastal �as na porod, tak se vybere random pozice v okruhu rodi�ky
                Vector3 teren = new Vector3(Random.Range(1, 3) + character.gameObject.transform.position.x
                    , character.gameObject.transform.position.y,
                    Random.Range(0, 1) + character.gameObject.transform.position.z);

                List<Entity> children;
                children = MaterialStorage.generator.GenerateEntityPopulation(character.GetKind(), Mathf.RoundToInt(Random.Range(1,3)), teren);
                    foreach (Entity item in children)
                    {
                        character.addChilren(item);
                        if(character.getPartner!=null)
                        character.getPartner.GetComponent<Animal>().addChilren(item);
                    }

                character.setIsPregnant(false);
                character.ResetReproduceCooldowntToPregnant();
                character.resetTimePregnancy();
                return NodeState.SUCCESS;
            }
            else
            {//Nenastal �as porodu
                return NodeState.FAILURE;
            }
        }
        else
        {//Samice nen� t�hotn�
            return NodeState.FAILURE;
        }
    }





}
