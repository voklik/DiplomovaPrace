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
        if(TextField!=null)
        {

            if(TextField.gameObject.activeInHierarchy)
 
            {
     
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 500, (1 << LayerMask.NameToLayer("Animal"))))// | (1 << LayerMask.NameToLayer("Plant")))))
                {
                  
                    try
                    {
                   
                        Entity e = null;
                    e=    hit.collider.gameObject.GetComponentInParent<Entity>();
                        if (e != null)
                        {
                            entita = e;
                            Debug.LogWarning("Našel"+e.name);

                          
                        }
                         TextField.text = entita.GetEntityInformation();
                    }
                    catch (System.Exception)
                    {
                        Debug.LogWarning("error");
                    }
                }
                else {if(entita!=null)
                    TextField.text = entita.GetEntityInformation(); }
                    
            }
            }
        }
    }

