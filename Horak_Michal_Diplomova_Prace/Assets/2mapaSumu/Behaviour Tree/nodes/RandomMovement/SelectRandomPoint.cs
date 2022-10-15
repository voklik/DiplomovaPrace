using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectRandomPoint : Node
{
    //T��da, kter� vybere n�hodn� ter�n a zv��e se k n�mu vyd�.
    //Tento uzel existuje, aby byl na sc�n� n�jak� pohyb, pokud zv��ata nepot�ebuj� �e�it sv� pot�eby
    private readonly List<Stav> prerusitelneStavy = new List<Stav> { Stav.Nothing };
    private readonly List<Stav> neprerusitelneStavy = new List<Stav> { };
    private Stav stavProNod = Stav.GoRandom;
    private float timetoCatch = 0;
    private float timetoCatchLimit = 15.0f;
    public SelectRandomPoint(Animal ai)
    {
        this.character = ai;
    }


    /// <summary>
    /// Zpracov�n� uzlu - Charakter si vybere n�hodn� ter�n a vyd� se k n�mu. Pokud to dlouho trv�, tak si vybyre dal��
    /// </summary>
    /// <returns></returns>
    public override NodeState Evaluate()
    {
        if ((character.IsOneOfState(prerusitelneStavy) && !character.IsOneOfState(neprerusitelneStavy)) || character.getStav == stavProNod)
        {
            timetoCatch += Time.deltaTime;
            if (timetoCatch >= timetoCatchLimit)
            { character.setRandomPointTarget(); character.Vypis("zm�na"); timetoCatch = 0; }

            if (character.getRandomPointTarget() != null)
            {
                character.Vypis("jdu na bod" + character.getRandomPointTarget()); //TODO SMAZAT
                character.setStav(stavProNod);
                return NodeState.SUCCESS;
                //??asi nic?? //TODO SMAZAT
            }
            else
            {
                if (character.setRandomPointTarget() != null)
                {   // if (character.CalculateNewPath(character.getRandomPointTarget().transform.position))  //TODO SMAZAT
                    //   {
                    character.Vypis("jdu na wandr" + character.getRandomPointTarget());
                    if (character.getStav != stavProNod)
                        character.setStav(stavProNod);
                    timetoCatch = 0;
                    return NodeState.SUCCESS;
                    //}
                    // else
                    // {
                    //     character.Vypis("nejdu na wandr");
                    //    character.resetRandomPointTarget();
                    // }
                }
            }
        }
        return NodeState.FAILURE;
    }
}
