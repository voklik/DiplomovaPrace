using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCollider : MonoBehaviour
{
    /// <summary>
    /// Tøída, která slouží pro detekci kolize u entity. Jedná se o kolize na tìlo > Narazil jsem na kámen> tìlo nesmí jít do kamene.
    /// Jedná se velice malou oblast
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
    /// Zastaví entitu na X vteøin
    /// </summary>
    /// <param name="x">Vteøin</param>
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
