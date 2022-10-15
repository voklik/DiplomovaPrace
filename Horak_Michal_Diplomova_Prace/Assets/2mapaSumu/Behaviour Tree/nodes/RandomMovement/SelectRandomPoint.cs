using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectRandomPoint : Node
{
    //Tøída, která vybere náhodný terén a zvíøe se k nìmu vydá.
    //Tento uzel existuje, aby byl na scénì nìjaký pohyb, pokud zvíøata nepotøebují øešit své potøeby
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
    /// Zpracování uzlu - Charakter si vybere náhodný terén a vydá se k nìmu. Pokud to dlouho trvá, tak si vybyre další
    /// </summary>
    /// <returns></returns>
    public override NodeState Evaluate()
    {
        if ((character.IsOneOfState(prerusitelneStavy) && !character.IsOneOfState(neprerusitelneStavy)) || character.getStav == stavProNod)
        {
            timetoCatch += Time.deltaTime;
            if (timetoCatch >= timetoCatchLimit)
            { character.setRandomPointTarget(); character.Vypis("zmìna"); timetoCatch = 0; }

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
