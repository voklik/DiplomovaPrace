using System.Collections.Generic;
using UnityEngine;

public class OpenWindowScript : MonoBehaviour
{
    //Tøída, která má na starost otevírání oken
    private static List<GameObject> ListOfWindows = new List<GameObject>();

    [SerializeField] GameObject Window;

    private void Start()
    {
        //pøi opìtovném zapnutí simulace se musí vynulovat seznam
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
