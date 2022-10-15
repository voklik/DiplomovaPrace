using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCollider : MonoBehaviour
{
    [SerializeField] Entity entity = null;

    private float radius = 10;
    private float time = 0.0f;
    private SphereCollider sphereCollider;
    private void Start()
    {


        sphereCollider = gameObject.GetComponent<SphereCollider>();

        if (sphereCollider == null)
            sphereCollider=gameObject.AddComponent<SphereCollider>();
        Wait(0.2f);
        transform.localPosition = transform.localPosition + Vector3.zero;
    }

    public void Wait(float x)
    {
        waiter(x);
    }

    private IEnumerator waiter(float sec)
    {
        yield return new WaitForSeconds(sec);

    }


    public void setEntity(Entity e)
    {
        entity = e;
    }


    public void setRange(float a)
    {

        if (sphereCollider != null)
        {
            sphereCollider.radius = a;



        }
        else
        {
            sphereCollider = gameObject.GetComponent<SphereCollider>();
            sphereCollider.radius = a;

        }
        radius = a;
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (entity != null)
        //{ entity.Vypis("meet" + other.name);
        //    entity.GetInCollision(other.gameObject);
        //}

        if (other.gameObject.name.Contains("Area"))
        {
                   entity.Vypis("kolize " + other.gameObject.transform.parent.name);
            entity.GetInCollision(other.gameObject.transform.parent.gameObject);
         
        }
        else if (!other.gameObject.name.Contains("x:"))
        {
                  entity.Vypis("AAAAkolize " + other.gameObject.name);
            entity.GetInCollision(other.gameObject);
        }

    }
    private void OnTriggerExit(Collider other)
    {
       
        if (entity != null)
          
        {
           // entity.Vypis("kolize konec" + other.name);
            //entity.RemoveFromCollision(other.gameObject);

            if (other.gameObject.name.Contains("Area"))
            {
                entity.Vypis("kolize konec " + other.gameObject.transform.parent.name);
                entity.RemoveFromCollision(other.gameObject.transform.parent.gameObject);

            }
            else if (!other.gameObject.name.Contains("x:"))
            {
                entity.Vypis("AAAAkolize konec" + other.gameObject.name);
                entity.RemoveFromCollision(other.gameObject);
            }
        }
    }
}
