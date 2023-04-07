using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int layer_mask = LayerMask.GetMask("Terrain");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 30, layer_mask))
            {
                try
                {
                    //  hit.transform.gameObject.GetComponent<Teren>().OnMouseOver();
                    MaterialStorage.toolltipUI.DisplayInfo(hit.transform.name);
                }
                catch (System.Exception)
                {
                    //     MaterialStorage.toolltipUI.DisplayInfo("");
                    return;
                }
            }
        }
    }
}
