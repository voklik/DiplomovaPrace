using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminateApplication : MonoBehaviour
{
    //Pøiøazuje se k tlaèítku na hlavním menu, aby se mohla ukonèit celá aplikace
    public void ExterminateApplication()
    {
        // Rozhoduje se, zda se vypne hra, èi v enginu se zruší probíhající testování
#if UNITY_EDITOR
      
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
