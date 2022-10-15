using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Plant : Entity
{
    public void InitHeightReset()
    { InitHeight2(); }

    public override  void Start()
    {
       
        typeEntity = 2;
       

    Init();
     
      

                gameObject.GetComponentInChildren<Rigidbody>().useGravity = true;

            gameObject.GetComponentInChildren<Rigidbody>().angularDrag = 100;
            //for (int i = 0; i < 20; i++)
            //{
            //    Debug.Log(agent.isOnNavMesh);
            //    waiter(0.2f);
            //    if (agent.isOnNavMesh)
            //    {
            //        ag.SetDestination(new Vector3(transform.position.x + 5, transform.position.y, transform.position.z));
            //        ag.isStopped = true;
            //        agent.enabled = false;
            //        gameObject.GetComponent<Rigidbody>().useGravity = false;

            //    }
            //}

            //Transform target;
            //NavMeshHit hit;
            //bool blocked = false;


            //blocked = NavMesh.Raycast(transform.position, new Vector3(transform.position.x, -1, transform.position.z), out hit, NavMesh.AllAreas);
            //Debug.DrawLine(transform.position, new Vector3(transform.position.x, -1, transform.position.z), blocked ? Color.red : Color.green);

            //if (blocked)
            //    Debug.DrawRay(hit.position, Vector3.up, Color.red);

            //  Debug.Log(hit.distance);


        }

   

    void awake()
    {
        
        //pøiøadit text nad objektem
    }

    // Update is called once per frame
    public override void  Update()
    {
        //Transform target;
        //NavMeshHit hit;
        //bool blocked = false;


        //blocked = NavMesh.Raycast(transform.position, new Vector3(transform.position.x,-1, transform.position.z), out hit, NavMesh.AllAreas);
        //Debug.DrawLine(transform.position, new Vector3(transform.position.x, -1, transform.position.z), blocked ? Color.red : Color.green);

        //if (blocked)
        //    Debug.DrawRay(hit.position, transform.position, Color.red);

        //Debug.Log(hit.distance);
        //if (agent.enabled)
        //{
        //    if (agent.isOnNavMesh)
        //    {
        //        agent.SetDestination(new Vector3(transform.position.x + 5, transform.position.y, transform.position.z));
        //        agent.isStopped = true;
        //        // agent.enabled = false;
        //        gameObject.GetComponent<Rigidbody>().useGravity = false;

        //    }
        //}
        if (isLive)
        {
            StatsChangeTimeEntity();


        }

        Reproduce();
        transform.rotation = Quaternion.Euler(0, 0, 0);
        Wait(0.5f);
     
    }

    private void Reproduce()
    {
        if (age >= mature_age && canReproduce == true)
        {
            if (reproduce_cooldown_left > 0)
            {
                reproduce_cooldown_left -= Time.deltaTime;
            }
            else
            {

                Vector3 teren = new Vector3(Random.Range(1, 3) + gameObject.transform.position.x
                    , gameObject.transform.position.y,
                    Random.Range(0, 1) + gameObject.transform.position.z);
                //pokud to není keø
                if (type != 3)
                {
                    MaterialStorage.generator.GenerateEntityPopulation(kind,1, teren);
                    reproduce_cooldown_left = reproduce_cooldown;
                }
            }
        }
    }

    public override string GetEntityInformation()
    {
        string text = "";
        //   Debug.LogWarning("Info");
        text += kind + " " + name + " " + Mathf.Round(age * 10) / 10 + " ";
                return text;
    }


}
