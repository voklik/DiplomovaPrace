using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Drink : Node
{//Zv��e pr�v� pije
    private Animal character;

    private NavMeshAgent agent;//Agent je pot�eba, aby se zastavil pohyb

    public Drink(NavMeshAgent agent, Animal ai)
    {

        this.agent = agent;
        this.character = ai;
    }

    /// <summary>
    /// Zpracov�n� uzlu - Pije so dokud ��ze� se nedostane pod 10% maxim�ln� hodnoty
    /// </summary>
    /// <returns></returns>
    public override NodeState Evaluate()
    {
        if ((character.getThirsty() / character.getThirstyMax() < 0.1) && (character.getStav == Stav.Drinking))
        {
            character.setStav(Stav.Nothing);
            return NodeState.SUCCESS;
        }

        else
        {
            character.Vypis("Piji");
            character.Drink();
            agent.isStopped = true;
            if ((character.getThirsty() / character.getThirstyMax() < 0.1) && (character.getStav == Stav.Drinking || character.getStav == Stav.GoingForWater))
            {
                character.setStav(Stav.Nothing);
                return NodeState.SUCCESS;

            }
            return NodeState.RUNNING;
        }
    }
}
