using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Sleep : Node
{//Uzel, kter� slou�� pro spu�t�n� sp�nku, p�i spln�n� po�adavc�ch, nebo ukon�en� prob�haj�c�ho sp�nku
    private Animal character;
    private NavMeshAgent agent;//Pot�eba pro zastaven� pohybu

    public Sleep(NavMeshAgent agent, Animal ai)
    {
        this.agent = agent;
        this.character = ai;
    }
    /// <summary>
    /// Zpracov�n� uzlu. Sp� se, dokud pot�eba se nedostane pod 10% maxim�ln� hodnoty
    /// </summary>
    /// <returns></returns>
    public override NodeState Evaluate()
    {
        if (character.getSleep() / character.getSleepMax() < 0.10 && character.getStav == Stav.Sleeping)
        {//Pokud charakter se dostal pod 10% procent pot�eby sp�nku a na konci minul�ho cyklu Update spal, tak se ukon�� sp�nek 
            character.setStav(Stav.Nothing);
            return NodeState.SUCCESS;
        }
        else
        {//Charakter jde sp�t
            character.Vypis("sp�m");//TODO SMAZAT
            character.Sleep();
            agent.isStopped = true;
            character.setStav(Stav.Sleeping);
            return NodeState.RUNNING;
        }

    }
}
