using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseInfoSystem : MonoBehaviour
{


    [SerializeField] Text TextField;
    Entity entita;

    // Update is called once per frame
    void Update()
    {
        if (TextField != null)
        {

            if (TextField.gameObject.activeInHierarchy)

            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                LineRenderer lineRenderer = GetComponent<LineRenderer>();
               // Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.red, 0.5f, true);
                if (Physics.Raycast(ray, out hit, 100, (1 << LayerMask.NameToLayer("Animal"))))// | (1 << LayerMask.NameToLayer("Plant")))))
                {
                    Debug.DrawLine(ray.origin, hit.transform.position, Color.green, 2, true);

                    try
                    {

                        Entity e = null;
                        e = hit.collider.gameObject.GetComponentInParent<Entity>();
                        if (e != null)
                        {
                            entita = e;
                            Debug.LogWarning("Našel" + e.name);


                        }
                        TextField.text = entita.GetEntityInformation();
                    }
                    catch (System.Exception)
                    {
                        Debug.LogWarning("error");
                    }
                }
                else
                {
                    Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.yellow, 0.5f, true);
                    if (entita != null)
                        TextField.text = entita.GetEntityInformation();
                }

            }
        }
    }
}

