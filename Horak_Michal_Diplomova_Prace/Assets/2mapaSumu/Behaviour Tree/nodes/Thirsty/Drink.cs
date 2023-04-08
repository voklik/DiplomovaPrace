using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Drink : Node
{//Zv��e pr�v� pije
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
        if ((character.GetThirsty() / character.GetThirstyMax() < 0.1) && (character.GetStav == Stav.Drinking))
        {
            character.SetStav(Stav.Nothing);
            return NodeState.SUCCESS;
        }

        else
        {
            character.Drink();
            agent.isStopped = true;
            if ((character.GetThirsty() / character.GetThirstyMax() < 0.1) && (character.GetStav == Stav.Drinking || character.GetStav == Stav.GoingForWater))
            {
                character.SetStav(Stav.Nothing);
                return NodeState.SUCCESS;

            }
            return NodeState.RUNNING;
        }
    }
}
