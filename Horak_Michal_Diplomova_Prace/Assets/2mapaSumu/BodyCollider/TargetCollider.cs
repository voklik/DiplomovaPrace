using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollider : MonoBehaviour
{
    /// <summary>
    /// Tøída, která slouží pro detekci kolize u entity. Jedná se o kolize na "dosah vnímání" entity > Vidím/Cítím vodu/entitu.
    /// Díky této tøídì se nemusí procházet seznam všech entit, ale jen seznam tìch entit, které se pøes tuto tøídu pøidají(a následnì odebírají) z seznamu u entity.
    /// Jedná se velkou oblast
    /// </summary>
    [SerializeField] Entity entity = null;

    private float radius = 1;
    private float time = 0.0f;
    private SphereCollider sphereCollider;
    private void Awake()
    {
        sphereCollider = gameObject.GetComponent<SphereCollider>();
        Wait(0.2f);
        transform.localPosition = transform.localPosition + Vector3.zero;
    }
    private void Update()
    {
        time = time + Time.deltaTime;

        if (time < 10.0f)
        {
            sphereCollider.radius += (float)(0.01 * Time.deltaTime);
        }
        else if (time > 10.0f)
        {
            sphereCollider.radius -= (float)(0.01 * Time.deltaTime);
        }
        else if (time > 20.0f)
        {
            time = 0;
            sphereCollider.radius = radius;
        }

    }

    public void Wait(float x)
    {
        Waiter(x);
    }

    private IEnumerator Waiter(float sec)
    {
        yield return new WaitForSeconds(sec);

    }


    public void SetEntity(Entity e)
    {
        entity = e;
    }


    public void SetRange(float a)
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

        if (entity != null)
        {
            //   entity.Vypis("meet2" + other.gameObject.name);
            if (other.gameObject.name.Contains("Area"))
            {
                //       entity.Vypis("meet21" + other.gameObject.transform.parent.name);
                entity.GameobjectSpotted(other.gameObject.transform.parent.gameObject);
            }
            else
            {
                //      entity.Vypis("meet22" + other.gameObject.name);
                entity.GameobjectSpotted(other.gameObject);
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (entity != null)
            entity.gameobjectEscaped(other.gameObject);

    }
}
