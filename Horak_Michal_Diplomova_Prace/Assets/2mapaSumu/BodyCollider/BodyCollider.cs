using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCollider : MonoBehaviour
{
    /// <summary>
    /// T��da, kter� slou�� pro detekci kolize u entity. Jedn� se o kolize na t�lo > Narazil jsem na k�men> t�lo nesm� j�t do kamene.
    /// Jedn� se velice malou oblast
    /// </summary>

    [SerializeField] Entity entity = null;

    private SphereCollider sphereCollider;
    private void Start()
    {


        sphereCollider = gameObject.GetComponent<SphereCollider>();

        if (sphereCollider == null)
            sphereCollider = gameObject.AddComponent<SphereCollider>();
        Wait(0.2f);
        transform.localPosition = transform.localPosition + Vector3.zero;
    }
    /// <summary>
    /// Zastav� entitu na X vte�in
    /// </summary>
    /// <param name="x">Vte�in</param>
    public void Wait(float x)
    {
        WaitSeconds(x);
    }

    private IEnumerator WaitSeconds(float sec)
    {
        yield return new WaitForSeconds(sec);

    }


    public void setEntity(Entity e)
    {
        entity = e;
    }


    public void setRange(float radius)
    {

        if (sphereCollider != null)
        {
            sphereCollider.radius = radius;



        }
        else
        {
            sphereCollider = gameObject.GetComponent<SphereCollider>();
            sphereCollider.radius = radius;

        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name.Contains("Area"))
        {
            entity.GetInCollision(other.gameObject.transform.parent.gameObject);
        }
        else if (!other.gameObject.name.Contains("x:"))
        {
            entity.GetInCollision(other.gameObject);
        }

    }
    private void OnTriggerExit(Collider other)
    {

        if (entity != null)
        {
            if (other.gameObject.name.Contains("Area"))
            {
                entity.RemoveFromCollision(other.gameObject.transform.parent.gameObject);
            }
            else if (!other.gameObject.name.Contains("x:"))
            {
                entity.RemoveFromCollision(other.gameObject);
            }
        }
    }
}
