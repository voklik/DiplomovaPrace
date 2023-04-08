using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NodeGoTo : Node
{//Uzel, kter� zaji��uje pohyb k c�ly

    private NavMeshAgent agent;
    public NodeGoTo(NavMeshAgent agent, Animal ai)
    {
        this.agent = agent;
        this.character = ai;
    }
    /// <summary>
    /// Zpracov�n� uzlu - pohyb-
    /// </summary>
    /// <returns></returns>
    public override NodeState Evaluate()
    {
        float distance = character.GetDistanceToTarget();
        if (distance != -1000)//Hodnota -1000 znamen�, �e to nen� p��stupn�
        {
            if (character.IsInCollisionWith(character.GetTarget()) || distance <= 3.0)//Pokud je kolize, nebo jsem tomu velice bl�zko
            {
                character.SetAgentMovementEnabled(true);//Vypnu pohyb
                agent.isStopped = true;
                if (character.GetStav == Stav.GoRandom)
                {
                    character.ResetRandomPointTarget();
                    character.SetStav(Stav.Nothing);
                }
                return NodeState.SUCCESS;
            }
            else
            {//Nen� p��stupn� c�l
                Vector3 target = character.GetTarget().transform.position;

                //Zkus�m naj�t c�l znova
                character.Vypis(target.ToString());
                if (character.GetStav == Stav.GoRandom)
                { target = new Vector3(target.x, target.y + 0.0f, target.z); }
                bool enabled = agent.enabled;
                agent.SetDestination(target);
                try
                {
                    agent.isStopped = false;
                }
                catch (System.Exception e)
                {
                    Debug.Log(character.gameObject.name + "error" + e.Message);
                }
                agent.isStopped = false;
                agent.enabled = enabled;
                character.SetAgentMovementEnabled(false);

                //Dostal jsem se k c�ly
                if (character.IsInCollisionWith(character.GetTarget()) || distance <= 3.0f)
                {
                    character.SetAgentMovementEnabled(true);
                    if (character.GetStav == Stav.GoRandom)
                    {
                        character.ResetRandomPointTarget();
                        character.SetStav(Stav.Nothing);
                    }
                    return NodeState.SUCCESS;
                }
                return NodeState.RUNNING;//Zat�m jsem c�le nedosahl
            }
        }
        else
        {//Nic nen� v dosahu
            return NodeState.FAILURE;
        }

    }
}
