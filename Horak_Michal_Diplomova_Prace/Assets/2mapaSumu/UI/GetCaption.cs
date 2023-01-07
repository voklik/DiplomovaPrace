using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCaption : MonoBehaviour
{
    public string key;
    void Start()
    {
        string caption = CaptionsLibrary.GetCaption(key);

        //Jedná se o btn
        if (this.gameObject.GetComponent<UnityEngine.UI.Button>() != null)
        {
            if (this.gameObject.GetComponentInChildren<UnityEngine.UI.Text>() != null)
            {
                this.gameObject.GetComponentInChildren<UnityEngine.UI.Text>().text = caption;
            }
        }
        else if (this.gameObject.GetComponent<UnityEngine.UI.Text>() != null)
        {
            this.gameObject.GetComponent<UnityEngine.UI.Text>().text = caption;
        }
    }

}
