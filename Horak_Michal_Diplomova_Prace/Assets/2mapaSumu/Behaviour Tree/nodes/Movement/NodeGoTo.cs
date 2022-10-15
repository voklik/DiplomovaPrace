using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NodeGoTo : Node
{//Uzel, kter˝ zajiöùuje pohyb k cÌly

    private NavMeshAgent agent;
    private Animal character;

    public NodeGoTo(NavMeshAgent agent, Animal ai)
    {
        this.agent = agent;
        this.character = ai;
    }
    /// <summary>
    /// Zpracov·nÌ uzlu - pohyb-
    /// </summary>
    /// <returns></returns>
    public override NodeState Evaluate()
    {
        //  character.Vypis("Go"); //TODO SMAZAT
        float distance = character.getDistanceToTarget();
        if (character.getStav == Stav.GoRandom)
        {
            character.Vypis("distance to target terrain" + distance); //TODO SMAZAT
        }
        if (distance != -1000)//Hodnota -1000 znamen·, ûe to nenÌ p¯ÌstupnÈ
        {
            if (character.IsInCollisionWith(character.getTarget()) || distance <= 3.0)//Pokud je kolize, nebo jsem tomu velice blÌzko
            {
                character.Vypis("yes1"); //TODO SMAZAT
                character.setAgentMovementEnabled(true);//Vypnu pohyb
                character.Vypis("target caught"); //TODO SMAZAT
                agent.isStopped = true;
                if (character.getStav == Stav.GoRandom)
                {
                    character.resetRandomPointTarget();
                    character.setStav(Stav.Nothing);
                }
                // character.stavNext(); //TODO SMAZAT
                return NodeState.SUCCESS;
            }
            else
            {//NenÌ p¯Ìstupn˝ cÌl
                character.Vypis("no1"); //TODO SMAZAT
                Vector3 target = character.getTarget().transform.position;
                //  Vector3 tar = new Vector3(target.x * 2, target.y, target.z);
                //  Debug.Log("my:" + character.transform.position.ToString());
                //  Debug.Log("target:" + character.getTarget().transform.position.ToString());
                character.Vypis("GoToPlace"); //TODO SMAZAT

                //agent.ResetPath();

                //ZkusÌm najÌt cÌl znova
                character.Vypis(target.ToString());
                if (character.getStav == Stav.GoRandom)
                { target = new Vector3(target.x, target.y + 0.0f, target.z); }
                bool enabled = agent.enabled;
                agent.SetDestination(target);

                //   Debug.LogError(character.gameObject.name + " Destination "+agent.destination+ " enabled " + agent.enabled + " OnMash " + agent.isOnNavMesh + " ActiveEnabled " + agent.isActiveAndEnabled);
                //    character.setAgentMovementEnabled(false);
                // Debug.Log(character.gameObject.name + " navmesh " + agent.isOnNavMesh);
                try
                {
                    //  agent.enabled = false;
                    //    agent.enabled = true;
                    // Debug.Log(character.gameObject.name + " navmesh " + agent.isOnNavMesh);
                    agent.isStopped = false;
                }
                catch (System.Exception e)
                {
                    // Debug.Log(character.gameObject.name + "error"+e.Message);
                }
                // Debug.Log(character.gameObject.name + " navmesh " + agent.isOnNavMesh);
                agent.isStopped = false;
                agent.enabled = enabled;
                character.setAgentMovementEnabled(false);
                //  character.Wait(0.1f);
                //  agent.ResetPath();

                //Dostal jsem se k cÌly
                if (character.IsInCollisionWith(character.getTarget()) || distance <= 3.0f)
                {
                    character.Vypis("yes2"); //TODO SMAZAT
                    character.setAgentMovementEnabled(true);
                    character.Vypis("target caught2"); //TODO SMAZAT
                    if (character.getStav == Stav.GoRandom)
                    {
                        character.resetRandomPointTarget();
                        character.setStav(Stav.Nothing);
                    }
                    return NodeState.SUCCESS;
                }
                character.Vypis("no2"); //TODO SMAZAT
                return NodeState.RUNNING;//ZatÌm jsem cÌle nedosahl
            }


            //if (distance <= 2.5f)
            //{
            //        character.setAgentMovementEnabled(true);
            //        character.Vypis("target caught");
            //        if (character.getStav == Stav.GoRandom)
            //        {
            //            character.resetRandomPointTarget();
            //            character.setStav(Stav.Nothing);
            //        }
            //        // character.stavNext();
            //        return NodeState.SUCCESS;
            //    }
            //else
            //{
            //    Vector3 target = character.getTarget().transform.position;
            //  //  Vector3 tar = new Vector3(target.x * 2, target.y, target.z);
            //    //  Debug.Log("my:" + character.transform.position.ToString());
            //    //  Debug.Log("target:" + character.getTarget().transform.position.ToString());
            //    character.Vypis("GoToPlace");
            //        //agent.ResetPath();
            //        character.Vypis(target.ToString());
            //        if(character.getStav==Stav.GoRandom)
            //        { target = new Vector3(target.x, target.y + 0.0f, target.z); }
            //        agent.SetDestination(target);
            //        //    character.setAgentMovementEnabled(false);
            //        agent.isStopped = false;
            //        character.setAgentMovementEnabled(false);
            //      //  character.Wait(0.1f);
            //      //  agent.ResetPath();
            //        distance = character.getDistanceToTarget();
            //    if (distance <= 2.5f)
            //        {
            //            character.setAgentMovementEnabled(true);
            //            character.Vypis("target caught");
            //            if(character.getStav==Stav.GoRandom)
            //            {
            //                character.resetRandomPointTarget();
            //                character.setStav(Stav.Nothing);
            //            }
            //        return NodeState.SUCCESS;
            //    }
            //    return NodeState.RUNNING;
            //}

        }
        else
        {
            character.Vypis("NIC V DOSAHU" + character.getStav.ToString());
            return NodeState.FAILURE;
        }

    }
}
