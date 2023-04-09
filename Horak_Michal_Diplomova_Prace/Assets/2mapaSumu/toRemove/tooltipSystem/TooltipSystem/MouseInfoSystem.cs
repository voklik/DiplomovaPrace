using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseInfoSystem : MonoBehaviour
{//Pokud myš pøejede pøes Zvíøe v simulaci, tak vypíše text do textfieldu


    [SerializeField] Text TextField;
    Entity entita;

    void Update()
    {
        if (TextField != null)
        {
            if (TextField.gameObject.activeInHierarchy)
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                LineRenderer lineRenderer = GetComponent<LineRenderer>();
                if (Physics.Raycast(ray, out RaycastHit hit, 100, (1 << LayerMask.NameToLayer("Animal"))))// | (1 << LayerMask.NameToLayer("Plant")))))
                {
                    //Debug.DrawLine(ray.origin, hit.transform.position, Color.green, 2, true);
                    try
                    {
                        Entity e = null;
                        e = hit.collider.gameObject.GetComponentInParent<Entity>();
                        if (e != null)
                        {
                            entita = e;
                        }
                        TextField.text = entita.GetEntityInformation();
                    }
                    catch (System.Exception e)
                    {
                        Debug.LogWarning(e.Message);
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

