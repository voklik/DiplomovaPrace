using System.Collections.Generic;
using UnityEngine;

public class OpenWindowScript : MonoBehaviour
{
    //T��da, kter� m� na starost otev�r�n� oken
    private static List<GameObject> ListOfWindows = new List<GameObject>();

    [SerializeField] GameObject Window;

    private void Start()
    {
        //p�i op�tovn�m zapnut� simulace se mus� vynulovat seznam
        ListOfWindows.Clear();
    }

    public void Open()
    {
        if (Window != null)
        {
            if (!Window.activeInHierarchy)
            { Window.SetActive(true); }
        }
    }

    public void OpenAndCloseOther()
    {
        if (Window != null)
        {
            if (!Window.activeInHierarchy)
            {
                if (!ListOfWindows.Contains(Window))
                { ListOfWindows.Add(Window); }
                foreach (GameObject item in ListOfWindows)
                {
                    item.SetActive(false);
                }
                Window.SetActive(true);
            }
        }
    }
}
